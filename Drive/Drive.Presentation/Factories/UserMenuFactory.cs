using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.DiskMenu;
using Drive.Presentation.Actions.MainMenu;
using Drive.Presentation.Actions.ProfileMenu;
using Drive.Presentation.Actions.SharedMenu;
using Drive.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Factories
{
    public static class UserMenuFactory
    {
        public static MainUserMenuAction Create()
        {
            var actions = new List<IAction>
            {
                new MyDriveAction(),
                new SharedWithMeAction(),
                new ProfileSettingsAction(),
                new LogoutAction()
            };

            return new MainUserMenuAction(actions);
        }
    }
}
