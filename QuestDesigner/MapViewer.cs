using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;

namespace QuestDesigner.Controls
{
	/// <summary>
	/// Summary description for UserPictureBox.
	/// </summary>
	public class UserPictureBox : System.Windows.Forms.UserControl
	{

		private System.Windows.Forms.HScrollBar hScrollBar1;
		private System.Windows.Forms.VScrollBar vScrollBar1;

		private Image[,] imageCache;
		//
		protected GridData[] gridData = new GridData[5];
		int zoom = 0;

		protected GridData CurrentGridData
		{
			get
			{
				return gridData[zoom];
			}
		}

		protected int Zoom
		{
			get
			{
				return zoom;
			}

			set {
				zoom = value;
			}
		}

		public void SetZoom(int level, Point center)
		{

			// check vor invalid zoom range
			if (level < 0 || level >= gridData.Length)
				return;

			float xPercent = (float)((hScrollBar1.Value + (this.ClientSize.Width / 2))) / (CurrentGridData.GridSizeX * CurrentGridData.TileSize);
			float yPercent = (float)((vScrollBar1.Value + (this.ClientSize.Height / 2))) / (CurrentGridData.GridSizeY * CurrentGridData.TileSize);
			//xPercent:(event.clientX-parseInt(cart.style.left)+(cart.bounds.x*zoomData.tileSize))/(zoomData.gridSize[0]*zoomData.tileSize),
			//yPercent:(event.clientY-parseInt(cart.style.top)+(cart.bounds.y*zoomData.tileSize))/(zoomData.gridSize[1]*zoomData.tileSize)				

			//int firstTileX = Math.Min(CurrentGridData.GridSizeX - cartW, Math.Max(0, Math.floor(centerTileX - cartW / 2)));
			//int firstTileY = Math.Min(CurrentGridData.GridSizeY - cartH, Math.Max(0, Math.floor(centerTileY - cartH / 2)));

			xPercent = Math.Min(1, xPercent);
			yPercent = Math.Min(1, yPercent);

			zoom = level;
			//
			this.hScrollBar1.Minimum = 0;
			this.hScrollBar1.Maximum = CurrentGridData.GridSizeX * CurrentGridData.TileSize;
			this.hScrollBar1.Value = Math.Max(0, (int)(this.hScrollBar1.Maximum * xPercent) - (this.ClientSize.Width /2));

			this.vScrollBar1.Minimum = 0;
			this.vScrollBar1.Maximum = CurrentGridData.GridSizeY * CurrentGridData.TileSize;
			this.vScrollBar1.Value = Math.Max(0, (int)(this.vScrollBar1.Maximum * yPercent) - (this.ClientSize.Height /2));
			// TODO: Add any initialization after the InitForm call

			cartW = Math.Min((int)Math.Floor((decimal)this.ClientRectangle.Width / CurrentGridData.TileSize) + 2, CurrentGridData.GridSizeX);
			cartH = Math.Min((int)Math.Floor((decimal)this.ClientRectangle.Height / CurrentGridData.TileSize) + 2, CurrentGridData.GridSizeY);

			imageCache = (Image[,])Array.CreateInstance(typeof(Image), new int[] { CurrentGridData.GridSizeX, CurrentGridData.GridSizeY });

			Refresh();
		}

		int cartW, cartH;		

		public UserPictureBox()
		{
			InitializeGridData();

			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.MouseWheel += new MouseEventHandler(UserPictureBox_MouseWheel);

			SetZoom(0,new Point(0,0));			
			
			SelectZone(4, 3);
		}

		void UserPictureBox_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta>0 )
				SetZoom (Zoom + 1,e.Location);
			else if (e.Delta <0)
				SetZoom (Zoom - 1,e.Location);			

			Refresh();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
			this.SuspendLayout();
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.Location = new System.Drawing.Point(0, 128);
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(136, 16);
			this.hScrollBar1.TabIndex = 0;
			this.hScrollBar1.ValueChanged += new System.EventHandler(this.hScrollBar1_ValueChanged);
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// vScrollBar1
			// 
			this.vScrollBar1.Location = new System.Drawing.Point(136, 8);
			this.vScrollBar1.Name = "vScrollBar1";
			this.vScrollBar1.Size = new System.Drawing.Size(16, 112);
			this.vScrollBar1.TabIndex = 1;
			this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
			this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
			// 
			// UserPictureBox
			// 
			this.Controls.Add(this.vScrollBar1);
			this.Controls.Add(this.hScrollBar1);
			this.DoubleBuffered = true;
			this.Name = "UserPictureBox";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserPictureBox_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UserPictureBox_MouseMove);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserPictureBox_Paint);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserPictureBox_MouseUp);
			this.SizeChanged += new System.EventHandler(this.UserPictureBox_SizeChanged);
			this.ResumeLayout(false);

		}
		
		#endregion

		#region Scrollbar handling

		private int iOffsetX = 0;
		private int iOffsetY = 0;

		public int OffsetX
		{
			get
			{
				return iOffsetX;
			}
			set
			{
				if (value >= this.hScrollBar1.Minimum && value <= this.hScrollBar1.Maximum)
				{
					iOffsetX = value;
					hScrollBar1.Value = value;
					Invalidate();
				}
			}
		}

		public int OffsetY
		{
			get
			{
				return iOffsetY;
			}
			set
			{
				if (value >= this.vScrollBar1.Minimum && value <= this.vScrollBar1.Maximum)
				{
					iOffsetY = value;
					vScrollBar1.Value = value;
					Invalidate();
				}
			}
		}

		private void hScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			int nVal = e.NewValue;
			OffsetX = nVal;

		}

		private void vScrollBar1_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			int nVal = e.NewValue;
			OffsetY = nVal;
		}

		void vScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			iOffsetY = vScrollBar1.Value;
		}

		void hScrollBar1_ValueChanged(object sender, EventArgs e)
		{
			iOffsetX = hScrollBar1.Value;
		}

		private void SizeScrollBars()
		{			
			hScrollBar1.SetBounds(0, ClientRectangle.Height - hScrollBar1.Height, ClientRectangle.Width - vScrollBar1.Width, hScrollBar1.Height);
			vScrollBar1.SetBounds(ClientRectangle.Right - vScrollBar1.Width, 0, vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height);			

			Invalidate();
		}

		#endregion

		private void UserPictureBox_SizeChanged(object sender, System.EventArgs e)
		{
			SizeScrollBars();

			cartW = Math.Min((int)Math.Floor((decimal)this.ClientRectangle.Width / CurrentGridData.TileSize) + 2, CurrentGridData.GridSizeX);
			cartH = Math.Min((int)Math.Floor((decimal)this.ClientRectangle.Height / CurrentGridData.TileSize) + 2, CurrentGridData.GridSizeY);
		}

		private void UserPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			
			Image img = null;

			int firstX = OffsetX / CurrentGridData.TileSize;
			int firstY = OffsetY / CurrentGridData.TileSize;

			int paddingX = OffsetX % CurrentGridData.TileSize;
			int paddingY = OffsetY % CurrentGridData.TileSize;

			for (int x = 0; x < cartW; x++)
				for (int y = 0; y < cartH; y++)
				{
					img = LoadTile(x + firstX, y + firstY);
					if (img!=null) {
						g.DrawImage(img, x * CurrentGridData.TileSize - paddingX, y * CurrentGridData.TileSize - paddingY, CurrentGridData.TileSize, CurrentGridData.TileSize);
						g.DrawRectangle(SystemPens.ControlDark, x * CurrentGridData.TileSize - paddingX, y * CurrentGridData.TileSize - paddingY, CurrentGridData.TileSize, CurrentGridData.TileSize);
						g.DrawString("Koords:" + (x + firstX) + "/" + (y + firstY) + " = " + CoordToTile(x + firstX, y + firstY), SystemFonts.IconTitleFont, SystemBrushes.ControlText, x * CurrentGridData.TileSize - paddingX, y * CurrentGridData.TileSize - paddingY);
					}
				}

			g.FillRectangle(Brushes.Gray, ClientRectangle.Width - vScrollBar1.Width, ClientRectangle.Height - hScrollBar1.Height, vScrollBar1.Width, hScrollBar1.Height);
		}

		private Image LoadTile(int x, int y)
		{
			try
			{
				if (imageCache[x,y] == null)
					imageCache[x,y] = Image.FromFile(CurrentGridData.ImagePrefix + CoordToTile(x, y) + CurrentGridData.ImagePostfix);

				return imageCache[x,y];
			} catch {
				return null;
			}
		}

		private int CoordToTile(int x, int y)
		{
			return ((y * CurrentGridData.GridSizeX) + x + 1);			
		}

		protected void SelectZone(int offsetX, int offsetY)
		{
			this.hScrollBar1.Value = offsetX * CurrentGridData.ZoneSize;
			this.vScrollBar1.Value = offsetY * CurrentGridData.ZoneSize;

			Refresh();
		}

		protected void InitializeGridData()
		{
			gridData[0] = new GridData();
			gridData[0].ImagePrefix = "config/images/albion/m_";
			gridData[0].ImagePostfix = ".jpg";			
			gridData[0].GridSizeX = 3;
			gridData[0].GridSizeY = 4;			
			gridData[0].TileSize = 250;
			gridData[0].ZoneSize = 125;

			gridData[1] = new GridData();
			gridData[1].ImagePrefix = "config/images/albion/25d_";
			gridData[1].ImagePostfix = ".jpg";
			gridData[1].GridSizeX = 6;
			gridData[1].GridSizeY = 8;
			gridData[1].TileSize = 256;
			gridData[1].ZoneSize = 256;

			gridData[2] = new GridData();
			gridData[2].ImagePrefix = "config/images/albion/5c_";
			gridData[2].ImagePostfix = ".jpg";
			gridData[2].GridSizeX = 12;
			gridData[2].GridSizeY = 15;
			gridData[2].TileSize = 256;
			gridData[2].ZoneSize = 512;

			gridData[3] = new GridData();
			gridData[3].ImagePrefix = "config/images/albion/1k_";
			gridData[3].ImagePostfix = ".jpg";
			gridData[3].GridSizeX = 12;
			gridData[3].GridSizeY = 15;
			gridData[3].TileSize = 512;
			gridData[3].ZoneSize = 1024;

			gridData[4] = new GridData();
			gridData[4].ImagePrefix = "config/images/albion/2k_";
			gridData[4].ImagePostfix = ".jpg";
			gridData[4].GridSizeX = 23;
			gridData[4].GridSizeY = 29;
			gridData[4].TileSize = 512;
			gridData[4].ZoneSize = 2048;
		}		

		protected class GridData
		{
			private int tileSize;

			public int TileSize
			{
				get { return tileSize; }
				set { tileSize = value; }
			}

			private int zoneSize;

			public int ZoneSize
			{
				get { return zoneSize; }
				set { zoneSize = value; }
			}

			private int gridSizeX;

			public int GridSizeX
			{
				get { return gridSizeX; }
				set { gridSizeX = value; }
			}

			private int gridSizeY;

			public int GridSizeY
			{
				get { return gridSizeY; }
				set { gridSizeY = value; }
			}
			private string imagePrefix;

			public string ImagePrefix
			{
				get { return imagePrefix; }
				set { imagePrefix = value; }
			}
			private string imagePostfix;

			public string ImagePostfix
			{
				get { return imagePostfix; }
				set { imagePostfix = value; }
			}

			public GridData()
			{

			}

		}

		
		Point originalLocation;
		Point lastPosition;
		bool capture = false;
		private void UserPictureBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{				
				if (capture)
				{										
					int deltaX = lastPosition.X - e.X;
					int deltaY = lastPosition.Y - e.Y;

					OffsetX -= deltaX;
					OffsetY -= deltaY;
					
					Refresh();					
					lastPosition = e.Location;
					
					
				}
			}
		}

		private void UserPictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				capture = false;
				//Cursor.Position = PointToScreen(originalLocation);				
				//Cursor.Show();				
			}
		}

		private void UserPictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				capture = true;
				//originalLocation = e.Location;
				lastPosition = e.Location;
				//Cursor.Hide();
			}
		}
	}

	

}
