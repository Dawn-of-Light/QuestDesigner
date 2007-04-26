namespace DOL.Tools.QuestDesigner
{
    partial class Location
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerLocation = new System.Windows.Forms.SplitContainer();
            this.dataGridViewLocation = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOnMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyGridLocation = new System.Windows.Forms.PropertyGrid();
            this.headerStrip3 = new DOL.Tools.QuestDesigner.Controls.HeaderStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.colObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegionID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.splitContainerLocation.Panel1.SuspendLayout();
            this.splitContainerLocation.Panel2.SuspendLayout();
            this.splitContainerLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.headerStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerLocation
            // 
            this.splitContainerLocation.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "locationSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainerLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLocation.Location = new System.Drawing.Point(0, 25);
            this.splitContainerLocation.Name = "splitContainerLocation";
            // 
            // splitContainerLocation.Panel1
            // 
            this.splitContainerLocation.Panel1.Controls.Add(this.dataGridViewLocation);
            // 
            // splitContainerLocation.Panel2
            // 
            this.splitContainerLocation.Panel2.Controls.Add(this.propertyGridLocation);
            this.splitContainerLocation.Size = new System.Drawing.Size(501, 298);
            this.splitContainerLocation.SplitterDistance = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.LocationSplitterDistance;
            this.splitContainerLocation.TabIndex = 6;
            // 
            // dataGridViewLocation
            // 
            this.dataGridViewLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObjectName,
            this.colName,
            this.colRegionID});
            this.dataGridViewLocation.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLocation.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLocation.Name = "dataGridViewLocation";
            this.dataGridViewLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLocation.Size = new System.Drawing.Size(350, 298);
            this.dataGridViewLocation.TabIndex = 2;
            this.dataGridViewLocation.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewLocation_RowValidating);
            this.dataGridViewLocation.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewLocation_DefaultValuesNeeded);
            this.dataGridViewLocation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewLocation_DataError);
            this.dataGridViewLocation.SelectionChanged += new System.EventHandler(this.dataGridViewLocation_SelectionChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteLocationToolStripMenuItem,
            this.showOnMapToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 48);
            // 
            // pasteLocationToolStripMenuItem
            // 
            this.pasteLocationToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.paste;
            this.pasteLocationToolStripMenuItem.Name = "pasteLocationToolStripMenuItem";
            this.pasteLocationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pasteLocationToolStripMenuItem.Text = "Paste Location";
            this.pasteLocationToolStripMenuItem.Click += new System.EventHandler(this.pasteLocationToolStripMenuItem_Click);
            // 
            // showOnMapToolStripMenuItem
            // 
            this.showOnMapToolStripMenuItem.Enabled = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.ShowTaskPane;
            this.showOnMapToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.area;
            this.showOnMapToolStripMenuItem.Name = "showOnMapToolStripMenuItem";
            this.showOnMapToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.showOnMapToolStripMenuItem.Text = "Show on Map";
            this.showOnMapToolStripMenuItem.Click += new System.EventHandler(this.showOnMapToolStripMenuItem_Click);
            // 
            // propertyGridLocation
            // 
            this.propertyGridLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridLocation.Location = new System.Drawing.Point(0, 0);
            this.propertyGridLocation.Name = "propertyGridLocation";
            this.propertyGridLocation.Size = new System.Drawing.Size(147, 298);
            this.propertyGridLocation.TabIndex = 3;
            // 
            // headerStrip3
            // 
            this.headerStrip3.AutoSize = false;
            this.headerStrip3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.headerStrip3.ForeColor = System.Drawing.Color.Gray;
            this.headerStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
            this.headerStrip3.Location = new System.Drawing.Point(0, 0);
            this.headerStrip3.Name = "headerStrip3";
            this.headerStrip3.Size = new System.Drawing.Size(501, 25);
            this.headerStrip3.TabIndex = 7;
            this.headerStrip3.Text = "headerStrip3";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(85, 22);
            this.toolStripLabel3.Text = "Locations";
            // 
            // colObjectName
            // 
            this.colObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObjectName.DataPropertyName = "ObjectName";
            this.colObjectName.FillWeight = 63.5826F;
            this.colObjectName.HeaderText = "ObjectName";
            this.colObjectName.Name = "colObjectName";
            this.colObjectName.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 183.1179F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colRegionID
            // 
            this.colRegionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRegionID.FillWeight = 53.29949F;
            this.colRegionID.HeaderText = "RegionID";
            this.colRegionID.Name = "colRegionID";
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerLocation);
            this.Controls.Add(this.headerStrip3);
            this.Name = "Location";
            this.Size = new System.Drawing.Size(501, 323);
            this.splitContainerLocation.Panel1.ResumeLayout(false);
            this.splitContainerLocation.Panel2.ResumeLayout(false);
            this.splitContainerLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.headerStrip3.ResumeLayout(false);
            this.headerStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerLocation;
        private System.Windows.Forms.PropertyGrid propertyGridLocation;
        private DOL.Tools.QuestDesigner.Controls.HeaderStrip headerStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pasteLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOnMapToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRegionID;

    }
}
