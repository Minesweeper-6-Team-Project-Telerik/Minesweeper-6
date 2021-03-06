// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleWrapper.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The console wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Models
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using ConsoleMinesweeper.Interfaces;

    /// <summary>
    ///     The console wrapper.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ConsoleWrapper : IConsoleWrapper<ConsoleColor, ConsoleKeyInfo>
    {
        /// <summary>
        ///     Gets or sets the background color.
        /// </summary>
        /// <value>Background color.</value>
        public ConsoleColor BackgroundColor
        {
            get
            {
                return Console.BackgroundColor;
            }

            set
            {
                Console.BackgroundColor = value;
            }
        }

        /// <summary>
        ///     Gets or sets the foreground color.
        /// </summary>
        /// <value>Foreground color.</value>
        public ConsoleColor ForegroundColor
        {
            get
            {
                return Console.ForegroundColor;
            }

            set
            {
                Console.ForegroundColor = value;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether cursor visible.
        /// </summary>
        /// <value>Is cursor visible or not.</value>
        public bool CursorVisible
        {
            get
            {
                return Console.CursorVisible;
            }

            set
            {
                Console.CursorVisible = value;
            }
        }

        /// <summary>
        ///     Gets or sets the cursor size.
        /// </summary>
        /// <value>Cursor size.</value>
        public int CursorSize
        {
            get
            {
                return Console.CursorSize;
            }

            set
            {
                Console.CursorSize = value;
            }
        }

        /// <summary>
        /// The set cursor position.
        /// </summary>
        /// <param name="x">
        /// The x position.
        /// </param>
        /// <param name="y">
        /// The y position.
        /// </param>
        public void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// The write text.
        /// </summary>
        /// <param name="text">
        /// The text to write.
        /// </param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        ///     The reset color.
        /// </summary>
        public void ResetColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// The read key.
        /// </summary>
        /// <param name="intercept">
        /// The intercept.
        /// </param>
        /// <returns>
        /// The <see cref="ConsoleKeyInfo"/>.
        /// </returns>
        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        /// <summary>
        /// The set window size.
        /// </summary>
        /// <param name="width">
        /// The width.
        /// </param>
        /// <param name="height">
        /// The height.
        /// </param>
        public void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// The read line.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
