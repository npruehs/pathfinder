// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Brush.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control
{
    /// <summary>
    /// Brush for modifying the map.
    /// </summary>
    public enum Brush
    {
        /// <summary>
        /// Brush for creating walkable terrain.
        /// </summary>
        Walkable, 

        /// <summary>
        /// Brush for creating un-walkable terrain.
        /// </summary>
        Unwalkable, 

        /// <summary>
        /// Brush for choosing the start of the path.
        /// </summary>
        Start, 

        /// <summary>
        /// Brush for choosing the finish of the path.
        /// </summary>
        Finish
    }
}