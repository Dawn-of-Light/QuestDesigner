/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;
using Flobbster.Windows.Forms;
using DOL.Tools.QuestDesigner.Converter;
using Microsoft.DirectX;
using System.Reflection;

namespace DOL.Tools.QuestDesigner
{
    public partial class Location : UserControl
    {
        private PropertyBag locationBag;		

        public Location()
        {
            InitializeComponent();
        }


        private PropertySpec getLocationProperties(DataColumn col)
        {
            PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
            switch (col.ColumnName)
            {
                case "ID":
                    spec.Attributes = new Attribute[] { BrowsableAttribute.No };
                    break;
                case "RegionID":
                    spec.ConverterTypeName = typeof(RegionConverter).FullName;
                    spec.Category = "Location";
                    break;
                case "Heading":    
                case "X":
                case "Y":
                case "Z":
                    spec.Category = "Location";
                    break;
            }
            return spec;
        }

        void locationBag_SetValue(object sender, PropertySpecEventArgs e)
        {
            if (DB.locationBinding.Current != null)
            {
                DataRowView rowView;
                switch (e.Property.Name)
                {
                    case "Name":
                        rowView = ((DataRowView)DB.locationBinding.Current);

                        rowView[DB.COL_LOCATION_OBJECTNAME] = Utils.ConvertToObjectName((string)e.Value);
                        
                        ((DataRowView)DB.locationBinding.Current)[e.Property.Name] = e.Value;
                        break;
                    default:

                        // little hack since the typconverter seems to be skipped if the mousewheel is used to select a value from propertygrid
                        if (!DB.LocationTable.Columns[e.Property.Name].DataType.IsAssignableFrom(e.Value.GetType()))
                        {
                            TypeConverter conv = (TypeConverter)Activator.CreateInstance(Assembly.GetCallingAssembly().GetType(e.Property.ConverterTypeName));
                            e.Value = conv.ConvertTo(e.Value, DB.LocationTable.Columns[e.Property.Name].DataType);
                        }

                        ((DataRowView)DB.locationBinding.Current)[e.Property.Name] = e.Value;
                        break;
                }
                propertyGridLocation.Refresh();
                dataGridViewLocation.Refresh();
            }
        }

        void locationBag_GetValue(object sender, PropertySpecEventArgs e)
        {
            if (DB.locationBinding.Current != null)
            {
                DataRowView rowView = ((DataRowView)DB.locationBinding.Current);
                switch (e.Property.Name)
                {                    
                    default:
                        e.Value = rowView[e.Property.Name];
                        break;
                }
            }
        }


        public void SetDataSet()
        {
            // config Location
            locationBag = new PropertyBag();
            locationBag.GetValue += new PropertySpecEventHandler(locationBag_GetValue);
            locationBag.SetValue += new PropertySpecEventHandler(locationBag_SetValue);

            foreach (DataColumn col in DB.LocationTable.Columns)
            {
                locationBag.Properties.Add(getLocationProperties(col));
            }            

            propertyGridLocation.SelectedObject = locationBag;

            dataGridViewLocation.AutoGenerateColumns = false;
            dataGridViewLocation.DataSource = DB.locationBinding;
            
            colRegionID.ValueMember = DB.COL_REGION_ID;
            colRegionID.DisplayMember = DB.COL_REGION_DESCRIPTION;
            colRegionID.DataPropertyName = DB.COL_LOCATION_REGIONID;
            colRegionID.DataSource = DB.regionBinding;
        }



        private void dataGridViewLocation_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colObjectName.Name].Value = Const.GRID_AUTOFILL_VALUE;
        }

        private void dataGridViewLocation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridViewLocation.Rows[e.RowIndex];
            row.ErrorText = null;
            if (e.RowIndex == (dataGridViewLocation.Rows.Count - 2) &&
                dataGridViewLocation.Rows[e.RowIndex + 1].IsNewRow &&
                row.Cells[colObjectName.Name].Value != null &&
                (row.Cells[colObjectName.Name].Value == DBNull.Value ||
                 row.Cells[colObjectName.Name].Value.ToString() == Const.GRID_AUTOFILL_VALUE)
                )
            {
                string coname = row.Cells[colObjectName.Name].Value as string;
                if (coname != null)
                {
                    row.Cells[colObjectName.Name].Value = Utils.ConvertToObjectName(coname);
                    e.Cancel = false;
                }
            }
            else if (row.Cells[colObjectName.Name].Value != null &&
                row.Cells[colObjectName.Name].Value != DBNull.Value &&
                row.Cells[colObjectName.Name].Value.ToString() != Const.GRID_AUTOFILL_VALUE)
            {
                row.Cells[colObjectName.Name].Value = Utils.ConvertToObjectName(Convert.ToString(row.Cells[colObjectName.Name].Value));
            }
        }

        private void dataGridViewLocation_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dataGridViewLocation.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
                e.Cancel = true;
            }
        }


        private void dataGridViewLocation_SelectionChanged(object sender, EventArgs e)
        {
            if (DB.locationBinding.Current != null && dataGridViewLocation.CurrentRow != null && !dataGridViewLocation.CurrentRow.IsNewRow)
            {
                propertyGridLocation.Enabled = true;
                propertyGridLocation.Refresh();
            }
            else
                propertyGridLocation.Enabled = false;
        }

        private void pasteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject ido = Clipboard.GetDataObject();

            if (ido.GetDataPresent(ClipboardLocation.Format.Name))
            {                
                ClipboardLocation loc = (ClipboardLocation)ido.GetData(ClipboardLocation.Format.Name);                

                if (DB.locationBinding.Current!=null)
                {
                    DataRowView rowView = (DataRowView)DB.locationBinding.Current;                    
                    rowView[DB.COL_LOCATION_X] = loc.X;
                    rowView[DB.COL_LOCATION_Y] = loc.Y;
                    rowView[DB.COL_LOCATION_Z] = loc.Z;
                    rowView[DB.COL_LOCATION_REGIONID] = loc.RegionID;

                    propertyGridLocation.Refresh();
                }
            }
        }

        private void showOnMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DB.locationBinding.Current != null)
            {

                DataRowView rowView =(DataRowView) DB.locationBinding.Current;

                if (rowView[DB.COL_LOCATION_X] != DBNull.Value && rowView[DB.COL_LOCATION_Y] != DBNull.Value && rowView[DB.COL_LOCATION_REGIONID] != DBNull.Value)
                {

                    Vector3 location = new Vector3();

                    location.X = (float)Convert.ToDouble(rowView[DB.COL_LOCATION_X]);
                    location.Y = (float)Convert.ToDouble(rowView[DB.COL_LOCATION_Y]);

                    int regionID = Convert.ToInt32(rowView[DB.COL_LOCATION_REGIONID]);
                    QuestDesignerMain.DesignerForm.DXControl.ShowLocation(location, regionID);
                    QuestDesignerMain.DesignerForm.ShowTab("Map Editor");
                }

            }
        }
    }
}
