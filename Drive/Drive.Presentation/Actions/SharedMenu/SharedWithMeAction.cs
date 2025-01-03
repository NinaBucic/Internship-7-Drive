using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.CommentsMenu;
using Drive.Presentation.Actions.DiskMenu;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.SharedMenu
{
    public class SharedWithMeAction : IAction
    {
        private readonly SharedItemRepository _sharedItemRepository;
        private readonly FileRepository _fileRepository;
        private readonly User _currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Shared With Me";

        public SharedWithMeAction(
            SharedItemRepository sharedItemRepository,
            FileRepository fileRepository,
            User currentUser)
        {
            _sharedItemRepository = sharedItemRepository;
            _fileRepository = fileRepository;
            _currentUser = currentUser;
        }

        public void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Shared With Me - User: {_currentUser.Email}\n");

                var sharedFolders = _sharedItemRepository.GetSharedFolders(_currentUser.Id);
                var sharedFiles = _sharedItemRepository.GetSharedFiles(_currentUser.Id);

                if (!sharedFolders.Any() && !sharedFiles.Any())
                {
                    Writer.WriteError("No items shared with you.");
                    break;
                }

                Writer.DisplayFolders(sharedFolders);
                Writer.DisplayFiles(sharedFiles);

                Console.WriteLine("\nEnter a command (type 'help' for a list of commands):");
                var command = Console.ReadLine()?.ToLower();
                Console.Clear();

                if (string.IsNullOrWhiteSpace(command)) continue;

                if (command == "help")
                {
                    HelpMenu.DisplaySharedCommands();
                    Console.ReadKey();
                    continue;
                }

                if (command == "back") break;

                if (CommandParser.TryParseCommand(command, "edit file ", out var fileName))
                {
                    var fileToEdit = _sharedItemRepository.GetSharedFiles(_currentUser.Id)
                        .FirstOrDefault(f => f.Name.ToLower().Equals(fileName));

                    if (fileToEdit == null)
                    {
                        Writer.WriteError($"File '{fileName}' not found in your shared items.");
                        continue;
                    }

                    var editAction = new EditFileAction(fileToEdit,_fileRepository);
                    editAction.Open();
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "delete ", out var itemName))
                {
                    HandleDeleteSharedItem(itemName);
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "view comments ", out var fileName2))
                {
                    var file = _sharedItemRepository.GetSharedFiles(_currentUser.Id)
                        .FirstOrDefault(f => f.Name.ToLower() == fileName2.ToLower());

                    if (file == null)
                    {
                        Writer.WriteError($"File '{fileName2}' not found in your shared items.");
                        continue;
                    }

                    var viewCommentsAction = new ViewCommentsAction(
                        RepositoryFactory.Create<CommentRepository>(),
                        file,
                        _currentUser
                    );
                    viewCommentsAction.Open();
                    continue;
                }


                Writer.WriteError("Invalid command. Type 'help' to see available commands.");
                continue;
            }
        }

        private void HandleDeleteSharedItem(string itemName)
        {
            var folder = _sharedItemRepository.GetSharedFolders(_currentUser.Id)
                .FirstOrDefault(f => f.Name.ToLower().Equals(itemName));

            var file = _sharedItemRepository.GetSharedFiles(_currentUser.Id)
                .FirstOrDefault(f => f.Name.ToLower().Equals(itemName));

            if (folder == null && file == null)
            {
                Writer.WriteError($"Item '{itemName}' not found in your shared items.");
                return;
            }

            if (folder != null && file != null)
            {
                var choice = Reader.FolderOrFile(itemName);
                if (choice == "folder") file = null;
                else folder = null;
            }

            if (!Reader.Confirm($"Are you sure you want to remove '{itemName}' from your shared list? "))
            {
                return;
            }

            ResponseResultType result;

            if (folder != null)
            {
                result = _sharedItemRepository.RemoveFromRecipient(_currentUser.Id, folder.Id, null);
            }
            else
            {
                result = _sharedItemRepository.RemoveFromRecipient(_currentUser.Id, null, file!.Id);
            }

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine($"'{itemName}' successfully removed from your shared list.");
                Console.ReadKey();
            }
            else
            {
                Writer.WriteError($"Failed to remove '{itemName}' from your shared list.");
            }
        }
    }
}
