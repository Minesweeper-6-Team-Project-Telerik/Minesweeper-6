// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="">
//   
// </copyright>
// <summary>
//   The Player interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models.Interfaces
{
    /// <summary>
    ///     The Player interface.
    /// </summary>
    public interface IMinesweeperPlayer
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the score.
        /// </summary>
        int Score { get; set; }

        /// <summary>
        ///     Gets or sets the time.
        /// </summary>
        int Time { get; set; }
    }
}