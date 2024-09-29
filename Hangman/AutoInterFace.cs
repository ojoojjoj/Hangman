using System.ComponentModel.Design;
using System.Diagnostics;

namespace Hangman
{
    public class AutoInterface : IInterface
    {
        public static List<string> PossibleWords = new List<string>();

        public string GetFilePath()
        {
            string filePath = "../../../words.txt";
            return filePath;
        }

        public List<string> SetPossibleWords()
        {
            foreach (string word in Initialize.AllRandomWords)
            {
                if (GameContent.DisplayRandomWord.Count == word.Length)
                {
                    PossibleWords.Add(word);
                }
                GameContent.NumberOfIterations++;
            }
            return PossibleWords;
        }

        public char GuessInput()
        {
            Thread.Sleep(2000);
            GameContent.NumberOfIterations = 0;
            char userGuess = ' ';

            if (GameContent.BeginningOfGame)
            {
                PossibleWords = SetPossibleWords();
            }
            (PossibleWords) = RemovedWords(PossibleWords);
            (PossibleWords) = GetPossibleWords(PossibleWords);

            if (PossibleWords.Count > 0)
            {
                userGuess = MostCommonChar(PossibleWords);
            }
            else
            {
                foreach (char c in GameContent.ValidGuesses)
                {
                    if (!GameContent.WrongGuesses.Contains(c) && !GameContent.DisplayRandomWord.Contains(c))
                    {
                        userGuess = c;
                        break;
                    }
                }
            }

            Debug.WriteLine("**********************");
            Debug.WriteLine($"Number of iterations: {GameContent.NumberOfIterations}");
            Debug.WriteLine($"Possible words left: {PossibleWords.Count}");
            Debug.WriteLine($"Number of guesses left: {10 - GameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI guesses: {GameContent.UserGuess}");
            return userGuess;
        }

        static List<string> RemovedWords(List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();
            bool falseChar = false;

            foreach (string word in possibleWords)
            {
                //Change this to a method instead!!
                falseChar = false;
                foreach (char charWord in word)
                {
                    foreach (char charGuesses in GameContent.WrongGuesses)
                    {
                        if (charWord == charGuesses)
                        {
                            falseChar = true;
                            removedWords.Add(word);
                            GameContent.NumberOfIterations++;
                            break;
                        }
                        GameContent.NumberOfIterations++;
                    }
                    if (falseChar)
                    {
                        break;
                    }
                }
            }
            foreach (string word in removedWords)
            {
                possibleWords.Remove(word);
            }

            return possibleWords;
        }

         List<string> GetPossibleWords(List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();

            for (int i = 0; i < GameContent.DisplayRandomWord.Count; i++)
            {
                char displayChar = GameContent.DisplayRandomWord[i];

                for (int j = 0; j < possibleWords.Count; j++)
                {
                    string word = possibleWords[j];

                    char wordChar = word[i];

                    if (displayChar != wordChar && displayChar != '_')
                    {
                        removedWords.Add(word);
                    }
                    GameContent.NumberOfIterations++;

                }
            }
            foreach (string word in removedWords)
            {
                possibleWords.Remove(word);
            }
            return possibleWords;
        }

        //This method is possible to be remove
        char GetExactChar(string word)
        {
            foreach (char c in word)
            {
                if (!GameContent.DisplayRandomWord.Contains(c))
                {
                    return c;
                }
            }
            PossibleWords.Remove(word);

            return word[0];
        }

        static char MostCommonChar(List<string> possibleWords)
        {
            int[] numberOfChar = new int[GameContent.ValidGuesses.Length];

            //Räknar antal bokstäver i possibleWords
            foreach (string word in possibleWords)
            {
                foreach (char c in word)
                {
                    int i2 = 0;
                    foreach (char c2 in GameContent.ValidGuesses)
                    {
                        if (c == c2)
                        {
                            numberOfChar[i2]++;
                            GameContent.NumberOfIterations++;
                            break;
                        }
                        i2++;
                        GameContent.NumberOfIterations++;
                    }
                }
            }

            bool goAgain = false;
            int index = 0;

            while (true)
            {
                goAgain = false;
                int highestNumber = 0;
                int i = 0;
                index = 0;

                //Hittar den bokstav som återfinns flest gånger i possibleWords
                foreach (int i2 in numberOfChar)
                {

                    if (i2 > highestNumber)
                    {
                        highestNumber = i2;
                        index = i;
                    }
                    i++;
                    GameContent.NumberOfIterations++;
                }

                //Kontrollerar om bokstaven redan dykt upp bland fel gissningar
                for (i = 0; i < GameContent.WrongGuesses.Length; i++)
                {
                    char c = GameContent.WrongGuesses[i];

                    if (GameContent.ValidGuesses[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        GameContent.NumberOfIterations++;
                        break;
                    }
                    GameContent.NumberOfIterations++;
                }

                if (goAgain)
                {
                    continue;
                }

                //Kontrollerar om bokstaven redan dykt upp bland rätt gissningar
                for (i = 0; i < GameContent.DisplayRandomWord.Count; i++)
                {
                    char c = GameContent.DisplayRandomWord[i];

                    if (GameContent.ValidGuesses[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        GameContent.NumberOfIterations++;
                        break;
                    }
                    GameContent.NumberOfIterations++;
                }

                if (goAgain)
                {
                    continue;
                }

                break;
            }


            return GameContent.ValidGuesses[index];
        }

        public void LoggAINumberOfWrongGuesses()
        {
            List<int> aiWrongGuesses = new List<int>();
            string filePath = "../../../AINumberOfWrongGuesses.txt";
            float ai = 0;

            //Change this to the same as SaveUserWord()
            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    if (int.TryParse(sr.ReadLine(), out int number))
                    {
                        aiWrongGuesses.Add(number);
                    }
                }
            }
            aiWrongGuesses.Add(GameContent.NumberOfWrongGuesses);

            using (var writer = new StreamWriter(filePath))
            {
                foreach (int i in aiWrongGuesses)
                    writer.WriteLine(i);
            }

            foreach (int i in aiWrongGuesses)
            {
                ai = (ai + i);
            }

            if (PossibleWords.Count < 1)
            {
                SaveUserWord();
            }

            else if (GameContent.GameOver)
            {
                for (int i = 0; i < 2; i++)
                {
                    SaveUserWord();
                }
            }

            Debug.WriteLine("********AI Stats******");
            Debug.WriteLine($"Number of wrong guesses: {GameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI average: {ai / aiWrongGuesses.Count}");
        }

        static void SaveUserWord()
        {
            string filePath = "../../../words.txt";

            File.AppendAllText(filePath, Environment.NewLine + GameContent.RandomWord);

            Debug.WriteLine("Saved the new word...");
        }

        public string SetRandomWord()
        {
            Console.Clear();
            Console.Write("Skriv ett ord: ");
            GameContent.RandomWord = Console.ReadLine()?.ToUpper() ?? string.Empty;

            foreach (char c in GameContent.RandomWord)
            {
                if (!Initialize.ValidChar.Contains(c))
                {
                    throw new ArgumentOutOfRangeException("Du får bara ange bokstäverna A-Ö");
                }
            }
            if (GameContent.RandomWord.Length < 1)
            {
                throw new ArgumentNullException("Du måste ange något ord");
            }
            return GameContent.RandomWord;
        }

        public void Run(IInterface OutputInput)
        {
            Game.Run(OutputInput);
        }
    }
}
