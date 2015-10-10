// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidGridOperation.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The invalid grid operation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models.Exceptions
{
    using System;

    /// <summary>
    ///     The invalid grid operation.
    /// </summary>
    public class InvalidGridOperation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidGridOperation"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public InvalidGridOperation(string message)
            : base(message)
        {
        }
    }
}