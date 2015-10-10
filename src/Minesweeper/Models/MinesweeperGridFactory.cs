// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinesweeperGridFactory.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   The minesweeper grid factory mdl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Minesweeper.Models
{
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     The minesweeper grid factory.
    /// </summary>
    public static class MinesweeperGridFactory
    {
        /// <summary>
        /// The create new table.
        /// </summary>
        /// <param name="type">
        /// The game difficulty type.
        /// </param>
        /// <returns>
        /// The game grid <see cref="IMinesweeperGrid"/>.
        /// </returns>
        public static IMinesweeperGrid CreateNewTable(MinesweeperDifficultyType type)
        {
            IMinesweeperGrid grid = null;
            switch (type)
            {
                case MinesweeperDifficultyType.Easy:
                    grid = new MinesweeperGrid(9, 9, 8);
                    break;
                case MinesweeperDifficultyType.Medium:
                    grid = new MinesweeperGrid(16, 16, 30);
                    break;
                case MinesweeperDifficultyType.Hard:
                    grid = new MinesweeperGrid(22, 22, 80);
                    break;
            }

            return grid;
        }
    }
}