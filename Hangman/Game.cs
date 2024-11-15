namespace Hangman
{
    public class Game
    {
        private IGameMode _gameMode;
        private GameContent _gameContent;

        private bool _isGameRunning = true;

        public Game(IGameMode gameMode)
        {
            _gameMode = gameMode;
            _gameContent = new GameContent(_gameMode);
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        /// <param name="GameMode"></param>
        public void Run()
        {
            do
            {
                PrintGame.PrintGameView("", _gameContent);

                GetUserGuess();

                CorrectOrWrongGuess();

                CheckingWinOrLose();

                _gameContent.BeginningOfGame = false;

            } while (_isGameRunning);

            if (_gameMode is AIGameMode)
            {
                _gameMode.LoggAINumberOfWrongGuesses(_gameContent);
            }

            WinOrLoseScreen();
        }

        /// <summary>
        /// Gets users/AI guess and checks if it's valid
        /// </summary>
        /// <param name="GameMode"></param>
        private void GetUserGuess()
        {
            bool validGuess = false;

            while (!validGuess)
            {
                try
                {
                    _gameContent.UserGuess = _gameMode.GuessInput(_gameContent);
                    validGuess = true;
                }
                catch (ArgumentException ex)
                {
                    PrintGame.PrintGameView(ex.Message, _gameContent);
                }
            }
        }

        /// <summary>
        /// Checks if the guess is correct or wrong
        /// </summary>
        private void CorrectOrWrongGuess()
        {

            if (!CheckingCorrectAnswer())
            {
                _gameContent.WrongGuesses[_gameContent.NumberOfWrongGuesses] = _gameContent.UserGuess;
                _gameContent.NumberOfWrongGuesses++;
            }
        }

        private bool CheckingCorrectAnswer()
        {
            bool correctAnswer = false;

            for (int i = 0; i < _gameContent.RandomWord.Length; i++)
            {
                if (_gameContent.RandomWord[i] == _gameContent.UserGuess)
                {
                    _gameContent.DisplayRandomWord[i] = _gameContent.UserGuess;

                    correctAnswer = true;
                }
            }
            return correctAnswer;
        }

        /// <summary>
        /// Checks if the user/AI have won or have game over
        /// </summary>
        private void CheckingWinOrLose()
        {
            CheckIfWin();

            if (!_gameContent.Win)
            {
                CheckIfGameOver();
            }
        }

        private void CheckIfGameOver()
        {
            if (_gameContent.NumberOfWrongGuesses >= 10)
            {
                _gameContent.GameOver = true;
                _isGameRunning = false;
            }
        }

        private void CheckIfWin()
        {
            _gameContent.Win = true;
            _isGameRunning = false;

            for (int i = 0; i < (_gameContent.DisplayRandomWord.Count); i++)
            {
                if (_gameContent.RandomWord[i] != _gameContent.DisplayRandomWord[i])
                {
                    _gameContent.Win = false;
                    _isGameRunning = true;
                    break;
                }
            }
        }

        private void WinOrLoseScreen()
        {
            if (_gameContent.GameOver)
            {
                PrintGame.GameOverScreen(_gameContent);
            }
            else if (_gameContent.Win)
            {
                PrintGame.WinScreen(_gameContent);
            }
        }
    }
}
