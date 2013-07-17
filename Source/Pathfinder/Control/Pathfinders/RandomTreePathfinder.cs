// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomTreePathfinder.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control.Pathfinders
{
    using System.Collections.Generic;

    using Npruehs.GrabBag.RapidlyExploringRandomTrees;

    using Pathfinder.Model;

    /// <summary>
    ///     Random tree pathfinder illustrated with this tool.
    /// </summary>
    public class RandomTreePathfinder : IPathfinder
    {
        #region Constants

        /// <summary>
        /// Maximum number of configurations to explore while trying to
        /// find a path from start to finish.
        /// </summary>
        private const int ConfigurationCount = 20000;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Calculates the path from start to finish on the specified map.
        /// </summary>
        /// <param name="map">Map to find the path on.</param>
        /// <param name="path">Path from start to finish on the specified map.</param>
        /// <param name="visitedTiles">Map tiles that have been visited looking for the shortest path.</param>
        /// <returns>
        ///     <c>True</c>, if a path could be found, and <c>false</c> otherwise.
        /// </returns>
        public bool CalculatePath(Map map, out List<MapTile> path, out IList<MapTile> visitedTiles)
        {
            // Grow new RRT from start to finish.
            var t = new RapidlyExploringRandomTree<MapTile, List<MapTile>>();
            var c = new MapConfigurationSpace(map);

            t.GrowTree(c, map.Start, ConfigurationCount);

            // Get visited tiles from tree edges.
            path = new List<MapTile>();
            visitedTiles = new List<MapTile>();

            foreach (RapidlyExploringRandomTreeEdge<MapTile, List<MapTile>> e in t.Edges)
            {
                foreach (var tile in e.Input)
                {
                    path.Add(tile);
                    visitedTiles.Add(tile);
                }
            }

            return path.Contains(map.Start);
        }

        #endregion
    }
}