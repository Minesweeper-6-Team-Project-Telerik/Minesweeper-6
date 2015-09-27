// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridBox.cs" company="">
//   
// </copyright>
// <summary>
//   The grid box.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;

    using Minesweeper.Models;

    /// <summary>
    ///     The grid box.
    /// </summary>
    internal class GridBox : ConsoleBox
    {
        /// <summary>
        ///     The x.
        /// </summary>
        private int x;

        /// <summary>
        ///     The y.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridBox"/> class.
        /// </summary>
        /// <param name="StartX">
        /// The start x.
        /// </param>
        /// <param name="StartY">
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
        public GridBox(
            int StartX, 
            int StartY, 
            int sizeX, 
            int sizeY, 
            ConsoleColor colorBack, 
            ConsoleColor colorText, 
            string text)
            : base(StartX, StartY, sizeX, sizeY, colorBack, colorText, text)
        {
        }

        /// <summary>
        ///     The start.
        /// </summary>
        public void Start()
        {
            this.x = this.StartX + 1;
            this.y = this.StartY + 1;

            ConsoleKeyInfo key;
            Console.CursorVisible = true;
            Console.CursorSize = 100;

            Console.SetCursorPosition(this.x, this.y);

            // Console.BackgroundColor = ConsoleColor.Gray;
            // Console.ForegroundColor = ConsoleColor.Gray;
            // Console.Write("O");
            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (this.x < this.StartX + this.SizeX - 1)
                    {
                        this.x += 1;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (this.y < this.StartY + this.SizeY - 1)
                    {
                        this.y += 1;
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (this.x > this.StartX + 1)
                    {
                        this.x -= 1;
                    }
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (this.y > this.StartY + 1)
                    {
                        this.y -= 1;
                    }
                }

                if (key.Key == ConsoleKey.Spacebar)
                {
                    var args = new MinesweeperCellClickEventArgs
                                   {
                                       Row = this.y - this.StartY - 1, 
                                       Col = this.x - this.StartX - 1
                                   };

                    this.OpenCellEvent.Invoke(this, args);
                }

                if (key.Key == ConsoleKey.F)
                {
                    var args = new MinesweeperCellClickEventArgs
                                   {
                                       Row = this.y - this.StartY - 1, 
                                       Col = this.x - this.StartX - 1
                                   };

                    this.ProtectCellEvent.Invoke(this, args);
                }

                Console.SetCursorPosition(this.x, this.y);
            }
            while (key.KeyChar != 'e');
        }

        /// <summary>
        ///     The open cell event.
        /// </summary>
        public event EventHandler OpenCellEvent;

        /// <summary>
        ///     The protect cell event.
        /// </summary>
        public event EventHandler ProtectCellEvent;
    }
}