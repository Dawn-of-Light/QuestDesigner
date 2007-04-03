using DOL.Tools.QuestDesigner.Controls;
namespace DOL.Tools.QuestDesigner
{
	partial class Item
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
            System.Windows.Forms.ImageList imageListItem;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Item));
            System.Windows.Forms.ImageList imageListItemLarge;
            System.Windows.Forms.ColumnHeader columnName;
            System.Windows.Forms.ColumnHeader columnType;
            System.Windows.Forms.ToolStripButton B_ToggleGroups;
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Monster", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("NPC", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Merchants", System.Windows.Forms.HorizontalAlignment.Left);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewItem = new System.Windows.Forms.ListView();
            this.propertyGridItem = new System.Windows.Forms.PropertyGrid();
            this.headerStrip1 = new DOL.Tools.QuestDesigner.Controls.HeaderStrip();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.B_NewItem = new System.Windows.Forms.ToolStripButton();
            this.B_SearchItem = new System.Windows.Forms.ToolStripButton();
            this.B_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.B_ListView = new System.Windows.Forms.ToolStripSplitButton();
            this.B_ListViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewSymbols = new System.Windows.Forms.ToolStripMenuItem();
            this.B_ListViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            imageListItem = new System.Windows.Forms.ImageList(this.components);
            imageListItemLarge = new System.Windows.Forms.ImageList(this.components);
            columnName = new System.Windows.Forms.ColumnHeader();
            columnType = new System.Windows.Forms.ColumnHeader();
            B_ToggleGroups = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.headerStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListItem
            // 
            imageListItem.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListItem.ImageStream")));
            imageListItem.TransparentColor = System.Drawing.Color.Transparent;
            imageListItem.Images.SetKeyName(0, "item.png");
            // 
            // imageListItemLarge
            // 
            imageListItemLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListItemLarge.ImageStream")));
            imageListItemLarge.TransparentColor = System.Drawing.Color.Transparent;
            imageListItemLarge.Images.SetKeyName(0, "item32.png");
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
            // splitContainer1
            // 
            this.splitContainer1.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "ItemSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewItem);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.propertyGridItem);
            this.splitContainer1.Size = new System.Drawing.Size(595, 287);
            this.splitContainer1.SplitterDistance = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.ItemSplitterDistance;
            this.splitContainer1.TabIndex = 8;
            // 
            // listViewItem
            // 
            this.listViewItem.AllowColumnReorder = true;
            this.listViewItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnName,
            columnType});
            this.listViewItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewItem.FullRowSelect = true;
            this.listViewItem.GridLines = true;
            listViewGroup1.Header = "Monster";
            listViewGroup1.Name = "LVG_Monster";
            listViewGroup2.Header = "NPC";
            listViewGroup2.Name = "LVG_NPC";
            listViewGroup3.Header = "Merchants";
            listViewGroup3.Name = "LVG_Merchants";
            this.listViewItem.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listViewItem.HideSelection = false;
            this.listViewItem.LabelEdit = true;
            this.listViewItem.LargeImageList = imageListItemLarge;
            this.listViewItem.Location = new System.Drawing.Point(0, 0);
            this.listViewItem.Name = "listViewItem";
            this.listViewItem.Size = new System.Drawing.Size(350, 287);
            this.listViewItem.SmallImageList = imageListItem;
            this.listViewItem.StateImageList = imageListItem;
            this.listViewItem.TabIndex = 6;
            this.listViewItem.UseCompatibleStateImageBehavior = false;
            this.listViewItem.View = System.Windows.Forms.View.Details;
            this.listViewItem.SelectedIndexChanged += new System.EventHandler(this.listViewItem_SelectedIndexChanged);
            this.listViewItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewItem_KeyDown);
            this.listViewItem.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewItem_ColumnClick);
            this.listViewItem.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewItem_AfterLabelEdit);
            // 
            // propertyGridItem
            // 
            this.propertyGridItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridItem.Enabled = false;
            this.propertyGridItem.Location = new System.Drawing.Point(0, 0);
            this.propertyGridItem.Margin = new System.Windows.Forms.Padding(2);
            this.propertyGridItem.Name = "propertyGridItem";
            this.propertyGridItem.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.propertyGridItem.Size = new System.Drawing.Size(241, 287);
            this.propertyGridItem.TabIndex = 6;
            // 
            // headerStrip1
            // 
            this.headerStrip1.AutoSize = false;
            this.headerStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerStrip1.ForeColor = System.Drawing.Color.White;
            this.headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel,
            this.toolStripSeparator1,
            this.B_NewItem,
            this.B_SearchItem,
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
            // toolStripLabel
            // 
            this.toolStripLabel.ForeColor = System.Drawing.Color.Gray;
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel.Text = "Items";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // B_NewItem
            // 
            this.B_NewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_NewItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.item;
            this.B_NewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_NewItem.Name = "B_NewItem";
            this.B_NewItem.Size = new System.Drawing.Size(23, 22);
            this.B_NewItem.Text = "New Item";
            this.B_NewItem.ToolTipText = "Insert new Item";
            this.B_NewItem.Click += new System.EventHandler(this.B_NewItem_Click);
            // 
            // B_SearchItem
            // 
            this.B_SearchItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.B_SearchItem.Enabled = false;
            this.B_SearchItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.search;
            this.B_SearchItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.B_SearchItem.Name = "B_SearchItem";
            this.B_SearchItem.Size = new System.Drawing.Size(23, 22);
            this.B_SearchItem.Text = "Search Item";
            this.B_SearchItem.ToolTipText = "Search ItemTemplate in DOL database";
            this.B_SearchItem.Click += new System.EventHandler(this.B_SearchItem_Click);
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
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.headerStrip1);
            this.Name = "Item";
            this.Size = new System.Drawing.Size(595, 312);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.headerStrip1.ResumeLayout(false);
            this.headerStrip1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PropertyGrid propertyGridItem;
		private HeaderStrip headerStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton B_NewItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripSplitButton B_ListView;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewTiles;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewSymbols;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewList;
		private System.Windows.Forms.ToolStripMenuItem B_ListViewDetails;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton B_Delete;
		private System.Windows.Forms.ListView listViewItem;
        private System.Windows.Forms.ToolStripButton B_SearchItem;
	}
}
