using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMinesweeper.Test
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;
    using ConsoleMinesweeper.View;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    using Moq;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestMenus
    {
        private string testStr;
        private ConsoleKeyInfo[] testKeys = new ConsoleKeyInfo[30];
        private int keysCnt;

        private IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> ConsoleMock()
        {
            var mockedConsole = new Mock<IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>>();
            mockedConsole.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(r => { this.testStr = r; });
            mockedConsole.Setup(r => r.ReadKey(It.IsAny<bool>())).Returns(() =>
            {
                return testKeys[keysCnt++];
            });
            mockedConsole.Setup(r => r.ResetColor()).Verifiable();
            mockedConsole.Setup(r => r.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>())).Verifiable(); ;
            return mockedConsole.Object;
        }

        private IConsoleView ViewMock()
        {
            var mockedView = new Mock<IConsoleView>();
            mockedView.Setup(r => r.DisplayGameOver(It.IsAny<bool>())).Verifiable();
            mockedView.Setup(r => r.DisplayGrid(It.IsAny<IMinesweeperGrid>())).Verifiable();
            mockedView.Setup(r => r.DisplayMoves(It.IsAny<int>())).Verifiable();
            mockedView.Setup(r => r.DisplayTime(It.IsAny<int>())).Verifiable();
            mockedView.Setup(r => r.DisplayScoreBoard(It.IsAny<IMinesweeperPlayerBoard>())).Verifiable();
            return mockedView.Object;
        }

        [TestMethod]
        public void TestStartMenusShouldDisplay()
        {
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            
            testStr = "";
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), new ConsoleView(false, this.ConsoleMock()), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");
            testStr = "";
            ConsoleMenus.StartMainMenu(this.ConsoleMock());
            Assert.AreEqual(testStr != "", true, "No output for menu!");
            testStr = "";

        }

        [TestMethod]
        public void TestGameStartMenuItemsShouldDisplay()
        {
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());            
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());            
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());            
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");
        }

        [TestMethod]
        public void TestScoreStartMenuItemsShouldDisplay()
        {
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");

            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            testStr = "";
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(testStr != "", true, "No output for menu!");
        }
    }
}
