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
using DOL.Tools.Mapping.Forms;

namespace DOL.Tools.Mapping.Modules
{
    [Modul(true, true)]
    public class LocationModule : AbstractDataRowModule
    {

        public const int WIDTH = 300;
        public const int HEIGHT = 350;
        public const string MODULE_NAME = "Location";

        private DataRowChangeEventHandler locationTableEventHandler;

        public LocationModule(): base(MODULE_NAME) {}

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

        public override void RegionLoad(RegionMgr.Region region)
        {            
            // load locations
            DataRow[] locations = DB.LocationTable.Select(DB.COL_LOCATION_REGIONID+"=" + RegionMgr.CurrentRegion.ID);
            foreach (DataRow location in locations)
            {
                AddLocation(location);
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
            DataRow row = GetRowForObject(obj);

            if (row != null)
            {
                row.BeginEdit();
                row[DB.COL_LOCATION_X] = obj.X;
                row[DB.COL_LOCATION_Y] = obj.Y;
                row.EndEdit();
//                Log.Info("Moving to" + row[DB.COL_LOCATION_Y] + "|" + obj.Y);
            }
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
        }

        public override GeometryObj GetObjectAt(int x, int y)
        {            
            DataRow[] objs = DB.LocationTable.Select(DB.COL_LOCATION_REGIONID + "=" + RegionMgr.CurrentRegion.ID + " AND " + x + ">=" + DB.COL_LOCATION_X + "-" + (WIDTH / 2) + " AND " + x + "<=" + DB.COL_LOCATION_X + "+" + (WIDTH / 2) + " AND " + y + ">=" + DB.COL_LOCATION_Y + "-" + (HEIGHT / 2) + " AND " + y + "<=" + DB.COL_LOCATION_Y + "+" + (HEIGHT / 2));
            if (objs.Length > 0)
                return GetObjectForRow(objs[0]);
            //return new LocationMapObject(objs[0]);
            else
                return null;
        }

        public override void ClearDirty()
        {
            
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

        private GeometryObj EditLocation(GeometryObj obj, DataRow locationRow)
        {
            if (locationRow[DB.COL_LOCATION_X] == DBNull.Value || locationRow[DB.COL_LOCATION_Y] == DBNull.Value)
                return obj;

            float x = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_X]);
            float y = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_Y]);

            obj.X = x;
            obj.Y = y;

            return obj;
        }

        private GeometryObj AddLocation(DataRow locationRow)
        {
            if (locationRow[DB.COL_LOCATION_X] == DBNull.Value || locationRow[DB.COL_LOCATION_Y] == DBNull.Value)
                return null;

            float x = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_X]);
            float y = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_Y]);

            GeometryObj obj = null;
            if (x > 0 || y > 0)
            {
                
                Model m_PointModel;

                m_PointModel = new Model(Plane, Textures.Path);

                obj = new GeometryObj(this,m_PointModel, DrawLevel.Forer, DetailLevel.MoreDetailed, x, y, 0, 0, 0, 0,
                    new Vector3(2, 2, 2),true);
                DXControl.GeoObjects.Add(obj);
                SetObjectForRow(locationRow, obj);
            }
            return obj;
        }

        private void LocationTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow locationRow = e.Row;
            if (RegionMgr.CurrentRegion != null && locationRow[DB.COL_LOCATION_REGIONID] is int && (int)locationRow[DB.COL_LOCATION_REGIONID] == RegionMgr.CurrentRegion.ID)
            {
                if (e.Action == DataRowAction.Add)
                {
                    GeometryObj obj = AddLocation(locationRow);
                }
                else if (e.Action == DataRowAction.Delete)
                {
                    GeometryObj obj = GetObjectForRow(locationRow);
                    if (obj != null)
                        DXControl.GeoObjects.Remove(obj);

                    RemoveObjectForRow(locationRow);
                }
                else if (e.Action == DataRowAction.Change)
                {                    
                    GeometryObj obj = GetObjectForRow(locationRow);
                    if (obj != null)
                    {
                        EditLocation(obj, locationRow);
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
