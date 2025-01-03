using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.DiskMenu
{
    public class MyDriveAction : BaseMenuAction
    {
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly User _currentUser;
        private Folder? _currentFolder;

        public MyDriveAction(FolderRepository folderRepository, FileRepository fileRepository, User currentUser, IList<IAction> actions)
            : base(actions)
        {
            Name = "My Drive";
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _currentUser = currentUser;
            _currentFolder = null;
        }

        public override void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"My Drive - User: {_currentUser.Email}\n");

                DisplayFoldersAndFiles();

                Console.WriteLine("\nEnter a command (type 'help' for a list of commands):");
                var command = Console.ReadLine()?.ToLower();
                Console.Clear();

                if (string.IsNullOrWhiteSpace(command)) continue;

                if (command == "help")
                {
                    HelpMenu.DisplayGeneralCommands();
                    Console.ReadKey();
                    continue;
                }

                if (command == "back")
                {
                    if (_currentFolder == null) break;
                    _currentFolder = _currentFolder.ParentFolder;
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "enter folder ", out var folderName))
                {
                    var folder = _folderRepository.GetByNameAndParent(folderName, _currentUser.Id, _currentFolder?.Id);
                    if (folder == null)
                    {
                        Writer.WriteError($"Folder '{folderName}' not found.");
                        continue;
                    }
                    _currentFolder = folder;
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "create folder ", out var newFolderName))
                {
                    HandleCreateFolder(newFolderName);
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "create file ", out var fileName))
                {
                    HandleCreateFile(fileName);
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "edit file ", out var fileToEdit))
                {
                    var file = _fileRepository.GetByNameAndParent(fileToEdit, _currentUser.Id, _currentFolder?.Id);
                    if (file == null)
                    {
                        Writer.WriteError($"File '{fileToEdit}' not found.");
                        continue;
                    }

                    var editAction = new EditFileAction(file,_fileRepository);
                    editAction.Open();
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "delete ", out var itemToDelete))
                {
                    if (!CommandParser.TryResolveItem(
                            itemToDelete,
                            _folderRepository,
                            _fileRepository,
                            _currentUser.Id,
                            _currentFolder?.Id,
                            out var folder,
                            out var file))
                    {
                        var choice = Reader.FolderOrFile(itemToDelete);
                        if (choice == "folder") file = null;
                        else folder = null;
                    }

                    if (folder != null)
                    {
                        if (!Reader.Confirm($"Are you sure you want to delete the folder '{folder.Name}'?"))
                        {
                            continue;
                        }

                        var result = _folderRepository.Delete(folder);

                        if (result == ResponseResultType.Success)
                        {
                            Console.WriteLine($"Folder '{folder.Name}' successfully deleted.");
                        }
                        else
                        {
                            Writer.WriteError($"Failed to delete folder '{folder.Name}'.");
                        }
                    }
                    else if (file != null)
                    {
                        if (!Reader.Confirm($"Are you sure you want to delete the file '{file.Name}'?"))
                        {
                            continue;
                        }

                        var result = _fileRepository.Delete(file);

                        if (result == ResponseResultType.Success)
                        {
                            Console.WriteLine($"File '{file.Name}' successfully deleted.");
                        }
                        else
                        {
                            Writer.WriteError($"Failed to delete file '{file.Name}'.");
                        }
                    }
                    else
                    {
                        Writer.WriteError($"Item '{itemToDelete}' not found in the current directory.");
                    }

                    Console.ReadKey();
                    continue;
                }


                if (CommandParser.TryParseShareCommand(command, out var itemToShare, out var emailToShareWith))
                {
                    var shareAction = new ShareItemAction(
                        _folderRepository,
                        _fileRepository,
                        RepositoryFactory.Create<UserRepository>(),
                        RepositoryFactory.Create<SharedItemRepository>(),
                        _currentUser,
                        _currentFolder
                    );

                    shareAction.SetParameters(itemToShare, emailToShareWith);
                    shareAction.Open();
                    continue;
                }

                if (CommandParser.TryParseUnshareCommand(command, out var itemToUnshare, out var emailToUnshareWith))
                {
                    var unshareAction = new UnshareItemAction(
                        _folderRepository,
                        _fileRepository,
                        RepositoryFactory.Create<UserRepository>(),
                        RepositoryFactory.Create<SharedItemRepository>(),
                        _currentUser,
                        _currentFolder
                    );

                    unshareAction.SetParameters(itemToUnshare, emailToUnshareWith);
                    unshareAction.Open();
                    continue;
                }

                Writer.WriteError("Invalid command. Type 'help' to see available commands.");
                continue;
            }
        }

        private void DisplayFoldersAndFiles()
        {
            if (_currentFolder == null) 
            {
                var folders = _folderRepository.GetRootFolders(_currentUser.Id);
                var files = _fileRepository.GetFilesWithoutFolder(_currentUser.Id);

                Writer.DisplayFolders(folders);
                Writer.DisplayFiles(files);
                return;
            }
            else
            {
                var folders = _folderRepository.GetSubFolders(_currentFolder.Id, _currentUser.Id);
                var files = _fileRepository.GetFilesByFolderId(_currentFolder.Id, _currentUser.Id);

                Writer.DisplayFolders(folders);
                Writer.DisplayFiles(files);
            }
        }

        private void HandleCreateFolder(string folderName)
        {
            if (string.IsNullOrWhiteSpace(folderName))
            {
                Writer.WriteError("Folder name cannot be empty.");
                return;
            }

            if (!Reader.Confirm($"Are you sure you want to create the folder '{folderName}'?"))
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            var newFolder = new Folder
            {
                Name = folderName,
                OwnerId = _currentUser.Id,
                ParentFolderId = _currentFolder?.Id,
                CreatedAt = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };

            var responseResult = _folderRepository.Add(newFolder);
            switch (responseResult)
            {
                case ResponseResultType.Success:
                    Console.WriteLine($"Folder '{folderName}' created successfully.");
                    Console.ReadKey();
                    break;
                case ResponseResultType.AlreadyExists:
                    Writer.WriteError($"Folder '{folderName}' already exists in the current location.");
                    break;
                case ResponseResultType.NoChanges:
                    Writer.WriteError($"Failed to create folder '{folderName}'. No changes saved.");
                    break;
                default:
                    Writer.WriteError("An unexpected error occurred.");
                    break;
            }
        }

        private void HandleCreateFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                Writer.WriteError("File name cannot be empty.");
                return;
            }

            if (!Reader.Confirm($"Are you sure you want to create the file '{fileName}'?"))
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            var newFile = new File
            {
                Name = fileName,
                OwnerId = _currentUser.Id,
                FolderId = _currentFolder?.Id,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow,
                Content = null
            };

            var responseResult = _fileRepository.Add(newFile);
            switch (responseResult)
            {
                case ResponseResultType.Success:
                    Console.WriteLine($"File '{fileName}' created successfully.");
                    Console.ReadKey();
                    break;
                case ResponseResultType.AlreadyExists:
                    Writer.WriteError($"File '{fileName}' already exists in the current location.");
                    break;
                case ResponseResultType.NoChanges:
                    Writer.WriteError($"Failed to create file '{fileName}'. No changes saved.");
                    break;
                default:
                    Writer.WriteError("An unexpected error occurred.");
                    break;
            }
        }


    }
}
