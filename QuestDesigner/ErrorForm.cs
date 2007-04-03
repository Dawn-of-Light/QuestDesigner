/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DOL.Tools.QuestDesigner
{
    /// <summary>
    /// Summary description for ErrorForm.
    /// </summary>
    public class ErrorForm : Form
    {
        private Button btnExit;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelErrorIcon;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label labelErrorMessage;
        private RichTextBox rtbError;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public ErrorForm(Exception e)
        {            
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.Text = "Fatal Error: " + e.GetType().FullName;
            this.rtbError.Clear();
            this.rtbError.AppendText(e.Message);
            this.rtbError.AppendText("\n");
            this.rtbError.AppendText(e.GetType().FullName+e.StackTrace);
            
            ShowDialog();
        }
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.btnExit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelErrorIcon = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Location = new System.Drawing.Point(439, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 266);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(514, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // labelErrorIcon
            // 
            this.labelErrorIcon.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.error;
            this.labelErrorIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelErrorIcon.Location = new System.Drawing.Point(3, 0);
            this.labelErrorIcon.Name = "labelErrorIcon";
            this.labelErrorIcon.Padding = new System.Windows.Forms.Padding(3);
            this.labelErrorIcon.Size = new System.Drawing.Size(24, 24);
            this.labelErrorIcon.TabIndex = 3;
            this.labelErrorIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.labelErrorIcon);
            this.flowLayoutPanel2.Controls.Add(this.labelErrorMessage);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(514, 24);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.Location = new System.Drawing.Point(33, 3);
            this.labelErrorMessage.Margin = new System.Windows.Forms.Padding(3);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Padding = new System.Windows.Forms.Padding(3);
            this.labelErrorMessage.Size = new System.Drawing.Size(173, 19);
            this.labelErrorMessage.TabIndex = 4;
            this.labelErrorMessage.Text = "Unrecoverable error encountered:";
            // 
            // rtbError
            // 
            this.rtbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbError.Location = new System.Drawing.Point(0, 24);
            this.rtbError.Name = "rtbError";
            this.rtbError.Size = new System.Drawing.Size(514, 242);
            this.rtbError.TabIndex = 5;
            this.rtbError.Text = "";
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.btnExit;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 296);
            this.ControlBox = false;
            this.Controls.Add(this.rtbError);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorForm";
            this.ShowInTaskbar = false;
            this.Text = "Fatal Error";
            this.TopMost = true;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}