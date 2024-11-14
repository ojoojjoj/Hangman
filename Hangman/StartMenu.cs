using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class StartMenu : IMenuVariant
    {
        public List<string> Options { get { return new List<string> { "Nytt Spel", "Avsluta" }; } }

        public int Choice { get; set; }

        public StartMenu()
        {
            Choice = 0;
        }

        public void MenuChoice()
        {
            switch (Choice)
            {
                case 0:
                    Menu menu = new Menu(new GameModeMenu());
                    menu.DisplayMenu();
                    break;
                case 1:
                    Program.Loop = false;
                    break;
            }
        }
    }
}
