using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuestDesigner
{
	public partial class CustomCode : UserControl
	{

		DataTable questTable;

		public CustomCode()
		{
			InitializeComponent();
		}

		public void setDataSet(DataSet questData)
		{
			questTable = questData.Tables["Quest"];

			this.textBoxLoadedCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.ScriptLoadedCode", true));
			this.textBoxUnloadedCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.ScriptUnloadedCode", true));
			this.textBoxInitCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", questData, "Quest.InitializationCode", true));
		}
	}
}
