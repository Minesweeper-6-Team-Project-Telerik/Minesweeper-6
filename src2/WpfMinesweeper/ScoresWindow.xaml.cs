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
    using System.Windows;

    using Minesweeper.Models.Interfaces;

    /// <summary>
    ///     Interaction logic for ScoresWindow.xaml
    /// </summary>
    public partial class ScoresWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoresWindow"/> class.
        /// </summary>
        /// <param name="board">
        /// The board.
        /// </param>
        public ScoresWindow(IMinesweeperPlayerBoard board)
        {
            this.InitializeComponent();
            this.scoreList.ItemsSource = board.Players;
        }
    }
}