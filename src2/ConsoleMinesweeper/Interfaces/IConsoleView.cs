// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConsoleView.cs" company="">
//   
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
        /// The type.
        /// </param>
        void RequestScoreList(MinesweeperDifficultyType type);
    }
}