﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMinesweeperView.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The View interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Views
{
    using System;
    using System.Collections.Generic;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The View interface.
    /// </summary>
    public interface IMinesweeperView
    {
        /// <summary>
        ///     The open cell.
        /// </summary>
        event EventHandler OpenCellEvent;

        /// <summary>
        ///     The protect cell.
        /// </summary>
        event EventHandler ProtectCellEvent;

        /// <summary>
        ///     The show score board event.
        /// </summary>
        event EventHandler ShowScoreBoardEvent;

        /// <summary>
        ///     The add player event.
        /// </summary>
        event EventHandler AddPlayerEvent;

        /// <summary>
        /// The display time.
        /// </summary>
        /// <param name="timer">
        /// The game timer.
        /// </param>
        void DisplayTime(int timer);

        /// <summary>
        /// The display moves.
        /// </summary>
        /// <param name="moves">
        /// The game moves.
        /// </param>
        void DisplayMoves(int moves);

        /// <summary>
        /// The display score board.
        /// </summary>
        /// <param name="players">
        /// The current players.
        /// </param>
        void DisplayScoreBoard(List<MinesweeperPlayer> players);

        /// <summary>
        /// The display grid.
        /// </summary>
        /// <param name="grid">
        /// The game grid.
        /// </param>
        void DisplayGrid(IMinesweeperGrid grid);

        /// <summary>
        /// The display game over.
        /// </summary>
        /// <param name="gameResult">
        /// The game result.
        /// </param>
        void DisplayGameOver(bool gameResult);
    }
}