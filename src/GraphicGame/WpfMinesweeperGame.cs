// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfMinesweeperGame.cs" company="">
//   
// </copyright>
// <summary>
//   The wpf minesweeper game.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GraphicGame
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    using MineSweeper.GameModel.Interfaces;

    /// <summary>
    ///     The wpf minesweeper game.
    /// </summary>
    internal class WpfMinesweeperGame : IMinesweeperGame<WpfMinesweeperButton>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WpfMinesweeperGame"/> class.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public WpfMinesweeperGame(int rows, int columns, int minesCount)
        {
            this.Grid = new WpfMinesweeperGrid(rows, columns, minesCount);
            this.ScoreBoard = new List<IScoreRecord>();
        }

        /// <summary>
        /// Gets the grid.
        /// </summary>
        public WpfMinesweeperGrid Grid { get; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Gets or sets the score board.
        /// </summary>
        public List<IScoreRecord> ScoreBoard { get; set; }

        /// <summary>
        /// The start.
        /// </summary>
        public void Start()
        {
            var qWindow = new Window();

            qWindow.Title = "WPF in Console";
            qWindow.Width = this.Grid.WpfGrid.Width + 50;
            qWindow.Height = this.Grid.WpfGrid.Height + 100;

            qWindow.Content = this.Grid.WpfGrid;
            qWindow.ShowDialog();
        }
    }
}