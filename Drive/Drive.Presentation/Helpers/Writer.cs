using Drive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public static void DisplayComments(IEnumerable<Comment> comments)
        {
            if (!comments.Any())
            {
                Console.WriteLine("No comments found for this file.\n");
                return;
            }

            foreach (var comment in comments)
            {
                var authorEmail = comment.Author?.Email ?? "Unknown Author";
                var date = comment.LastModified?.ToString("yyyy-MM-dd HH:mm") ?? comment.CreatedAt.ToString("yyyy-MM-dd HH:mm");

                Console.WriteLine($"ID: {comment.Id} | Author: {authorEmail} | Date: {date}");
                Console.WriteLine($"Content: {comment.Content}\n");
            }
            Console.WriteLine();
        }
    }
}
