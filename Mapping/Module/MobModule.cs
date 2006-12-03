using System;
using System.Collections.Generic;
using System.Text;
using DOL.Tools.Mapping.Modules;
using DOL.Tools.Mapping.Map;
using System.Collections;
using System.Data;
using DOL.Tools.Mapping.DX;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;
using DOL.Tools.Mapping.DX.Meshes;
using Microsoft.DirectX;
using DOL.Tools.QuestDesigner;

namespace DOL.Tools.Mapping.Modules
{
    [Modul(MODULE_NAME, true, true)]
    public class MobModule : AbstractDataRowModule
    {

        public const string MODULE_NAME = "Mob";

        public class MobMapObject : IMapObject
        {
            DataRow row;

            public const int WIDTH = 300;
            public const int HEIGHT = 350;

            public MobMapObject(DataRow row)
            {
                this.row = row;
            }

            public IModul Modul
            {
                get { return ModulMgr.GetModulByName(MODULE_NAME).Modul; }
            }

            public int X
            {
                get
                {
                    return (int)row["X"];
                }
                set
                {
                    row["X"] = value;
                }
            }

            public int Y
            {
                get
                {
                    return (int)row["Y"];
                }
                set
                {
                    row["Y"] = value;
                }
            }

            public bool IsMovable
            {
                get {return true;}
            }

            public bool IsHit(int x, int y)
            {
                return (x >= X - (WIDTH/2) && x <= X + (WIDTH/2) && y >= Y - (HEIGHT/2) && y <= Y + (HEIGHT/2));
            }
        }


        private DataRowChangeEventHandler mobTableEventHandler;

        public override void Load()
        {
            mobTableEventHandler = new DataRowChangeEventHandler(MobTable_RowChanged);
            DB.MobTable.RowChanged += mobTableEventHandler;
        }

        public override void Unload()
        {
            DB.MobTable.RowChanged -= mobTableEventHandler;
            mobTableEventHandler = null;
        }

        public override void Activate()
        {
        }

        public override void Deactivate()
        {
        }

        public override void RegionLoad(RegionMgr.Region region)
        {
            ClearObjectRowMapping();

            // load mobs
            DataRow[] mobs = DB.MobTable.Select("Region=" + RegionMgr.CurrentRegion.ID);
            foreach (DataRow mob in mobs)
            {
                AddMob(mob);
            }
        }

        public override void RegionUnload(RegionMgr.Region region)
        {
        }

        public override void DXClick(MouseEventArgs e)
        {
        }

        public override void ObjectMoved(IMapObject obj)
        {
            // new coordinates are already in the db row nothing else needs to be done.

            // render moved objects
            Objects.Render();
        }

        public override IMapObject GetObjectAt(int x, int y)
        {
            DataRow[] mobs = DB.MobTable.Select("Region=" + RegionMgr.CurrentRegion.ID+" AND "+x+">=X-"+(MobMapObject.WIDTH/2)+" AND "+x+"<=X+"+(MobMapObject.WIDTH/2)+" AND "+y+">=Y-"+(MobMapObject.HEIGHT/2)+" AND "+y+"<=Y+"+(MobMapObject.HEIGHT/2));
            if (mobs.Length > 0)
                return new MobMapObject(mobs[0]);
            else
                return null;
        }

        public override ArrayList GetObjects()
        {
            return base.GetObjects();
        }

        public override void Filter(ModulMgr.ModulObj mod)
        {
            foreach (GeometryObj obj in GetObjects())
            {
                Objects.Remove(obj);
            }
        }

        public override void Unfilter(ModulMgr.ModulObj mod)
        {
            foreach (GeometryObj obj in GetObjects())
            {
                Objects.Add(obj);
            }
        }

        public override void ClearDirty()
        {            
        }

        public override Form GetPropertyForm()
        {
            return null;
        }

        private GeometryObj AddMob(DataRow mobRow)
        {
            float x = (float)Convert.ToDouble(mobRow["X"]);
            float y = (float)Convert.ToDouble(mobRow["Y"]);

            GeometryObj obj = null;
            if (x > 0 || y > 0)
            {
                
                Model m_PointModel;
                if ((byte)mobRow["Realm"] == (byte)DOL.GS.PacketHandler.eRealm.None)
                {
                    m_PointModel = new Model(Plane, Textures.Mob);
                }
                else
                {
                    m_PointModel = new Model(Plane, Textures.NPC);
                }

                obj = new GeometryObj(m_PointModel, DrawLevel.Forer, DetailLevel.MoreDetailed, x, y, 0, 0, 0, 0,
                    new Vector3(2, 2, 2));
                Objects.Add(obj);
                SetObjectForRow(mobRow, obj);
            }
            return obj;
        }        

        private void MobTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow mobRow = e.Row;
            if (RegionMgr.CurrentRegion != null && (int)mobRow["Region"] == RegionMgr.CurrentRegion.ID)
            {
                if (e.Action == DataRowAction.Add)
                {
                    GeometryObj obj = AddMob(mobRow);
                }
                else if (e.Action == DataRowAction.Delete)
                {
                    GeometryObj obj = GetObjectForRow(mobRow);
                    if (obj != null)
                        Objects.Remove(obj);

                    RemoveObjectForRow(mobRow);
                }
                else if (e.Action == DataRowAction.Change)
                {
                    float x = (float)Convert.ToDouble(mobRow["X"]);
                    float y = (float)Convert.ToDouble(mobRow["Y"]);

                    GeometryObj obj = GetObjectForRow(mobRow);
                    if (obj != null)
                    {
                        obj.X = x;
                        obj.Y = y;
                    }
                    else
                    {
                        AddMob(mobRow);
                    }
                }
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            }
        }
        
    }
}
