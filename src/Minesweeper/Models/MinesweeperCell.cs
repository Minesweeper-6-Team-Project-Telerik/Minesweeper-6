// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperCell.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The minesweeper cell.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using Minesweeper.Models.Exceptions;
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The minesweeper cell.
    /// </summary>
    public class MinesweeperCell : IMinesweeperCell
    {
        /// <summary>
        ///     The has bomb.
        /// </summary>
        private bool hasBomb;

        /// <summary>
        /// The is protected.
        /// </summary>
        private bool isProtected;

        /// <summary>
        ///     The is revealed.
        /// </summary>
        private bool isRevealed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MinesweeperCell" /> class.
        /// </summary>
        public MinesweeperCell()
        {
            this.IsProtected = false;
            this.IsRevealed = false;
            this.HasBomb = false;
            this.NeighboringMinesCount = 0;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is revealed.
        /// </summary>
        /// <exception cref="InvalidCellOperation">
        ///     The InvalidCellOperation exception.
        /// </exception>
        /// <value>Is cell revealed or not.</value>
        public bool IsRevealed
        {
            get
            {
                return this.isRevealed;
            }

            set
            {
                if (!this.IsProtected && !this.isRevealed)
                {
                    this.isRevealed = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether has bomb.
        /// </summary>
        /// <exception cref="InvalidCellOperation">
        ///     The InvalidCellOperation exception.
        /// </exception>
        /// <value>Has cell bomb or not.</value>
        public bool HasBomb
        {
            get
            {
                return this.hasBomb;
            }

            set
            {
                if (this.hasBomb)
                {
                    throw new InvalidCellOperation("There is already bomb on this cell!");
                }

                this.hasBomb = value;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is protected.
        /// </summary>
        /// <value>Is cell protected or not.</value>
        public bool IsProtected
        {
            get
            {
                return this.isProtected;
            }

            set
            {
                if (!this.IsRevealed)
                {
                    this.isProtected = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating how many mines surround the cell.
        /// </summary>
        /// <value>The mines count in the neighboring cells.</value>
        public int NeighboringMinesCount { get; set; }
    }
}