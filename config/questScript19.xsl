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
using DOL.Database;
using DOL.Events;
using DOL.GS.PacketHandler;
using log4net;
using DOL.GS.Quests;
using DOL.GS.Behaviour;
using DOL.GS.Behaviour.Attributes;
using DOL.AI.Brain;

	namespace <xsl:value-of select="Namespace"/> {
	
     /* The first thing we do, is to declare the class we create
	 * as Quest. To do this, we derive from the abstract class
	 * BaseQuest	  	 
	 */
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

		protected const int minimumLevel = <xsl:value-of select="MinimumLevel"/>;
		protected const int maximumLevel = <xsl:value-of select="MaximumLevel"/>;
	 
            public override int Level
		    {
	                get { return <xsl:value-of select="MinimumLevel"/>; }
		    }

	<xsl:for-each select="/Quest/Mob">
		private static GameNPC <xsl:value-of select="ObjectName"/> = null;
		</xsl:for-each>
		<xsl:for-each select="/Quest/ItemTemplate">
		private static ItemTemplate <xsl:value-of select="ItemTemplateID"/> = null;
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

		public <xsl:value-of select="Name"/>(GamePlayer questingPlayer) : this(questingPlayer, 1)
		{
		}

		public <xsl:value-of select="Name"/>(GamePlayer questingPlayer, int step) : base(questingPlayer, step)
		{
		}

		public <xsl:value-of select="Name"/>(GamePlayer questingPlayer, DBQuest dbQuest) : base(questingPlayer, dbQuest)
	{
	}

	[ScriptLoadedEvent]
	public static void ScriptLoaded(DOLEvent e, object sender, EventArgs args)
	{
	if (!ServerProperties.Properties.LOAD_QUESTS)
		return;
	if (log.IsInfoEnabled)
		log.Info("Quest \"" + questTitle + "\" initializing ...");

	#region defineNPCs
	GameNPC[] npcs;
	<xsl:for-each select="/Quest/Mob">
			npcs = WorldMgr.GetNPCsByName("<xsl:value-of select="Name"/>",(eRealm) <xsl:value-of select="Realm"/>);
			if (npcs.Length == 0)
			{
				if (!WorldMgr.GetRegion(<xsl:value-of select="Region"/>).IsDisabled)
				{
				<xsl:choose>
					<xsl:when test="NPCTemplateID!='-1'">
						<xsl:value-of select="ObjectName"/> = new <xsl:value-of select="ClassType"/>(NPCTemplateMgr.GetTemplate(<xsl:value-of select="NPCTemplateID"/>));
					</xsl:when>			
					<xsl:otherwise>
						<xsl:value-of select="ObjectName"/> = new <xsl:value-of select="ClassType"/>();
					</xsl:otherwise>		
				</xsl:choose>
				<xsl:value-of select="ObjectName"/>.Model = <xsl:value-of select="Model"/>;
				<xsl:value-of select="ObjectName"/>.Name = "<xsl:value-of select="Name"/>";
				if (log.IsWarnEnabled)
					log.Warn("Could not find " + <xsl:value-of select="ObjectName"/>.Name + ", creating ...");
				<xsl:value-of select="ObjectName"/>.Realm = (eRealm) <xsl:value-of select="Realm"/>;
				<xsl:value-of select="ObjectName"/>.CurrentRegionID = <xsl:value-of select="Region"/>;
				<xsl:value-of select="ObjectName"/>.Size = <xsl:value-of select="Size"/>;
				<xsl:value-of select="ObjectName"/>.Level = <xsl:value-of select="Level"/>;
				<xsl:value-of select="ObjectName"/>.MaxSpeedBase = <xsl:value-of select="Speed"/>;
				<xsl:if test="MeleeDamageType"><xsl:value-of select="ObjectName"/>.MeleeDamageType = <xsl:value-of select="MeleeDamageType"/>;
				</xsl:if>
				<xsl:if test="FactionID"><xsl:value-of select="ObjectName"/>.Faction = FactionMgr.GetFactionByID(<xsl:value-of select="FactionID"/>);
				</xsl:if>				
				<xsl:value-of select="ObjectName"/>.X = <xsl:value-of select="X"/>;
				<xsl:value-of select="ObjectName"/>.Y = <xsl:value-of select="Y"/>;
				<xsl:value-of select="ObjectName"/>.Z = <xsl:value-of select="Z"/>;
				<xsl:value-of select="ObjectName"/>.Heading = <xsl:value-of select="Heading"/>;
				<xsl:value-of select="ObjectName"/>.RespawnInterval = <xsl:value-of select="RespawnInterval"/>;
				<xsl:value-of select="ObjectName"/>.Flags = <xsl:value-of select="Flags"/>;
/*				ToDo:
*				export EquipmentTemplate
*/				
				
				<xsl:if test="MeleeDamageType"><xsl:value-of select="ObjectName"/>.EquipmentTemplateID = "<xsl:value-of select="EquipmentTemplateID"/>";
				</xsl:if>
				<xsl:if test="BodyType"><xsl:value-of select="ObjectName"/>.BodyType = <xsl:value-of select="BodyType"/>;
				</xsl:if>

				StandardMobBrain brain = new StandardMobBrain();
				brain.AggroLevel = <xsl:value-of select="AggroLevel"/>;
				brain.AggroRange = <xsl:value-of select="AggroRange"/>;
				<xsl:value-of select="ObjectName"/>.SetOwnBrain(brain);
				
				//You don't have to store the created mob in the db if you don't want,
				//it will be recreated each time it is not found, just comment the following
				//line if you rather not modify your database
				if (SAVE_INTO_DATABASE)
					<xsl:value-of select="ObjectName"/>.SaveIntoDatabase();
					
				<xsl:if test="AddToWorld='true'">	
				<xsl:value-of select="ObjectName"/>.AddToWorld();
				</xsl:if>
				}
			}
			else 
			{
				<xsl:value-of select="ObjectName"/> = npcs[0];
			}
		</xsl:for-each>

			#endregion

			#region defineItems

		<xsl:for-each select="/Quest/ItemTemplate">
			<xsl:value-of select="ItemTemplateID"/> = (ItemTemplate) GameServer.Database.FindObjectByKey(typeof (ItemTemplate), "<xsl:value-of select="ItemTemplateID"/>");
			if (<xsl:value-of select="ItemTemplateID"/> == null)
			{
				<xsl:value-of select="ItemTemplateID"/> = new ItemTemplate();
				<xsl:value-of select="ItemTemplateID"/>.Name = "<xsl:value-of select="Name"/>";
				if (log.IsWarnEnabled)
					log.Warn("Could not find " + <xsl:value-of select="ItemTemplateID"/>.Name + ", creating it ...");
				<xsl:value-of select="ItemTemplateID"/>.Level = <xsl:value-of select="Level"/>;
				<xsl:value-of select="ItemTemplateID"/>.Weight = <xsl:value-of select="Weight"/>;
				<xsl:value-of select="ItemTemplateID"/>.Model = <xsl:value-of select="Model"/>;
				<xsl:value-of select="ItemTemplateID"/>.Object_Type = <xsl:value-of select="Object_Type"/>;
				<xsl:if test="Item_Type"><xsl:value-of select="ItemTemplateID"/>.Item_Type = <xsl:value-of select="Item_Type"/>;
				</xsl:if>
				<xsl:value-of select="ItemTemplateID"/>.Id_nb = "<xsl:value-of select="ItemTemplateID"/>";
				<xsl:if test="Hand"><xsl:value-of select="ItemTemplateID"/>.Hand = <xsl:value-of select="Hand"/>;
				</xsl:if>
				<xsl:if test="Platinum"><xsl:value-of select="ItemTemplateID"/>.Platinum = <xsl:value-of select="Platinum"/>;
				</xsl:if>
				<xsl:value-of select="ItemTemplateID"/>.Gold = <xsl:value-of select="Gold"/>;
				<xsl:value-of select="ItemTemplateID"/>.Silver = <xsl:value-of select="Silver"/>;
				<xsl:value-of select="ItemTemplateID"/>.Copper = <xsl:value-of select="Copper"/>;
				<xsl:value-of select="ItemTemplateID"/>.IsPickable = <xsl:value-of select="IsPickable"/>;
				<xsl:value-of select="ItemTemplateID"/>.IsDropable = <xsl:value-of select="IsDropable"/>;
				<xsl:if test="IsTradable"><xsl:value-of select="ItemTemplateID"/>.IsTradable = <xsl:value-of select="IsTradable"/>;
				</xsl:if>
				<xsl:if test="CanDropAsLoot"><xsl:value-of select="ItemTemplateID"/>.CanDropAsLoot = <xsl:value-of select="CanDropAsLoot"/>;
				</xsl:if>
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
				<xsl:if test="Bonus6">
				<xsl:value-of select="ItemTemplateID"/>.Bonus6 = <xsl:value-of select="Bonus6"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus6Type = (int) <xsl:value-of select="Bonus6Type"/>;
				</xsl:if>
				<xsl:if test="Bonus7">
				<xsl:value-of select="ItemTemplateID"/>.Bonus7 = <xsl:value-of select="Bonus7"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus7Type = (int) <xsl:value-of select="Bonus7Type"/>;
				</xsl:if>
				<xsl:if test="Bonus8">
				<xsl:value-of select="ItemTemplateID"/>.Bonus8 = <xsl:value-of select="Bonus8"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus8Type = (int) <xsl:value-of select="Bonus8Type"/>;
				</xsl:if>
				<xsl:if test="Bonus9">
				<xsl:value-of select="ItemTemplateID"/>.Bonus9 = <xsl:value-of select="Bonus9"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus9Type = (int) <xsl:value-of select="Bonus9Type"/>;
				</xsl:if>
				<xsl:if test="Bonus10">
				<xsl:value-of select="ItemTemplateID"/>.Bonus10 = <xsl:value-of select="Bonus10"/>;
				<xsl:value-of select="ItemTemplateID"/>.Bonus10Type = (int) <xsl:value-of select="Bonus10Type"/>;
				</xsl:if>
				<xsl:if test="ExtraBonus">
				<xsl:value-of select="ItemTemplateID"/>.ExtraBonus = <xsl:value-of select="ExtraBonus"/>;
				<xsl:value-of select="ItemTemplateID"/>.ExtraBonusType = (int) <xsl:value-of select="ExtraBonusType"/>;
				</xsl:if>
				<xsl:if test="Effect"><xsl:value-of select="ItemTemplateID"/>.Effect = <xsl:value-of select="Effect"/>;
				</xsl:if>
				<xsl:if test="Emblem"><xsl:value-of select="ItemTemplateID"/>.Emblem = <xsl:value-of select="Emblem"/>;
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
				<xsl:if test="Extension"><xsl:value-of select="ItemTemplateID"/>.Extension = <xsl:value-of select="Extension"/>;
				</xsl:if>																						
				<xsl:value-of select="ItemTemplateID"/>.Quality = <xsl:value-of select="Quality"/>;				
				<xsl:value-of select="ItemTemplateID"/>.Condition = <xsl:value-of select="Condition"/>;
				<xsl:value-of select="ItemTemplateID"/>.MaxCondition = <xsl:value-of select="MaxCondition"/>;
				<xsl:value-of select="ItemTemplateID"/>.Durability = <xsl:value-of select="Durability"/>;
				<xsl:value-of select="ItemTemplateID"/>.MaxDurability = <xsl:value-of select="MaxDurability"/>;
				<xsl:if test="PoisonCharges"><xsl:value-of select="ItemTemplateID"/>.PoisonCharges = <xsl:value-of select="PoisonCharges"/>;
				</xsl:if>
				<xsl:if test="PoisonMaxCharges"><xsl:value-of select="ItemTemplateID"/>.PoisonMaxCharges = <xsl:value-of select="PoisonMaxCharges"/>;
				</xsl:if>
				<xsl:if test="PoisonSpellID"><xsl:value-of select="ItemTemplateID"/>.PoisonSpellID = <xsl:value-of select="PoisonSpellID"/>;
				</xsl:if>
				<xsl:if test="ProcSpellID1"><xsl:value-of select="ItemTemplateID"/>.ProcSpellID1 = <xsl:value-of select="ProcSpellID1"/>;
				</xsl:if>
				<xsl:if test="SpellID1"><xsl:value-of select="ItemTemplateID"/>.SpellID1 = <xsl:value-of select="SpellID1"/>;
				</xsl:if>
				<xsl:if test="MaxCharges1"><xsl:value-of select="ItemTemplateID"/>.MaxCharges1 = <xsl:value-of select="MaxCharges1"/>;
				</xsl:if>
				<xsl:if test="Charges1"><xsl:value-of select="ItemTemplateID"/>.Charges1 = <xsl:value-of select="Charges1"/>;
				</xsl:if>
				//You don't have to store the created item in the db if you don't want,
				//it will be recreated each time it is not found, just comment the following
				//line if you rather not modify your database
				if (SAVE_INTO_DATABASE)
					GameServer.Database.AddNewObject(<xsl:value-of select="ItemTemplateID"/>);
				}
			</xsl:for-each>

			#endregion

			#region defineAreas
			<xsl:for-each select="/Quest/Area">
				if (!WorldMgr.GetRegion(<xsl:value-of select="RegionID"/>).IsDisabled)
				{
					<xsl:choose>
					<xsl:when test="AreaType='BindArea'">
						BindPoint <xsl:value-of select="ObjectName"/>BindPoint = new BindPoint();
						<xsl:value-of select="ObjectName"/>BindPoint.Radius = (ushort)<xsl:value-of select="R"/>;
						<xsl:value-of select="ObjectName"/>BindPoint.X = <xsl:value-of select="X"/>;
						<xsl:value-of select="ObjectName"/>BindPoint.Y = <xsl:value-of select="Y"/>;
						<xsl:value-of select="ObjectName"/>BindPoint.Z = <xsl:value-of select="Z"/>;
						<xsl:value-of select="ObjectName"/>BindPoint.Region = <xsl:value-of select="RegionID"/>;
						<xsl:value-of select="ObjectName"/> = new Area.BindArea("<xsl:value-of select="Name"/>",<xsl:value-of select="ObjectName"/>BindPoint);
					</xsl:when>
					<xsl:otherwise>						
						<xsl:value-of select="ObjectName"/> = new Area.<xsl:value-of select="AreaType"/>("<xsl:value-of select="Name"/>",<xsl:value-of select="X"/>,<xsl:value-of select="Y"/>,<xsl:value-of select="Z"/>,<xsl:value-of select="R"/>);											
					</xsl:otherwise>
				</xsl:choose>
				<xsl:if test="Sound">
					<xsl:value-of select="ObjectName"/>.Sound = (byte)<xsl:value-of select="Sound"/>;
				</xsl:if>
				<xsl:if test="IsSafeArea">
					<xsl:value-of select="ObjectName"/>.IsSafeArea = <xsl:value-of select="IsSafeArea"/>;
				</xsl:if>
				<xsl:if test="CanBroadcast">
					<xsl:value-of select="ObjectName"/>.CanBroadcast = <xsl:value-of select="CanBroadcast"/>;
				</xsl:if>
				<xsl:if test="DisplayMessage">
					<xsl:value-of select="ObjectName"/>.DisplayMessage = <xsl:value-of select="DisplayMessage"/>;
				</xsl:if>
				<xsl:if test="CheckLOS">
					<xsl:value-of select="ObjectName"/>.CheckLOS = <xsl:value-of select="CheckLOS"/>;
				</xsl:if>
				Region <xsl:value-of select="ObjectName"/>Region = WorldMgr.GetRegion(<xsl:value-of select="RegionID"/>);
				if (<xsl:value-of select="ObjectName"/>Region != null)
					<xsl:value-of select="ObjectName"/>Region.AddArea(<xsl:value-of select="ObjectName"/>);
				}
		</xsl:for-each>
		#endregion
		
		#region defineQuestParts

		QuestBuilder builder = QuestMgr.getBuilder(typeof(<xsl:value-of select="Name"/>));
			QuestBehaviour a;
			<xsl:for-each select="/Quest/QuestPart"><xsl:sort select="Position" order="ascending" data-type="number"/>a = builder.CreateBehaviour(<xsl:value-of select="defaultNPC"/>,<xsl:value-of select="MaxExecutions"/>);
				<xsl:for-each select="QuestPartTrigger">a.AddTrigger(<xsl:value-of select="TypeName"/>,<xsl:value-of disable-output-escaping="yes" select="K"/>,<xsl:value-of disable-output-escaping="yes" select="I"/>);
			</xsl:for-each>
			<xsl:for-each select="QuestPartRequirement">a.AddRequirement(<xsl:value-of select="TypeName"/>,<xsl:value-of disable-output-escaping="yes" select="N"/>,<xsl:value-of disable-output-escaping="yes" select="V"/><xsl:if test="Comparator">,(eComparator)<xsl:value-of select="Comparator"/></xsl:if>);
			</xsl:for-each>
			<xsl:for-each select="QuestPartAction">a.AddAction(<xsl:value-of select="TypeName"/>,<xsl:value-of disable-output-escaping="yes" select="P"/>,<xsl:value-of disable-output-escaping="yes" select="Q"/>);
			</xsl:for-each>AddBehaviour(a);
			</xsl:for-each>
			#endregion

			// Custom Scriptloaded Code Begin
			<xsl:value-of select="ScriptLoadedCode"/>
			// Custom Scriptloaded Code End
			if (<xsl:value-of select="InvitingNPC"/>!=null) {
				<xsl:value-of select="InvitingNPC"/>.AddQuestToGive(typeof (<xsl:value-of select="Name"/>));
			}
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
				if (<xsl:value-of select="ObjectName"/>!=null) {
					Region <xsl:value-of select="ObjectName"/>Region = WorldMgr.GetRegion(<xsl:value-of select="RegionID"/>);
					if (<xsl:value-of select="ObjectName"/>Region != null)
						<xsl:value-of select="ObjectName"/>Region.RemoveArea(<xsl:value-of select="ObjectName"/>);
				}
			</xsl:for-each>

			/* If <xsl:value-of select="InvitingNPC"/> has not been initialized, then we don't have to remove any
			 * hooks from him ;-)
			 */
			if (<xsl:value-of select="InvitingNPC"/> == null)
				return;
			/* Now we remove the possibility to give this quest to players */			
			<xsl:value-of select="InvitingNPC"/>.RemoveQuestToGive(typeof (<xsl:value-of select="Name"/>));
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
				<xsl:for-each select="/Quest/QuestStep">
					case <xsl:value-of select="Step"/>:
						return "<xsl:value-of select="Description"/>";
				</xsl:for-each>
					default:
						return " No Queststep Description available.";
				}				
			}
		}
		
		/// <summary>
		/// This method checks if a player is qualified for this quest
		/// </summary>
		/// <returns>true if qualified, false if not</returns>
		public override bool CheckQuestQualification(GamePlayer player)
		{		
			// if the player is already doing the quest his level is no longer of relevance
			if (player.IsDoingQuest(typeof (<xsl:value-of select="Name"/>)) != null)
				return true;
				
			// Custom Code Begin
			<xsl:value-of select="CheckQuestQualificationCode"/>
			// Custom  Code End
			
		<xsl:text disable-output-escaping="yes">
			if (player.Level &gt; maximumLevel || player.Level &lt; minimumLevel )
				return false;
		</xsl:text>

		<xsl:if test="/Quest/QuestCharacterClass">
			if (
		<xsl:for-each select="/Quest/QuestCharacterClass">
			player.CharacterClass.ID != (byte) eCharacterClass.<xsl:value-of select="Description"/> <xsl:text disable-output-escaping="yes"> &amp;&amp; </xsl:text>		
		</xsl:for-each>
				true) {
				return false;			
			}
		</xsl:if>
			return true;
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
