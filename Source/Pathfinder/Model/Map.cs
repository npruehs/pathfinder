// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Map.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Model
{
    /// <summary>
    /// Map to find paths on.
    /// </summary>
    public class Map
    {
        #region Fields

        /// <summary>
        /// Width and height of this map, in tiles.
        /// </summary>
        private readonly int size;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs and initializes a new map with the
        /// specified width and height.
        /// </summary>
        /// <param name="size">
        /// Width and height of the new map, in tiles.
        /// </param>
        public Map(int size)
        {
            this.size = size;

            this.Reset();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Finish of the path to find.
        /// </summary>
        public MapTile Finish { get; set; }

        /// <summary>
        /// Width and height of this map, in tiles.
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        /// <summary>
        /// Start of the path to find.
        /// </summary>
        public MapTile Start { get; set; }

        /// <summary>
        /// Total number of map tiles.
        /// </summary>
        public int TileCount
        {
            get
            {
                return this.Tiles.Length;
            }
        }

        /// <summary>
        /// Tiles that make up this map.
        /// </summary>
        public MapTile[] Tiles { get; private set; }

        #endregion

        #region Public Indexers

        /// <summary>
        /// Gets the map tile with the specified coordinates.
        /// </summary>
        /// <param name="x">X-coordinate of the map tile to get.</param>
        /// <param name="y">Y-coordinate of the map tile to get.</param>
        /// <returns>Map tile with the specified coordinates.</returns>
        public MapTile this[int x, int y]
        {
            get
            {
                return this[this.CoodinatesToIndex(x, y)];
            }
        }

        /// <summary>
        /// Gets the map tile with the specified index.
        /// </summary>
        /// <param name="index">Index of the map tile to get.</param>
        /// <returns>Map tile with the specified index.</returns>
        public MapTile this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Tiles.Length)
                {
                    return null;
                }

                return this.Tiles[index];
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the index of the map tile at the specified coordinates.
        /// </summary>
        /// <param name="x">X-coordinate of the tile to get the index of.</param>
        /// <param name="y">Y-coordinate of the tile to get the index of.</param>
        /// <returns>Index of the map tile at the specified coordinates.</returns>
        public int CoodinatesToIndex(int x, int y)
        {
            return (this.size * y) + x;
        }

        /// <summary>
        /// Gets the x-coordinate of the map tile with the specified index.
        /// </summary>
        /// <param name="index">
        /// Index of the tile to get the x-coordinate of.
        /// </param>
        /// <returns>
        /// X-coordinate of the tile with the specified index.
        /// </returns>
        public int IndexToXCoordinate(int index)
        {
            return index % this.size;
        }

        /// <summary>
        /// Gets the y-coordinate of the map tile with the specified index.
        /// </summary>
        /// <param name="index">
        /// Index of the tile to get the y-coordinate of.
        /// </param>
        /// <returns>
        /// Y-coordinate of the tile with the specified index.
        /// </returns>
        public int IndexToYCoordinate(int index)
        {
            return index / this.size;
        }

        /// <summary>
        /// Returns <c>true</c>, if the map tile at the specified position
        /// is walkable, and <c>false</c> otherwise.
        /// </summary>
        /// <param name="x">X-coordinate of the tile to check.</param>
        /// <param name="y">Y-coordinate of the tile to check.</param>
        /// <returns>
        /// <c>true</c>, if the map tile at the specified position
        /// is walkable, and <c>false</c> otherwise.
        /// </returns>
        public bool IsTileWalkable(int x, int y)
        {
            return this.Tiles[this.CoodinatesToIndex(x, y)].IsWalkable;
        }

        /// <summary>
        /// Initializes this map with walkable tiles.
        /// </summary>
        public void Reset()
        {
            this.Tiles = new MapTile[this.size * this.size];
            var index = 0;

            for (var y = 0; y < this.size; y++)
            {
                for (var x = 0; x < this.size; x++)
                {
                    this.Tiles[index] = new MapTile(index, x, y);
                    index++;
                }
            }
        }

        /// <summary>
        /// Marks the map tile at the specified position as walkable or un-walkable.
        /// </summary>
        /// <param name="x">X-coordinate of the tile to mark.</param>
        /// <param name="y">Y-coordinate of the tile to mark.</param>
        /// <param name="walkable">
        /// Whether to mark the specified tile as walkable, or not.
        /// </param>
        public void SetTileWalkable(int x, int y, bool walkable)
        {
            this.Tiles[this.CoodinatesToIndex(x, y)].IsWalkable = walkable;
        }

        #endregion
    }
}