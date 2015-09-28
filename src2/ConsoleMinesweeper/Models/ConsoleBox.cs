// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleBox.cs" company="">
//   
// </copyright>
// <summary>
//   The console box.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Models
{
    using System;

    using ConsoleMinesweeper.Interfaces;

    /// <summary>
    /// The console box.
    /// </summary>
    /// <typeparam name="TColor">
    /// </typeparam>
    public class ConsoleBox<TColor> : IConsoleBox<TColor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleBox{TColor}"/> class.
        /// </summary>
        /// <param name="startX">
        /// The start x.
        /// </param>
        /// <param name="startY">
        /// The start y.
        /// </param>
        /// <param name="sizeX">
        /// The size x.
        /// </param>
        /// <param name="sizeY">
        /// The size y.
        /// </param>
        /// <param name="colorBack">
        /// The color back.
        /// </param>
        /// <param name="colorText">
        /// The color text.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public ConsoleBox(int startX, int startY, int sizeX, int sizeY, TColor colorBack, TColor colorText, string text)
        {
            if (startX <= 0 || startY <= 0)
            {
                throw new ArgumentException("Start coordinates cannot be negative or 0!");
            }

            if (sizeX <= 0 || sizeY <= 0)
            {
                throw new ArgumentException("Sizes cannot be negative or 0!");
            }

            if (text == null)
            {
                throw new ArgumentNullException("Input string cannot be null!");
            }

            if (colorBack == null || colorText == null)
            {
                throw new ArgumentNullException("Colors cannot be null!");
            }

            this.StartX = startX;
            this.StartY = startY;
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.ColorBackground = colorBack;
            this.ColorText = colorText;
            this.Text = text;
        }

        /// <summary>
        ///     Gets or sets the start x.
        /// </summary>
        public int StartX { get; set; }

        /// <summary>
        ///     Gets or sets the start y.
        /// </summary>
        public int StartY { get; set; }

        /// <summary>
        ///     Gets or sets the size x.
        /// </summary>
        public int SizeX { get; protected set; }

        /// <summary>
        ///     Gets or sets the size y.
        /// </summary>
        public int SizeY { get; protected set; }

        /// <summary>
        ///     Gets or sets the color background.
        /// </summary>
        public TColor ColorBackground { get; protected set; }

        /// <summary>
        ///     Gets or sets the color text.
        /// </summary>
        public TColor ColorText { get; protected set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text { get; set; }
    }
}