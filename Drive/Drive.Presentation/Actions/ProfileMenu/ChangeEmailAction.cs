using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.ProfileMenu
{
    public class ChangeEmailAction : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly User _currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Change Email";

        public ChangeEmailAction(UserRepository userRepository, User currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("Change Email");

            Reader.ReadInput("Enter new email: ", out var newEmail);

            if (!Reader.ValidateEmail(newEmail))
            {
                Writer.WriteError("Invalid email format.");
                return;
            }

            if (_userRepository.GetByEmail(newEmail) != null)
            {
                Writer.WriteError("Email already exists. Try another one.");
                return;
            }

            if (!Reader.Confirm($"Are you sure you want to change your email to '{newEmail}'?"))
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            _currentUser.Email = newEmail;
            var result = _userRepository.Update(_currentUser);

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Email updated successfully!");
                return;
            }
            
            Writer.WriteError("Failed to update email. Try again.");
        }
    }
}
