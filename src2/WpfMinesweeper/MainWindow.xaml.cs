using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMinesweeper
{
    using Minesweeper.Controller;
    using Minesweeper.Models;
    using Minesweeper.Models.Interfaces;

    using WpfMinesweeper.View;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MinesweeperGameController gameController;
        private WpfView view;

        public MainWindow()
        {
            InitializeComponent();
           // view = new WpfView(WinesweeperGrid);
                       
        }

        private void MenuItem_NewEasyGame_Click(object sender, RoutedEventArgs e)
        {
            WinesweeperGrid.Children.Clear();
            this.view = new WpfView(WinesweeperGrid);
            this.gameController = new MinesweeperGameController(DifficultyType.Easy, this.view);            
            this.Width = 240;
            this.Height = 340;
            this.gameController.StartGame();
        }

        private void MenuItem_NewMediumGame_Click(object sender, RoutedEventArgs e)
        {
            WinesweeperGrid.Children.Clear();
            this.view = new WpfView(WinesweeperGrid);
            this.gameController = new MinesweeperGameController(DifficultyType.Medium, this.view);
            this.Width = 380;
            this.Height = 480;
            this.gameController.StartGame();
        }

        private void MenuItem_NewHardGame_Click(object sender, RoutedEventArgs e)
        {
            WinesweeperGrid.Children.Clear();
            this.view = new WpfView(WinesweeperGrid);
            this.gameController = new MinesweeperGameController(DifficultyType.Hard, this.view);
            this.Width = 500;
            this.Height = 600;
            this.gameController.StartGame();
        }

    }
}
