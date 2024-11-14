using System.Diagnostics;

namespace Hangman
{
    public class AIGameMode : IGameMode
    {
        public List<string> PossibleWords = new List<string>();

        public string GetFilePath()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt");
            return filePath;
        }

        public void SetPossibleWords(GameContent gameContent)
        {
            foreach (string word in gameContent.AllRandomWords)
            {
                if (gameContent.DisplayRandomWord.Count == word.Length)
                {
                    PossibleWords.Add(word);
                }
            }
        }

        public char GuessInput(GameContent gameContent)
        {
            Thread.Sleep(2000);
            char userGuess = ' ';

            if (gameContent.BeginningOfGame)
            {
                SetPossibleWords(gameContent);
            }
            RemovedWords(gameContent);
            GetPossibleWords(gameContent);

            if (PossibleWords.Count > 0)
            {
                userGuess = MostCommonChar(gameContent);
            }
            else
            {
                foreach (char c in gameContent.ValidGuesses)
                {
                    if (!gameContent.WrongGuesses.Contains(c) && !gameContent.DisplayRandomWord.Contains(c))
                    {
                        userGuess = c;
                        break;
                    }
                }
            }
            return userGuess;
        }

        private void RemovedWords(GameContent gameContent)
        {
            List<string> removedWords = new List<string>();
            bool falseChar = false;

            foreach (string word in PossibleWords)
            {
                //Change this to a method instead!!
                falseChar = false;
                foreach (char charWord in word)
                {
                    foreach (char charGuesses in gameContent.WrongGuesses)
                    {
                        if (charWord == charGuesses)
                        {
                            falseChar = true;
                            removedWords.Add(word);
                            break;
                        }
                    }
                    if (falseChar)
                    {
                        break;
                    }
                }
            }
            foreach (string word in removedWords)
            {
                PossibleWords.Remove(word);
            }
        }

        private void GetPossibleWords(GameContent gameContent)
        {
            List<string> removedWords = new List<string>();

            for (int i = 0; i < gameContent.DisplayRandomWord.Count; i++)
            {
                char displayChar = gameContent.DisplayRandomWord[i];

                for (int j = 0; j < PossibleWords.Count; j++)
                {
                    string word = PossibleWords[j];

                    char wordChar = word[i];

                    if (displayChar != wordChar && displayChar != '_')
                    {
                        removedWords.Add(word);
                    }
                }
            }
            foreach (string word in removedWords)
            {
                PossibleWords.Remove(word);
            }
        }

        private char MostCommonChar(GameContent gameContent)
        {
            int[] numberOfChar = new int[gameContent.ValidGuesses.Length];

            //Räknar antal bokstäver i possibleWords
            foreach (string word in PossibleWords)
            {
                foreach (char c in word)
                {
                    int i2 = 0;
                    foreach (char c2 in gameContent.ValidGuesses)
                    {
                        if (c == c2)
                        {
                            numberOfChar[i2]++;
                            break;
                        }
                        i2++;
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
                }

                //Kontrollerar om bokstaven redan dykt upp bland fel gissningar
                for (i = 0; i < gameContent.WrongGuesses.Length; i++)
                {
                    char c = gameContent.WrongGuesses[i];

                    if (gameContent.ValidGuesses[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        break;
                    }
                }

                if (goAgain)
                {
                    continue;
                }

                //Kontrollerar om bokstaven redan dykt upp bland rätt gissningar
                for (i = 0; i < gameContent.DisplayRandomWord.Count; i++)
                {
                    char c = gameContent.DisplayRandomWord[i];

                    if (gameContent.ValidGuesses[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        break;
                    }
                }

                if (goAgain)
                {
                    continue;
                }

                break;
            }


            return gameContent.ValidGuesses[index];
        }

        public void LoggAINumberOfWrongGuesses(GameContent gameContent)
        {
            List<int> aiWrongGuesses = new List<int>();
            string filePath = Path.Combine(AppContext.BaseDirectory, "AINumberOfWrongGuesses.txt");

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
            aiWrongGuesses.Add(gameContent.NumberOfWrongGuesses);

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
                SaveUserWord(gameContent);
            }

            else if (gameContent.GameOver)
            {
                for (int i = 0; i < 2; i++)
                {
                    SaveUserWord(gameContent);
                }
            }

            Debug.WriteLine("********AI Stats******");
            Debug.WriteLine($"Number of wrong guesses: {gameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI average: {ai / aiWrongGuesses.Count}");
        }

        static void SaveUserWord(GameContent gameContent)
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "words.txt");

            File.AppendAllText(filePath, Environment.NewLine + gameContent.RandomWord);

            Debug.WriteLine("Saved the new word...");
        }

        public string SetRandomWord(List<string> allRandomWords)
        {
            string validChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ-";

            Console.Clear();
            Console.Write("Skriv ett ord: ");
            string randomWord = Console.ReadLine()?.ToUpper() ?? string.Empty;

            foreach (char c in randomWord)
            {
                if (!validChar.Contains(c))
                {
                    throw new ArgumentOutOfRangeException("Du får bara ange bokstäverna A-Ö");
                }
            }
            if (randomWord.Length < 1)
            {
                throw new ArgumentNullException("Du måste ange något ord");
            }
            return randomWord;
        }
    }
}
