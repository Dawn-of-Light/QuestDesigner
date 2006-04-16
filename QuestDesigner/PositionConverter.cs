using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DOL.GS;
using QuestDesigner.Util;

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
			comboBoxRegion.DataSource = DB.regionTable;
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

				Point local = new Point(Convert.ToInt32(zoneX.Value), Convert.ToInt32(zoneY.Value), Convert.ToInt32(zoneZ.Value));
				Point global = Utils.ConvertZonePointToRegion((int)zoneRow["zoneID"],local);

				regionX.Value = global.X;
				regionY.Value = global.Y;
				regionZ.Value = global.Z;
			}
		}

			
	}
}