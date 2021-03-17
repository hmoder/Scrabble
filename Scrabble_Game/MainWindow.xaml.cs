//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="NWTC">
//     Copyright (c) Knudson, Hoffman, Trofka, Moder
// </copyright>
//-----------------------------------------------------------------------

namespace Scrabble_Game
{
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Enables visibility of the tile marker when mouse focus on the Start Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void StartLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.focusTile1.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Disables visibility of the tile marker when mouse focus on the Start Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void StartLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.focusTile1.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Enables visibility of the tile marker when mouse focus on the About Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void AboutLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.focusTile2.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Disables visibility of the tile marker when mouse focus on the About Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void AboutLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.focusTile2.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Enables visibility of the tile marker when mouse focus on the Exit Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ExitLbl_MouseEnter(object sender, MouseEventArgs e)
        {
            this.focusTile3.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Disables visibility of the tile marker when mouse focus on the Exit Label
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ExitLbl_MouseLeave(object sender, MouseEventArgs e)
        {
            this.focusTile3.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Displays About Scramble message box when clicked
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void AboutLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(
                "Scrabble\r\n" +
                "Version 8.2\r\n\r\n" +
                "This version of Scrabble was developed by:\r\n" +
                "Christine Knudson\r\n" +
                "Vicky Trofka\r\n" +
                "Derrick Hoffman\r\n" +
                "Hannah Moder\r\n\r\n" +
                "Copyright 2020",
                "About Scrabble");
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ExitLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Displays player selection combo box
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void StartLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Make combo box visible
            this.playerSelectComboBox.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Starts a new game and opens GameWindow with number of players
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void PlayerSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selection = this.playerSelectComboBox.SelectedIndex;
            
            if (selection == 1 || selection == 2 || selection == 3 || selection == 4)
            {
                // Instantiate and show game window
                GameWindow newGame = new GameWindow(selection);
                newGame.ShowDialog();
            }
        }
    }
}
