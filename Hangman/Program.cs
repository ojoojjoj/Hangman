namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameMode = new AIGameMode();

            Initialize.InitializeGame(gameMode);

            Console.ReadKey();
        }

        IGameMode GetInterface(IGameMode OutputInput)
        {
            IGameMode OI = OutputInput;
            return OI;
        }
    }
}
