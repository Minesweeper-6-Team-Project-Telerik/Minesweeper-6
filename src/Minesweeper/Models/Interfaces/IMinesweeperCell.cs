// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperCell.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The MinesweeperCell interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models.Interfaces
{
    /// <summary>
    ///     The MinesweeperCell interface.
    /// </summary>
    public interface IMinesweeperCell
    {
        /// <summary>
        ///     Gets or sets a value indicating whether is revealed.
        /// </summary>
        /// <value>True or false is cell revealed.</value>
        bool IsRevealed { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether has bomb.
        /// </summary>
        /// <value>True or false has cell a bomb.</value>
        bool HasBomb { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is protected.
        /// </summary>
        /// <value>True or false is cell protected.</value>
        bool IsProtected { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating how many mines surround the cell.
        /// </summary>
        /// <value>The count of neighboring cells with mines.</value>
        int NeighboringMinesCount { get; set; }
    }
}