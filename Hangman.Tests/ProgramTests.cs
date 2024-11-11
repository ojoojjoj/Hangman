using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetInterfaceTest()
        {
            //Arrange
            var expected = new TestGameMode();
            var expected2 = new UserGameMode();
            var expected3 = new AIGameMode();

            //Act
            var actual = Program.GetInterface(expected);
            var actual2 = Program.GetInterface(expected2);
            var actual3 = Program.GetInterface(expected3);

            //Assert
            Assert.ReferenceEquals(actual, expected);
            Assert.ReferenceEquals(actual2, expected2);
            Assert.ReferenceEquals(actual3, expected3);
        }
    }
}
