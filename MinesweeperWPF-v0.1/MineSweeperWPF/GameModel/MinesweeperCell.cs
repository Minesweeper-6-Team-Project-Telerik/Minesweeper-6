// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cell.cs" company="">
//   
// </copyright>
// <summary>
//   The cell.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel
{
    using MineSweeper.GameModel.Interfaces;

    /// <summary>
    /// The cell.
    /// </summary>
    /// <typeparam name="T">
    /// Cell value
    /// </typeparam>
    public class MinesweeperCell<T> : IMinesweeperCell<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MinesweeperCell{T}" /> class.
        /// </summary>
        public MinesweeperCell()
        {
            this.Reset();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperCell{T}"/> class.
        /// </summary>
        /// <param name="revealed">
        /// The revealed.
        /// </param>
        /// <param name="hasBomb">
        /// The has bomb.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public MinesweeperCell(bool revealed, bool hasBomb, T value)
        {
            this.IsRevealed = revealed;
            this.HasBomb = hasBomb;
            this.Value = value;
        }

        /// <summary>
        ///     Gets a value indicating whether has bomb.
        /// </summary>
        public bool HasBomb { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether is revealed.
        /// </summary>
        public bool IsRevealed { get; private set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     The reveal.
        /// </summary>
        public void Reveal()
        {
            this.IsRevealed = true;
        }

        /// <summary>
        ///     The put bomb.
        /// </summary>
        public void PutBomb()
        {
            this.HasBomb = true;
        }

        /// <summary>
        ///     The reset.
        /// </summary>
        public void Reset()
        {
            this.IsRevealed = false;
            this.HasBomb = false;
            this.Value = default(T);
        }
    }
}