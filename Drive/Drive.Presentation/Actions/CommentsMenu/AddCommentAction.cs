using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.CommentsMenu
{
    public class AddCommentAction : IAction
    {
        private readonly CommentRepository _commentRepository;
        private readonly File _file;
        private readonly User _currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Add Comment";

        public AddCommentAction(CommentRepository commentRepository, File file, User currentUser)
        {
            _commentRepository = commentRepository;
            _file = file;
            _currentUser = currentUser;
        }

        public void Open()
        {
            Console.Clear();
            Console.WriteLine($"Adding a comment to file: {_file.Name}");
            Console.WriteLine("Enter your comment (or type 'back' to cancel):");

            var content = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(content))
            {
                Writer.WriteError("Comment cannot be empty.");
                return;
            }

            if (content.ToLower() == "back")
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            var newComment = new Comment
            {
                FileId = _file.Id,
                AuthorId = _currentUser.Id,
                Content = content,
                CreatedAt = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };

            var result = _commentRepository.Add(newComment);
            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Comment added successfully.");
                return;
            }

            Writer.WriteError("Failed to add comment.");
        }
    }
}

