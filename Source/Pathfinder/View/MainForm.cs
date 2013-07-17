// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    using Pathfinder.Control;
    using Pathfinder.Model;

    /// <summary>
    /// Main window of the Pathfinder application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constants

        /// <summary>
        /// Default text to be displayed in the status bar.
        /// </summary>
        public const string DefaultStatusText = "Ready.";

        /// <summary>
        /// Title of the error dialog.
        /// </summary>
        public const string MessageboxCaptionError = "Error!";

        /// <summary>
        /// Title of the warning dialog.
        /// </summary>
        public const string MessageboxCaptionWarning = "Warning";

        /// <summary>
        /// Tooltip to be displayed whenever the numericUpDown to
        /// choose the brush size with is hovered.
        /// </summary>
        public const string TooltipBrushsize = "Select the size of the brush the terrain is drawn with!";

        /// <summary>
        /// Tooltip to be displayed whenever the button used to
        /// start the path-finding algorithm is hovered.
        /// </summary>
        public const string TooltipButtonFindpath = "Find the shortest path from start to finish!";

        /// <summary>
        /// Tooltip to be displayed whenever the button used to
        /// set the finish of the path is hovered.
        /// </summary>
        public const string TooltipButtonFinish = "Choose the finish of the path to find!";

        /// <summary>
        /// Tooltip to be displayed whenever the button used to
        /// set the start of the path is hovered.
        /// </summary>
        public const string TooltipButtonStart = "Choose the start point of the path to find!";

        /// <summary>
        /// Tooltip to be displayed whenever the button used to
        /// create un-walkable terrain is hovered.
        /// </summary>
        public const string TooltipButtonUnwalkable =
            "Create unwalkable terrain: The pathfinder will avoid unwalkable terrain.";

        /// <summary>
        /// Tooltip to be displayed whenever the button used to
        /// create walkable terrain is hovered.
        /// </summary>
        public const string TooltipButtonWalkable =
            "Create walkable terrain: The pathfinder will try to find the shortest path from start to finish on this terrain.";

        /// <summary>
        /// Tooltip to be displayed whenever the map is hovered.
        /// </summary>
        public const string TooltipMap =
            "The map to find the shortest paths on: Use the buttons to the right to modify the map!";

        /// <summary>
        /// Tooltip to be displayed whenever the label showing the
        /// time the algorithm took to find the path is hovered.
        /// </summary>
        public const string TooltipTimeFindpath =
            "The time the last query required for finding the shortest path from start to finish.";

        /// <summary>
        /// Title of the main window.
        /// </summary>
        public const string WindowTitle = "Pathfinder";

        #endregion

        #region Fields

        /// <summary>
        /// Controller which manages this window.
        /// </summary>
        private readonly Controller controller;

        /// <summary>
        /// Image of the map the paths are found on.
        /// </summary>
        private readonly Bitmap mapImage;

        /// <summary>
        /// Button of the currently selected brush.
        /// </summary>
        private Button selectedBrushButton;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Constructs a new main window for the application,
        /// managed by the passed controller
        /// </summary>
        /// <param name="controller">
        /// Controller to manage this window.
        /// </param>
        public MainForm(Controller controller)
        {
            this.controller = controller;

            this.InitializeComponent();

            this.mapImage = new Bitmap(Controller.MapSize, Controller.MapSize);
            this.pictureBox.Image = this.mapImage;

            this.numericUpDownBrushSize.Value = Controller.DefaultBrushSize;
            this.numericUpDownDrawSpeed.Value = Controller.DefaultDrawSpeed;

            this.toolStripStatusLabel.Text = DefaultStatusText;

            this.selectedBrushButton = this.buttonWalkable;
            this.selectedBrushButton.FlatStyle = FlatStyle.Flat;

            this.InitializeTooltips();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clears and refreshes the map image with the specified color.
        /// </summary>
        /// <param name="color">New color of the map image.</param>
        public void ClearMapImage(Color color)
        {
            for (var y = 0; y < this.mapImage.Height; y++)
            {
                for (var x = 0; x < this.mapImage.Width; x++)
                {
                    this.DrawPixel(x, y, color);
                }
            }

            this.RefreshPicture();
        }

        /// <summary>
        /// Draws a pixel with the specified color at the 
        /// passed position on the map image.
        /// </summary>
        /// <param name="x">X-coordinate of the pixel to draw.</param>
        /// <param name="y">Y-coordinate of the pixel to draw.</param>
        /// <param name="color">Color of the pixel to draw.</param>
        public void DrawPixel(int x, int y, Color color)
        {
            this.mapImage.SetPixel(x, y, color);
        }

        /// <summary>
        /// Draws the passed list of visited tiles in another thread.
        /// </summary>
        /// <param name="visitedTiles">Tiles to draw.</param>
        public void DrawVisitedTiles(IList<MapTile> visitedTiles)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += this.BackgroundDrawVisitedTiles;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += this.BackgroundDrawVisitedTilesProgressChanged;
            worker.RunWorkerCompleted += this.BackgroundDrawVisitedTilesCompleted;
            worker.RunWorkerAsync(visitedTiles);
        }

        /// <summary>
        /// Refreshes the map image.
        /// </summary>
        public void RefreshPicture()
        {
            this.pictureBox.Refresh();
        }

        /// <summary>
        /// Resets the text displayed in the status bar to its default value.
        /// </summary>
        public void ResetStatusText()
        {
            this.toolStripStatusLabel.Text = DefaultStatusText;
        }

        /// <summary>
        /// Resets the displayed times to zero.
        /// </summary>
        public void ResetTimes()
        {
            this.labelFindTimeValue.Text = new TimeSpan().ToString();
        }

        /// <summary>
        /// Sets the background colors of the four brush buttons.
        /// </summary>
        /// <param name="walkable">New color of the button for walkable terrain.</param>
        /// <param name="unwalkable">New color of the button for un-walkable terrain.</param>
        /// <param name="start">New color of the button for the start of the path.</param>
        /// <param name="finish">New color of the button for the finish of the path.</param>
        public void SetButtonColors(Color walkable, Color unwalkable, Color start, Color finish)
        {
            this.buttonWalkable.BackColor = walkable;
            this.buttonUnwalkable.BackColor = unwalkable;
            this.buttonStart.BackColor = start;
            this.buttonFinish.BackColor = finish;
        }

        /// <summary>
        /// Sets the length of the path found, in tiles.
        /// </summary>
        /// <param name="length">New path length to display.</param>
        public void SetPathLength(int length)
        {
            this.labelPathLengthValue.Text = length.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Sets the value of the progress bar.
        /// </summary>
        /// <param name="progress">New value of the progress bar, in percent.</param>
        public void SetProgress(int progress)
        {
            this.toolStripProgressBar.Value = progress;
        }

        /// <summary>
        /// Sets the text displayed in the status bar.
        /// </summary>
        /// <param name="status">New text to be displayed in the status bar.</param>
        public void SetStatusText(string status)
        {
            this.toolStripStatusLabel.Text = status;
        }

        /// <summary>
        /// Sets the time the last query required for finding the shortest path
        /// from start to finish.
        /// </summary>
        /// <param name="time">New time to display.</param>
        public void SetTimeFindPath(string time)
        {
            this.labelFindTimeValue.Text = time;
        }

        /// <summary>
        /// Shows an error message dialog with the specified content.
        /// </summary>
        /// <param name="error">Error message to show.</param>
        public void ShowError(string error)
        {
            MessageBox.Show(this, error, MessageboxCaptionError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Shows a message dialog with the specified content.
        /// </summary>
        /// <param name="caption">Caption of the dialog to show.</param>
        /// <param name="message">Message to show.</param>
        public void ShowMessage(string caption, string message)
        {
            MessageBox.Show(this, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Shows a warning dialog with the specified content.
        /// </summary>
        /// <param name="warning">Warning to show.</param>
        public void ShowWarning(string warning)
        {
            MessageBox.Show(this, warning, MessageboxCaptionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Adds the passed string to the default title of
        /// this window.
        /// </summary>
        /// <param name="s">New window title.</param>
        /// <seealso cref="WindowTitle"/>
        public void UpdateTitle(string s)
        {
            this.Text = string.Format("{0} {1}", WindowTitle, s);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Draws the list of visited tiles.
        /// </summary>
        /// <param name="sender">Thread drawing the tiles.</param>
        /// <param name="e">Tiles to draw.</param>
        private void BackgroundDrawVisitedTiles(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            IList<MapTile> visitedTiles = (IList<MapTile>)e.Argument;
            this.DrawTiles(visitedTiles, Controller.ColorVisited, worker);
        }

        /// <summary>
        /// Draws the path from start to finish.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BackgroundDrawVisitedTilesCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DrawTiles(this.controller.Path, Controller.ColorPath, null);
        }

        /// <summary>
        /// Sets the value of the progress bar.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">Number of tiles drawn, in percent.</param>
        private void BackgroundDrawVisitedTilesProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.SetProgress(e.ProgressPercentage);
            this.SetStatusText(string.Format("Drawing visited tiles... ({0} %)", e.ProgressPercentage));
        }

        /// <summary>
        /// Draws the specified list of tiles with the passed color.
        /// </summary>
        /// <param name="tiles">Tiles to draw.</param>
        /// <param name="color">Color to draw with.</param>
        /// <param name="worker">Thread to report progress for.</param>
        private void DrawTiles(ICollection<MapTile> tiles, Color color, BackgroundWorker worker)
        {
            var g = this.pictureBox.CreateGraphics();
            var pen = new Pen(color);
            var tilesDrawn = 0;

            foreach (var tile in tiles)
            {
                // Draw tile.
                g.DrawRectangle(pen, tile.Pos.X, tile.Pos.Y, 1, 1);
                tilesDrawn++;

                // Slow down to draw speed.
                if (tilesDrawn % this.controller.DrawSpeed == 0)
                {
                    Thread.Sleep(1);
                }

                // Report draw progress.
                if (worker != null)
                {
                    var progress = tilesDrawn * 100 / tiles.Count;
                    worker.ReportProgress(progress);
                }

                if (tile.Equals(this.controller.Map.Finish))
                {
                    break;
                }
            }

            this.ResetStatusText();
        }

        /// <summary>
        /// Initialized all tooltips of this window.
        /// </summary>
        private void InitializeTooltips()
        {
            // Set map tooltip.
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.pictureBox, TooltipMap);

            // Set button tooltips.
            toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonWalkable, TooltipButtonWalkable);

            toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonUnwalkable, TooltipButtonUnwalkable);

            toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonStart, TooltipButtonStart);

            toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonFinish, TooltipButtonFinish);

            toolTip = new ToolTip();
            toolTip.SetToolTip(this.buttonFindPath, TooltipButtonFindpath);

            // Set brush size tooltips.
            toolTip = new ToolTip();
            toolTip.SetToolTip(this.labelBrushSize, TooltipBrushsize);
            toolTip.SetToolTip(this.numericUpDownBrushSize, TooltipBrushsize);

            // Set time label tooltip.
            toolTip = new ToolTip();
            toolTip.SetToolTip(this.labelFindTime, TooltipTimeFindpath);
            toolTip.SetToolTip(this.labelFindTimeValue, TooltipTimeFindpath);
        }

        private void aboutPathfinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.About();
        }

        private void buttonFindPath_Click(object sender, EventArgs e)
        {
            this.controller.FindPath();
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            this.controller.ChooseBrushFinish();

            this.selectedBrushButton.FlatStyle = FlatStyle.Standard;
            this.buttonFinish.FlatStyle = FlatStyle.Flat;
            this.selectedBrushButton = this.buttonFinish;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.controller.ChooseBrushStart();

            this.selectedBrushButton.FlatStyle = FlatStyle.Standard;
            this.buttonStart.FlatStyle = FlatStyle.Flat;
            this.selectedBrushButton = this.buttonStart;
        }

        private void buttonUnwalkable_Click(object sender, EventArgs e)
        {
            this.controller.ChooseBrushUnwalkable();

            this.selectedBrushButton.FlatStyle = FlatStyle.Standard;
            this.buttonUnwalkable.FlatStyle = FlatStyle.Flat;
            this.selectedBrushButton = this.buttonUnwalkable;
        }

        private void buttonWalkable_Click(object sender, EventArgs e)
        {
            this.controller.ChooseBrushWalkable();

            this.selectedBrushButton.FlatStyle = FlatStyle.Standard;
            this.buttonWalkable.FlatStyle = FlatStyle.Flat;
            this.selectedBrushButton = this.buttonWalkable;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.CreateNewMap();
        }

        private void numericUpDownBrushSize_ValueChanged(object sender, EventArgs e)
        {
            this.controller.SetBrushSize((int)((NumericUpDown)sender).Value);
        }

        private void numericUpDownDrawSpeed_ValueChanged(object sender, EventArgs e)
        {
            this.controller.DrawSpeed = (int)((NumericUpDown)sender).Value;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Open();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            this.controller.PictureClicked(this.pictureBox.PointToClient(Cursor.Position));
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.controller.PictureMouseDown();
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.controller.PictureMouseEnter();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            this.controller.PictureMouseLeave();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.controller.PictureMouseMoved(this.pictureBox.PointToClient(Cursor.Position));
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.controller.PictureMouseUp();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.Quit();
        }

        private void radioButtonAStar_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.UseAStarAlgorithm();
        }

        private void radioButtonDijkstra_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.UseDijkstraAlgorithm();
        }

        private void radioButtonRandomTree_CheckedChanged(object sender, EventArgs e)
        {
            this.controller.UseRandomTree();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.controller.SaveAs();
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            this.controller.CreateNewMap();
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            this.controller.Open();
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.controller.SaveAs();
        }

        #endregion
    }
}