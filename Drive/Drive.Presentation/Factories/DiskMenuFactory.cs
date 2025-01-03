using Drive.Data.Entities.Models;
using Drive.Domain.Factories;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Actions;
using Drive.Presentation.Actions.DiskMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
