using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace QuestDesigner.Util
{
	class Log
	{
		public static void Info(string msg)
		{
			ShowMessage(msg, global::QuestDesigner.Properties.Resources.info);
		}

		public static void Warning(string msg)
		{
			ShowMessage(msg, global::QuestDesigner.Properties.Resources.warning);
		}

		public static void Error(string msg)
		{
			ShowMessage(msg, global::QuestDesigner.Properties.Resources.error);
		}

		public static void ShowMessage(string msg, Icon ico)
		{
			ShowMessage(msg, ico.ToBitmap());
		}

		public static void ShowMessage(string msg, Image img)
		{
			QuestDesignerMain.DesignerForm.StatusLabel.Text = msg;
			QuestDesignerMain.DesignerForm.StatusIcon.Image = img;
		}
	}
}
