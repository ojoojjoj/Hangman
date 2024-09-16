namespace Hangman.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWordsLenght()
        {
            //Arrange
            var game = new Game();
            
            //Act
            string randomWord = Game.GetRandomWord(game);
            int randomWordLenght = randomWord.Length;
            char[] displayWord = Game.GetDisplayWord(randomWord);
            int displayWordLenght = displayWord.Length;

            //Assert
            Assert.AreEqual(displayWordLenght, randomWordLenght);
        }
    }
}