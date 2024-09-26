using System.Diagnostics;

namespace Hangman
{
    public class AutoInterFace : IUserInterface
    {
        public List<string> PossibleWords = new List<string>();

        public static List<string> SetPossibleWords(Game game, List<string> possibleWords, GameContent gameContent)
        {
            foreach (string word in game.RandomWords)
            {
                if (gameContent.DisplayRandomWord.Length == word.Length)
                {
                    possibleWords.Add(word); 
                }
                gameContent.NumberOfIterations++;
            }
            return possibleWords;
        }

        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {
            Thread.Sleep(2000);
            Random random = new Random();
            
            gameContent.NumberOfIterations = 0;
            if (gameContent.BeginningOfGame)
            {
                PossibleWords = SetPossibleWords(game, PossibleWords, gameContent);
            }
            (PossibleWords, gameContent) = RemovedWords(gameContent, PossibleWords);
            (PossibleWords, gameContent) = GetPossibleWords(gameContent, PossibleWords);

            if (PossibleWords.Count > 1)
            {
                (gameContent.UserGuess, gameContent) = MostCommonChar(gameContent, PossibleWords);
            }
            else if (PossibleWords.Count == 1)
            {
                string word = PossibleWords[0];
                gameContent.UserGuess = GetExactChar(gameContent, word);
            }
            else
            {
                foreach (char c in gameContent.ValidChar)
                {
                    if (!gameContent.Guesses.Contains(c) && !gameContent.DisplayRandomWord.Contains(c))
                    {
                        gameContent.UserGuess = c;
                        break;
                    }
                }
            }

            Debug.WriteLine("**********************");
            Debug.WriteLine($"Number of iterations: {gameContent.NumberOfIterations}");
            Debug.WriteLine($"Possible words left: {PossibleWords.Count}");
            Debug.WriteLine($"Number of guesses left: {10 - gameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI guesses: {gameContent.UserGuess}");

            return gameContent;
        }

        static (List<string>, GameContent) RemovedWords(GameContent gameContent, List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();
            bool falseChar = false;

            foreach (string word in possibleWords)
            {
                falseChar = false;
                foreach (char charWord in word)
                {
                    foreach (char charGuesses in gameContent.Guesses)
                    {
                        if (charWord == charGuesses)
                        {
                            falseChar = true;
                            removedWords.Add(word);
                            gameContent.NumberOfIterations++;
                            break;
                        }
                        gameContent.NumberOfIterations++;
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
            
            return (possibleWords, gameContent);
        }

        static (List<string>, GameContent) GetPossibleWords(GameContent gameContent, List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();

            for (int i = 0; i < gameContent.DisplayRandomWord.Length; i++)
            {
                char displayChar = gameContent.DisplayRandomWord[i];

                for (int j = 0; j < possibleWords.Count; j++)
                {
                    string word = possibleWords[j];

                    char wordChar = word[i];

                    if (displayChar != wordChar && displayChar != '_')
                    {
                        removedWords.Add(word);
                    }
                    gameContent.NumberOfIterations++;

                }
            }
            foreach (string word in removedWords)
            {
                possibleWords.Remove(word);
            }
            return (possibleWords, gameContent);
        }

        char GetExactChar(GameContent gameContent, string word)
        {
            foreach (char c in word)
            {
                if (!gameContent.DisplayRandomWord.Contains(c))
                {
                    return c;
                }
            }
            PossibleWords.Remove(word);
            
            return word[0];
        }

        static (char, GameContent) MostCommonChar(GameContent gameContent, List<string> possibleWords)
        {
            int[] numberOfChar = new int[gameContent.ValidChar.Length];

            //Räknar antal bokstäver i possibleWords
            foreach (string word in possibleWords)
            {
                foreach (char c in word)
                {
                    int i2 = 0;
                    foreach (char c2 in gameContent.ValidChar)
                    {
                        if (c == c2)
                        {
                            numberOfChar[i2]++;
                            gameContent.NumberOfIterations++;
                            break;
                        }
                        i2++;
                        gameContent.NumberOfIterations++;
                    }
                }
            }
            bool loop = true;
            bool goAgain = false;
            int index = 0;

            while (loop)
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
                    gameContent.NumberOfIterations++;
                }

                //Kontrollerar om bokstaven redan dykt upp bland fel gissningar
                for (i = 0; i < gameContent.Guesses.Length; i++)
                {
                    char c = gameContent.Guesses[i];

                    if (gameContent.ValidChar[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        gameContent.NumberOfIterations++;
                        break;
                    }
                    gameContent.NumberOfIterations++;
                }

                if (goAgain)
                {
                    continue;
                }

                //Kontrollerar om bokstaven redan dykt upp bland rätt gissningar
                for (i = 0; i < gameContent.DisplayRandomWord.Length; i++)
                {
                    char c = gameContent.DisplayRandomWord[i];

                    if (gameContent.ValidChar[index] == c)
                    {
                        numberOfChar[index] = 0;
                        goAgain = true;
                        gameContent.NumberOfIterations++;
                        break;
                    }
                    gameContent.NumberOfIterations++;
                }

                if (goAgain)
                {
                    continue;
                }
                loop = false;
            }


            return (gameContent.ValidChar[index], gameContent);
        }

        public void LoggAINumberOfWrongGuesses(GameContent gameContent)
        {
            List<int> aiWrongGuesses = new List<int>();
            string filePath = "C:\\Users\\danne\\source\\Hangman\\Hangman\\Hangman\\AINumberOfWrongGuesses.txt";
            float ai = 0;

            using (var sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    int.TryParse(sr.ReadLine(), out int number);
                    aiWrongGuesses.Add(number);
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

            Debug.WriteLine("********AI Stats******");
            Debug.WriteLine($"Number of wrong guesses: {gameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI average: {ai / aiWrongGuesses.Count}");
        }

        static void SaveUserWord (GameContent gameContent)
        {
            string filePath = "C:\\Users\\danne\\source\\Hangman\\Hangman\\Hangman\\words.txt";

            File.AppendAllText(filePath,Environment.NewLine + gameContent.RandomWord);

            Debug.WriteLine("Saved the new word...");
        }
    }
}
