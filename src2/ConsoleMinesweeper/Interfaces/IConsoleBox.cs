// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleBox.cs" company="">
//   
// </copyright>
// <summary>
//   The ConsoleBox interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Interfaces
{
    /// <summary>
    /// The ConsoleBox interface.
    /// </summary>
    /// <typeparam name="TColor">
    /// </typeparam>
    public interface IConsoleBox<out TColor>
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
        TColor ColorBackground { get; }

        /// <summary>
        ///     Gets the color text.
        /// </summary>
        TColor ColorText { get; }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        string Text { get; }
    }
}