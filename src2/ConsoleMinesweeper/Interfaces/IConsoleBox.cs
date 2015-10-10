// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleBox.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
    /// Console Color...
    /// </typeparam>
    public interface IConsoleBox<out TColor>
    {
        /// <summary>
        ///     Gets the start x.
        /// </summary>
        /// <value>Start x coordinate.</value>
        int StartX { get; }

        /// <summary>
        ///     Gets the start y.
        /// </summary>
        /// <value>Start y coordinate.</value>
        int StartY { get; }

        /// <summary>
        ///     Gets the size x.
        /// </summary>
        /// <value>Horizontal size x.</value>
        int SizeX { get; }

        /// <summary>
        ///     Gets the size y.
        /// </summary>
        /// <value>Vertical size y.</value>
        int SizeY { get; }

        /// <summary>
        ///     Gets the color background.
        /// </summary>
        /// <value>Background color.</value>
        TColor ColorBackground { get; }

        /// <summary>
        ///     Gets the color text.
        /// </summary>
        /// <value>Text color.</value>
        TColor ColorText { get; }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <value>Console text.</value>
        string Text { get; }
    }
}
