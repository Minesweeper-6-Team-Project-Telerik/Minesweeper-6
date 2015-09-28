// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperTimer.cs" company="">
//   
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
        /// The start.
        /// </summary>
        void Start();

        /// <summary>
        /// The stop.
        /// </summary>
        void Stop();
    }
}