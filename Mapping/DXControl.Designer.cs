namespace DOL.Tools.Mapping.Forms
{
    partial class DXControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public System.Windows.Forms.TrackBar ZoomSlider;
        public System.Windows.Forms.HScrollBar hScrollBar;
        public System.Windows.Forms.VScrollBar vScrollBar;
        public System.Windows.Forms.ToolStrip toolStrip;
        public System.Windows.Forms.ToolStripComboBox comboBoxMaps;
        private System.Windows.Forms.ToolStripLabel labelCoords;
        private System.Windows.Forms.ToolStripLabel labelObject;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabelRegion;
        private System.Windows.Forms.ToolStripMenuItem filterMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetZoomToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip objectToolTip;
        private System.Windows.Forms.ToolStripMenuItem mobnameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DXControl));
            this.ZoomSlider = new System.Windows.Forms.TrackBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.comboBoxMaps = new System.Windows.Forms.ToolStripComboBox();
            this.labelCoords = new System.Windows.Forms.ToolStripLabel();
            this.labelObject = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRegion = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mobnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectToolTip = new System.Windows.Forms.ToolTip(this.components);
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // ZoomSlider
            // 
            this.ZoomSlider.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.ZoomSlider, "ZoomSlider");
            this.ZoomSlider.LargeChange = 250;
            this.ZoomSlider.Maximum = 1000;
            this.ZoomSlider.Minimum = 50;
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.SmallChange = 100;
            this.ZoomSlider.TabStop = false;
            this.ZoomSlider.TickFrequency = 250;
            this.ZoomSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ZoomSlider.Value = 100;
            this.ZoomSlider.Scroll += new System.EventHandler(this.Zoom_Scroll);
            // 
            // hScrollBar
            // 
            resources.ApplyResources(this.hScrollBar, "hScrollBar");
            this.hScrollBar.LargeChange = 0;
            this.hScrollBar.Maximum = 0;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.SmallChange = 0;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            resources.ApplyResources(this.vScrollBar, "vScrollBar");
            this.vScrollBar.LargeChange = 0;
            this.vScrollBar.Maximum = 0;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.SmallChange = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxMaps,
            this.labelCoords,
            this.labelObject,
            this.toolStripLabelRegion});
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Stretch = true;
            // 
            // comboBoxMaps
            // 
            this.comboBoxMaps.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaps.DropDownWidth = 200;
            resources.ApplyResources(this.comboBoxMaps, "comboBoxMaps");
            this.comboBoxMaps.Name = "comboBoxMaps";
            this.comboBoxMaps.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaps_SelectionChangeCommitted);
            // 
            // labelCoords
            // 
            resources.ApplyResources(this.labelCoords, "labelCoords");
            this.labelCoords.Name = "labelCoords";
            // 
            // labelObject
            // 
            this.labelObject.Name = "labelObject";
            resources.ApplyResources(this.labelObject, "labelObject");
            // 
            // toolStripLabelRegion
            // 
            this.toolStripLabelRegion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelRegion.Name = "toolStripLabelRegion";
            resources.ApplyResources(this.toolStripLabelRegion, "toolStripLabelRegion");
            this.toolStripLabelRegion.Text = global::DOL.Tools.QuestDesigner.Properties.Resources.lblRegion;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobnameToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyLocationToolStripMenuItem,
            this.filterMenuItem,
            this.zoomToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // mobnameToolStripMenuItem
            // 
            this.mobnameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.mobnameToolStripMenuItem.Name = "mobnameToolStripMenuItem";
            resources.ApplyResources(this.mobnameToolStripMenuItem, "mobnameToolStripMenuItem");
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.add;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importObjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // copyLocationToolStripMenuItem
            // 
            this.copyLocationToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.copy;
            this.copyLocationToolStripMenuItem.Name = "copyLocationToolStripMenuItem";
            resources.ApplyResources(this.copyLocationToolStripMenuItem, "copyLocationToolStripMenuItem");
            this.copyLocationToolStripMenuItem.Click += new System.EventHandler(this.copyLocationToolStripMenuItem_Click);
            // 
            // filterMenuItem
            // 
            this.filterMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.searchNPC;
            this.filterMenuItem.Name = "filterMenuItem";
            resources.ApplyResources(this.filterMenuItem, "filterMenuItem");
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            toolStripSeparator1,
            this.resetZoomToolStripMenuItem});
            this.zoomToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.search;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            resources.ApplyResources(this.zoomToolStripMenuItem, "zoomToolStripMenuItem");
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            resources.ApplyResources(this.zoomInToolStripMenuItem, "zoomInToolStripMenuItem");
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            resources.ApplyResources(this.zoomOutToolStripMenuItem, "zoomOutToolStripMenuItem");
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            resources.ApplyResources(this.resetZoomToolStripMenuItem, "resetZoomToolStripMenuItem");
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ZoomSlider);
            this.panel1.Controls.Add(this.toolStrip);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // DXControl
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this, "$this");
            this.Name = "DXControl";
            this.Load += new System.EventHandler(this.DXControl_Load);
            this.MouseLeave += new System.EventHandler(this.DXControl_MouseLeave);
            this.Click += new System.EventHandler(this.DXControl_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseDown);
            this.Resize += new System.EventHandler(this.DXControl_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseUp);
            this.MouseEnter += new System.EventHandler(this.DXControl_MouseEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DXControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }

}