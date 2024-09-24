namespace Hangman
{
    public class Game(bool interFace)
    {
        public string[] RandomWords = { "BRYGGA", "LERA", "BIL", "DJUR", "GRYNING", "MÖRKER", "STEG", "BY", "MOLN", "SJÖ"
                , "GRÖT", "FAR", "TRAFIK", "ORM", "REGN", "HAV", "SKOG", "SKY", "DJUR", "BIL", "BLOMMA", "FLAGGA", "VÄG"
                , "STEG", "FISK", "STAD", "LJUS", "DAG", "TALLRIK", "BLOMMA", "SOL", "TÅG", "BÄNK", "BRÖD", "BEN", "HUND"
                , "HUS", "SKOLA", "TRAFIK", "FJÄLL", "PENNA", "TÅG", "NÄBB", "REGN", "BÅT", "BI", "CYKEL", "TRÄD", "FLAGGA"
                , "BARN", "STAD", "BIL", "CYKEL", "CYKEL", "OST", "TRÄD", "STAD", "BLOMMA", "PENNA", "HUND", "CYKEL", "ORM"
                , "FJÄLL", "SKOG", "NATT", "SKRIVBORD", "BARN", "SKOG", "GOLV", "LÄGENHET", "BLOMMA", "HAV", "LAND", "FJÄDER"
                , "FLYG", "FÄRG", "STAD", "ARM", "SNÖ", "ÄNG", "HÅLL", "BÅT", "SJÖ", "SÄNG", "Ö", "FLYGPLAN", "STEG", "BOK"
                , "FJÄDER", "MÅNE", "MOR", "TÅG", "BLÅ", "SJÖ", "TRÄD", "VIT", "HUND", "BIL", "BLOMMA", "HAND", "VIN", "STAD"
                , "VÄGG", "GABEL", "SJÖ", "BOK", "GLAS", "SKÄGG", "HUVUD", "VÄDER", "FJÄLL", "VAGN", "VÄXT", "BOK", "TRAPP"
                , "VIND", "SKOLA", "HUS", "TRAFIK", "TRAFIK", "SAND", "TASS", "CYKEL", "SOL", "TRÄ", "BRYGGA", "LJUS", "SKUGGA"
                , "TAK", "BARN", "BIL", "FRUKT", "LÅDA", "SKRIVBORD", "FLYG", "GRÖN", "BLOMMA", "VIND", "TRAFIK", "BARN"
                , "STAD", "BUSS", "GRYNING", "BORD", "MOROT", "FJÄLL", "FLYG", "GRÄS", "STAD", "SJÖ", "MÅNE", "SKOG", "BY"
                , "SKOG", "BOK", "VÄDER", "SLASK", "HUS", "MÄNNISKA", "BUSS", "SKED", "DÖRR", "SKOG", "HUS", "SOMMAR", "STOL"
                , "SKOLA", "BIL", "KLOCKA", "SPÅR", "KLOCKA", "MÖRKER", "HÅLL", "TRÄD", "TRAFIK", "SNÖ", "FLAGGA", "VÄG"
                , "LANDSKAP", "HUND", "SJÖ", "HJÄRTA", "SVART", "CYKEL", "STAD", "MÄNNISKA", "STAD", "HAV", "TÅG", "FJÄLL"
                , "HAV", "FÅGEL", "TÅG", "BIL", "VATTEN", "BY", "STEG", "BY", "FAMILJ", "VÄG", "STORM", "GLAS", "VÄN"
                , "KLOCKA", "BLOMMA", "HAV", "BY", "IS", "SJÖ", "SYSTER", "REGN", "BUSS", "FLYG", "TÅG", "MOLN", "VIND"
                , "SKOLA", "FÖNSTER", "DATOR", "DAL", "HUS", "SKOG", "SKOLA", "KNIV", "BERG", "KATT", "MÄNNISKA", "TRAFIK"
                , "RÖD", "FÅGEL", "SKÄGG", "SKOLA", "BROR", "BLOMMA", "SKUGGA", "CYKEL", "SKRIVBORD", "TRÄD", "VÄG", "SAND"
                , "SKOLA", "PENNA", "STEG", "FLAGGA", "TEKNIK", "KUNNIG", "LYCKA", "BRUS", "TÅR", "SKRIN", "MASKIN", "KALAS"
                , "MORGON", "SLUT", "KLANG", "TÄLT", "DÖD", "KLIPPA", "HAVRE", "MIDDAG", "TOM", "ÅNGA", "GENOM", "BRONS", "HÖST"
                , "FRI", "LEVANDE", "SÅDD", "FEL", "HOPP", "DRIV", "STJÄRNA", "FÖRSTA", "UPPFINNING", "ÖKEN", "LJUD", "INLÄRNING"
                , "SVAG", "EKO", "MELLODY", "FRAMFÖR", "VINTER", "MINNE", "LÄTT", "KAOS", "DUBBEL", "KÄNSLA", "TIDIGARE", "UPPTÄCKT"
                , "FÖDSEL", "ÖDE", "SORG", "LUGN", "RESULTAT", "BAKOM", "BYGGNAD", "TIDNING", "SPONTAN", "PLÅNBOK", "KAMERA", "FROST"
                , "STÅL", "BULLER", "HÖG", "BÖRJAN", "OKUNNIG", "LÖV", "FRAMSTEG", "SAMKVÄM", "KREATIVITET", "TVIVEL", "JORD", "KLING"
                , "DOKUMENT", "STÄMMA", "TRYCK", "TRO", "SYSTEM", "VIKT", "GLÖMSKA", "STARK", "RHYTM", "KOJA", "HUNGRIG", "MUSIK", "MASK"
                , "TVIVEL", "GAMMALDAGS", "BÄR", "NÄKTAR", "FORSKNING", "SPEKTAKEL", "TID", "MOLEKYL", "MÄTT", "SVÅR", "UPP", "TON"
                , "DRÖM", "NER", "STYV", "VAL", "BLOMSTER", "SENAST", "BILJETT", "LÅG", "ENERGI", "STYCKE", "KOMPLEX", "BREDVID", "FRID"
                , "VÄNSTER", "MÅNAD", "BRO", "KORREKT", "ENKEL", "INTELLIGENS", "SKÖRD", "TIDIG", "TYP", "JUBEL", "JÄRN", "MINUT", "RUNDA"
                , "LUFT", "FÖRRA", "FÖRR", "NY", "FULL", "OSÄKER", "DAGG", "KRAFT", "DECENNIUM", "INSEKT", "OLJUD", "DÖR", "KORT"
                , "ÅRTUSEN", "SVÄLT", "VÄXTER", "GULD", "DUNDER", "TUNNEL", "SENARE", "RELIGION", "HÖGER", "VÅR", "INNOVATION", "BÖN"
                , "ORDNING", "SÄSONG", "BLIXT", "FAST", "PUNKT", "STADGA", "TANKE", "GAMMAL", "SEN", "MITTEN", "SIST", "DOVA", "BESLUT"
                , "KOPPAR", "KANT", "GRÄNS", "TYSTNAD", "VECKA", "PLANET", "KVÄLL", "HASTIG", "ÅR", "SPEL", "SÄKER", "MILD", "VETANDE"
                , "STUGA", "ATOM", "TIMME", "SILVER", "MODERN", "MARDÖM", "LÅNG", "SAFT", "NÄSTA", "SEKEL", "KRING", "UTVECKLING", "NU"
                , "SKRATT", "BOTTEN", "MITTEMOT", "JORD", "FEST", "HANDLING" };
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
