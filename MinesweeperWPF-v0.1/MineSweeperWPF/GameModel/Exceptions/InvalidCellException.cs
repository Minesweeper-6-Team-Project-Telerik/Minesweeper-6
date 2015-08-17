// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCellException.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid cell exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Exceptions
{
    using System;

    /// <summary>
    ///     The invalid cell exception.
    /// </summary>
    internal class InvalidCellException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidCellException" /> class.
        /// </summary>
        public InvalidCellException()
            : base("Invalid cell!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidCellException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidCellException(string message)
            : base(message)
        {
        }
    }
}