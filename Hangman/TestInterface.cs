using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class TestInterface : IInterface
    {
        public string GetFilePath()
        {
            string filePath = "../../../wordsTest.txt";
            return filePath;
        }

        public string SetRandomWord()
        {
            return "DEFAULT";
        }

        public char GuessInput()
        {
            return 'D';
        }

        public void Run(IInterface OutputInput)
        {
        }
    }
}
