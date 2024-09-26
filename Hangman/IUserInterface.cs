using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public interface IUserInterface
    {
        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {

            return gameContent;
        }

        public void LoggAINumberOfWrongGuesses(GameContent gameContent);

    }
}
