using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.ProfileMenu
{
    public class ProfileSettingsAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Profile Settings";

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("You are in Profile Settings menu. [Functionality pending]");
            Console.ReadKey();
        }
    }
}
