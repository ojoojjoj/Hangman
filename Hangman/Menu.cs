using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class Menu
    {
        IMenuVariant MenuVariant { get; set; }

        bool Loop;

        public Menu(IMenuVariant menuVariant)
        {
            MenuVariant = menuVariant;
            Loop = true;
        }

        public void DisplayMenu()
        {
            while (Loop)
            {
                GetMenuOptions();
                GetMenuChoice(); 
            }
            MenuVariant.MenuChoice();
        }
       
        private void GetMenuOptions()
        {
            Console.Clear();
            for (int i = 0; i < MenuVariant.Options.Count; i++)
            {
                if (MenuVariant.Choice == i)
                {
                    Console.WriteLine($"> {MenuVariant.Options[i]}");
                }
                else
                {
                    Console.WriteLine($"  {MenuVariant.Options[i]}");
                }
            }
        }

        private void GetMenuChoice()
        {
            ConsoleKey key;
            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MenuVariant.Choice > 0)
                    {
                        MenuVariant.Choice--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MenuVariant.Choice < MenuVariant.Options.Count - 1)
                    {
                        MenuVariant.Choice++;
                    }
                    break;
                case ConsoleKey.Enter:
                    Loop = false;
                    break;
            }
        }
    }
}
