// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperPlayer.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper player.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using System;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The minesweeper player.
    /// </summary>
    [Serializable]
    public class MinesweeperPlayer : IMinesweeperPlayer
    {
        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        public int Score { get; set; }
    }
}