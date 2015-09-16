// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGameController.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper game controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Controller
{
    using System;
    using System.Windows.Threading;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    /// <summary>
    ///     The minesweeper game controller.
    /// </summary>
    public class MinesweeperGameController
    {
        /// <summary>
        ///     The t.
        /// </summary>
        private readonly DispatcherTimer timer;

        /// <summary>
        ///     The game view.
        /// </summary>
        protected IMinesweeperView gameView;

        /// <summary>
        ///     The grid.
        /// </summary>
        protected IMinesweeperGrid grid;

        /// <summary>
        ///     The player board.
        /// </summary>
        protected IPlayerBoard playerBoard;

        /// <summary>
        ///     The score.
        /// </summary>
        private int score;

        /// <summary>
        ///     The seconds passed.
        /// </summary>
        private int secondsPassed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGameController"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="gameView">
        /// The game view.
        /// </param>
        public MinesweeperGameController(DifficultyType type, IMinesweeperView gameView)
        {
            this.grid = MinesweeperGridFactory.CreateNewTable(type);
            this.gameView = gameView;
            this.gameView.OpenCellEvent += this.GameViewOnOpenCellEvent;
            this.gameView.ProtectCellEvent += this.GameViewOnProtectCellEvent;
            this.grid.BoomEvent += this.GridOnBoomEvent;
            this.score = 0;
            this.secondsPassed = 0;
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += this.clockTimeTick;
            this.timer.Start();
        }

        /// <summary>
        /// The clock time tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void clockTimeTick(object sender, EventArgs e)
        {
            this.secondsPassed++;
            this.gameView.DisplayTime(this.secondsPassed);
        }

        /// <summary>
        /// The game view on protect cell event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GameViewOnProtectCellEvent(object sender, EventArgs eventArgs)
        {
            var args = (MinesweeperCellClickEventArgs)eventArgs;
            this.grid.TriggerCellProtection(args.Row, args.Col);
            this.gameView.DisplayGrid(this.grid);
            this.gameView.DisplayMoves(this.score);
        }

        /// <summary>
        /// The grid on boom event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GridOnBoomEvent(object sender, EventArgs eventArgs)
        {
            this.timer.Stop();
            this.grid.RevealAllMines();
            this.gameView.DisplayGameOver();            
            this.gameView.DisplayGrid(this.grid);
        }

        /// <summary>
        /// The game view on open cell event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GameViewOnOpenCellEvent(object sender, EventArgs eventArgs)
        {
            var args = (MinesweeperCellClickEventArgs)eventArgs;
            this.grid.RevealCell(args.Row, args.Col);

            this.score++;
            this.gameView.DisplayGrid(this.grid);
            this.gameView.DisplayMoves(this.score);
        }

        /// <summary>
        ///     The start game.
        /// </summary>
        public void StartGame()
        {
            this.gameView.DisplayGrid(this.grid);
        }

    }
}