// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfTimer.cs" company="">
//   
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
    /// The wpf timer.
    /// </summary>
    public class WpfTimer : IMinesweeperTimer
    {
        /// <summary>
        /// The timer.
        /// </summary>
        private readonly DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfTimer"/> class.
        /// </summary>
        /// <param name="timer">
        /// The timer.
        /// </param>
        /// <param name="span">
        /// The span.
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
        /// The start.
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
        /// The stop.
        /// </summary>
        public void Stop()
        {
            this.timer.Stop();
        }
    }
}