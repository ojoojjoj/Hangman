namespace Hangman
{
    public class Program
    {
        public static bool Loop = true;

        static void Main(string[] args)
        {
            Console.Title = "Hangman";

            do
            {
                Menu menu = new Menu(new StartMenu());
                menu.DisplayMenu(); 
            } while (Loop);
        }
    }
}