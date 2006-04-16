namespace QuestDesigner
{
	partial class AboutBox
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
			this.VerInfoGrp.SuspendLayout();
			this.AssembliesGrp.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// ProdEdition
			// 
			this.ProdEdition.Visible = false;
			// 
			// Company
			// 
			this.Company.Text = "DOL";
			// 
			// LicTo
			// 
			this.LicTo.Text = "Gandulf";
			// 
			// OrderOnlineLink
			// 
			this.OrderOnlineLink.Enabled = false;
			// 
			// LookForUpdatesLink
			// 
			this.LookForUpdatesLink.Click += new System.EventHandler(this.LookForUpdatesLink_Click);
			// 
			// ProdInfoLink
			// 
			this.ProdInfoLink.Click += new System.EventHandler(this.ProdInfoLink_Click);
			// 
			// CopyrightLabel
			// 
			this.CopyrightLabel.Text = "Copyright © 2005";
			this.CopyrightLabel.Visible = false;
			// 
			// AboutBox
			// 
			this.ClientSize = new System.Drawing.Size(530, 464);
			this.Name = "AboutBox";
			this.VerInfoGrp.ResumeLayout(false);
			this.AssembliesGrp.ResumeLayout(false);
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
