using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Data.Entities.Models
{
    public class SharedItem
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; } = null!;

        public int RecipientId { get; set; }
        public User Recipient { get; set; } = null!;

        public int? FolderId { get; set; }
        public Folder? Folder { get; set; }

        public int? FileId { get; set; }
        public File? File { get; set; }
    }
}
