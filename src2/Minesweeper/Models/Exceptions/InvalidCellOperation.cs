// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidCellOperation.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The invalid cell operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models.Exceptions
{
    using System;

    /// <summary>
    ///     The invalid cell operation.
    /// </summary>
    public class InvalidCellOperation : Exception
    {
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