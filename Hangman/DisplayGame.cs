using System.Text;

namespace Hangman
{
    public class DisplayGame
    {
        public static void DisplayView(GameContent gameContent)
        {
            Console.Clear();
            Console.WriteLine("+----- HANGMAN -----+\n");
            DisplayGuesses(gameContent);
            HangMan(gameContent);
            DisplayWord(gameContent);
            Console.Write("\nGissa en bokstav:");
        }
        public static void DisplayWord(GameContent gameContent)
        {
            Console.Write("\nGissa ordet: ");
            Console.Write(gameContent.DisplayRandomWord);
            Console.WriteLine();
        }
        public static void DisplayGuesses(GameContent gameContent)
        {
            Console.Write("Gissade bokstäver: ");
            foreach (char c in gameContent.Guesses)
            {
                Console.Write(c);
            }
        }

        public static void WinScreen(GameContent gameContent)
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < 20; i++)
            {
                Console.Clear();
                Console.WriteLine("+----- HANGMAN -----+\n");
                Console.WriteLine("Grattis du har vunnit!");
                HangManWinnerLoop(stringBuilder);
                Console.WriteLine($"\nRätt svar: {gameContent.RandomWord}");
                Thread.Sleep(250);
            }
        }

        public static void GameOverScreen(GameContent gameContent)
        {
            for (int i = 0;i < 10;i++)
            {
                Console.Clear();
                Console.WriteLine("+----- HANGMAN -----+\n");
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("GAME OVER!");
                Console.ResetColor();
                HangMan10();
                Console.WriteLine($"\nRätta svaret: {gameContent.RandomWord}");
                Thread.Sleep(250);
            }
        }

        public static void HangMan(GameContent gameContent)
        {
            switch (gameContent.NumberOfWrongGuesses)
            {
                case 0: HangMan0(); break;
                case 1: HangMan1(); break;
                case 2: HangMan2(); break;
                case 3: HangMan3(); break;
                case 4: HangMan4(); break;
                case 5: HangMan5(); break;
                case 6: HangMan6(); break;
                case 7: HangMan7(); break;
                case 8: HangMan8(); break;
                case 9: HangMan9(); break;
                case 10: HangMan10(); break;
            }
        }

        public static void HangMan0()
        {
            Console.WriteLine("\n\n\n\n\n\n");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan1()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan2()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan3()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan4()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan5()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan6()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |   |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan7()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |   |\\");
            Console.WriteLine("  |");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan8()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |   |\\");
            Console.WriteLine("  |    \\");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan9()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |  /|\\");
            Console.WriteLine("  |    \\");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangMan10()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |   O");
            Console.WriteLine("  |  /|\\");
            Console.WriteLine("  |  / \\");
            Console.WriteLine(" ____");
            Console.WriteLine("|    |");
            Console.WriteLine("|    |");
        }

        public static void HangManWinner()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine(" ____   \\O/");
            Console.WriteLine("|    |   |");
            Console.WriteLine("|    |  / \\");
        }
        public static void HangManWinnerLoop(StringBuilder stringBuilder)
        {
            Console.WriteLine("\n");
            Console.WriteLine("  _____");
            Console.WriteLine("  |/  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");
            Console.WriteLine("  |");

            string row1 = " ____";
            string row2 = "|    |";
            stringBuilder.Append(' ');

            string spaces = "";
            spaces.Append(' ');

            Console.WriteLine($"{row1}{spaces}   \\O/");
            Console.WriteLine($"{row2}{spaces}   |");
            Console.WriteLine($"{row2}{spaces}  / \\");
        }
    }
}
