// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGrid.cs" company="">
//   
// </copyright>
// <summary>
//   The Grid interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Interfaces
{
    /// <summary>
    /// The Grid interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    internal interface IMinesweeperGrid<T>
    {
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
        T RevealCell(int row, int column);

        /// <summary>
        ///     The to string.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        string ToString();

        /// <summary>
        /// The get cell value.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="column">
        /// The column.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetCellValue(int row, int column);

        /// <summary>
        /// The is valid cell.
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
        bool IsValidCell(int row, int column);

        /// <summary>
        /// The neighbour mines count.
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
        ///     The reset.
        /// </summary>
        void Reset();

        /// <summary>
        ///     The revealed count.
        /// </summary>
        /// <returns>
        ///     The <see cref="int" />.
        /// </returns>
        int RevealedCount();

        /// <summary>
        ///     The reveal mines.
        /// </summary>
        void RevealMines();
    }
}