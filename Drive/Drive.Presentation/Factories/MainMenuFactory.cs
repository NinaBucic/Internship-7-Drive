using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MainMenu;
using Drive.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static MainMenuAction Create()
        {
            var actions = new List<IAction>
            {
                new LoginAction(RepositoryFactory.Create<UserRepository>()),
                new RegisterAction(RepositoryFactory.Create<UserRepository>()),
                new ExitMenuAction()
            };

            return new MainMenuAction(actions);
        }
    }
}
