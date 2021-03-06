// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfView.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The wpf view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Management.Instrumentation;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;
    using Minesweeper.Views;

    using WpfMinesweeper.Models;
    using WpfMinesweeper.Properties;

    /// <summary>
    ///     The Windows Presentation Foundation view.
    /// </summary>
    public class WpfView : IMinesweeperView
    {
        /// <summary>
        ///     The cell height and width.
        /// </summary>
        private const int CellHeightAndWidth = 20;

        /// <summary>
        ///     The buttons.
        /// </summary>
        private readonly List<WpfMinesweeperButton> buttons;

        /// <summary>
        ///     The images.
        /// </summary>
        private readonly List<ImageBrush> images;

        /// <summary>
        ///     The win grid.
        /// </summary>
        private readonly Grid win;

        /// <summary>
        ///     The is grid initialized.
        /// </summary>
        private bool isGridInitialized;

        /// <summary>
        ///     The last column.
        /// </summary>
        private int lastCol;

        /// <summary>
        ///     The last row.
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
            // Keep global grid for later use
            this.win = window;

            this.isGridInitialized = false;

            // Keep reference to all grid buttons
            this.buttons = new List<WpfMinesweeperButton>();

            // Initialize all resource pictures, and keep them in ram for performance
            this.images = new List<ImageBrush>
                              {
                                  ImageFactory.CreateImage(Resources.mine), 
                                  ImageFactory.CreateImage(Resources.flag)
                              };
        }

        /// <summary>
        ///     The add player event.
        /// </summary>
        public event EventHandler AddPlayerEvent;

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
        /// The display time.
        /// </summary>
        /// <param name="timer">
        /// The game timer.
        /// </param>
        public void DisplayTime(int timer)
        {
            var timeLabel = (Label)this.win.FindName("TimeLabel");

            if (timeLabel == null)
            {
                throw new InstanceNotFoundException("Cannot find time label element!");
            }

            timeLabel.Content = timer.ToString("D3");
        }

        /// <summary>
        /// The display moves.
        /// </summary>
        /// <param name="moves">
        /// The game moves.
        /// </param>
        public void DisplayMoves(int moves)
        {
            var movesLabel = (Label)this.win.FindName("ScoreLabel");

            if (movesLabel == null)
            {
                throw new InstanceNotFoundException("Cannot find time label element!");
            }

            movesLabel.Content = moves.ToString("D3");
        }

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="board">
        /// The score board.
        /// </param>
        public void DisplayScoreBoard(List<MinesweeperPlayer> board)
        {
            var scoresWindow = new ScoresWindow(board);
            scoresWindow.Show();
        }

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The game grid.
        /// </param>
        public void DisplayGrid(IMinesweeperGrid grid)
        {
            var rows = grid.Rows;
            var cols = grid.Cols;

            if (grid.NeighborMinesCount(this.lastRow, this.lastCol) == 0)
            {
                this.isGridInitialized = false;
            }            

            if (this.isGridInitialized)
            {
                var i = this.lastRow;
                var j = this.lastCol;

                var button = this.buttons.First(x => x.Name == "Button_" + i.ToString() + "_" + j.ToString());
                this.UpdateCellButton(grid, button);
            }
            else
            {
                this.buttons.Clear();
                this.win.Children.Clear();

                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < cols; j++)
                    {
                        var button = new WpfMinesweeperButton { Row = rows, Col = cols };                     

                        button.Name = "Button_" + i + "_" + j;
                        button.HorizontalAlignment = HorizontalAlignment.Left;
                        button.VerticalAlignment = VerticalAlignment.Top;
                        button.Width = CellHeightAndWidth;
                        button.Height = CellHeightAndWidth;
                        button.Margin = new Thickness(i * CellHeightAndWidth, j * CellHeightAndWidth, 0, 0);
                        button.Click += this.CellButtonClick;                        
                        button.MouseRightButtonUp += this.ButtonOnMouseRightButtonUp;
                        button.Row = i;
                        button.Col = j;

                        this.UpdateCellButton(grid, button);

                        this.win.Children.Add(button);
                        this.buttons.Add(button);                        
                    }
                }

                this.isGridInitialized = true;
            }
        }

        /// <summary>
        /// The display game over.
        /// </summary>
        /// <param name="gameResult">
        /// The game result.
        /// </param>
        public void DisplayGameOver(bool gameResult)
        {
            this.isGridInitialized = false;

            if (gameResult == false)
            {
                MessageBox.Show("Game Over!", "Minesweeper", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var unprotectedButtons = this.buttons.Where(b => (string)b.Content == string.Empty);
                foreach (var upb in unprotectedButtons)
                {
                    upb.Background = this.images[1];
                }

                var protectedButtons = this.buttons.Where(b => b.Background.Equals(this.images[1]));
                foreach (var pb in protectedButtons)
                {
                    pb.IsHitTestVisible = false;
                }

                var inputBox = new InputBox(this.PlayerAdd);
                inputBox.Show();
            }
        }

        /// <summary>
        ///     The score item click.
        /// </summary>
        public void ScoreItemClick()
        {
            if (this.ShowScoreBoardEvent != null)
            {
                this.ShowScoreBoardEvent.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// The update cell button.
        /// </summary>
        /// <param name="grid">
        /// The game grid.
        /// </param>
        /// <param name="button">
        /// The button.
        /// </param>
        private void UpdateCellButton(IMinesweeperGrid grid, WpfMinesweeperButton button)
        {
            var i = button.Row;
            var j = button.Col;
            
            var color = new System.Windows.Media.Color();

            if (grid.IsCellProtected(i, j))
            {
                button.Background = this.images[1];
            }
            else if (grid.IsCellRevealed(i, j))
            {
                button.ClearValue(Control.BackgroundProperty);
                button.Background = new SolidColorBrush(Colors.LightGray);

                if (grid.HasCellBomb(i, j))
                {
                    button.Background = this.images[0];
                }
                else
                {
                    switch (grid.NeighborMinesCount(i, j))
                    {
                        case 1:
                            color = Colors.Blue;
                            break;
                        case 2:
                            color = Colors.Green;
                            break;
                        case 3:
                            color = Colors.Red;
                            break;
                        case 4:
                            color = Colors.Indigo;
                            break;
                        case 5:
                            color = Colors.DarkSlateGray;
                            break;
                        case 6:
                            color = Colors.DarkRed;
                            break;
                        case 7:
                            color = Colors.DarkBlue;
                            break;
                        case 8:
                            color = Colors.Black;
                            break;                        
                    }

                    if (grid.NeighborMinesCount(i, j) != 0)
                    {
                        button.Content = grid.NeighborMinesCount(i, j).ToString();
                        button.Foreground = new SolidColorBrush(color);
                    }
                }

                button.IsHitTestVisible = false;
            }
            else
            {
                button.Background = new SolidColorBrush(Colors.AliceBlue);

                button.Content = string.Empty;
            }
        }

        /// <summary>
        /// The player add.
        /// </summary>
        /// <param name="name">
        /// The player name.
        /// </param>
        private void PlayerAdd(string name)
        {
            var movesLabel = (Label)this.win.FindName("ScoreLabel");
            var timeLabel = (Label)this.win.FindName("TimeLabel");

            if (movesLabel == null || timeLabel == null)
            {
                throw new NullReferenceException("Move or time labels are not available!");
            }

            var args = new MinesweeperAddPlayerEventArgs { PlayerName = name };

            if (this.AddPlayerEvent != null)
            {
                this.AddPlayerEvent.Invoke(this, args);
            }
        }

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
            if ((sender as WpfMinesweeperButton) == null)
            {
                throw new NullReferenceException("No object given!");
            }

            var args = new MinesweeperCellClickEventArgs
                           {
                               Row = ((WpfMinesweeperButton)sender).Row, 
                               Col = ((WpfMinesweeperButton)sender).Col
                           };

            this.lastCol = args.Col;
            this.lastRow = args.Row;

            if (this.ProtectCellEvent != null)
            {
                this.ProtectCellEvent.Invoke(this, args);
            }
        }

        /// <summary>
        /// The button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The click event.
        /// </param>
        private void CellButtonClick(object sender, RoutedEventArgs e)
        {
            if ((sender as WpfMinesweeperButton) == null)
            {
                throw new NullReferenceException("No object given!");
            }

            var args = new MinesweeperCellClickEventArgs
                           {
                               Row = ((WpfMinesweeperButton)sender).Row, 
                               Col = ((WpfMinesweeperButton)sender).Col
                           };

            this.lastCol = args.Col;
            this.lastRow = args.Row;

            if (this.OpenCellEvent != null)
            {
                this.OpenCellEvent.Invoke(this, args);
            }
        }
    }
}
