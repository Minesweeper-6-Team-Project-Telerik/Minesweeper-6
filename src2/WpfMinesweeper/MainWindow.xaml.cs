// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper
{
    using System.Windows;

    using Minesweeper.Controller;
    using Minesweeper.Models;

    using WpfMinesweeper.View;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     The view.
        /// </summary>
        private readonly WpfView view;

        /// <summary>
        ///     The game controller.
        /// </summary>
        private MinesweeperGameController gameController;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.view = new WpfView(this.WinesweeperGrid);
            this.Width = 240;
            this.Height = 340;
            this.gameController = new MinesweeperGameController(MinesweeperDifficultyType.Easy, this.view);
        }

        /// <summary>
        /// The menu item_ new easy game_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MenuItem_NewEasyGame_Click(object sender, RoutedEventArgs e)
        {
            this.WinesweeperGrid.Children.Clear();
            this.Width = 240;
            this.Height = 340;
            this.gameController = new MinesweeperGameController(MinesweeperDifficultyType.Easy, this.view);
        }

        /// <summary>
        /// The menu item_ new medium game_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MenuItem_NewMediumGame_Click(object sender, RoutedEventArgs e)
        {
            this.WinesweeperGrid.Children.Clear();
            this.Width = 380;
            this.Height = 480;
            this.gameController = new MinesweeperGameController(MinesweeperDifficultyType.Medium, this.view);
        }

        /// <summary>
        /// The menu item_ new hard game_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MenuItem_NewHardGame_Click(object sender, RoutedEventArgs e)
        {
            this.WinesweeperGrid.Children.Clear();
            this.Width = 500;
            this.Height = 600;
            this.gameController = new MinesweeperGameController(MinesweeperDifficultyType.Hard, this.view);
        }

        /// <summary>
        /// The score item_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void ScoreItem_Click(object sender, RoutedEventArgs e)
        {
            this.view.ScoreItem_Click();
        }
    }
}