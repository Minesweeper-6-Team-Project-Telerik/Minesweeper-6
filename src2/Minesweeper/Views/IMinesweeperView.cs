// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IView.cs" company="">
//   
// </copyright>
// <summary>
//   The View interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Views
{
    using System;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The View interface.
    /// </summary>
    public interface IMinesweeperView
    {
        /// <summary>
        /// The display time.
        /// </summary>
        /// <param name="timer">
        /// The timer.
        /// </param>
        void DisplayTime(int timer);

        /// <summary>
        /// The display moves.
        /// </summary>
        /// <param name="moves">
        /// The moves.
        /// </param>
        void DisplayMoves(int moves);

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        void DisplayScoreBoard(IPlayerBoard board);

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The grid.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        void DisplayGrid(IMinesweeperGrid grid);

        void DisplayGameOver();

        /// <summary>
        ///     The open cell.
        /// </summary>
        event EventHandler OpenCellEvent;

        /// <summary>
        ///     The protect cell.
        /// </summary>
        event EventHandler ProtectCellEvent;
        
        /// <summary>
        ///     The show score board.
        /// </summary>
        event EventHandler ShowScoreBoardEvent;
    }
}