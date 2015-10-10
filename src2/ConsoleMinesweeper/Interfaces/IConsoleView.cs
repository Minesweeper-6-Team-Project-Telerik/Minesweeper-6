// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleView.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The ConsoleView interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleMinesweeper.Interfaces
{
    using Minesweeper.Models;
    using Minesweeper.Views;

    /// <summary>
    /// The ConsoleView interface.
    /// </summary>
    public interface IConsoleView : IMinesweeperView
    {
        /// <summary>
        /// The request score list.
        /// </summary>
        /// <param name="type">
        /// The game difficulty type.
        /// </param>
        void RequestScoreList(MinesweeperDifficultyType type);
    }
}
