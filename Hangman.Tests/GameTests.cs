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
            string expectedResult = "??????"; //What do we expect when Game is dependent on class Random?

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}