using Drive.Data.Entities.Models;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions.DiskMenu;

namespace Drive.Presentation.Factories
{
    public static class DiskMenuFactory
    {
        public static MyDriveAction Create(User currentUser)
        {
            var actions = new List<IAction>
            {
            };

            return new MyDriveAction(
                RepositoryFactory.Create<FolderRepository>(),
                RepositoryFactory.Create<FileRepository>(),
                currentUser,
                actions
            );
        }
    }

}
