// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The entry point of the program.
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
