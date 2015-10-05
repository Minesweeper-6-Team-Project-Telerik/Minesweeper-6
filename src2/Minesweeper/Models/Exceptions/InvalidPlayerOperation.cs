// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidPlayerOperation.cs" company="">
//   
// </copyright>
// <summary>
//   The invalid player operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models.Exceptions
{
    using System;

    /// <summary>
    /// The invalid player operation.
    /// </summary>
    public class InvalidPlayerOperation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPlayerOperation"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidPlayerOperation(string message)
            : base(message)
        {
        }
    }
}