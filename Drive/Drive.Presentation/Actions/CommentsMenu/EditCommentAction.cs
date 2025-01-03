using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.CommentsMenu
{
    public class EditCommentAction : IAction
    {
        private readonly CommentRepository _commentRepository;
        private readonly int _commentId;
        private readonly User _currentUser;
        private readonly File _file;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Edit Comment";

        public EditCommentAction(CommentRepository commentRepository, int commentId, User currentUser, File file)
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

            if (comment.AuthorId != _currentUser.Id)
            {
                Writer.WriteError("You are not authorized to edit this comment.");
                return;
            }

            Console.WriteLine("Enter new content for the comment (or type 'back' to cancel):");
            var newContent = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newContent) || newContent.ToLower() == "back")
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            comment.Content = newContent;
            comment.LastModified = DateTime.UtcNow;

            var result = _commentRepository.Update(comment);
            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Comment updated successfully.");
                return;
            }

            Writer.WriteError("Failed to update comment.");
        }
    }

}
