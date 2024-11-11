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

        public string SetRandomWord();

        public char GuessInput();

        public void Run(IGameMode OutputInput);

        public void LoggAINumberOfWrongGuesses()
        {

        }

    }
}
