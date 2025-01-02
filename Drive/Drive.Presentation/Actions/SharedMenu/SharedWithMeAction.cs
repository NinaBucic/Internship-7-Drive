using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.SharedMenu
{
    public class SharedWithMeAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Shared With Me";

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("You are in Shared With Me menu. [Functionality pending]");
            Console.ReadKey();
        }
    }
}
