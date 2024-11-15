using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public interface IGameMode
    {
        public string GetFilePath();

        public string SetRandomWord(List<string> allRandomWords);

        public char GuessInput(GameContent gameContent);

        public void LoggAINumberOfWrongGuesses(GameContent gameContent)
        {

        }

    }
}
