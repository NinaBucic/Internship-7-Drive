using Drive.Data.Entities.Models;
using Drive.Domain.Enums;
using Drive.Domain.Repositories;
using Drive.Presentation.Abstractions;
using Drive.Presentation.Factories;
using Drive.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.MainMenu
{
    public class RegisterAction : IAction
    {
        private readonly UserRepository _userRepository;

        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Register";

        public RegisterAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Register Menu");

                Reader.ReadInput("Enter your email: ", out var email);

                if (!Reader.ValidateEmail(email))
                {
                    Writer.WriteError("Invalid email format. Please try again.");
                    continue;
                }

                if (_userRepository.GetByEmail(email) is not null)
                {
                    Writer.WriteError("Email already exists!");
                    break;
                }

                Reader.ReadInput("Enter your password: ", out var password);
                Reader.ReadInput("Confirm your password: ", out var confirmPassword);

                if (!Reader.ValidateString(password) || password != confirmPassword)
                {
                    Writer.WriteError("Passwords do not match or are empty. Please try again.");
                    break;
                }

                var captcha = Reader.GenerateCaptcha();
                Console.WriteLine($"CAPTCHA: {captcha}");
                Reader.ReadInput("Enter the CAPTCHA: ", out var captchaInput);

                if (captcha != captchaInput)
                {
                    Writer.WriteError("CAPTCHA does not match. Please try again.");
                    break;
                }

                var user = new User(email, BCrypt.Net.BCrypt.HashPassword(password));
                var result = _userRepository.Add(user);

                if (result == ResponseResultType.NoChanges)
                {
                    Writer.WriteError("Failed to register user. Please try again.");
                    break;
                }

                Console.WriteLine("Registration successful! Press any key to continue...");
                Console.ReadKey();

                var userMenu = UserMenuFactory.Create();
                userMenu.Open();
                break;
            }
        }
    }
}
