// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="">
//   
// </copyright>
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("MineSweeper")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Telerik")]
[assembly: AssemblyProduct("MineSweeper")]
[assembly: AssemblyCopyright("Copyright © Telerik 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("bd3662c4-8672-4f44-9886-7ed423821496")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace MineSweeper
{
    using System;
    using System.Windows;

    using MineSweeper.ConsoleGame;
    using MineSweeper.GraphicGame;

    /// <summary>
    ///     The program.
    /// </summary>
    internal class Minesweeper
    {
        /// <summary>
        ///     The main.
        /// </summary>
        [STAThread]

        // <summary>
        // The main.
        // </summary>
        private static void Main()
        {
            // var game = new ConsoleMinesweeperGame(5, 10, 15);
            var game = new WpfMinesweeperGame(10, 10, 25);
            game.Start();
        }
    }
}