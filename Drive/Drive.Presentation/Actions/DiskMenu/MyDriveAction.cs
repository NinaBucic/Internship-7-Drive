using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    var folder = _folderRepository.GetByName(folderName, _currentUser.Id);
                    if (folder == null)
                    {
                        Writer.WriteError($"Folder '{folderName}' not found.");
                        continue;
                    }
                    _currentFolder = folder;
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
    }
}
