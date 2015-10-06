// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Menu.cs" company="">
//   
// </copyright>
// <summary>
//   The menu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleMinesweeper.Interfaces;
    using ConsoleMinesweeper.Models;

    /// <summary>
    ///     The menu.
    /// </summary>
    public class Menu : ConsoleBox<ConsoleColor>
    {
        /// <summary>
        ///     The buttons.
        /// </summary>
        private readonly IList<ConsoleButton<ConsoleColor>> buttons;

        /// <summary>
        /// The output.
        /// </summary>
        private readonly IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output;

        /// <summary>
        ///     The idx.
        /// </summary>
        private int idx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
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
        /// <param name="buttons">
        /// The buttons.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        public Menu(
            int startX, 
            int startY, 
            int sizeX, 
            int sizeY, 
            ConsoleColor colorBack, 
            ConsoleColor colorText, 
            IList<ConsoleButton<ConsoleColor>> buttons, 
            IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output)
            : base(startX, startY, sizeX, sizeY, colorBack, colorText, string.Empty)
        {
            this.buttons = buttons;
            this.output = output;

            var x = 2;
            var y = 2;

            foreach (var button in buttons)
            {
                x = Math.Max(x, button.SizeX);
                y += button.SizeY;
            }

            x += 6;
            y += 4 + ((buttons.Count() - 1) * 2);

            this.SizeX = x;
            this.SizeY = y;

            y = startY;

            ConsolePrinter.Print(output, this);

            foreach (var button in buttons)
            {
                button.StartX = this.StartX + 3;
                button.StartY = y + 3;
                ConsolePrinter.Print(output, button);
                y += 2 + button.SizeY;
            }
        }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.buttons[0].Trigger();

            ConsolePrinter.Print(this.output, this);

            foreach (var button in this.buttons)
            {
                ConsolePrinter.Print(this.output, button);
            }

            ConsoleKeyInfo key;
            this.output.CursorVisible = false;

            do
            {
                key = this.output.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    this.idx--;
                    this.RefreshUp();
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    this.idx++;
                    this.RefreshDown();
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    this.buttons[this.idx].Click();
                }
            }
            while (key.Key != ConsoleKey.E);
        }

        /// <summary>
        ///     The refresh up.
        /// </summary>
        private void RefreshUp()
        {
            if (this.idx < 0)
            {
                this.idx = 0;
            }
            else
            {
                this.buttons[this.idx].Trigger();
                this.buttons[this.idx + 1].Trigger();

                var y = this.StartY;

                foreach (var button in this.buttons)
                {
                    ConsolePrinter.Print(this.output, button);
                    y += 2 + button.SizeY;
                }
            }
        }

        /// <summary>
        ///     The refresh down.
        /// </summary>
        private void RefreshDown()
        {
            if (this.idx > this.buttons.Count - 1)
            {
                this.idx = this.buttons.Count - 1;
            }
            else
            {
                this.buttons[this.idx].Trigger();
                this.buttons[this.idx - 1].Trigger();
                foreach (var button in this.buttons)
                {
                    ConsolePrinter.Print(this.output, button);
                }
            }
        }
    }
}