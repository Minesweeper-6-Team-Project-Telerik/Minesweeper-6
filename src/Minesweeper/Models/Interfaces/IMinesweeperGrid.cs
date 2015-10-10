// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperGrid.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The MinesweeperGrid interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models.Interfaces
{
    using System;

    /// <summary>
    ///     The MinesweeperGrid interface.
    /// </summary>
    public interface IMinesweeperGrid
    {
        /// <summary>
        ///     The bomb opened event.
        /// </summary>
        event EventHandler BoomEvent;

        /// <summary>
        ///     Gets the Cols count.
        /// </summary>
        /// <value>The Cols count.</value>
        int Cols { get; }

        /// <summary>
        ///     Gets the Rows count.
        /// </summary>
        /// <value>The Rows count.</value>
        int Rows { get; }

        /// <summary>
        ///     Gets the mines count.
        /// </summary>
        /// <value>The mines count.</value>
        int MinesCount { get; }

        /// <summary>
        /// Gets the revealed cells count.
        /// </summary>
        /// <value>The revealed cells count.</value>
        int RevealedCellsCount { get; }

        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The reveal cell row.
        /// </param>
        /// <param name="column">
        /// The reveal cell column.
        /// </param>
        void RevealCell(int row, int column);

        /// <summary>
        /// The check if the cell is revealed.
        /// </summary>
        /// <param name="row">
        /// The reveal cell row.
        /// </param>
        /// <param name="column">
        /// The reveal cell column.
        /// </param>
        /// <returns>
        /// If the cell is revealed or not revealed <see cref="bool"/>.
        /// </returns>
        bool IsCellRevealed(int row, int column);

        /// <summary>
        /// The protect cell.
        /// </summary>
        /// <param name="row">
        /// The protect cell row.
        /// </param>
        /// <param name="column">
        /// The protect cell column.
        /// </param>
        void ProtectCell(int row, int column);

        /// <summary>
        /// The check if cell is protected.
        /// </summary>
        /// <param name="row">
        /// The protected cell row.
        /// </param>
        /// <param name="column">
        /// The protected cell column.
        /// </param>
        /// <returns>
        /// If the cell is protected or not protected <see cref="bool"/>.
        /// </returns>
        bool IsCellProtected(int row, int column);

        /// <summary>
        /// The has cell bomb.
        /// </summary>
        /// <param name="row">
        /// The has cell row.
        /// </param>
        /// <param name="column">
        /// The has cell column.
        /// </param>
        /// <returns>
        /// Has cell bomb or not <see cref="bool"/>.
        /// </returns>
        bool HasCellBomb(int row, int column);

        /// <summary>
        /// The trigger cell protection.
        /// </summary>
        /// <param name="row">
        /// The trigger cell row.
        /// </param>
        /// <param name="column">
        /// The trigger cell column.
        /// </param>
        void TriggerCellProtection(int row, int column);

        /// <summary>
        /// The neighbor mines count.
        /// </summary>
        /// <param name="row">
        /// The revealed cell row.
        /// </param>
        /// <param name="column">
        /// The revealed cell column.
        /// </param>
        /// <returns>
        /// The count of neighboring cells with mines.<see cref="int"/>.
        /// </returns>
        int NeighborMinesCount(int row, int column);

        /// <summary>
        ///     The reveal all mines.
        /// </summary>
        void RevealAllMines();
    }
}