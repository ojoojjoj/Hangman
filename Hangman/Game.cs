namespace Hangman
{
    public static class Game
    {
        /// <summary>
        /// Runs the game
        /// </summary>
        /// <param name="OutputInput"></param>
        public static void Run(IInterface OutputInput)
        {
            do
            {
                //PrintGame class should split up to Console and Debug for better testing
                if (OutputInput is not TestInterface)
                {
                    PrintGame.PrintGameView("");
                }

                GetUserGuess(OutputInput);

                CorrectOrWrongGuess();

                CheckingWinOrLose();

                GameContent.BeginningOfGame = false;

            } while (GameContent.GameRunning && OutputInput is not TestInterface);

            if (OutputInput is AutoInterface)
            {
                OutputInput.LoggAINumberOfWrongGuesses();
            }

            if (OutputInput is not TestInterface)
            {
                WinOrLoseScreen(); 
            }
        }

        /// <summary>
        /// Gets users/AI guess and checks if it's valid
        /// </summary>
        /// <param name="OutputInput"></param>
        private static void GetUserGuess(IInterface OutputInput)
        {
            bool validGuess = false;

            while (!validGuess)
            {
                try
                {
                    GameContent.UserGuess = OutputInput.GuessInput();
                    validGuess = true;
                }
                catch (ArgumentException ex)
                {
                    PrintGame.PrintGameView(ex.Message);
                }
            }
        }

        /// <summary>
        /// Checks if the guess is correct or wrong
        /// </summary>
        private static void CorrectOrWrongGuess()
        {

            if (!CheckingCorrectAnswer())
            {
                GameContent.WrongGuesses[GameContent.NumberOfWrongGuesses] = GameContent.UserGuess;
                GameContent.NumberOfWrongGuesses++;
            }
        }

        private static bool CheckingCorrectAnswer()
        {
            for (int i = 0; i < GameContent.RandomWord.Length; i++)
            {
                if (GameContent.RandomWord[i] == GameContent.UserGuess)
                {
                    GameContent.DisplayRandomWord[i] = GameContent.UserGuess;

                    if (i == GameContent.RandomWord.Length - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the user/AI have won or have game over
        /// </summary>
        private static void CheckingWinOrLose()
        {
            CheckIfWin();

            if (!GameContent.Win)
            {
                CheckIfGameOver();
            }
        }

        private static void CheckIfGameOver()
        {
            if (GameContent.NumberOfWrongGuesses >= 10)
            {
                GameContent.GameOver = true;
                GameContent.GameRunning = false;
            }
        }

        private static void CheckIfWin()
        {
            GameContent.Win = true;
            GameContent.GameRunning = false;

            for (int i = 0; i < (GameContent.DisplayRandomWord.Count); i++)
            {
                if (GameContent.RandomWord[i] != GameContent.DisplayRandomWord[i])
                {
                    GameContent.Win = false;
                    GameContent.GameRunning = true;
                    break;
                }
            }
        }

        private static void WinOrLoseScreen()
        {
            if (GameContent.GameOver)
            {
                PrintGame.GameOverScreen();
            }
            else if (GameContent.Win)
            {
                PrintGame.WinScreen();
            }
        }
    }
}
