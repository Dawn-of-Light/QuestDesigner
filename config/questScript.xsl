<?xml version="1.0" encoding="iso-8859-1"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<xsl:for-each select="/Quest/Quest">	
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

/*
* Author:	<xsl:value-of select="Author"/>
* Date:		<xsl:value-of select="Date"/>
*
* Notes:
*  <xsl:value-of select="Description"/>
*/

using System;
using System.Reflection;
using DOL.GS.Database;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using DOL.GS.Quests;
using DOL.AI.Brain;

namespace <xsl:value-of select="Namespace"/> {

/* The first thing we do, is to declare the quest requirement
	 * class linked with the new Quest. To do this, we derive 
	 * from the abstract class AbstractQuestDescriptor
	 */
	public class <xsl:value-of select="Name"/>Descriptor : AbstractQuestDescriptor
	{
		/* This is the type of the quest class linked with 
		 * this requirement class, you must override the 
		 * base method like that
		 */
		public override Type LinkedQuestType
		{
			get { return typeof(<xsl:value-of select="Name"/>); }
		}

		/* This value is used to retrieves how many times the 
		 * player can do the quest. Override it only if you need, 
		 * the default value is 1
		 */
		public override int MaxQuestCount
		{
			get { return <xsl:value-of select="MaxQuestCount"/>; }
		}

		/* This value is used to retrieves the minimum level needed
		 *  to be able to make this quest. Override it only if you need, 
		 * the default value is 1
		 */
//		public override int MinLevel
//		{
//			get { return <xsl:value-of select="MinimumLevel"/>; }
//		}

		/* This value is used to retrieves how maximum level needed
		 * to be able to make this quest. Override it only if you need, 
		 * the default value is 50
		 */
		public override int MaxLevel
		{
			get { return <xsl:value-of select="MaximumLevel"/>; }
		}

		/* This method is used to know if the player is qualified to 
		 * do the quest. The base method always test his level and
		 * how many time the quest has been done. Override it only if 
		 * you want to add a custom test (here we test also the class name)
		 */
		public override bool CheckQuestQualification(GamePlayer player)
		{
			if(base.CheckQuestQualification(player) == false)
				return false;

			// if the player is already doing the quest his level is no longer of relevance
			if (player.IsDoingQuest(typeof (<xsl:value-of select="Name"/>)) != null)
				return true;

			return true;
		}
	}

     /* The second thing we do, is to declare the class we create
	 * as Quest. We must make it persistant using attributes, to
	 * do this, we derive from the abstract class AbstractQuest
	 */
	[NHibernate.Mapping.Attributes.Subclass(NameType=typeof(<xsl:value-of select="Name"/>), ExtendsType=typeof(AbstractQuest))]
	public class <xsl:value-of select="Name"/> : BaseQuest
	{
		/// <summary>
		/// Defines a logger for this class.
		///
		/// </summary>
		private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		/* Declare the variables we need inside our quest.
		* You can declare static variables here, which will be available in
		* ALL instance of your quest and should be initialized ONLY ONCE inside
		* the OnScriptLoaded method.
		*
		* Or declare nonstatic variables here which can be unique for each Player
		* and change through the quest journey...
		*
		*/

		protected const string questTitle = "<xsl:value-of select="Title"/>";

		<xsl:for-each select="/Quest/Mob">
		private static GameNPC <xsl:value-of select="ObjectName"/> = null;
		</xsl:for-each>
		<xsl:for-each select="/Quest/ItemTemplate">
		private static GenericItemTemplate <xsl:value-of select="ItemTemplateID"/> = null;
		</xsl:for-each>
		<xsl:for-each select="/Quest/Area">
		private static AbstractArea <xsl:value-of select="ObjectName"/> = null;
		</xsl:for-each>
		<xsl:for-each select="/Quest/Location">
		private static GameLocation <xsl:value-of select="ObjectName"/> = new GameLocation("<xsl:value-of select="Name"/>",<xsl:value-of select="RegionID"/>,<xsl:value-of select="X"/>,<xsl:value-of select="Y"/>,<xsl:value-of select="Z"/><xsl:if test="Heading">,<xsl:value-of select="Heading"/></xsl:if>);
		</xsl:for-each>

		// Custom Initialization Code Begin
		<xsl:value-of select="InitializationCode"/>
		// Custom Initialization Code End

		/* 
		* Constructor
		*/
		public <xsl:value-of select="Name"/>() : base()
		{
		}

		[ScriptLoadedEvent]
		public static void ScriptLoaded(DOLEvent e, object sender, EventArgs args)
		{
			if (log.IsInfoEnabled)
				log.Info("Quest \"" + questTitle + "\" initializing ...");

			#region defineNPCs
			GameNPC[] npcs;
		<xsl:for-each select="/Quest/Mob">
			npcs = WorldMgr.GetNPCsByName("<xsl:value-of select="Name"/>",(eRealm) <xsl:value-of select="Realm"/>);
			if (npcs.Length == 0)
			{
				<xsl:value-of select="ObjectName"/> = new <xsl:value-of select="ClassType"/>();
				<xsl:value-of select="ObjectName"/>.Model = <xsl:value-of select="Model"/>;
				<xsl:value-of select="ObjectName"/>.Name = "<xsl:value-of select="Name"/>";
				if (log.IsWarnEnabled)
					log.Warn("Could not find " + <xsl:value-of select="ObjectName"/>.Name + ", creating ...");
				<xsl:value-of select="ObjectName"/>.GuildName = "Part of " + questTitle + " Quest";
				<xsl:value-of select="ObjectName"/>.Realm = (byte) <xsl:value-of select="Realm"/>;
				<xsl:value-of select="ObjectName"/>.RegionId = <xsl:value-of select="Region"/>;
				<xsl:value-of select="ObjectName"/>.Size = <xsl:value-of select="Size"/>;
				<xsl:value-of select="ObjectName"/>.Level = <xsl:value-of select="Level"/>;
				<xsl:value-of select="ObjectName"/>.MaxSpeedBase = <xsl:value-of select="Speed"/>;
				<xsl:if test="MeleeDamageType"><xsl:value-of select="ObjectName"/>.MeleeDamageType = <xsl:value-of select="MeleeDamageType"/>;
				</xsl:if>
				<xsl:if test="FactionID"><xsl:value-of select="ObjectName"/>.Faction = FactionMgr.GetFactionByID(<xsl:value-of select="FactionID"/>);
				</xsl:if>
				<xsl:value-of select="ObjectName"/>.Position = new Point(<xsl:value-of select="X"/>, <xsl:value-of select="Y"/>, <xsl:value-of select="Z"/>);
				<xsl:value-of select="ObjectName"/>.Heading = <xsl:value-of select="Heading"/>;
				//<xsl:value-of select="ObjectName"/>.RespawnInterval = <xsl:value-of select="RespawnInterval"/>;
				<xsl:if test="MeleeDamageType"><xsl:value-of select="ObjectName"/>.EquipmentTemplateID = "<xsl:value-of select="EquipmentTemplateID"/>";
				</xsl:if>
				
				{
					StandardMobBrain brain = new StandardMobBrain();
					brain.AggroLevel = <xsl:value-of select="AggroLevel"/>;
					brain.AggroRange = <xsl:value-of select="AggroRange"/>;
					<xsl:value-of select="ObjectName"/>.SetOwnBrain(brain);
				}
				//You don't have to store the created mob in the db if you don't want,
				//it will be recreated each time it is not found, just comment the following
				//line if you rather not modify your database
				if (SAVE_INTO_DATABASE)
					<xsl:value-of select="ObjectName"/>.SaveIntoDatabase();
					
				<xsl:if test="AddToWorld='true'">	
				<xsl:value-of select="ObjectName"/>.AddToWorld();
				</xsl:if>
			}
			else 
			{
				<xsl:value-of select="ObjectName"/> = npcs[0];
			}
		</xsl:for-each>

			#endregion

			#region defineItems

		<xsl:for-each select="/Quest/ItemTemplate">
			<xsl:value-of select="ItemTemplateID"/> = (GenericItemTemplate) GameServer.Database.FindObjectByKey(typeof (GenericItemTemplate), "<xsl:value-of select="ItemTemplateID"/>");
			if (<xsl:value-of select="ItemTemplateID"/> == null)
			{
				<xsl:value-of select="ItemTemplateID"/> = new GenericItemTemplate();
				<xsl:value-of select="ItemTemplateID"/>.Name = "<xsl:value-of select="Name"/>";
				if (log.IsWarnEnabled)
					log.Warn("Could not find " + <xsl:value-of select="ItemTemplateID"/>.Name + ", creating it ...");
				<xsl:value-of select="ItemTemplateID"/>.Level = <xsl:value-of select="Level"/>;

				<xsl:value-of select="ItemTemplateID"/>.Weight = <xsl:value-of select="Weight"/>;
				<xsl:value-of select="ItemTemplateID"/>.Model = <xsl:value-of select="Model"/>;

				<xsl:value-of select="ItemTemplateID"/>.Object_Type = <xsl:value-of select="Object_Type"/>;
				<xsl:if test="Item_Type"><xsl:value-of select="ItemTemplateID"/>.Item_Type = <xsl:value-of select="Item_Type"/>;
				</xsl:if>
				<xsl:value-of select="ItemTemplateID"/>.ItemTemplateID = "<xsl:value-of select="ItemTemplateID"/>";
				<xsl:if test="Hand"><xsl:value-of select="ItemTemplateID"/>.Hand = <xsl:value-of select="Hand"/>;
				</xsl:if>
				<xsl:value-of select="ItemTemplateID"/>.Gold = <xsl:value-of select="Gold"/>;
				<xsl:value-of select="ItemTemplateID"/>.Silver = <xsl:value-of select="Silver"/>;
				<xsl:value-of select="ItemTemplateID"/>.Copper = <xsl:value-of select="Copper"/>;
				<xsl:value-of select="ItemTemplateID"/>.IsPickable = <xsl:value-of select="IsPickable"/>;
				<xsl:value-of select="ItemTemplateID"/>.IsDropable = <xsl:value-of select="IsDropable"/>;
				<xsl:if test="Color"><xsl:value-of select="ItemTemplateID"/>.Color = <xsl:value-of select="Color"/>;
				</xsl:if>
				<xsl:value-of select="ItemTemplateID"/>.Bonus = <xsl:value-of select="Bonus"/>; // default bonus				
				<xsl:if test="Bonus1">
				<xsl:value-of select="ItemTemplateID"/>.Bonus1 = <xsl:value-of select="Bonus1"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus1Type = (int) <xsl:value-of select="Bonus1Type"/>;
				</xsl:if>
				<xsl:if test="Bonus2">
				<xsl:value-of select="ItemTemplateID"/>.Bonus2 = <xsl:value-of select="Bonus2"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus2Type = (int) <xsl:value-of select="Bonus2Type"/>;
				</xsl:if>
				<xsl:if test="Bonus3">
				<xsl:value-of select="ItemTemplateID"/>.Bonus3 = <xsl:value-of select="Bonus3"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus3Type = (int) <xsl:value-of select="Bonus3Type"/>;
				</xsl:if>
				<xsl:if test="Bonus4">
				<xsl:value-of select="ItemTemplateID"/>.Bonus4 = <xsl:value-of select="Bonus4"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus4Type = (int) <xsl:value-of select="Bonus4Type"/>;
				</xsl:if>
				<xsl:if test="Bonus5">
				<xsl:value-of select="ItemTemplateID"/>.Bonus5 = <xsl:value-of select="Bonus5"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus5Type = (int) <xsl:value-of select="Bonus5Type"/>;
				</xsl:if>
				<xsl:if test="ExtraBonus">
				<xsl:value-of select="ItemTemplateID"/>.ExtraBonus = <xsl:value-of select="ExtraBonus"/>;
				<xsl:value-of select="ItemTemplateID"/>.ExtraBonusType = (int) <xsl:value-of select="ExtraBonusType"/>;
				</xsl:if>
				<xsl:if test="Effect"><xsl:value-of select="ItemTemplateID"/>.Effect = <xsl:value-of select="Effect"/>;
				</xsl:if>
				<xsl:if test="Emblem"><xsl:value-of select="ItemTemplateID"/>.Emblem = <xsl:value-of select="Embelm"/>;
				</xsl:if>				
				<xsl:if test="Charges"><xsl:value-of select="ItemTemplateID"/>.Charges = <xsl:value-of select="Charges"/>;
				</xsl:if>							
				<xsl:if test="MaxCharges"><xsl:value-of select="ItemTemplateID"/>.MaxCharges = <xsl:value-of select="MaxCharges"/>;
				</xsl:if>										
				<xsl:if test="SpellID"><xsl:value-of select="ItemTemplateID"/>.SpellID = <xsl:value-of select="SpellID"/>;
				</xsl:if>													
				<xsl:if test="ProcSpellID"><xsl:value-of select="ItemTemplateID"/>.ProcSpellID = <xsl:value-of select="ProcSpellID"/>;
				</xsl:if>																
				<xsl:if test="Type_Damage"><xsl:value-of select="ItemTemplateID"/>.Type_Damage = <xsl:value-of select="Type_Damage"/>;
				</xsl:if>							
				<xsl:if test="Realm"><xsl:value-of select="ItemTemplateID"/>.Realm = <xsl:value-of select="Realm"/>;
				</xsl:if>																
				<xsl:if test="MaxCount"><xsl:value-of select="ItemTemplateID"/>.MaxCount = <xsl:value-of select="MaxCount"/>;
				</xsl:if>																			
				<xsl:if test="PackSize"><xsl:value-of select="ItemTemplateID"/>.PackSize = <xsl:value-of select="PackSize"/>;
				</xsl:if>																			
				<xsl:if test="ModelExtension"><xsl:value-of select="ItemTemplateID"/>.ModelExtension = <xsl:value-of select="ModelExtension"/>;
				</xsl:if>																						
				<xsl:value-of select="ItemTemplateID"/>.Quality = <xsl:value-of select="Quality"/>;
				<xsl:value-of select="ItemTemplateID"/>.MaxQuality = <xsl:value-of select="MaxQuality"/>;
				<xsl:value-of select="ItemTemplateID"/>.Condition = <xsl:value-of select="Condition"/>;
				<xsl:value-of select="ItemTemplateID"/>.MaxCondition = <xsl:value-of select="MaxCondition"/>;
				<xsl:value-of select="ItemTemplateID"/>.Durability = <xsl:value-of select="Durability"/>;
				<xsl:value-of select="ItemTemplateID"/>.MaxDurability = <xsl:value-of select="MaxDurability"/>;

				//You don't have to store the created item in the db if you don't want,
				//it will be recreated each time it is not found, just comment the following
				//line if you rather not modify your database
				if (SAVE_INTO_DATABASE)
					GameServer.Database.AddNewObject(<xsl:value-of select="ItemTemplateID"/>);
			}
			</xsl:for-each>

			#endregion

			<xsl:for-each select="/Quest/Area">
				<xsl:if test="AreaType='Circle'">
				    <xsl:value-of select="ObjectName"/> = new <xsl:value-of select="AreaType"/>();
        			<xsl:value-of select="ObjectName"/>.Description = "<xsl:value-of select="Name"/>";
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).X = <xsl:value-of select="X"/>;
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).Y = <xsl:value-of select="Y"/>;
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).Radius = <xsl:value-of select="R"/>;
        			<xsl:value-of select="ObjectName"/>.RegionID = <xsl:value-of select="RegionID"/>;
        			AreaMgr.RegisterArea(<xsl:value-of select="ObjectName"/>);
				</xsl:if>
				<xsl:if test="AreaType='Square'">
				    <xsl:value-of select="ObjectName"/> = new <xsl:value-of select="AreaType"/>();
        			<xsl:value-of select="ObjectName"/>.Description = "<xsl:value-of select="Name"/>";
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).X = <xsl:value-of select="X"/>;
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).Y = <xsl:value-of select="Y"/>;
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).Width = <xsl:value-of select="Z"/>;
        			((<xsl:value-of select="AreaType"/>)<xsl:value-of select="ObjectName"/>).Height = <xsl:value-of select="R"/>;
        			<xsl:value-of select="ObjectName"/>.RegionID = <xsl:value-of select="RegionID"/>;
        			AreaMgr.RegisterArea(<xsl:value-of select="ObjectName"/>);
				</xsl:if>
			</xsl:for-each>
			#region defineQuestParts

			QuestBuilder builder = QuestMgr.getBuilder(typeof(<xsl:value-of select="Name"/>));
			BaseQuestPart a;
			<xsl:for-each select="/Quest/QuestPart">a = builder.CreateQuestPart();
				<xsl:for-each select="QuestPartTrigger">a.AddTrigger(<xsl:value-of select="TypeName"/><xsl:if test="Keyword">,<xsl:value-of select="Keyword"/></xsl:if><xsl:if test="Object">,<xsl:value-of select="Object"/></xsl:if>);
				</xsl:for-each>
				<xsl:for-each select="QuestPartRequirement">a.AddRequirement(<xsl:value-of select="TypeName"/><xsl:if test="N">,<xsl:value-of select="N"/></xsl:if><xsl:if test="V">,<xsl:value-of select="V"/></xsl:if><xsl:if test="Comparator">,(eComparator)<xsl:value-of select="Comparator"/></xsl:if>);
				</xsl:for-each>
				<xsl:for-each select="QuestPartAction">a.AddAction(<xsl:value-of select="TypeName"/><xsl:if test="P">,<xsl:value-of select="P"/></xsl:if><xsl:if test="Q">,<xsl:value-of select="Q"/></xsl:if>);
				</xsl:for-each>AddQuestPart(a);
			</xsl:for-each>
			#endregion

			// Custom Scriptloaded Code Begin
			<xsl:value-of select="ScriptLoadedCode"/>
			// Custom Scriptloaded Code End

            QuestMgr.AddQuestDescriptor(<xsl:value-of select="InvitingNPC"/>, typeof (<xsl:value-of select="Name"/>));

			if (log.IsInfoEnabled)
				log.Info("Quest \"" + questTitle + "\" initialized");
		}

		[ScriptUnloadedEvent]
		public static void ScriptUnloaded(DOLEvent e, object sender, EventArgs args)
		{
			// Custom Scriptunloaded Code Begin
			<xsl:value-of select="ScriptUnloadedCode"/>
			// Custom Scriptunloaded Code End

			<xsl:for-each select="/Quest/Area">
			AreaMgr.UnregisterArea(<xsl:value-of select="ObjectName"/>);
			</xsl:for-each>

			/* Now we remove to SirQuait the possibility to give this quest to players */
			QuestMgr.RemoveQuestDescriptor(<xsl:value-of select="InvitingNPC"/>, typeof (<xsl:value-of select="Name"/>));
		}

		/* Now we set the quest name.
		* If we don't override the base method, then the quest
		* will have the name "UNDEFINED QUEST NAME" and we don't
		* want that, do we? ;-)
		*/

		public override string Name
		{
			get { return questTitle; }
		}

		/* Now we set the quest step descriptions.
		* If we don't override the base method, then the quest
		* description for ALL steps will be "UNDEFINDED QUEST DESCRIPTION"
		* and this isn't something nice either ;-)
		*/
		public override string Description
		{
			get
			{
			switch (Step)
			{
				<xsl:for-each select="QuestStep">
					case <xsl:value-of select="Step"/>:
						return "[Step #<xsl:value-of select="Step"/>] <xsl:value-of select="Description"/>";
				</xsl:for-each>
					default:
						return " No Queststep Description available.";
				}				
			}
		}

		public override void AbortQuest()
		{
			base.AbortQuest(); //Defined in Quest, changes the state, stores in DB etc ...
		}

		public override void FinishQuest()
		{
			base.FinishQuest(); //Defined in Quest, changes the state, stores in DB etc ...
		}
	}
}
</xsl:for-each>	
</xsl:template>
</xsl:stylesheet>
