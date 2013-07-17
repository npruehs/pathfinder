// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapTile.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Model
{
    using System;

    using Npruehs.GrabBag.Math.Vectors;
    using Npruehs.GrabBag.ShortestPaths.AStar;
    using Npruehs.GrabBag.ShortestPaths.Dijkstra;

    /// <summary>
    /// Tile of a map to find paths on.
    /// </summary>
    public class MapTile : IAStarNode, IDijkstraNode
    {
        #region Fields

        /// <summary>
        /// Unique index of this map tile.
        /// </summary>
        private readonly int index;

        /// <summary>
        /// Position of this tile on the map.
        /// </summary>
        private readonly Vector2I pos;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new map tile with the specified unique index
        /// and the passed coordinates.
        /// </summary>
        /// <param name="index">Unique index of the new map tile.</param>
        /// <param name="x">X-coordinate of the new map tile.</param>
        /// <param name="y">Y-coordinate of the new map tile.</param>
        public MapTile(int index, int x, int y)
        {
            this.index = index;
            this.pos = new Vector2I(x, y);
            this.IsWalkable = true;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Whether this tile has been discovered by the A* algorithm.
        /// </summary>
        public bool Discovered { get; set; }

        /// <summary>
        /// A* F score of this tile.
        /// </summary>
        public int F { get; set; }

        /// <summary>
        /// A* G score of this tile.
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// A* H score of this tile.
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// Unique index of this map tile.
        /// </summary>
        public int Index
        {
            get
            {
                return this.index;
            }
        }

        /// <summary>
        /// Whether this tile is walkable or not.
        /// </summary>
        public bool IsWalkable { get; set; }

        /// <summary>
        /// Predecessor tile on the path A* found from start to finish.
        /// </summary>
        public IAStarNode ParentNode { get; set; }

        /// <summary>
        /// Position of this tile on the map.
        /// </summary>
        public Vector2I Pos
        {
            get
            {
                return this.pos;
            }
        }

        /// <summary>
        /// Predecessor tile on the path Dijkstra found from start to finish.
        /// </summary>
        public IDijkstraNode Predecessor { get; set; }

        /// <summary>
        /// Whether this node has already been visited by A*, or not.
        /// </summary>
        public bool Visited { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Returns the Manhattan distance from this tile to the target.
        /// </summary>
        /// <param name="target">Target to compute the distance to.</param>
        /// <returns>Manhattan distance from this tile to the target.</returns>
        public int EstimateHeuristicMovementCost(IAStarNode target)
        {
            var targetTile = (MapTile)target;
            return Math.Abs(targetTile.Pos.X - this.Pos.X) + Math.Abs(targetTile.Pos.Y - this.Pos.Y);
        }

        #endregion
    }
}