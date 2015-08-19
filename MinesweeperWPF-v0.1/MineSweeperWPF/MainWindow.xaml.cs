namespace MineSweeperWPF
{
    using MineSweeper.ConsoleGame;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int rows = 4;

        private static int cols = 4;

        private static int bombs = 4;

        private static ConsoleMinesweeperGame game;

        private static DispatcherTimer timer = new DispatcherTimer();

        private static int movesCount = 0;

        private static int passedTimeSeconds = 1;

        private static int passedTimeMinutes = 0;

        private static string flag = "pack://application:,,/Images/Flag.png";

        private static string bomb = "pack://application:,,/Images/Bomb.png";

        /// <summary>
        /// Main Program Window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            game = new ConsoleMinesweeperGame(rows, cols, bombs);

            StartTimer();
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        private void StartTimer()
        {
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += clockTimeTick;
            timer.Start();
        }

        private void clockTimeTick(object sender, EventArgs e)
        {
            if (movesCount == (rows * cols) - bombs)
            {
                ShowWindow("Won");
                timer.Stop();
            }

            if (passedTimeSeconds == 60)
            {
                passedTimeSeconds = 0;
                passedTimeMinutes++;
            }
            
            timerTextBox.Text = CheckTimeInput();
            passedTimeSeconds++;
        }

        private string CheckTimeInput()
        {
            string result = string.Empty;

            if (passedTimeMinutes < 10)
            {
                result += "0";
            }

            result += passedTimeMinutes.ToString() + ":";

            if (passedTimeSeconds < 10)
            {
                result += "0";
            }

            result += passedTimeSeconds.ToString();

            return result;
        }

        /// <summary>
        /// This method checks the selected value in the input matrix
        /// </summary>
        /// <param name="button"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void GiveContent(Button button, int row, int col)
        {
            var matrix = game.Grid;
            string check = matrix.RevealCell(row, col).ToString();

            if (check == "*")
            {
                PaintButtonValue(button, bomb);
                timer.Stop();

                ShowWindow("Lost");
            }
            else if (check == "0")
            {
                button.Content = "0";

                // Check neighbours for value 0 and show them
            }
            else
            {
                button.Content = check;
            }

            button.IsEnabled = false;
            movesCount++;
        }

        private void PaintButtonValue(Button button, string value)
        {
            StackPanel panel = new StackPanel();
            panel.Orientation = Orientation.Horizontal;

            Image image = new Image();
            image.Source = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));

            panel.Children.Add(image);

            button.Content = panel;
        }

        /// <summary>
        /// This method shows the final winning or losing window
        /// </summary>
        /// <param name="end"></param>
        private void ShowWindow(string end)
        {
            Window window = new Window();
            window.Width = 200;
            window.Height = 120;

            Uri iconUri = new Uri("pack://application:,,/Images/Icon.png", UriKind.RelativeOrAbsolute);
            window.Icon = BitmapFrame.Create(iconUri);

            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };

            stackPanel.Children.Add(new Label { Content = "You have " + end + "!" });

            if (end == "Won")
            {
                stackPanel.Children.Add(new Label { Content = "Moves: " + movesCount.ToString() });                
                stackPanel.Children.Add(new Label { Content = "Time: " + CheckTimeInput() });
            }

            window.Content = stackPanel;
            window.Show();

            AllDisable();
        }

        /// <summary>
        /// Disables all buttons after the end of the game
        /// </summary>
        private void AllDisable()
        {
            matrix_0_0.IsEnabled = false;
            matrix_0_1.IsEnabled = false;
            matrix_0_2.IsEnabled = false;
            matrix_0_3.IsEnabled = false;
            matrix_1_0.IsEnabled = false;
            matrix_1_1.IsEnabled = false;
            matrix_1_2.IsEnabled = false;
            matrix_1_3.IsEnabled = false;
            matrix_2_0.IsEnabled = false;
            matrix_2_1.IsEnabled = false;
            matrix_2_2.IsEnabled = false;
            matrix_2_3.IsEnabled = false;
            matrix_3_0.IsEnabled = false;
            matrix_3_1.IsEnabled = false;
            matrix_3_2.IsEnabled = false;
            matrix_3_3.IsEnabled = false;
        }

        private void Matrix_0_0(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_0_0, 0, 0);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_0_0_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_0_0;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_0_1(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_0_1, 0, 1);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_0_1_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_0_1;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_0_2(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_0_2, 0, 2);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_0_2_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_0_2;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_0_3(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_0_3, 0, 3);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_0_3_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_0_3;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_1_0(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_1_0, 1, 0);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_1_0_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_1_0;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_1_1(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_1_1, 1, 1);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_1_1_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_1_1;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_1_2(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_1_2, 1, 2);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_1_2_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_1_2;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_1_3(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_1_3, 1, 3);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_1_3_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_1_3;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_2_0(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_2_0, 2, 0);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_2_0_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_2_0;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_2_1(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_2_1, 2, 1);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_2_1_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_2_1;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_2_2(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_2_2, 2, 2);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_2_2_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_2_2;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_2_3(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_2_3, 2, 3);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_2_3_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_2_3;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_3_0(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_3_0, 3, 0);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_3_0_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_3_0;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_3_1(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_3_1, 3, 1);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_3_1_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_3_1;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_3_2(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_3_2, 3, 2);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_3_2_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_3_2;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        private void Matrix_3_3(object sender, RoutedEventArgs e)
        {
            GiveContent(matrix_3_3, 3, 3);
            counterTextBox.Text = movesCount.ToString();
        }

        private void Matrix_3_3_Right(object sender, MouseEventArgs e)
        {
            Button button = matrix_3_3;

            if (button.Content == null)
            {
                PaintButtonValue(button, flag);
            }
            else
            {
                button.Content = null;
            }
        }

        /// <summary>
        /// Restart Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Restart(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// View Help
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewHelp(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Width = Application.Current.MainWindow.Width * 2;
            window.Height = Application.Current.MainWindow.Height;
            
            Uri iconUri = new Uri("pack://application:,,/Images/Icon.png", UriKind.RelativeOrAbsolute);
            window.Icon = BitmapFrame.Create(iconUri);

            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };

            stackPanel.Children.Add(new Label { Content = "Help about Minesweeper" });
            stackPanel.Children.Add(new Label { Content = "You have to finish the game without getting the given mines." });
            stackPanel.Children.Add(new Label { Content = "You have a time clock which shows the time you are playing the level." });
            stackPanel.Children.Add(new Label { Content = "If you win you get additional window showing the moves and the time you have spent to finish the level." });
            stackPanel.Children.Add(new Label { Content = "Enjoy! :)" });

            window.Content = stackPanel;
            window.Show();
        }
    }
}
