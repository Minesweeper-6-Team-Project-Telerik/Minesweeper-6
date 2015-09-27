// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Button.cs" company="">
//   
// </copyright>
// <summary>
//   The button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;

    /// <summary>
    ///     The button.
    /// </summary>
    internal class Button : ConsoleBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
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
        /// <param name="colorBackSel">
        /// The color back sel.
        /// </param>
        /// <param name="colorTextSel">
        /// The color text sel.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        public Button(
            int sizeX, 
            int sizeY, 
            ConsoleColor colorBack, 
            ConsoleColor colorText, 
            ConsoleColor colorBackSel, 
            ConsoleColor colorTextSel, 
            string text)
            : base(0, 0, sizeX, sizeY, colorBack, colorText, text)
        {
            // validation
            this.ColorBackSelected = colorBackSel;
            this.ColorBackSelected = colorBackSel;
        }

        /// <summary>
        ///     Gets or sets the color back selected.
        /// </summary>
        public ConsoleColor ColorBackSelected { get; protected set; }

        /// <summary>
        ///     Gets or sets the color text selected.
        /// </summary>
        public ConsoleColor ColorTextSelected { get; protected set; }

        /// <summary>
        ///     The click event.
        /// </summary>
        public event EventHandler ClickEvent;

        /// <summary>
        ///     The trigger.
        /// </summary>
        public void Trigger()
        {
            var colorBackTmp = this.ColorBackSelected;
            var colorTextTmp = this.ColorTextSelected;
            this.ColorBackSelected = this.ColorBackground;
            this.ColorTextSelected = this.ColorText;
            this.ColorBackground = colorBackTmp;
            this.ColorText = colorTextTmp;
        }

        /// <summary>
        ///     The click.
        /// </summary>
        public void Click()
        {
            if (this.ClickEvent != null)
            {
                this.ClickEvent.Invoke(this, EventArgs.Empty);
            }
        }
    }
}