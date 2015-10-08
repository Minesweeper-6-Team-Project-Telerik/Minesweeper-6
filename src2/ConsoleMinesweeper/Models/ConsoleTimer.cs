// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleTimer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The console timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Models
{
    using System;
    using System.Threading;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The console timer.
    /// </summary>
    public class ConsoleTimer : IMinesweeperTimer
    {
        /// <summary>
        ///     The console timer.
        /// </summary>
        private Timer consoleTimer;

        /// <summary>
        ///     The tick event.
        /// </summary>
        public event EventHandler TickEvent;

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.consoleTimer = new Timer(this.TimerCallback, null, 0, 1000);
        }

        /// <summary>
        ///     The stop.
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// The timer callback.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        private void TimerCallback(object o)
        {
            if (this.TickEvent != null)
            {
                this.TickEvent.Invoke(this, new EventArgs());
            }
        }
    }
}
