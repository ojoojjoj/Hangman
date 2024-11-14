using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class GameModeMenu : IMenuVariant
    {
        public List<string> Options { get { return new List<string> { "Normal Gamemode", "AI GameMode" }; } }

        public int Choice { get; set; }

        public GameModeMenu()
        {
            Choice = 0;
        }

        public void MenuChoice()
        {
            switch (Choice)
            {
                case 0:
                    var userGameMode = new UserGameMode();
                    var userGame = new Game(userGameMode);
                    userGame.Run();
                    break;
                case 1:
                    var AIGameMode = new AIGameMode();
                    var AIGame = new Game(AIGameMode);
                    AIGame.Run();
                    break;
            }
        }
    }
}
