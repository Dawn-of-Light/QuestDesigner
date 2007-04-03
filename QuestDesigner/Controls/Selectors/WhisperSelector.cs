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
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace DOL.Tools.QuestDesigner.Controls
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
			foreach (DataRow row in DB.ActionTable.Rows)
			{
                if (row[Const.ACTION_P] is string && ((string)row[Const.ACTION_P]).Contains("["))
				{
                    MatchCollection matches = Regex.Matches((string)row[Const.ACTION_P], "\\[(.)*\\]", RegexOptions.Compiled);
					foreach (Match match in matches)
					{
						keywords.Add(match.Value.Trim(WHISPER_TRIMS));
					}
				}

                if (row[Const.ACTION_Q] is string && ((string)row[Const.ACTION_Q]).Contains("["))
                {
                    MatchCollection matches = Regex.Matches((string)row[Const.ACTION_Q], "\\[(.)*\\]", RegexOptions.Compiled);
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
			return global::DOL.Tools.QuestDesigner.Properties.Resources.info;
		}
		
	}
}
