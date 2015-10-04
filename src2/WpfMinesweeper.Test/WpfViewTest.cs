namespace WpfMinesweeper.Test
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Timers;
    using System.Threading;
    using System.Windows.Controls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Minesweeper.Controller;
    using Minesweeper.Models;

    using WpfMinesweeper;
    using WpfMinesweeper.View;
    
    [TestClass]
    public class WpfViewTest
    {
        [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
       public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

       private const int MOUSEEVENTF_LEFTDOWN = 0x02;
       private const int MOUSEEVENTF_LEFTUP = 0x04;
       private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
       private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private MainWindow mainWindow = new MainWindow();
        private Random random = new Random();

        private void DoMouseClick(uint X, uint Y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        [TestMethod]
        public void TestViewCreation()
        {   
            var view = new WpfView(mainWindow.WinesweeperGrid);

            Assert.AreNotEqual(null, view, "View is created");
        }

        [TestMethod]
        public void TestCorrectTime()
        {
            WpfView view = new WpfView(mainWindow.WinesweeperGrid);
            var timeLabel = (Label)mainWindow.WinesweeperGrid.FindName("TimeLabel");

            var sw = Stopwatch.StartNew();
            Thread.Sleep(2250);     //A little bit over two seconds because of offset between Thread.Sleep and Stopwatch
            sw.Stop();

            int timePassed = sw.Elapsed.Seconds;

            view.DisplayTime(timePassed);

            Assert.AreEqual("002", timeLabel.Content, "Correct time is shown");
        }

        [TestMethod]
        public void TestIncorrectTime()
        {
            WpfView view = new WpfView(mainWindow.WinesweeperGrid);
            var timeLabel = (Label)mainWindow.WinesweeperGrid.FindName("TimeLabel");

            var sw = Stopwatch.StartNew();
            Thread.Sleep(3000);
            sw.Stop();

            int timePassed = sw.Elapsed.Seconds;

            view.DisplayTime(timePassed);

            Assert.AreNotEqual("001", timeLabel.Content, "Incorrect time is shown");
        }

        [TestMethod]
        public void TestCorrectMoves()
        {
            var windowWidth = (int)mainWindow.ActualWidth;
            var windowHeight = (int)mainWindow.ActualHeight;
            uint randomX = (uint)random.Next(0, windowWidth);
            uint randomY = (uint)random.Next(0, windowHeight);

            WpfView view = new WpfView(mainWindow.WinesweeperGrid);

            DoMouseClick(randomX, randomY);

        }
    }
}
