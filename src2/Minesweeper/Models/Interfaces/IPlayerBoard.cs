// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayerBoard.cs" company="">
//   
// </copyright>
// <summary>
//   The PlayerBoard interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The PlayerBoard interface.
    /// </summary>
    public interface IPlayerBoard
    {
        /// <summary>
        /// Gets the players.
        /// </summary>
        List<Player> Players { get; }

        /// <summary>
        /// The add player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        void AddPlayer(Player player);
    }
}