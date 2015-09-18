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
        /// The players filename.
        /// </summary>
        private const string PlayersFilename = "scores.data";

        /// <summary>
        ///     The game view.
        /// </summary>
        private readonly IMinesweeperView gameView;

        /// <summary>
        ///     The grid.
        /// </summary>
        private readonly IMinesweeperGrid grid;

        /// <summary>
        ///     The player board.
        /// </summary>
        private readonly IMinesweeperPlayerBoard players;

        /// <summary>
        ///     The t.
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        ///     The score.
        /// </summary>
        private int score;

        /// <summary>
        ///     The seconds passed.
        /// </summary>
        private int secondsPassed;

        private bool isGameStarted;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGameController"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="gameView">
        /// The game view.
        /// </param>
        public MinesweeperGameController(MinesweeperDifficultyType type, IMinesweeperView gameView)
        {
            if (gameView == null)
            {
                throw new ArgumentNullException("gameView");
            }

            // Create grid object
            this.grid = MinesweeperGridFactory.CreateNewTable(type);

            this.gameView = gameView;
            
            // Handle all view callbacks            
            this.gameView.OpenCellEvent += this.GameViewOnOpenCellEvent;
            this.gameView.ProtectCellEvent += this.GameViewOnProtectCellEvent;
            this.gameView.AddPlayerEvent += this.GameViewOnAddPlayerEvent;
            this.gameView.ShowScoreBoardEvent += this.GameViewOnShowScoreBoardEvent;

            // Handle all grid callbacks
            this.grid.BoomEvent += this.GridOnBoomEvent;

            // Get the players
            this.players = new MinesweeperPlayerBoard(PlayersFilename);

            this.gameView.DisplayGrid(this.grid);
            this.isGameStarted = false;
        }

        /// <summary>
        /// The game view on show score board event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GameViewOnShowScoreBoardEvent(object sender, EventArgs eventArgs)
        {
            this.gameView.DisplayScoreBoard(this.players);
        }

        /// <summary>
        /// The game view on add player event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GameViewOnAddPlayerEvent(object sender, EventArgs eventArgs)
        {
            var args = (MinesweeperAddPlayerEventArgs)eventArgs;
            this.players.AddPlayer(args.Player);
            this.players.Save();
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
        private void ClockTimeTick(object sender, EventArgs e)
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
            this.gameView.DisplayGameOver(false);
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
            if (!this.isGameStarted)
            {
                this.StartGame();
                this.isGameStarted = true;
            }
            
            var args = (MinesweeperCellClickEventArgs)eventArgs;

            if (!this.grid.IsCellProtected(args.Row, args.Col))
            {
                this.grid.RevealCell(args.Row, args.Col);

                this.score++;
                this.gameView.DisplayGrid(this.grid);
                this.gameView.DisplayMoves(this.score);

                if (this.score >= (this.grid.Cols * this.grid.Rows) - this.grid.MinesCount)
                {
                    this.timer.Stop();
                    this.gameView.DisplayGameOver(true);
                }
            }            
        }

        private void StartGame()
        {
            // Configure timer
            this.timer = new DispatcherTimer();
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += this.ClockTimeTick;

            this.timer.Start();

            // Other local data
            this.score = 0;
            this.secondsPassed = 0;

            // Display grid
            this.gameView.DisplayGrid(this.grid);            
        }
    }
}