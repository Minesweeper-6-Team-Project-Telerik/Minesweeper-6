// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGrid.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper grid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using System;
    using System.Linq;

    using Minesweeper.Models.Exceptions;
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The minesweeper grid.
    /// </summary>
    public class MinesweeperGrid : IMinesweeperGrid
    {
        /// <summary>
        ///     The mines count.
        /// </summary>
        private readonly int minesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGrid"/> class.
        /// </summary>
        /// <param name="rows">
        /// The Rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public MinesweeperGrid(int rows, int columns, int minesCount)
        {
            this.Rows = rows;
            this.Cols = columns;
            this.minesCount = minesCount;
            this.Grid = new IMinesweeperCell[rows, columns];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    this.Grid[i, j] = new MinesweeperCell();
                }
            }

            this.PutRandomBombs();
        }

        /// <summary>
        ///     Gets the grid.
        /// </summary>
        private IMinesweeperCell[,] Grid { get; set; }

        /// <summary>
        ///     The Cols.
        /// </summary>
        public int Cols { get; private set; }

        /// <summary>
        ///     The Rows.
        /// </summary>
        public int Rows { get; private set; }

        
        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        public void RevealCell(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            if (this.Grid[row, column].HasBomb)
            {
                var handler = this.BoomEvent;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }

            this.Grid[row, column].IsRevealed = true;
        }

        /// <summary>
        /// The protect cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        public void ProtectCell(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            this.Grid[row, column].IsProtected = true;
        }

        /// <summary>
        /// The neighbour mines count.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// </exception>
        public int NeighbourMinesCount(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            // restrict neigbour cell area
            var minRow = (row - 1) < 0 ? row : row - 1;
            var maxRow = (row + 1) >= this.Rows ? row : row + 1;
            var minColumn = (column - 1) < 0 ? column : column - 1;
            var maxColumn = (column + 1) >= this.Cols ? column : column + 1;

            var count = 0;
            for (var i = minRow; i <= maxRow; i++)
            {
                for (var j = minColumn; j <= maxColumn; j++)
                {
                    if (this.Grid[i, j].HasBomb)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /// <summary>
        ///     The reveal all mines.
        /// </summary>
        public void RevealAllMines()
        {
            foreach (var elem in this.Grid)
            {
                if (!elem.IsRevealed)
                {
                    elem.IsRevealed = true;
                }
            }
        }

        /// <summary>
        ///     The boom event.
        /// </summary>
        public event EventHandler BoomEvent;

        /// <summary>
        /// The is cell revealed.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsCellRevealed(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.Grid[row, column].IsRevealed;
        }

        /// <summary>
        /// The is cell protected.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public bool IsCellProtected(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.Grid[row, column].IsProtected;
        }

        /// <summary>
        /// The has cell bomb.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// </exception>
        public bool HasCellBomb(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.Grid[row, column].HasBomb;
        }

        /// <summary>
        /// The trigger cell protection.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void TriggerCellProtection(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            this.Grid[row, column].IsProtected = !this.Grid[row, column].IsProtected;
        }

        /// <summary>
        /// The is valid cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValidCell(int row, int column)
        {
            return (row >= 0 && row < this.Rows) && (column >= 0 && column < this.Cols);
        }

        /// <summary>
        ///     The put random bombs.
        /// </summary>
        private void PutRandomBombs()
        {
            var mineCoordinates = new int[this.minesCount]; // creates array of coordinates of mines row*x+column
            var currentMinesCount = 0;
            var randomGenerator = new Random();

            do
            {
                // generates random coordinates
                var gridCellsCount = this.Rows * this.Cols; // max random number
                int randomNumber;

                do
                {
                    randomNumber = randomGenerator.Next(gridCellsCount);
                }
                while (mineCoordinates.Count(n => n == randomNumber) > 0); // check if exist

                mineCoordinates[currentMinesCount] = randomNumber;
                currentMinesCount++;
            }
            while (currentMinesCount < this.minesCount);

            for (var i = 0; i < this.minesCount; i++)
            {
                // fill mines
                var row = mineCoordinates[i] % this.Rows;
                var column = mineCoordinates[i] / this.Cols;

                this.Grid[row, column].HasBomb = true;
            }
        }
    }
}