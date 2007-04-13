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
using System.Data;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;
using DOL.GS;
using DOL.Tools.Mapping;

namespace DOL.Tools.QuestDesigner
{
	public partial class PositionConverter : UserControl
	{

        private ClipboardLocation loc = new ClipboardLocation(0,0,1);

        private bool disableEvents = false;

		public PositionConverter()
		{
			InitializeComponent();            
		}

		private void PositionConverter_Load(object sender, EventArgs e)
		{
            
            comboBoxRegion.DisplayMember = DB.COL_REGION_DESCRIPTION;
            comboBoxRegion.ValueMember = DB.COL_REGION_ID;
            comboBoxRegion.DataSource = DB.regionBinding;


            comboBoxZone.DisplayMember = DB.COL_ZONE_DESCRIPTION;
            comboBoxZone.ValueMember = DB.COL_ZONE_ID;
            comboBoxZone.DataSource = DB.zoneBinding;

            if (comboBoxRegion.SelectedValue is int)
            {
                DB.zoneBinding.Filter = DB.COL_ZONE_REGIONID+ "=" + comboBoxRegion.SelectedValue;
                loc.RegionID = Convert.ToInt32(comboBoxRegion.SelectedValue);
            }

            loc.X = Convert.ToInt32(regionX.Value);
            loc.Y = Convert.ToInt32(regionY.Value);
            loc.Z = Convert.ToInt32(regionZ.Value);
		}

		private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (disableEvents)
                return;

			if (comboBoxRegion.SelectedValue is int) {
				DB.zoneBinding.Filter = DB.COL_ZONE_REGIONID+ "=" + comboBoxRegion.SelectedValue;
                loc.RegionID = Convert.ToInt32(comboBoxRegion.SelectedValue);
			}
		}
	
		private void position_ValueChanged(object sender, EventArgs e)
		{
            if (disableEvents)
                return;

			if (comboBoxZone.SelectedItem != null)
			{
                disableEvents = true;

				DataRowView zoneRow = (DataRowView)comboBoxZone.SelectedItem;

				Point3D local = new Point3D(Convert.ToInt32(zoneX.Value), Convert.ToInt32(zoneY.Value), Convert.ToInt32(zoneZ.Value));
                Point3D global = Utils.ConvertZonePointToRegion((int)zoneRow[DB.COL_ZONE_ID], local);

                loc.X = global.X;
                loc.Y = global.Y;
                loc.Z = global.Z;

				regionX.Value = global.X;
				regionY.Value = global.Y;

                if (cbComputeZ.Checked)
                {
                    updateZ();
                }
                else
                {
                    regionZ.Value = global.Z;
                }

                disableEvents = false;
			}
		}

        private void cbComputeZ_CheckedChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            updateZ();            
        }

        private void regionY_ValueChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            loc.Y = Convert.ToInt32(regionY.Value);

            if (loc.ZoneID >= 0 && !String.IsNullOrEmpty(comboBoxZone.ValueMember))
            {
                disableEvents = true;

                comboBoxZone.SelectedValue = loc.ZoneID;
                zoneY.Value = loc.LocalY;

                disableEvents = false;
            }
            updateZ();
        }

        private void regionX_ValueChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            loc.X = Convert.ToInt32(regionX.Value);
            if (loc.ZoneID >= 0 && !String.IsNullOrEmpty(comboBoxZone.ValueMember))
            {
                disableEvents = true;

                comboBoxZone.SelectedValue = loc.ZoneID;
                zoneX.Value = loc.LocalX;

                disableEvents = false;
            }
            updateZ();
        }

        private void regionZ_ValueChanged(object sender, EventArgs e)
        {
            if (disableEvents)
                return;

            loc.Z = Convert.ToInt32(regionZ.Value);
            disableEvents = true;
            zoneZ.Value = loc.Z;
            disableEvents = false;

            updateZ();
        }

        private void updateZ()
        {
            if (cbComputeZ.Checked && loc.ZoneID >=0)
            {
                loc.Z = DAoCMapping.GetZByZoneLocs(loc.X, loc.Y, loc.ZoneID);
                disableEvents = true;
                zoneZ.Value = loc.Z;
                regionZ.Value = loc.Z;
                disableEvents = false;
            }
        }
	}
}