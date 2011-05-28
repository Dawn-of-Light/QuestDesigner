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
using DOL.Database;
using Microsoft.DirectX.Direct3D;

namespace DOL.Tools.Mapping.Modules
{
    [Modul(true, true)]
    public class DatabaseWorldObjectModule : AbstractObjectModule<WorldObject>
    {        

        public const string MODULE_NAME = "Database World Objects";

        public DatabaseWorldObjectModule() : base(MODULE_NAME, 128, 128) { }        

        public override void Load()
        {
            //mobTableEventHandler = new DataRowChangeEventHandler(MobTable_RowChanged);
            //DB.NPCTable.RowChanged += mobTableEventHandler;
        }

        public override void Unload()
        {
            //DB.NPCTable.RowChanged -= mobTableEventHandler;
            //mobTableEventHandler = null;
        }               

        public override void RegionLoad(RegionMgr.Region region)
        {            
            // load mobs
            if (QuestDesignerMain.WaitForDatabase() && QuestDesignerMain.DatabaseSupported)
            {
                IList<WorldObject> objs = QuestDesignerMain.DatabaseAdapter.GetWorldObjectListForRegion(region.ID);
                foreach (WorldObject obj in objs)
                {
                    AddWorldObject(obj);
                }
            }
        }

        public override void RegionUnload(RegionMgr.Region region)
        {
            foreach (GeometryObj obj in GetObjects())
            {
                DXControl.GeoObjects.Remove(obj);
            }
            ClearObjectRowMapping();
        }

        public override void DXClick(MouseEventArgs e)
        {
        }

        public override void ObjectMoved(GeometryObj obj)
        {
            // new coordinates are already in the db row nothing else needs to be done.
            /*
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
             * */
        }

        public override GeometryObj GetObjectAt(int x, int y)
        {

            if (IsFiltered)
                return null;
            foreach (GeometryObj obj in GetObjects())
            {
                if (x >= obj.X - (Width / 2) && x <= obj.X + (Width / 2)
                    && y >= obj.Y - (Height / 2) && y <= obj.Y + (Height / 2))
                {
                    return obj;
                }
            }
            return null;
        }

        public override string GetInfoText(GeometryObj obj)
        {
            WorldObject mob = GetDataObjectForGeometryObject(obj);

            StringBuilder sb = new StringBuilder();
            sb.Append(mob.Name);
            return sb.ToString();
        }
        
        private GeometryObj AddWorldObject(WorldObject mob)
        {            
            float heading = Utils.HeadingToRadians(mob.Heading);

            GeometryObj obj = null;
                            
            Model m_PointModel;

            Texture texture = Textures.LoadMapObjectTexture(mob.ClassType);                        
            
            m_PointModel = new Model(Plane,  texture);

            obj = new GeometryObj(this,m_PointModel, DrawLevel.Middle, DetailLevel.MoreDetailed, mob.X, mob.Y, 0, 0, 0, heading,
                new Vector3(1, 1, 1),false,true);
            if (!IsFiltered)
                DXControl.GeoObjects.Add(obj);
            SetObjectForRow(mob, obj);
            
            return obj;
        }        
    }
}
