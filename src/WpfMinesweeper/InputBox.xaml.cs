// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputBox.xaml.cs" company="Telerik Academy">
//   Teamwork Project "Minesweeper-6"
// </copyright>
// <summary>
//   Interaction logic for InputBox.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfMinesweeper
{
    using System;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for InputBox...
    /// </summary>
    public partial class InputBox : Window
    {
        /// <summary>
        /// The player name delegate.
        /// </summary>
        private readonly Action<string> playerNameDelegate;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputBox"/> class.
        /// </summary>
        /// <param name="playerNameDelegate">
        /// The player name delegate.
        /// </param>
        public InputBox(Action<string> playerNameDelegate)
        {
            this.InitializeComponent();
            this.playerNameDelegate = playerNameDelegate;
        }

        /// <summary>
        /// The cancel button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The click event.
        /// </param>
        private void CancelButtonClick(object sender, RoutedEventArgs e)
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
        /// The click event.
        /// </param>
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            // Input validations            
            this.playerNameDelegate(this.NameTextBox.Text);

            this.Close();
        }
    }
}
