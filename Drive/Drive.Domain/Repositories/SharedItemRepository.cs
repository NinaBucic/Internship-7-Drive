using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Domain.Repositories
{
    public class SharedItemRepository : BaseRepository
    {
        public SharedItemRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(SharedItem sharedItem)
        {
            var existingShare = DbContext.SharedItems.FirstOrDefault(s =>
                s.OwnerId == sharedItem.OwnerId &&
                s.RecipientId == sharedItem.RecipientId &&
                s.FolderId == sharedItem.FolderId &&
                s.FileId == sharedItem.FileId);

            if (existingShare != null)
            {
                return ResponseResultType.NoChanges;
            }

            DbContext.SharedItems.Add(sharedItem);

            return SaveChanges();
        }

        public ResponseResultType Remove(SharedItem sharedItem)
        {
            DbContext.SharedItems.Remove(sharedItem);
            return SaveChanges();
        }

        public ResponseResultType RemoveFromRecipient(int recipientId, int? folderId, int? fileId)
        {
            var sharedItem = DbContext.SharedItems.FirstOrDefault(si =>
                si.RecipientId == recipientId &&
                si.FolderId == folderId &&
                si.FileId == fileId);

            if (sharedItem == null)
                return ResponseResultType.NotFound;

            DbContext.SharedItems.Remove(sharedItem);
            return SaveChanges();
        }

        public SharedItem? GetSharedItem(int ownerId, int recipientId, int? folderId, int? fileId)
        {
            return DbContext.SharedItems.FirstOrDefault(s =>
                s.OwnerId == ownerId &&
                s.RecipientId == recipientId &&
                s.FolderId == folderId &&
                s.FileId == fileId);
        }

        public ICollection<Folder> GetSharedFolders(int recipientId)
        {
            return DbContext.SharedItems
                .Where(si => si.RecipientId == recipientId && si.FolderId != null)
                .Select(si => si.Folder!)
                .ToList();
        }

        public ICollection<File> GetSharedFiles(int recipientId)
        {
            return DbContext.SharedItems
                .Where(si => si.RecipientId == recipientId && si.FileId != null)
                .Select(si => si.File!)
                .ToList();
        }


    }
}
