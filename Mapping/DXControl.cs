using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DOL.Tools.Mapping.DX;
using DOL.Tools.Mapping.DX.Meshes;
using DOL.Tools.Mapping.Map;
using Timer=System.Timers.Timer;
using DOL.Tools.QuestDesigner.Util;
using DOL.Tools.QuestDesigner;
using DOL.Tools.Mapping.Modules;
using DOL.Tools.QuestDesigner.QuestDesigner.Util;
using DOL.Tools.QuestDesigner.Properties;
using System.Diagnostics;
using DOL.Database;

namespace DOL.Tools.Mapping.Forms
{
    /// <summary>
    /// Summary description for DXControl.
    /// </summary>
    public class DXControl : UserControl
    {
       
        public TrackBar ZoomSlider;
        public HScrollBar hScrollBar;
        public VScrollBar vScrollBar;        
        private bool MapMoving = false;
        private bool ObjectMoving = false;
        private GeometryObj m_SelectedObject;
        private Point MouseMoveStart = new Point(-1, -1);
        private Vector3 LastMouseVector = new Vector3();
        private int MouseValueH = 0;
        private int MouseValueV = 0;
        private Matrix View = Matrix.Zero;
        private Matrix Proj = Matrix.Zero;        
        public GeometryObj HBObject;
        public ToolStrip toolStrip;
        public ToolStripComboBox comboBoxMaps;
        private ToolStripLabel labelCoords;
        private ToolStripLabel labelObject;
        public ContextMenuStrip contextMenuStrip;
        private IContainer components;
        private ToolStripMenuItem copyLocationToolStripMenuItem;
        private ToolStripLabel toolStripLabelRegion;
        public Matrix ControlMeshMatrix;

        private int cachedRegionID = -1;
        private ToolStripMenuItem filterMenuItem;
        private Vector3 cachedLocation;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private Panel panel1;
        private ToolTip objectToolTip;
        private ToolStripMenuItem mobnameToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;

        private static Set<GeometryObj> geoObjects = new Set<GeometryObj>();

        public static Set<GeometryObj> GeoObjects
        {
            get { return geoObjects; }
        }

        protected GeometryObj SelectedObject
        {
            get { return m_SelectedObject; }
            set 
            { 
                m_SelectedObject = value;
                                
                if (SelectedObject != null)
                {
                    mobnameToolStripMenuItem.Text = SelectedObject.Modul.GetInfoText(SelectedObject);
                    mobnameToolStripMenuItem.Visible = true;
                    toolStripSeparator3.Visible = true;

                    if (SelectedObject.Modul is DatabaseMobModule)
                    {
                        importToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        importToolStripMenuItem.Enabled = false;
                    }
                }
                else
                {
                    mobnameToolStripMenuItem.Visible = false;
                    toolStripSeparator3.Visible = false;
                    importToolStripMenuItem.Enabled = false;
                }
            }
        }

        public DXControl()
        {                       
            DB.DatabaseLoaded += new DB.DatabaseLoadedEventHandler(DB_DatabaseLoaded);
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //Mouse?
            MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            ZoomSlider.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            hScrollBar.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            vScrollBar.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);

            // Styles
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, false);

            // TODO: Add any initialization after the InitializeComponent call
            
        }

        public void SetDatabaseSupport(bool support)
        {
            foreach (ToolStripItem item in filterMenuItem.DropDownItems) {
                if (item.Name == DatabaseMobModule.MODULE_NAME || item.Name == DatabaseWorldObjectModule.MODULE_NAME) {
                    item.Enabled = support;
                }
            }                
        }		

        void DB_DatabaseLoaded()
        {
            
            RegionMgr.PreloadRegions();            
            ModulMgr.PreloadModules();            
        }

        public void ShowLocation(Vector3 point, int regionID)
        {
            if (Common.DeviceReady)
            {
                RegionMgr.LoadRegion(regionID);

                if (point.X <= hScrollBar.Maximum && point.X >= hScrollBar.Minimum)
                {
                    hScrollBar.Value = (int)point.X;
                }
                if (point.Y <= vScrollBar.Maximum && point.Y >= vScrollBar.Minimum)
                {
                    vScrollBar.Value = (int)point.Y;
                }
                SetZoom(0.25F);
            }
            else
            {
                cachedRegionID = regionID;
                cachedLocation = point;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
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
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            this.ZoomSlider = new System.Windows.Forms.TrackBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.comboBoxMaps = new System.Windows.Forms.ToolStripComboBox();
            this.labelCoords = new System.Windows.Forms.ToolStripLabel();
            this.labelObject = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRegion = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mobnameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.copyLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectToolTip = new System.Windows.Forms.ToolTip(this.components);
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // ZoomSlider
            // 
            this.ZoomSlider.BackColor = System.Drawing.SystemColors.Control;
            this.ZoomSlider.Dock = System.Windows.Forms.DockStyle.Right;
            this.ZoomSlider.Enabled = false;
            this.ZoomSlider.LargeChange = 250;
            this.ZoomSlider.Location = new System.Drawing.Point(474, 0);
            this.ZoomSlider.Maximum = 1000;
            this.ZoomSlider.Minimum = 50;
            this.ZoomSlider.Name = "ZoomSlider";
            this.ZoomSlider.Size = new System.Drawing.Size(150, 25);
            this.ZoomSlider.SmallChange = 100;
            this.ZoomSlider.TabIndex = 0;
            this.ZoomSlider.TabStop = false;
            this.ZoomSlider.TickFrequency = 250;
            this.ZoomSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ZoomSlider.Value = 100;
            this.ZoomSlider.Scroll += new System.EventHandler(this.Zoom_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar.Enabled = false;
            this.hScrollBar.LargeChange = 0;
            this.hScrollBar.Location = new System.Drawing.Point(0, 471);
            this.hScrollBar.Maximum = 0;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(624, 17);
            this.hScrollBar.SmallChange = 0;
            this.hScrollBar.TabIndex = 0;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar.Enabled = false;
            this.vScrollBar.LargeChange = 0;
            this.vScrollBar.Location = new System.Drawing.Point(607, 25);
            this.vScrollBar.Maximum = 0;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 446);
            this.vScrollBar.SmallChange = 0;
            this.vScrollBar.TabIndex = 0;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxMaps,
            this.labelCoords,
            this.labelObject,
            this.toolStripLabelRegion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 150, 0);
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.Stretch = true;
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip";
            // 
            // comboBoxMaps
            // 
            this.comboBoxMaps.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaps.DropDownWidth = 200;
            this.comboBoxMaps.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboBoxMaps.MaxDropDownItems = 30;
            this.comboBoxMaps.Name = "comboBoxMaps";
            this.comboBoxMaps.Size = new System.Drawing.Size(150, 25);
            this.comboBoxMaps.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaps_SelectionChangeCommitted);
            // 
            // labelCoords
            // 
            this.labelCoords.AutoSize = false;
            this.labelCoords.Name = "labelCoords";
            this.labelCoords.Size = new System.Drawing.Size(150, 22);
            // 
            // labelObject
            // 
            this.labelObject.Name = "labelObject";
            this.labelObject.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripLabelRegion
            // 
            this.toolStripLabelRegion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelRegion.Name = "toolStripLabelRegion";
            this.toolStripLabelRegion.Size = new System.Drawing.Size(40, 22);
            this.toolStripLabelRegion.Text = "Region";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobnameToolStripMenuItem,
            this.toolStripSeparator3,
            this.copyLocationToolStripMenuItem,
            this.filterMenuItem,
            this.zoomToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(154, 98);
            // 
            // mobnameToolStripMenuItem
            // 
            this.mobnameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.mobnameToolStripMenuItem.Name = "mobnameToolStripMenuItem";
            this.mobnameToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mobnameToolStripMenuItem.Text = "Mobname";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.add;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importObjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // copyLocationToolStripMenuItem
            // 
            this.copyLocationToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.copy;
            this.copyLocationToolStripMenuItem.Name = "copyLocationToolStripMenuItem";
            this.copyLocationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.copyLocationToolStripMenuItem.Text = "Copy Location";
            this.copyLocationToolStripMenuItem.Click += new System.EventHandler(this.copyLocationToolStripMenuItem_Click);
            // 
            // filterMenuItem
            // 
            this.filterMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.searchNPC;
            this.filterMenuItem.Name = "filterMenuItem";
            this.filterMenuItem.Size = new System.Drawing.Size(153, 22);
            this.filterMenuItem.Text = "Filter";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            toolStripSeparator1,
            this.resetZoomToolStripMenuItem});
            this.zoomToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.search;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ZoomSlider);
            this.panel1.Controls.Add(this.toolStrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 25);
            this.panel1.TabIndex = 6;
            // 
            // DXControl
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "DXControl";
            this.Size = new System.Drawing.Size(624, 488);
            this.Load += new System.EventHandler(this.DXControl_Load);
            this.MouseLeave += new System.EventHandler(this.DXControl_MouseLeave);
            this.Click += new System.EventHandler(this.DXControl_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseDown);
            this.Resize += new System.EventHandler(this.DXControl_Resize);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseUp);
            this.MouseEnter += new System.EventHandler(this.DXControl_MouseEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DXControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ZoomSlider)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private void DXRender()
        {
            Common.Device.Clear(ClearFlags.Target, Color.Black, 0.0f, 0);
            DXSetCamera();
            Common.Device.BeginScene();

            DXRenderObjects();

            Common.Device.EndScene();
            Common.Device.Present();
        }

        private void DXRenderObjects()
        {
            if (!DB.isInitialized())
                return;

            if (GeoObjects.Count == 0)
                return;
                                   
            DetailLevel lvl = GetDetailLevel();
            int objs = 0;
                                   
            double zoomValue = Math.Pow(ZoomSlider.Value, 1.20)/(ZoomSlider.Maximum - ZoomSlider.Minimum)/26*(256*256/16);
            
            int x = (int) (ClientRectangle.Width*zoomValue);
            int y = (int) (ClientRectangle.Height*zoomValue);

            float cameraX = (float) hScrollBar.Value;
            float cameraY = (float) vScrollBar.Value;

            int plusX = (int) cameraX + x;
            int minusX = (int) cameraX - x;
            int plusY = (int) cameraY + y;
            int minusY = (int) cameraY - y;            

            // use a copy of geoobjects list so that list can be manipulated during lazy loading of mapelements
            GeometryObj[] objects = GeoObjects.ToArray();
            Array.Sort(objects);

            lock (objects.SyncRoot)
            {                                    
                foreach (GeometryObj obj in objects)
                {
                    if (obj.DrawLevel == DrawLevel.NonRender)
                        continue;
                    if (!InDetailLevel(obj.DetailLevel, lvl))
                        continue;
                    
                    
                    if ((DrawLevel)obj.DrawLevel != DrawLevel.Background)
                    {
                        if (!((obj.X >= minusX && obj.X <= plusX) && (obj.Y >= minusY && obj.Y <= plusY)))
                            continue;
                    }
                    obj.Render();

                    //Objects increasen..
                    objs++;
                    
                }
                StatusChangeObjects(objs);
            }
            
        }

        public void StatusChangeDXCoords(int x, int y)
        {
            labelCoords.Text = string.Format("X: {0} - Y: {1}", x, y);
        }

        public void StatusChangeObjects(int objs)
        {
            labelObject.Text = string.Format("Objects: {0}", objs);
        }

        private void DXSetCamera()
        {            
            float cameraX = (float) hScrollBar.Value;
            float cameraY = -((float) vScrollBar.Value);
            float cameraZ = -((float) (ZoomSlider.Value*ZoomSlider.Value));

            //Based on Scrollbares,...
            View = Matrix.LookAtLH(
                new Vector3(cameraX, cameraY, cameraZ),
                new Vector3(cameraX, cameraY, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f));

            //Std            
            Proj = Matrix.PerspectiveFovLH(
                (float) Math.PI/4.0f*(float) ClientRectangle.Height/500.0f,
                (float) ClientRectangle.Width/(float) ClientRectangle.Height,
                0.01f,
                1000000.0f);

            Common.Device.Transform.View = View;
            Common.Device.Transform.Projection = Proj;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();           
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void comboBoxMaps_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            char[] seps = { '[', ']' };
            string item = (string)comboBoxMaps.Items[comboBoxMaps.SelectedIndex];
            string[] split = item.Split(seps, 3); //befor, between, after ;)

            if (item == "")
                return;

            if (split.Length < 2)
                return;

            string region = split[1];


            int id = int.Parse(region);
            RegionMgr.Region reg = RegionMgr.GetRegion(id);

            if (reg != null)
                RegionMgr.LoadRegion(reg);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DXRender();
        }        

        private void Zoom_Scroll(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void DXControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.ZoomSlider.Focus();
            this.ZoomSlider.Select();

            Vector3 v3 = DXClickToVector(new Vector2(e.X, e.Y));
            SelectedObject = ModulMgr.GetObjectAt((int)v3.X, (int)v3.Y);            

            if (e.Button == MouseButtons.Left)
            {
                if (SelectedObject != null && SelectedObject.IsMovable)
                {
                    MapMoving = false;
                    ObjectMoving = true;
                }
                else
                {
                    this.Cursor = Cursors.Hand;
                    MouseMoveStart = new Point(e.X, e.Y);
                    MouseValueH = hScrollBar.Value;
                    MouseValueV = vScrollBar.Value;
                    MapMoving = true;
                    ObjectMoving = false;
                }
            }
            else
            {
                MapMoving = false;
                ObjectMoving = false;
            }
        }

        private void DXControl_MouseMove(object sender, MouseEventArgs e)
        {
            Vector3 coords = DXClickToVector(new Vector2(e.X, e.Y));

            if (MapMoving)
            {
                float diffX = (MouseMoveStart.X - e.X)*(float) Math.Pow(ZoomSlider.Value, 2)/580;
                float diffY = (MouseMoveStart.Y - e.Y)*(float) Math.Pow(ZoomSlider.Value, 2)/580;

                int tX = (MouseValueH + (int) diffX);
                int tY = (MouseValueV + (int) diffY);

                if (tX <= hScrollBar.Maximum && tX >= hScrollBar.Minimum)
                {
                    hScrollBar.Value = tX;
                }
                if (tY <= vScrollBar.Maximum && tY >= vScrollBar.Minimum)
                {
                    vScrollBar.Value = tY;
                }
                Invalidate();
            }
            else if (ObjectMoving && SelectedObject != null && SelectedObject.IsMovable)
            {                                            
                SelectedObject.X = (int) coords.X;
                SelectedObject.Y = (int) coords.Y;                
                SelectedObject.Modul.ObjectMoved(SelectedObject);
            }            
            StatusChangeDXCoords((int) coords.X, (int) coords.Y);
        }

        private void DXControl_MouseLeave(object sender, EventArgs e)
        {
            if (MapMoving)
            {
                MapMoving = false;
                this.Cursor = Cursors.Default;
            }

            ObjectMoving = false;
        }

        private void DXControl_MouseUp(object sender, MouseEventArgs e)
        {
            int diffX = Math.Abs(MouseMoveStart.X - e.X);
            int diffY = Math.Abs(MouseMoveStart.Y - e.Y);

            if ((diffX <= 3 && diffY <= 3) || (MouseMoveStart.X == -1 && MouseMoveStart.Y == -1))
                ModulMgr.TriggerModules(ModulEvent.DXClick, e);
            LastMouseVector = DXClickToVector(new Vector2(e.X, e.Y));

            if (e.Button == MouseButtons.Right)
            {                
                contextMenuStrip.Show(this, e.Location);                
            } else if (e.Button == MouseButtons.Left)
            {
                MapMoving = false;
                ObjectMoving = false;
                MouseMoveStart.X = -1;
                MouseMoveStart.Y = -1;
                SelectedObject = null;
                this.Cursor = Cursors.Default;
            }
        }

        private void DXControl_MouseWheel(object sender, MouseEventArgs e)
        {
            Zoom(e.Delta);            
        }

        /// <summary>
        /// Set zoomfactor to value between 0.0 and 1.0 
        /// </summary>
        /// <param name="percent"></param>
        public void SetZoom(float percent)
        {
            ZoomSlider.Value = (int)((ZoomSlider.Maximum - ZoomSlider.Minimum) * percent) + ZoomSlider.Minimum;
            Invalidate();          
        }

        /// <summary>
        /// Get zoomfactor to value between 0.0 and 1.0 
        /// </summary>
        /// <param name="percent"></param>
        public float GetZoom()
        {
            return (float)Math.Round(((float)(ZoomSlider.Value - ZoomSlider.Minimum)) / (ZoomSlider.Maximum - ZoomSlider.Minimum),2);
            
        }

        public void CenterView()
        {
            vScrollBar.Value = (vScrollBar.Maximum + vScrollBar.Minimum) / 2;
            hScrollBar.Value = (hScrollBar.Maximum + hScrollBar.Minimum) / 2;
        }

        private void Zoom(int value)
        {
            if (ZoomSlider.Enabled)
            {
                //int moved = e.Delta; //Add some multiplactors?
                double zoomPow = Settings.Default.ZoomValuePow;                

                double factor = Math.Pow(ZoomSlider.Value, zoomPow) / Math.Pow(ZoomSlider.Maximum, zoomPow) ;
                int moved = (int)(factor * -value);
                int newvalue = ZoomSlider.Value + moved;

                if (newvalue > ZoomSlider.Maximum)
                    newvalue = ZoomSlider.Maximum;

                if (newvalue < ZoomSlider.Minimum)
                    newvalue = ZoomSlider.Minimum;

                if (ZoomSlider.Value != newvalue)
                {
                    ZoomSlider.Value = newvalue;
                    Invalidate();
                }
            }
        }

        private void DXControl_Resize(object sender, EventArgs e)
        {            
            //Invalidate();
        }

        public Vector3 DXClickToVector(Vector2 click)
        {
            if (HBObject == null)
                return new Vector3(0, 0, 0);

            if (HBObject.Model.Mesh == null)
                return new Vector3(0, 0, 0);

            Matrix World = HBObject.CreateWorldMatrix();

            Vector3 rayStart, rayDirection;

            // Convert the mouse point into a 3D point            
            Vector3 v = new Vector3(
                (((2.0f*click.X)/this.ClientRectangle.Width) - 1)/Proj.M11,
                -(((2.0f*click.Y)/this.ClientRectangle.Height) - 1)/Proj.M22,
                1.0f);

            // Get the inverse of the composite view and world matrix
            Matrix m = View*World;
            m.Invert();

            // Transform the screen space pick ray into 3D space
            rayDirection.X = v.X*m.M11 + v.Y*m.M21 + v.Z*m.M31;
            rayDirection.Y = v.X*m.M12 + v.Y*m.M22 + v.Z*m.M32;
            rayDirection.Z = v.X*m.M13 + v.Y*m.M23 + v.Z*m.M33;

            rayStart.X = m.M41;
            rayStart.Y = m.M42;
            rayStart.Z = m.M43;

            Mesh msh = ((XMesh) HBObject.Model.Mesh).Mesh;

            IntersectInformation info = new IntersectInformation();

            if (!msh.Intersect(rayStart, rayDirection, out info))
                return new Vector3(0.0f, 0.0f, 0.0f);

            Vector3 hitPos = rayStart + info.Dist*rayDirection;

            return new Vector3(HBObject.X + hitPos.X, HBObject.Y - hitPos.Y, hitPos.Z);
        }        

        public void AddFilter(string name)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(name, null, new EventHandler(filterMenuItem_Click));
            item.CheckOnClick = true;
            item.Checked = true;

            if (name == DatabaseMobModule.MODULE_NAME || name == DatabaseWorldObjectModule.MODULE_NAME)
            {
                item.Enabled = QuestDesignerMain.DatabaseSupported;
            }

            filterMenuItem.DropDownItems.Add(item);
        }

        void filterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            IModul mod = ModulMgr.GetModulByName(item.Text);

            if (mod == null)
                throw new ArgumentException("No Module with name:"+item.Text+" found.");

            if (item.Checked)                
                ModulMgr.TriggerModule(mod, ModulEvent.Unfilter);
            else
                ModulMgr.TriggerModule(mod, ModulEvent.Filter);
                
        }
        
        private DetailLevel GetDetailLevel()
        {
            float zoom = GetZoom();

            if (zoom <= 0.1)
                return DetailLevel.MostDetailed;
            else if (zoom <= 0.2)
                return DetailLevel.MoreDetailed;
            else if (zoom <= 0.3)
                return DetailLevel.Detailed;
            else if (zoom <= 0.5)
                return DetailLevel.Middle;
            else if (zoom <= 0.7)
                return DetailLevel.Undetailed;
            else
                return DetailLevel.Nondetailed;
        }

        private bool InDetailLevel(DetailLevel level, DetailLevel inlevel)
        {
            if ((byte) inlevel >= (byte) level)
                return true;
            else
                return false;
        }

        private void DXControl_MouseEnter(object sender, EventArgs e)
        {
        }

        private void DXControl_Click(object sender, EventArgs e)
        {
        }

        private void DXControl_Load(object sender, EventArgs e)
        {            
            RegionMgr.LoadRegions();
            ModulMgr.LoadModules();

            ZoomSlider.KeyDown+=new KeyEventHandler(DXControl_KeyDown);

            if (cachedRegionID >= 0)
            {
                RegionMgr.LoadRegion(cachedRegionID);
                if (cachedLocation.X <= hScrollBar.Maximum && cachedLocation.X >= hScrollBar.Minimum)
                {
                    //hScrollBar.Value += diffX;
                    hScrollBar.Value = (int)cachedLocation.X;
                }
                if (cachedLocation.Y <= vScrollBar.Maximum && cachedLocation.Y >= vScrollBar.Minimum)
                {
                    //vScrollBar.Value += diffY;
                    vScrollBar.Value = (int)cachedLocation.Y;
                }

                Invalidate();

            }   
        }

        private void copyLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            IDataObject ido = new System.Windows.Forms.DataObject();            
            ClipboardLocation loc = new ClipboardLocation(Convert.ToInt32(LastMouseVector.X),Convert.ToInt32(LastMouseVector.Y), RegionMgr.CurrentRegion.ID);
            ido.SetData(loc);
            Clipboard.SetDataObject(ido, true);
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(ZoomSlider.SmallChange);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zoom(-ZoomSlider.SmallChange);
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetZoom(0.75F);        
        }               

        private void DXControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
                hScrollBar.Value -= hScrollBar.LargeChange;
            else if (e.KeyData == Keys.Right)
                hScrollBar.Value += hScrollBar.LargeChange;
            else if (e.KeyData == Keys.Up)
                vScrollBar.Value -= vScrollBar.LargeChange;
            else if (e.KeyData == Keys.Down)
                vScrollBar.Value += vScrollBar.LargeChange;
            else if (e.KeyData == Keys.Add)
                Zoom(ZoomSlider.SmallChange);
            else if (e.KeyData == Keys.Subtract)
                Zoom(-ZoomSlider.SmallChange);
            else
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            Invalidate();
        }

        private void importObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
                if (SelectedObject.Modul is DatabaseMobModule) {
                    Mob mob = ((DatabaseMobModule) SelectedObject.Modul).GetDataObjectForGeometryObject(SelectedObject);
                    QuestDesignerMain.DesignerForm.npcView.FillDataRowFromObject(mob);
                }
            }
        }
        
    }
}