using System.Diagnostics;

namespace Hangman
{
    public class GameContent
    {
        public string RandomWord { get; }

        public List<char> DisplayRandomWord { get; set; }

        public char[] WrongGuesses = new char[11];

        public char UserGuess { get; set; }

        public int NumberOfWrongGuesses { get; set; }

        public bool GameOver = false;

        public bool Win = false;

        public string ValidGuesses = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ-";

        public bool BeginningOfGame = true;

        public List<string> AllRandomWords { get; }

        public GameContent(IGameMode gameMode)
        {
            AllRandomWords = GetAllRandomWordsFromFile();
            RandomWord = GetRandomWord(gameMode);
            DisplayRandomWord = GetDisplayRandomWord();
        }

        private List<string> GetAllRandomWordsFromFile()
        {
            List<string> allRandomWords = new List<string>();

            string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt");
            using var sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                allRandomWords.Add(sr.ReadLine()?.ToUpper() ?? string.Empty);
            }
            return allRandomWords;
        }

        private string GetRandomWord(IGameMode gameMode)
        {
            bool randomWordValid = false;

            string randomWord = "";

            while (!randomWordValid)
            {
                try
                {
                    randomWord = gameMode.SetRandomWord(AllRandomWords);
                    randomWordValid = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Console.Clear();
                    Console.WriteLine("Du får bara ange bokstäverna A-Ö\n>Fortsätt...");
                    Console.ReadKey();
                }
                catch (ArgumentNullException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Console.Clear();
                    Console.WriteLine("Du måste ange något ord\n>Fortsätt...");
                    Console.ReadKey();
                }
            }
            return randomWord;
        }

        private List<char> GetDisplayRandomWord()
        {
            List<char> displayRandomWord = new List<char>();

            for (int i = 0; i < RandomWord.Length; i++)
            {
                displayRandomWord.Add('_');
            }
            return displayRandomWord;
        }
    }
}
