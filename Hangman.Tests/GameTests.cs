using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;

namespace Hangman.Tests
{
    [TestClass]
    public class GameTests
    {


        [TestMethod()]
        [DataRow("LAMPA", "_____")]
        [DataRow("KYCKLING", "________")]
        [DataRow("ANKA", "____")]
        public void GetDisplayWordTest(string word, string expectedResult)
        {
            //Arrange 

            //Act
            char[] actualResult = Game.GetDisplayWord(word);

            //Assert
            CollectionAssert.AreEqual(expectedResult.ToCharArray(), actualResult, $"Game.GetDisplayWord fails, expected: {expectedResult}, actual: {actualResult}");
        }

        [TestMethod()]
        public void GetRandomWordTest()
        {
            //Arrange
            var game = new Game();

            //Act
            string actualResult = Game.GetRandomWord(game); //How do we test this? 
            //string expectedResultWord = "??????"; //What do we expect when Game is dependent on class Random?
            bool expectedResult = game.RandomWords.Contains(actualResult);

            //Assert
            Assert.IsTrue(expectedResult);
        }

        [DataRow("ANKA", "____")]
        [TestMethod()]
        public void CheckingDoubleGuessTest(string randomWord, string displayWord)
        {
            //Arrange
            var gameContent = new GameContent(randomWord, displayWord.ToCharArray());
            gameContent.UserGuess = 'A';
            gameContent.Guesses[0] = 'A';

            //Act
            bool doubleGuess = Game.CheckingDoubleGuess(gameContent);

            //Assert
            Assert.IsTrue(doubleGuess);
        }
    }
}