using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class GameContent
    {
        public string RandomWord { get; set; }
        public char[] DisplayRandomWord { get; set; }
        public char[] Guesses = new char[11];
        public bool GameLoop = true;
        public char UserGuess;
        public int NumberOfWrongGuesses;
        public bool IfWrongAnswer;
        public bool GameOver = false;
        public bool Winner = false;
        public string ValidChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ-";
        public int NumberOfIterations;
        public bool BeginningOfGame = true;

        public GameContent(string randomWord, char[] displayRandomWord)
        {
            RandomWord = randomWord;
            DisplayRandomWord = displayRandomWord;
        }
    }
}
