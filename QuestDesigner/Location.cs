using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;
using Flobbster.Windows.Forms;
using QuestDesigner.Converter;

namespace QuestDesigner
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
                    break;
                case "ZoneID":
                    spec.ConverterTypeName = typeof(ZoneConverter).FullName;
                    spec.Category = "Local";
                    break;
                case "X":
                case "Y":
                case "Z":
                    spec.Category = "Global";
                    break;
                case "Heading":
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
                    case "Zone X":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        if (rowView["ZoneID"] is int)
                        {
                            rowView["X"] = Utils.ConvertZoneXToRegion((int)rowView["ZoneID"], (int)e.Value);
                        }
                        else
                        {
                            MessageBox.Show("Select a Zone first, or the global coordinate cannot be computed.");
                        }
                        break;
                    case "Zone Y":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        if (rowView["ZoneID"] is int)
                        {
                            rowView["Y"] = Utils.ConvertZoneYToRegion((int)rowView["ZoneID"], (int)e.Value);
                        }
                        else
                        {
                            MessageBox.Show("Select a Zone first, or the global coordinate cannot be computed.");
                        }
                        break;
                    case "Zone Z":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        rowView["Z"] = e.Value;
                        break;

                    case "Name":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        if (string.IsNullOrEmpty(Convert.ToString(rowView["ObjectName"])))
                        {
                            rowView["ObjectName"] = Utils.ConvertToObjectName((string)e.Value);
                        }
                        ((DataRowView)DB.locationBinding.Current)[e.Property.Name] = e.Value;
                        break;
                    case "RegionID":
                        if (e.Value is int)
                            DB.zoneBinding.Filter = "regionID=" + e.Value;
                        else
                            DB.zoneBinding.Filter = null;

                        ((DataRowView)DB.locationBinding.Current)[e.Property.Name] = e.Value;
                        break;
                    default:
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
                DataRowView rowView;
                switch (e.Property.Name)
                {
                    case "Zone X":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        if (rowView["ZoneID"] is int && rowView["X"] is int)
                        {
                            e.Value = Utils.ConvertRegionXToZone((int)rowView["ZoneID"], (int)rowView["X"]);
                        }

                        break;
                    case "Zone Y":
                        rowView = ((DataRowView)DB.locationBinding.Current);
                        if (rowView["ZoneID"] is int && rowView["Y"] is int)
                        {
                            e.Value = Utils.ConvertRegionYToZone((int)rowView["ZoneID"], (int)rowView["Y"]);
                        }
                        break;
                    case "Zone Z":
                        e.Value = ((DataRowView)DB.locationBinding.Current)["Z"];
                        break;
                    default:
                        e.Value = ((DataRowView)DB.locationBinding.Current)[e.Property.Name];
                        break;
                }
            }
        }


        public void SetDataSet(DataSet dataset)
        {
            // config Location
            locationBag = new PropertyBag();
            locationBag.GetValue += new PropertySpecEventHandler(locationBag_GetValue);
            locationBag.SetValue += new PropertySpecEventHandler(locationBag_SetValue);

            foreach (DataColumn col in DB.LocationTable.Columns)
            {
                locationBag.Properties.Add(getLocationProperties(col));
            }
            locationBag.Properties.Add(new PropertySpec("Zone X", typeof(int), "Local", "Zone related X Coordinate"));
            locationBag.Properties.Add(new PropertySpec("Zone Y", typeof(int), "Local", "Zone related Y Coordinate"));
            locationBag.Properties.Add(new PropertySpec("Zone Z", typeof(int), "Local", "Zone related Z Coordinate"));

            propertyGridLocation.SelectedObject = locationBag;

            dataGridViewLocation.AutoGenerateColumns = false;
            dataGridViewLocation.DataSource = DB.locationBinding;

            colRegionID.DataSource = DB.RegionTable;
            colRegionID.ValueMember = "id";
            colRegionID.DisplayMember = "description";
            colRegionID.DataPropertyName = "RegionID";
        }



        private void dataGridViewLocation_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colObjectName.Name].Value = "<AUTO>";
        }

        private void dataGridViewLocation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridViewLocation.Rows[e.RowIndex];
            row.ErrorText = null;
            if (e.RowIndex == (dataGridViewLocation.Rows.Count - 2) &&
                dataGridViewLocation.Rows[e.RowIndex + 1].IsNewRow &&
                row.Cells[colObjectName.Name].Value != null &&
                (row.Cells[colObjectName.Name].Value == DBNull.Value ||
                 row.Cells[colObjectName.Name].Value.ToString() == "<AUTO>")
                )
            {
                string coname = row.Cells[colLocationName.Name].Value as string;
                if (coname != null)
                {
                    row.Cells[colObjectName.Name].Value = Utils.ConvertToObjectName(coname);
                    e.Cancel = false;
                }
            }
            else if (row.Cells[colObjectName.Name].Value != null &&
                row.Cells[colObjectName.Name].Value != DBNull.Value &&
                row.Cells[colObjectName.Name].Value.ToString() != "<AUTO>")
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
    }
}
