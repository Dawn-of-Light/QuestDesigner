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
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Configuration;

namespace DOL.Tools.QuestDesigner
{
	public partial class AboutBox : NETXP.Forms.About
	{
		public AboutBox()
		{
			InitializeComponent();

			foreach (Assembly s in AppDomain.CurrentDomain.GetAssemblies())
			{
				string[] lvsi = new string[3];
				lvsi[0] = s.GetName().Name;
				lvsi[1] = s.GetName().FullName;
				lvsi[2] = s.GetName().Version.ToString();
				ListViewItem lvi = new ListViewItem(lvsi, 0);
				this.ListOfAssemblies.Items.Add(lvi);
			}

			AssemblyCopyrightAttribute objCopyright = AssemblyCopyrightAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute;
			AssemblyDescriptionAttribute objDescription = AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute)) as AssemblyDescriptionAttribute;
			AssemblyCompanyAttribute objCompany = AssemblyCompanyAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute;
			AssemblyTrademarkAttribute objTrademark = AssemblyTrademarkAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyTrademarkAttribute)) as AssemblyTrademarkAttribute;
			AssemblyProductAttribute objProduct = AssemblyProductAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute)) as AssemblyProductAttribute;
			AssemblyTitleAttribute objTitle = AssemblyTitleAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
			GuidAttribute objGuid = GuidAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(GuidAttribute)) as GuidAttribute;
			DebuggableAttribute objDebuggable = DebuggableAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(DebuggableAttribute)) as DebuggableAttribute;
			CLSCompliantAttribute objCLSCompliant = CLSCompliantAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(CLSCompliantAttribute)) as CLSCompliantAttribute;

			AppName.Text = objProduct.Product;
			BigTitle.Text = objTitle.Title;
			ProdVer.Text = QuestDesignerMain.Version;
			AppDesc.Text = objDescription.Description;
			CopyrightLabel.Text = objCopyright.Copyright;
			SerialNo.Text = objGuid.Value;
			Company.Text = objCompany.Company;

		}

		private void LookForUpdatesLink_Click(object sender, EventArgs e)
		{            
			string targetURL = System.Configuration.ConfigurationManager.AppSettings["UpdateUrl"];
			System.Diagnostics.Process.Start(targetURL);
		}

		private void ProdInfoLink_Click(object sender, EventArgs e)
		{
            string targetURL = System.Configuration.ConfigurationManager.AppSettings["InfoUrl"];
			System.Diagnostics.Process.Start(targetURL);
		}
		
	}
}

