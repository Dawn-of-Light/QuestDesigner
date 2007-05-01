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
        public const string MODULE_NAME = "Location";        

        private DataRowChangeEventHandler locationTableEventHandler;

        private DataTableClearEventHandler locationTableClearEventHandler;

        public LocationModule(): base(MODULE_NAME,128,128) {}

        public override void Load()
        {
            locationTableEventHandler = new DataRowChangeEventHandler(LocationTable_RowChanged);
            locationTableClearEventHandler = new DataTableClearEventHandler(LocationTable_TableClearing);
            DB.LocationTable.RowChanged += locationTableEventHandler;
            DB.LocationTable.RowDeleting += locationTableEventHandler;
            DB.LocationTable.TableClearing += locationTableClearEventHandler;
        }

        void LocationTable_TableClearing(object sender, DataTableClearEventArgs e)
        {
            foreach (GeometryObj obj in GetObjects())
            {
                DXControl.GeoObjects.Remove(obj);
            }
            ClearObjectRowMapping();
        }

        public override void Unload()
        {
            DB.LocationTable.RowChanged -= locationTableEventHandler;
            DB.LocationTable.RowDeleting -= locationTableEventHandler;
            DB.LocationTable.TableClearing -= locationTableClearEventHandler;
            locationTableEventHandler = null;
            locationTableClearEventHandler = null;
        }

        public override string GetInfoText(GeometryObj obj)
        {
            DataRow locationRow = GetDataObjectForGeometryObject(obj);

            StringBuilder sb = new StringBuilder();

            sb.Append((string)locationRow[DB.COL_LOCATION_NAME]);

            return sb.ToString();
        }

        public override void RegionLoad(RegionMgr.Region region)
        {            
            // load locations
            DataRow[] locations = DB.LocationTable.Select(DB.COL_LOCATION_REGIONID+"=" + region.ID);
            foreach (DataRow location in locations)
            {
                AddLocation(location);
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
            DataRow row = GetDataObjectForGeometryObject(obj);

            if (row != null)
            {
                row.BeginEdit();
                row[DB.COL_LOCATION_X] = obj.X;
                row[DB.COL_LOCATION_Y] = obj.Y;
                row.EndEdit();

            }
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
        }

        public override GeometryObj GetObjectAt(int x, int y)
        {
            if (IsFiltered)
                return null;

            DataRow[] objs = DB.LocationTable.Select(DB.COL_LOCATION_REGIONID + "=" + RegionMgr.CurrentRegion.ID + " AND " + x + ">=" + DB.COL_LOCATION_X + "-" + (Width / 2) + " AND " + x + "<=" + DB.COL_LOCATION_X + "+" + (Width / 2) + " AND " + y + ">=" + DB.COL_LOCATION_Y + "-" + (Height / 2) + " AND " + y + "<=" + DB.COL_LOCATION_Y + "+" + (Height / 2));
            if (objs.Length > 0)
                return GetGeometryObjectForDataObject(objs[0]);
            else
                return null;
        }        

               

        private GeometryObj EditLocation(GeometryObj obj, DataRow locationRow)
        {
            if (locationRow[DB.COL_LOCATION_X] == DBNull.Value || locationRow[DB.COL_LOCATION_Y] == DBNull.Value)
                return obj;

            float x = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_X]);
            float y = (float)Convert.ToDouble(locationRow[DB.COL_LOCATION_Y]);
            float heading = Utils.HeadingToRadians(Convert.ToInt32(locationRow[DB.COL_LOCATION_HEADING]));

            obj.X = x;
            obj.Y = y;
            obj.Roll = heading;

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

                m_PointModel = new Model(Plane, Textures.LoadMapObjectTexture("Location"));

                obj = new GeometryObj(this,m_PointModel, DrawLevel.Forer, DetailLevel.Detailed, x, y, 0, 0, 0, 0,
                    new Vector3(2, 2, 2),true,true);
                if (!IsFiltered)
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
                    GeometryObj obj = GetGeometryObjectForDataObject(locationRow);
                    if (obj != null)
                        DXControl.GeoObjects.Remove(obj);

                    RemoveObjectForRow(locationRow);
                }
                else if (e.Action == DataRowAction.Change)
                {                    
                    GeometryObj obj = GetGeometryObjectForDataObject(locationRow);
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
