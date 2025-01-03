using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MainMenu
{
    public class MainMenuAction : BaseMenuAction
    {
        public MainMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "Main Menu";
        }

        public override void Open()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Drive!");
            base.Open();
        }
    }
}
