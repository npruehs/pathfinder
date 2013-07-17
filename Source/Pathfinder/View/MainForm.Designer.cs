namespace Pathfinder.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonWalkable = new System.Windows.Forms.Button();
            this.buttonUnwalkable = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.labelBrushSize = new System.Windows.Forms.Label();
            this.numericUpDownBrushSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutPathfinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFindTime = new System.Windows.Forms.Label();
            this.labelFindTimeValue = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.radioButtonDijkstra = new System.Windows.Forms.RadioButton();
            this.radioButtonAStar = new System.Windows.Forms.RadioButton();
            this.radioButtonRandomTree = new System.Windows.Forms.RadioButton();
            this.labelDrawSpeed = new System.Windows.Forms.Label();
            this.numericUpDownDrawSpeed = new System.Windows.Forms.NumericUpDown();
            this.labelPathLength = new System.Windows.Forms.Label();
            this.labelPathLengthValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrushSize)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDrawSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWalkable
            // 
            this.buttonWalkable.Location = new System.Drawing.Point(318, 52);
            this.buttonWalkable.Name = "buttonWalkable";
            this.buttonWalkable.Size = new System.Drawing.Size(179, 30);
            this.buttonWalkable.TabIndex = 1;
            this.buttonWalkable.Text = "Walkable";
            this.buttonWalkable.UseVisualStyleBackColor = true;
            this.buttonWalkable.Click += new System.EventHandler(this.buttonWalkable_Click);
            // 
            // buttonUnwalkable
            // 
            this.buttonUnwalkable.ForeColor = System.Drawing.Color.White;
            this.buttonUnwalkable.Location = new System.Drawing.Point(318, 88);
            this.buttonUnwalkable.Name = "buttonUnwalkable";
            this.buttonUnwalkable.Size = new System.Drawing.Size(179, 30);
            this.buttonUnwalkable.TabIndex = 2;
            this.buttonUnwalkable.Text = "Unwalkable";
            this.buttonUnwalkable.UseVisualStyleBackColor = true;
            this.buttonUnwalkable.Click += new System.EventHandler(this.buttonUnwalkable_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.ForeColor = System.Drawing.Color.White;
            this.buttonStart.Location = new System.Drawing.Point(318, 124);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(179, 30);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonFinish
            // 
            this.buttonFinish.ForeColor = System.Drawing.Color.White;
            this.buttonFinish.Location = new System.Drawing.Point(318, 160);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(179, 30);
            this.buttonFinish.TabIndex = 4;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Location = new System.Drawing.Point(12, 358);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(485, 57);
            this.buttonFindPath.TabIndex = 5;
            this.buttonFindPath.Text = "Find Path!";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            this.buttonFindPath.Click += new System.EventHandler(this.buttonFindPath_Click);
            // 
            // labelBrushSize
            // 
            this.labelBrushSize.AutoSize = true;
            this.labelBrushSize.Location = new System.Drawing.Point(318, 198);
            this.labelBrushSize.Name = "labelBrushSize";
            this.labelBrushSize.Size = new System.Drawing.Size(60, 13);
            this.labelBrushSize.TabIndex = 7;
            this.labelBrushSize.Text = "Brush Size:";
            // 
            // numericUpDownBrushSize
            // 
            this.numericUpDownBrushSize.Location = new System.Drawing.Point(406, 196);
            this.numericUpDownBrushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBrushSize.Name = "numericUpDownBrushSize";
            this.numericUpDownBrushSize.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownBrushSize.TabIndex = 8;
            this.numericUpDownBrushSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownBrushSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBrushSize.ValueChanged += new System.EventHandler(this.numericUpDownBrushSize_ValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(511, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::Pathfinder.Properties.Resources.NewDocumentHS;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::Pathfinder.Properties.Resources.openHS;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = global::Pathfinder.Properties.Resources.saveHS;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutPathfinderToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutPathfinderToolStripMenuItem
            // 
            this.aboutPathfinderToolStripMenuItem.Image = global::Pathfinder.Properties.Resources.Help;
            this.aboutPathfinderToolStripMenuItem.Name = "aboutPathfinderToolStripMenuItem";
            this.aboutPathfinderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutPathfinderToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aboutPathfinderToolStripMenuItem.Text = "About Pathfinder...";
            this.aboutPathfinderToolStripMenuItem.Click += new System.EventHandler(this.aboutPathfinderToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 504);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(511, 22);
            this.statusStrip.TabIndex = 10;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready.";
            // 
            // labelFindTime
            // 
            this.labelFindTime.AutoSize = true;
            this.labelFindTime.Location = new System.Drawing.Point(12, 427);
            this.labelFindTime.Name = "labelFindTime";
            this.labelFindTime.Size = new System.Drawing.Size(75, 13);
            this.labelFindTime.TabIndex = 12;
            this.labelFindTime.Text = "Found path in:";
            // 
            // labelFindTimeValue
            // 
            this.labelFindTimeValue.AutoSize = true;
            this.labelFindTimeValue.Location = new System.Drawing.Point(97, 427);
            this.labelFindTimeValue.Name = "labelFindTimeValue";
            this.labelFindTimeValue.Size = new System.Drawing.Size(13, 13);
            this.labelFindTimeValue.TabIndex = 14;
            this.labelFindTimeValue.Text = "0";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 52);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 300);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            this.pictureBox.MouseLeave += new System.EventHandler(this.pictureBox_MouseLeave);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonOpen,
            this.toolStripButtonSave});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(511, 25);
            this.toolStrip.TabIndex = 17;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNew.Image = global::Pathfinder.Properties.Resources.NewDocumentHS;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNew.Text = "New Map";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpen.Image = global::Pathfinder.Properties.Resources.openHS;
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpen.Text = "Open Map";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.toolStripButtonOpen_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSave.Image = global::Pathfinder.Properties.Resources.saveHS;
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSave.Text = "Save Map";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(318, 243);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(53, 13);
            this.labelAlgorithm.TabIndex = 18;
            this.labelAlgorithm.Text = "Algorithm:";
            // 
            // radioButtonDijkstra
            // 
            this.radioButtonDijkstra.AutoSize = true;
            this.radioButtonDijkstra.Location = new System.Drawing.Point(406, 241);
            this.radioButtonDijkstra.Name = "radioButtonDijkstra";
            this.radioButtonDijkstra.Size = new System.Drawing.Size(60, 17);
            this.radioButtonDijkstra.TabIndex = 19;
            this.radioButtonDijkstra.TabStop = true;
            this.radioButtonDijkstra.Text = "Dijkstra";
            this.radioButtonDijkstra.UseVisualStyleBackColor = true;
            this.radioButtonDijkstra.CheckedChanged += new System.EventHandler(this.radioButtonDijkstra_CheckedChanged);
            // 
            // radioButtonAStar
            // 
            this.radioButtonAStar.AutoSize = true;
            this.radioButtonAStar.Location = new System.Drawing.Point(406, 264);
            this.radioButtonAStar.Name = "radioButtonAStar";
            this.radioButtonAStar.Size = new System.Drawing.Size(36, 17);
            this.radioButtonAStar.TabIndex = 20;
            this.radioButtonAStar.TabStop = true;
            this.radioButtonAStar.Text = "A*";
            this.radioButtonAStar.UseVisualStyleBackColor = true;
            this.radioButtonAStar.CheckedChanged += new System.EventHandler(this.radioButtonAStar_CheckedChanged);
            // 
            // radioButtonRandomTree
            // 
            this.radioButtonRandomTree.AutoSize = true;
            this.radioButtonRandomTree.Location = new System.Drawing.Point(406, 288);
            this.radioButtonRandomTree.Name = "radioButtonRandomTree";
            this.radioButtonRandomTree.Size = new System.Drawing.Size(90, 17);
            this.radioButtonRandomTree.TabIndex = 21;
            this.radioButtonRandomTree.TabStop = true;
            this.radioButtonRandomTree.Text = "Random Tree";
            this.radioButtonRandomTree.UseVisualStyleBackColor = true;
            this.radioButtonRandomTree.CheckedChanged += new System.EventHandler(this.radioButtonRandomTree_CheckedChanged);
            // 
            // labelDrawSpeed
            // 
            this.labelDrawSpeed.AutoSize = true;
            this.labelDrawSpeed.Location = new System.Drawing.Point(318, 328);
            this.labelDrawSpeed.Name = "labelDrawSpeed";
            this.labelDrawSpeed.Size = new System.Drawing.Size(69, 13);
            this.labelDrawSpeed.TabIndex = 22;
            this.labelDrawSpeed.Text = "Draw Speed:";
            // 
            // numericUpDownDrawSpeed
            // 
            this.numericUpDownDrawSpeed.Location = new System.Drawing.Point(406, 326);
            this.numericUpDownDrawSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDrawSpeed.Name = "numericUpDownDrawSpeed";
            this.numericUpDownDrawSpeed.Size = new System.Drawing.Size(66, 20);
            this.numericUpDownDrawSpeed.TabIndex = 23;
            this.numericUpDownDrawSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownDrawSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownDrawSpeed.ValueChanged += new System.EventHandler(this.numericUpDownDrawSpeed_ValueChanged);
            // 
            // labelPathLength
            // 
            this.labelPathLength.AutoSize = true;
            this.labelPathLength.Location = new System.Drawing.Point(12, 453);
            this.labelPathLength.Name = "labelPathLength";
            this.labelPathLength.Size = new System.Drawing.Size(64, 13);
            this.labelPathLength.TabIndex = 24;
            this.labelPathLength.Text = "Path length:";
            // 
            // labelPathLengthValue
            // 
            this.labelPathLengthValue.AutoSize = true;
            this.labelPathLengthValue.Location = new System.Drawing.Point(97, 453);
            this.labelPathLengthValue.Name = "labelPathLengthValue";
            this.labelPathLengthValue.Size = new System.Drawing.Size(13, 13);
            this.labelPathLengthValue.TabIndex = 25;
            this.labelPathLengthValue.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 526);
            this.Controls.Add(this.labelPathLengthValue);
            this.Controls.Add(this.labelPathLength);
            this.Controls.Add(this.numericUpDownDrawSpeed);
            this.Controls.Add(this.labelDrawSpeed);
            this.Controls.Add(this.radioButtonRandomTree);
            this.Controls.Add(this.radioButtonAStar);
            this.Controls.Add(this.radioButtonDijkstra);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.labelFindTimeValue);
            this.Controls.Add(this.labelFindTime);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.numericUpDownBrushSize);
            this.Controls.Add(this.labelBrushSize);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonUnwalkable);
            this.Controls.Add(this.buttonWalkable);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Pathfinder";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBrushSize)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDrawSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button buttonWalkable;
        private System.Windows.Forms.Button buttonUnwalkable;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.Label labelBrushSize;
        private System.Windows.Forms.NumericUpDown numericUpDownBrushSize;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label labelFindTime;
        private System.Windows.Forms.Label labelFindTimeValue;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutPathfinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.Label labelAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonDijkstra;
        private System.Windows.Forms.RadioButton radioButtonAStar;
        private System.Windows.Forms.RadioButton radioButtonRandomTree;
        private System.Windows.Forms.Label labelDrawSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownDrawSpeed;
        private System.Windows.Forms.Label labelPathLength;
        private System.Windows.Forms.Label labelPathLengthValue;
    }
}

