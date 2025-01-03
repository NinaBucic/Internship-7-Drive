using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Helpers
{
    public static class HelpMenu
    {
        public static void DisplayGeneralCommands()
        {
            Console.WriteLine("\nAvailable Commands: (write names without ‘ ’) \n" +
                 "help – Displays all available commands.\n" +
                 "create folder ‘folder name’ – Creates a folder in the current location.\n" +
                 "create file ‘file name’ – Creates a file in the current location.\n" +
                 "enter folder ‘folder name’ – Navigates into the specified folder.\n" +
                 "edit file ‘file name’ – Edits the specified file.\n" +
                 "delete ‘folder or file name’ – Deletes the specified folder or file.\n" +
                 "rename ‘folder or file name’ to ‘new name’ – Renames the specified folder or file.\n" +
                 "back – Return\n");
        }

        public static void DisplayEditFileCommands()
        {
            Console.WriteLine("\nFile Editor Commands:\n" +
                ":help - Display all commands\n" +
                ":save and exit - Save changes and exit\n" +
                ":exit - Exit without saving\n"+
                "Backspace on empty input - Remove last line");
        }
    }
}
