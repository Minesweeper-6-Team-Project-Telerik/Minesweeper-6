// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICell.cs" company="">
//   
// </copyright>
// <summary>
//   The Cell interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Interfaces
{
    /// <summary>
    /// The MinesweeperCell interface.
    /// </summary>
    /// <typeparam name="T">
    /// Cell value
    /// </typeparam>
    internal interface IMinesweeperCell<T>
    {
        /// <summary>
        ///     Gets a value indicating whether is revealed.
        /// </summary>
        bool IsRevealed { get; }

        /// <summary>
        ///     Gets a value indicating whether has bomb.
        /// </summary>
        bool HasBomb { get; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        T Value { get; set; }

        /// <summary>
        ///     Gets and sets the number of bombs surounding the specific cell
        /// </summary>
        int BombCount { get; set; }
        /// <summary>
        ///     The reveal.
        /// </summary>
        void Reveal();

        /// <summary>
        ///     The put bomb.
        /// </summary>
        void PutBomb();

        /// <summary>
        ///     The reset.
        /// </summary>
        void Reset();
    }
}