using Drive.Presentation.Abstractions;

namespace Drive.Presentation.Actions.ProfileMenu
{
    public class ProfileSettingsAction : BaseMenuAction
    {
        public ProfileSettingsAction(IList<IAction> actions) : base(actions)
        {
            Name = "Profile Settings";
        }

        public override void Open()
        {
            Console.Clear();
            Console.WriteLine("Profile Settings Menu");
            base.Open();
        }
    }
}
