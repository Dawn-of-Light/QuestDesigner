using System;
using System.Collections;
using System.Drawing;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DOL.Tools.Mapping.DX;
using DOL.Tools.Mapping.DX.Meshes;
using Plane=DOL.Tools.Mapping.DX.Meshes.Plane;
using DOL.Tools.QuestDesigner.Util;
using System.Data;
using DOL.Tools.QuestDesigner;
using System.ComponentModel;
using DOL.Tools.Mapping.Modules;

namespace DOL.Tools.Mapping.Map
{
    public class RegionMgr
    {
        private static ArrayList m_Regions;
        private static Region m_OpenedRegion;

        private static BackgroundWorker backgroundWorker;
        
        public static Region CurrentRegion
        {
            get { return m_OpenedRegion; }
            set { m_OpenedRegion = value; }
        }

        public class Region
        {
            private string m_Name;
            private int m_MinWidth;
            private int m_MinHeight;
            private int m_MaxWidth;
            private int m_MaxHeight;
            private int m_ID;
            private ArrayList m_Zones;

            public string Name
            {
                get { return m_Name; }
                set { m_Name = value; }
            }

            public int MinWidth
            {
                get { return m_MinWidth; }
                set { m_MinWidth = value; }
            }

            public int MinHeight
            {
                get { return m_MinHeight; }
                set { m_MinHeight = value; }
            }

            public int MaxWidth
            {
                get { return m_MaxWidth; }
                set { m_MaxWidth = value; }
            }

            public int MaxHeight
            {
                get { return m_MaxHeight; }
                set { m_MaxHeight = value; }
            }

            public int ID
            {
                get { return m_ID; }
                set { m_ID = value; }
            }

            public ArrayList Zones
            {
                get
                {
                    if (m_Zones == null)
                        m_Zones = new ArrayList();

                    return m_Zones;
                }
            }

            public Region(string name, int id)
            {
                Name = name;
                ID = id;
            }
        }

        public class Zone
        {
            private int m_X;
            private int m_Y;
            private int m_Width;
            private int m_Height;
            private string m_Texture;
            private int m_Region;
            private string m_Description;

            public int Region
            {
                get { return m_Region; }
                set { m_Region = value; }
            }

            public string Description
            {
                get { return m_Description; }
                set { m_Description = value; }
            }

            public int X
            {
                get { return m_X; }
                set { m_X = value; }
            }

            public int Y
            {
                get { return m_Y; }
                set { m_Y = value; }
            }

            public int Width
            {
                get { return m_Width; }
                set { m_Width = value; }
            }

            public int Height
            {
                get { return m_Height; }
                set { m_Height = value; }
            }

            public string Texture
            {
                get { return m_Texture; }
                set { m_Texture = value; }
            }

            public Zone(int region, int x, int y, int width, int height, string file,string descr)
            {
                Region = region;
                X = x;
                Y = y;
                Width = width;
                Height = height;
                Texture = file;
                Description = descr;
            }
        }

        public static bool LoadRegions()
        {                        
            // allready loaded nothing else to do.
            if (m_Regions == null)
                PreloadRegions();
                        
            lock (m_Regions.SyncRoot)
            {                
                QuestDesignerMain.DesignerForm.DXControl.comboBoxMaps.Items.Clear();

                // Lets calc our region borders!
                foreach (Region region in m_Regions)
                {                    
                    if (region.Zones.Count > 0)
                    {
                        //Add them to our list!
                        string reg = string.Format("[{0}] {1} ({2})", region.ID, region.Name, region.Zones.Count);
                        QuestDesignerMain.DesignerForm.DXControl.comboBoxMaps.Items.Add(reg);
                    }
                }
            }
            return true;
        }

        public static bool PreloadRegions()
        {
            // allready loaded nothing else to do.
            if (m_Regions != null)
                return true;

            m_Regions = new ArrayList();

            lock (m_Regions.SyncRoot)
            {
                Log.Info("Loading Regions..");

                if (!QuestDesignerMain.WaitForDatabase())
                    return false;

                //Look for regions...
                foreach (DataRow regionRow in DB.RegionTable.Rows)
                {
                    int id = (int)regionRow["id"];
                    string name = (string)regionRow["description"];

                    Region region = new Region(name, id);
                    m_Regions.Add(region);
                }

                Log.Info("Loading Zones..");

                foreach (DataRow zoneRow in DB.ZoneTable.Rows)
                {
                    //1=1;8;8;67;67
                    //id=region;widht;height;xoff;yoff

                    int id = (int)zoneRow["zoneID"]; // int.Parse((string) entry.Key);
                    //string[] paras = ((string) entry.Value).Split(';');
                    int region = (int)zoneRow["regionID"]; // int.Parse(paras[0]);
                    int width = ((int)zoneRow["width"]) * 8192; //8192 = 256*256/8 - a zone is parted into 8 subzones
                    int height = ((int)zoneRow["height"]) * 8192; //see above
                    int x = ((int)zoneRow["offsetx"]) * 8192;
                    int y = ((int)zoneRow["offsety"]) * 8192;
                    string descr = Convert.ToString(zoneRow["description"]);
                    string img = "data\\maps\\" + id + ".jpg";

                    /*if (File.Exists(img))
                    {
                        Zone zone = new Zone(region,x,y,width,height,img);
                        Region reg = GetRegion(region);

                        if (reg != null)
                            reg.Zones.Add(zone);
                    }*/

                    Zone zone = new Zone(region, x, y, width, height, img, descr);
                    Region reg = GetRegion(region);

                    if (reg != null)
                        reg.Zones.Add(zone);
                }

                // First, sort!
                m_Regions.Sort(new RegionSorter());
                
                // Lets calc our region borders!
                foreach (Region region in m_Regions)
                {
                    int minWidth = -1;
                    int minHeight = -1;
                    int maxWidth = -1;
                    int maxHeight = -1;

                    foreach (Zone zone in region.Zones)
                    {
                        if (minWidth == -1)
                            minWidth = zone.X;
                        if (minHeight == -1)
                            minHeight = zone.Y;
                        if (maxWidth == -1)
                            maxWidth = zone.X + zone.Width;
                        if (maxHeight == -1)
                            maxHeight = zone.Y + zone.Height;

                        int newMinW = zone.X;
                        int newMinH = zone.Y;

                        int newMaxW = zone.X + zone.Width;
                        int newMaxH = zone.Y + zone.Height;

                        if (newMinW < minWidth)
                            minWidth = newMinW;

                        if (newMinH < minHeight)
                            minHeight = newMinH;

                        if (newMaxW > maxWidth)
                            maxWidth = newMaxW;

                        if (newMaxH > maxHeight)
                            maxHeight = newMaxH;
                    }

                    region.MinWidth = minWidth;
                    region.MaxHeight = maxHeight;
                    region.MaxWidth = maxWidth;
                    region.MaxHeight = maxHeight;
                    
                }
            }
            
            Log.Info("Ready");
            return true;
        } 

        public static Region GetRegion(int id)
        {
            foreach (Region region in m_Regions)
            {
                if (region.ID == id)
                    return region;
            }
            return null;
        }

        public static bool LoadRegion(int regionID)
        {
            Region region = GetRegion(regionID);

            if (region != null)
                return LoadRegion(region);
            else
                return false;
        }        

        public static bool LoadRegion(Region region)
        {

            if (region == null)
                return false;

            if (m_OpenedRegion != null && region.ID == m_OpenedRegion.ID)
            {
                Log.Info("Region "+region.Name+" allready loaded.");
                return true;
            }

            UnloadRegion();                    

            Log.Info("Loading zones of region "+region.Name);

            //Create "hitbox"
            Mesh hb = Mesh.Box(Common.Device, 256*256*16, 256*256*16, 0.0f);
            XMesh ms = new XMesh(hb);
            
            Texture tx = Textures.Generator(Color.Cyan);
            Model mdl = new Model(ms, tx);
            GeometryObj bj =
                new GeometryObj(mdl, DrawLevel.NonRender, DetailLevel.Nondetailed, 256*256*16/2, 256*256*16/2, 0.0f,
                                0.0f, 0.0f, 0.0f, new Vector3(1.0f, 1.0f, 1.0f));
            Objects.Add(bj);
            QuestDesignerMain.DesignerForm.DXControl.HBObject = bj;
                        
            try
            {
                if (backgroundWorker!=null && backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();                    
                }
                
                m_OpenedRegion = region;

                backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_doWork);
                backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception e)
            {
                QuestDesignerMain.HandleException(e, "Region loading error: " + e.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.databaseError);
            }
            
            //Scrollbars..
            /*QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Minimum = region.MinHeight;
			QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Maximum = region.MaxHeight;
			QuestDesignerMain.DesignerForm.DXControl.hScrollBar.SmallChange = (region.MaxHeight - region.MinHeight)/10000;
			QuestDesignerMain.DesignerForm.DXControl.hScrollBar.LargeChange = (region.MaxHeight - region.MinHeight)/1000;
			QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Value = region.MinHeight;

			QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Minimum = region.MinWidth;
			QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Maximum = region.MaxWidth;
			QuestDesignerMain.DesignerForm.DXControl.vScrollBar.SmallChange = (region.MaxWidth - region.MinWidth)/10000;
			QuestDesignerMain.DesignerForm.DXControl.vScrollBar.LargeChange = (region.MaxWidth - region.MinWidth)/1000;
			QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Value = region.MinWidth;*/

            //QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Minimum = -(256*256*16);
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Maximum = 256*256*16;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.SmallChange = 256;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.LargeChange = 2560;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Value = 256*256*16/2; //0

            //QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Minimum = -(256*256*16);
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Maximum = 256*256*16;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.SmallChange = 256;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.LargeChange = 2560;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Value = 256*256*16/2; //0

            QuestDesignerMain.DesignerForm.DXControl.Zoom.Value = (QuestDesignerMain.DesignerForm.DXControl.Zoom.Maximum -
                                                         QuestDesignerMain.DesignerForm.DXControl.Zoom.Minimum)/3*2;

            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Enabled = true;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Enabled = true;
            QuestDesignerMain.DesignerForm.DXControl.Zoom.Enabled = true;

            ModulMgr.TriggerModule(ModulMgr.ModulEvent.RegionLoad, region);

            // render newly added objects from Modules
            Objects.Render();

            return true;
        }

        /// <summary>
        /// Initializes the database
        /// </summary>
        private static void backgroundWorker_doWork(object sender, DoWorkEventArgs e)
        {
            //Load zones
            BackgroundWorker worker = (BackgroundWorker) sender;

            QuestDesignerMain.DesignerForm.StatusProgress.Step = QuestDesignerMain.DesignerForm.StatusProgress.Maximum / m_OpenedRegion.Zones.Count;

            foreach (Zone zone in m_OpenedRegion.Zones)
            {
                //Create it!
                Log.Info("Loading Texture for "+zone.Description);
                Plane mesh = new Plane(Common.Device, zone.Width, zone.Height, false);
                
                Texture tex = Textures.LoadTexture(zone.Texture);
                
                if (e.Cancel || worker.CancellationPending)
                {
                    e.Cancel = true;
                    e.Result = false;
                    return;
                }

                //float scaleX = zone.Width / tex.GetLevelDescription(0).Width;
                //float scaleY = zone.Height / tex.GetLevelDescription(0).Height;

                Model model = new Model(mesh, tex);
                GeometryObj obj =
                    new GeometryObj(model, DrawLevel.Background, DetailLevel.Nondetailed, zone.X, zone.Y, 0.0f, 0.0f,
                                    0.0f, 0.0f, new Vector3(1.0f, 1.0f, 1.0f));
                Objects.Add(obj);

                QuestDesignerMain.DesignerForm.StatusProgress.PerformStep();
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            }

            e.Result = true;
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                QuestDesignerMain.HandleException(e.Error, "Region loading error: " + e.Error.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.error);
            }
            else
            {
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
                Log.Info("Region successfully loaded");                
            }
            GC.Collect();
            QuestDesignerMain.DesignerForm.StatusProgress.Value = QuestDesignerMain.DesignerForm.StatusProgress.Minimum;
        }

        public static bool UnloadRegion()
        {
            if (m_OpenedRegion == null)
                return false;

            Log.Info("Unloading Region");

            //Delete all objects // SLOW
            Log.Info("Disposing Meshes..");
            foreach (GeometryObj obj in Objects.ToArray())
            {
                obj.Model.Mesh.Dispose();
                obj.Model = null;
            }
            QuestDesignerMain.DesignerForm.DXControl.HBObject = null;

            Log.Info("Clearing Lists..");

            Objects.Clear();
            
            // dont empty textures is caching is enabled
            if (!DOL.Tools.QuestDesigner.Properties.Settings.Default.CacheTextures)                
                Textures.Reset();

            Log.Info("Resetting Controls");

            ModulMgr.TriggerModule(ModulMgr.ModulEvent.RegionLoad, m_OpenedRegion);

            //Unset region
            m_OpenedRegion = null;

            //Scrollbars..
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Maximum = 0;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.SmallChange = 0;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.LargeChange = 0;

            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Maximum = 0;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.SmallChange = 0;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.LargeChange = 0;

            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Enabled = false;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Enabled = false;
            QuestDesignerMain.DesignerForm.DXControl.Zoom.Enabled = false;

            Log.Info("Redrawing..");

            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            GC.Collect();
            Log.Info("Ready");
            return true;
        }

        private class RegionSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                Region a = (Region) x;
                Region b = (Region) y;

                if (a.ID < b.ID)
                    return -1;
                if (a.ID == b.ID)
                    return 0;
                if (a.ID > b.ID)
                    return 1;

                return 0;
            }
        }
    }
}