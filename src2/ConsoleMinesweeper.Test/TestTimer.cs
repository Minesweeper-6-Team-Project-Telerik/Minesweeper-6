using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleMinesweeper.Test
{
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Models;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestTimer
    {
        [TestMethod]
        public void TestTimerShouldIncrement()
        {
            int cnt = 0;
            ConsoleTimer timer = new ConsoleTimer();
            timer.TickEvent += (sender, args) => { cnt++; };
            timer.Start();

            System.Threading.Thread.Sleep(1100);
            Assert.AreEqual(cnt, 2, "timer is not ticking");

            timer.Stop();
        }
    }
}
