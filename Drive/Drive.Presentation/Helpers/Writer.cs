using Drive.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
