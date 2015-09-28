// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleWrapper.cs" company="">
//   
// </copyright>
// <summary>
//   The ConsoleWrapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Interfaces
{
    /// <summary>
    /// The ConsoleWrapper interface.
    /// </summary>
    /// <typeparam name="TColor">
    /// </typeparam>
    /// <typeparam name="TKey">
    /// </typeparam>
    public interface IConsoleWrapper<TColor, TKey>
    {
        /// <summary>
        ///     Gets or sets the background color.
        /// </summary>
        TColor BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the foreground color.
        /// </summary>
        TColor ForegroundColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cursor visible.
        /// </summary>
        bool CursorVisible { get; set; }

        /// <summary>
        /// Gets or sets the cursor size.
        /// </summary>
        int CursorSize { get; set; }

        /// <summary>
        /// The set cursor position.
        /// </summary>
        /// <param name="x">
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        void SetCursorPosition(int x, int y);

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        void Write(string text);

        /// <summary>
        ///     The reset color.
        /// </summary>
        void ResetColor();

        /// <summary>
        /// The read key.
        /// </summary>
        /// <param name="intercept">
        /// The intercept.
        /// </param>
        /// <returns>
        /// The <see cref="TKey"/>.
        /// </returns>
        TKey ReadKey(bool intercept);
    }
}