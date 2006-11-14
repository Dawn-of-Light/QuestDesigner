using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using QuestDesigner.Util;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace QuestDesigner.Controls
{
	[SelectorAttribute("Whisper")]
	public class WhisperSelector : BaseSelector
	{

		private static char[] WHISPER_TRIMS = new char[] { '[', ']' };		

		public WhisperSelector(int itemID, char param): base(itemID,param)
		{			
			this.list.Items.AddRange(GetWhisperKeywords());
		}

		public static string[] GetWhisperKeywords()
		{
			ArrayList keywords = new ArrayList();
			foreach (DataRow row in DB.QuestPartTable.Rows)
			{
				if (row["Message"] is string && ((string)row["Message"]).Contains("["))
				{
					MatchCollection matches = Regex.Matches((string)row["Message"], "\\[(.)*\\]", RegexOptions.Compiled);
					foreach (Match match in matches)
					{
						keywords.Add(match.Value.Trim(WHISPER_TRIMS));
					}
				}
			}
			return (string[])keywords.ToArray(typeof(string));
		}

		protected override System.Drawing.Image getImage(int index)
		{
			return global::QuestDesigner.Properties.Resources.info;
		}
		
	}
}
