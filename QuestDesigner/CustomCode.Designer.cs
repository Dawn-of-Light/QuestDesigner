namespace DOL.Tools.QuestDesigner
{
	partial class CustomCode
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
			DOL.Tools.QuestDesigner.Controls.HeaderStrip headerStripCustomCode;
			System.Windows.Forms.ToolStripLabel toolStripLabelCustomCode;
			NETXP.Controls.Docking.Renderers.Office2003 office20031 = new NETXP.Controls.Docking.Renderers.Office2003();
			NETXP.Library.DynamicColorTable dynamicColorTable1 = new NETXP.Library.DynamicColorTable();
			this.tabControlCodeSection = new NETXP.Controls.Docking.TabControl();
			this.tabPageInit = new NETXP.Controls.Docking.TabPage();
			this.textBoxInitCode = new System.Windows.Forms.TextBox();
			this.tabPageLoaded = new NETXP.Controls.Docking.TabPage();
			this.textBoxLoadedCode = new System.Windows.Forms.TextBox();
			this.tabPageUnloaded = new NETXP.Controls.Docking.TabPage();
			this.textBoxUnloadedCode = new System.Windows.Forms.TextBox();
			headerStripCustomCode = new DOL.Tools.QuestDesigner.Controls.HeaderStrip();
			toolStripLabelCustomCode = new System.Windows.Forms.ToolStripLabel();
			headerStripCustomCode.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControlCodeSection)).BeginInit();
			this.tabControlCodeSection.SuspendLayout();
			this.tabPageInit.SuspendLayout();
			this.tabPageLoaded.SuspendLayout();
			this.tabPageUnloaded.SuspendLayout();
			this.SuspendLayout();
			// 
			// headerStripCustomCode
			// 
			headerStripCustomCode.AutoSize = false;
			headerStripCustomCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			headerStripCustomCode.ForeColor = System.Drawing.Color.Gray;
			headerStripCustomCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			headerStripCustomCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabelCustomCode});
			headerStripCustomCode.Location = new System.Drawing.Point(0, 0);
			headerStripCustomCode.Name = "headerStripCustomCode";
			headerStripCustomCode.Size = new System.Drawing.Size(585, 25);
			headerStripCustomCode.TabIndex = 3;
			headerStripCustomCode.Text = "headerStrip1";
			// 
			// toolStripLabelCustomCode
			// 
			toolStripLabelCustomCode.Name = "toolStripLabelCustomCode";
			toolStripLabelCustomCode.Size = new System.Drawing.Size(114, 22);
			toolStripLabelCustomCode.Text = "Custom Code";
			// 
			// tabControlCodeSection
			// 
			this.tabControlCodeSection.Appearance = NETXP.Controls.Docking.TabPosition.Top;
			this.tabControlCodeSection.BoldSelectedPage = true;
			this.tabControlCodeSection.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlCodeSection.Location = new System.Drawing.Point(0, 25);
			this.tabControlCodeSection.Name = "tabControlCodeSection";
			this.tabControlCodeSection.PixelArea = true;
			this.tabControlCodeSection.PixelBorder = false;
			this.tabControlCodeSection.PositionTop = true;
			office20031.ColorTable = dynamicColorTable1;
			this.tabControlCodeSection.Renderer = office20031;
			this.tabControlCodeSection.ShowArrows = false;
			this.tabControlCodeSection.ShowClose = false;
			this.tabControlCodeSection.ShrinkPagesToFit = false;
			this.tabControlCodeSection.Size = new System.Drawing.Size(585, 327);
			this.tabControlCodeSection.TabIndex = 3;
			this.tabControlCodeSection.TabPages.AddRange(new NETXP.Controls.Docking.TabPage[] {
            this.tabPageInit,
            this.tabPageLoaded,
            this.tabPageUnloaded});
			// 
			// tabPageInit
			// 
			this.tabPageInit.Controls.Add(this.textBoxInitCode);
			this.tabPageInit.Location = new System.Drawing.Point(0, 23);
			this.tabPageInit.Name = "tabPageInit";
			this.tabPageInit.Size = new System.Drawing.Size(585, 304);
			this.tabPageInit.TabIndex = 3;
			this.tabPageInit.Title = "Initialization";
			this.tabPageInit.ToolTipText = "Initialization";
			// 
			// textBoxInitCode
			// 
			this.textBoxInitCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxInitCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxInitCode.Location = new System.Drawing.Point(0, 0);
			this.textBoxInitCode.Multiline = true;
			this.textBoxInitCode.Name = "textBoxInitCode";
			this.textBoxInitCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxInitCode.Size = new System.Drawing.Size(585, 304);
			this.textBoxInitCode.TabIndex = 1;
			this.textBoxInitCode.WordWrap = false;
			// 
			// tabPageLoaded
			// 
			this.tabPageLoaded.Controls.Add(this.textBoxLoadedCode);
			this.tabPageLoaded.Location = new System.Drawing.Point(0, 23);
			this.tabPageLoaded.Name = "tabPageLoaded";
			this.tabPageLoaded.Size = new System.Drawing.Size(585, 304);
			this.tabPageLoaded.TabIndex = 4;
			this.tabPageLoaded.Title = "Script Loaded";
			this.tabPageLoaded.ToolTipText = "Script Loaded";
			// 
			// textBoxLoadedCode
			// 
			this.textBoxLoadedCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxLoadedCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxLoadedCode.Location = new System.Drawing.Point(0, 0);
			this.textBoxLoadedCode.Multiline = true;
			this.textBoxLoadedCode.Name = "textBoxLoadedCode";
			this.textBoxLoadedCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxLoadedCode.Size = new System.Drawing.Size(585, 304);
			this.textBoxLoadedCode.TabIndex = 0;
			this.textBoxLoadedCode.WordWrap = false;
			// 
			// tabPageUnloaded
			// 
			this.tabPageUnloaded.Controls.Add(this.textBoxUnloadedCode);
			this.tabPageUnloaded.Location = new System.Drawing.Point(0, 23);
			this.tabPageUnloaded.Name = "tabPageUnloaded";
			this.tabPageUnloaded.Size = new System.Drawing.Size(585, 304);
			this.tabPageUnloaded.TabIndex = 5;
			this.tabPageUnloaded.Title = "Script Unloaded";
			this.tabPageUnloaded.ToolTipText = "Script Unloaded";
			// 
			// textBoxUnloadedCode
			// 
			this.textBoxUnloadedCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxUnloadedCode.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxUnloadedCode.Location = new System.Drawing.Point(0, 0);
			this.textBoxUnloadedCode.Multiline = true;
			this.textBoxUnloadedCode.Name = "textBoxUnloadedCode";
			this.textBoxUnloadedCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxUnloadedCode.Size = new System.Drawing.Size(585, 304);
			this.textBoxUnloadedCode.TabIndex = 0;
			this.textBoxUnloadedCode.WordWrap = false;
			// 
			// CustomCode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabControlCodeSection);
			this.Controls.Add(headerStripCustomCode);
			this.Name = "CustomCode";
			this.Size = new System.Drawing.Size(585, 352);
			headerStripCustomCode.ResumeLayout(false);
			headerStripCustomCode.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tabControlCodeSection)).EndInit();
			this.tabControlCodeSection.ResumeLayout(false);
			this.tabPageInit.ResumeLayout(false);
			this.tabPageInit.PerformLayout();
			this.tabPageLoaded.ResumeLayout(false);
			this.tabPageLoaded.PerformLayout();
			this.tabPageUnloaded.ResumeLayout(false);
			this.tabPageUnloaded.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private NETXP.Controls.Docking.TabPage tabPageInit;
		private System.Windows.Forms.TextBox textBoxInitCode;
		private NETXP.Controls.Docking.TabPage tabPageLoaded;
		private System.Windows.Forms.TextBox textBoxLoadedCode;
		private NETXP.Controls.Docking.TabPage tabPageUnloaded;
		private System.Windows.Forms.TextBox textBoxUnloadedCode;
		public NETXP.Controls.Docking.TabControl tabControlCodeSection;
	}
}
