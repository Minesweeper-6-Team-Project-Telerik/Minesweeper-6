// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMenus.cs" company="">
//   
// </copyright>
// <summary>
//   The test menus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Test
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;
    using ConsoleMinesweeper.View;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    using Moq;

    /// <summary>
    /// The test menus.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestMenus
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
        /// The view mock.
        /// </summary>
        /// <returns>
        /// The <see cref="IConsoleView"/>.
        /// </returns>
        private IConsoleView ViewMock()
        {
            var mockedView = new Mock<IConsoleView>();
            mockedView.Setup(r => r.DisplayGameOver(It.IsAny<bool>())).Verifiable();
            mockedView.Setup(r => r.DisplayGrid(It.IsAny<IMinesweeperGrid>())).Verifiable();
            mockedView.Setup(r => r.DisplayMoves(It.IsAny<int>())).Verifiable();
            mockedView.Setup(r => r.DisplayTime(It.IsAny<int>())).Verifiable();
            mockedView.Setup(r => r.DisplayScoreBoard(It.IsAny<List<MinesweeperPlayer>>())).Verifiable();
            return mockedView.Object;
        }

        /// <summary>
        /// The test start menus should display.
        /// </summary>
        [TestMethod]
        public void TestStartMenusShouldDisplay()
        {
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.UpArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartGameMenu(
                this.ConsoleMock(), 
                new ConsoleView(false, this.ConsoleMock()), 
                new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");
            this.testStr = string.Empty;
            ConsoleMenus.StartMainMenu(this.ConsoleMock());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");
            this.testStr = string.Empty;
        }

        /// <summary>
        /// The test game start menu items should display.
        /// </summary>
        [TestMethod]
        public void TestGameStartMenuItemsShouldDisplay()
        {
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartGameMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");
        }

        /// <summary>
        /// The test score start menu items should display.
        /// </summary>
        [TestMethod]
        public void TestScoreStartMenuItemsShouldDisplay()
        {
            var i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");

            i = 0;
            this.keysCnt = 0;
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.DownArrow, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);
            this.testKeys[i++] = new ConsoleKeyInfo(' ', ConsoleKey.E, false, false, false);

            this.testStr = string.Empty;
            ConsoleMenus.StartScoresMenu(this.ConsoleMock(), this.ViewMock(), new ConsoleTimer());
            Assert.AreEqual(this.testStr != string.Empty, true, "No output for menu!");
        }
    }
}