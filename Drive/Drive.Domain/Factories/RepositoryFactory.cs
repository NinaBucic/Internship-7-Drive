using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drive.Domain.Repositories;

namespace Drive.Domain.Factories
{
    public static class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
            where TRepository : BaseRepository
        {
            var dbContext = DbContextFactory.GetDriveDbContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

            return repositoryInstance!;
        }
    }
}
