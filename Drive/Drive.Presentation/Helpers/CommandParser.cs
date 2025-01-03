using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Helpers
{
    public static class CommandParser
    {
        public static bool TryParseCommand(string command, string prefix, out string parameter)
        {
            parameter = string.Empty;

            if (string.IsNullOrWhiteSpace(command) || !command.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            parameter = command.Substring(prefix.Length).Trim();
            return !string.IsNullOrWhiteSpace(parameter);
        }

        public static bool TryParseShareCommand(string command, out string itemName, out string email)
        {
            const string commandPrefix = "share ";
            const string withKeyword = " with ";

            itemName = string.Empty;
            email = string.Empty;

            if (string.IsNullOrWhiteSpace(command) || !command.StartsWith(commandPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var splitCommand = command.Substring(commandPrefix.Length).Split(new[] { withKeyword }, StringSplitOptions.None);

            if (splitCommand.Length != 2)
            {
                return false;
            }

            itemName = splitCommand[0].Trim();
            email = splitCommand[1].Trim();

            return !string.IsNullOrWhiteSpace(itemName) && !string.IsNullOrWhiteSpace(email);
        }

        public static bool TryParseUnshareCommand(string command, out string itemName, out string email)
        {
            const string commandPrefix = "unshare ";
            const string withKeyword = " with ";

            itemName = string.Empty;
            email = string.Empty;

            if (string.IsNullOrWhiteSpace(command) || !command.StartsWith(commandPrefix, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var splitCommand = command.Substring(commandPrefix.Length).Split(new[] { withKeyword }, StringSplitOptions.None);

            if (splitCommand.Length != 2)
            {
                return false;
            }

            itemName = splitCommand[0].Trim();
            email = splitCommand[1].Trim();

            return !string.IsNullOrWhiteSpace(itemName) && !string.IsNullOrWhiteSpace(email);
        }

        public static bool TryResolveItem(
            string itemName,
            FolderRepository folderRepository,
            FileRepository fileRepository,
            int ownerId,
            int? parentFolderId,
            out Folder? folder,
            out File? file)
        {
            folder = folderRepository.GetByNameAndParent(itemName, ownerId, parentFolderId);
            file = fileRepository.GetByNameAndParent(itemName, ownerId, parentFolderId);

            if (folder != null && file != null) return false;

            return true;
        }
    }
}
