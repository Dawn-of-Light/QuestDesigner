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
    public partial class Area : UserControl
    {

        private PropertyBag areaCircleBag, areaSquareBag;

        public Area()
        {
            InitializeComponent();
        }

        public void setDataSet(DataSet questData)
        {
            // config area

            areaCircleBag = new PropertyBag();
            areaCircleBag.GetValue += new PropertySpecEventHandler(areaBag_GetValue);
            areaCircleBag.SetValue += new PropertySpecEventHandler(areaBag_SetValue);

            foreach (DataColumn col in DB.AreaTable.Columns)
            {
                areaCircleBag.Properties.Add(getAreaCircleProperties(col));
            }
            areaSquareBag = new PropertyBag();
            areaSquareBag.GetValue += new PropertySpecEventHandler(areaBag_GetValue);
            areaSquareBag.SetValue += new PropertySpecEventHandler(areaBag_SetValue);

            foreach (DataColumn col in DB.AreaTable.Columns)
            {
                areaSquareBag.Properties.Add(getAreaSquareProperties(col));
            }
            propertyGridArea.SelectedObject = areaCircleBag;

            dataGridArea.AutoGenerateColumns = false;
            dataGridArea.DataSource = DB.areaBinding;

            colRegionID.DataSource = DB.RegionTable;
            colRegionID.DataPropertyName = "RegionID";
            colRegionID.ValueMember = "id";
            colRegionID.DisplayMember = "description";
        }
        void areaBag_SetValue(object sender, PropertySpecEventArgs e)
        {
            if (DB.areaBinding.Current != null)
            {
                DataRowView rowView = ((DataRowView)DB.areaBinding.Current);
                if (rowView.Row.RowState == DataRowState.Detached)
                {                    
                    return;
                }

                switch (e.Property.Name)
                {
                    case "Name":                        
                        rowView[e.Property.Name] = e.Value;
                        rowView["ObjectName"] = Utils.ConvertToObjectName((string)e.Value);
                        break;
                    case "Width":
                        rowView["Z"] = e.Value;
                        break;
                    case "Height":
                        rowView["R"] = e.Value;
                        break;                    
                    default:

                        // little hack since the typconverter seems to be skipped if the mousewheel is used to select a value from propertygrid
                        if (!DB.AreaTable.Columns[e.Property.Name].DataType.IsAssignableFrom(e.Value.GetType()))
                        {
                            TypeConverter conv = (TypeConverter)Activator.CreateInstance(Assembly.GetCallingAssembly().GetType(e.Property.ConverterTypeName));
                            e.Value = conv.ConvertTo(e.Value, DB.AreaTable.Columns[e.Property.Name].DataType);
                        }

                        rowView[e.Property.Name] = e.Value;
                        break;
                }
                if ("AreaType".Equals(e.Property.Name))
                {
                    if ("Square".Equals(e.Value))
                        propertyGridArea.SelectedObject = areaSquareBag;
                    else
                        propertyGridArea.SelectedObject = areaCircleBag;
                }

                propertyGridArea.Refresh();
                dataGridArea.Refresh();
            }
        }

        void areaBag_GetValue(object sender, PropertySpecEventArgs e)
        {
            if (DB.areaBinding.Current != null)
            {
                DataRowView rowView = ((DataRowView)DB.areaBinding.Current);
                if (rowView.Row.RowState == DataRowState.Detached)
                {
                    e.Value = null;
                    return;
                }
                switch (e.Property.Name)
                {
                    case "Width":
                        e.Value = rowView["Z"];
                        break;
                    case "Height":
                        e.Value = rowView["R"];
                        break;
                    default:
                        e.Value = rowView[e.Property.Name];
                        break;
                }
            }
        }

        private PropertySpec getAreaCircleProperties(DataColumn col)
        {
            PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
            switch (col.ColumnName)
            {
                case "RegionID":
                    spec.ConverterTypeName = typeof(RegionConverter).FullName;
                    spec.Category = "Location";
                    break;
                case "R":
                    spec.Description = "Radius of Circle";
                    spec.Category = "Location";
                    break;
                case "X":
                case "Y":
                case "Z":                
                    spec.Category = "Location";
                    break;
                case "AreaType":
                    spec.ConverterTypeName = typeof(AreaTypeConverter).FullName;
                    break;
            }
            return spec;
        }

        private PropertySpec getAreaSquareProperties(DataColumn col)
        {
            PropertySpec spec = new PropertySpec(col.ColumnName, col.DataType, null, null, col.DefaultValue);
            switch (col.ColumnName)
            {
                case "RegionID":
                    spec.ConverterTypeName = typeof(RegionConverter).FullName;
                    spec.Category = "Location";
                    break;
                case "X":
                    spec.Description = "X Coordinate of Square";
                    spec.Category = "Location";
                    break;
                case "Y":
                    spec.Description = "Y Coordinate of Square";
                    spec.Category = "Location";
                    break;
                case "Z":
                    spec.Name = "Width";
                    spec.Description = "Width of Square";
                    spec.Category = "Location";
                    break;
                case "R":
                    spec.Name = "Height";
                    spec.Description = "Height of Square";
                    spec.Category = "Location";
                    break;
                case "AreaType":
                    spec.ConverterTypeName = typeof(AreaTypeConverter).FullName;
                    break;
            }
            return spec;
        }

        private void Area_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridArea_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dataGridArea.Rows[e.RowIndex];
            row.ErrorText = null;
            if (e.RowIndex == (dataGridArea.Rows.Count - 2) &&
                dataGridArea.Rows[e.RowIndex + 1].IsNewRow &&
                row.Cells[colObjectName.Name].Value != null &&
                (row.Cells[colObjectName.Name].Value == DBNull.Value ||
                 row.Cells[colObjectName.Name].Value.ToString() == Const.GRID_AUTOFILL_VALUE)
                )
            {
                string coname = row.Cells[colAreaName.Name].Value as string;
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

        private void dataGridArea_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                dataGridArea.Rows[e.RowIndex].ErrorText = e.Exception.ToString();
                e.Cancel = true;
            }
        }

        private void dataGridArea_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[colObjectName.Name].Value = Const.GRID_AUTOFILL_VALUE;
            //e.Row.Cells[colObjectName.Name].Value = Const.GRID_AUTOFILL_VALUE;
        }

        private void dataGridArea_SelectionChanged(object sender, EventArgs e)
        {
            if (DB.areaBinding.Current != null && dataGridArea.CurrentRow != null && !dataGridArea.CurrentRow.IsNewRow)
            {
                propertyGridArea.Enabled = true;
                if (Convert.ToString(((DataRowView)DB.areaBinding.Current)["AreaType"]) == "Square")
                    propertyGridArea.SelectedObject = areaSquareBag;
                else
                    propertyGridArea.SelectedObject = areaCircleBag;
            }
            else
                propertyGridArea.Enabled = false;
        }

        private void pasteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject ido = Clipboard.GetDataObject();

            if (ido.GetDataPresent(ClipboardLocation.Format.Name))
            {
                // Text data is present on the clipboard
                ClipboardLocation loc = (ClipboardLocation)ido.GetData(ClipboardLocation.Format.Name);                

                if (DB.areaBinding.Current != null)
                {
                    DataRowView rowView = (DataRowView)DB.areaBinding.Current;
                    rowView["X"] = loc.X;
                    rowView["Y"] = loc.Y;
                    rowView["Z"] = loc.Z;
                    rowView["regionID"] = loc.RegionID;

                    propertyGridArea.Refresh();
                }
            }
        }

        private void showOnMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DB.areaBinding.Current != null)
            {

                DataRowView rowView = (DataRowView)DB.areaBinding.Current;

                if (rowView["X"] != DBNull.Value && rowView["Y"] != DBNull.Value && rowView["regionID"] != DBNull.Value)
                {
                    Vector3 location = new Vector3();

                    location.X = (float)Convert.ToDouble(rowView["X"]);
                    location.Y = (float)Convert.ToDouble(rowView["Y"]);

                    int regionID = Convert.ToInt32(rowView["regionID"]);
                    QuestDesignerMain.DesignerForm.DXControl.ShowLocation(location, regionID);
                    QuestDesignerMain.DesignerForm.ShowTab("Map Editor");
                }
            }
        }
    }
}
