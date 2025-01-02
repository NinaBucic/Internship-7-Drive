using Drive.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Drive.Presentation.Actions.MainMenu
{
    public class MainMenuAction : BaseMenuAction
    {
        public MainMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "Main Menu";
        }

        public override void Open()
        {
            Console.WriteLine("Welcome to Drive!");
            base.Open();
        }
    }
}
