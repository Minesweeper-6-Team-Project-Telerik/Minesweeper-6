// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IllegalMoveException.cs" company="">
//   
// </copyright>
// <summary>
//   The illegal move exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Exceptions
{
    using System;

    /// <summary>
    ///     The illegal move exception.
    /// </summary>
    internal class IllegalMoveException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="IllegalMoveException" /> class.
        /// </summary>
        public IllegalMoveException()
            : base("Illegal move!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IllegalMoveException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public IllegalMoveException(string message)
            : base(message)
        {
        }
    }
}