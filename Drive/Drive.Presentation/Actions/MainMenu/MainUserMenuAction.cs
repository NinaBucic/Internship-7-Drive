using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drive.Presentation.Actions.MainMenu
{
    public class MainUserMenuAction : BaseMenuAction
    {
        public MainUserMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "User Main Menu";
        }

        public override void Open()
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Drive!");
            base.Open();
        }
    }
}
