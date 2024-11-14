using System.ComponentModel.Design;

namespace Hangman
{
    public class UserGameMode : IGameMode
    {
        public string GetFilePath()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt");
            return filePath;
        }

        public char GuessInput(GameContent gameContent)
        {
            char.TryParse(Console.ReadLine(), out char userGuess);
            userGuess = char.ToUpper(userGuess);

            CheckIfGuessIsValid(userGuess, gameContent);
            CheckIfGuessIsDoubleGuess(userGuess, gameContent);

            return userGuess;
        }

        private static void CheckIfGuessIsValid(char userGuess, GameContent gameContent)
        {
            if (!gameContent.ValidGuesses.Contains(userGuess))
            {
                throw new ArgumentException("Du får enbart använda A-Ö");
            }
            
        }

        private static void CheckIfGuessIsDoubleGuess(char userGuess, GameContent gameContent)
        {
            if (gameContent.WrongGuesses.Contains(userGuess) || gameContent.DisplayRandomWord.Contains(userGuess))
            {
                throw new ArgumentException("Du har redan angett den här bokstaven");
            }
        }

        public string SetRandomWord(List<string> allRandomWords)
        {
            string randomWord = allRandomWords[Random.Shared.Next(allRandomWords.Count)].ToUpper();
            return randomWord;
        }
    }
}
