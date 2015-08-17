// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandUnknownException.cs" company="">
//   
// </copyright>
// <summary>
//   The command unknown exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Exceptions
{
    using System;

    /// <summary>
    ///     The command unknown exception.
    /// </summary>
    internal class CommandUnknownException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandUnknownException" /> class.
        /// </summary>
        public CommandUnknownException()
            : base("Command unknown!")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandUnknownException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public CommandUnknownException(string message)
            : base(message)
        {
        }
    }
}