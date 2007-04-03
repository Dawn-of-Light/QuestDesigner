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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using vbAccelerator.Components.Controls;
using System.Drawing;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	public class BaseSelector : Form, ISelector
	{
		public int ItemID;
		public char Param;
		protected ListBox list;
		protected ShadowTextBox text;
		private LinkLabel linkLabelMore;
		private LinkLabel linkLabelDelete;
		private FlowLayoutPanel linkPanel;
private bool editable = true;

		public event OnItemSelectedEventHandler OnItemSelected;
		public event OnItemSelectedEventHandler OnItemAdding;
		public event OnItemSelectedEventHandler OnItemDeleting;

		public BaseSelector()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();			
		}

		public BaseSelector(int id, char param)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();			

			this.list.DrawItem += new DrawItemEventHandler(list_DrawItem);			
			ItemID = id;
			Param = param;
		}				

		protected override void OnLoad(EventArgs e)
		{		
			base.OnLoad(e);

			// hide list if empty
			list.Visible = (list.Items.Count > 0);

			int height = this.Padding.Vertical;
			if (text.Visible)
				height += text.Height;

			if (list.Visible)
				height += list.Height;

			if (linkPanel.Visible)
				height += linkPanel.Height;

			this.Height = height;

			if (MultiLine)
				this.Width = 158 * 2;
		}

		public bool MultiLine
		{
			get
			{
				return text.Multiline;
			}
			set
			{								 					 
				if (value)
				{					
					text.Height = 13 * 4;										
				}
				else
				{
					text.Height = 13;										
				}
				text.Multiline = value;
			}
		}

		public bool Editable
		{
			get
			{
				return editable;
			}
			set
			{
				editable = value;
				text.Visible = editable;
			}
		}

		public object SelectedValue
		{
			get
			{
				if (text.Text == list.Text)
					return list.SelectedValue != null ? list.SelectedValue : list.SelectedItem;
				else
					return text.Text;
			}
			set
			{
				list.SelectedValue = value;				
				text.Text = !String.IsNullOrEmpty(list.Text)? list.Text: Convert.ToString(value);
				
			}
		}

		public bool ShowMoreButton
		{
			get
			{
				return linkLabelMore.Visible;
			}
			set
			{
				linkLabelMore.Visible = value;
				linkPanel.Visible = linkLabelMore.Visible || linkLabelDelete.Visible;
			}
		}

		public bool ShowDeleteButton
		{
			get
			{
				return linkLabelDelete.Visible;
			}
			set
			{
				linkLabelDelete.Visible = value;
				linkPanel.Visible = linkLabelMore.Visible || linkLabelDelete.Visible;
			}
		}		
	
		protected virtual Image getImage(int index)
		{
			return global::DOL.Tools.QuestDesigner.Properties.Resources.info;
		}

		private void list_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			try
			{
				if (e.Index >= 0)
				{
					Image myImage = getImage(e.Index);

					Rectangle rectImage = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
					// adjusting the width by the same proportion as the height was adjusted
					rectImage.Width = (int)Math.Round(myImage.Width * ((double)e.Bounds.Height / myImage.Height));

					e.Graphics.DrawImage(myImage, rectImage);
					e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

					e.Graphics.DrawString(list.GetItemText(list.Items[e.Index]), list.Font, new SolidBrush(e.ForeColor),
							e.Bounds.Left + myImage.Width, e.Bounds.Top);
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
			}
			// Draws the rectangle around the selected item.
			e.DrawFocusRectangle();
		}

		/// <summary>
		/// Paint the form and draw a neat border.
		/// </summary>
		/// <param name="e">Information about the paint event</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Rectangle borderRect = new Rectangle(this.ClientRectangle.Location, this.ClientRectangle.Size);
			borderRect.Width -= 1;
			borderRect.Height -= 1;
			e.Graphics.DrawRectangle(SystemPens.ControlDark, borderRect);

			if (text.Visible)
			{
				int y = borderRect.Top + text.Top+ text.Height+text.Margin.Vertical;
				e.Graphics.DrawLine(SystemPens.ControlDark, borderRect.Left, y, borderRect.Left + borderRect.Width, y);
			}
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.list = new System.Windows.Forms.ListBox();
			this.text = new DOL.Tools.QuestDesigner.Controls.ShadowTextBox();
			this.linkLabelMore = new System.Windows.Forms.LinkLabel();
			this.linkLabelDelete = new System.Windows.Forms.LinkLabel();
			this.linkPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.linkPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// list
			// 
			this.list.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.list.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.list.FormattingEnabled = true;
			this.list.Location = new System.Drawing.Point(1, 14);
			this.list.Margin = new System.Windows.Forms.Padding(0);
			this.list.MinimumSize = new System.Drawing.Size(150, 100);
			this.list.Name = "list";
			this.list.ScrollAlwaysVisible = true;
			this.list.Size = new System.Drawing.Size(158, 104);
			this.list.TabIndex = 0;
			this.list.DoubleClick += new System.EventHandler(this.list_DoubleClick);
			this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
			this.list.KeyDown += new System.Windows.Forms.KeyEventHandler(this.list_KeyDown);
			// 
			// text
			// 
			this.text.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.text.Dock = System.Windows.Forms.DockStyle.Top;
			this.text.Location = new System.Drawing.Point(1, 1);
			this.text.Margin = new System.Windows.Forms.Padding(0);
			this.text.MinimumSize = new System.Drawing.Size(150, 13);
			this.text.Name = "text";
			this.text.Size = new System.Drawing.Size(158, 13);
			this.text.TabIndex = 1;
			this.text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
			// 
			// linkLabelMore
			// 
			this.linkLabelMore.AutoSize = true;
			this.linkLabelMore.Location = new System.Drawing.Point(116, 0);
			this.linkLabelMore.Name = "linkLabelMore";
			this.linkLabelMore.Size = new System.Drawing.Size(39, 13);
			this.linkLabelMore.TabIndex = 2;
			this.linkLabelMore.TabStop = true;
			this.linkLabelMore.Text = "more...";
			this.linkLabelMore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMore_LinkClicked);
			// 
			// linkLabelDelete
			// 
			this.linkLabelDelete.AutoSize = true;
			this.linkLabelDelete.Location = new System.Drawing.Point(74, 0);
			this.linkLabelDelete.Name = "linkLabelDelete";
			this.linkLabelDelete.Size = new System.Drawing.Size(36, 13);
			this.linkLabelDelete.TabIndex = 3;
			this.linkLabelDelete.TabStop = true;
			this.linkLabelDelete.Text = "delete";
			this.linkLabelDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDelete_LinkClicked);
			// 
			// linkPanel
			// 
			this.linkPanel.BackColor = System.Drawing.Color.Transparent;
			this.linkPanel.Controls.Add(this.linkLabelMore);
			this.linkPanel.Controls.Add(this.linkLabelDelete);
			this.linkPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.linkPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.linkPanel.Location = new System.Drawing.Point(1, 123);
			this.linkPanel.Name = "linkPanel";
			this.linkPanel.Size = new System.Drawing.Size(158, 13);
			this.linkPanel.TabIndex = 4;
			// 
			// BaseSelector
			// 
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(160, 137);
			this.Controls.Add(this.list);
			this.Controls.Add(this.linkPanel);
			this.Controls.Add(this.text);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new System.Drawing.Size(150, 30);
			this.Name = "BaseSelector";
			this.Padding = new System.Windows.Forms.Padding(1);
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.linkPanel.ResumeLayout(false);
			this.linkPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion		

		private void SelectItem(object item)
		{
			if (OnItemSelected != null)
			{
				this.OnItemSelected(this, new ItemSelectorEvent(ItemID, Param, item));
			}
		}

		private void list_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SelectItem(list.SelectedValue != null ? list.SelectedValue : list.SelectedItem);
				this.Close();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void list_DoubleClick(object sender, EventArgs e)
		{
			SelectItem(list.SelectedValue!=null? list.SelectedValue: list.SelectedItem);
			this.Close();
		}

		private void text_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
                text.Text = text.Text.Replace('{', '<');
                text.Text = text.Text.Replace('}', '>');
				SelectItem(text.Text);
				this.Close();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void list_SelectedIndexChanged(object sender, EventArgs e)
		{
			text.Text = list.Text;
		}

		private void linkLabelMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.OnItemAdding!=null)
				this.OnItemAdding(this,new ItemSelectorEvent(ItemID,Param,SelectedValue));
			this.Close();
		}

		private void linkLabelDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.OnItemDeleting != null)
				this.OnItemDeleting(this,new ItemSelectorEvent(ItemID, Param, SelectedValue));
			this.Close();
		}
	}

	public class ShadowTextBox : TextBox
	{
		public ShadowTextBox() : base() { }

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			
			int y = pevent.ClipRectangle.Top+ pevent.ClipRectangle.Height -1;
			pevent.Graphics.DrawLine(SystemPens.ControlDark, pevent.ClipRectangle.Left, y, pevent.ClipRectangle.Right, y);
		}
	}
}
