// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleWrapper.cs" company="">
//   
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
        /// The x.
        /// </param>
        /// <param name="y">
        /// The y.
        /// </param>
        public void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        /// <summary>
        /// The write.
        /// </summary>
        /// <param name="text">
        /// The text.
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

        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}