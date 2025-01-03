using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.ProfileMenu;
using Drive.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drive.Data.Entities.Models;

namespace Drive.Presentation.Factories
{
    public static class ProfileSettingsMenuFactory
    {
        public static ProfileSettingsAction Create(User currentUser)
        {
            var actions = new List<IAction>
            {
                new ChangeEmailAction(RepositoryFactory.Create<UserRepository>(),currentUser),
                new ChangePasswordAction(RepositoryFactory.Create<UserRepository>(), currentUser),
                new ExitMenuAction()
            };

            return new ProfileSettingsAction(actions);
        }
    }
}
