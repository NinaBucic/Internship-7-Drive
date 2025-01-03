using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.MainMenu
{
    public class MainUserMenuAction : BaseMenuAction
    {
        public MainUserMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "User Main Menu";
        }

        public override void Open()
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Drive!");
            base.Open();
        }
    }
}
