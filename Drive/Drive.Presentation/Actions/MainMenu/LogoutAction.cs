using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MainMenu
{
    public class LogoutAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Logout";

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("You have logged out. Returning to the main menu...");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
