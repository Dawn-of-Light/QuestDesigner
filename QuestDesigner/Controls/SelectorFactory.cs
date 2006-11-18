using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using QuestDesigner.Util;

namespace QuestDesigner.Controls
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
