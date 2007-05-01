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
using Microsoft.DirectX;
using System.Drawing;
using DOL.Tools.QuestDesigner;
using DOL.Tools.Mapping.Forms;

namespace DOL.Tools.Mapping.Modules
{
    [Modul(true, true)]
    public class AreaModule : AbstractDataRowModule
    {
        public const string MODULE_NAME = "Area";

        private DataRowChangeEventHandler areaTableEventHandler;
        private DataTableClearEventHandler areaTableClearEventHandler;        

        public AreaModule(): base(MODULE_NAME) {}

        public override string GetInfoText(GeometryObj obj)
        {
            DataRow areaRow = GetDataObjectForGeometryObject(obj);

            StringBuilder sb = new StringBuilder();

            sb.Append((string)areaRow[DB.COL_AREA_NAME]);

            return sb.ToString();
        }

        public override void Load()
        {            
            areaTableEventHandler = new DataRowChangeEventHandler(AreaTable_RowChanged);
            areaTableClearEventHandler = new DataTableClearEventHandler(AreaTable_TableClearing);
            DB.AreaTable.RowChanged += areaTableEventHandler;
            DB.AreaTable.RowDeleting += areaTableEventHandler;
            DB.AreaTable.TableClearing += areaTableClearEventHandler;
        }

        void AreaTable_TableClearing(object sender, DataTableClearEventArgs e)
        {
            foreach (GeometryObj obj in GetObjects())
            {
                DXControl.GeoObjects.Remove(obj);
            }
            ClearObjectRowMapping();
        }

        public override void Unload()
        {
            DB.LocationTable.RowChanged -= areaTableEventHandler;
            DB.LocationTable.RowDeleting-= areaTableEventHandler;
            DB.AreaTable.TableClearing -= areaTableClearEventHandler;
            areaTableEventHandler = null;
            areaTableClearEventHandler = null;
        }        

        public override void RegionLoad(RegionMgr.Region region)
        {            
            // load locations
            DataRow[] areas = DB.AreaTable.Select(DB.COL_AREA_REGIONID+"=" + region.ID);
            foreach (DataRow area in areas)
            {
                AddArea(area);
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

                // since aresquare is not centered in mapviewer mode handle is special here
                if ((string)row[DB.COL_AREA_AREATYPE] == Const.AREA_SQUARE)
                {
                    row[DB.COL_AREA_X] = obj.X - Convert.ToInt32(row[DB.COL_AREA_Z]) / 2;
                    row[DB.COL_AREA_Y] = obj.Y - Convert.ToInt32(row[DB.COL_AREA_R]) / 2;
                }
                else
                {
                    row[DB.COL_AREA_X] = obj.X;
                    row[DB.COL_AREA_Y] = obj.Y;
                }
                row.EndEdit();                
            }
            QuestDesignerMain.DesignerForm.DXControl.Invalidate();
        }

        public override GeometryObj GetObjectAt(int x, int y)
        {
            if (IsFiltered)
                return null;

            DataRow[] objs = DB.AreaTable.Select(DB.COL_AREA_REGIONID + "=" + RegionMgr.CurrentRegion.ID + " AND " + DB.COL_AREA_AREATYPE + "='" + Const.AREA_SQUARE+ "' AND " + x + ">=" + DB.COL_AREA_X + " AND " + x + "<= (" + DB.COL_AREA_X + "+" + DB.COL_AREA_Z + ") AND " + y + ">=" + DB.COL_AREA_Y + " AND " + y + "<= (" + DB.COL_AREA_Y + "+" + DB.COL_AREA_R + ")");            
            if (objs.Length > 0)
                return GetGeometryObjectForDataObject(objs[0]);
            
            objs = DB.AreaTable.Select(DB.COL_AREA_REGIONID + "=" + RegionMgr.CurrentRegion.ID + " AND " + DB.COL_AREA_AREATYPE + "='" + Const.AREA_CIRCLE + "' AND " + x + ">= (" + DB.COL_AREA_X + " - "+ DB.COL_AREA_R+ "/2) AND " + x + "<= (" + DB.COL_AREA_X + "+" + DB.COL_AREA_R + "/2) AND " + y + ">= (" + DB.COL_AREA_Y +" - "+DB.COL_AREA_R + "/2) AND " + y + "<= (" + DB.COL_AREA_Y + "+" + DB.COL_AREA_R + "/2)");
            if (objs.Length > 0)
                return GetGeometryObjectForDataObject(objs[0]);
            
            return null;
        }                        

        private GeometryObj AddArea(DataRow areaRow)
        {
            if (areaRow[DB.COL_AREA_X] == DBNull.Value || areaRow[DB.COL_AREA_Y] == DBNull.Value)
                return null;

            float x = (float)Convert.ToDouble(areaRow[DB.COL_AREA_X]);
            float y = (float)Convert.ToDouble(areaRow[DB.COL_AREA_Y]);

            float width = areaRow[DB.COL_AREA_Z] == DBNull.Value ? 0 : (float)Convert.ToDouble(areaRow[DB.COL_AREA_Z]);
            float height = areaRow[DB.COL_AREA_R] == DBNull.Value ? 0 : (float)Convert.ToDouble(areaRow[DB.COL_AREA_R]);

            GeometryObj obj = null;
            if (x > 0 || y > 0)
            {                
                Model m_PointModel;
                if ((string)areaRow[DB.COL_AREA_AREATYPE] == Const.AREA_SQUARE)
                {
                    DOL.Tools.Mapping.DX.Meshes.Plane plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, width, height, false);                    
                    m_PointModel = new Model(plane, Textures.AreaSquare);
                }
                else
                {
                    DOL.Tools.Mapping.DX.Meshes.Plane plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, height, height, true);                    
                    m_PointModel = new Model(plane, Textures.AreaCircle);
                }

                obj = new GeometryObj(this, m_PointModel, DrawLevel.Backer, DetailLevel.Nondetailed, x, y, 0, 0, 0, 0,
                    new Vector3(1, 1, 1), true,false);

                if (!IsFiltered)
                    DXControl.GeoObjects.Add(obj);

                SetObjectForRow(areaRow, obj);
            }
            return obj;
        }

        private GeometryObj EditArea(GeometryObj obj, DataRow areaRow)
        {
            if (areaRow[DB.COL_AREA_X] == DBNull.Value || areaRow[DB.COL_AREA_Y] == DBNull.Value)
                return null;

            float x = (float)Convert.ToDouble(areaRow[DB.COL_AREA_X]);
            float y = (float)Convert.ToDouble(areaRow[DB.COL_AREA_Y]);

            float width = areaRow[DB.COL_AREA_Z] == DBNull.Value ? 0 : (float)Convert.ToDouble(areaRow[DB.COL_AREA_Z]);
            float height = areaRow[DB.COL_AREA_R] == DBNull.Value ? 0 : (float)Convert.ToDouble(areaRow[DB.COL_AREA_R]);
            
            if (x > 0 || y > 0)
            {                
                Model m_PointModel;
                if ((string)areaRow[DB.COL_AREA_AREATYPE] == Const.AREA_SQUARE)
                {
                    DOL.Tools.Mapping.DX.Meshes.Plane plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, width, height, false);                    
                    m_PointModel = new Model(plane, Textures.AreaSquare);
                }
                else
                {
                    DOL.Tools.Mapping.DX.Meshes.Plane plane = new DOL.Tools.Mapping.DX.Meshes.Plane(Common.Device, height, height, true);                    
                    m_PointModel = new Model(plane, Textures.AreaCircle);
                }

                obj.Model = m_PointModel;
                obj.X = x;
                obj.Y = y;                               
            }
            return obj;
        }

        private void AreaTable_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            DataRow areaRow = e.Row;
            if (RegionMgr.CurrentRegion != null && areaRow[DB.COL_AREA_REGIONID] is int && (int)areaRow[DB.COL_AREA_REGIONID] == RegionMgr.CurrentRegion.ID)
            {
                if (e.Action == DataRowAction.Add)
                {
                    GeometryObj obj = AddArea(areaRow);
                }
                else if (e.Action == DataRowAction.Delete)
                {
                    GeometryObj obj = GetGeometryObjectForDataObject(areaRow);
                    if (obj != null)
                        DXControl.GeoObjects.Remove(obj);

                    RemoveObjectForRow(areaRow);
                }
                else if (e.Action == DataRowAction.Change)
                {                    
                    GeometryObj obj = GetGeometryObjectForDataObject(areaRow);
                                                           
                    if (obj != null)
                    {
                        EditArea(obj, areaRow);
                    }
                    else // no object found add it
                    {
                        AddArea(areaRow);
                    }

                }
                QuestDesignerMain.DesignerForm.DXControl.Invalidate();
            }
        }

    }
}
