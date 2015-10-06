// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestTimer.cs" company="">
//   
// </copyright>
// <summary>
//   The test timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Test
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using ConsoleMinesweeper.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The test timer.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestTimer
    {
        /// <summary>
        /// The test timer should increment.
        /// </summary>
        [TestMethod]
        public void TestTimerShouldIncrement()
        {
            var cnt = 0;
            var timer = new ConsoleTimer();
            timer.TickEvent += (sender, args) => { cnt++; };
            timer.Start();

            Thread.Sleep(1100);
            Assert.AreEqual(cnt, 2, "timer is not ticking");

            timer.Stop();
        }
    }
}