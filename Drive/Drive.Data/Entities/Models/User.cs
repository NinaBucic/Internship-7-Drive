using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Data.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Folder> Folders { get; set; } = new List<Folder>();
        public ICollection<File> Files { get; set; } = new List<File>();

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
