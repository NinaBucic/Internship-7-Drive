using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Repositories
{
    public class FolderRepository : BaseRepository
    {
        public FolderRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Folder folder)
        {
            if (GetByNameAndParent(folder.Name, folder.OwnerId, folder.ParentFolderId) != null)
                return ResponseResultType.AlreadyExists;

            DbContext.Folders.Add(folder);
            return SaveChanges();
        }


        public ICollection<Folder> GetRootFolders(int ownerId)
        {
            return DbContext.Folders
                .Where(f => f.OwnerId == ownerId && f.ParentFolderId == null)
                .OrderBy(f => f.Name)
                .ToList();
        }

        public ICollection<Folder> GetSubFolders(int parentFolderId, int ownerId)
        {
            return DbContext.Folders
                .Where(f => f.OwnerId == ownerId && f.ParentFolderId == parentFolderId)
                .OrderBy(f => f.Name)
                .ToList();
        }

        public Folder? GetByNameAndParent(string name, int ownerId, int? parentId)
        {
            return DbContext.Folders.FirstOrDefault(f =>
                f.Name.ToLower().Equals(name) &&
                f.OwnerId == ownerId &&
                f.ParentFolderId == parentId);
        }


    }
}
