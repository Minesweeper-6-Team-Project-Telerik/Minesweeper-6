// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperAddPlayerEventArgs.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
        /// <value>The player name.</value>
        public string PlayerName { get; set; }
    }
}