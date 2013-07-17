// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AStarPathfinder.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control.Pathfinders
{
    using System.Collections.Generic;

    using Npruehs.GrabBag.ShortestPaths.AStar;

    using Pathfinder.Model;

    /// <summary>
    ///     A* pathfinder illustrated with this tool.
    /// </summary>
    public class AStarPathfinder : IPathfinder
    {
        #region Public Methods and Operators

        /// <summary>
        /// Calculates the path from start to finish on the specified map.
        /// </summary>
        /// <param name="map">
        /// Map to find the path on.
        /// </param>
        /// <param name="path">
        /// Path from start to finish on the specified map.
        /// </param>
        /// <param name="visitedTiles">
        /// Map tiles that have been visited looking for the shortest path.
        /// </param>
        /// <returns>
        /// <c>True</c>, if a path could be found, and <c>false</c> otherwise.
        /// </returns>
        public bool CalculatePath(Map map, out List<MapTile> path, out IList<MapTile> visitedTiles)
        {
            var mapGraph = new MapGraph(map);

            // Reset A*.
            foreach (var tile in map.Tiles)
            {
                tile.Discovered = false;
                tile.Visited = false;
            }

            path = AStar.FindPath(mapGraph.Graph, map.Start, map.Finish, out visitedTiles);
            return path != null;
        }

        #endregion
    }
}