using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;
using DOL.GS;

namespace QuestDesigner
{
	public partial class PositionConverter : UserControl
	{
		public PositionConverter()
		{
			InitializeComponent();			
		}

		private void PositionConverter_Load(object sender, EventArgs e)
		{
			comboBoxRegion.DataSource = DB.RegionTable;
			comboBoxRegion.DisplayMember = "description";
			comboBoxRegion.ValueMember = "id";

			comboBoxZone.DataSource = DB.zoneBinding;
			comboBoxZone.DisplayMember = "description";
			comboBoxZone.ValueMember = "zoneID";
		}

		private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxRegion.SelectedValue is int) {
				DB.zoneBinding.Filter = "regionID=" + comboBoxRegion.SelectedValue;
			}
		}		
	
		private void position_ValueChanged(object sender, EventArgs e)
		{
			if (comboBoxZone.SelectedItem != null)
			{
				DataRowView zoneRow = (DataRowView)comboBoxZone.SelectedItem;

				Point3D local = new Point3D(Convert.ToInt32(zoneX.Value), Convert.ToInt32(zoneY.Value), Convert.ToInt32(zoneZ.Value));
				Point3D global = Utils.ConvertZonePointToRegion((int)zoneRow["zoneID"],local);

				regionX.Value = global.X;
				regionY.Value = global.Y;
				regionZ.Value = global.Z;
			}
		}

			
	}
}