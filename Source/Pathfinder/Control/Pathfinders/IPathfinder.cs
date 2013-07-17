// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPathfinder.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control.Pathfinders
{
    using System.Collections.Generic;

    using Pathfinder.Model;

    /// <summary>
    ///     Pathfinder that can be illustrated with this tool.
    /// </summary>
    public interface IPathfinder
    {
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
        bool CalculatePath(Map map, out List<MapTile> path, out IList<MapTile> visitedTiles);

        #endregion
    }
}