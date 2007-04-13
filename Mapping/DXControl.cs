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
using DOL.Tools.Mapping.Resource;
using DOL.Tools.QuestDesigner.Util;
using DOL.Tools.QuestDesigner;
using DOL.Tools.Mapping.Modules;

namespace DOL.Tools.Mapping.Forms
{
    /// <summary>
    /// Summary description for DXControl.
    /// </summary>
    public class DXControl : UserControl
    {
       
        public TrackBar Zoom;
        public HScrollBar hScrollBar;
        public VScrollBar vScrollBar;        
        private bool MapMoving = false;
        private IMapObject ObjectMove;
        private Point MouseMoveStart = new Point(-1, -1);
        private Vector3 LastMouseVector = new Vector3();
        private int MouseValueH = 0;
        private int MouseValueV = 0;
        private Matrix View = Matrix.Zero;
        private Matrix Proj = Matrix.Zero;
        public bool DeviceReady = false;
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

        public DXControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            //Mouse?
            MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            Zoom.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            hScrollBar.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);
            vScrollBar.MouseWheel += new MouseEventHandler(DXControl_MouseWheel);

            // Styles
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, false);

            // TODO: Add any initialization after the InitializeComponent call
            
        }

        public void ShowLocation(Vector3 point, int regionID)
        {
            if (DeviceReady)
            {

                RegionMgr.LoadRegion(regionID);

                if (point.X <= hScrollBar.Maximum && point.X >= hScrollBar.Minimum)
                {
                    //hScrollBar.Value += diffX;
                    hScrollBar.Value = (int)point.X;
                }
                if (point.Y <= vScrollBar.Maximum && point.Y >= vScrollBar.Minimum)
                {
                    //vScrollBar.Value += diffY;
                    vScrollBar.Value = (int)point.Y;
                }

                Zoom.Value = Zoom.Minimum + (Zoom.LargeChange);

                Invalidate();
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
            this.Zoom = new System.Windows.Forms.TrackBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.comboBoxMaps = new System.Windows.Forms.ToolStripComboBox();
            this.labelCoords = new System.Windows.Forms.ToolStripLabel();
            this.labelObject = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelRegion = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Zoom
            // 
            this.Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Zoom.BackColor = System.Drawing.SystemColors.Desktop;
            this.Zoom.Enabled = false;
            this.Zoom.LargeChange = 100;
            this.Zoom.Location = new System.Drawing.Point(184, 444);
            this.Zoom.Maximum = 3000;
            this.Zoom.Minimum = 15;
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(424, 45);
            this.Zoom.SmallChange = 100;
            this.Zoom.TabIndex = 0;
            this.Zoom.TabStop = false;
            this.Zoom.TickFrequency = 500;
            this.Zoom.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Zoom.Value = 100;
            this.Zoom.Scroll += new System.EventHandler(this.Zoom_Scroll);
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
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxMaps,
            this.labelCoords,
            this.labelObject,
            this.toolStripLabelRegion});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(624, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip";
            // 
            // comboBoxMaps
            // 
            this.comboBoxMaps.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.comboBoxMaps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaps.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.comboBoxMaps.MaxDropDownItems = 30;
            this.comboBoxMaps.Name = "comboBoxMaps";
            this.comboBoxMaps.Size = new System.Drawing.Size(250, 25);
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
            this.copyLocationToolStripMenuItem,
            this.filterMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(154, 70);
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
            this.filterMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.search;
            this.filterMenuItem.Name = "filterMenuItem";
            this.filterMenuItem.Size = new System.Drawing.Size(153, 22);
            this.filterMenuItem.Text = "Filter";
            // 
            // DXControl
            // 
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.toolStrip);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "DXControl";
            this.Size = new System.Drawing.Size(624, 488);
            this.Load += new System.EventHandler(this.DXControl_Load);
            this.Click += new System.EventHandler(this.DXControl_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseMove);
            this.Resize += new System.EventHandler(this.DXControl_Resize);
            this.MouseEnter += new System.EventHandler(this.DXControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.DXControl_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DXControl_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.Zoom)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
            
            GeometryObj[] array = (GeometryObj[]) Objects.ToArray();

            lock (array)
            {
                DetailLevel lvl = GetDetailLevel();
                int objs = 0;

                //float zoomval = Zoom.Value / (Zoom.Maximum - Zoom.Minimum) + 1;
                double ViewFac = DOL.Tools.QuestDesigner.Properties.Settings.Default.ViewFactor;                                
                double zoomval = Math.Pow(Zoom.Value, 1.20)/(Zoom.Maximum - Zoom.Minimum)/26*(256*256/16)*ViewFac;

                int x = (int) (ClientRectangle.Width*zoomval);
                int y = (int) (ClientRectangle.Height*zoomval);

                float cameraX = (float) hScrollBar.Value;
                float cameraY = (float) vScrollBar.Value;

                int plusX = (int) cameraX + x;
                int minusX = (int) cameraX - x;
                int plusY = (int) cameraY + y;
                int minusY = (int) cameraY - y;

                for (byte a = (byte) DrawLevel._START; a <= (byte) DrawLevel._LAST; a++)
                {
                    foreach (GeometryObj obj in array)
                    {
                        if (!InDetailLevel(obj.DetailLevel, lvl))
                            continue;

                        if (obj.DrawLevel == (DrawLevel) a)
                        {
                            if ((DrawLevel) a != DrawLevel.Background)
                            {
                                if (!((obj.X >= minusX && obj.X <= plusX) && (obj.Y >= minusY && obj.Y <= plusY)))
                                    continue;
                            }
                            //World Matrix..
                            //Common.Device.Transform.World = Matrix.RotationYawPitchRoll(obj.Yaw, obj.Pitch, obj.Roll)*Matrix.Translation(obj.X, -obj.Y, obj.Z);
                            Common.Device.Transform.World = Objects.CreateWorldMatrix(obj);

                            //Texture
                            Common.Device.SetTexture(0, obj.Model.Texture);

                            //Set Blend Texture
                            if (obj.Model.BlendTexture != null)
                            {
                                Common.Device.SetTexture(1, obj.Model.BlendTexture);
                                Common.Device.TextureState[1].ColorOperation = TextureOperation.Modulate;
                                Common.Device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
                                Common.Device.TextureState[1].ColorArgument2 = TextureArgument.Current;
                                Common.Device.TextureState[2].ColorOperation = TextureOperation.Disable;
                            }
                            else
                                Common.Device.TextureState[1].ColorOperation = TextureOperation.Disable;

                            //Rendern..
                            obj.Model.Mesh.Render();

                            //Objects increasen..
                            objs++;
                        }
                    }
                }
                StatusChangeObjects(objs);
            }
        }

        public void StatusChangeCoords(int x, int y)
        {
            //statusBarPanelCoords.Text = string.Format("X: {0} - Y: {1}", x, y);
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
            float cameraX = 0.0f;
            float cameraY = 0.0f;
            float cameraZ = 0.0f;

            cameraX = (float) hScrollBar.Value;
            cameraY = -((float) vScrollBar.Value);
            cameraZ = -((float) (Zoom.Value*Zoom.Value));

            //Based on Scrollbares,...
            View = Matrix.LookAtLH(
                new Vector3(cameraX, cameraY, cameraZ),
                new Vector3(cameraX, cameraY, 0.0f),
                new Vector3(0.0f, 1.0f, 0.0f));

            //Std
            //ToDo: Check this! / 500?
            Proj = Matrix.PerspectiveFovLH(
                (float) Math.PI/4.0f*(float) ClientRectangle.Height/500.0f,
                (float) ClientRectangle.Width/(float) ClientRectangle.Height,
                0.01f,
                3000000.0f);

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
            if (e.Button == MouseButtons.Left)
            {
                                
                Vector3 v3 = DXClickToVector(new Vector2(e.X, e.Y));
                IMapObject mapObject = ModulMgr.GetObjectAt((int) v3.X, (int) v3.Y);
                if (mapObject != null && mapObject.IsMovable)
                {
                    ObjectMove = mapObject;
                    return;
                }
                
                MouseMoveStart = new Point(e.X, e.Y);
                MouseValueH = hScrollBar.Value;
                MouseValueV = vScrollBar.Value;
                MapMoving = true;
            }
        }

        private void DXControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (MapMoving)
            {
                float diffX = (MouseMoveStart.X - e.X)*(float) Math.Pow(Zoom.Value, 2)/580;
                float diffY = (MouseMoveStart.Y - e.Y)*(float) Math.Pow(Zoom.Value, 2)/580;

                int tX = (MouseValueH + (int) diffX);
                int tY = (MouseValueV + (int) diffY);

                if (tX <= hScrollBar.Maximum && tX >= hScrollBar.Minimum)
                {
                    //hScrollBar.Value += diffX;
                    hScrollBar.Value = tX;
                }
                if (tY <= vScrollBar.Maximum && tY >= vScrollBar.Minimum)
                {
                    //vScrollBar.Value += diffY;
                    vScrollBar.Value = tY;
                }

                Invalidate();
            }
            else if (ObjectMove != null)
            {
                Vector3 v3 = DXClickToVector(new Vector2(e.X, e.Y));
                ObjectMove.X = (int) v3.X;
                ObjectMove.Y = (int) v3.Y;
                ObjectMove.Modul.ObjectMoved(ObjectMove);
            }
            StatusChangeCoords(e.X, e.Y);
            Vector3 coords = DXClickToVector(new Vector2(e.X, e.Y));
            StatusChangeDXCoords((int) coords.X, (int) coords.Y);
        }

        private void DXControl_MouseLeave(object sender, EventArgs e)
        {
            if (MapMoving)
                MapMoving = false;
        }

        private void DXControl_MouseUp(object sender, MouseEventArgs e)
        {
            int diffX = Math.Abs(MouseMoveStart.X - e.X);
            int diffY = Math.Abs(MouseMoveStart.Y - e.Y);

            if ((diffX <= 3 && diffY <= 3) || (MouseMoveStart.X == -1 && MouseMoveStart.Y == -1))
                ModulMgr.TriggerModule(ModulMgr.ModulEvent.DXClick, e);
            LastMouseVector = DXClickToVector(new Vector2(e.X, e.Y));

            if (e.Button == MouseButtons.Right)
            {
                Vector3 vec = DXClickToVector(new Vector2(e.X, e.Y));
                //MessageBox.Show("Click at X: " + vec.X + " Y: " + vec.Y + " Z: " + vec.Z);
                //Just do nothing :P
                //Point m = System.Windows.Forms.Cursor.Position;                
                Point m = this.PointToScreen(e.Location);
                m.Y -= 24;
                m.X -= 8;
                contextMenuStrip.Show(this, e.Location );
            }

            if (e.Button == MouseButtons.Left)
            {
                MapMoving = false;
                MouseMoveStart.X = -1;
                MouseMoveStart.Y = -1;
                ObjectMove = null;
            }
        }

        private void DXControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Zoom.Enabled)
            {
                //int moved = e.Delta; //Add some multiplactors?
                double zoomPow = DOL.Tools.QuestDesigner.Properties.Settings.Default.ZoomValuePow;
                double zoomMul = DOL.Tools.QuestDesigner.Properties.Settings.Default.ZoomValueMul;
                    
                double factor = Math.Pow(Zoom.Value, zoomPow)/Math.Pow(Zoom.Maximum, zoomPow)*zoomMul;
                int moved = (int) (factor*-e.Delta);
                int newvalue = Zoom.Value + moved;

                if (newvalue <= Zoom.Maximum && newvalue >= Zoom.Minimum)
                {
                    Zoom.Value += moved;
                    Invalidate();
                }
            }
        }

        private void DXControl_Resize(object sender, EventArgs e)
        {
            //LastResize = System.DateTime.Now.Ticks;
            //Invalidate();
        }

        public Vector3 DXClickToVector(Vector2 click)
        {
            if (HBObject == null)
                return new Vector3(0, 0, 0);

            if (HBObject.Model.Mesh == null)
                return new Vector3(0, 0, 0);

            Matrix World = Objects.CreateWorldMatrix(HBObject);

            Vector3 rayStart, rayDirection;

            // Convert the mouse point into a 3D point
            Vector3 v = new Vector3(
                (((2.0f*click.X)/Common.Device.PresentationParameters.BackBufferWidth) - 1)/Proj.M11,
                -(((2.0f*click.Y)/Common.Device.PresentationParameters.BackBufferHeight) - 1)/Proj.M22,
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
            filterMenuItem.DropDownItems.Add(item);
            
        }

        void filterMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            ModulMgr.ModulObj mod = ModulMgr.GetModulByName(item.Text);

            if (mod == null)
                throw new ArgumentException("No Module with name:"+item.Text+" found.");

            if (item.Checked)
                mod.Modul.Unfilter(mod);
            else
                mod.Modul.Filter(mod);            
        }

        

        private DetailLevel GetDetailLevel()
        {
            int zoom = (int) (((float) Zoom.Value/(float) (Zoom.Maximum - Zoom.Minimum))*100.0f);

            if (zoom <= 4)
                return DetailLevel.MostDetailed;
            if (zoom <= 8)
                return DetailLevel.MoreDetailed;
            if (zoom <= 14)
                return DetailLevel.Detailed;
            if (zoom <= 26)
                return DetailLevel.Middle;
            if (zoom <= 43)
                return DetailLevel.Undetailed;

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
            Log.Info("Copied " + LastMouseVector.X + ";" + LastMouseVector.Y + " to clipboard");

            IDataObject ido = new DataObject();            

            ClipboardLocation loc = new ClipboardLocation(Convert.ToInt32(LastMouseVector.X),Convert.ToInt32(LastMouseVector.Y), RegionMgr.CurrentRegion.ID);

            ido.SetData(loc);
            Clipboard.SetDataObject(ido, true);
        }
    }
}