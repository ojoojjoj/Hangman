using System.Diagnostics;

namespace Hangman
{
    public static class Initialize
    {
        public static List<string> AllRandomWords = new List<string>();
        public static string ValidChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ-";
        
        /// <summary>
        /// Initialize the game and runs it
        /// </summary>
        /// <param name="OutputInput"></param>
        public static void InitializeGame(IInterface OutputInput)
        {
            GetAllRandomWordsFromFile(OutputInput);

            GetRandomWord(OutputInput);

            SetDisplayWord();

            OutputInput.Run(OutputInput);
        }

        /// <summary>
        /// Get full list of all random words from words.txt
        /// </summary>
        /// <param name="randomWords"></param>
        /// <returns></returns>
        private static void GetAllRandomWordsFromFile(IInterface OutputInput)
        {
            string filePath = OutputInput.GetFilePath();

            using var sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                AllRandomWords.Add(sr.ReadLine()?.ToUpper() ?? string.Empty);
            }
        }

        /// <summary>
        /// Gets/Sets a random word and checks if its valid
        /// </summary>
        /// <param name="randomWords"></param>
        /// <param name="OutputInput"></param>
        private static void GetRandomWord(IInterface OutputInput)
        {
            bool randomWordValid = false;

            while (!randomWordValid)
            {
                try
                {
                    GameContent.RandomWord = OutputInput.SetRandomWord();
                    randomWordValid = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Console.WriteLine("Du får bara ange bokstäverna A-Ö");
                    Thread.Sleep(1500);
                }
                catch (ArgumentNullException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Console.WriteLine("Du måste ange något ord");
                    Thread.Sleep(1500);
                }
            }
        }
        
        /// <summary>
        /// Set the word that is displayed for the user/AI
        /// </summary>
        private static void SetDisplayWord()
        {
            GameContent.DisplayRandomWord.Clear();

            for (int i = 0; i < GameContent.RandomWord.Length; i++)
            {
                GameContent.DisplayRandomWord.Add('_');
            }
        }
    }
}
