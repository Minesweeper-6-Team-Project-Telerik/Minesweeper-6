using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMinesweeper
{
    using System.Windows.Controls;

    /// <summary>
    ///     The wpf minesweeper button.
    /// </summary>
    internal class WpfMinesweeperButton : Button
    {
        /// <summary>
        ///     Gets or sets the row.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        ///     Gets or sets the col.
        /// </summary>
        public int Col { get; set; }
    }
}
