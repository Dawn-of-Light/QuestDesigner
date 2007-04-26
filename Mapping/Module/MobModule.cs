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
using DOL.Tools.Mapping.Forms;

namespace DOL.Tools.Mapping.Modules
{
    [Modul(true, true)]
    public class MobModule : AbstractDataRowModule
    {        

        public const string MODULE_NAME = "Mob";
       
        public MobModule(): base(MODULE_NAME,350,350) {}

        private DataRowChangeEventHandler mobTableEventHandler;

        public override void Load()
        {
            mobTableEventHandler = new DataRowChangeEventHandler(MobTable_RowChanged);
            DB.NPCTable.RowChanged += mobTableEventHandler;
        }

        public override void Unload()
        {
            DB.NPCTable.RowChanged -= mobTableEventHandler;
            mobTableEventHandler = null;
        }        

        public override void RegionLoad(RegionMgr.Region region)
        {            
            // load mobs
            DataRow[] mobs = DB.NPCTable.Select(DB.COL_NPC_REGION+"=" + RegionMgr.CurrentRegion.ID);
            foreach (DataRow mob in mobs)
            {
                AddMob(mob);
            }
        }

        public override void RegionUnload(RegionMgr.Region region)
        {
            ClearObjectRowMapping();
        }

        public override void DXClick(MouseEventArgs e)
        {
        }

        public override void ObjectMoved(GeometryObj obj)
        {
            // new coordinates are already in the db row nothing else needs to be done.

            DataRow row = GetRowForObject(obj);

            if (row != null)
            {
                row.BeginEdit();
                row[DB.COL_NPC_X] = obj.X;
                row[DB.COL_NPC_Y] = obj.Y;
                row.EndEdit();
            }

            // render moved objects
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
        }

        public override GeometryObj GetObjectAt(int x, int y)
        {
            DataRow[] mobs = DB.NPCTable.Select(DB.COL_NPC_REGION + "=" + RegionMgr.CurrentRegion.ID + " AND " + x + ">=" + DB.COL_NPC_X + "-" + (Width / 2) + " AND " + x + "<=" + DB.COL_NPC_X + "+" + (Width / 2) + " AND " + y + ">=" + DB.COL_NPC_Y + "-" + (Height / 2) + " AND " + y + "<=" + DB.COL_NPC_Y + "+" + (Height / 2));
            if (mobs.Length > 0)
                return GetObjectForRow(mobs[0]);
                //return new MobMapObject(mobs[0]);
            else
                return null;
        }        

        public override void Filter()
        {
            foreach (GeometryObj obj in GetObjects())
            {
                DXControl.GeoObjects.Remove(obj);
            }
        }

        public override void Unfilter()
        {            
            DXControl.GeoObjects.AddRange(GetObjects());
        }

        public override void ClearDirty()
        {            
        }        

        private GeometryObj EditMob(GeometryObj obj, DataRow mobRow)
        {
            if (mobRow[DB.COL_NPC_X] == DBNull.Value || mobRow[DB.COL_NPC_Y] == DBNull.Value)
                return null;

            float x = (float)Convert.ToDouble(mobRow[DB.COL_NPC_X]);
            float y = (float)Convert.ToDouble(mobRow[DB.COL_NPC_Y]);
            float heading = Utils.HeadingToRadians((float)Convert.ToDouble(mobRow[DB.COL_NPC_HEADING]));

            obj.X = x;
            obj.Y = y;
            obj.Roll = heading;

            return obj;
        }

        private GeometryObj AddMob(DataRow mobRow)
        {
            if (mobRow[DB.COL_NPC_X] == DBNull.Value || mobRow[DB.COL_NPC_Y] == DBNull.Value)
                return null;

            float x = (float)Convert.ToDouble(mobRow[DB.COL_NPC_X]);
            float y = (float)Convert.ToDouble(mobRow[DB.COL_NPC_Y]);
            float heading = Utils.HeadingToRadians((float)((Convert.ToDouble(mobRow[DB.COL_NPC_HEADING]) )));

            GeometryObj obj = null;
            if (x > 0 || y > 0)
            {
                
                Model m_PointModel;
                if ((byte)mobRow[DB.COL_NPC_REALM] == (byte)DOL.GS.PacketHandler.eRealm.None)
                {
                    m_PointModel = new Model(Plane, Textures.Mob);
                }
                else
                {
                    m_PointModel = new Model(Plane, Textures.NPC);
                }

                obj = new GeometryObj(this,m_PointModel, DrawLevel.Forer, DetailLevel.MoreDetailed, x, y, 0, 0, 0, heading,
                    new Vector3(1, 1, 1),true);
                DXControl.GeoObjects.Add(obj);
                SetObjectForRow(mobRow, obj);
            }
            return obj;
        }        

        private void MobTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow mobRow = e.Row;
            if (RegionMgr.CurrentRegion != null && (int)mobRow[DB.COL_NPC_REGION] == RegionMgr.CurrentRegion.ID)
            {
                if (e.Action == DataRowAction.Add)
                {
                    GeometryObj obj = AddMob(mobRow);
                }
                else if (e.Action == DataRowAction.Delete)
                {
                    GeometryObj obj = GetObjectForRow(mobRow);
                    if (obj != null)
                        DXControl.GeoObjects.Remove(obj);

                    RemoveObjectForRow(mobRow);
                }
                else if (e.Action == DataRowAction.Change)
                {                    
                    GeometryObj obj = GetObjectForRow(mobRow);
                    if (obj != null)
                    {
                        EditMob(obj,mobRow);
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
