// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleView.cs" company="">
//   
// </copyright>
// <summary>
//   The console view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.View
{
    using System;
    using System.Text;

    using ConsoleMinesweeper.Models;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    /// <summary>
    ///     The console view.
    /// </summary>
    internal class ConsoleView : IMinesweeperView
    {
        /// <summary>
        ///     The grid box.
        /// </summary>
        private ConsoleBox<ConsoleColor> gridBox;

        /// <summary>
        ///     The score box.
        /// </summary>
        private ConsoleBox<ConsoleColor> scoreBox;

        /// <summary>
        ///     The time.
        /// </summary>
        private int time;

        /// <summary>
        ///     The time box.
        /// </summary>
        private ConsoleBox<ConsoleColor> timeBox;

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
            if (this.scoreBox == null)
            {
                this.scoreBox = new ConsoleBox<ConsoleColor>(
                    35, 
                    2, 
                    10, 
                    2, 
                    ConsoleColor.Cyan, 
                    ConsoleColor.DarkRed, 
                    moves.ToString());
            }

            this.scoreBox.Text = "Moves: " + moves;
            ConsolePrinter.Print(new ConsoleWrapper(), this.scoreBox);

            if (this.timeBox == null)
            {
                this.timeBox = new ConsoleBox<ConsoleColor>(
                    35, 
                    10, 
                    10, 
                    2, 
                    ConsoleColor.Cyan, 
                    ConsoleColor.DarkRed, 
                    this.time.ToString());
            }

            this.timeBox.Text = "Time: " + this.time;
            ConsolePrinter.Print(new ConsoleWrapper(), this.timeBox);
        }

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DisplayScoreBoard(IMinesweeperPlayerBoard board)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The grid.
        /// </param>
        public void DisplayGrid(IMinesweeperGrid grid)
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
                        else if (grid.NeighbourMinesCount(i, j) == 0)
                        {
                            sb.Append(" ");
                        }
                        else
                        {
                            sb.Append(grid.NeighbourMinesCount(i, j).ToString());
                        }
                    }
                    else if (grid.IsCellProtected(i, j))
                    {
                        sb.Append("F");
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
                    2, 
                    2, 
                    grid.Rows + 1, 
                    grid.Cols + 1, 
                    ConsoleColor.Cyan, 
                    ConsoleColor.DarkRed, 
                    sb.ToString());
                Console.Clear();
                ConsolePrinter.PrintGrid(new ConsoleWrapper(), this.gridBox, this.OpenCellEvent, this.ProtectCellEvent);                
            }

            this.gridBox.Text = sb.ToString();
            ConsolePrinter.Print(new ConsoleWrapper(), this.gridBox);
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

                ConsolePrinter.Print(new ConsoleWrapper(), gameOverBox);
                Console.ReadKey(true);
                ConsoleMenus.StartMainMenu();
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

                ConsolePrinter.Print(new ConsoleWrapper(), gameOverBox);
                var name = Console.ReadLine();

                var args = new MinesweeperAddPlayerEventArgs { PlayerName = name };

                this.AddPlayerEvent.Invoke(this, args);

                ConsoleMenus.StartMainMenu();
            }
        }
    }
}