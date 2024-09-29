namespace Hangman
{
    public static class GameContent
    {
        public static string RandomWord = "";
        public static List<char> DisplayRandomWord = new List<char>();
        public static char[] WrongGuesses = new char[11];
        public static bool GameRunning = true;
        public static char UserGuess;
        public static int NumberOfWrongGuesses;
        public static bool GameOver = false;
        public static bool Win = false;
        public static string ValidGuesses = "ABCDEFGHIJKLMNOPQRSTUVWXYZÅÄÖ-";
        public static int NumberOfIterations;
        public static bool BeginningOfGame = true;
    }
}
