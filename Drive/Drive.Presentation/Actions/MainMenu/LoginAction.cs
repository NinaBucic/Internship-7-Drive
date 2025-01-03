using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Factories;
using Drive.Presentation.Helpers;

namespace Drive.Presentation.Actions.MainMenu
{
    public class LoginAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Login";

        public LoginAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Login Menu");

                Reader.ReadInput("Enter your email: ",out var email);

                if (!Reader.ValidateEmail(email))
                {
                    Writer.WriteError("Invalid email format. Please try again.");
                    continue;
                }

                var user = _userRepository.GetByEmail(email);
                if (user is null)
                {
                    Writer.WriteError("User not found. Returning to main menu.");
                    break;
                }

                Reader.ReadInput("Enter your password: ", out var password);

                if (!Reader.ValidateString(password))
                {
                    Writer.WriteError("Password cannot be empty.");
                    continue;
                }

                if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    Console.WriteLine("Invalid password. Returning to main menu in 30 seconds...");
                    Thread.Sleep(30000);
                    Console.Clear();
                    break;
                }

                Console.WriteLine("Login successful! Press any key to continue...");
                Console.ReadKey();

                var userMenu = UserMenuFactory.Create(user);
                userMenu.Open();
                break;
            }
        }
    }
}
