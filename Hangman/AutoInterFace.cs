using System.Diagnostics;

namespace Hangman
{
    public class AutoInterFace : IUserInterface
    {
        public GameContent TakeUserGuess(GameContent gameContent, Game game)
        {
            Random random = new Random();
            var possibleWords = new List<string>();

            possibleWords.Clear();
            possibleWords = RemovedWords(game, gameContent, possibleWords);
            possibleWords = PossibleWords(game, gameContent, possibleWords);

            string word = GuessWord(random, game, possibleWords);
            gameContent.UserGuess = word.ToCharArray()[random.Next(word.Length)];
            Debug.WriteLine($"AI guesses: {gameContent.UserGuess}");
            Debug.WriteLine($"Possible words left: {possibleWords.Count}");
            Thread.Sleep(2000);
            return gameContent;
        }

        public string GuessWord(Random random, Game game, List<string> possibleWords)
        {
            string word = possibleWords[random.Next(possibleWords.Count)];
            return word;
        }

        public List<string> RemovedWords(Game game, GameContent gameContant, List<string> possibleWords)
        {
            bool falseChar = false;

            foreach (string word in game.RandomWords)
            {
                falseChar = false;
                foreach (char charWord in word)
                {
                    foreach (char charGuesses in gameContant.Guesses)
                    {
                        if (charWord == charGuesses)
                        {
                            falseChar = true;
                            break;
                        }
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

            return possibleWords;
        }

        public List<string> PossibleWords(Game game, GameContent gameContant, List<string> possibleWords)
        {
            List<string> removedWords = new List<string>();

            foreach (char c in gameContant.DisplayRandomWord)
            {
                foreach (string word in possibleWords)
                {
                    if (!word.Contains(c) && c != '_')
                    {
                        removedWords.Add(word);
                    }
                }
            }
            foreach (string word in removedWords)
            {
                possibleWords.Remove(word);
            }
            return possibleWords;
        }

    }
}
