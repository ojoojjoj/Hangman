namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            Game.InitializeGame(game);
            Console.ReadKey();
        }
    }
}
