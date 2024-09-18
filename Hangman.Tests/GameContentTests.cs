using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests
{
    [TestClass()]
    public class GameContentTests
    {
        [TestMethod()]
        public void CanConstructGameContent()
        {
            //Arrange
            var randomWord = "LAMPA";
            var displayRandomWord = new char[] { '_', '_', '_', '_', '_' };

            //Act
            var gameContent = new GameContent(randomWord, displayRandomWord);
            
            //Assert
            Assert.Fail();
        }
    }
}