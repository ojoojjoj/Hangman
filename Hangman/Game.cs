namespace Hangman
{
    public class Game(bool interFace)
    {
        public string[] RandomWords = {"LAMPA", "KYCKLING", "BJÖRK", "GRILL", "ANKA", "HÄST", "ÖRN", "HÖGTALARE"
        , "SKARVSLADD", "FÖNSTER", "ISOLERING", "EL", "AKADEMIKER", "UNIVERSITET", "GURKA", "TOMAT", "RABATTER", "PERSILJA"
        , "PENNA", "NÄSDUK", "PAPPER", "LJUS", "STOL", "HUSHÅLLSPAPPER", "BANANER", "ÄPPLE", "UGN", "MOBILTELEFON", "MÖSSA"
        , "JACKA", "OVERALL", "DJURPARK", "TIVOLI", "ZOO", "NÖJESPARK", "PARKERING", "GARAGE", "BUSS", "BÅT", "FLYGPLAN", "Ö"
        , "KUDDE", "MYGGA", "INSEKT", "UTSLAG", "VÅRTA", "NAGEL", "TÅ", "ÖRA", "ÖGA", "ÖDLA", "ÄRTA", "ÅRA", "UBÅT", "ÖRHÄNGE"
        , "ÄNGEL", "ÅNGLOK", "ÅNGMASKIN", "MÄRKE", "SIGNAL", "RETRO", "BILJLARD", "TENNIS", "PINGIS", "SCHACK", "ASKA", "BRÖDER"
        , "ORGEL", "PIANO", "TUPP", "SKÅL", "PORSLIN", "FLASKA", "BURK", "FLÄKT", "DATOR", "KOD", "NATUR", "SJUKHUS", "VÅRD"
        , "MÅLAR", "TÅGAR", "VÄGAR", "LÅNAR", "SKÅLAR", "RÅNAR", "STOLAR", "SPOLAR", "POLAR"
        , "SOLAR", "DALAR", "VÅGAR", "RÅGAR", "SAKAR", "SMAKAR", "BACKAR", "PACKAR", "HACKAR"
        , "TACKAR", "SOCKAR", "LOCKAR", "ROCKAR", "DOCKAR", "KROKAR", "BLÅSER", "LÅSER"
        , "SÅSER", "FASER", "LASER", "DOSER", "BASER", "KASAR", "RASAR", "FASAR", "MASAR"
        , "SASAR", "LÅTER", "SÄTER", "ÄTER", "MÅTER", "BRÅKAR", "RÅKAR", "SKÅPAR", "LÅGAR"
        , "SPÅNAR", "TRÅNAR", "PLÅNAR", "SLÅNAR", "GLÅMAR", "HOPPAR", "LOPPAR", "STOPPAR", "TOPPAR", "KOPPAR", "SHOPPAR", "MOPPAR", "DOPPAR",
         "KALLAR", "STALLAR", "BALLAR", "HALLAR", "VALLAR", "FALLAR", "RALLAR", "SALLAR",
         "PALLAR", "GALLAR", "MALLAR", "TALLAR", "VAKNAR", "SAKNAR", "RAKNAR", "TAKNAR",
        "SKINAR", "GLINAR", "KLINAR", "FINAR", "BINAR", "LINAR", "SINAR", "VINAR",
        "SOPAR", "ROPAR", "KOPAR", "TOPAR", "GAPAR", "LAPAR", "RAPAR", "TAPAR",
        "KRONOR", "DONOR", "HONOR", "TONOR", "MONOR", "SONOR", "GONOR", "KONOR",
        "DRIVER", "SLIVER", "RIVER", "VIVER", "LIVER", "BIVER", "GIVER", "TIVER",
        "FLYGER", "RYGER", "BYGER", "TRYGER", "GRYGER", "STYGER", "LYGER", "VYGER",
        "SKEPAR", "PEPAR", "LEPAR", "FEPAR", "REPAR", "HEPAR", "GEPAR", "TEPAR",
        "SAMTAR", "TAMTAR", "RAMTAR", "LAMTAR", "KAMTAR", "BAMTAR", "DAMTAR", "HAMTAR",
        "SPRANG", "BRANG", "KRANG", "TRANG", "PRANG", "DRANG", "GRANG", "VRANG",
        "VÄXER", "LÄXER", "SÄXER", "TÄXER", "NÄXER", "RÄXER", "BÄXER", "MÄXER"};
        public bool InterFace { get; } = interFace;

        public static void InitializeGame(Game game, IUserInterface ui)
        {
            string randomWord = GetRandomWord(game);
            char[] displayWord = GetDisplayWord(randomWord);
            var gameContent = new GameContent(randomWord, displayWord);
            RunningGame(gameContent, ui, game);
        }

        public static string GetRandomWord(Game game)
        {
            Random random = new();
            string randomWord = game.RandomWords[random.Next(game.RandomWords.Length)];
            return randomWord;
        }

        public static char[] GetDisplayWord(string randomWord)
        {
            char[] displayWord = new char[randomWord.Length];

            for (int i = 0; i < randomWord.Length; i++)
            {
                displayWord[i] = '_';
            }

            return displayWord;
        }

        public static void RunningGame(GameContent gameContent, IUserInterface ui, Game game)
        {
            do
            {
                DisplayGame.DisplayView(gameContent);
                gameContent = CheckingUserGuess(gameContent, ui, game);
                gameContent = CheckingWinOrLose(gameContent);

            } while (gameContent.GameLoop);
            WinOrLoseScreen(gameContent);
            Console.ReadKey();
        }

        public static GameContent CheckingUserGuess(GameContent gameContent, IUserInterface ui, Game game)
        {
            gameContent = ui.TakeUserGuess(gameContent, game);
            bool validChar = CheckValidChar(gameContent);
            bool doubleGuess = CheckingDoubleGuess(gameContent);

            if (doubleGuess || !validChar)
            {
                return gameContent;
            }

            CheckingCorrectAnswer(gameContent);

            if (gameContent.IfWrongAnswer)
            {
                gameContent.Guesses[gameContent.NumberOfWrongGuesses] = gameContent.UserGuess;
                gameContent.NumberOfWrongGuesses++;
            }
            return gameContent;
        }

        public static GameContent TakeUserGuess(GameContent gameContent)
        {
            char.TryParse(Console.ReadLine(), out gameContent.UserGuess);
            gameContent.UserGuess = char.ToUpper(gameContent.UserGuess);

            return gameContent;
        }

        public static bool CheckValidChar(GameContent gameContent)
        {
            for (int i = 0; i < gameContent.ValidChar.Length; i++)
            {
                if (gameContent.UserGuess == gameContent.ValidChar[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckingDoubleGuess(GameContent gameContent)
        {
            for (int i = 0; i < gameContent.Guesses.Length; i++)
            {
                if (gameContent.UserGuess == gameContent.Guesses[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static GameContent CheckingCorrectAnswer(GameContent gameContent)
        {
            gameContent.IfWrongAnswer = true;

            for (int i = 0; i < gameContent.RandomWord.Length; i++)
            {
                if (gameContent.RandomWord[i] == gameContent.UserGuess)
                {
                    gameContent.DisplayRandomWord[i] = gameContent.UserGuess;
                    gameContent.IfWrongAnswer = false;
                }
            }
            return gameContent;
        }

        public static GameContent CheckingWinOrLose(GameContent gameContent)
        {
            if (gameContent.NumberOfWrongGuesses >= 10)
            {
                gameContent.GameOver = true;
                gameContent.GameLoop = false;
                return gameContent;
            }

            for (int i = 0; i < gameContent.DisplayRandomWord.Length; i++)
            {
                if (gameContent.RandomWord[i] != gameContent.DisplayRandomWord[i])
                {
                    gameContent.Winner = false;
                    gameContent.GameLoop = true;
                    break;
                }
                gameContent.Winner = true;
                gameContent.GameLoop = false;
            }

            return gameContent;
        }

        public static void WinOrLoseScreen(GameContent gameContent)
        {
            if (gameContent.GameOver)
            {
                DisplayGame.GameOverScreen(gameContent);
            }
            else if (gameContent.Winner)
            {
                DisplayGame.WinScreen(gameContent);
            }
        }
    }
}
