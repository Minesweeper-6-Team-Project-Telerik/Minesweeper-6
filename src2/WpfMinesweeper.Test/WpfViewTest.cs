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
        public void TestCellBackgroundIsChangedWhenCellHasMine()
        {
            MainWindow window = new MainWindow();
            MinesweeperGrid minesweeperGrid = (MinesweeperGrid)MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            PrivateObject view = new PrivateObject(new WpfView(window.WinesweeperGrid));
            Grid buttons = (Grid)view.GetField("win");

            view.Invoke("DisplayGrid", minesweeperGrid);

            int counter = 0;
            for (int r = 0; r < minesweeperGrid.Rows; r++)
            {
                for (int c = 0; c < minesweeperGrid.Cols; c++)
                {
                    if (minesweeperGrid.HasCellBomb(r, c))
                    {
                        minesweeperGrid.RevealCell(r, c);
                        view.Invoke("DisplayGrid", minesweeperGrid);
                        r = minesweeperGrid.Rows;
                        break;
                    }

                    counter++;
                }
            }
            
            List<ImageBrush> images = (List<ImageBrush>)view.GetField("images");
            Button button = (Button)buttons.Children[counter];

            Assert.AreEqual(images[0], button.Background);
        }

        [TestMethod]
        public void TestCellBackgroundIsChangedWhenProtected()
        {
            MainWindow window = new MainWindow();
            MinesweeperGrid minesweeperGrid = (MinesweeperGrid)MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Easy);
            PrivateObject view = new PrivateObject(new WpfView(window.WinesweeperGrid));
            Grid buttons = (Grid)view.GetField("win");

            view.Invoke("DisplayGrid", minesweeperGrid);

            int counter = 0;
            for (int r = 0; r < minesweeperGrid.Rows; r++)
            {
                for (int c = 0; c < minesweeperGrid.Cols; c++)
                {
                    if (minesweeperGrid.HasCellBomb(r, c))
                    {
                        minesweeperGrid.ProtectCell(r, c);
                        view.Invoke("DisplayGrid", minesweeperGrid);
                        r = minesweeperGrid.Rows;
                        break;
                    }

                    counter++;
                }
            }

            List<ImageBrush> images = (List<ImageBrush>)view.GetField("images");
            Button button = (Button)buttons.Children[counter];

            Assert.AreEqual(images[1], button.Background);
        }

        [TestMethod]
        public void TestColorIsChangedToBlueWhenCellHasOneNeighoubringMines()
        {
            MainWindow window = new MainWindow();
            MinesweeperGrid minesweeperGrid = (MinesweeperGrid)MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard);
            PrivateObject view = new PrivateObject(new WpfView(window.WinesweeperGrid));
            Grid buttons = (Grid)view.GetField("win");

            view.Invoke("DisplayGrid", minesweeperGrid);

            int counter = 0;
            for (int r = 0; r < minesweeperGrid.Rows; r++)
            {
                for (int c = 0; c < minesweeperGrid.Cols; c++)
                {
                    if (minesweeperGrid.NeighborMinesCount(r, c) == 1)
                    {
                        minesweeperGrid.RevealCell(r, c);
                        view.Invoke("DisplayGrid", minesweeperGrid);

                        r = minesweeperGrid.Rows;
                        break;
                    }

                    counter++;
                }
            }

            Button button = (Button)buttons.Children[counter];

            Color color = Colors.Blue;
            SolidColorBrush buttonColorBrush = (SolidColorBrush)button.Foreground;
            var buttonColor = buttonColorBrush.Color;

            Assert.AreEqual(color, buttonColor);
        }

        public void TestColorIsChangedToGreenWhenCellHasTwoNeighoubringMines()
        {
            MainWindow window = new MainWindow();
            MinesweeperGrid minesweeperGrid = (MinesweeperGrid)MinesweeperGridFactory.CreateNewTable(MinesweeperDifficultyType.Hard);
            PrivateObject view = new PrivateObject(new WpfView(window.WinesweeperGrid));
            Grid buttons = (Grid)view.GetField("win");

            view.Invoke("DisplayGrid", minesweeperGrid);

            int counter = 0;
            for (int r = 0; r < minesweeperGrid.Rows; r++)
            {
                for (int c = 0; c < minesweeperGrid.Cols; c++)
                {
                    if (minesweeperGrid.NeighborMinesCount(r, c) == 2)
                    {
                        minesweeperGrid.RevealCell(r, c);
                        view.Invoke("DisplayGrid", minesweeperGrid);

                        r = minesweeperGrid.Rows;
                        break;
                    }

                    counter++;
                }
            }

            Button button = (Button)buttons.Children[counter];

            Color color = Colors.Green;
            SolidColorBrush buttonColorBrush = (SolidColorBrush)button.Foreground;
            var buttonColor = buttonColorBrush.Color;

            Assert.AreEqual(color, buttonColor);
        }
    }
}
