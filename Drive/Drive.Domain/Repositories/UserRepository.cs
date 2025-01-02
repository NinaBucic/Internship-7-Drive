using Drive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;

namespace Drive.Domain.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public User? GetByEmail(string email)
        {
            return DbContext.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
