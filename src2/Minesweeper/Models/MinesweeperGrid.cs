// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGrid.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
        ///     Gets the grid.
        /// </summary>
        private readonly MinesweeperCell[,] grid;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGrid"/> class.
        /// </summary>
        /// <param name="rows">
        /// The number of grid rows.
        /// </param>
        /// <param name="columns">
        /// The number of grid columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public MinesweeperGrid(int rows, int columns, int minesCount)
        {
            if (rows <= 0 || columns <= 0 || minesCount <= 0)
            {
                throw new ArgumentException("Array dimentions and bom count should be positive value!");
            }

            this.Rows = rows;
            this.Cols = columns;
            this.MinesCount = minesCount;
            this.grid = new MinesweeperCell[rows, columns];

            MinesweeperGridIterator.IterateGrid(this.Rows, this.Cols, this.PopulateGrid);

            this.PutRandomBombs();
        }

        /// <summary>
        ///     The boom event.
        /// </summary>
        public event EventHandler BoomEvent;

        /// <summary>
        ///     Gets the mines count.
        /// </summary>
        /// <value>The mines count.</value>
        public int MinesCount { get; private set; }

        /// <summary>
        ///     Gets the Cols.
        /// </summary>
        /// <value>The number of columns.</value>
        public int Cols { get; private set; }

        /// <summary>
        ///     Gets the Rows.
        /// </summary>
        /// <value>The number of rows.</value>
        public int Rows { get; private set; }

        /// <summary>
        /// Gets the revealed cells count.
        /// </summary>
        /// <value>The revealed cells count.</value>
        public int RevealedCellsCount { get; private set; }

        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The cell to reveal row.
        /// </param>
        /// <param name="column">
        /// The cell to reveal column.
        /// </param>
        public void RevealCell(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            if (this.grid[row, column].HasBomb)
            {
                var handler = this.BoomEvent;

                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }

            this.grid[row, column].IsRevealed = true;
            this.RevealedCellsCount++;
            this.RevealAllNeighborsWithZeroMines();
        }

        /// <summary>
        /// The protect cell.
        /// </summary>
        /// <param name="row">
        /// The cell to protect row.
        /// </param>
        /// <param name="column">
        /// The cell to protect column.
        /// </param>
        public void ProtectCell(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            this.grid[row, column].IsProtected = true;
        }

        /// <summary>
        /// The neighbor mines count.
        /// </summary>
        /// <param name="row">
        /// The entered cell row.
        /// </param>
        /// <param name="column">
        /// The entered cell column.
        /// </param>
        /// <returns>
        /// The neighbor mines count <see cref="int"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// The InvalidGridOperation Exception.
        /// </exception>
        public int NeighborMinesCount(int row, int column)
        {           
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            this.grid[row, column].NeighboringMinesCount = 0;

            MinesweeperGridIterator.IterateNeighbours(row, column, this.Rows, this.Cols, this.IncrementMinesCount);

            return this.grid[row, column].NeighboringMinesCount;
        }

        /// <summary>
        ///     The reveal all mines.
        /// </summary>
        public void RevealAllMines()
        {
            foreach (var elem in this.grid)
            {
                if (!elem.IsRevealed)
                {
                    elem.IsRevealed = true;
                }
            }
        }

        /// <summary>
        /// The is cell revealed.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <returns>
        /// Is cell revealed or not <see cref="bool"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// The InvalidGridOperation Exception.
        /// </exception>
        public bool IsCellRevealed(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.grid[row, column].IsRevealed;
        }

        /// <summary>
        /// The is cell protected.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <returns>
        /// Is cell protected or not <see cref="bool"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// The InvalidGridOperation Exception.
        /// </exception>
        public bool IsCellProtected(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.grid[row, column].IsProtected;
        }

        /// <summary>
        /// The has cell bomb.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <returns>
        /// Has cell bomb or not <see cref="bool"/>.
        /// </returns>
        /// <exception cref="InvalidGridOperation">
        /// The InvalidGridOperation Exception.
        /// </exception>
        public bool HasCellBomb(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            return this.grid[row, column].HasBomb;
        }

        /// <summary>
        /// The trigger cell protection.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <exception cref="InvalidGridOperation">
        /// The InvalidGridOperation Exception.
        /// </exception>
        public void TriggerCellProtection(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidGridOperation("Not valid cell entered!");
            }

            this.grid[row, column].IsProtected = !this.grid[row, column].IsProtected;
        }

        /// <summary>
        /// The open neighbor zero mines.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        private void OpenNeightborZeroMines(int row, int column)
        {
            MinesweeperGridIterator.IterateNeighbours(row, column, this.RevealNeighbour);
        }

        /// <summary>
        /// The reveal neighbor.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        private void RevealNeighbour(int row, int column)
        {
            if (this.IsValidCell(row, column) && !this.HasCellBomb(row, column) && !this.IsCellRevealed(row, column))
            {
                this.RevealCell(row, column);
            }
        }

        /// <summary>
        ///     The reveal all neighbors with zero mines.
        /// </summary>
        private void RevealAllNeighborsWithZeroMines()
        {
            MinesweeperGridIterator.IterateGrid(this.Rows, this.Cols, this.RevealCellWithZeroMines);
        }

        /// <summary>
        /// The reveal cell with zero mines.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        private void RevealCellWithZeroMines(int row, int column)
        {
            if (this.NeighborMinesCount(row, column) == 0 && this.IsCellRevealed(row, column))
            {
                this.OpenNeightborZeroMines(row, column);
            }
        }

        /// <summary>
        /// The is valid cell.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <returns>
        /// If is valid cell or not <see cref="bool"/>.
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
            var mineCoordinates = new int[this.MinesCount]; // creates array of coordinates of mines row*x+column
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
            while (currentMinesCount < this.MinesCount);

            for (var i = 0; i < this.MinesCount; i++)
            {
                // fill mines
                var row = mineCoordinates[i] % this.Rows;
                var column = mineCoordinates[i] / this.Cols;

                this.grid[row, column].HasBomb = true;
            }
        }

        /// <summary>
        /// The populate grid.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        private void PopulateGrid(int row, int column)
        {
            this.grid[row, column] = new MinesweeperCell();
        }

        /// <summary>
        /// The increment mines count.
        /// </summary>
        /// <param name="currentRow">
        /// The current row.
        /// </param>
        /// <param name="currentColumn">
        /// The current column.
        /// </param>
        /// <param name="initialRow">
        /// The initial row.
        /// </param>
        /// <param name="initialColumn">
        /// The initial column.
        /// </param>
        private void IncrementMinesCount(int currentRow, int currentColumn, int initialRow, int initialColumn)
        {
            if (this.grid[currentRow, currentColumn].HasBomb)
            {
                this.grid[initialRow, initialColumn].NeighboringMinesCount++;
            }
        }
    }
}