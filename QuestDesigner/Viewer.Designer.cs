using QuestDesigner.Controls;
namespace QuestDesigner
{
	partial class Viewer
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
			this.userPictureBox1 = new QuestDesigner.Controls.UserPictureBox();
			this.SuspendLayout();
			// 
			// userPictureBox1
			// 
			this.userPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userPictureBox1.Location = new System.Drawing.Point(0, 0);
			this.userPictureBox1.Name = "userPictureBox1";
			this.userPictureBox1.OffsetX = 500;
			this.userPictureBox1.OffsetY = 375;
			this.userPictureBox1.Size = new System.Drawing.Size(279, 270);
			this.userPictureBox1.TabIndex = 0;
			// 
			// Viewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(279, 270);
			this.Controls.Add(this.userPictureBox1);
			this.Name = "Viewer";
			this.Text = "Viewer";
			this.ResumeLayout(false);

		}

		#endregion

		private QuestDesigner.Controls.UserPictureBox userPictureBox1;

	}
}