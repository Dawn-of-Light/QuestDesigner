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
using System.Threading;
using DOL.Tools.Mapping.Forms;
using System.Collections.Generic;
using DOL.Tools.QuestDesigner.Properties;

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
            private List<Zone> m_Zones;

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

            public List<Zone> Zones
            {
                get
                {
                    if (m_Zones == null)
                        m_Zones = new List<Zone>();

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
                        string reg = string.Format("{1} [{0}] ({2})", region.ID, region.Name, region.Zones.Count);
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
                //Look for regions...
                foreach (DataRow regionRow in DB.RegionTable.Rows)
                {
                    int id = (int)regionRow[DB.COL_REGION_ID];
                    string name = (string)regionRow[DB.COL_REGION_DESCRIPTION];

                    Region region = new Region(name, id);
                    m_Regions.Add(region);
                }                

                foreach (DataRow zoneRow in DB.ZoneTable.Rows)
                {
                    //1=1;8;8;67;67
                    //id=region;widht;height;xoff;yoff

                    int id = (int)zoneRow[DB.COL_ZONE_ID]; // int.Parse((string) entry.Key);
                    //string[] paras = ((string) entry.Value).Split(';');
                    int region = (int)zoneRow[DB.COL_ZONE_REGIONID]; // int.Parse(paras[0]);
                    int width = ((int)zoneRow[DB.COL_ZONE_WIDTH]) * 8192; //8192 = 256*256/8 - a zone is parted into 8 subzones
                    int height = ((int)zoneRow[DB.COL_ZONE_HEIGHT]) * 8192; //see above
                    int x = ((int)zoneRow[DB.COL_ZONE_OFFSETX]) * 8192;
                    int y = ((int)zoneRow[DB.COL_ZONE_OFFSETY]) * 8192;
                    string descr = Convert.ToString(zoneRow[DB.COL_ZONE_DESCRIPTION]);
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
                    int minWidth = int.MaxValue;
                    int minHeight = int.MaxValue;
                    int maxWidth = -1;
                    int maxHeight = -1;

                    foreach (Zone zone in region.Zones)
                    {
                        minWidth = Math.Min(minWidth, zone.X);
                        minHeight = Math.Min(minHeight, zone.Y);

                        maxWidth = Math.Max(maxWidth,zone.X + zone.Width);
                        maxHeight = Math.Max(maxHeight,zone.Y + zone.Height);
                    }

                    region.MinWidth = minWidth;
                    region.MaxHeight = maxHeight;
                    region.MaxWidth = maxWidth;
                    region.MaxHeight = maxHeight;
                    
                }
            }                        
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
                Log.Info(String.Format(Resources.msgRegionAlreadyLoaded, region.Name));
                return true;
            }

            // we are still loading a old region, cancel that operation
            if (backgroundWorker!=null && backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
                       
            UnloadRegion();                    
            

            //Create "hitbox"
            Mesh hb = Mesh.Box(Common.Device, 256*256*16, 256*256*16, 0.0f);
            XMesh ms = new XMesh(hb);
            
            Texture tx = Textures.Generator(Color.Cyan);
            Model mdl = new Model(ms, tx);
            GeometryObj bj =
                new GeometryObj(null,mdl, DrawLevel.NonRender, DetailLevel.Nondetailed, 256*256*16/2, 256*256*16/2, 0.0f,
                                0.0f, 0.0f, 0.0f, new Vector3(1.0f, 1.0f, 1.0f),false,false);
            DXControl.GeoObjects.Add(bj);
            QuestDesignerMain.DesignerForm.DXControl.HBObject = bj;
            
            try
            {
                m_OpenedRegion = region;

                backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorker_doWork);
                backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync();
            }
            catch (Exception e)
            {
                QuestDesignerMain.HandleException(e, Resources.msgRegionError+": " + e.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.databaseError);
            }
            
            //Scrollbars..
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Maximum = 256*256*16;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.SmallChange = 256;
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.LargeChange = 2560;
                        
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Minimum = 0;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Maximum = 256*256*16;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.SmallChange = 256;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.LargeChange = 2560;

            QuestDesignerMain.DesignerForm.DXControl.SetZoom(0.75F); ;
            
            int maxSize = Math.Max (region.MaxHeight - region.MinHeight,region.MaxWidth- region.MinWidth);
            int zoomFactor = (QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Maximum - QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Minimum) / 16 * (maxSize / (256 * 256));

            // restrcit zoomFactor zo Minimum-Maximum
            QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Value = Math.Min(QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Maximum, Math.Max(QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Minimum, zoomFactor));
                       
            QuestDesignerMain.DesignerForm.DXControl.hScrollBar.Enabled = true;
            QuestDesignerMain.DesignerForm.DXControl.vScrollBar.Enabled = true;
            QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Enabled = true;

            QuestDesignerMain.DesignerForm.DXControl.CenterView();

            ModulMgr.TriggerModules(ModulEvent.RegionLoad, region);

            // render newly added objects from Modules
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();

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

            lock (DXControl.GeoObjects)
            {
                foreach (Zone zone in m_OpenedRegion.Zones)
                {
                    //Create it!                    
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
                        new GeometryObj(null,model, DrawLevel.Background, DetailLevel.Nondetailed, zone.X, zone.Y, 0.0f, 0.0f,
                                        0.0f, 0.0f, new Vector3(1.0f, 1.0f, 1.0f),false,false);
                    DXControl.GeoObjects.Add(obj);

                    if (QuestDesignerMain.DesignerForm != null && !QuestDesignerMain.DesignerForm.StatusProgress.IsDisposed)
                    {
                        QuestDesignerMain.DesignerForm.StatusProgress.PerformStep();
                        QuestDesignerMain.DesignerForm.DXControl.Invalidate();
                    }
                }
            }

            e.Result = true;
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                QuestDesignerMain.HandleException(e.Error, Resources.msgRegionError+": " + e.Error.Message, global::DOL.Tools.QuestDesigner.Properties.Resources.error);
            }
            else
            {
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
                Log.Info(Resources.msgRegionSuccess);                
            }

            if (QuestDesignerMain.DesignerForm != null && !QuestDesignerMain.DesignerForm.StatusProgress.IsDisposed)
            {
                QuestDesignerMain.DesignerForm.StatusProgress.Value = QuestDesignerMain.DesignerForm.StatusProgress.Minimum;
            }
        }

        public static bool UnloadRegion()
        {
            if (m_OpenedRegion == null)
                return false;            

            //Delete all objects // SLOW
            lock (DXControl.GeoObjects)
            {
                foreach (GeometryObj obj in DXControl.GeoObjects)
                {
                    obj.Model.Mesh.Dispose();
                    obj.Model = null;
                }
                QuestDesignerMain.DesignerForm.DXControl.HBObject = null;
                
                DXControl.GeoObjects.Clear();                
            }
            // dont empty textures is caching is enabled
            if (!DOL.Tools.QuestDesigner.Properties.Settings.Default.CacheTextures)                
                Textures.Reset();            

            ModulMgr.TriggerModules(ModulEvent.RegionUnload, m_OpenedRegion);

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
            QuestDesignerMain.DesignerForm.DXControl.ZoomSlider.Enabled = false;

            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            
            return true;
        }

        private class RegionSorter : IComparer
        {
            public int Compare(object x, object y)
            {
                Region a = (Region) x;
                Region b = (Region) y;
                                
                return (b.Zones.Count - a.Zones.Count) * 10000 + a.Name.CompareTo(b.Name);
            
            }
        }
    }
}