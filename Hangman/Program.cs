namespace Hangman
{
    public class Program
    {
        static void Main(string[] args)
        {
            var OutputInput = GetInterface(new AutoInterface());

            Initialize.InitializeGame(OutputInput);

            Console.ReadKey();
        }

        public static IInterface GetInterface(IInterface OutputInput)
        {
            IInterface OI = OutputInput;
            return OI;
        }
    }
}
