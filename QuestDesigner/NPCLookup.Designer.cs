namespace DOL.Tools.QuestDesigner
{
	partial class NPCLookupForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NPCLookupForm));
			this.comboBoxNPC = new System.Windows.Forms.ComboBox();
			this.buttonAccept = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.propertyGridNPC = new System.Windows.Forms.PropertyGrid();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBoxNPC
			// 
			this.comboBoxNPC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBoxNPC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.tableLayoutPanel1.SetColumnSpan(this.comboBoxNPC, 2);
			this.comboBoxNPC.DisplayMember = "MobID";
			this.comboBoxNPC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.comboBoxNPC.FormattingEnabled = true;
			this.comboBoxNPC.Location = new System.Drawing.Point(3, 3);
			this.comboBoxNPC.Name = "comboBoxNPC";
			this.comboBoxNPC.Size = new System.Drawing.Size(274, 21);
			this.comboBoxNPC.TabIndex = 0;
			this.comboBoxNPC.ValueMember = "MobID";
			this.comboBoxNPC.SelectedIndexChanged += new System.EventHandler(this.comboBoxNPC_SelectedIndexChanged);
			// 
			// buttonAccept
			// 
			this.buttonAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAccept.Location = new System.Drawing.Point(121, 200);
			this.buttonAccept.Name = "buttonAccept";
			this.buttonAccept.Size = new System.Drawing.Size(75, 22);
			this.buttonAccept.TabIndex = 1;
			this.buttonAccept.Text = "Accept";
			this.buttonAccept.UseVisualStyleBackColor = true;
			this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(202, 200);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 22);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.comboBoxNPC, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonAccept, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.propertyGridNPC, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, -3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 225);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// propertyGridNPC
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.propertyGridNPC, 2);
			this.propertyGridNPC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGridNPC.HelpVisible = false;
			this.propertyGridNPC.Location = new System.Drawing.Point(2, 29);
			this.propertyGridNPC.Margin = new System.Windows.Forms.Padding(2);
			this.propertyGridNPC.Name = "propertyGridNPC";
			this.propertyGridNPC.Size = new System.Drawing.Size(276, 166);
			this.propertyGridNPC.TabIndex = 3;
			this.propertyGridNPC.ToolbarVisible = false;
			// 
			// NPCLookupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 225);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NPCLookupForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Lookup NPC";
			this.TopMost = true;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxNPC;
		private System.Windows.Forms.Button buttonAccept;
		private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PropertyGrid propertyGridNPC;
	}
}