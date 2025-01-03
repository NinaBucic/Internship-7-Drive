using Drive.Data.Entities;
using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Domain.Repositories
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DriveDbContext dbContext) : base(dbContext)
        {
        }

        public Comment? GetById(int commentId)
        {
            return DbContext.Comments
                .Include(c => c.Author)
                .Include(c => c.File)
                .ThenInclude(f => f.Owner) 
                .FirstOrDefault(c => c.Id == commentId);
        }

        public ResponseResultType Add(Comment comment)
        {
            DbContext.Comments.Add(comment);
            return SaveChanges();
        }

        public ResponseResultType Update(Comment comment)
        {
            var existingComment = GetById(comment.Id);
            if (existingComment == null)
                return ResponseResultType.NotFound;

            existingComment.Content = comment.Content;
            existingComment.LastModified = comment.LastModified;

            return SaveChanges();
        }

        public ResponseResultType Delete(Comment comment)
        {
            DbContext.Comments.Remove(comment);
            return SaveChanges();
        }

        public ICollection<Comment> GetCommentsByFileId(int fileId)
        {
            return DbContext.Comments
                .Where(c => c.FileId == fileId)
                .Include(c => c.Author)
                .OrderByDescending(c => c.LastModified ?? c.CreatedAt)
                .ToList();
        }
    }
}
