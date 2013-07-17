// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DijkstraPathfinder.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control.Pathfinders
{
    using System.Collections.Generic;

    using Npruehs.GrabBag.ShortestPaths.Dijkstra;

    using Pathfinder.Model;

    /// <summary>
    ///     Dijkstra pathfinder illustrated with this tool.
    /// </summary>
    public class DijkstraPathfinder : IPathfinder
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

            // Reset Dijkstra.
            foreach (var tile in map.Tiles)
            {
                tile.Predecessor = null;
            }

            Dijkstra.FindPaths(mapGraph.Graph, map.Start, out visitedTiles);

            // Build path from predecessor pointers.
            path = new List<MapTile>();
            var mapTile = map.Finish;

            while (mapTile != null)
            {
                path.Add(mapTile);
                mapTile = mapTile.Predecessor as MapTile;
            }

            path.Reverse();

            return path.Contains(map.Start);
        }

        #endregion
    }
}