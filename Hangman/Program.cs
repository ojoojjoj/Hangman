namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(false);
            IUserInterface ui = game.InterFace ? new UserInterface() : new AutoInterFace();
            Game.InitializeGame(game, ui);
        }
    }
}
