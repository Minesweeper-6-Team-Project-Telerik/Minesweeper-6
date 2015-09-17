// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperPlayerBoard.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper player board.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models
{
    using System;
    using System.Collections.Generic;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    /// The minesweeper player board.
    /// </summary>
    [Serializable]
    public class MinesweeperPlayerBoard : IMinesweeperPlayerBoard
    {
        /// <summary>
        /// The file.
        /// </summary>
        private readonly string file;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperPlayerBoard"/> class.
        /// </summary>
        /// <param name="file">
        /// The file.
        /// </param>
        public MinesweeperPlayerBoard(string file)
        {
            this.Players = MinesweeperGameData.Load<List<MinesweeperPlayer>>(file) ?? new List<MinesweeperPlayer>();
            this.file = file;
        }

        /// <summary>
        /// Gets the players.
        /// </summary>
        public List<MinesweeperPlayer> Players { get; private set; }

        /// <summary>
        /// The add player.
        /// </summary>
        /// <param name="player">
        /// The player.
        /// </param>
        public void AddPlayer(MinesweeperPlayer player)
        {
            this.Players.Add(player);
        }

        /// <summary>
        /// The save.
        /// </summary>
        public void Save()
        {
            MinesweeperGameData.Save(this.Players, this.file);
        }
    }
}