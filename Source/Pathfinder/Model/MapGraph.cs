// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapGraph.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Model
{
    using Npruehs.GrabBag.Graphs;
    using Npruehs.GrabBag.Math.Vectors;

    /// <summary>
    /// Graph representing a pathfinder map.
    /// </summary>
    public class MapGraph
    {
        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new graph from the specified map.
        /// </summary>
        /// <param name="map">Map to build the graph from.</param>
        public MapGraph(Map map)
        {
            this.Map = map;
            
            this.MapToGraph(map);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Graph representing the map.
        /// </summary>
        public Graph<MapTile, int> Graph { get; private set; }

        /// <summary>
        /// Map represented by this graph.
        /// </summary>
        public Map Map { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an edge to this graph, if moving from the specified
        /// map tile in the passed direction is allowed and doesn't exceed
        /// the map bounds.
        /// </summary>
        /// <param name="tile">Edge start.</param>
        /// <param name="direction">Edge direction.</param>
        private void AddMapGraphEdge(MapTile tile, Vector2I direction)
        {
            var targetPosition = tile.Pos + direction;

            // Check map bounds.
            if (targetPosition.X <= 0 || targetPosition.X >= this.Map.Size - 1 || targetPosition.Y <= 0
                || targetPosition.Y >= this.Map.Size - 1)
            {
                return;
            }

            var targetTile = this.Map[targetPosition.X, targetPosition.Y];

            if (targetTile.IsWalkable)
            {
                this.Graph.AddDirectedEdge(tile, targetTile, 1);
            }
        }

        /// <summary>
        /// Converts the passed map to graph with edges between walkable tiles.
        /// </summary>
        /// <param name="map">Map to build the graph from.</param>
        private void MapToGraph(Map map)
        {
            this.Graph = new Graph<MapTile, int>(map.Tiles);

            for (var x = 0; x < map.Size; x++)
            {
                for (var y = 0; y < map.Size; y++)
                {
                    var tile = map[x, y];

                    this.AddMapGraphEdge(tile, new Vector2I(0, +1));
                    this.AddMapGraphEdge(tile, new Vector2I(0, -1));
                    this.AddMapGraphEdge(tile, new Vector2I(+1, 0));
                    this.AddMapGraphEdge(tile, new Vector2I(-1, 0));

                    this.AddMapGraphEdge(tile, new Vector2I(+1, +1));
                    this.AddMapGraphEdge(tile, new Vector2I(-1, -1));
                    this.AddMapGraphEdge(tile, new Vector2I(+1, -1));
                    this.AddMapGraphEdge(tile, new Vector2I(-1, +1));
                }
            }
        }

        #endregion
    }
}