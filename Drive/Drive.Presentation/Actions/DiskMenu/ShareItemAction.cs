using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using System.Diagnostics;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.DiskMenu
{
    public class ShareItemAction : IAction
    {
        private readonly FolderRepository _folderRepository;
        private readonly FileRepository _fileRepository;
        private readonly UserRepository _userRepository;
        private readonly SharedItemRepository _sharedItemRepository;
        private readonly User _currentUser;
        private Folder? _currentFolder;

        private string? _itemName;
        private string? _email;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Share Item";

        public ShareItemAction(
            FolderRepository folderRepository,
            FileRepository fileRepository,
            UserRepository userRepository,
            SharedItemRepository sharedItemRepository,
            User currentUser,
            Folder? currentFolder)
        {
            _folderRepository = folderRepository;
            _fileRepository = fileRepository;
            _userRepository = userRepository;
            _sharedItemRepository = sharedItemRepository;
            _currentUser = currentUser;
            _currentFolder = currentFolder;
        }

        public void SetParameters(string itemName, string email)
        {
            _itemName = itemName;
            _email = email;
        }

        public void Open()
        {
            if (string.IsNullOrWhiteSpace(_itemName) || string.IsNullOrWhiteSpace(_email))
            {
                Writer.WriteError("Item name or email not provided.");
                return;
            }

            Folder? folder = null;
            File? file = null;

            if (!CommandParser.TryResolveItem(
                    _itemName,
                    _folderRepository,
                    _fileRepository,
                    _currentUser.Id,
                    _currentFolder?.Id,
                    out folder,
                    out file))
            {
                var choice=Reader.FolderOrFile(_itemName);
                if (choice == "folder") file = null;
                else folder = null;
            }

            if (folder == null && file == null)
            {
                Writer.WriteError("No valid item selected to share.");
                return;
            }

            var recipient = _userRepository.GetByEmail(_email);
            if (recipient == null)
            {
                Writer.WriteError($"No user found with email '{_email}'.");
                return;
            }

            var sharedItem = new SharedItem
            {
                OwnerId = _currentUser.Id,
                RecipientId = recipient.Id,
                FolderId = folder?.Id,
                FileId = file?.Id
            };

            var result = _sharedItemRepository.Add(sharedItem);

            switch (result)
            {
                case ResponseResultType.Success:
                    Console.WriteLine("Item successfully shared!");
                    Console.ReadKey();
                    break;
                case ResponseResultType.NoChanges:
                    Writer.WriteError("This item is already shared with the user.");
                    break;
                default:
                    Writer.WriteError("Failed to share item.");
                    break;
            }
        }
    }
}
