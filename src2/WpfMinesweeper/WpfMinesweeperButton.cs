// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfMinesweeperButton.cs" company="">
//   
// </copyright>
// <summary>
//   The wpf minesweeper button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper
{
    using System.Windows.Controls;

    /// <summary>
    ///     The wpf minesweeper button.
    /// </summary>
    public class WpfMinesweeperButton : Button
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