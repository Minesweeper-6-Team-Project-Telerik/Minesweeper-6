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
    using System.Collections.Generic;

    using Minesweeper.Models;
    using Minesweeper.Models.Exceptions;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    /// <summary>
    ///     The minesweeper game controller.
    /// </summary>
    public class MinesweeperGameController
    {
        /// <summary>
        ///     The players filename.
        /// </summary>
        public const string PlayersFilename = "scores.data";

        /// <summary>
        ///     The game view.
        /// </summary>
        private readonly IMinesweeperView gameView;

        /// <summary>
        ///     The grid.
        /// </summary>
        private readonly IMinesweeperGrid grid;

        /// <summary>
        /// The minesweeper timer.
        /// </summary>
        private readonly IMinesweeperTimer minesweeperTimer;

        private readonly List<MinesweeperPlayer> players;

        /// <summary>
        /// The type.
        /// </summary>
        private readonly MinesweeperDifficultyType type;

        /// <summary>
        /// The is game started.
        /// </summary>
        private bool isGameStarted;

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
        /// <param name="timer">
        /// The timer.
        /// </param>
        public MinesweeperGameController(
            IMinesweeperGrid gameGrid, 
            IMinesweeperView gameView, 
            IMinesweeperTimer timer,
            List<MinesweeperPlayer> players,
            MinesweeperDifficultyType type)
        {
            if (gameGrid == null)
            {
                throw new ArgumentNullException("gameGrid");
            }

            if (gameView == null)
            {
                throw new ArgumentNullException("gameView");
            }

            if (timer == null)
            {
                throw new ArgumentNullException("timer");
            }

            if (players == null)
            {
                throw new ArgumentNullException("players");
            }

            // Initialize objects
            this.grid = gameGrid;            
            this.gameView = gameView;
            this.minesweeperTimer = timer;
            this.players = players;
            this.type = type;

            // Handle all view callbacks            
            this.gameView.OpenCellEvent += this.GameViewOnOpenCellEvent;
            this.gameView.ProtectCellEvent += this.GameViewOnProtectCellEvent;
            this.gameView.AddPlayerEvent += this.GameViewOnAddPlayerEvent;
            this.gameView.ShowScoreBoardEvent += this.GameViewOnShowScoreBoardEvent;

            // Handle all grid callbacks
            this.grid.BoomEvent += this.GridOnBoomEvent;
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
            var player = new MinesweeperPlayer { Name = args.PlayerName, Time = this.secondsPassed, Type = this.type };

           this.players.Add(player);
           MinesweeperGameData.Save(this.players, PlayersFilename);            
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
            this.minesweeperTimer.Stop();
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
            // Fix game over event. Score incrementation.
            if (!this.isGameStarted)
            {
                this.StartGame();
                this.isGameStarted = true;
            }

            var args = (MinesweeperCellClickEventArgs)eventArgs;

            if (!this.grid.IsCellProtected(args.Row, args.Col))
            {
                if (!this.grid.IsCellRevealed(args.Row, args.Col))
                {
                    this.grid.RevealCell(args.Row, args.Col);

                    this.score++;
                    this.gameView.DisplayGrid(this.grid);
                    this.gameView.DisplayMoves(this.score);

                    if (this.grid.RevealedCellsCount >= (this.grid.Cols * this.grid.Rows) - this.grid.MinesCount)
                    {
                        this.minesweeperTimer.Stop();
                        this.gameView.DisplayGameOver(true);
                    }
                }
            }
        }

        /// <summary>
        /// The start game.
        /// </summary>
        private void StartGame()
        {
            // Configure timer
            this.minesweeperTimer.TickEvent += this.ClockTimeTick;
            this.minesweeperTimer.Start();

            // Other local data
            this.score = 0;
            this.secondsPassed = 0;

            // Display grid
            this.gameView.DisplayGrid(this.grid);
        }
    }
}