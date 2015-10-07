﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ConsoleMinesweeper
{
    using ConsoleMinesweeper.Models;

    /// <summary>
    ///     The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            ConsoleMenus.StartMainMenu(new ConsoleWrapper());
        }
    }
}