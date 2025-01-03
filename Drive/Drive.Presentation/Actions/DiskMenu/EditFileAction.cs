using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.DiskMenu
{
    public class EditFileAction : IAction
    {
        private readonly File _file;
        private readonly FileRepository _fileRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; }

        public EditFileAction(File file, FileRepository fileRepository)
        {
            _file = file;
            _fileRepository = fileRepository;
            Name = $"Edit File: {_file.Name}";
        }

        public void Open()
        {
            var newContent = new List<string>(_file.Content?.Split(Environment.NewLine) ?? Array.Empty<string>());

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Editing File: {_file.Name}\n");
                Console.WriteLine("Current Content:");
                DisplayCurrentContent(newContent);

                Console.Write("\n> Press enter for new line or command, backpace for delete last line");
                var key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (newContent.Count > 0)
                    {
                        newContent.RemoveAt(newContent.Count - 1);
                    }
                    continue;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Write("\n> ");
                    var input = Console.ReadLine();

                    if (input != null && input.StartsWith(":"))
                    {
                        if (HandleCommand(input, newContent))
                            break;
                    }
                    else if (!string.IsNullOrWhiteSpace(input))
                        newContent.Add(input);
                    else
                        newContent.Add("");
                }
            }
        }

        private void DisplayCurrentContent(List<string> content)
        {
            if (content.Count == 0)
            {
                Console.WriteLine("(Empty file)");
                return;
            }

            foreach (var line in content)
            {
                Console.WriteLine(line);
            }
        }

        private bool HandleCommand(string command, List<string> newContent)
        {
            switch (command)
            {
                case ":help":
                    HelpMenu.DisplayEditFileCommands();
                    Console.ReadKey();
                    return false;

                case ":save and exit":
                    _file.Content = string.Join(Environment.NewLine, newContent);
                    _file.LastModifiedAt = DateTime.UtcNow;

                    var result = _fileRepository.Update(_file);
                    if (result == ResponseResultType.Success)
                    {
                        Console.WriteLine("File saved successfully.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Failed to save file. Try again.");
                    }
                    return true;

                case ":exit":
                    Writer.WriteError("Exiting without saving changes.");
                    return true;

                default:
                    Writer.WriteError("Invalid command. Type ':help' for a list of commands.");
                    return false;
            }
        }
    }
}
