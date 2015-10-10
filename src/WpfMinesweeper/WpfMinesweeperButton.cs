// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfMinesweeperButton.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The Windows Presentation Foundation minesweeper button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WpfMinesweeper
{
    using System.Windows.Controls;

    /// <summary>
    ///     The Windows Presentation Foundation minesweeper button.
    /// </summary>
    public class WpfMinesweeperButton : Button
    {
        /// <summary>
        ///     Gets or sets the row.
        /// </summary>
        /// <value>The button row.</value>
        public int Row { get; set; }

        /// <summary>
        ///     Gets or sets the col.
        /// </summary>
        /// <value>The button column.</value>
        public int Col { get; set; }
    }
}
