using Drive.Data.Entities;
using Drive.Domain.Enums;
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

        public ResponseResultType Add(File file)
        {
            var existingFile = DbContext.Files.FirstOrDefault(f =>
                f.Name.ToLower().Equals(file.Name) &&
                f.OwnerId == file.OwnerId &&
                f.FolderId == file.FolderId);

            if (existingFile != null)
            {
                return ResponseResultType.AlreadyExists;
            }

            DbContext.Files.Add(file);

            return SaveChanges();
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
