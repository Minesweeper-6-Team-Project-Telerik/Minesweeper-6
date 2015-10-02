namespace ConsoleMinesweeper.Interfaces
{
    using Minesweeper.Models;
    using Minesweeper.Views;

    public interface IConsoleView : IMinesweeperView
    {
        void RequestScoreList(MinesweeperDifficultyType type);
    }
}