namespace Hangman
{
    public class Game(bool interFace)
    {
        public string[] RandomWords = { "LAMPA", "KYCKLING", "BJÖRK", "GRILL", "ANKA", "HÄST", "ÖRN", "HÖGTALARE"
        , "SKARVSLADD", "FÖNSTER", "ISOLERING", "EL", "AKADEMIKER", "UNIVERSITET", "GURKA", "TOMAT", "RABATTER", "PERSILJA"
        , "PENNA", "NÄSDUK", "PAPPER", "LJUS", "STOL", "HUSHÅLLSPAPPER", "BANANER", "ÄPPLE", "UGN", "MOBILTELEFON", "MÖSSA"
        , "JACKA", "OVERALL", "DJURPARK", "TIVOLI", "ZOO", "NÖJESPARK", "PARKERING", "GARAGE", "BUSS", "BÅT", "FLYGPLAN", "Ö"
        , "KUDDE", "MYGGA", "INSEKT", "UTSLAG", "VÅRTA", "NAGEL", "TÅ", "ÖRA", "ÖGA", "ÖDLA", "ÄRTA", "ÅRA", "UBÅT", "ÖRHÄNGE"
        , "ÄNGEL", "ÅNGLOK", "ÅNGMASKIN", "MÄRKE", "SIGNAL", "RETRO", "BILJLARD", "TENNIS", "PINGIS", "SCHACK", "ASKA", "BRÖDER"
        , "ORGEL", "PIANO", "TUPP", "SKÅL", "PORSLIN", "FLASKA", "BURK", "FLÄKT", "DATOR", "KOD", "NATUR", "SJUKHUS", "VÅRD"
        , "MÅLAR", "VÄGAR", "LÅNAR", "SKÅLAR", "RÅNAR", "STOLAR", "SPOLAR", "SOLAR", "DALAR", "VÅGAR", "SAKER", "SMAKAR"
        , "BACKAR", "PACKAR", "HACKAR", "TACKAR", "SOCKAR", "LOCKAR", "ROCKAR", "DOCKAR", "KROKAR", "BLÅSER", "LÅSER"
        , "SÅSER", "FASTER", "LASER", "DOSER", "BASER", "RASAR", "FASAD", "MASAR", "SJALAR", "LÅTER", "SÄTER", "ÄTER", "MÅTER"
        , "BRÅKAR", "RAKAR", "SKÅPEN", "LAGAR", "SPÅNAR", "TRÄNAR", "PLÅNBOK", "GLÄNTA", "HOPPAR", "LOPPOR", "STOPPAR", "TOPPAR"
        , "KOPPAR", "SHOPPAR", "MOPPA", "DOPPAR","KALLA", "STALL", "BALAR", "HALKAR", "VALLAR", "FALLER", "RALLY", "SALAR"
        , "PALLAR", "GALLER", "MALLAR", "TALLAR", "VAKNAR", "SAKNAR", "RÄKNAR", "TANKAR","SKINER", "GLIDER", "KLIAR", "FLINAR"
        , "BIlAR", "LINA", "SINAR", "VIN", "SOPPAR", "ROPAR", "KÖPER", "TORKAR", "GAPAR", "LAPAR", "RAPAR", "LAGAR", "KRONOR"
        , "DOCKOR", "HÖNOR", "TONER", "MYGGOR", "SNÖRE", "GRAN", "KONER", "DRIVER", "SILVER", "RIVER", "VINER", "LITER", "BÄVER"
        , "TIGER", "NIGER", "FLYGER", "RYKER", "BYGGER", "TYGER", "GRYNER", "STUGOR", "LYSER", "VYER", "SKEPPAR", "PEPPAR"
        , "LÄPPAR", "FENAR", "REPAR", "HEJAR", "TEJPAR", "METAR", "SAMTAL", "TANTER", "RAMSOR", "LAKAN", "KAMRAT", "BAMBU"
        , "DAMMAR", "HAMSTER", "SPRANG", "BRANN", "KLANG", "TRAMPA", "PANGA", "DRÄNKA", "GUNGA", "VRÅLA", "VÄXER", "LÄXER"
        , "SAXAR", "VÄRKER", "NÄSOR", "RÄKOR", "BÄVER", "MÄLTE"};
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
