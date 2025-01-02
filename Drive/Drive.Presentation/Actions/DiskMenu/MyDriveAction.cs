using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions.DiskMenu
{
    public class MyDriveAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "My Drive";

        public void Open()
        {
            Console.Clear();
            Console.WriteLine("You are in My Drive menu. [Functionality pending]");
            Console.ReadKey();
        }
    }
}
