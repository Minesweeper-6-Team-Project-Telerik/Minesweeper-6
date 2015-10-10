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
        /// <value>The player name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>Game duration in seconds.</value>
        int Time { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>The game difficulty type.</value>
        MinesweeperDifficultyType Type { get; set; }
    }
}