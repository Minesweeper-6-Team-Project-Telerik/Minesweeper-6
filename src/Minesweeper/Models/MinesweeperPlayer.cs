// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperPlayer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
        /// <value>Game duration in seconds.</value>
        public int Time { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>The player name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>Game difficulty type.</value>
        public MinesweeperDifficultyType Type { get; set; }
    }
}