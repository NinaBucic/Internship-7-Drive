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
                 "share ‘folder or file name’ with ‘email’ – Shares a folder or file with the specified user.\n" +
                 "unshare ‘folder or file name’ with ‘email’ – Stops sharing a folder or file with the specified user.\n" +
                 "back – Return\n");
        }

        public static void DisplaySharedCommands()
        {
            Console.WriteLine("\nAvailable Commands: (write names without ‘ ’) \n" +
                "help – Displays all available commands.\n" +
                "edit file ‘file name’ – Edits the specified file.\n" +
                "delete ‘folder or file name’ – Removes the shared folder or file from your list.\n" +
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

        public static void DisplayCommentCommands()
        {
            Console.WriteLine("\nComment Commands:\n" +
                "add comment - Add a new comment.\n" +
                "edit comment ‘comment ID’ - Edit a specific comment.\n" +
                "delete comment ‘comment ID’ - Delete a specific comment.\n" +
                "back - Return to the previous menu.\n");
        }
    }
}
