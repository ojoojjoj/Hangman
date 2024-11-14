using System.ComponentModel.Design;

namespace Hangman
{
    public class UserGameMode : IGameMode
    {
        public string GetFilePath()
        {
            string filePath = "../../../words.txt";
            return filePath;
        }

        public char GuessInput()
        {
            char.TryParse(Console.ReadLine(), out GameContent.UserGuess);
            char userGuess = char.ToUpper(GameContent.UserGuess);

            CheckIfGuessIsValid();
            CheckIfGuessIsDoubleGuess();

            return userGuess;
        }

        private static void CheckIfGuessIsValid()
        {
            if (!GameContent.ValidGuesses.Contains(GameContent.UserGuess))
            {
                throw new ArgumentException("Du får enbart använda A-Ö");
            }
            
        }

        private static void CheckIfGuessIsDoubleGuess()
        {
            if (GameContent.WrongGuesses.Contains(GameContent.UserGuess) || GameContent.DisplayRandomWord.Contains(GameContent.UserGuess))
            {
                throw new ArgumentException("Du har redan angett den här bokstaven");
            }
        }

        public string SetRandomWord()
        {
            Random random = new();
            GameContent.RandomWord = Initialize.AllRandomWords[random.Next(Initialize.AllRandomWords.Count)].ToUpper();
            return GameContent.RandomWord;
        }

        public void Run(IGameMode OutputInput)
        {
            Game.Run(OutputInput);
        }
    }
}
