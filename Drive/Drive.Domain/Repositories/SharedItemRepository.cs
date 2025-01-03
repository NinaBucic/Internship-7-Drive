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

        public SharedItem? GetSharedItem(int ownerId, int recipientId, int? folderId, int? fileId)
        {
            return DbContext.SharedItems.FirstOrDefault(s =>
                s.OwnerId == ownerId &&
                s.RecipientId == recipientId &&
                s.FolderId == folderId &&
                s.FileId == fileId);
        }

    }
}
