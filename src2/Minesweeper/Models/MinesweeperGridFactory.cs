// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGridFactoryMdl.cs" company="">
//   
// </copyright>
// <summary>
//   The minesweeper grid factory mdl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Minesweeper.Models
{
    using Minesweeper.Models.Interfaces;

    /// <summary>
    /// The minesweeper grid factory mdl.
    /// </summary>
    public static class MinesweeperGridFactory
    {
        /// <summary>
        /// The get people.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IMinesweeperGrid"/>.
        /// </returns>
        public static IMinesweeperGrid CreateNewTable(DifficultyType type)
        {
            IMinesweeperGrid grid = null;
            switch (type)
            {
                case DifficultyType.Easy:
                    grid = new MinesweeperGrid(9, 9, 10);
                    break;
                case DifficultyType.Medium:
                    grid = new MinesweeperGrid(16, 16, 40);
                    break;
                case DifficultyType.Hard:
                    grid = new MinesweeperGrid(22, 22, 99);
                    break;
            }

            return grid;
        }
    }
}