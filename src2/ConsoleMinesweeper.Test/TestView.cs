using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMinesweeper.Test
{
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.View;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    using Moq;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestView
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

        [TestMethod]
        public void TestViewDisplayMovesAndTimeShouldNotDisplayInNotRealView()
        {
            testStr = "";
            var view = new ConsoleView(false, ConsoleMock());
            view.DisplayTime(0);
            view.DisplayMoves(0);
            Assert.AreEqual(testStr == "", true, "No output!");
        }

        [TestMethod]
        public void TestViewDisplayMovesAndTimeShouldDisplayInRealView()
        {
            testStr = "";
            var view = new ConsoleView(true, ConsoleMock());
            view.DisplayTime(0);
            view.DisplayMoves(0);
            Assert.AreEqual(testStr != "", true, "No output!");
        }

        [TestMethod]
        public void TestViewPlayersShouldDisplay()
        {
            testStr = "";
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, ConsoleMock());
            IMinesweeperPlayerBoard board = new MinesweeperPlayerBoard("test.mine");
            board.AddPlayer(new MinesweeperPlayer()
                                {
                                    Name = "test",
                                    Time = 0,
                                    Type = MinesweeperDifficultyType.Easy
                                });
            view.DisplayScoreBoard(board);
            Assert.AreEqual(testStr != "", true, "No output!");
        }

        [TestMethod]
        public void TestGridShouldDisplay()
        {
            testStr = "";
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, ConsoleMock());

            IMinesweeperGrid grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            grid.BoomEvent += (sender, args) => { };
            grid.ProtectCell(0, 0);
            grid.RevealCell(1, 1);

            view.DisplayGrid(grid);

            i = 0;
            grid.RevealAllMines();
            view.DisplayGrid(grid);
            Assert.AreEqual(testStr != "", true, "No output!");
        }

        [TestMethod]
        public void TestGridGameOverShouldDisplay()
        {
            testStr = "";
            var i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, ConsoleMock());
            view.AddPlayerEvent += (sender, args) => { };

            view.DisplayGameOver(true);
            Assert.AreEqual(testStr != "", true, "No output!");

            testStr = "";
            i = 0;
            keysCnt = 0;
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            view = new ConsoleView(true, ConsoleMock());
            view.AddPlayerEvent += (sender, args) => { };

            view.DisplayGameOver(false);
            Assert.AreEqual(testStr != "", true, "No output!");
        }

        [TestMethod]
        public void TestScoreList()
        {
            var view = new ConsoleView(true, ConsoleMock());
            view.ShowScoreBoardEvent += (sender, args) => { };
            view.RequestScoreList(MinesweeperDifficultyType.Easy);            
        }
    }
}
