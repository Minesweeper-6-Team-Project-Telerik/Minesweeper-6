﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperCell.cs" company="">
//   
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
        }

        /// <summary>
        ///     Gets or sets a value indicating whether is revealed.
        /// </summary>
        /// <exception cref="InvalidCellOperation">
        /// </exception>
        public bool IsRevealed
        {
            get
            {
                return this.isRevealed;
            }

            set
            {
                if (this.isRevealed)
                {
                   // throw new InvalidCellOperation("Cell is already revealed!");
                }

                if (!this.IsProtected)
                {
                    this.isRevealed = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether has bomb.
        /// </summary>
        /// <exception cref="InvalidCellOperation">
        /// </exception>
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
        public bool IsProtected { get; set; }
    }
}