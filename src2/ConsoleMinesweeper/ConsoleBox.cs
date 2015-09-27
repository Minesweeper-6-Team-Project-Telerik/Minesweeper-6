// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleBox.cs" company="">
//   
// </copyright>
// <summary>
//   The console box.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;

    /// <summary>
    ///     The console box.
    /// </summary>
    internal class ConsoleBox : IConsoleBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleBox"/> class.
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
        public ConsoleBox(
            int startX, 
            int startY, 
            int sizeX, 
            int sizeY, 
            ConsoleColor colorBack, 
            ConsoleColor colorText, 
            string text)
        {
            // todo: validations
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
        public ConsoleColor ColorBackground { get; protected set; }

        /// <summary>
        ///     Gets or sets the color text.
        /// </summary>
        public ConsoleColor ColorText { get; protected set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        public string Text { get; set; }
    }
}