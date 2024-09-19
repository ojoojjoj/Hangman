using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class UserInterface : IUserInterface
    {
        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {
            char.TryParse(Console.ReadLine(), out gameContent.UserGuess);
            gameContent.UserGuess = char.ToUpper(gameContent.UserGuess);

            return gameContent;
        }

    }
}
