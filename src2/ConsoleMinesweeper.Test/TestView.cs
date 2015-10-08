// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestView.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The test view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.View;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Models;

    using Moq;

    /// <summary>
    /// The test view.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestView
    {
        /// <summary>
        /// The test keys.
        /// </summary>
        private readonly ConsoleKeyInfo[] testKeys = new ConsoleKeyInfo[30];

        /// <summary>
        /// The keys cnt.
        /// </summary>
        private int keysCnt;

        /// <summary>
        /// The test str.
        /// </summary>
        private string testStr;

        /// <summary>
        /// The console mock.
        /// </summary>
        /// <returns>
        /// The <see cref="IConsoleWrapper"/>.
        /// </returns>
        private IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> ConsoleMock()
        {
            var mockedConsole = new Mock<IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>>();
            mockedConsole.Setup(r => r.Write(It.IsAny<string>())).Callback<string>(r => { this.testStr = r; });
            mockedConsole.Setup(r => r.ReadKey(It.IsAny<bool>()))
                .Returns(() => { return this.testKeys[this.keysCnt++]; });
            mockedConsole.Setup(r => r.ResetColor()).Verifiable();
            mockedConsole.Setup(r => r.SetCursorPosition(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            
            return mockedConsole.Object;
        }

        /// <summary>
        /// The test view display moves and time should not display in not real view.
        /// </summary>
        [TestMethod]
        public void TestViewDisplayMovesAndTimeShouldNotDisplayInNotRealView()
        {
            this.testStr = string.Empty;
            var view = new ConsoleView(false, this.ConsoleMock());
            view.DisplayTime(0);
            view.DisplayMoves(0);
            Assert.AreEqual(this.testStr == string.Empty, true, "No output!");
        }

        /// <summary>
        /// The test view display moves and time should display in real view.
        /// </summary>
        [TestMethod]
        public void TestViewDisplayMovesAndTimeShouldDisplayInRealView()
        {
            this.testStr = string.Empty;
            var view = new ConsoleView(true, this.ConsoleMock());
            view.DisplayTime(0);
            view.DisplayMoves(0);
            Assert.AreEqual(this.testStr != string.Empty, true, "No output!");
        }

        /// <summary>
        /// The test view players should display.
        /// </summary>
        [TestMethod]
        public void TestViewPlayersShouldDisplay()
        {
            this.testStr = string.Empty;
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, this.ConsoleMock());
            var board = new List<MinesweeperPlayer>
                            {
                                new MinesweeperPlayer
                                    {
                                        Name = "test", 
                                        Time = 0, 
                                        Type = MinesweeperDifficultyType.Easy
                                    }
                            };
            view.DisplayScoreBoard(board);
            Assert.AreEqual(this.testStr != string.Empty, true, "No output!");
        }

        /// <summary>
        /// The test grid should display.
        /// </summary>
        [TestMethod]
        public void TestGridShouldDisplay()
        {
            this.testStr = string.Empty;
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, this.ConsoleMock());

            var grid = MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            grid.BoomEvent += (sender, args) => { };
            grid.ProtectCell(0, 0);
            grid.RevealCell(1, 1);

            view.DisplayGrid(grid);

            i = 0;
            grid.RevealAllMines();
            view.DisplayGrid(grid);
            Assert.AreEqual(this.testStr != string.Empty, true, "No output!");
        }

        /// <summary>
        /// The test grid game over should display.
        /// </summary>
        [TestMethod]
        public void TestGridGameOverShouldDisplay()
        {
            this.testStr = string.Empty;
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            var view = new ConsoleView(true, this.ConsoleMock());
            view.AddPlayerEvent += (sender, args) => { };

            view.DisplayGameOver(true);
            Assert.AreEqual(this.testStr != string.Empty, true, "No output!");

            this.testStr = string.Empty;
            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.End, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            view = new ConsoleView(true, this.ConsoleMock());
            view.AddPlayerEvent += (sender, args) => { };

            view.DisplayGameOver(false);
            Assert.AreEqual(this.testStr != string.Empty, true, "No output!");
        }

        /// <summary>
        /// The test score list.
        /// </summary>
        [TestMethod]
        public void TestScoreList()
        {
            var view = new ConsoleView(true, this.ConsoleMock());
            view.ShowScoreBoardEvent += (sender, args) => { };
            view.RequestScoreList(MinesweeperDifficultyType.Easy);
        }
    }
}
