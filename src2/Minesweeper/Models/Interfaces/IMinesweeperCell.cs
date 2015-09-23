// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperCell.cs" company="">
//   
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
        bool IsRevealed { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether has bomb.
        /// </summary>
        bool HasBomb { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether is protected.
        /// </summary>
        bool IsProtected { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating how many mines surround the cell.
        /// </summary>
        int NeighbouringMinesCount { get; set; }
    }
}