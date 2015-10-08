// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleWrapper.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
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
        /// <value>The background color.</value>
        TColor BackgroundColor { get; set; }

        /// <summary>
        ///     Gets or sets the foreground color.
        /// </summary>
        /// <value>The foreground color.</value>
        TColor ForegroundColor { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether cursor visible.
        /// </summary>
        /// <value>True or false if cursor is visible or not.</value>
        bool CursorVisible { get; set; }

        /// <summary>
        ///     Gets or sets the cursor size.
        /// </summary>
        /// <value>The cursor size.</value>
        int CursorSize { get; set; }

        /// <summary>
        /// The set cursor position.
        /// </summary>
        /// <param name="x">
        /// The x cursor position.
        /// </param>
        /// <param name="y">
        /// The y cursor position.
        /// </param>
        void SetCursorPosition(int x, int y);

        /// <summary>
        /// The text write.
        /// </summary>
        /// <param name="text">
        /// The text string.
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

        /// <summary>
        /// The set window size.
        /// </summary>
        /// <param name="width">
        /// The window width.
        /// </param>
        /// <param name="height">
        /// The window height.
        /// </param>
        void SetWindowSize(int width, int height);

        /// <summary>
        /// The window clear.
        /// </summary>
        void Clear();

        /// <summary>
        /// The read line.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string ReadLine();
    }
}
