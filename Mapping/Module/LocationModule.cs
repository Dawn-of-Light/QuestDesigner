using System;
using System.Collections.Generic;
using System.Text;
using DOL.Tools.Mapping.Modules;
using DOL.Tools.Mapping.Map;
using System.Collections;
using System.Data;
using DOL.Tools.Mapping.DX;
using DOL.Tools.QuestDesigner.Util;
using System.Windows.Forms;
using DOL.Tools.Mapping.DX.Meshes;
using Microsoft.DirectX;
using DOL.Tools.QuestDesigner;

namespace DOL.Tools.Mapping.Modules
{
    [Modul("Location", true, true)]
    public class LocationModule : AbstractDataRowModule
    {

        private DataRowChangeEventHandler locationTableEventHandler;

        public override void Load()
        {
            locationTableEventHandler = new DataRowChangeEventHandler(LocationTable_RowChanged);
            DB.LocationTable.RowChanged += locationTableEventHandler;
        }

        public override void Unload()
        {
            DB.LocationTable.RowChanged -= locationTableEventHandler;
            locationTableEventHandler = null;
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
            
            // load locations
            DataRow[] locations = DB.LocationTable.Select("RegionID=" + RegionMgr.CurrentRegion.ID);
            foreach (DataRow location in locations)
            {
                AddLocation(location);
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
        }

        public override IMapObject GetObjectAt(int x, int y)
        {
            return null;
        }

        public override void ClearDirty()
        {
            
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

        public override Form GetPropertyForm()
        {
            return null;
        }

        public override ArrayList GetObjects()
        {
            return base.GetObjects();            
        }

        private GeometryObj AddLocation(DataRow locationRow)
        {
            float x = (float)Convert.ToDouble(locationRow["X"]);
            float y = (float)Convert.ToDouble(locationRow["Y"]);

            GeometryObj obj = null;
            if (x > 0 || y > 0)
            {
                
                Model m_PointModel;

                m_PointModel = new Model(Plane, Textures.Path);

                obj = new GeometryObj(m_PointModel, DrawLevel.Forer, DetailLevel.MoreDetailed, x, y, 0, 0, 0, 0,
                    new Vector3(2, 2, 2));
                Objects.Add(obj);
                SetObjectForRow(locationRow, obj);
            }
            return obj;
        }

        private void LocationTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow locationRow = e.Row;
            if (RegionMgr.CurrentRegion != null && locationRow["RegionID"] is int && (int)locationRow["RegionID"] == RegionMgr.CurrentRegion.ID)
            {
                if (e.Action == DataRowAction.Add)
                {
                    GeometryObj obj = AddLocation(locationRow);
                }
                else if (e.Action == DataRowAction.Delete)
                {
                    GeometryObj obj = GetObjectForRow(locationRow);
                    if (obj != null)
                        Objects.Remove(obj);

                    RemoveObjectForRow(locationRow);
                }
                else if (e.Action == DataRowAction.Change)
                {
                    float x = (float)Convert.ToDouble(locationRow["X"]);
                    float y = (float)Convert.ToDouble(locationRow["Y"]);

                    GeometryObj obj = GetObjectForRow(locationRow);
                    if (obj != null)
                    {
                        obj.X = x;
                        obj.Y = y;
                    }
                    else // no object found add it
                    {
                        AddLocation(locationRow);
                    }
                }
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            }
        }
        
    }
}
