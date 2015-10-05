// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoresWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for ScoresWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     Interaction logic for ScoresWindow.xaml
    /// </summary>
    public partial class ScoresWindow : Window
    {
        /// <summary>
        /// The board.
        /// </summary>
        private readonly List<MinesweeperPlayer> board;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoresWindow"/> class.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        public ScoresWindow(List<MinesweeperPlayer> board)
        {
            this.InitializeComponent();
            this.ScoreList.ItemsSource =
                board.Where(x => x.Type == MinesweeperDifficultyType.Easy).OrderBy(x => x.Time);
            this.board = board;
        }

        /// <summary>
        /// The text to type.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="MinesweeperDifficultyType"/>.
        /// </returns>
        private MinesweeperDifficultyType TextToType(string text)
        {
            switch (text)
            {
                case "Easy":
                    return MinesweeperDifficultyType.Easy;
                case "Medium":
                    return MinesweeperDifficultyType.Medium;
                case "Hard":
                    return MinesweeperDifficultyType.Hard;
            }

            return MinesweeperDifficultyType.Easy;
        }

        /// <summary>
        /// The select box_ drop down closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void SelectBox_DropDownClosed(object sender, EventArgs e)
        {
            if (this.board != null)
            {
                this.ScoreList.ItemsSource =
                    this.board.Where(x => x.Type == this.TextToType(this.SelectBox.Text)).OrderBy(x => x.Time);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}