// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScoreBoard.cs" company="">
//   
// </copyright>
// <summary>
//   The ScoreBoard interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel.Interfaces
{
    /// <summary>
    ///     The ScoreBoard interface.
    /// </summary>
    internal interface IScoreRecord
    {
        /// <summary>
        ///     Gets or sets the player name.
        /// </summary>
        string PlayerName { get; set; }

        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        /// The compare to.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int CompareTo(object obj);
    }
}