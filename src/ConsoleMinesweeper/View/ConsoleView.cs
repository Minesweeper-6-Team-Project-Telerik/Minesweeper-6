// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The console view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The console view.
    /// </summary>
    public class ConsoleView : IConsoleView
    {
        /// <summary>
        ///     The console wrapper view.
        /// </summary>
        private readonly IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> consoleWrpView;

        /// <summary>
        ///     The is real view.
        /// </summary>
        private readonly bool isRealView;

        /// <summary>
        ///     The grid box.
        /// </summary>
        private ConsoleBox<ConsoleColor> gridBox;

        /// <summary>
        ///     The score box.
        /// </summary>
        private ConsoleBox<ConsoleColor> scoreBox;

        /// <summary>
        ///     The game time.
        /// </summary>
        private int time;

        /// <summary>
        ///     The time box.
        /// </summary>
        private ConsoleBox<ConsoleColor> timeBox;

        /// <summary>
        ///     The game difficulty type.
        /// </summary>
        private MinesweeperDifficultyType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleView"/> class.
        /// </summary>
        /// <param name="real">
        /// The real view.
        /// </param>
        /// <param name="consoleWrpView">
        /// The console Wrapper View.
        /// </param>
        public ConsoleView(bool real, IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> consoleWrpView)
        {
            this.isRealView = real;
            this.consoleWrpView = consoleWrpView;
        }

        /// <summary>
        ///     The open cell event.
        /// </summary>
        public event EventHandler OpenCellEvent;

        /// <summary>
        ///     The protect cell event.
        /// </summary>
        public event EventHandler ProtectCellEvent;

        /// <summary>
        ///     The show score board event.
        /// </summary>
        public event EventHandler ShowScoreBoardEvent;

        /// <summary>
        ///     The add player event.
        /// </summary>
        public event EventHandler AddPlayerEvent;

        /// <summary>
        /// The display time.
        /// </summary>
        /// <param name="timer">
        /// The timer.
        /// </param>
        public void DisplayTime(int timer)
        {
            this.time = timer;
        }

        /// <summary>
        /// The display moves.
        /// </summary>
        /// <param name="moves">
        /// The moves.
        /// </param>
        public void DisplayMoves(int moves)
        {
            if (this.isRealView)
            {
                if (this.scoreBox == null)
                {
                    this.scoreBox = new ConsoleBox<ConsoleColor>(
                        35, 
                        10, 
                        10, 
                        2, 
                        ConsoleColor.Cyan, 
                        ConsoleColor.DarkRed, 
                        moves.ToString());
                }

                this.scoreBox.Text = "Moves: " + moves;
                ConsolePrinter.Print(this.consoleWrpView, this.scoreBox);

                if (this.timeBox == null)
                {
                    this.timeBox = new ConsoleBox<ConsoleColor>(
                        35, 
                        15, 
                        10, 
                        2, 
                        ConsoleColor.Cyan, 
                        ConsoleColor.DarkRed, 
                        this.time.ToString());
                }

                this.timeBox.Text = "Time: " + this.time;
                ConsolePrinter.Print(this.consoleWrpView, this.timeBox);
            }
        }

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="board">
        /// The score board.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// The Exception.
        /// </exception>
        public void DisplayScoreBoard(List<MinesweeperPlayer> board)
        {
            var list = board.Where(x => x.Type == this.type).OrderBy(x => x.Time);
            var players = new StringBuilder();

            players.Append(" Name                                           | Score    ");
            players.Append("-----------------------------------------------------------");
            foreach (var l in list)
            {
                players.Append(" " + l.Name.PadRight(47, ' ') + "| " + l.Time.ToString().PadRight(9, ' '));
            }

            var scoreBoxList = new ConsoleBox<ConsoleColor>(
                10, 
                10, 
                60, 
                40, 
                ConsoleColor.Cyan, 
                ConsoleColor.DarkRed, 
                players.ToString());

            ConsolePrinter.Print(this.consoleWrpView, scoreBoxList);
            this.consoleWrpView.ReadKey(true);
            ConsoleMenus.StartMainMenu(this.consoleWrpView);
        }

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The game grid.
        /// </param>
        public void DisplayGrid(IMinesweeperGrid grid)
        {
            if (this.isRealView)
            {
                var sb = new StringBuilder();

                for (var i = 0; i < grid.Rows; i++)
                {
                    for (var j = 0; j < grid.Cols; j++)
                    {
                        if (grid.IsCellRevealed(i, j))
                        {
                            if (grid.HasCellBomb(i, j))
                            {
                                sb.Append("*");
                            }
                            else if (grid.NeighborMinesCount(i, j) == 0)
                            {
                                sb.Append(" ");
                            }
                            else
                            {
                                sb.Append(grid.NeighborMinesCount(i, j).ToString());
                            }
                        }
                        else if (grid.IsCellProtected(i, j))
                        {
                            sb.Append("~");
                        }
                        else
                        {
                            sb.Append('▒');
                        }
                    }
                }

                if (this.gridBox == null)
                {
                    this.gridBox = new ConsoleBox<ConsoleColor>(
                        10, 
                        10, 
                        grid.Rows + 1, 
                        grid.Cols + 1, 
                        ConsoleColor.Cyan, 
                        ConsoleColor.DarkRed, 
                        sb.ToString());
                    this.consoleWrpView.Clear();
                    ConsolePrinter.PrintGrid(
                        this.consoleWrpView, 
                        this.gridBox, 
                        this.OpenCellEvent, 
                        this.ProtectCellEvent);
                }

                this.gridBox.Text = sb.ToString();
                ConsolePrinter.Print(this.consoleWrpView, this.gridBox);
            }
        }

        /// <summary>
        /// The display game over.
        /// </summary>
        /// <param name="gameResult">
        /// The game result.
        /// </param>
        public void DisplayGameOver(bool gameResult)
        {
            if (gameResult == false)
            {
                var gameOverBox = new ConsoleBox<ConsoleColor>(
                    25, 
                    10, 
                    14, 
                    5, 
                    ConsoleColor.Red, 
                    ConsoleColor.Black, 
                    "Game Over!");

                ConsolePrinter.Print(this.consoleWrpView, gameOverBox);
                this.consoleWrpView.ReadKey(true);
                ConsoleMenus.StartMainMenu(this.consoleWrpView);
            }
            else
            {
                var gameOverBox = new ConsoleBox<ConsoleColor>(
                    15, 
                    10, 
                    30, 
                    5, 
                    ConsoleColor.Green, 
                    ConsoleColor.Black, 
                    "Enter your name: ");

                ConsolePrinter.Print(this.consoleWrpView, gameOverBox);
                var name = this.consoleWrpView.ReadLine();

                var args = new MinesweeperAddPlayerEventArgs { PlayerName = name };

                this.AddPlayerEvent.Invoke(this, args);

                ConsoleMenus.StartMainMenu(this.consoleWrpView);
            }
        }

        /// <summary>
        /// The request score list.
        /// </summary>
        /// <param name="type">
        /// The game difficulty type.
        /// </param>
        public void RequestScoreList(MinesweeperDifficultyType type)
        {
            this.type = type;

            if (this.ShowScoreBoardEvent != null)
            {
                this.ShowScoreBoardEvent.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
