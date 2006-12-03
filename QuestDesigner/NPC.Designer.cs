using DOL.Tools.QuestDesigner.Controls;
namespace DOL.Tools.QuestDesigner
{
	partial class NPC
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
            System.Windows.Forms.ImageList imageListNPC;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPC));
            System.Windows.Forms.ImageList imageListNPCLarge;
            System.Windows.Forms.ColumnHeader columnName;
            System.Windows.Forms.ColumnHeader columnType;
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Monster", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("NPC", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Merchants", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ToolStripButton B_ToggleGroups;
            this.propertyGridNPC = new System.Windows.Forms.PropertyGrid();
            this.splitContainerNPC = new System.Windows.Forms.SplitContainer();
            this.listViewNPC = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOnMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerStrip1 = new DOL.Tools.QuestDesigner.Controls.HeaderStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.B_NewNPC = new System.Windows.Forms.ToolStripButton();
            this.B_NewMob = new System.Windows.Forms.ToolStripButton();
            this.B_SearchNPC = new System.Windows.Forms.ToolStripButton();
            this.B_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.B_ListView = new System.Windows.Forms.ToolStripSplitButton();
            this.B_ListViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewSymbols = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            imageListNPC = new System.Windows.Forms.ImageList(this.components);
            imageListNPCLarge = new System.Windows.Forms.ImageList(this.components);
            columnName = new System.Windows.Forms.ColumnHeader();
            columnType = new System.Windows.Forms.ColumnHeader();
            B_ToggleGroups = new System.Windows.Forms.ToolStripButton();
            this.splitContainerNPC.Panel1.SuspendLayout();
            this.splitContainerNPC.Panel2.SuspendLayout();
            this.splitContainerNPC.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.headerStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListNPC
            // 
            imageListNPC.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNPC.ImageStream")));
            imageListNPC.TransparentColor = System.Drawing.Color.Transparent;
            imageListNPC.Images.SetKeyName(0, "npc.png");
            imageListNPC.Images.SetKeyName(1, "mob.png");
            // 
            // imageListNPCLarge
            // 
            imageListNPCLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNPCLarge.ImageStream")));
            imageListNPCLarge.TransparentColor = System.Drawing.Color.Transparent;
            imageListNPCLarge.Images.SetKeyName(0, "npc32.png");
            imageListNPCLarge.Images.SetKeyName(1, "mob32.png");
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 227;
            // 
            // columnType
            // 
            columnType.Text = "Type";
            columnType.Width = 95;
            // 
            // propertyGridNPC
            // 
            this.propertyGridNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridNPC.Enabled = false;
            this.propertyGridNPC.Location = new System.Drawing.Point(0, 0);
            this.propertyGridNPC.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGridNPC.Name = "propertyGridNPC";
            this.propertyGridNPC.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridNPC.Size = new System.Drawing.Size(241, 287);
            this.propertyGridNPC.TabIndex = 6;
            // 
            // splitContainerNPC
            // 
            this.splitContainerNPC.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "npcSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainerNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerNPC.Location = new System.Drawing.Point(0, 25);
            this.splitContainerNPC.Name = "splitContainerNPC";
            // 
            // splitContainerNPC.Panel1
            // 
            this.splitContainerNPC.Panel1.Controls.Add(this.listViewNPC);
            // 
            // splitContainerNPC.Panel2
            // 
            this.splitContainerNPC.Panel2.Controls.Add(this.propertyGridNPC);
            this.splitContainerNPC.Size = new System.Drawing.Size(595, 287);
            this.splitContainerNPC.SplitterDistance = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.NPCSplitterDistance;
            this.splitContainerNPC.TabIndex = 8;
            // 
            // listViewNPC
            // 
            this.listViewNPC.AllowColumnReorder = true;
            this.listViewNPC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnName,
            columnType});
            this.listViewNPC.ContextMenuStrip = this.contextMenuStrip;
            this.listViewNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNPC.FullRowSelect = true;
            this.listViewNPC.GridLines = true;
            listViewGroup1.Header = "Monster";
            listViewGroup1.Name = "LVG_Monster";
            listViewGroup2.Header = "NPC";
            listViewGroup2.Name = "LVG_NPC";
            listViewGroup3.Header = "Merchants";
            listViewGroup3.Name = "LVG_Merchants";
            this.listViewNPC.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listViewNPC.HideSelection = false;
            this.listViewNPC.LabelEdit = true;
            this.listViewNPC.LargeImageList = imageListNPCLarge;
            this.listViewNPC.Location = new System.Drawing.Point(0, 0);
            this.listViewNPC.Name = "listViewNPC";
            this.listViewNPC.Size = new System.Drawing.Size(350, 287);
            this.listViewNPC.SmallImageList = imageListNPC;
            this.listViewNPC.StateImageList = imageListNPC;
            this.listViewNPC.TabIndex = 6;
            this.listViewNPC.UseCompatibleStateImageBehavior = false;
            this.listViewNPC.View = System.Windows.Forms.View.Details;
            this.listViewNPC.SelectedIndexChanged += new System.EventHandler(this.listViewNPC_SelectedIndexChanged);
            this.listViewNPC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewNPC_KeyDown);
            this.listViewNPC.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewNPC_ColumnClick);
            this.listViewNPC.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewNPC_AfterLabelEdit);
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
            // headerStrip1
            // 
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.headerStrip1.ForeColor = System.Drawing.Color.White;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.B_NewNPC,
            this.B_NewMob,
            this.B_SearchNPC,
            this.B_Delete,
            this.toolStripSeparator2,
            this.B_ListView,
            B_ToggleGroups});
            this.headerStrip1.Location = new System.Drawing.Point(0, 0);
            this.headerStrip1.Name = "headerStrip1";
            this.headerStrip1.Size = new System.Drawing.Size(595, 25);
            this.headerStrip1.TabIndex = 7;
            this.headerStrip1.Text = "headerStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Gray;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(53, 22);
            this.toolStripLabel1.Text = "NPCs";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // B_NewNPC
            // 
            this.B_NewNPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_NewNPC.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.npc;
            this.B_NewNPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_NewNPC.Name = "B_NewNPC";
            this.B_NewNPC.Size = new System.Drawing.Size(23, 22);
            this.B_NewNPC.Text = "New NPC";
            this.B_NewNPC.ToolTipText = "Insert new NPC";
            this.B_NewNPC.Click += new System.EventHandler(this.B_NewNPC_Click);
            // 
            // B_NewMob
            // 
            this.B_NewMob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_NewMob.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.mob;
            this.B_NewMob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_NewMob.Name = "B_NewMob";
            this.B_NewMob.Size = new System.Drawing.Size(23, 22);
            this.B_NewMob.Text = "New Mob";
            this.B_NewMob.ToolTipText = "Insert new Mob";
            this.B_NewMob.Click += new System.EventHandler(this.B_NewMob_Click);
            // 
            // B_SearchNPC
            // 
            this.B_SearchNPC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_SearchNPC.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.searchNPC;
            this.B_SearchNPC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_SearchNPC.Name = "B_SearchNPC";
            this.B_SearchNPC.Size = new System.Drawing.Size(23, 22);
            this.B_SearchNPC.Text = "Search NPC";
            this.B_SearchNPC.ToolTipText = "Search NPC in DOL database";
            this.B_SearchNPC.Click += new System.EventHandler(this.B_SearchNPC_Click);
            // 
            // B_Delete
            // 
            this.B_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_Delete.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.delete;
            this.B_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_Delete.Name = "B_Delete";
            this.B_Delete.Size = new System.Drawing.Size(23, 22);
            this.B_Delete.Text = "Delete";
            this.B_Delete.Click += new System.EventHandler(this.B_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // B_ListView
            // 
            this.B_ListView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_ListView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.B_ListViewDetails,
            this.B_ListViewList,
            this.B_ListViewSymbols,
            this.B_ListViewTiles});
            this.B_ListView.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.listview;
            this.B_ListView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_ListView.Name = "B_ListView";
            this.B_ListView.Size = new System.Drawing.Size(32, 22);
            this.B_ListView.Text = "toolStripSplitButton1";
            this.B_ListView.ToolTipText = "Toggle Displaymode of ListView";
            this.B_ListView.ButtonClick += new System.EventHandler(this.B_ListView_ButtonClick);
            // 
            // B_ListViewDetails
            // 
            this.B_ListViewDetails.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_ListViewDetails.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.details;
            this.B_ListViewDetails.Name = "B_ListViewDetails";
            this.B_ListViewDetails.Size = new System.Drawing.Size(136, 22);
            this.B_ListViewDetails.Text = "Details";
            this.B_ListViewDetails.Click += new System.EventHandler(this.B_ListViewDetails_Click);
            // 
            // B_ListViewList
            // 
            this.B_ListViewList.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_ListViewList.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.list;
            this.B_ListViewList.Name = "B_ListViewList";
            this.B_ListViewList.Size = new System.Drawing.Size(136, 22);
            this.B_ListViewList.Text = "List";
            this.B_ListViewList.Click += new System.EventHandler(this.B_ListViewList_Click);
            // 
            // B_ListViewSymbols
            // 
            this.B_ListViewSymbols.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_ListViewSymbols.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.icons;
            this.B_ListViewSymbols.Name = "B_ListViewSymbols";
            this.B_ListViewSymbols.Size = new System.Drawing.Size(136, 22);
            this.B_ListViewSymbols.Text = "Symbols";
            this.B_ListViewSymbols.Click += new System.EventHandler(this.B_ListViewSymbols_Click);
            // 
            // B_ListViewTiles
            // 
            this.B_ListViewTiles.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_ListViewTiles.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.tiles;
            this.B_ListViewTiles.Name = "B_ListViewTiles";
            this.B_ListViewTiles.Size = new System.Drawing.Size(136, 22);
            this.B_ListViewTiles.Text = "Tiles";
            this.B_ListViewTiles.Click += new System.EventHandler(this.B_ListViewTiles_Click);
            // 
            // B_ToggleGroups
            // 
            B_ToggleGroups.Checked = true;
            B_ToggleGroups.CheckOnClick = true;
            B_ToggleGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            B_ToggleGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            B_ToggleGroups.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.listviewGroup;
            B_ToggleGroups.ImageTransparentColor = System.Drawing.Color.Magenta;
            B_ToggleGroups.Name = "B_ToggleGroups";
            B_ToggleGroups.Size = new System.Drawing.Size(23, 22);
            B_ToggleGroups.Text = "Toggle Grouping";
            B_ToggleGroups.CheckStateChanged += new System.EventHandler(this.B_ToggleGroups_CheckStateChanged);
            // 
            // NPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerNPC);
            this.Controls.Add(this.headerStrip1);
            this.Name = "NPC";
            this.Size = new System.Drawing.Size(595, 312);
            this.splitContainerNPC.Panel1.ResumeLayout(false);
            this.splitContainerNPC.Panel2.ResumeLayout(false);
            this.splitContainerNPC.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGridNPC;
		private HeaderStrip headerStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton B_NewNPC;
		private System.Windows.Forms.SplitContainer splitContainerNPC;
		private System.Windows.Forms.ToolStripButton B_NewMob;
		private System.Windows.Forms.ToolStripSplitButton B_ListView;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewTiles;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewSymbols;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewList;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewDetails;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton B_Delete;
		private System.Windows.Forms.ListView listViewNPC;
		private System.Windows.Forms.ToolStripButton B_SearchNPC;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pasteLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOnMapToolStripMenuItem;
	}
}
