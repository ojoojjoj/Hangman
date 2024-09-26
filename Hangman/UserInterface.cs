namespace Hangman
{
    public class UserInterface : IUserInterface
    {
        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {
            char.TryParse(Console.ReadLine(), out gameContent.UserGuess);
            gameContent.UserGuess = char.ToUpper(gameContent.UserGuess);
            
            gameContent = CheckValidChar(gameContent);
            gameContent = CheckDoubleGuess(gameContent);

            return gameContent;
        }

        private static GameContent CheckValidChar(GameContent gameContent)
        {
            if (!gameContent.ValidChar.Contains(gameContent.UserGuess))
            {
                throw new ArgumentException("Du får enbart använda A-Ö");
            }
            else { return gameContent; }
        }

        private static GameContent CheckDoubleGuess(GameContent gameContent)
        {
            if (gameContent.Guesses.Contains(gameContent.UserGuess) || gameContent.DisplayRandomWord.Contains(gameContent.UserGuess)) {
                throw new ArgumentException("Du har redan angett den här bokstaven");
            }
            else { return gameContent; }
        }
    }
}
