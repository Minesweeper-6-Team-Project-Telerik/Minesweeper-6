// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Button.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The button.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper.Models
{
    using System;

    /// <summary>
    /// The button.
    /// </summary>
    /// <typeparam name="TColor">
    /// </typeparam>
    public class ConsoleButton<TColor> : ConsoleBox<TColor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleButton{TColor}"/> class.
        ///     Initializes a new instance of the <see cref="ConsoleButton"/> class.
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
        public ConsoleButton(
            int sizeX, 
            int sizeY, 
            TColor colorBack, 
            TColor colorText, 
            TColor colorBackSel, 
            TColor colorTextSel, 
            string text)
            : base(1, 1, sizeX, sizeY, colorBack, colorText, text)
        {
            if (colorBackSel == null || colorTextSel == null)
            {
                throw new ArgumentNullException("Colors cannot be null!");
            }

            this.ColorBackSelected = colorBackSel;
            this.ColorTextSelected = colorTextSel;
        }

        /// <summary>
        ///     The click event.
        /// </summary>
        public event EventHandler ClickEvent;

        /// <summary>
        ///     Gets or sets the color back selected.
        /// </summary>
        public TColor ColorBackSelected { get; protected set; }

        /// <summary>
        ///     Gets or sets the color text selected.
        /// </summary>
        public TColor ColorTextSelected { get; protected set; }

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
