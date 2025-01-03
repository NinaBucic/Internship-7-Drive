﻿using System.Text.RegularExpressions;

namespace Drive.Presentation.Helpers
{
    public static class Reader
    {
        public static bool Confirm(string message)
        {
            Console.Write($"{message} (yes/no): ");
            var stringInput = "";
            stringInput = Console.ReadLine()?.ToLower();
            while (stringInput != "yes" && stringInput != "no")
            {
                Console.Write("Invalid input! Please try again (yes/no): ");
                stringInput = Console.ReadLine()?.ToLower();
            }
            return stringInput == "yes";
        }

        public static string FolderOrFile(string itemName)
        {
            Console.Write($"Both a folder and file named '{itemName}' exist. Specify 'folder' or 'file': ");
            var stringInput = "";
            stringInput = Console.ReadLine()?.ToLower();
            while (stringInput != "folder" && stringInput != "file")
            {
                Console.Write("Invalid input! Please try again (folder/file): ");
                stringInput = Console.ReadLine()?.ToLower();
            }
            return stringInput;
        }

        public static void ReadInput(string message, out string input)
        {
            Console.Write(message);
            input = Console.ReadLine() ?? string.Empty;
        }

        public static bool ValidateString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool ValidateEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]{2,}\.[^@\s]{3,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static string GenerateCaptcha()
        {
            var random = new Random();
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var digits = "0123456789";

            char letter = letters[random.Next(letters.Length)];
            char digit = digits[random.Next(digits.Length)];

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var remainingChars = Enumerable.Repeat(chars, 4)
                .Select(s => s[random.Next(s.Length)])
                .ToList();

            remainingChars.Add(letter);
            remainingChars.Add(digit);

            var captcha = new string(remainingChars.OrderBy(_ => random.Next()).ToArray());

            return captcha;
        }

    }
}
