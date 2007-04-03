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

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace DOL.Tools.QuestDesigner.Controls
{
	public class HeaderStrip : ToolStrip
	{		
		private ToolStripProfessionalRenderer	_pr=null;

		#region Public API
		public HeaderStrip()
		{
			this.Dock = DockStyle.Top;
			this.GripStyle = ToolStripGripStyle.Hidden;
			this.AutoSize = false;

			// Set renderer - override background painting
			SetRenderer();
			
			// Setup Headers
			Font font = SystemFonts.MenuFont;
			this.Font = new Font("Arial", font.SizeInPoints + 3.75F, FontStyle.Bold);
			this.ForeColor = System.Drawing.Color.Gray;

			ToolStripLabel tsl = new ToolStripLabel();
			tsl.Font = this.Font;
			tsl.Text = "I";

			this.Height = tsl.GetPreferredSize(Size.Empty).Height + 6;
		}
		
		#endregion

		#region Overrides
		protected override void OnRendererChanged(EventArgs e)
		{
			base.OnRendererChanged(e);
			// Work around bug with setting renderer in the constructor
			SetRenderer();
		}
		#endregion

		#region Private Implementation		

		private void SetRenderer()
		{
			// Set renderer - override background painting
			if ((this.Renderer is ToolStripProfessionalRenderer) && (this.Renderer != _pr))
			{
				if (_pr == null)
				{
					// Only swap out if we're setup to use a professional renderer
					_pr = new ToolStripProfessionalRenderer();
					_pr.RoundedEdges = false;
					_pr.RenderToolStripBackground += new ToolStripRenderEventHandler(Renderer_RenderToolStripBackground);
				}
				this.Renderer = _pr;
			}
		}
		#endregion

		#region Event Handlers
		void Renderer_RenderToolStripBackground(object sender, ToolStripRenderEventArgs e)
		{
			Color start;
			Color end;

			if (this.Renderer is ToolStripProfessionalRenderer)
			{
				ToolStripProfessionalRenderer pr = (this.Renderer as ToolStripProfessionalRenderer);
							
				start = pr.ColorTable.OverflowButtonGradientMiddle;
				end = pr.ColorTable.OverflowButtonGradientEnd;				
				
				Rectangle bounds = new Rectangle(Point.Empty, e.ToolStrip.Size);

				// Make sure we need to do work
				if ((bounds.Width > 0) && (bounds.Height > 0))
				{
					using (Brush b = new LinearGradientBrush(bounds, start, end, LinearGradientMode.Vertical))
					{
						e.Graphics.FillRectangle(b, bounds);
					}
				}
			}
		}		
		#endregion
	}	
}
