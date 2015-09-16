// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfView.cs" company="">
//   
// </copyright>
// <summary>
//   The wpf view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper.View
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    /// <summary>
    ///     The wpf view.
    /// </summary>
    internal class WpfView : IMinesweeperView
    {
        /// <summary>
        /// The buttons.
        /// </summary>
        private readonly List<WpfMinesweeperButton> buttons;

        /// <summary>
        ///     The win.
        /// </summary>
        private readonly Grid win;

        /// <summary>
        /// The is grid initialized.
        /// </summary>
        private bool isGridInitialized;

        /// <summary>
        /// The last col.
        /// </summary>
        private int lastCol;

        /// <summary>
        /// The last row.
        /// </summary>
        private int lastRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfView"/> class.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        public WpfView(Grid window)
        {
            this.win = window;
            this.isGridInitialized = false;
            this.buttons = new List<WpfMinesweeperButton>();
        }

        /// <summary>
        /// The display time.
        /// </summary>
        /// <param name="timer">
        /// The timer.
        /// </param>
        public void DisplayTime(int timer)
        {
            var MyTimeLabel = (Label)this.win.FindName("TimeLabel");
            MyTimeLabel.Content = timer.ToString("D3");
        }

        /// <summary>
        /// The display moves.
        /// </summary>
        /// <param name="moves">
        /// The moves.
        /// </param>
        public void DisplayMoves(int moves)
        {
            var MyMovesLabel = (Label)this.win.FindName("ScoreLabel");
            MyMovesLabel.Content = moves.ToString("D3");
        }

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public void DisplayScoreBoard(IPlayerBoard board)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The grid.
        /// </param>
        public void DisplayGrid(IMinesweeperGrid grid)
        {
            var rows = grid.Rows;
            var cols = grid.Cols;

            if (this.isGridInitialized)
            {
                var i = this.lastRow;
                var j = this.lastCol;

                var button = this.buttons.First(x => x.Name == "Button_" + i.ToString() + "_" + j.ToString());

                if (grid.IsCellProtected(i, j))
                {
                    button.Content = 'F'.ToString();
                }
                else if (grid.IsCellRevealed(i, j))
                {
                    button.IsEnabled = false;
                    if (grid.HasCellBomb(i, j))
                    {
                        button.Content = '*'.ToString();
                    }
                    else
                    {
                        button.Content = grid.NeighbourMinesCount(i, j).ToString();
                    }
                }
                else
                {
                    button.Content = string.Empty;
                }
            }
            else
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < cols; j++)
                    {
                        var button = new WpfMinesweeperButton { Row = rows, Col = cols };

                        if (grid.IsCellProtected(i, j))
                        {
                            button.Content = 'F'.ToString();
                        }
                        else if (grid.IsCellRevealed(i, j))
                        {
                            button.IsEnabled = false;
                            if (grid.HasCellBomb(i, j))
                            {
                                button.Content = '*'.ToString();
                            }
                            else
                            {
                                button.Content = grid.NeighbourMinesCount(i, j).ToString();
                            }
                        }
                        else
                        {
                            button.Content = string.Empty;
                        }

                        button.Name = "Button_" + i + "_" + j;
                        button.HorizontalAlignment = HorizontalAlignment.Left;
                        button.VerticalAlignment = VerticalAlignment.Top;
                        button.Width = 20;
                        button.Height = 20;
                        button.Margin = new Thickness(i * 20, j * 20, 0, 0);
                        button.Click += this.button_Click;
                        button.MouseRightButtonUp += this.ButtonOnMouseRightButtonUp;
                        button.Row = i;
                        button.Col = j;
                        this.win.Children.Add(button);
                        this.buttons.Add(button);
                    }
                }

                this.isGridInitialized = true;
            }
        }

        public void DisplayGameOver()
        {
            this.isGridInitialized = false;
            //var dialog = new InputBox();
            //if (dialog.ShowDialog() == true)
            //{
            //    MessageBox.Show("You said: " + dialog.ResponseText);
            //} 
        }

        /// <summary>
        ///     The open cell event.
        /// </summary>
        public event EventHandler OpenCellEvent;

        /// <summary>
        ///     The protect cell event.
        /// </summary>
        public event EventHandler ProtectCellEvent;

        /// <summary>
        ///     The show score board event.
        /// </summary>
        public event EventHandler ShowScoreBoardEvent;


        /// <summary>
        /// The button on mouse right button up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="mouseButtonEventArgs">
        /// The mouse button event args.
        /// </param>
        private void ButtonOnMouseRightButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            var args = new MinesweeperCellClickEventArgs
                           {
                               Row = (sender as WpfMinesweeperButton).Row,
                               Col = (sender as WpfMinesweeperButton).Col
                           };

            this.lastCol = args.Col;
            this.lastRow = args.Row;

            this.ProtectCellEvent.Invoke(this, args);
        }

        /// <summary>
        /// The button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            var args = new MinesweeperCellClickEventArgs
                           {
                               Row = (sender as WpfMinesweeperButton).Row,
                               Col = (sender as WpfMinesweeperButton).Col
                           };

            this.lastCol = args.Col;
            this.lastRow = args.Row;

            this.OpenCellEvent.Invoke(this, args);
        }
    }
}