namespace Hangman
{
    public class Game(bool interFace)
    {
        /*public string[] RandomWords = { "BRYGGA", "LERA", "BIL", "DJUR", "GRYNING", "MÖRKER", "STEG", "BY", "MOLN", "SJÖ"
                , "GRÖT", "FAR", "TRAFIK", "ORM", "REGN", "HAV", "SKOG", "SKY", "DJUR", "BIL", "BLOMMA", "FLAGGA", "VÄG"
                , "STEG", "FISK", "STAD", "LJUS", "DAG", "TALLRIK", "OVERALL", "SOL", "TÅG", "BÄNK", "BRÖD", "BEN", "HUND"
                , "HUS", "SKOLA", "TRAFIK", "FJÄLL", "PENNA", "TÅG", "NÄBB", "REGN", "BÅT", "BI", "CYKEL", "TRÄD", "FLAGGA"
                , "BARN", "STAD", "BIL", "OST", "TRÄD", "STAD", "HANDTAG", "PENNA", "HUND", "ORM", "KANOT", "KAJAK", "PROGRAM"
                , "FJÄLL", "SKOG", "NATT", "SKRIVBORD", "BARN", "SKOG", "GOLV", "LÄGENHET", "DISKMASKIN", "HAV", "LAND", "FJÄDER"
                , "FLYG", "FÄRG", "STAD", "ARM", "SNÖ", "ÄNG", "STEGE", "BÅT", "SJÖ", "SÄNG", "Ö", "FLYGPLAN", "STEG", "BOK"
                , "FJÄDER", "MÅNE", "MOR", "TÅG", "BLÅ", "TRÄD", "VIT", "HUND", "HAND", "VIN", "STAD", "RÅDJUR", "LEJON"
                , "VÄGG", "DJUNGEL", "SJÖ", "BOK", "GLAS", "SKÄGG", "HUVUD", "VÄDER", "FJÄLL", "VAGN", "VÄXT", "TRAPP", "CHIPS"
                , "VIND", "PÅSE", "HUS", "KABEL", "JUICE", "SAND", "TASS", "KRYPA", "SOL", "TRÄ", "BRYGGA", "LJUS", "SKUGGA"
                , "TAK", "BARN", "FRUKT", "LÅDA", "FLYG", "GRÖN", "VIND", "KEDJA", "BARN", "TONÅRING", "GUBBE", "GEVÄR", "SURFPLATTA"
                , "SOLGLASÖGON", "BUSS", "GRYNING", "BORD", "MOROT", "FJÄLL", "MÅNE", "VINDSKYDD", "STUGA", "LASTBIL", "MÅNE", "SKOG", "BY"
                , "PLANET", "OSTHYVEL", "VÄDER", "SLASK", "RADHUS", "MÄNNISKA", "BUSSHÅLLPLATS", "SKED", "DÖRR", "TRÄSK", "SOMMAR", "STOL"
                , "LÄGENHET", "MOTOR", "KLOCKA", "SPÅR", "ÄLG", "MÖRKER", "LODJUR", "BUSKE", "FJÄRRKONTROLL", "SNÖ", "FLAGGA", "VÄG"
                , "LANDSKAP", "HUND", "MODIG", "HJÄRTA", "SVART", "HOPPA", "DJÄVUL", "ÄNGEL", "KYLSKÅP", "GARN", "TÅG", "FJÄLL"
                , "TAVLA", "UGGLA", "TÄCKE", "VÄRMELJUS", "VATTEN", "BY", "BORR", "SKRUVDRAGARE", "FAMILJ", "MOTORVÄG", "STORM", "GLAS"
                , "UR", "SPIS", "TRÖJA", "BY", "IS", "RYGGSÄCK", "SYSTER", "MUGG", "PENGAR", "FLYGPLATS", "TÅGRÄLS", "MOLN", "VIND"
                , "MATTA", "FÖNSTER", "DATOR", "DAL", "SOFFA", "FILT", "SPEL", "KNIV", "BERG", "KATT", "SIFFRA", "KAOS"
                , "RÖD", "FÅGEL", "SKÄGG", "HJUL", "BROR", "VÄXELLÅDA", "FISKESPÖ", "SIMMA", "SKRIVBORD", "GREN", "DIKE", "SAND"
                , "UNIVERSITET", "KRITA", "ULL", "FLAGGA", "TEKNIK", "KUNNIG", "LYCKA", "BRUS", "TÅR", "SKRIN", "MASKIN", "KALAS"
                , "MORGON", "SLUT", "ANTENN", "TÄLT", "DÖD", "KLIPPA", "HAVRE", "MIDDAG", "TOM", "ÅNGA", "GENOM", "BRONS", "HÖST"
                , "FRI", "LEVANDE", "SÅDD", "FEL", "HOPP", "DRIV", "STJÄRNA", "FÖRSTA", "UPPFINNING", "ÖKEN", "LJUD", "INLÄRNING"
                , "SVAG", "EKO", "LEKSAK", "FRAMFÖR", "VINTER", "MINNE", "LÄTT", "UPPREPA", "DUBBEL", "KÄNSLA", "TIDIGARE", "UPPTÄCKT"
                , "FÖDSEL", "ÖDE", "SORG", "LUGN", "RESULTAT", "BAKOM", "BYGGNAD", "TIDNING", "SPONTAN", "PLÅNBOK", "KAMERA", "FROST"
                , "STÅL", "BULLER", "HÖG", "BÖRJAN", "OKUNNIG", "LÖV", "FRAMSTEG", "SAMKVÄM", "KREATIVITET", "TVIVEL", "JORD", "TRIANGEL"
                , "DOKUMENT", "STÄMMA", "TRYCK", "TRO", "SYSTEM", "VIKT", "GLÖMSKA", "STARK", "VIRKA", "KOJA", "HUNGRIG", "MUSIK", "MASK"
                , "TVIVEL", "GAMMALDAGS", "BÄR", "NÄKTAR", "FORSKNING", "SPEKTAKEL", "TID", "MOLEKYL", "MÄTT", "SVÅR", "UPP", "TON"
                , "DRÖM", "NER", "STYV", "VAL", "BLOMSTER", "SENAST", "BILJETT", "LÅG", "ENERGI", "STYCKE", "KOMPLEX", "BREDVID", "FRID"
                , "VÄNSTER", "MÅNAD", "BRO", "KORREKT", "ENKEL", "INTELLIGENS", "SKÖRD", "TIDIG", "TYP", "JUBEL", "JÄRN", "MINUT", "RUNDA"
                , "LUFT", "FÖRRA", "FÖRR", "NY", "FULL", "OSÄKER", "DAGG", "KRAFT", "DECENNIUM", "INSEKT", "OLJUD", "DÖR", "KORT"
                , "ÅRTUSEN", "SVÄLT", "VÄXTER", "GULD", "DUNDER", "TUNNEL", "SENARE", "RELIGION", "HÖGER", "VÅR", "INNOVATION", "BÖN"
                , "ORDNING", "SÄSONG", "BLIXT", "FAST", "PUNKT", "STADGA", "TANKE", "GAMMAL", "SEN", "MITTEN", "SIST", "DOVA", "BESLUT"
                , "KOPPAR", "KANT", "GRÄNS", "TYSTNAD", "VECKA", "PLANET", "KVÄLL", "HASTIG", "ÅR", "SPEL", "SÄKER", "MILD", "VETANDE"
                , "STUGA", "ATOM", "TIMME", "SILVER", "MODERN", "MARDÖM", "LÅNG", "SAFT", "NÄSTA", "SEKEL", "KRING", "UTVECKLING", "NU"
                , "SKRATT", "BOTTEN", "MITTEMOT", "JORD", "FEST", "HANDLING" };*/

        public List<string> RandomWords = new List<string>();
        public bool InterFace { get; } = interFace;

        public static void InitializeGame(Game game, IUserInterface ui)
        {
            (string randomWord, game.RandomWords) = GetRandomWord(game);
            char[] displayWord = GetDisplayWord(randomWord);
            var gameContent = new GameContent(randomWord, displayWord);
            RunningGame(gameContent, ui, game);
        }

        public static (string, List<string>) GetRandomWord(Game game)
        {
            game.RandomWords = GetRandomWordsList(game);

            Random random = new();
            string randomWord = game.RandomWords[random.Next(game.RandomWords.Count)].ToUpper();

            return (randomWord, game.RandomWords);
        }

        public static List<string> GetRandomWordsList(Game game)
        {
            string filePath = "C:\\Users\\danne\\source\\Hangman\\Hangman\\Hangman\\words.txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    game.RandomWords.Add(sr.ReadLine()?.ToUpper() ?? string.Empty);
                }
            }
            return game.RandomWords;
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
                
                try
                {
                    gameContent = CheckingUserGuess(gameContent, ui, game);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(1500);
                    continue;
                }

                gameContent = CheckingWinOrLose(gameContent);
                gameContent.BeginningOfGame = false;

            } while (gameContent.GameLoop);
            WinOrLoseScreen(gameContent);
            Console.ReadKey();
        }

        public static GameContent CheckingUserGuess(GameContent gameContent, IUserInterface ui, Game game)
        {

            gameContent = ui.TakeUserGuess(gameContent, game);

            CheckingCorrectAnswer(gameContent);

            if (gameContent.IfWrongAnswer)
            {
                gameContent.Guesses[gameContent.NumberOfWrongGuesses] = gameContent.UserGuess;
                gameContent.NumberOfWrongGuesses++;
            }
            return gameContent;
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
