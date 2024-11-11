using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests
{
    [TestClass]
    public class InitializeTest
    {
        [TestMethod]
        public void GetAllRandomWordsFromFileTest()
        {
            //Arrange
            IGameMode OutputInput = new TestGameMode();

            //Act
            Initialize.InitializeGame(OutputInput);
            List<string> expectedAllRandomWords = new List<string> { "DEFAULT1", "DEFAULT2", "DEFAULT3" };

            //Assert
            CollectionAssert.AreEqual(expectedAllRandomWords, Initialize.AllRandomWords);
        }

        [TestMethod]
        public void GetRandomWordTest()
        {
            //Arrange
            IGameMode OutputInput = new TestGameMode();

            //Act
            Initialize.InitializeGame(OutputInput);
            string expectedRandomWord = "DEFAULT";

            //Assert
            Assert.AreEqual(expectedRandomWord, GameContent.RandomWord);
        }

        [TestMethod()]
        public void GetDisplayWordTest()
        {
            //Arrange 
            IGameMode OutputInput = new TestGameMode();

            //Act
            Initialize.InitializeGame(OutputInput);
            List<char> expectedDisplayWord = new List<char> { '_', '_', '_', '_', '_', '_', '_' };

            //Assert
            CollectionAssert.AreEqual(expectedDisplayWord, GameContent.DisplayRandomWord);
        }
    }
}
