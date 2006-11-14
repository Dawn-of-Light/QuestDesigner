using QuestDesigner.Controls;
namespace QuestDesigner
{
	partial class QuestInfo
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
            QuestDesigner.Controls.HeaderStrip headerStrip2;
            System.Windows.Forms.ToolStripLabel toolStripLabel2;
            QuestDesigner.Controls.HeaderStrip headerStrip1;
            System.Windows.Forms.ToolStripLabel toolStripLabel1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label labelQuestName;
            System.Windows.Forms.Label labelTitle;
            System.Windows.Forms.Label labelAuthor;
            System.Windows.Forms.Label labelDate;
            System.Windows.Forms.Label labelVersion;
            System.Windows.Forms.Label labelNamespace;
            System.Windows.Forms.Label labelLevel;
            System.Windows.Forms.Label labelInvitingNPC;
            System.Windows.Forms.Label labelMaxQuestCount;
            System.Windows.Forms.Label labelNotes;
            this.QuestStep = new System.Windows.Forms.DataGridView();
            this.QuestName = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.TextBox();
            this.scriptDate = new System.Windows.Forms.DateTimePicker();
            this.Version = new System.Windows.Forms.TextBox();
            this.Namespace = new System.Windows.Forms.TextBox();
            this.LevelMin = new System.Windows.Forms.NumericUpDown();
            this.LevelMax = new System.Windows.Forms.NumericUpDown();
            this.InvitingNPC = new System.Windows.Forms.ComboBox();
            this.MaxQuestCount = new System.Windows.Forms.NumericUpDown();
            this.Notes = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            headerStrip2 = new QuestDesigner.Controls.HeaderStrip();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            headerStrip1 = new QuestDesigner.Controls.HeaderStrip();
            toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            labelQuestName = new System.Windows.Forms.Label();
            labelTitle = new System.Windows.Forms.Label();
            labelAuthor = new System.Windows.Forms.Label();
            labelDate = new System.Windows.Forms.Label();
            labelVersion = new System.Windows.Forms.Label();
            labelNamespace = new System.Windows.Forms.Label();
            labelLevel = new System.Windows.Forms.Label();
            labelInvitingNPC = new System.Windows.Forms.Label();
            labelMaxQuestCount = new System.Windows.Forms.Label();
            labelNotes = new System.Windows.Forms.Label();
            tableLayoutPanel5.SuspendLayout();
            headerStrip2.SuspendLayout();
            headerStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxQuestCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 6;
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            tableLayoutPanel5.Controls.Add(headerStrip2, 0, 0);
            tableLayoutPanel5.Controls.Add(headerStrip1, 0, 7);
            tableLayoutPanel5.Controls.Add(this.QuestStep, 0, 8);
            tableLayoutPanel5.Controls.Add(labelQuestName, 0, 1);
            tableLayoutPanel5.Controls.Add(this.QuestName, 1, 1);
            tableLayoutPanel5.Controls.Add(labelTitle, 0, 2);
            tableLayoutPanel5.Controls.Add(this.Title, 1, 2);
            tableLayoutPanel5.Controls.Add(labelAuthor, 0, 3);
            tableLayoutPanel5.Controls.Add(this.Author, 1, 3);
            tableLayoutPanel5.Controls.Add(labelDate, 0, 4);
            tableLayoutPanel5.Controls.Add(this.scriptDate, 1, 4);
            tableLayoutPanel5.Controls.Add(labelVersion, 0, 5);
            tableLayoutPanel5.Controls.Add(this.Version, 1, 5);
            tableLayoutPanel5.Controls.Add(labelNamespace, 0, 6);
            tableLayoutPanel5.Controls.Add(this.Namespace, 1, 6);
            tableLayoutPanel5.Controls.Add(labelLevel, 3, 1);
            tableLayoutPanel5.Controls.Add(this.LevelMin, 4, 1);
            tableLayoutPanel5.Controls.Add(this.LevelMax, 5, 1);
            tableLayoutPanel5.Controls.Add(labelInvitingNPC, 3, 2);
            tableLayoutPanel5.Controls.Add(this.InvitingNPC, 4, 2);
            tableLayoutPanel5.Controls.Add(labelMaxQuestCount, 3, 3);
            tableLayoutPanel5.Controls.Add(this.MaxQuestCount, 4, 3);
            tableLayoutPanel5.Controls.Add(labelNotes, 3, 4);
            tableLayoutPanel5.Controls.Add(this.Notes, 3, 5);
            tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 9;
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel5.Size = new System.Drawing.Size(606, 309);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // headerStrip2
            // 
            headerStrip2.AutoSize = false;
            tableLayoutPanel5.SetColumnSpan(headerStrip2, 6);
            headerStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            headerStrip2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            headerStrip2.ForeColor = System.Drawing.Color.White;
            headerStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            headerStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel2});
            headerStrip2.Location = new System.Drawing.Point(0, 0);
            headerStrip2.Name = "headerStrip2";
            headerStrip2.Size = new System.Drawing.Size(606, 30);
            headerStrip2.TabIndex = 23;
            headerStrip2.Text = "header";
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.ForeColor = System.Drawing.Color.Gray;
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(110, 27);
            toolStripLabel2.Text = "Quest Details";
            // 
            // headerStrip1
            // 
            headerStrip1.AutoSize = false;
            tableLayoutPanel5.SetColumnSpan(headerStrip1, 6);
            headerStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            headerStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            headerStrip1.ForeColor = System.Drawing.Color.White;
            headerStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            headerStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabel1});
            headerStrip1.Location = new System.Drawing.Point(0, 186);
            headerStrip1.Name = "headerStrip1";
            headerStrip1.Size = new System.Drawing.Size(606, 25);
            headerStrip1.TabIndex = 22;
            headerStrip1.Text = "header";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            toolStripLabel1.ForeColor = System.Drawing.Color.Gray;
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new System.Drawing.Size(94, 22);
            toolStripLabel1.Text = "Quest Steps";
            // 
            // QuestStep
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.QuestStep.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.QuestStep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.QuestStep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.QuestStep.BackgroundColor = System.Drawing.SystemColors.Control;
            this.QuestStep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel5.SetColumnSpan(this.QuestStep, 6);
            this.QuestStep.DataMember = "QuestStep";
            this.QuestStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestStep.Location = new System.Drawing.Point(3, 214);
            this.QuestStep.Name = "QuestStep";
            this.QuestStep.RowTemplate.Height = 24;
            this.QuestStep.Size = new System.Drawing.Size(600, 92);
            this.QuestStep.TabIndex = 21;
            // 
            // labelQuestName
            // 
            labelQuestName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelQuestName.AutoSize = true;
            labelQuestName.Location = new System.Drawing.Point(3, 36);
            labelQuestName.Name = "labelQuestName";
            labelQuestName.Size = new System.Drawing.Size(35, 13);
            labelQuestName.TabIndex = 0;
            labelQuestName.Text = "Name";
            // 
            // QuestName
            // 
            this.QuestName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuestName.Location = new System.Drawing.Point(115, 33);
            this.QuestName.Name = "QuestName";
            this.QuestName.Size = new System.Drawing.Size(175, 20);
            this.QuestName.TabIndex = 1;
            this.QuestName.Validating += new System.ComponentModel.CancelEventHandler(this.QuestName_Validating);
            // 
            // labelTitle
            // 
            labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelTitle.AutoSize = true;
            labelTitle.Location = new System.Drawing.Point(3, 63);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(27, 13);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Title";
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.Location = new System.Drawing.Point(115, 59);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(175, 20);
            this.Title.TabIndex = 3;
            // 
            // labelAuthor
            // 
            labelAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new System.Drawing.Point(3, 89);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new System.Drawing.Size(38, 13);
            labelAuthor.TabIndex = 4;
            labelAuthor.Text = "Author";
            // 
            // Author
            // 
            this.Author.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Author.Location = new System.Drawing.Point(115, 86);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(175, 20);
            this.Author.TabIndex = 5;
            // 
            // labelDate
            // 
            labelDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelDate.AutoSize = true;
            labelDate.Location = new System.Drawing.Point(3, 115);
            labelDate.Name = "labelDate";
            labelDate.Size = new System.Drawing.Size(30, 13);
            labelDate.TabIndex = 6;
            labelDate.Text = "Date";
            // 
            // scriptDate
            // 
            this.scriptDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptDate.Location = new System.Drawing.Point(115, 112);
            this.scriptDate.Name = "scriptDate";
            this.scriptDate.Size = new System.Drawing.Size(175, 20);
            this.scriptDate.TabIndex = 7;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Location = new System.Drawing.Point(3, 141);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new System.Drawing.Size(72, 13);
            labelVersion.TabIndex = 8;
            labelVersion.Text = "Script Version";
            // 
            // Version
            // 
            this.Version.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Version.Location = new System.Drawing.Point(115, 138);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(175, 20);
            this.Version.TabIndex = 9;
            // 
            // labelNamespace
            // 
            labelNamespace.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelNamespace.AutoSize = true;
            labelNamespace.Location = new System.Drawing.Point(2, 167);
            labelNamespace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            labelNamespace.Name = "labelNamespace";
            labelNamespace.Size = new System.Drawing.Size(64, 13);
            labelNamespace.TabIndex = 10;
            labelNamespace.Text = "Namespace";
            // 
            // Namespace
            // 
            this.Namespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Namespace.Location = new System.Drawing.Point(114, 163);
            this.Namespace.Margin = new System.Windows.Forms.Padding(2);
            this.Namespace.Name = "Namespace";
            this.Namespace.Size = new System.Drawing.Size(177, 20);
            this.Namespace.TabIndex = 11;
            this.Namespace.Validating += new System.ComponentModel.CancelEventHandler(this.Namespace_Validating);
            // 
            // labelLevel
            // 
            labelLevel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelLevel.AutoSize = true;
            labelLevel.Location = new System.Drawing.Point(316, 36);
            labelLevel.Name = "labelLevel";
            labelLevel.Size = new System.Drawing.Size(86, 13);
            labelLevel.TabIndex = 12;
            labelLevel.Text = "Level (min - max)";
            // 
            // LevelMin
            // 
            this.LevelMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LevelMin.Location = new System.Drawing.Point(428, 33);
            this.LevelMin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LevelMin.Name = "LevelMin";
            this.LevelMin.Size = new System.Drawing.Size(84, 20);
            this.LevelMin.TabIndex = 13;
            // 
            // LevelMax
            // 
            this.LevelMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LevelMax.Location = new System.Drawing.Point(518, 33);
            this.LevelMax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.LevelMax.Name = "LevelMax";
            this.LevelMax.Size = new System.Drawing.Size(85, 20);
            this.LevelMax.TabIndex = 14;
            // 
            // labelInvitingNPC
            // 
            labelInvitingNPC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelInvitingNPC.AutoSize = true;
            labelInvitingNPC.Location = new System.Drawing.Point(316, 63);
            labelInvitingNPC.Name = "labelInvitingNPC";
            labelInvitingNPC.Size = new System.Drawing.Size(66, 13);
            labelInvitingNPC.TabIndex = 15;
            labelInvitingNPC.Text = "Inviting NPC";
            // 
            // InvitingNPC
            // 
            tableLayoutPanel5.SetColumnSpan(this.InvitingNPC, 2);
            this.InvitingNPC.DisplayMember = "Name";
            this.InvitingNPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvitingNPC.FormattingEnabled = true;
            this.InvitingNPC.Location = new System.Drawing.Point(428, 59);
            this.InvitingNPC.Name = "InvitingNPC";
            this.InvitingNPC.Size = new System.Drawing.Size(175, 21);
            this.InvitingNPC.TabIndex = 16;
            this.InvitingNPC.ValueMember = "ObjectName";
            // 
            // labelMaxQuestCount
            // 
            labelMaxQuestCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            labelMaxQuestCount.AutoSize = true;
            labelMaxQuestCount.Location = new System.Drawing.Point(316, 89);
            labelMaxQuestCount.Name = "labelMaxQuestCount";
            labelMaxQuestCount.Size = new System.Drawing.Size(83, 13);
            labelMaxQuestCount.TabIndex = 17;
            labelMaxQuestCount.Text = "MaxQuestCount";
            // 
            // MaxQuestCount
            // 
            tableLayoutPanel5.SetColumnSpan(this.MaxQuestCount, 2);
            this.MaxQuestCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxQuestCount.Location = new System.Drawing.Point(428, 86);
            this.MaxQuestCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.MaxQuestCount.Name = "MaxQuestCount";
            this.MaxQuestCount.Size = new System.Drawing.Size(175, 20);
            this.MaxQuestCount.TabIndex = 18;
            // 
            // labelNotes
            // 
            labelNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            labelNotes.AutoSize = true;
            labelNotes.Location = new System.Drawing.Point(316, 122);
            labelNotes.Name = "labelNotes";
            labelNotes.Size = new System.Drawing.Size(103, 13);
            labelNotes.TabIndex = 19;
            labelNotes.Text = "Notes: (TODO\'s etc)";
            // 
            // Notes
            // 
            tableLayoutPanel5.SetColumnSpan(this.Notes, 3);
            this.Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Notes.Location = new System.Drawing.Point(316, 138);
            this.Notes.Multiline = true;
            this.Notes.Name = "Notes";
            tableLayoutPanel5.SetRowSpan(this.Notes, 2);
            this.Notes.Size = new System.Drawing.Size(287, 45);
            this.Notes.TabIndex = 20;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // QuestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tableLayoutPanel5);
            this.Name = "QuestInfo";
            this.Size = new System.Drawing.Size(606, 309);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            headerStrip2.ResumeLayout(false);
            headerStrip2.PerformLayout();
            headerStrip1.ResumeLayout(false);
            headerStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuestStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxQuestCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox Notes;
		private System.Windows.Forms.TextBox QuestName;
		private System.Windows.Forms.ComboBox InvitingNPC;
		private System.Windows.Forms.TextBox Title;
		private System.Windows.Forms.TextBox Author;
		private System.Windows.Forms.DateTimePicker scriptDate;
		private System.Windows.Forms.TextBox Version;
		private System.Windows.Forms.NumericUpDown LevelMin;
		private System.Windows.Forms.NumericUpDown LevelMax;
		private System.Windows.Forms.TextBox Namespace;
		private System.Windows.Forms.NumericUpDown MaxQuestCount;
		private System.Windows.Forms.DataGridView QuestStep;
		private System.Windows.Forms.ErrorProvider errorProvider;

	}
}
