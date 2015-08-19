// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleMinesweeperGrid.cs" company="">
//   
// </copyright>
// <summary>
//   The console minesweeper Grid.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.ConsoleGame
{
    using System.Text;

    using MineSweeper.GameModel;

    /// <summary>
    ///     The console minesweeper Grid.
    /// </summary>
    internal class ConsoleMinesweeperGrid : MinesweeperGrid<char>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleMinesweeperGrid"/> class.
        /// </summary>
        /// <param name="rows">
        /// The Rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        public ConsoleMinesweeperGrid(int rows, int columns, int minesCount)
            : base(rows, columns, minesCount)
        {
            this.Reset();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    this.SetCellValue(i, j, '?');
                }
            }
        }

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
        /// The <see cref="char"/>.
        /// </returns>
        public override char RevealCell(int row, int column)
        {
            if (this.Grid[row, column].HasBomb)
            {
                this.SetCellValue(row, column, '*');
            }
            else
            {
                this.SetCellValue(row, column, this.NeighbourMinesCount(row, column).ToString()[0]);
            }

            return base.RevealCell(row, column);
        }

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("   ");

            // generates column numbers
            for (var i = 0; i < this.Cols; i++)
            {
                sb.AppendFormat(" {0}", i);
            }

            sb.Append(" \n");

            // generates -----------------
            sb.Append("   ");
            sb.Append('-', (this.Cols * 2) + 1);
            sb.Append(" \n");

            for (var i = 0; i < this.Rows; i++)
            {
                // generates row number
                sb.AppendFormat("{0} |", i);

                // generate values in each row
                for (var j = 0; j < this.Cols; j++)
                {
                    sb.AppendFormat(" {0}", this.GetCellValue(i, j));
                }

                sb.Append(" |\n");
            }

            // generates -----------------
            sb.Append("   ");
            sb.Append('-', (this.Cols * 2) + 1);
            sb.Append(" \n");

            return sb.ToString();
        }
    }
}