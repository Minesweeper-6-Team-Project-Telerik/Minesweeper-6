﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperCellClickEventArgs.cs" company="">
//   
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
        public int Row { get; set; }

        /// <summary>
        ///     Gets or sets the col.
        /// </summary>
        public int Col { get; set; }
    }
}