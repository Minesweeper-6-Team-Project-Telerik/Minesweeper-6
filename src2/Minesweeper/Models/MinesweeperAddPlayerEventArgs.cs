// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperAddPlayerEventArgs.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper add player event args.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using System;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The minesweeper add player event args.
    /// </summary>
    public class MinesweeperAddPlayerEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the player.
        /// </summary>
        public string PlayerName { get; set; }
    }
}