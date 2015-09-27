// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsolePrinter.cs" company="">
//   
// </copyright>
// <summary>
//   The enumerable ex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using System;

    /// <summary>
    ///     The console printer.
    /// </summary>
    public static class ConsolePrinter
    {
        /// <summary>
        /// The print.
        /// </summary>
        /// <param name="box">
        /// The box.
        /// </param>
        public static void Print(IConsoleBox box)
        {
            Console.BackgroundColor = box.ColorBackground;
            Console.ForegroundColor = box.ColorText;

            for (var i = box.StartX; i <= box.StartX + box.SizeX; i++)
            {
                for (var j = box.StartY; j <= box.StartY + box.SizeY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(box.StartX, box.StartY);
            Console.Write("╔");
            Console.SetCursorPosition(box.StartX, box.StartY + box.SizeY);
            Console.Write("╚");
            Console.SetCursorPosition(box.StartX + box.SizeX, box.StartY);
            Console.Write("╗");
            Console.SetCursorPosition(box.StartX + box.SizeX, box.StartY + box.SizeY);
            Console.Write("╝");

            for (var i = box.StartX + 1; i < box.StartX + box.SizeX; i++)
            {
                Console.SetCursorPosition(i, box.StartY);
                Console.Write("═");
                Console.SetCursorPosition(i, box.StartY + box.SizeY);
                Console.Write("═");
            }

            for (var i = box.StartY + 1; i < box.StartY + box.SizeY; i++)
            {
                Console.SetCursorPosition(box.StartX, i);
                Console.Write("║");
                Console.SetCursorPosition(box.StartX + box.SizeX, i);
                Console.Write("║");
            }

            if (box.Text != string.Empty)
            {
                var rows = box.Text.SplitBy(box.SizeX - 1);
                var cnt = 0;

                foreach (var row in rows)
                {
                    Console.SetCursorPosition(box.StartX + 1, box.StartY + 1 + cnt);
                    Console.Write(row);
                    cnt++;
                }
            }

            Console.WindowLeft = 0;
            Console.ResetColor();
        }
    }
}