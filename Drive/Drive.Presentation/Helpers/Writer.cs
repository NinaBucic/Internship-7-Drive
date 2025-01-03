using Drive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Helpers
{
    public static class Writer
    {
        public static void Write(User user)
        {
            Console.WriteLine($"User: {user.Id}, Email: {user.Email}");
        }

        public static void WriteError(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void DisplayFolders(IEnumerable<Folder> folders)
        {
            Console.WriteLine("Folders:");
            foreach (var folder in folders)
            {
                Console.WriteLine($" - [{folder.Id}] {folder.Name} (Last Modified: {folder.LastModified})");
            }
            Console.WriteLine();
        }

        public static void DisplayFiles(IEnumerable<File> files)
        {
            Console.WriteLine("Files:");
            foreach (var file in files)
            {
                Console.WriteLine($" - [{file.Id}] {file.Name} (Last Modified: {file.LastModifiedAt})");
            }
            Console.WriteLine();
        }
    }
}
