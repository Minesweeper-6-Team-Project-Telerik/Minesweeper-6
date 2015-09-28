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

    using ConsoleMinesweeper.Interfaces;

    using Minesweeper.Models;

    /// <summary>
    ///     The console printer.
    /// </summary>
    public static class ConsolePrinter
    {
        /// <summary>
        /// The print.
        /// </summary>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <param name="box">
        /// The box.
        /// </param>
        public static void Print(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output, IConsoleBox<ConsoleColor> box)
        {
            output.BackgroundColor = box.ColorBackground;
            output.ForegroundColor = box.ColorText;

            for (var i = box.StartX; i <= box.StartX + box.SizeX; i++)
            {
                for (var j = box.StartY; j <= box.StartY + box.SizeY; j++)
                {
                    output.SetCursorPosition(i, j);
                    output.Write(" ");
                }
            }

            output.SetCursorPosition(box.StartX, box.StartY);
            output.Write("╔");
            output.SetCursorPosition(box.StartX, box.StartY + box.SizeY);
            output.Write("╚");
            output.SetCursorPosition(box.StartX + box.SizeX, box.StartY);
            output.Write("╗");
            output.SetCursorPosition(box.StartX + box.SizeX, box.StartY + box.SizeY);
            output.Write("╝");

            for (var i = box.StartX + 1; i < box.StartX + box.SizeX; i++)
            {
                output.SetCursorPosition(i, box.StartY);
                output.Write("═");
                output.SetCursorPosition(i, box.StartY + box.SizeY);
                output.Write("═");
            }

            for (var i = box.StartY + 1; i < box.StartY + box.SizeY; i++)
            {
                output.SetCursorPosition(box.StartX, i);
                output.Write("║");
                output.SetCursorPosition(box.StartX + box.SizeX, i);
                output.Write("║");
            }

            if (box.Text != string.Empty)
            {
                var rows = box.Text.SplitBy(box.SizeX - 1);
                var cnt = 0;

                foreach (var row in rows)
                {
                    output.SetCursorPosition(box.StartX + 1, box.StartY + 1 + cnt);
                    output.Write(row);
                    cnt++;
                }
            }

            output.ResetColor();
        }

        public static void PrintGrid(IConsoleWrapper<ConsoleColor, ConsoleKeyInfo> output, IConsoleBox<ConsoleColor> box, EventHandler openCellEvent, EventHandler protectCellEvent)
        {
            Print(output, box);

            var x = box.StartX + 1;
            var y = box.StartY + 1;

            output.CursorVisible = true;
            output.CursorSize = 100;
            output.SetCursorPosition(x, y);

            ConsoleKeyInfo key;

            do
            {
                key = output.ReadKey(true);

                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (x < box.StartX + box.SizeX - 1)
                    {
                        x += 1;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (y < box.StartY + box.SizeY - 1)
                    {
                        y += 1;
                    }
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (x > box.StartX + 1)
                    {
                        x -= 1;
                    }
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (y > box.StartY + 1)
                    {
                        y -= 1;
                    }
                }

                if (key.Key == ConsoleKey.Spacebar)
                {
                    var args = new MinesweeperCellClickEventArgs
                    {
                        Row = y - box.StartY - 1,
                        Col = x - box.StartX - 1
                    };

                    openCellEvent.Invoke(null, args);
                }

                if (key.Key == ConsoleKey.F)
                {
                    var args = new MinesweeperCellClickEventArgs
                    {
                        Row = y - box.StartY - 1,
                        Col = x - box.StartX - 1
                    };

                    protectCellEvent.Invoke(null, args);
                }

                output.SetCursorPosition(x, y);
            }
            while (key.Key != ConsoleKey.End);
        }
    }
}