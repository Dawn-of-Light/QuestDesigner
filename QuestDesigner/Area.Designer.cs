namespace DOL.Tools.QuestDesigner
{
    partial class Area
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
            System.Windows.Forms.ToolStripLabel toolStripLabelArea;
            DOL.Tools.QuestDesigner.Controls.HeaderStrip headerStripArea;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOnMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridArea = new System.Windows.Forms.DataGridView();
            this.colObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegionID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAreaType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.propertyGridArea = new System.Windows.Forms.PropertyGrid();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.copyLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripLabelArea = new System.Windows.Forms.ToolStripLabel();
            headerStripArea = new DOL.Tools.QuestDesigner.Controls.HeaderStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArea)).BeginInit();
            headerStripArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripLabelArea
            // 
            toolStripLabelArea.Name = "toolStripLabelArea";
            toolStripLabelArea.Size = new System.Drawing.Size(53, 22);
            toolStripLabelArea.Text = "Areas";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyLocationToolStripMenuItem,
            this.pasteLocationToolStripMenuItem,
            this.showOnMapToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(156, 92);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
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
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "AreaSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridArea);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridArea);
            this.splitContainer1.Size = new System.Drawing.Size(458, 125);
            this.splitContainer1.SplitterDistance = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.AreaSplitterDistance;
            this.splitContainer1.TabIndex = 3;
            // 
            // dataGridArea
            // 
            this.dataGridArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObjectName,
            this.colName,
            this.colRegionID,
            this.colAreaType});
            this.dataGridArea.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridArea.Location = new System.Drawing.Point(0, 0);
            this.dataGridArea.Name = "dataGridArea";
            this.dataGridArea.Size = new System.Drawing.Size(350, 125);
            this.dataGridArea.TabIndex = 0;
            this.dataGridArea.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridArea_RowValidating);
            this.dataGridArea.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridArea_DefaultValuesNeeded);
            this.dataGridArea.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridArea_DataError);
            this.dataGridArea.SelectionChanged += new System.EventHandler(this.dataGridArea_SelectionChanged);
            // 
            // colObjectName
            // 
            this.colObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObjectName.DataPropertyName = "ObjectName";
            this.colObjectName.FillWeight = 124.2128F;
            this.colObjectName.HeaderText = "ObjectName";
            this.colObjectName.Name = "colObjectName";
            this.colObjectName.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 124.2128F;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colRegionID
            // 
            this.colRegionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRegionID.FillWeight = 71.06599F;
            this.colRegionID.HeaderText = "Region";
            this.colRegionID.Name = "colRegionID";
            // 
            // colAreaType
            // 
            this.colAreaType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAreaType.DataPropertyName = "AreaType";
            this.colAreaType.FillWeight = 80.50832F;
            this.colAreaType.HeaderText = "AreaType";
            this.colAreaType.Name = "colAreaType";
            // 
            // propertyGridArea
            // 
            this.propertyGridArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridArea.Location = new System.Drawing.Point(0, 0);
            this.propertyGridArea.Name = "propertyGridArea";
            this.propertyGridArea.Size = new System.Drawing.Size(104, 125);
            this.propertyGridArea.TabIndex = 0;
            // 
            // copyLocationToolStripMenuItem
            // 
            this.copyLocationToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.copy;
            this.copyLocationToolStripMenuItem.Name = "copyLocationToolStripMenuItem";
            this.copyLocationToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.copyLocationToolStripMenuItem.Text = "Copy Location";
            this.copyLocationToolStripMenuItem.Click += new System.EventHandler(this.copyLocationToolStripMenuItem_Click);
            // 
            // headerStripArea
            // 
            headerStripArea.AutoSize = false;
            headerStripArea.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            headerStripArea.ForeColor = System.Drawing.Color.Gray;
            headerStripArea.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            headerStripArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1});
            headerStripArea.Location = new System.Drawing.Point(0, 0);
            headerStripArea.Name = "headerStripArea";
            headerStripArea.Size = new System.Drawing.Size(458, 25);
            headerStripArea.TabIndex = 4;
            headerStripArea.Text = "headerStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            toolStripLabel1.Text = "Areas";
            // 
            // Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(headerStripArea);
            this.Name = "Area";
            this.Size = new System.Drawing.Size(458, 150);
            this.Load += new System.EventHandler(this.Area_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridArea)).EndInit();
            headerStripArea.ResumeLayout(false);
            headerStripArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridArea;
        private System.Windows.Forms.PropertyGrid propertyGridArea;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pasteLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOnMapToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colRegionID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAreaType;
        private System.Windows.Forms.ToolStripMenuItem copyLocationToolStripMenuItem;
    }
}
