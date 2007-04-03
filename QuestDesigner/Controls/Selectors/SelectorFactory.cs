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
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using DOL.Tools.QuestDesigner.Util;

namespace DOL.Tools.QuestDesigner.Controls
{
	class SelectorFactory
	{
        public static ISelector GetSelector(string description, int id, char param)
        {
            return GetSelector(description, id, param,null);
        }

		public static ISelector GetSelector(string description, int id, char param,string comparatorType)
		{
			ISelector selector;

			if (param == Const.CODE_COMPARATOR)
				selector = new ComparatorSelector(id, param,comparatorType);
			else if (description.StartsWith("QuestType"))
				selector = new QuestSelector(id, param);
			else if (description.StartsWith("GameLiving"))
				selector = new NPCSelector(id, param);
			else if (description.StartsWith("Area"))
				selector = new AreaSelector(id, param);
			else if (description.StartsWith("Item"))
				selector = new ItemSelector(id, param);
			else if (description.StartsWith("Whisper"))
				selector = new WhisperSelector(id, param);
			else if (description.StartsWith("Region"))
				selector = new RegionSelector(id, param);
			else if (description.StartsWith("Zone"))
				selector = new ZoneSelector(id, param);
			else if (description.StartsWith("TextType"))
				selector = new EnumerationSelector(id, param, typeof(DOL.GS.Quests.eTextType).Name);
			else if (description.StartsWith("Text"))
				selector = new TextSelector(id, param);
			else if (description.StartsWith("Location"))
				selector = new LocationSelector(id, param);			
			else if (description.StartsWith("Comparator"))
				selector = new ComparatorSelector(id, param,comparatorType);
			else if (description.StartsWith("Emote"))
				selector = new EnumerationSelector(id, param, typeof(DOL.GS.PacketHandler.eEmote).Name);
			else if (description.StartsWith("CharacterClass"))
				selector = new EnumerationSelector(id, param, typeof(DOL.GS.eCharacterClass).Name);
			else
				selector = new BaseSelector(id, param);

			return selector;
		}
	}
}
