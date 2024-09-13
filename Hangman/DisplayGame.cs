using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Clear();
            Console.WriteLine("+----- HANGMAN -----+\n");
            Console.WriteLine("Grattis du har vunnit!");
            HangManWinner();
            Console.WriteLine($"\nRätt svar: {gameContent.RandomWord}");
        }

        public static void GameOverScreen(GameContent gameContent)
        {
            Console.Clear();
            Console.WriteLine("+----- HANGMAN -----+\n");
            Console.WriteLine("GAME OVER!");
            HangMan10();
            Console.WriteLine($"\nRätta svaret: {gameContent.RandomWord}");
        }

        public static void HangMan(GameContent gameContent)
        {
            switch(gameContent.NumberOfWrongGuesses)
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
    }
}
