// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputBox.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for InputBox.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper
{
    using System;
    using System.Windows;

    using Minesweeper.Models;

    /// <summary>
    ///     Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        /// <summary>
        /// The player delegate.
        /// </summary>
        private readonly Action<MinesweeperPlayer> playerDelegate;

        /// <summary>
        /// The score.
        /// </summary>
        private readonly int score;

        /// <summary>
        /// The time.
        /// </summary>
        private readonly int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBox"/> class.
        /// </summary>
        /// <param name="score">
        /// The score.
        /// </param>
        /// <param name="time">
        /// The time.
        /// </param>
        /// <param name="playerDelegate">
        /// The player Delegate.
        /// </param>
        public InputBox(int score, int time, Action<MinesweeperPlayer> playerDelegate)
        {
            this.score = score;
            this.time = time;
            this.InitializeComponent();
            this.playerDelegate = playerDelegate;
        }

        /// <summary>
        /// The cancel button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The ok button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Input validations            
            var newPlayer = new MinesweeperPlayer();
            newPlayer.Name = this.NameTextBox.Text;
            newPlayer.Score = this.score;
            newPlayer.Time = this.time;

            this.playerDelegate(newPlayer);

            this.Close();
        }
    }
}