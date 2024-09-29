using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;

namespace Hangman.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetUserGuessTest()
        {
            //Arrange
            IInterface UserOrAi = new TestInterface();
            Initialize.InitializeGame(UserOrAi);

            //Act
            Game.Run(UserOrAi);
            char expectedResult = 'D';

            //Assert
            Assert.AreEqual(expectedResult, GameContent.UserGuess);
        }

        [TestMethod]
        public void CheckingCorrectAnswerTest()
        {
            //Arrange
            IInterface OutputInput = new TestInterface();
            Initialize.InitializeGame(OutputInput);

            //Act
            Game.Run(OutputInput);
            List<char> expectedResult = new List<char> {'D', '_', '_', '_', '_', '_', '_' };

            //Assert
            CollectionAssert.AreEqual(expectedResult, GameContent.DisplayRandomWord);
        }





    }
}