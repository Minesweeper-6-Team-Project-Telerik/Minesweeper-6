// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="">
//   
// </copyright>
// <summary>
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MineSweeper.GraphicGame
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMinesweeperMainWindow : Window
    {
        /// <summary>
        ///     The game.
        /// </summary>
        private WpfMinesweeperGame game;

        /// <summary>
        /// The moves count.
        /// </summary>
        private int movesCount;

        /// <summary>
        /// The passed time minutes.
        /// </summary>
        private int passedTimeMinutes;

        /// <summary>
        /// The passed time seconds.
        /// </summary>
        private int passedTimeSeconds;

        /// <summary>
        /// The timer.
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfMinesweeperMainWindow"/> class.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines Count.
        /// </param>
        public WpfMinesweeperMainWindow(int rows, int columns, int minesCount)
        {
            this.InitializeComponent();
            this.StartGame(rows, columns, minesCount);
        }

        /// <summary>
        /// The start timer.
        /// </summary>
        private void StartTimer()
        {
            this.timer.Interval = new TimeSpan(0, 0, 1);
            this.timer.Tick += this.clockTimeTick;
            this.timer.Start();
        }

        /// <summary>
        /// The clock time tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void clockTimeTick(object sender, EventArgs e)
        {
            // if (movesCount == (rows * cols) - bombs)
            // {
            // ShowWindow("Won");
            // timer.Stop();
            // }
            if (this.passedTimeSeconds == 60)
            {
                this.passedTimeSeconds = 0;
                this.passedTimeMinutes++;
            }

            this.timerTextBox.Text = this.CheckTimeInput();
            this.passedTimeSeconds++;
        }

        /// <summary>
        /// The check time input.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string CheckTimeInput()
        {
            var result = string.Empty;

            if (this.passedTimeMinutes < 10)
            {
                result += "0";
            }

            result += this.passedTimeMinutes + ":";

            if (this.passedTimeSeconds < 10)
            {
                result += "0";
            }

            result += this.passedTimeSeconds.ToString();

            return result;
        }

        /// <summary>
        /// The start game.
        /// </summary>
        /// <param name="rows">
        /// The rows.
        /// </param>
        /// <param name="columns">
        /// The columns.
        /// </param>
        /// <param name="minesCount">
        /// The mines count.
        /// </param>
        private void StartGame(int rows, int columns, int minesCount)
        {
            this.game = new WpfMinesweeperGame(rows, columns, minesCount);

            this.timer = new DispatcherTimer();
            this.movesCount = 0;
            this.passedTimeSeconds = 1;
            this.passedTimeMinutes = 0;

            this.Width = this.game.Grid.WpfGrid.Width + 50;
            this.Height = this.game.Grid.WpfGrid.Height + 300;
            this.grid.Children.Add(this.game.Grid.WpfGrid);

            this.game.Grid.BombOpened += this.GridOnBombOpened;

            this.StartTimer();
        }

        /// <summary>
        /// The game over.
        /// </summary>
        private void GameOver()
        {
            MessageBox.Show("Game over!");
        }

        /// <summary>
        /// The grid on bomb opened.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="eventArgs">
        /// The event args.
        /// </param>
        private void GridOnBombOpened(object sender, EventArgs eventArgs)
        {
            this.GameOver();
        }
    }
}