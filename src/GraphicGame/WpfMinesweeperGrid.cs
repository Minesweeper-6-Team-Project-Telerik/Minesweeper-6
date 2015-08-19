// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfMinesweeperGrid.cs" company="">
//   
// </copyright>
// <summary>
//   The wpf minesweeper grid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GraphicGame
{
    using System.Windows;
    using System.Windows.Controls;

    using MineSweeper.GameModel;

    /// <summary>
    ///     The wpf minesweeper grid.
    /// </summary>
    internal class WpfMinesweeperGrid : MinesweeperGrid<WpfMinesweeperButton>
    {
        /// <summary>
        /// The row height.
        /// </summary>
        private const int RowHeight = 25;

        /// <summary>
        /// The row width.
        /// </summary>
        private const int RowWidth = 25;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfMinesweeperGrid"/> class.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public WpfMinesweeperGrid(int rows, int columns, int minesCount)
            : base(rows, columns, minesCount)
        {
            this.Reset();

            this.WpfGrid = new Grid { Width = RowWidth * columns, Height = RowHeight * rows, ShowGridLines = true };                

            for (var i = 0; i < rows; i++)
            {
                var gridRow = new RowDefinition { Height = new GridLength(RowHeight) };                
                this.WpfGrid.RowDefinitions.Add(gridRow);
            }

            for (var i = 0; i < columns; i++)
            {
                var gridCol = new ColumnDefinition { Width = new GridLength(RowWidth) };
                this.WpfGrid.ColumnDefinitions.Add(gridCol);
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var btn = new WpfMinesweeperButton { Row = i, Col = j };

                    System.Windows.Controls.Grid.SetRow(btn, i);
                    System.Windows.Controls.Grid.SetColumn(btn, j);
                    btn.Click += this.ClickEvent;
                    this.WpfGrid.Children.Add(btn);

                    this.SetCellValue(i, j, btn);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the wpf grid.
        /// </summary>
        public Grid WpfGrid { get; set; }

        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="WpfMinesweeperButton"/>.
        /// </returns>
        public override WpfMinesweeperButton RevealCell(int row, int column)
        {
            var btn = this.GetCellValue(row, column);

            if (this.Grid[row, column].HasBomb)
            {
                btn.Content = "*";
            }
            else
            {
                btn.Content = this.NeighbourMinesCount(row, column).ToString();
            }

            this.SetCellValue(row, column, btn);
            return base.RevealCell(row, column);
        }

        /// <summary>
        /// The click event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ClickEvent(object sender, RoutedEventArgs e)
        {            
            this.RevealCell((sender as WpfMinesweeperButton).Row, (sender as WpfMinesweeperButton).Col);
            (sender as WpfMinesweeperButton).IsEnabled = false;
        }
    }
}