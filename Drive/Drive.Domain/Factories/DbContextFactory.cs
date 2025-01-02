using Drive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Factories
{
    public static class DbContextFactory
    {
        public static DriveDbContext GetDriveDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Drive"].ConnectionString)
                .Options;

            return new DriveDbContext(options);
        }
    }
}
