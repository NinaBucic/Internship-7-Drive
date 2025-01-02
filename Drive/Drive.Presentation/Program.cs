using Drive.Presentation.Factories;

namespace Drive.Presentation

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = MainMenuFactory.Create();
            mainMenu.Open();
        }
    }
}
