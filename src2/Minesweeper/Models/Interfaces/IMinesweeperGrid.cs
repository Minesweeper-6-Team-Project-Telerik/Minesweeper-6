// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperGrid.cs" company="">
//   
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
        ///     The Cols.
        /// </summary>
        int Cols { get; }

        /// <summary>
        ///     The Rows.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the mines count.
        /// </summary>
        int MinesCount { get; }

        int RevealedCellsCount { get; }

        /// <summary>
        /// The reveal cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        void RevealCell(int row, int column);

        /// <summary>
        /// The is cell revealed.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsCellRevealed(int row, int column);

        /// <summary>
        /// The protect cell.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        void ProtectCell(int row, int column);

        /// <summary>
        /// The is cell protected.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsCellProtected(int row, int column);

        /// <summary>
        /// The has cell bomb.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool HasCellBomb(int row, int column);

        /// <summary>
        /// The trigger cell protection.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        void TriggerCellProtection(int row, int column);

        /// <summary>
        /// The neighbor mines count.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int NeighbourMinesCount(int row, int column);

        /// <summary>
        ///     The reveal all mines.
        /// </summary>
        void RevealAllMines();
    }
}