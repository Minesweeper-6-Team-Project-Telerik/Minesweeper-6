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
    using System.Collections.Generic;

    [TestClass]
    public class WpfViewTest
    {
        private MainWindow mainWindow = new MainWindow();
        private Random random = new Random();

        private void ClickRandomButton()
        {
            PrivateObject privateView = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            var grid = (Grid)privateView.GetField("win");
            var randomButton = (Button)grid.Children[random.Next(0, grid.Children.Count)];

            randomButton.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));
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
            ClickRandomButton();

            var movesLabel = (Label)mainWindow.WinesweeperGrid.FindName("ScoreLabel");
            Assert.AreEqual("001", movesLabel.Content, "Correct moves are shown");
        }

        [TestMethod]
        public void TestIncorrectMoves()
        {
            ClickRandomButton();

            var movesLabel = (Label)mainWindow.WinesweeperGrid.FindName("ScoreLabel");
            Assert.AreNotEqual("002", movesLabel.Content, "Correct moves are shown");
        }

        [TestMethod]
        public void TestCellBackgroundIsChanged()
        {
            
        }
    }
}
