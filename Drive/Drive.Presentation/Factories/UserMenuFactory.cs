using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.MainMenu;
using Drive.Presentation.Actions.SharedMenu;
using Drive.Data.Entities.Models;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;

namespace Drive.Presentation.Factories
{
    public static class UserMenuFactory
    {
        public static MainUserMenuAction Create(User currentUser)
        {
            var actions = new List<IAction>
            {
                DiskMenuFactory.Create(currentUser),
                new SharedWithMeAction(RepositoryFactory.Create<SharedItemRepository>(),RepositoryFactory.Create<FileRepository>(),currentUser),
                ProfileSettingsMenuFactory.Create(currentUser),
                new LogoutAction()
            };

            return new MainUserMenuAction(actions);
        }
    }
}
