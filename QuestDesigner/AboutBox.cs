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

namespace QuestDesigner
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
			ProdVer.Text = Application.ProductVersion;
			AppDesc.Text = objDescription.Description;
			CopyrightLabel.Text = objCopyright.Copyright;
			SerialNo.Text = objGuid.Value;
			Company.Text = objCompany.Company;

		}

		private void LookForUpdatesLink_Click(object sender, EventArgs e)
		{
			string targetURL = "http://dol.psykonikcorp.net:8080/display/Tools/Quest+Designer";
			System.Diagnostics.Process.Start(targetURL);
		}

		private void ProdInfoLink_Click(object sender, EventArgs e)
		{
			string targetURL = "http://dol.psykonikcorp.net:8080/display/Tools/Quest+Designer";
			System.Diagnostics.Process.Start(targetURL);
		}
		
	}
}

