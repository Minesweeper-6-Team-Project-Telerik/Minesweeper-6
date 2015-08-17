// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreRecord.cs" company="">
//   
// </copyright>
// <summary>
//   The score record.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GameModel
{
    using System;

    using MineSweeper.GameModel.Interfaces;

    /// <summary>
    ///     The score record.
    /// </summary>
    public class ScoreRecord : IComparable, IScoreRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreRecord"/> class.
        /// </summary>
        /// <param name="playerName">
        /// The player name.
        /// </param>
        /// <param name="score">
        /// The score.
        /// </param>
        public ScoreRecord(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        /// <summary>
        ///     Gets or sets the player name.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The compare to.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public int CompareTo(object obj)
        {
            if (!(obj is ScoreRecord))
            {
                throw new ArgumentException("Compare Object is not ScoreRecord!");
            }

            return -1 * this.Score.CompareTo(((ScoreRecord)obj).Score);
        }
    }
}