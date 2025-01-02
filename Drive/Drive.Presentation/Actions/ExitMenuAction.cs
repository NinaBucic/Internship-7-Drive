using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "Exit";

        public ExitMenuAction()
        {
        }

        public void Open()
        {
            Console.WriteLine("Exiting...");
        }
    }
}
