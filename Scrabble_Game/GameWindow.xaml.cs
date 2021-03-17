//-----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="NWTC">
//     Copyright (c) Knudson, Hoffman, Trofka, Moder
// </copyright>
//-----------------------------------------------------------------------

namespace Scrabble_Game
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for GameWindow.xaml.cs
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// The tile selected
        /// </summary>
        private FrameworkElement element;

        /// <summary>
        /// The turn count
        /// </summary>
        private int turnCount;

        /// <summary>
        /// The last tile spot
        /// </summary>
        private int lastSpot;

        /// <summary>
        /// Boolean to represent successful drop
        /// </summary>
        private bool dropSuccess;

        /// <summary>
        /// The bag of tiles
        /// </summary>
        private Bag tileBag;

        /// <summary>
        /// The bag of tiles
        /// </summary>
        private Bag referenceBag;

        /// <summary>
        /// The player of the game
        /// </summary>
        private Player myPlayer;

        /// <summary>
        /// The players of the game
        /// </summary>
        private List<Player> players;

        /// <summary>
        /// Array to hold spot numbers.
        /// </summary>
        private Spot[] spots;

        /// <summary>
        /// The word being played horizontally
        /// </summary>
        private List<char> horzWord;

        /// <summary>
        /// The word being played vertical word
        /// </summary>
        private List<char> vertWord;

        /// <summary>
        /// The spots of the played tiles
        /// </summary>
        private List<int> playedTileSpots;

        /// <summary>
        /// The blank tile letter
        /// </summary>
        private char blankTileLetter;

        /// <summary>
        /// The blank tile spot
        /// </summary>
        private int blankTileSpot;

        /// <summary>
        /// The image sources of the played tiles
        /// </summary>
        private List<string> playedTileSources;

        /// <summary>
        /// The array of triple word score spots
        /// </summary>
        private int[] tripWordSpots;

        /// <summary>
        /// The array of double word score spots
        /// </summary>
        private int[] dblWordSpots;

        /// <summary>
        /// The array of triple letter score spots
        /// </summary>
        private int[] tripLetterSpots;

        /// <summary>
        /// The array of double letter score spots
        /// </summary>
        private int[] dblLetterSpots;

        /// <summary>
        /// The spots of the letters played
        /// </summary>
        private List<int> letterLocations;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow"/> class.
        /// </summary>
        /// <param name="numPlayers">The number of players.</param>
        public GameWindow(int numPlayers)
        {
            this.InitializeComponent();
            this.tileBag = new Bag();
            this.turnCount = 1;
            this.blankTileLetter = '\0';
            this.blankTileSpot = '\0';
            this.dropSuccess = false;
            this.referenceBag = new Bag();
            this.myPlayer = new Player();
            this.players = new List<Player>();
            this.element = new FrameworkElement();
            this.spots = new Spot[225];
            this.BuildRectangles();
            this.horzWord = new List<char>();
            this.vertWord = new List<char>();
            this.playedTileSources = new List<string>();
            this.playedTileSpots = new List<int>();
            this.tripWordSpots = new int[] { 0, 7, 14, 105, 119, 210, 217, 224 };
            this.dblWordSpots = new int[] { 16, 28, 32, 42, 48, 56, 64, 70, 154, 160, 168, 176, 182, 192, 196, 208 };
            this.tripLetterSpots = new int[] { 20, 24, 76, 80, 84, 88, 136, 140, 144, 148, 200, 204 };
            this.dblLetterSpots = new int[] { 3, 11, 36, 38, 45, 52, 59, 92, 96, 98, 102, 108, 116, 122, 126, 128, 132, 165, 172, 179, 186, 188, 213, 221 };

            // Add players to list
            for (int i = 0; i < numPlayers; i++)
            {
                Player newPlayer = new Player();
                this.players.Add(newPlayer);
            }

            // Show score labels
            if (numPlayers == 2)
            {
                p2Lbl.Visibility = Visibility.Visible;
                p2ScoreLbl.Visibility = Visibility.Visible;
            }
            else
            {
                if (numPlayers == 3)
                {
                    p2Lbl.Visibility = Visibility.Visible;
                    p2ScoreLbl.Visibility = Visibility.Visible;
                    p3Lbl.Visibility = Visibility.Visible;
                    p3ScoreLbl.Visibility = Visibility.Visible;
                }
                else
                {
                    if (numPlayers == 4)
                    {
                        p2Lbl.Visibility = Visibility.Visible;
                        p2ScoreLbl.Visibility = Visibility.Visible;
                        p3Lbl.Visibility = Visibility.Visible;
                        p3ScoreLbl.Visibility = Visibility.Visible;
                        p4Lbl.Visibility = Visibility.Visible;
                        p4ScoreLbl.Visibility = Visibility.Visible;
                    }
                }
            }

            // Start with Player 1
            this.myPlayer = this.players[0];
        }

        /// <summary>
        /// Wiggles the bag, draws tiles, fills tray, and adds images to board
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private async void TileBagImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Wiggles the bag
            RotateTransform rotateForward = new RotateTransform(20);
            RotateTransform rotateBackward = new RotateTransform(-20);
            RotateTransform rotateToOrigin = new RotateTransform(0);
            this.tileBagImg.RenderTransform = rotateForward;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateToOrigin;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateBackward;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateToOrigin;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateForward;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateToOrigin;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateBackward;
            await Task.Delay(200);
            this.tileBagImg.RenderTransform = rotateToOrigin;

            // Clear lists
            this.horzWord.Clear();
            this.vertWord.Clear();
            this.playedTileSpots.Clear();
            this.playedTileSources.Clear();
            this.myPlayer.TilesInPlay.Clear();

            //// Image list variable
            List<Image> tileImages;

            // Fill the tray and return images
            tileImages = this.myPlayer.FillTray(this.tileBag);

            // Add click and move events and add to gameboard
            foreach (Image i in tileImages)
            {
                i.MouseDown += this.ATile_MouseDown;
                i.MouseMove += this.ATile_MouseMove;
                i.MouseLeftButtonUp += this.Tile_MouseLeftButtonUp;
                i.MouseRightButtonUp += this.ATile_MouseRightButtonUp;
                boardGrid.Children.Add(i);
                this.myPlayer.PlayerImages.Add(i);
            }

            // Change instruction label
            guideTxtBlk.Text = "Drag tiles onto board to make words! You can right click to remove tiles from the board.";
        }

        /// <summary>
        /// Builds invisible rectangles
        /// </summary>
        private void BuildRectangles()
        {
            Rectangle spot;
            int rowCount = 1;
            int colCount = 1;

            while (colCount <= this.spotGrid.Columns)
            {
                rowCount = 1;

                while (rowCount <= this.spotGrid.Rows)
                {
                    spot = new Rectangle() { Height = 35, Width = 35 };
                    spot.Opacity = 0;
                    spot.VerticalAlignment = VerticalAlignment.Center;
                    spot.HorizontalAlignment = HorizontalAlignment.Center;
                    spot.Stroke = Brushes.Black;
                    spot.AllowDrop = true;
                    spot.Drop += this.Spot_Drop;
                    spot.Fill = new SolidColorBrush(System.Windows.Media.Colors.White);
                    rowCount++;
                    this.spotGrid.Children.Add(spot);
                }

                colCount++;
            }

            // Fills the array for spot checking
            for (int i = 0; i < this.spots.Length; i++)
            {
                Spot newSpot = new Spot(i);
                this.spots[i] = newSpot;
            }
        }

        /// <summary>
        /// Logic for drop
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void Spot_Drop(object sender, DragEventArgs e)
        {
            Rectangle spot = sender as Rectangle;
            if (spot != null)
            {
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    ImageSource imgSrc = new ImageSourceConverter().ConvertFromString(dataString) as ImageSource;
                    ImageBrush newFill = new ImageBrush(imgSrc);
                    spot.Fill = newFill;
                    spot.Opacity = 1;
                    SolidColorBrush borderBrush = new SolidColorBrush(Colors.LimeGreen);
                    spot.StrokeThickness = 4;
                    spot.Stroke = borderBrush;
                    spot.AllowDrop = false;
                    spot.MouseRightButtonUp += this.ATile_MouseRightButtonUp;

                    this.lastSpot = spotGrid.Children.IndexOf(spot);
                    this.playedTileSpots.Add(this.lastSpot);

                    // Check for blank tile
                    if (dataString == this.referenceBag.Tiles[99].ImgPath)
                    {
                        this.blankTileSelectBox.IsEnabled = true;
                        this.blankTileSelectBox.Visibility = Visibility.Visible;
                        this.pickLbl.Visibility = Visibility.Visible;
                        this.blankTileSpot = this.lastSpot;
                    }
                    else
                    {
                        this.SetSpotLetter(dataString, false);
                    }
                }

                this.dropSuccess = true;
            }

            // Change guide label
            guideTxtBlk.Text = "Click the Play Word button when you've finished creating your word or to pass";
        }

        /// <summary>
        /// Mouse Enter for spots
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void Spot_MouseEnter(object sender, MouseEventArgs e)
        {
            ////
        }

        /// <summary>
        /// Mouse Left Button Up
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void Tile_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            ////
        }

        /// <summary>
        /// Logic for reset button
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Closes the program
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the program
            this.Close();
        }

        /// <summary>
        /// Registers a mouse click and finds location
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ATile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.dropSuccess = false;

            Image img = (Image)sender;
            DragDrop.DoDragDrop(img, img.Source.ToString(), DragDropEffects.Copy);

            if (this.dropSuccess == true)
            {
                this.myPlayer.AddPlayedTile(img.Margin.Left);
                this.myPlayer.RemoveTile(img.Margin.Left);
                boardGrid.Children.Remove(img);

                // Remove image from player's list
                this.myPlayer.PlayerImages.Remove(img);

                // Hide bag and label, show Play Word button
                this.playWordBtn.Visibility = Visibility.Visible;
                this.tileBagImg.Visibility = Visibility.Hidden;
                this.bagLbl.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Moves the tile based on mouse location
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ATile_MouseMove(object sender, MouseEventArgs e)
        {
            ////
        }

        /// <summary>
        /// Finds chars and adds to word list
        /// </summary>
        /// <param name="imgSrc">The image source path.</param>
        /// <param name="sNum">The spot number.</param>
        private void BuildWord(string imgSrc, int sNum)
        {
            int i = 0;

            while (i < this.tileBag.Tiles.Count)
            {
                if (imgSrc == this.tileBag.Tiles[i].ImgPath)
                {
                    char letter = this.tileBag.Tiles[i].Letter;

                    this.spots[sNum].Letter = letter;

                    break;
                }

                i++;
            }
        }

        /// <summary>
        /// Interaction logic for the Play Word button.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool isValidX = this.CheckHorizontal(this.lastSpot);

            if (isValidX)
            {
                // Check points
                int points = this.GetPoints();
                this.myPlayer.Points += points;

                try
                {
                    p1ScoreLbl.Content = this.players[0].Points.ToString();
                    p2ScoreLbl.Content = this.players[1].Points.ToString();
                    p3ScoreLbl.Content = this.players[2].Points.ToString();
                    p4ScoreLbl.Content = this.players[3].Points.ToString();
                }
                catch
                {
                    ////
                }
            }

            bool isValidY = this.CheckVertical(this.lastSpot);

            if (isValidY)
            {
                // Check points
                int points = this.GetPoints();
                this.myPlayer.Points += points;

                try
                {
                    p1ScoreLbl.Content = this.players[0].Points.ToString();
                    p2ScoreLbl.Content = this.players[1].Points.ToString();
                    p3ScoreLbl.Content = this.players[2].Points.ToString();
                    p4ScoreLbl.Content = this.players[3].Points.ToString();
                }
                catch
                {
                    ////
                }
            }

            if (isValidX == false && isValidY == false)
            {
                // Show error message
                MessageBox.Show("I'm sorry, Dave. I'm afraid I can't do that.\r\n" +
                                 "Your word was invalid.\r\n" +
                                 "You lose your turn.");

                // Remove from board
                foreach (Rectangle r in spotGrid.Children)
                {
                    if (r.StrokeThickness == 4)
                    {
                        r.StrokeThickness = 0;
                        r.Opacity = 0;
                        r.AllowDrop = true;
                        this.spots[spotGrid.Children.IndexOf(r)].Letter = '\0';
                    }
                }

                // Fill tray with images from played tile
                List<Image> tileImages = new List<Image>();
                tileImages = this.myPlayer.FillTray(this.myPlayer.TilesInPlay);

                // Add click and move events and add to gameboard
                foreach (Image i in tileImages)
                {
                    i.MouseDown += this.ATile_MouseDown;
                    i.MouseMove += this.ATile_MouseMove;
                    i.MouseLeftButtonUp += this.Tile_MouseLeftButtonUp;
                    i.MouseRightButtonUp += this.ATile_MouseRightButtonUp;
                    boardGrid.Children.Add(i);
                    this.myPlayer.PlayerImages.Add(i);
                }

                // Reset blank tile
                this.ResetBlankTile();
            }

            // Remove borders
            foreach (Rectangle spot in spotGrid.Children)
            {
                spot.StrokeThickness = 0;
            }

            // Remove tile images from tray image
            foreach (Image i in this.myPlayer.PlayerImages)
            {
                boardGrid.Children.Remove(i);
            }

            // Increment turn counter
            if (this.turnCount != this.players.Count)
            {
                this.turnCount++;
            }
            else
            {
                this.turnCount = 1;
            }

            this.myPlayer = this.players[this.turnCount - 1];

            // Show bag and label, hide Play Word button
            this.playWordBtn.Visibility = Visibility.Hidden;
            this.tileBagImg.Visibility = Visibility.Visible;
            this.bagLbl.Visibility = Visibility.Visible;

            // Change labels
            guideTxtBlk.Text = "Player " + this.turnCount + ", click the bag to get your letters!";
            this.playerLbl.Content = "Player " + this.turnCount;

            // Flash player label
            SolidColorBrush lblBorder = new SolidColorBrush(Colors.Fuchsia);
            Thickness lblThickness = new Thickness(2);
            Thickness noThickness = new Thickness(0);

            this.playerLbl.BorderBrush = lblBorder;
            this.playerLbl.BorderThickness = lblThickness;
            await Task.Delay(400);
            this.playerLbl.BorderThickness = noThickness;
            await Task.Delay(300);
            this.playerLbl.BorderThickness = lblThickness;
            await Task.Delay(400);
            this.playerLbl.BorderThickness = noThickness;
            await Task.Delay(300);
            this.playerLbl.BorderThickness = lblThickness;
            await Task.Delay(400);
            this.playerLbl.BorderThickness = noThickness;

            // Add next player's tile images
            foreach (Image i in this.myPlayer.PlayerImages)
            {
                boardGrid.Children.Add(i);
            }
        }

        /// <summary>
        /// Checks for vertical words
        /// </summary>
        /// <param name="lSpot">The spot of the last tile played.</param>
        /// <returns>Returns boolean isValid.</returns>
        private bool CheckVertical(int lSpot)
        {
            this.letterLocations = new List<int>();
            string subY = string.Empty;
            int fSpot = 0;
            int i = lSpot;
            bool isValid;

            while ((i >= 0) && (this.spots[i].Letter != '\0'))
            {
                fSpot = i;
                i -= 15;
            }

            while (fSpot < this.spots.Length && this.spots[fSpot].Letter != '\0')
            {
                subY += this.spots[fSpot].Letter;
                this.letterLocations.Add(fSpot);
                fSpot += 15;
            }

            isValid = this.DictionaryCheck(subY);
            
            return isValid;
        }

        /// <summary>
        /// Checks for horizontal words
        /// </summary>
        /// <param name="lSpot">The spot of the last tile played.</param>
        /// <returns>Returns boolean isValid.</returns>
        private bool CheckHorizontal(int lSpot)
        {
            this.letterLocations = new List<int>();
            string subX = string.Empty;
            int fSpot = 0;
            int i = lSpot;
            bool isValid;

            while ((i >= 0) && (this.spots[i].Letter != '\0'))
            {
                fSpot = i;
                i--;
            }

            while ((fSpot < this.spots.Length) && (this.spots[fSpot].Letter != '\0'))
            {
                subX += this.spots[fSpot].Letter;                                           // Blank tile is keeping the value of the last
                this.letterLocations.Add(fSpot);                                            // selected index and not updating
                fSpot++;
            }

            isValid = this.DictionaryCheck(subX);
            
            return isValid;
        }

        /// <summary>
        /// Checks the word in the dictionary
        /// </summary>
        /// <param name="word">The word being checked.</param>
        /// <returns>Returns boolean isValid.</returns>
        private bool DictionaryCheck(string word)
        {
            bool isValid = false;
            word = word.ToUpper();

            StreamReader sr = new StreamReader("scrabbledictionary.txt");
            while (sr.EndOfStream == false)
            {
                string line = sr.ReadLine();

                if (word == line)
                {
                    isValid = true;
                    break;
                }
            }

            sr.Close();
            return isValid;
        }

        /// <summary>
        /// Determines the points of the words played
        /// </summary>
        /// <returns>Returns the total points for the player.</returns>
        private int GetPoints()
        {
            int totalPoints = 0;
            int letterPoints = 0;
            bool tripWord = false;
            bool dblWord = false;

            foreach (int s in this.letterLocations)
            {
                if (s != this.blankTileSpot)
                {
                    // Find intial letter points
                    for (int p = 0; p < this.referenceBag.Tiles.Count; p++)
                    {
                        if (this.spots[s].Letter == this.referenceBag.Tiles[p].Letter)
                        {
                            letterPoints = this.referenceBag.Tiles[p].PointValue;

                            // Check for double letter
                            foreach (int i in this.dblLetterSpots)
                            {
                                if (this.spots[s].SpotNum == i)
                                {
                                    letterPoints = letterPoints * 2;
                                }
                            }

                            // Check for triple letter
                            foreach (int j in this.tripLetterSpots)
                            {
                                if (this.spots[s].SpotNum == j)
                                {
                                    letterPoints = letterPoints * 3;
                                }
                            }

                            break;
                        }

                        totalPoints += letterPoints;
                    }
                }

                // Check for double word
                foreach (int k in this.dblWordSpots)
                {
                    if (this.spots[s].SpotNum == k)
                    {
                        dblWord = true;
                        break;
                    }
                }

                // Check for triple word
                foreach (int m in this.tripWordSpots)
                {
                    if (this.spots[s].SpotNum == m)
                    {
                        tripWord = true;
                        break;
                    }
                }

                // Add letter points to total word points
                totalPoints += letterPoints;
                letterPoints = 0;
            }

            // Multipliers
            if (dblWord == true)
            {
                totalPoints = totalPoints * 2;
            }

            if (tripWord == true)
            {
                totalPoints = totalPoints * 3;
            }

            return totalPoints;
        }

        /// <summary>
        /// Sets the spot letter
        /// </summary>
        /// <param name="src">The image source.</param>
        /// <param name="blank">The blank tile boolean.</param>
        private void SetSpotLetter(string src, bool blank)
        {
            // Check for blank letter
            if (blank == true)
            {
                this.spots[this.lastSpot].Letter = this.blankTileLetter;

                char[] letter = src.ToCharArray();

                this.spots[this.lastSpot].Letter = letter[0];
            }
            else
            {
                for (int i = 0; i < this.referenceBag.Tiles.Count; i++)
                {
                    if (src == this.referenceBag.Tiles[i].ImgPath)
                    {
                        this.spots[this.lastSpot].Letter = this.referenceBag.Tiles[i].Letter;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Interaction logic for the Blank Tile Select combo box.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void BlankTileSelectBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rectangle rect;

            if (this.blankTileSelectBox.SelectedIndex != 0)
            {
                string str = this.blankTileSelectBox.SelectedValue.ToString();

                str = str.ToLower();

                char[] letter = str.ToCharArray();

                this.blankTileLetter = letter[0];

                this.blankTileSelectBox.Visibility = Visibility.Hidden;
                this.pickLbl.Visibility = Visibility.Hidden;

                this.SetSpotLetter(str, true);

                // Change spot image
                for (int i = 0; i < this.referenceBag.Tiles.Count; i++)
                {
                    if (this.blankTileLetter == this.referenceBag.Tiles[i].Letter)
                    {
                        ImageSource imgSrc = new ImageSourceConverter().ConvertFromString(this.referenceBag.Tiles[i].ImgPath) as ImageSource;
                        ImageBrush newFill = new ImageBrush(imgSrc);
                        rect = (Rectangle)this.spotGrid.Children[this.blankTileSpot];
                        rect.Fill = newFill;
                    }
                }
            }
        }

        /// <summary>
        /// Resets blank tile values
        /// </summary>
        private void ResetBlankTile()
        {
            this.blankTileLetter = '\0';
            this.blankTileSpot = '\0';
            this.blankTileSelectBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Returns tile to tray on mouse right button up.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="e">The arguments.</param>
        private void ATile_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int removeGridLocation = 0;
            Image img;

            // Counter
            int i = 0;
            Rectangle spot = sender as Rectangle;
            removeGridLocation = spotGrid.Children.IndexOf(spot);

            while (i < this.myPlayer.TilesInPlay.Count)
            {
                // Find spot in location, and check if it was recently played using Border Thickness.
                if (removeGridLocation == this.playedTileSpots[i] && spot.StrokeThickness == 4)
                {
                    img = this.myPlayer.FillTray(this.myPlayer.TilesInPlay, i);

                    // Add Methods back to reset tile.
                    img.MouseDown += this.ATile_MouseDown;
                    img.MouseMove += this.ATile_MouseMove;
                    img.MouseLeftButtonUp += this.Tile_MouseLeftButtonUp;
                    img.MouseRightButtonUp += this.ATile_MouseRightButtonUp;
                    boardGrid.Children.Add(img);
                    this.myPlayer.PlayerImages.Add(img);

                    // Remove From Both Spot and Tile Lists
                    this.myPlayer.TilesInPlay.RemoveAt(i);
                    this.playedTileSpots.RemoveAt(i);

                    // Reset Spot to No Tile
                    spot.StrokeThickness = 0;
                    spot.Opacity = 0;
                    spot.AllowDrop = true;
                    this.spots[this.spotGrid.Children.IndexOf(spot)].Letter = '\0';

                    // Reset if blank tile
                    if (removeGridLocation == this.blankTileSpot)
                    {
                        this.ResetBlankTile();
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Determines if end game and finds the winner.
        /// </summary>
        private void EndGame()
        {
            // Variable for winning player number
            int winNum = 1;

            // If the tile bag is empty...
            if (this.tileBag.Tiles.Count == 0)
            {
                for (int i = 1; i < this.players.Count; i++)
                {
                    if (this.players[i].Points > this.players[i - 1].Points)
                    {
                        winNum = i + 1;
                    }
                }

                // Display congratulatory message
                MessageBox.Show("Congratulations,\r\n" +
                                "Player " + winNum + "!\r\n" +
                                "You are a Master Wordsmith!");
            }
        }
    }
}