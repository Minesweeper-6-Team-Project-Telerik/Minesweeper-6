// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGame.cs" company="">
//   
// </copyright>
// <summary>
//   The Game interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// The Game interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    internal interface IMinesweeperGame<T>
    {
        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        ///     Gets or sets the score board.
        /// </summary>
        List<IScoreRecord> ScoreBoard { get; set; }

        /// <summary>
        ///     The start.
        /// </summary>
        void Start();
    }
}