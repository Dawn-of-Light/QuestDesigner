using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace QuestDesigner.Controls
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
