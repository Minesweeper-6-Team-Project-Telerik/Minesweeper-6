// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestControllerClass.cs" company="">
//   
// </copyright>
// <summary>
//   The test controller class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Test.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Controller;
    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    using Moq;

    /// <summary>
    /// The test controller class.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestControllerClass
    {
        /// <summary>
        /// The is grid displayed.
        /// </summary>
        private bool isGridDisplayed;

        /// <summary>
        /// The is score board displayed.
        /// </summary>
        private bool isScoreBoardDisplayed;

        /// <summary>
        /// The move displayed.
        /// </summary>
        private int moveDisplayed;

        /// <summary>
        /// The time displayed.
        /// </summary>
        private int timeDisplayed;

        /// <summary>
        /// The view mock.
        /// </summary>
        /// <returns>
        /// The <see cref="Mock"/>.
        /// </returns>
        private Mock<IMinesweeperView> ViewMock()
        {
            var mockedView = new Mock<IMinesweeperView>();
            mockedView.Setup(r => r.DisplayGameOver(It.IsAny<bool>())).Verifiable();
            mockedView.Setup(r => r.DisplayGrid(It.IsAny<IMinesweeperGrid>()))
                .Callback(() => this.isGridDisplayed = true);
            mockedView.Setup(r => r.DisplayMoves(It.IsAny<int>())).Callback<int>(r => { this.moveDisplayed = r; });
            mockedView.Setup(r => r.DisplayTime(It.IsAny<int>())).Callback<int>(r => { this.timeDisplayed = r; });
            mockedView.Setup(r => r.DisplayScoreBoard(It.IsAny<List<MinesweeperPlayer>>()))
                .Callback(() => this.isScoreBoardDisplayed = true);
            return mockedView;
        }

        /// <summary>
        /// The grid mock.
        /// </summary>
        /// <returns>
        /// The <see cref="Mock"/>.
        /// </returns>
        private Mock<IMinesweeperGrid> GridMock()
        {
            var mockedGrid = new Mock<IMinesweeperGrid>();
            mockedGrid.Setup(r => r.HasCellBomb(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            return mockedGrid;
        }

        /// <summary>
        /// The timer mock.
        /// </summary>
        /// <returns>
        /// The <see cref="Mock"/>.
        /// </returns>
        private Mock<IMinesweeperTimer> TimerMock()
        {
            var mockedTimer = new Mock<IMinesweeperTimer>();
            mockedTimer.Setup(r => r.Start()).Verifiable();
            mockedTimer.Setup(r => r.Stop()).Verifiable();
            return mockedTimer;
        }

        /// <summary>
        /// The test null grid should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestNullGridShouldThrow()
        {
            var controller = new MinesweeperGameController(
                null, 
                this.ViewMock().Object, 
                this.TimerMock().Object, 
                new List<MinesweeperPlayer>(), 
                MinesweeperDifficultyType.Easy);
        }

        /// <summary>
        /// The test null view should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestNullViewShouldThrow()
        {
            var controller = new MinesweeperGameController(
                this.GridMock().Object, 
                null, 
                this.TimerMock().Object, 
                new List<MinesweeperPlayer>(), 
                MinesweeperDifficultyType.Easy);
        }

        /// <summary>
        /// The test null timer should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestNullTimerShouldThrow()
        {
            var controller = new MinesweeperGameController(
                this.GridMock().Object, 
                this.ViewMock().Object, 
                null, 
                new List<MinesweeperPlayer>(), 
                MinesweeperDifficultyType.Easy);
        }

        /// <summary>
        /// The test null players should throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not thrown!")]
        public void TestNullPlayersShouldThrow()
        {
            var controller = new MinesweeperGameController(
                this.GridMock().Object, 
                this.ViewMock().Object, 
                this.TimerMock().Object, 
                null, 
                MinesweeperDifficultyType.Easy);
        }

        /// <summary>
        /// The test controller display score board should execute correctly.
        /// </summary>
        [TestMethod]
        public void TestControllerDisplayScoreBoardShouldExecuteCorrectly()
        {
            var grid = this.GridMock();
            var view = this.ViewMock();
            var timer = this.TimerMock();
            var controller = new MinesweeperGameController(
                grid.Object, 
                view.Object, 
                timer.Object, 
                new List<MinesweeperPlayer>(), 
                MinesweeperDifficultyType.Easy);

            this.isScoreBoardDisplayed = false;
            view.Raise(e => e.ShowScoreBoardEvent += null, EventArgs.Empty);

            Assert.AreEqual(this.isScoreBoardDisplayed, true, "Score board is not displayed!");
        }

        /// <summary>
        /// The test controller add player should execute correctly.
        /// </summary>
        [TestMethod]
        public void TestControllerAddPlayerShouldExecuteCorrectly()
        {
            var grid = this.GridMock();
            var view = this.ViewMock();
            var timer = this.TimerMock();
            var players = new List<MinesweeperPlayer>();
            var controller = new MinesweeperGameController(
                grid.Object, 
                view.Object, 
                timer.Object, 
                players, 
                MinesweeperDifficultyType.Easy);
            var args = new MinesweeperAddPlayerEventArgs { PlayerName = "test" };

            this.isScoreBoardDisplayed = false;
            view.Raise(e => e.AddPlayerEvent += null, args);

            Assert.AreEqual(players[0].Name, "test", "Player not added!");
        }

        /// <summary>
        /// The test controller on open cell event should display grid.
        /// </summary>
        [TestMethod]
        public void TestControllerOnOpenCellEventShouldDisplayGrid()
        {
            var grid = this.GridMock();
            var view = this.ViewMock();
            var timer = this.TimerMock();
            var players = new List<MinesweeperPlayer>();
            var controller = new MinesweeperGameController(
                grid.Object, 
                view.Object, 
                timer.Object, 
                players, 
                MinesweeperDifficultyType.Easy);
            var args = new MinesweeperCellClickEventArgs { Row = 1, Col = 1 };
            this.isGridDisplayed = false;

            this.isScoreBoardDisplayed = false;
            view.Raise(e => e.OpenCellEvent += null, args);
            view.Raise(e => e.ProtectCellEvent += null, args);

            Assert.AreEqual(this.isGridDisplayed, true, "Grid not displayed!");
        }

        /// <summary>
        /// The test controller on boom event should display grid.
        /// </summary>
        [TestMethod]
        public void TestControllerOnBoomEventShouldDisplayGrid()
        {
            var grid = this.GridMock();
            var view = this.ViewMock();
            var timer = this.TimerMock();
            var players = new List<MinesweeperPlayer>();
            var controller = new MinesweeperGameController(
                grid.Object, 
                view.Object, 
                timer.Object, 
                players, 
                MinesweeperDifficultyType.Easy);
            var args = new MinesweeperCellClickEventArgs { Row = 1, Col = 1 };
            this.isGridDisplayed = false;

            this.isScoreBoardDisplayed = false;
            view.Raise(e => e.OpenCellEvent += null, args);
            view.Raise(e => e.ProtectCellEvent += null, args);
            grid.Raise(e => e.BoomEvent += null, EventArgs.Empty);

            Assert.AreEqual(this.isGridDisplayed, true, "Grid not displayed!");
        }

        /// <summary>
        /// The test controller on tick event should display grid.
        /// </summary>
        [TestMethod]
        public void TestControllerOnTickEventShouldDisplayGrid()
        {
            var grid = this.GridMock();
            var view = this.ViewMock();
            var timer = this.TimerMock();
            var players = new List<MinesweeperPlayer>();
            var controller = new MinesweeperGameController(
                grid.Object, 
                view.Object, 
                timer.Object, 
                players, 
                MinesweeperDifficultyType.Easy);
            var args = new MinesweeperCellClickEventArgs { Row = 1, Col = 1 };
            this.isGridDisplayed = false;

            this.isScoreBoardDisplayed = false;
            view.Raise(e => e.OpenCellEvent += null, args);
            view.Raise(e => e.ProtectCellEvent += null, args);
            timer.Raise(e => e.TickEvent += null, EventArgs.Empty);

            Assert.AreEqual(this.isGridDisplayed, true, "Grid not displayed!");
        }
    }
}