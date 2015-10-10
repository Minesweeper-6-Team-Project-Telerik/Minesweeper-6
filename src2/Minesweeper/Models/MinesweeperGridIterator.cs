// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGridIterator.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The minesweeper grid iterator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models
{
    using System;

    /// <summary>
    /// The minesweeper grid iterator.
    /// </summary>
    internal static class MinesweeperGridIterator
    {
        /// <summary>
        /// The iterate grid.
        /// </summary>
        /// <param name="rows">
        /// The number of rows.
        /// </param>
        /// <param name="columns">
        /// The number of columns.
        /// </param>
        /// <param name="gridAction">
        /// The grid action.
        /// </param>
        public static void IterateGrid(int rows, int columns, Action<int, int> gridAction)
        {
            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    gridAction(r, c);
                }
            }
        }

        /// <summary>
        /// The iterate neighbors.
        /// </summary>
        /// <param name="initialRow">
        /// The initial row.
        /// </param>
        /// <param name="initialColumn">
        /// The initial column.
        /// </param>
        /// <param name="rows">
        /// The number of rows.
        /// </param>
        /// <param name="columns">
        /// The number of columns.
        /// </param>
        /// <param name="cellAction">
        /// The cell action.
        /// </param>
        public static void IterateNeighbors(
            int initialRow, 
            int initialColumn, 
            int rows, 
            int columns, 
            Action<int, int, int, int> cellAction)
        {
            // restrict neigbour cell area
            var minRow = (initialRow - 1) < 0 ? initialRow : initialRow - 1;
            var maxRow = (initialRow + 1) >= rows ? initialRow : initialRow + 1;
            var minColumn = (initialColumn - 1) < 0 ? initialColumn : initialColumn - 1;
            var maxColumn = (initialColumn + 1) >= columns ? initialColumn : initialColumn + 1;

            for (var r = minRow; r <= maxRow; r++)
            {
                for (var c = minColumn; c <= maxColumn; c++)
                {
                    cellAction(r, c, initialRow, initialColumn);
                }
            }
        }

        /// <summary>
        /// The iterate neighbors.
        /// </summary>
        /// <param name="row">
        /// The cell row.
        /// </param>
        /// <param name="column">
        /// The cell column.
        /// </param>
        /// <param name="cellAction">
        /// The cell action.
        /// </param>
        public static void IterateNeighbors(int row, int column, Action<int, int> cellAction)
        {
            for (var i = row - 1; i <= row + 1; i++)
            {
                for (var j = column - 1; j <= column + 1; j++)
                {
                    cellAction(i, j);
                }
            }
        }
    }
}