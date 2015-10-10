// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperCellClickEventArgs.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The minesweeper cell click event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using System;

    /// <summary>
    ///     The minesweeper cell click event args.
    /// </summary>
    public class MinesweeperCellClickEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the row.
        /// </summary>
        /// <value>The clicked cell row.</value>
        public int Row { get; set; }

        /// <summary>
        ///     Gets or sets the column.
        /// </summary>
        /// <value>The clicked cell column.</value>
        public int Col { get; set; }
    }
}