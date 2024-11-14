using System.Diagnostics;

namespace Hangman
{
    public class Initialize
    {
        IGameMode GameMode;

        public Initialize(IGameMode gameMode)
        {
            GameMode = gameMode;
        }

        /// <summary>
        /// Initialize the game and runs it
        /// </summary>
        /// <param name="gameMode"></param>
        public void Game()
        {
            var gameContent = new GameContent(GameMode);

            Game game = new Game(GameMode);
            game.Run();
        }
    }
}
