using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.CommentsMenu
{
    public class DeleteCommentAction : IAction
    {
        private readonly CommentRepository _commentRepository;
        private readonly int _commentId;
        private readonly User _currentUser;
        private readonly File _file;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Delete Comment";

        public DeleteCommentAction(CommentRepository commentRepository, int commentId, User currentUser, File file)
        {
            _commentRepository = commentRepository;
            _commentId = commentId;
            _currentUser = currentUser;
            _file = file;
        }

        public void Open()
        {
            var comment = _commentRepository.GetById(_commentId);

            if (comment == null)
            {
                Writer.WriteError("Comment does not exist.");
                return;
            }

            if (comment.FileId != _file.Id)
            {
                Writer.WriteError("The selected comment does not belong to this file.");
                return;
            }

            if (comment.AuthorId != _currentUser.Id || comment.File.OwnerId != _currentUser.Id)
            {
                Writer.WriteError("You are not authorized to delete this comment.");
                return;
            }

            var result = _commentRepository.Delete(comment);
            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Comment deleted successfully.");
                return;
            }
            
            Writer.WriteError("Failed to delete comment.");
        }
    }

}
