using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.ProfileMenu
{
    public class ChangePasswordAction : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly User _currentUser;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Change Password";

        public ChangePasswordAction(UserRepository userRepository, User currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("Change Password");

            Reader.ReadInput("Enter current password: ", out var currentPassword);

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, _currentUser.Password))
            {
                Writer.WriteError("Current password is incorrect.");
                return;
            }

            Reader.ReadInput("Enter new password: ", out var newPassword);
            Reader.ReadInput("Confirm new password: ", out var confirmPassword);

            if (newPassword != confirmPassword)
            {
                Writer.WriteError("Passwords do not match.");
                return;
            }

            _currentUser.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

            if (!Reader.Confirm("Are you sure you want to update your password?"))
            {
                Writer.WriteError("Action cancelled.");
                return;
            }

            var result = _userRepository.Update(_currentUser);

            if (result == ResponseResultType.Success)
            {
                Console.WriteLine("Password updated successfully!");
                return;
            }
            
            Writer.WriteError("Failed to update password. Try again.");
        }
    }
}
