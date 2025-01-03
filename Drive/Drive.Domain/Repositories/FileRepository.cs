using Drive.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Domain.Repositories
{
    public class FileRepository : BaseRepository
    {
        public FileRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<File> GetFilesWithoutFolder(int ownerId)
        {
            return DbContext.Files
                .Where(f => f.OwnerId == ownerId && f.FolderId == null)
                .OrderByDescending(f => f.LastModifiedAt)
                .ToList();
        }

        public ICollection<File> GetFilesByFolderId(int folderId, int ownerId)
        {
            return DbContext.Files
                .Where(f => f.FolderId == folderId && f.OwnerId == ownerId)
                .OrderByDescending(f => f.LastModifiedAt)
                .ToList();
        }


    }
}
