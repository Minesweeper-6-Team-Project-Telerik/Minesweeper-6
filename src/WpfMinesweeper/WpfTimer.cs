// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfTimer.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The wpf timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfMinesweeper
{
    using System;
    using System.Windows.Threading;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    /// The Windows Presentation Foundation timer.
    /// </summary>
    public class WpfTimer : IMinesweeperTimer
    {
        /// <summary>
        /// The dispatcher timer.
        /// </summary>
        private readonly DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfTimer"/> class.
        /// </summary>
        /// <param name="timer">
        /// The dispatcher timer.
        /// </param>
        /// <param name="span">
        /// The time span.
        /// </param>
        public WpfTimer(DispatcherTimer timer, TimeSpan span)
        {
            this.timer = timer;
            this.timer.Interval = span;
        }

        /// <summary>
        /// The tick event.
        /// </summary>
        public event EventHandler TickEvent;

        /// <summary>
        /// The timer start.
        /// </summary>
        public void Start()
        {
            this.timer.Tick += (sender, args) =>
                {
                    if (this.TickEvent != null)
                    {
                        this.TickEvent(sender, args);
                    }
                };
            this.timer.Start();
        }

        /// <summary>
        /// The timer stop.
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
        }
    }
}
