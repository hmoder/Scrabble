//-----------------------------------------------------------------------
// <copyright file="Bag.cs" company="NWTC">
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
    /// Interaction logic for Bag.cs
    /// </summary>
    public class Bag
    {
        /// <summary>
        /// The bag of tiles
        /// </summary>
        private List<Tile> tiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bag" /> class.
        /// </summary>
        public Bag()
        {
            this.Tiles = new List<Tile>();
            this.AddTile('a', 1, 9, "pack://application:,,,/Images/Tiles/A.png");
            this.AddTile('b', 3, 2, "pack://application:,,,/Images/Tiles/B.png");
            this.AddTile('c', 3, 2, "pack://application:,,,/Images/Tiles/C.png");
            this.AddTile('d', 2, 4, "pack://application:,,,/Images/Tiles/D.png");
            this.AddTile('e', 1, 12, "pack://application:,,,/Images/Tiles/E.png");
            this.AddTile('f', 4, 2, "pack://application:,,,/Images/Tiles/F.png");
            this.AddTile('g', 2, 3, "pack://application:,,,/Images/Tiles/G.png");
            this.AddTile('h', 4, 2, "pack://application:,,,/Images/Tiles/H.png");
            this.AddTile('i', 1, 9, "pack://application:,,,/Images/Tiles/I.png");
            this.AddTile('j', 8, 1, "pack://application:,,,/Images/Tiles/J.png");
            this.AddTile('k', 5, 1, "pack://application:,,,/Images/Tiles/K.png");
            this.AddTile('l', 1, 4, "pack://application:,,,/Images/Tiles/L.png");
            this.AddTile('m', 3, 2, "pack://application:,,,/Images/Tiles/M.png");
            this.AddTile('n', 1, 6, "pack://application:,,,/Images/Tiles/N.png");
            this.AddTile('o', 1, 6, "pack://application:,,,/Images/Tiles/O.png");
            this.AddTile('p', 3, 2, "pack://application:,,,/Images/Tiles/P.png");
            this.AddTile('q', 10, 1, "pack://application:,,,/Images/Tiles/Q.png");
            this.AddTile('r', 1, 8, "pack://application:,,,/Images/Tiles/R.png");
            this.AddTile('s', 1, 4, "pack://application:,,,/Images/Tiles/S.png");
            this.AddTile('t', 1, 6, "pack://application:,,,/Images/Tiles/T.png");
            this.AddTile('u', 1, 4, "pack://application:,,,/Images/Tiles/U.png");
            this.AddTile('v', 4, 2, "pack://application:,,,/Images/Tiles/V.png");
            this.AddTile('w', 4, 2, "pack://application:,,,/Images/Tiles/W.png");
            this.AddTile('x', 8, 1, "pack://application:,,,/Images/Tiles/X.png");
            this.AddTile('y', 4, 2, "pack://application:,,,/Images/Tiles/Y.png");
            this.AddTile('z', 10, 1, "pack://application:,,,/Images/Tiles/Z.png");
            this.AddTile(' ', 0, 2, "pack://application:,,,/Images/Tiles/blank.png");
        }

        /// <summary>
        /// Gets or sets the values for the Tiles list.
        /// </summary>
        public List<Tile> Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }

        /// <summary>
        /// Adds a tile to a bag.
        /// </summary>
        /// <param name="letter">The letter of the tile.</param>
        /// <param name="value">The point value of the tile.</param>
        /// <param name="count">The number of times to add the tile.</param>
        /// <param name="path">The path to the image file.</param>
        public void AddTile(char letter, int value, int count, string path)
        {
            // Runs a loop to add number of same tile to bag
            for (int i = 0; i < count; i++)
            {
                this.Tiles.Add(new Tile(letter, value, path));
            }
        }

        /// <summary>
        /// Draws and returns tile.
        /// </summary>
        /// <returns>The drawn tile.</returns>
        /// <param name="rand">Random number</param>
        public Tile DrawTile(Random rand)
        {
            // Variable to hold random tile
            Tile randomTile;
            int r = rand.Next(this.Tiles.Count);

            // Find random tile in list and set to variable
            randomTile = this.Tiles[r];

            // Remove tile from bag
            this.Tiles.Remove(randomTile);

            // Return random tile
            return randomTile;
        }
    }
}
