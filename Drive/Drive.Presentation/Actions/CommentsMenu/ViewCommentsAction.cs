using Drive.Data.Entities.Models;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Presentation.Actions.CommentsMenu
{
    public class ViewCommentsAction : IAction
    {
        private readonly CommentRepository _commentRepository;
        private readonly File _file;
        private readonly User _currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "View Comments";

        public ViewCommentsAction(CommentRepository commentRepository, File file, User currentUser)
        {
            _commentRepository = commentRepository;
            _file = file;
            _currentUser = currentUser;
        }

        public void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Comments for File: {_file.Name}\n");

                var comments = _commentRepository.GetCommentsByFileId(_file.Id);

                Writer.DisplayComments(comments);

                Console.WriteLine("\nEnter a command (type 'help' for a list of commands):");
                var command = Console.ReadLine()?.ToLower();

                if (string.IsNullOrWhiteSpace(command)) continue;

                if (command == "help")
                {
                    HelpMenu.DisplayCommentCommands();
                    Console.ReadKey();
                    continue;
                }

                if (command == "back") break;

                if (command == "add comment")
                {
                    var addAction = new AddCommentAction(_commentRepository, _file, _currentUser);
                    addAction.Open();
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "edit comment ", out var commentIdStr) && int.TryParse(commentIdStr, out var commentId))
                {
                    var editAction = new EditCommentAction(_commentRepository, commentId, _currentUser,_file);
                    editAction.Open();
                    continue;
                }

                if (CommandParser.TryParseCommand(command, "delete comment ", out var deleteCommentIdStr) && int.TryParse(deleteCommentIdStr, out var deleteCommentId))
                {
                    var deleteAction = new DeleteCommentAction(_commentRepository, deleteCommentId, _currentUser,_file);
                    deleteAction.Open();
                    continue;
                }

                Writer.WriteError("Invalid command. Type 'help' for a list of commands.");
            }
        }
    }
}
