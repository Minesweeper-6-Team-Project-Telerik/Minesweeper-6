// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperPlayerBoard.cs" company="">
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
    ///     The PlayerBoard interface.
    /// </summary>
    public interface IMinesweeperPlayerBoard
    {
        /// <summary>
        ///     Gets the players.
        /// </summary>
        List<MinesweeperPlayer> Players { get; }

        /// <summary>
        /// The add player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        void AddPlayer(MinesweeperPlayer player);

        /// <summary>
        /// The save.
        /// </summary>
        void Save();
    }
}