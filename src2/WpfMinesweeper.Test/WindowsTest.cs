namespace WpfMinesweeper.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    using Minesweeper.Models;

    using WpfMinesweeper;
    using WpfMinesweeper.View;
    
    [TestClass]
    public class WindowsTest
    {
        private void TestActionDelegate(string testString)
        {
            return;
        }

        [TestMethod]
        public void TestMainWindowCreation()
        {
            var mainWindow = new MainWindow();

            Assert.AreNotEqual(null, mainWindow, "Main window created successfully");
        }

        [TestMethod]
        public void TestScoreWindowCreation()
        {
            string playersFilename = "scores.data";
            var board = new MinesweeperPlayerBoard(playersFilename);
            var scoreWindow = new ScoresWindow(board);
            
            Assert.AreNotEqual(null, scoreWindow, "Score window created successfully");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestScoreWindowNotCreatedWhenPassedInvalidData()
        {
            var scoreWindow = new ScoresWindow(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TestInputBoxCreation()
        {
            var inputBox = new InputBox(TestActionDelegate);

            Assert.AreNotEqual(null, inputBox, "Input box created successfully");
        }


    }
}
