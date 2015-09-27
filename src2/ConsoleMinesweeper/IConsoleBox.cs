// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleBox.cs" company="">
//   
// </copyright>
// <summary>
//   The ConsoleBox interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;

    /// <summary>
    ///     The ConsoleBox interface.
    /// </summary>
    public interface IConsoleBox
    {
        /// <summary>
        ///     Gets the start x.
        /// </summary>
        int StartX { get; }

        /// <summary>
        ///     Gets the start y.
        /// </summary>
        int StartY { get; }

        /// <summary>
        ///     Gets the size x.
        /// </summary>
        int SizeX { get; }

        /// <summary>
        ///     Gets the size y.
        /// </summary>
        int SizeY { get; }

        /// <summary>
        ///     Gets the color background.
        /// </summary>
        ConsoleColor ColorBackground { get; }

        /// <summary>
        ///     Gets the color text.
        /// </summary>
        ConsoleColor ColorText { get; }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        string Text { get; }
    }
}