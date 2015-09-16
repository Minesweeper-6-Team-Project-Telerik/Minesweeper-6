// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCellOperation.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid cell operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models.Exceptions
{
    using System;

    /// <summary>
    /// The invalid cell operation.
    /// </summary>
    public class InvalidCellOperation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellOperation"/> class.
        /// </summary>
        public InvalidCellOperation()
            : base("Invalid cell operation!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellOperation"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidCellOperation(string message)
            : base(message)
        {
        }
    }
}