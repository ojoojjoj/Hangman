using System.Diagnostics;

namespace Hangman
{
    public class AutoInterFace : IUserInterface
    {
        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {
            Thread.Sleep(2000);
            Random random = new Random();
            var possibleWords = new List<string>();
            gameContent.NumberOfIterations = 0;

            possibleWords.Clear();
            (possibleWords, gameContent) = RemovedWords(game, gameContent, possibleWords);
            (possibleWords, gameContent) = CountWordsLenght(game, gameContent, possibleWords);
            (possibleWords, gameContent) = PossibleWords(game, gameContent, possibleWords);


            if (possibleWords.Count > 1)
            {
                (gameContent.UserGuess, gameContent) = MostCommonChar(gameContent, possibleWords);
            }
            else
            {
                string word = possibleWords[0];
                gameContent.UserGuess = GetExactChar(gameContent, word);
            }

            Debug.WriteLine("**********************");
            Debug.WriteLine($"Number of iterations: {gameContent.NumberOfIterations}");
            Debug.WriteLine($"Possible words left: {possibleWords.Count}");
            Debug.WriteLine($"Number of guesses left: {10 - gameContent.NumberOfWrongGuesses}");
            Debug.WriteLine($"AI guesses: {gameContent.UserGuess}");

            return gameContent;
        }

        public string GuessWord(Random random, Game game, List<string> possibleWords, GameContent gameContent)
        {

            string word = possibleWords[random.Next(possibleWords.Count)];
            return word;
        }

        public (List<string>, GameContent) RemovedWords(Game game, GameContent gameContent, List<string> possibleWords)
        {
            bool falseChar = false;

            foreach (string word in game.RandomWords)
            {
                falseChar = false;
                foreach (char charWord in word)
                {
                    foreach (char charGuesses in gameContent.Guesses)
                    {
                        if (charWord == charGuesses)
                        {
                            falseChar = true;
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
                if (falseChar == false)
                {
                    possibleWords.Add(word);
                }
            }
            
            return (possibleWords, gameContent);
        }

        public (List<string>, GameContent) PossibleWords(Game game, GameContent gameContent, List<string> possibleWords)
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

        public (List<string>, GameContent) CountWordsLenght(Game game, GameContent gameContent, List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();

            foreach (string word in possibleWords)
            {
                if (gameContent.DisplayRandomWord.Length != word.Length)
                {
                    removedWords.Add(word);
                }
                gameContent.NumberOfIterations++;
            }
            foreach (string word in removedWords)
            {
                possibleWords.Remove(word);
            }
            return (possibleWords, gameContent);
        }

        public char GetExactChar(GameContent gameContent, string word)
        {
            foreach (char c in word)
            {
                if (!gameContent.DisplayRandomWord.Contains(c))
                {
                    return c;
                }
            }

            return word[0];
        }

        public (char, GameContent) MostCommonChar(GameContent gameContent, List<string> possibleWords)
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

    }
}
