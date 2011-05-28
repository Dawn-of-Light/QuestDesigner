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
using DOL.GS.Behaviour;
using DOL.GS.PacketHandler;

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
			else if (description.StartsWith(Const.SELECTOR_QUESTTYPE))
				selector = new QuestSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_GAMELIVING) || description.StartsWith(Const.SELECTOR_GAMENPC))
				selector = new NPCSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_AREA))
				selector = new AreaSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_ITEM))
				selector = new ItemSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_WHIPSER))
				selector = new WhisperSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_REGION))
				selector = new RegionSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_ZONE))
				selector = new ZoneSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_TEXTTYPE))
				selector = new EnumerationSelector(id, param, typeof(eTextType).Name);
            else if (description.StartsWith(Const.SELECTOR_TEXT))
				selector = new TextSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_LOCATION))
				selector = new LocationSelector(id, param);
            else if (description.StartsWith(Const.SELECTOR_COMPARATOR))
				selector = new ComparatorSelector(id, param,comparatorType);
            else if (description.StartsWith(Const.SELECTOR_EMOTE))
				selector = new EnumerationSelector(id, param, typeof(eEmote).Name);
            else if (description.StartsWith(Const.SELECTOR_CHARACTERCLASS))
				selector = new EnumerationSelector(id, param, typeof(DOL.GS.eCharacterClass).Name);
			else
				selector = new BaseSelector(id, param);

			return selector;
		}
	}
}
