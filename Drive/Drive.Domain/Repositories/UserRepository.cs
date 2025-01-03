using Drive.Data.Entities;
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

        public ResponseResultType Add(User user)
        {
            DbContext.Users.Add(user);
            return SaveChanges();
        }

        public ResponseResultType Update(User user)
        {
            var existingUser = DbContext.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser == null)
                return ResponseResultType.NotFound;

            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            return SaveChanges();
        }
    }
}
