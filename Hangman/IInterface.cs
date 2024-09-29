using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public interface IInterface
    {
        public string GetFilePath();

        public string SetRandomWord();

        public char GuessInput();

        public void Run(IInterface OutputInput);

        public void LoggAINumberOfWrongGuesses()
        {

        }

    }
}
