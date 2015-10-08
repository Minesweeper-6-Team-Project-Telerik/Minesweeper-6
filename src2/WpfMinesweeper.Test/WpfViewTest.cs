using System.Windows;
using System.Windows.Input;

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
    using WpfMinesweeper.Models;
    using WpfMinesweeper.View;
    using System.Collections.Generic;
    using System.Windows.Media;

    [TestClass]
    public class WpfViewTest
    {
        private MainWindow mainWindow = new MainWindow();
        private Random random = new Random();

        private void ClickRandomButton()
        {
            PrivateObject view = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            Grid grid = (Grid)view.GetField("win");
            Button randomButton = (Button)grid.Children[random.Next(0, grid.Children.Count)];

            randomButton.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));
        }

        [TestMethod]
        public void TestViewCreation()
        {
            WpfView view = new WpfView(mainWindow.WinesweeperGrid);

            Assert.AreNotEqual(null, view, "View is created");
        }

        [TestMethod]
        public void TestCorrectTime()
        {
            WpfView view = new WpfView(mainWindow.WinesweeperGrid);
            Label timeLabel = (Label)mainWindow.WinesweeperGrid.FindName("TimeLabel");

            Stopwatch sw = Stopwatch.StartNew();
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
            Label timeLabel = (Label)mainWindow.WinesweeperGrid.FindName("TimeLabel");

            Stopwatch sw = Stopwatch.StartNew();
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

            Label movesLabel = (Label)mainWindow.WinesweeperGrid.FindName("ScoreLabel");
            Assert.AreEqual("001", movesLabel.Content, "Correct moves are shown");
        }

        [TestMethod]
        public void TestIncorrectMoves()
        {
            ClickRandomButton();

            Label movesLabel = (Label)mainWindow.WinesweeperGrid.FindName("ScoreLabel");
            Assert.AreNotEqual("002", movesLabel.Content, "Correct moves are shown");
        }

        [TestMethod]
        public void TestButtonCannotBeClickedTwice()
        {
            PrivateObject view = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            Grid grid = (Grid)view.GetField("win");
            grid.Children[0].RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));

            Assert.IsFalse(grid.Children[0].IsHitTestVisible);
        }

        [TestMethod]
        public void TestButtonBackgroundIsChangedOnClick()
        {
            PrivateObject view = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            Grid grid = (Grid)view.GetField("win");
            Button button = (Button) grid.Children[0];
            SolidColorBrush initalBackgroundColor = (SolidColorBrush)button.Background;
            button.RaiseEvent(new System.Windows.RoutedEventArgs(Button.ClickEvent));

            Assert.AreNotEqual(initalBackgroundColor, button.Background);
        }

        [TestMethod]
        public void TestCellBackgroundIsChangedWhenCellHasMine()
        {
            PrivateObject view = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            PrivateObject window = new PrivateObject(new MainWindow());
            PrivateObject gameController = new PrivateObject((MinesweeperGameController)window.GetField("gameController"));
            MinesweeperGrid minesweeperGrid = (MinesweeperGrid)gameController.GetField("grid");
            Grid grid = (Grid)view.GetField("win");
            List<WpfMinesweeperButton> buttons = (List<WpfMinesweeperButton>)view.GetField("buttons");


            WpfMinesweeperButton button = new WpfMinesweeperButton();
            view.Invoke("DisplayGrid", minesweeperGrid);
            int counter = 0;

            for (int r = 0; r < minesweeperGrid.Rows; r++)
            {
                for (int c = 0; c < minesweeperGrid.Cols; c++)
                {
                    if (minesweeperGrid.HasCellBomb(r, c))
                    {
                        button = buttons.Find(b => b.Name.Equals("Button_" + r + "_" + c));
                        button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        r = minesweeperGrid.Rows;
                        break;
                    }

                    counter++;
                }
            }
            
            List<ImageBrush> images = (List<ImageBrush>)view.GetField("images");


            //Assert.AreEqual(string.Empty, button.Content);
            Assert.AreEqual(images[0], button.Background);
        }

        [TestMethod]
        public void TestCellBackgroundIsChangedWhenProtected()
        {
            PrivateObject view = new PrivateObject(new WpfView(mainWindow.WinesweeperGrid));
            PrivateObject window = new PrivateObject(new MainWindow());
            Grid grid = (Grid)view.GetField("win");
            Button button = (Button) grid.Children[0];

            button.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton.Right) { RoutedEvent = Button.ClickEvent});

            List<ImageBrush> images = (List<ImageBrush>) view.GetField("images");

            Assert.AreEqual(images[1], button.Background);
        }
    }
}
