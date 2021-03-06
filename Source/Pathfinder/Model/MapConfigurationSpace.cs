﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapConfigurationSpace.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Npruehs.GrabBag.RapidlyExploringRandomTrees;
    using Npruehs.GrabBag.Util;

    /// <summary>
    /// Configuration space representing a pathfinder map.
    /// </summary>
    public class MapConfigurationSpace : IConfigurationSpace<MapTile, List<MapTile>>
    {
        #region Constants

        /// <summary>
        /// Probability of returning the finish instead of a random map
        /// tile when determining the direction to grow the
        /// random tree towards.
        /// </summary>
        private const double CoinHeadsProbability = 0.05f;

        /// <summary>
        /// Maximum distance between two vertices of the random tree.
        /// </summary>
        private const int StepSize = 5;

        #endregion

        #region Fields

        /// <summary>
        /// Pseudo-random number generator used for picking random
        /// directions to grow the random tree towards.
        /// </summary>
        private readonly Random2 random;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new configuration space from the specified map.
        /// </summary>
        /// <param name="map">Map to build the configuration space from.</param>
        public MapConfigurationSpace(Map map)
        {
            this.Map = map;
            this.random = new Random2();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Map represented by this configuration space.
        /// </summary>
        public Map Map { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the distance between the specified map tiles.
        /// </summary>
        /// <param name="first">First map tile to get the distance of.</param>
        /// <param name="second">Second map tile to get the distance of.</param>
        /// <returns>Distance between the specified map tiles.</returns>
        public IComparable GetDistance(MapTile first, MapTile second)
        {
            return first.Pos.Distance(second.Pos);
        }

        /// <summary>
        /// Gets a random map tile to grow the random tree towards.
        /// </summary>
        /// <returns>Random map tile to grow the random tree towards.</returns>
        public MapTile GetRandomState()
        {
            // Toss a coin.
            if (this.random.NextDouble() < CoinHeadsProbability)
            {
                // Heads! Return goal tile.
                return this.Map.Finish;
            }

            // Tails! Return random tile.
            return this.Map[this.random.NextInt32(this.Map.Size * this.Map.Size)];
        }

        /// <summary>
        /// Makes a motion <paramref name="uNew"/> from <paramref name="q"/>
        /// towards <paramref name="qNear"/>, resulting in a new state
        /// <paramref name="qNew"/>.
        /// </summary>
        /// <param name="q">Start tile to make the motion from.</param>
        /// <param name="qNear">Tile to make the motion towards.</param>
        /// <param name="qNew">New state that has been reached with the motion.</param>
        /// <param name="uNew">Motion made.</param>
        /// <returns><c>true</c>, if any motion has been made, and <c>false</c> otherwise.</returns>
        public bool NewState(MapTile q, MapTile qNear, out MapTile qNew, out List<MapTile> uNew)
        {
            // Get the direction to make a motion in.
            var dirX = Math.Sign(q.Pos.X - qNear.Pos.X);
            var dirY = Math.Sign(q.Pos.Y - qNear.Pos.Y);

            // Compute the motion to make, with maximum length of step size.
            var dX = Math.Min(Math.Abs(q.Pos.X - qNear.Pos.X), StepSize) * dirX;
            var dY = Math.Min(Math.Abs(q.Pos.Y - qNear.Pos.Y), StepSize) * dirY;

            // Get the index of the target map tile.
            qNew = this.Map[qNear.Pos.X + dX, qNear.Pos.Y + dY];

            // Early out if target tile is invalid.
            if (qNew == null)
            {
                uNew = new List<MapTile>();
                return false;
            }

            // Compute a line from qNear to the target map tile.
            uNew = this.Bresenham(qNear, qNew);

            return uNew.Count > 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Uses Bresenham's line algorithm to find a connected set of map
        /// tiles between t0 and t1. Returns that line, if there is one that
        /// is entirely walkable on this map, and an empty list otherwise.
        /// </summary>
        /// <param name="t0">
        /// Tile to start drawing at.
        /// </param>
        /// <param name="t1">
        /// Tile to finish drawing at.
        /// </param>
        /// <returns>
        /// Line between t0 and t1, if there is one that is entirely walkable
        /// on this map, and an empty list otherwise.
        /// </returns>
        private List<MapTile> Bresenham(MapTile t0, MapTile t1)
        {
            // Get line approximation.
            var line = Npruehs.GrabBag.Math.Bresenham.Plot(t0.Pos, t1.Pos);

            // Check if all tiles are walkable.
            var tiles = new List<MapTile>();

            foreach (var tile in line.Select(pos => this.Map[pos.X, pos.Y]))
            {
                if (tile.IsWalkable)
                {
                    tiles.Add(tile);
                }
                else
                {
                    tiles.Clear();
                    return tiles;
                }
            }

            return tiles;
        }

        #endregion
    }
}