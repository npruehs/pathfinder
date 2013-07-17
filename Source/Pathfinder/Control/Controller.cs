// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Controller.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.Control
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using Pathfinder.Control.Pathfinders;
    using Pathfinder.Model;
    using Pathfinder.View;

    /// <summary>
    /// GUI controller of the Pathfinder application.
    /// </summary>
    public class Controller
    {
        #region Constants

        /// <summary>
        /// Default size of the brush to draw map tiles with.
        /// </summary>
        public const int DefaultBrushSize = 5;

        /// <summary>
        /// Default speed to draw paths with.
        /// </summary>
        public const int DefaultDrawSpeed = 20;

        /// <summary>
        /// Name of the subfolder containing the map files.
        /// </summary>
        public const string MapFileFolder = "Maps";

        /// <summary>
        /// Mask of the map files of this application.
        /// </summary>
        public const string MapFileMask = "Map files (*.map)|*.map";

        /// <summary>
        /// Default height and width of the map.
        /// </summary>
        public const int MapSize = 300;

        #endregion

        #region Static Fields

        /// <summary>
        /// Color of the path finish on the map.
        /// </summary>
        public static readonly Color ColorFinish = Color.Green;

        /// <summary>
        /// Color of the path on the map.
        /// </summary>
        public static readonly Color ColorPath = Color.Green;

        /// <summary>
        /// Color of the path start on the map.
        /// </summary>
        public static readonly Color ColorStart = Color.Blue;

        /// <summary>
        /// Color of un-walkable terrain on the map.
        /// </summary>
        public static readonly Color ColorUnwalkable = Color.Black;

        /// <summary>
        /// Color of tiles visited while trying to find the path.
        /// </summary>
        public static readonly Color ColorVisited = Color.Yellow;

        /// <summary>
        /// Color of walkable terrain on the map.
        /// </summary>
        public static readonly Color ColorWalkable = Color.White;

        #endregion

        #region Fields

        /// <summary>
        /// About window of the Pathfinder application.
        /// </summary>
        private readonly AboutBox aboutBox;

        /// <summary>
        /// View of the Pathfinder application.
        /// </summary>
        private readonly MainForm mainForm;

        /// <summary>
        /// Terrain brush currently selected.
        /// </summary>
        private Brush brush;

        /// <summary>
        /// Whether the terrain brush is currently down on the map, or not.
        /// </summary>
        private bool brushDown;

        /// <summary>
        /// Size of the terrain brush currently selected.
        /// </summary>
        private int brushSize;

        /// <summary>
        /// Squared size of the terrain brush currently selected.
        /// </summary>
        private int brushSizeSquared;

        /// <summary>
        /// Time the last path-finding query finished.
        /// </summary>
        private DateTime endTime;

        /// <summary>
        /// Path most recently found.
        /// </summary>
        private List<MapTile> path;

        /// <summary>
        /// Current algorithm used for finding the path.
        /// </summary>
        private IPathfinder pathfinder;

        /// <summary>
        /// Time the last path-finding query started.
        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// Map tiles visited while trying to find to most recent path.
        /// </summary>
        private IList<MapTile> visitedTiles;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new controller and a new view for the Pathfinder
        /// application. Initializes the terrain brush, all button colors,
        /// and the map to their default values.
        /// </summary>
        public Controller()
        {
            this.mainForm = new MainForm(this);
            this.aboutBox = new AboutBox();

            this.mainForm.SetStatusText("Initializing application...");
            this.mainForm.Cursor = Cursors.AppStarting;

            this.brush = Brush.Walkable;
            this.brushSize = DefaultBrushSize;
            this.brushSizeSquared = this.brushSize * this.brushSize;
            this.brushDown = false;

            this.DrawSpeed = DefaultDrawSpeed;

            this.mainForm.SetButtonColors(ColorWalkable, ColorUnwalkable, ColorStart, ColorFinish);
            this.mainForm.ResetTimes();

            this.CreateNewMap();

            this.mainForm.Cursor = Cursors.Default;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Tiles to draw between two timeouts.
        /// </summary>
        public int DrawSpeed { get; set; }

        /// <summary>
        /// View of the Pathfinder application.
        /// </summary>
        public MainForm MainForm
        {
            get
            {
                return this.mainForm;
            }
        }

        /// <summary>
        /// Map to find the paths on.
        /// </summary>
        public Map Map { get; private set; }

        /// <summary>
        /// Path most recently found.
        /// </summary>
        public List<MapTile> Path
        {
            get
            {
                return this.path;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Shows information about the Pathfinder application.
        /// </summary>
        public void About()
        {
            this.aboutBox.Show();
        }

        /// <summary>
        /// Changes the terrain brush to selecting the finish of the path.
        /// </summary>
        public void ChooseBrushFinish()
        {
            this.brush = Brush.Finish;
        }

        /// <summary>
        /// Changes the terrain brush to selecting the start of the path.
        /// </summary>
        public void ChooseBrushStart()
        {
            this.brush = Brush.Start;
        }

        /// <summary>
        /// Changes the terrain brush to creating un-walkable terrain.
        /// </summary>
        public void ChooseBrushUnwalkable()
        {
            this.brush = Brush.Unwalkable;
        }

        /// <summary>
        /// Changes the terrain brush to creating walkable terrain.
        /// </summary>
        public void ChooseBrushWalkable()
        {
            this.brush = Brush.Walkable;
        }

        /// <summary>
        /// Creates and shows a new map.
        /// </summary>
        public void CreateNewMap()
        {
            this.ReportStatus("Creating new map...");
            this.Map = new Map(MapSize);
            this.mainForm.ClearMapImage(ColorWalkable);
            this.mainForm.ResetStatusText();
        }

        /// <summary>
        /// Removes the path most recently computed, if any, and computes the new
        /// path using a background worker thread.
        /// </summary>
        public void FindPath()
        {
            // Create new thread.
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += this.BackgroundFindPath;
            worker.RunWorkerCompleted += this.BackgroundFindPathCompleted;

            this.ReportStatus("Finding the shortest path from start to finish...");
            this.mainForm.ResetTimes();

            // Find path.
            this.startTime = DateTime.Now;
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Prompts the user for the map file he or she wishes to open,
        /// and tries to read the map from the specified map file.
        /// </summary>
        public void Open()
        {
            // Prepare the file stream and ask the user for the map to open.
            OpenFileDialog openFileDialog = new OpenFileDialog
                                                {
                                                    Filter = MapFileMask,
                                                    FilterIndex = 0,
                                                    RestoreDirectory = true,
                                                    InitialDirectory =
                                                        Application.StartupPath + "\\" + MapFileFolder
                                                };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // Try to read the map from the specified file.
                var stream = openFileDialog.OpenFile();
                this.ReadMapFromStream(stream);
                stream.Close();
            }
            catch (Exception)
            {
                // Notify the user on any errors that occur.
                this.ShowError("Invalid file or map file corrupt!");
            }
        }

        /// <summary>
        /// Called whenever the map image has been clicked. Draws
        /// terrain according to the brush currently selected,
        /// marking the map as dirty if necessary, and makes the view
        /// refresh itself.
        /// </summary>
        /// <param name="point">Point the map image has been clicked on.</param>
        public void PictureClicked(Point point)
        {
            var x = point.X;
            var y = point.Y;

            switch (this.brush)
            {
                case Brush.Walkable:
                    this.DrawCircle(x, y, ColorWalkable, true);
                    break;

                case Brush.Unwalkable:
                    this.DrawCircle(x, y, ColorUnwalkable, false);
                    break;

                case Brush.Start:
                    // Remove old start.
                    if (this.Map.Start != null)
                    {
                        this.DrawCircle(this.Map.Start.Pos.X, this.Map.Start.Pos.Y, ColorWalkable, true);
                    }

                    // Set new start.
                    this.DrawCircle(x, y, ColorStart, true);
                    this.Map.Start = this.Map[x, y];
                    break;

                case Brush.Finish:
                    // Remove old finish.
                    if (this.Map.Finish != null)
                    {
                        this.DrawCircle(this.Map.Finish.Pos.X, this.Map.Finish.Pos.Y, ColorWalkable, true);
                    }

                    // Set new finish.
                    this.DrawCircle(x, y, ColorFinish, true);
                    this.Map.Finish = this.Map[x, y];
                    break;
            }

            this.mainForm.RefreshPicture();
        }

        /// <summary>
        /// Called whenever the user presses the left mouse button on the
        /// map image. Lowers the terrain brush.
        /// </summary>
        public void PictureMouseDown()
        {
            this.brushDown = true;
        }

        /// <summary>
        /// Called whenever the user hovers the map image. Changes the
        /// mouse cursor to a cross.
        /// </summary>
        public void PictureMouseEnter()
        {
            this.mainForm.Cursor = Cursors.Cross;
        }

        /// <summary>
        /// Called whenever the mouse cursor leaves the map image.
        /// Restores the default mouse cursor and raises the terrain brush.
        /// </summary>
        public void PictureMouseLeave()
        {
            this.mainForm.Cursor = Cursors.Default;
            this.brushDown = false;
        }

        /// <summary>
        /// Called whenever the user moves the mouse over the map image.
        /// Updates the window title and fires a PictureClicked event if
        /// the left mouse button is currently down.
        /// </summary>
        /// <param name="point">
        /// Current position of the mouse cursor on the map image.
        /// </param>
        public void PictureMouseMoved(Point point)
        {
            this.mainForm.UpdateTitle(point.ToString());

            if (this.brushDown)
            {
                this.PictureClicked(point);
            }
        }

        /// <summary>
        /// Called whenever the user releases the left mouse button on the
        /// map image. Raises the terrain brush.
        /// </summary>
        public void PictureMouseUp()
        {
            this.brushDown = false;
        }

        /// <summary>
        /// Terminates the Pathfinder application.
        /// </summary>
        public void Quit()
        {
            Application.Exit();
        }

        /// <summary>
        /// Makes the GUI change the text displayed in the status bar.
        /// </summary>
        /// <param name="s">New text to be displayed in the status bar.</param>
        public void ReportStatus(string s)
        {
            this.mainForm.SetStatusText(s);
        }

        /// <summary>
        /// Prompts the user for the destination he or she wishes to write the
        /// map file to, and tries to write the map to the specified map file.
        /// </summary>
        public void SaveAs()
        {
            // Ask the user for the destination to write the new map file to.
            SaveFileDialog saveFileDialog = new SaveFileDialog
                                                {
                                                    Filter = MapFileMask,
                                                    FilterIndex = 0,
                                                    RestoreDirectory = true,
                                                    InitialDirectory =
                                                        Application.StartupPath + "\\" + MapFileFolder
                                                };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // Try to write the map to the specified destination file.
                var stream = saveFileDialog.OpenFile();
                this.WriteMapToStream(stream);
                stream.Close();
            }
            catch (Exception)
            {
                // Notify the user on any errors that occur.
                this.ShowError("An error has occured writing the map file!");
            }
        }

        /// <summary>
        /// Changes the size of the terrain brush to the specified value.
        /// </summary>
        /// <param name="newBrushSize">New size of the terrain brush.</param>
        public void SetBrushSize(int newBrushSize)
        {
            this.brushSize = newBrushSize;
            this.brushSizeSquared = newBrushSize * newBrushSize;
        }

        /// <summary>
        /// Makes the GUI show an error message dialog with the specified content.
        /// </summary>
        /// <param name="error">Error message to show.</param>
        public void ShowError(string error)
        {
            this.mainForm.ShowError(error);
        }

        /// <summary>
        /// Makes the GUI show a message dialog with the specified content.
        /// </summary>
        /// <param name="message">Message to show.</param>
        /// <param name="caption">caption of the dialog to show.</param>
        public void ShowMessage(string message, string caption)
        {
            this.mainForm.ShowMessage(caption, message);
        }

        /// <summary>
        /// Makes the GUI show a warning dialog with the specified content.
        /// </summary>
        /// <param name="warning">Warning to show.</param>
        public void ShowWarning(string warning)
        {
            this.mainForm.ShowWarning(warning);
        }

        /// <summary>
        /// Switches to the A* algorithm for finding the next path.
        /// </summary>
        public void UseAStarAlgorithm()
        {
            this.pathfinder = new AStarPathfinder();
        }

        /// <summary>
        /// Switches to the Dijkstra algorithm for finding the next path.
        /// </summary>
        public void UseDijkstraAlgorithm()
        {
            this.pathfinder = new DijkstraPathfinder();
        }

        /// <summary>
        /// Switches to rapidly-exploring random trees for finding the next path.
        /// </summary>
        public void UseRandomTree()
        {
            this.pathfinder = new RandomTreePathfinder();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Computes the new path from start to finish.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BackgroundFindPath(object sender, DoWorkEventArgs e)
        {
            if (this.pathfinder != null)
            {
                this.pathfinder.CalculatePath(this.Map, out this.path, out this.visitedTiles);
            }
        }

        /// <summary>
        /// Shows the new path from start to finish, if there is any, and
        /// a message box for notifying the user otherwise.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BackgroundFindPathCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Show the time the thread required for finding the path.
            this.endTime = DateTime.Now;
            this.mainForm.SetTimeFindPath(this.endTime.TimeOfDay.Subtract(this.startTime.TimeOfDay).ToString());

            this.RedrawMap();

            if (this.path != null)
            {
                // If there is a path, show it on the map.
                this.mainForm.DrawVisitedTiles(this.visitedTiles);
                this.mainForm.SetPathLength(this.path.Count);
            }
            else
            {
                // If not, tell the user about it.
                this.ShowMessage("There is no path from start to finish.", "No path found");
            }

            this.mainForm.ResetStatusText();
        }

        /// <summary>
        /// Draws a circle with the passed color and the radius of the current
        /// brush size at the specified position on the map image, modifying
        /// the map model as necessary.
        /// </summary>
        /// <param name="x">
        /// X-coordinate of the center of the circle to draw.
        /// </param>
        /// <param name="y">
        /// Y-coordinate of the center of the circle to draw.
        /// </param>
        /// <param name="color">
        /// Color to draw the circle with.
        /// </param>
        /// <param name="walkable">
        /// Whether to mark all affected map tiles as walkable, or not.
        /// </param>
        private void DrawCircle(int x, int y, Color color, bool walkable)
        {
            /*
             * Iterate the pixels within the square with it's upper left corner at
             * the passed coordinates and it's width and height equal to the brush
             * size.
             */
            for (var i = -this.brushSize; i <= this.brushSize; i++)
            {
                for (var j = -this.brushSize; j <= this.brushSize; j++)
                {
                    var targetPixelY = y + i;
                    var targetPixelX = x + j;

                    // Check if the current pixel is still within the map.
                    if (targetPixelX < 0 || targetPixelX >= MapSize || targetPixelY < 0 || targetPixelY >= MapSize)
                    {
                        continue;
                    }

                    // If the current pixel is within the circle, draw it.
                    if ((i * i) + (j * j) > this.brushSizeSquared)
                    {
                        continue;
                    }

                    this.mainForm.DrawPixel(targetPixelX, targetPixelY, color);
                    this.Map.SetTileWalkable(targetPixelX, targetPixelY, walkable);
                }
            }
        }

        /// <summary>
        /// Reads the size of a map, its start and finish points,
        /// and the walkability of all of its tiles from the specified stream.
        /// </summary>
        /// <param name="stream">Stream to read the map from.</param>
        private void ReadMapFromStream(Stream stream)
        {
            // Initialize a new binary reader.
            BinaryReader r = new BinaryReader(stream);

            // Initialize a new map with the read size.
            this.Map = new Map(r.ReadInt32());

            // Read the coordinates of the start and finish points.
            this.Map.Start = this.Map[r.ReadInt32(), r.ReadInt32()];
            this.Map.Finish = this.Map[r.ReadInt32(), r.ReadInt32()];

            // Read the walkability of all tiles.
            foreach (var mapTile in this.Map.Tiles)
            {
                var walkable = r.ReadBoolean();
                mapTile.IsWalkable = walkable;
            }

            // Close the binary reader.
            r.Close();

            this.RedrawMap();
        }

        /// <summary>
        /// Redraws the map picture from the current model.
        /// </summary>
        private void RedrawMap()
        {
            for (var x = 0; x < this.Map.Size; x++)
            {
                for (var y = 0; y < this.Map.Size; y++)
                {
                    this.mainForm.DrawPixel(x, y, this.Map[x, y].IsWalkable ? ColorWalkable : ColorUnwalkable);
                }
            }

            this.DrawCircle(this.Map.Start.Pos.X, this.Map.Start.Pos.Y, ColorStart, true);
            this.DrawCircle(this.Map.Finish.Pos.X, this.Map.Finish.Pos.Y, ColorFinish, true);

            this.mainForm.RefreshPicture();
        }

        /// <summary>
        /// Writes the size of the current map, its start and finish points,
        /// and the walkability of all tiles to the specified stream.
        /// </summary>
        /// <param name="stream">Stream to write the current map to.</param>
        private void WriteMapToStream(Stream stream)
        {
            // Initialize a new binary writer.
            BinaryWriter w = new BinaryWriter(stream);

            // Write the map size.
            w.Write(this.Map.Size);

            // Write the coordinates of the start and finish points.
            w.Write(this.Map.Start.Pos.X);
            w.Write(this.Map.Start.Pos.Y);

            w.Write(this.Map.Finish.Pos.X);
            w.Write(this.Map.Finish.Pos.Y);

            // Write the walkability of all tiles.
            foreach (var mapTile in this.Map.Tiles)
            {
                w.Write(mapTile.IsWalkable);
            }

            // Close the binary writer.
            w.Close();
        }

        #endregion
    }
}