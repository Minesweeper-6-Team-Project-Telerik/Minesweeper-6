// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperTimer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The MinesweeperTimer interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models.Interfaces
{
    using System;

    /// <summary>
    /// The MinesweeperTimer interface.
    /// </summary>
    public interface IMinesweeperTimer
    {
        /// <summary>
        /// The tick event.
        /// </summary>
        event EventHandler TickEvent;

        /// <summary>
        /// The game start.
        /// </summary>
        void Start();

        /// <summary>
        /// The game stop.
        /// </summary>
        void Stop();
    }
}