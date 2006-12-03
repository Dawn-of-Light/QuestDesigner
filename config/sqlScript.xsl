<?xml version="1.0" encoding="iso-8859-1"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<xsl:for-each select="/Quest/Mob">
		insert into TABLE_MOB values("<xsl:value-of select="Name"/>",<xsl:value-of select="Realm"/>,
		<xsl:value-of select="ClassType"/>,<xsl:value-of select="Model"/>
		<xsl:value-of select="Realm"/>,
		<xsl:value-of select="Region"/>,
		<xsl:value-of select="Size"/>,
		<xsl:value-of select="Level"/>,
		<xsl:value-of select="Speed"/>,
		<xsl:value-of select="MeleeDamageType"/>,
		<xsl:value-of select="FactionID"/>,
		<xsl:value-of select="X"/>,
		<xsl:value-of select="Y"/>,
		<xsl:value-of select="Z"/>,
		<xsl:value-of select="Heading"/>,
		<xsl:value-of select="RespawnInterval"/>,
		<xsl:value-of select="EquipmentTemplateID"/>,
		<xsl:value-of select="AggroLevel"/>,
		<xsl:value-of select="AggroRange"/>
		);
	</xsl:for-each>



	<xsl:for-each select="/Quest/ItemTemplate">
				  insert into TABLE_ITEM_TEMPLATE values(<xsl:value-of select="ItemTemplateID"/>,
				  <xsl:value-of select="Name"/>,
  				  <xsl:value-of select="Level"/>,
  				  <xsl:value-of select="Weight"/>,
					<xsl:value-of select="Model"/>,
					<xsl:value-of select="Object_Type"/>,
					<xsl:value-of select="Item_Type"/>,
					<xsl:value-of select="Hand"/>,
					<xsl:value-of select="Gold"/>,
					<xsl:value-of select="Silver"/>,
					<xsl:value-of select="Copper"/>,
					<xsl:value-of select="IsPickable"/>,
					<xsl:value-of select="IsDropable"/>,
					<xsl:value-of select="Color"/>,
					<xsl:value-of select="Bonus"/>,
					<xsl:value-of select="Bonus1"/>,
					<xsl:value-of select="Bonus1Type"/>,
					<xsl:value-of select="Bonus2"/>,
					<xsl:value-of select="Bonus2Type"/>,
					<xsl:value-of select="Bonus3"/>,
					<xsl:value-of select="Bonus3Type"/>,
					<xsl:value-of select="Bonus4"/>,
					<xsl:value-of select="Bonus4Type"/>;,
					<xsl:value-of select="Bonus5"/>,
					<xsl:value-of select="Bonus5Type"/>,
					<xsl:value-of select="ExtraBonus"/>,
					<xsl:value-of select="ExtraBonusType"/>,
					 <xsl:value-of select="Effect"/>,
					  <xsl:value-of select="Emblem"/>,
					  <xsl:value-of select="Charges"/>,
					  <xsl:value-of select="MaxCharges"/>,
					   <xsl:value-of select="SpellID"/>,
					    <xsl:value-of select="ProcSpellID"/>,
						 <xsl:value-of select="Type_Damage"/>,
						  <xsl:value-of select="Realm"/>,
						   <xsl:value-of select="MaxCount"/>,
						   <xsl:value-of select="PackSize"/>,
						    <xsl:value-of select="ModelExtension"/>;,
							<xsl:value-of select="Quality"/>,
							 <xsl:value-of select="MaxQuality"/>,
							  <xsl:value-of select="Condition"/>,
							   <xsl:value-of select="MaxCondition"/>,
							    <xsl:value-of select="Durability"/>,
								 <xsl:value-of select="MaxDurability"/>;
 		);
		</xsl:for-each>

		<!--

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
		-->
</xsl:template>
</xsl:stylesheet>
