// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGrid.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper Grid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel
{
    using System;
    using System.Linq;

    using MineSweeper.GameModel.Exceptions;
    using MineSweeper.GameModel.Interfaces;

    /// <summary>
    /// The minesweeper Grid.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    internal class MinesweeperGrid<T> : IMinesweeperGrid<T>
    {
        /// <summary>
        ///     The mines count.
        /// </summary>
        private readonly int minesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGrid{T}"/> class.
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
            this.Grid = new MinesweeperCell<T>[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    this.Grid[i, j] = new MinesweeperCell<T>();
                }
            }
        }

        /// <summary>
        ///     Gets the cols.
        /// </summary>
        protected int Cols { get; private set; }

        /// <summary>
        ///     Gets the rows.
        /// </summary>
        protected int Rows { get; private set; }

        /// <summary>
        ///     The Grid.
        /// </summary>
        protected MinesweeperCell<T>[,] Grid { get; private set; }

        /// <summary>
        ///     The reset.
        /// </summary>
        public void Reset()
        {
            this.ResetCells();
            this.PutRandomBombs();
        }

        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="InvalidCellException">
        /// </exception>
        public virtual T RevealCell(int row, int column)
        {
            if ((!this.IsValidCell(row, column)) || this.Grid[row, column].IsRevealed)
            {
                throw new InvalidCellException();
            }

            this.Grid[row, column].Reveal();
            return this.Grid[row, column].Value;
        }

        /// <summary>
        /// The get cell value.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="InvalidCellException">
        /// </exception>
        public T GetCellValue(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            return this.Grid[row, column].Value;
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
        public bool IsValidCell(int row, int column)
        {
            return (row >= 0 && row < this.Rows) && (column >= 0 && column < this.Cols);
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
        /// <exception cref="InvalidCellException">
        /// </exception>
        public int NeighbourMinesCount(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
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
        ///     The revealed count.
        /// </summary>
        /// <returns>
        ///     The <see cref="int" />.
        /// </returns>
        public int RevealedCount()
        {
            var count = 0;
            foreach (var elem in this.Grid)
            {
                if (elem.IsRevealed)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        ///     The reveal mines.
        /// </summary>
        public void RevealMines()
        {
            foreach (var elem in this.Grid)
            {
                if (elem.HasBomb)
                {
                    elem.Reveal();
                }
            }
        }

        /// <summary>
        /// The set cell value.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="InvalidCellException">
        /// </exception>
        protected void SetCellValue(int row, int column, T value)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            this.Grid[row, column].Value = value;
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

                this.Grid[row, column].PutBomb();
            }
        }

        /// <summary>
        ///     The reset cells.
        /// </summary>
        private void ResetCells()
        {
            foreach (var elem in this.Grid)
            {
                elem.Reset();
            }
        }
    }
}