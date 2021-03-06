namespace DOL.Tools.QuestDesigner
{
    partial class QuestDesignerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Data.DataColumn dataColumnQuestPartIF;
            System.Data.DataColumn dataColumnTriggerQuestPart;
            System.Data.DataColumn dataColumnTriggerType;
            System.Data.DataColumn dataColumnTriggerKeyword;
            System.Data.DataColumn dataColumnTriggerObject;
            System.Data.DataColumn dataColumnQuestTriggerID;
            System.Data.DataColumn datacolumnquestPartID;
            System.Data.DataColumn dataColumnRequirmentType;
            System.Data.DataColumn dataColumnRequirmeentN;
            System.Data.DataColumn dataColumnRequirementV;
            System.Data.DataColumn dataColumnRequirementComparator;
            System.Data.DataColumn dataColumnRequirementID;
            System.Data.DataColumn dataColumnActionQuestPartID;
            System.Data.DataColumn dataColumnActionType;
            System.Data.DataColumn dataColumnActionP;
            System.Data.DataColumn dataColumnActionQ;
            System.Data.DataColumn dataColumn1;
            System.Data.DataColumn dataColumnRegionID;
            System.Data.DataColumn dataColumnRegionDescription;
            System.Data.DataColumn dataColumnZoneID;
            System.Data.DataColumn dataColumnZoneRegionID;
            System.Data.DataColumn dataColumnZoneDescription;
            System.Data.DataColumn dataColumnZoneOffsetY;
            System.Data.DataColumn dataColumnZoneOffsetX;
            System.Data.DataColumn dataColumn15;
            System.Data.DataColumn dataColumn16;
            System.Data.DataColumn dataColumn17;
            System.Data.DataColumn dataColumn18;
            System.Data.DataColumn dataColumn19;
            System.Data.DataColumn dataColumn20;
            System.Data.DataColumn dataColumn21;
            System.Data.DataColumn dataColumn22;
            System.Data.DataColumn dataColumnText;
            System.Data.DataColumn dataColumnDefaultNPC;
            System.Data.DataColumn dataColumn28;
            System.Data.DataColumn dataColumn32;
            System.Data.DataColumn dataColumn23;
            System.Data.DataTable dataTableQuestCharacterClass;
            System.Data.DataColumn dataColumnCharacterClass;
            System.Data.DataColumn dataColumnDescription;
            System.Data.DataColumn dataColumnGold;
            System.Data.DataColumn dataColumnSilver;
            System.Data.DataColumn dataColumnCopper;
            System.Data.DataColumn dataColumnEmblem;
            System.Data.DataColumn dataColumnEffect;
            System.Data.DataColumn dataColumnExtension;
            System.Data.DataColumn dataColumn73;
            System.Data.DataColumn dataColumnPackSize;
            System.Data.DataColumn dataColumnCharges;
            System.Data.DataColumn dataColumnMaxCount;
            System.Data.DataColumn dataColumnSpellID;
            System.Data.DataColumn dataColumnProcSpellID;
            System.Data.DataColumn dataColumnPoisonCharges;
            System.Data.DataColumn dataColumnPoisonMaxCharges;
            System.Data.DataColumn dataColumnPoisonSpellID;
            System.Data.DataColumn dataColumnProcSpellID1;
            System.Data.DataColumn dataColumnSpellID1;
            System.Data.DataColumn dataColumnMaxCharges1;
            System.Data.DataColumn dataColumnCharges1;
            System.Data.DataColumn dataColumnIsTradable;
            System.Data.DataColumn dataColumnCanDropAsLoot;
            System.Data.DataColumn dataColumnBonus6Type;
            System.Data.DataColumn dataColumnBonus6;
            System.Data.DataColumn dataColumnBonus7Type;
            System.Data.DataColumn dataColumnBonus7;
            System.Data.DataColumn dataColumnBonus8Type;
            System.Data.DataColumn dataColumnBonus8;
            System.Data.DataColumn dataColumnBonus9Type;
            System.Data.DataColumn dataColumnBonus9;
            System.Data.DataColumn dataColumnBonus10Type;
            System.Data.DataColumn dataColumnBonus10;
            System.Data.DataColumn dataColumn59;
            System.Data.DataColumn dataColumn66;
            System.Data.DataColumn dataColumnPlatinum;
            System.Data.DataColumn dataColumnQuestDate;
            System.Data.DataColumn dataColumn26;
            System.Data.DataColumn dataColumn33;
            System.Data.DataColumn dataColumn34;
            System.Data.DataColumn dataColumn35;
            System.Data.DataColumn dataColumnQuestID;
            System.Data.DataColumn dataColumnQuestName;
            System.Data.DataColumn dataColumnQuestAuthor;
            System.Data.DataColumn dataColumnQuestVersion;
            System.Data.DataColumn dataColumnQuestDescription;
            System.Data.DataColumn dataColumn14;
            System.Data.DataColumn dataColumnMinimumLevel;
            System.Data.DataColumn dataColumnMaximumLevel;
            System.Data.DataColumn dataColumnInvintingNPC;
            System.Data.DataColumn dataColumn41;
            System.Data.DataColumn dataColumn62;
            System.Data.DataColumn dataColumn63;
            System.Data.DataColumn dataColumn64;
            System.Data.DataColumn dataColumn65;
            System.Data.DataColumn dataColumn36;
            System.Data.DataColumn dataColumn37;
            System.Data.DataColumn dataColumn39;
            System.Data.DataColumn dataColumn40;
            System.Data.DataColumn dataColumn42;
            System.Data.DataColumn dataColumn43;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestDesignerForm));
            NETXP.Controls.Docking.Renderers.Office2003 office20031 = new NETXP.Controls.Docking.Renderers.Office2003();
            NETXP.Library.DynamicColorTable dynamicColorTable1 = new NETXP.Library.DynamicColorTable();
            NETXP.Library.DynamicColorTable dynamicColorTable2 = new NETXP.Library.DynamicColorTable();
            this.toolStripContainerForm = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tabControlMain = new NETXP.Controls.Docking.TabControl();
            this.tabPageQuest = new NETXP.Controls.Docking.TabPage();
            this.questInfo = new DOL.Tools.QuestDesigner.QuestInfo();
            this.tabPageNPC = new NETXP.Controls.Docking.TabPage();
            this.npcView = new DOL.Tools.QuestDesigner.NPC();
            this.tabPageItem = new NETXP.Controls.Docking.TabPage();
            this.itemView = new DOL.Tools.QuestDesigner.Item();
            this.tabPageQuestPart = new NETXP.Controls.Docking.TabPage();
            this.questPartItems = new DOL.Tools.QuestDesigner.QuestPartItems();
            this.tabPageArea = new NETXP.Controls.Docking.TabPage();
            this.areaView = new DOL.Tools.QuestDesigner.Area();
            this.tabPageLocation = new NETXP.Controls.Docking.TabPage();
            this.locationView = new DOL.Tools.QuestDesigner.Location();
            this.tabPageCode = new NETXP.Controls.Docking.TabPage();
            this.customCode = new DOL.Tools.QuestDesigner.CustomCode();
            this.tabPageMap = new NETXP.Controls.Docking.TabPage();
            this.DXControl = new DOL.Tools.Mapping.Forms.DXControl();
            this.tabPageWeb = new NETXP.Controls.Docking.TabPage();
            this.webBrowser1 = new DOL.Tools.QuestDesigner.QuestDesigner.WebBrowser();
            this.xpTaskPane = new NETXP.Controls.TaskPane.XPTaskPane();
            this.xpTGQuestPart = new NETXP.Controls.TaskPane.XPTaskPaneGroup();
            this.xpTGActions = new NETXP.Controls.TaskPane.XPTaskPaneGroup();
            this.linkLabelNewQuest = new System.Windows.Forms.LinkLabel();
            this.linkSaveQuest = new System.Windows.Forms.LinkLabel();
            this.linkLoadQuest = new System.Windows.Forms.LinkLabel();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTaskPane = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionConverterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetQuest = new System.Data.DataSet();
            this.dataTableQuestPart = new System.Data.DataTable();
            this.dataColumn38 = new System.Data.DataColumn();
            this.dataTableTrigger = new System.Data.DataTable();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataTableRequirement = new System.Data.DataTable();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataTableAction = new System.Data.DataTable();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataTableQuest = new System.Data.DataTable();
            this.dataTableMob = new System.Data.DataTable();
            this.dataColumnName = new System.Data.DataColumn();
            this.dataColumnModel = new System.Data.DataColumn();
            this.dataColumnGuildName = new System.Data.DataColumn();
            this.dataColumnLevel = new System.Data.DataColumn();
            this.dataColumnX = new System.Data.DataColumn();
            this.dataColumnY = new System.Data.DataColumn();
            this.dataColumnZ = new System.Data.DataColumn();
            this.dataColumnRegion = new System.Data.DataColumn();
            this.dataColumnMobID = new System.Data.DataColumn();
            this.dataColumnClassType = new System.Data.DataColumn();
            this.dataColumnSpeed = new System.Data.DataColumn();
            this.dataColumnHeading = new System.Data.DataColumn();
            this.dataColumnSize = new System.Data.DataColumn();
            this.dataColumnEquipmentTemplateID = new System.Data.DataColumn();
            this.dataColumnFlags = new System.Data.DataColumn();
            this.dataColumnAggroLevel = new System.Data.DataColumn();
            this.dataColumnAggroRange = new System.Data.DataColumn();
            this.dataColumnMobRealm = new System.Data.DataColumn();
            this.dataColumnMobRespawnInterval = new System.Data.DataColumn();
            this.dataColumnMobFactionID = new System.Data.DataColumn();
            this.dataColumnMobMeleeDamageType = new System.Data.DataColumn();
            this.dataColumnMobItemsListTemplateID = new System.Data.DataColumn();
            this.dataColumnAddToworld = new System.Data.DataColumn();
            this.dataColumnObjectName = new System.Data.DataColumn();
            this.dataTableItemTemplate = new System.Data.DataTable();
            this.dataColumnIdNb = new System.Data.DataColumn();
            this.dataColumnItemName = new System.Data.DataColumn();
            this.dataColumnItemLevel = new System.Data.DataColumn();
            this.dataColumnDurability = new System.Data.DataColumn();
            this.dataColumnMaxDurability = new System.Data.DataColumn();
            this.dataColumnCondition = new System.Data.DataColumn();
            this.dataColumnMaxcondition = new System.Data.DataColumn();
            this.dataColumnQuality = new System.Data.DataColumn();
            this.dataColumnDPS_AF = new System.Data.DataColumn();
            this.dataColumnSPD_ABS = new System.Data.DataColumn();
            this.dataColumnHand = new System.Data.DataColumn();
            this.dataColumnTypeDamage = new System.Data.DataColumn();
            this.dataColumnObjectType = new System.Data.DataColumn();
            this.dataColumnItemType = new System.Data.DataColumn();
            this.dataColumnWeight = new System.Data.DataColumn();
            this.dataColumnItemModel = new System.Data.DataColumn();
            this.dataColumnRealm = new System.Data.DataColumn();
            this.dataColumnIsPickable = new System.Data.DataColumn();
            this.dataColumnIsDropable = new System.Data.DataColumn();
            this.dataColumnBonus = new System.Data.DataColumn();
            this.dataColumnBonus1 = new System.Data.DataColumn();
            this.dataColumnBonus1Type = new System.Data.DataColumn();
            this.dataColumnBonus2 = new System.Data.DataColumn();
            this.dataColumnBonus2Type = new System.Data.DataColumn();
            this.dataColumnBonus3 = new System.Data.DataColumn();
            this.dataColumnBonus3Type = new System.Data.DataColumn();
            this.dataColumnBonus4 = new System.Data.DataColumn();
            this.dataColumnBonus4Type = new System.Data.DataColumn();
            this.dataColumnBonus5 = new System.Data.DataColumn();
            this.dataColumnBonus5Type = new System.Data.DataColumn();
            this.dataColumnExtraBonus = new System.Data.DataColumn();
            this.dataColumnExtraBonusType = new System.Data.DataColumn();
            this.dataColumnColor = new System.Data.DataColumn();
            this.dataTableQuestStep = new System.Data.DataTable();
            this.dataColumnStep = new System.Data.DataColumn();
            this.dataColumnStepDescription = new System.Data.DataColumn();
            this.dataTableArea = new System.Data.DataTable();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn44 = new System.Data.DataColumn();
            this.dataTableLocation = new System.Data.DataTable();
            this.dataSetData = new System.Data.DataSet();
            this.dataTableRegion = new System.Data.DataTable();
            this.dataTableZone = new System.Data.DataTable();
            this.dataTableTriggerType = new System.Data.DataTable();
            this.dataColumnTriggerTypeValue = new System.Data.DataColumn();
            this.dataColumnTriggerTypeDescription = new System.Data.DataColumn();
            this.dataColumnTriggerTypeHelp = new System.Data.DataColumn();
            this.dataColumnTriggerTypeK = new System.Data.DataColumn();
            this.dataColumnTriggerTypeI = new System.Data.DataColumn();
            this.dataColumnTriggerTypeID = new System.Data.DataColumn();
            this.dataTableActionType = new System.Data.DataTable();
            this.dataColumnActionTypeValue = new System.Data.DataColumn();
            this.dataColumnActionTypeDescription = new System.Data.DataColumn();
            this.dataColumnActionTypeHelp = new System.Data.DataColumn();
            this.dataColumnActionTypeP = new System.Data.DataColumn();
            this.dataColumnActionTypeQ = new System.Data.DataColumn();
            this.dataColumnActionTypeID = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataTableRequirementType = new System.Data.DataTable();
            this.dataColumnRequirementTypeValue = new System.Data.DataColumn();
            this.dataColumnRequirementTypeDescription = new System.Data.DataColumn();
            this.dataColumnRequirementTypeHelp = new System.Data.DataColumn();
            this.dataColumnRequirementTypeN = new System.Data.DataColumn();
            this.dataColumnRequirementTypeV = new System.Data.DataColumn();
            this.dataColumnRequirementTypeID = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataTableeEnumeration = new System.Data.DataTable();
            this.dataColumnEnumerationType = new System.Data.DataColumn();
            this.dataColumnEnumerationValue = new System.Data.DataColumn();
            this.dataColumnEnumerationName = new System.Data.DataColumn();
            this.dataColumnEnumerationDescription = new System.Data.DataColumn();
            this.dataColumnRealmValue = new System.Data.DataColumn();
            this.dataColumnRealmDescription = new System.Data.DataColumn();
            this.dataColumnTextTypeValue = new System.Data.DataColumn();
            this.dataColumnTextTypeDescription = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn54 = new System.Data.DataColumn();
            this.dataColumn55 = new System.Data.DataColumn();
            this.dataColumn56 = new System.Data.DataColumn();
            this.dataColumn57 = new System.Data.DataColumn();
            this.dataColumn60 = new System.Data.DataColumn();
            this.dataColumn61 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.saveQuestDialog = new System.Windows.Forms.SaveFileDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.openQuestDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveScriptDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            dataColumnQuestPartIF = new System.Data.DataColumn();
            dataColumnTriggerQuestPart = new System.Data.DataColumn();
            dataColumnTriggerType = new System.Data.DataColumn();
            dataColumnTriggerKeyword = new System.Data.DataColumn();
            dataColumnTriggerObject = new System.Data.DataColumn();
            dataColumnQuestTriggerID = new System.Data.DataColumn();
            datacolumnquestPartID = new System.Data.DataColumn();
            dataColumnRequirmentType = new System.Data.DataColumn();
            dataColumnRequirmeentN = new System.Data.DataColumn();
            dataColumnRequirementV = new System.Data.DataColumn();
            dataColumnRequirementComparator = new System.Data.DataColumn();
            dataColumnRequirementID = new System.Data.DataColumn();
            dataColumnActionQuestPartID = new System.Data.DataColumn();
            dataColumnActionType = new System.Data.DataColumn();
            dataColumnActionP = new System.Data.DataColumn();
            dataColumnActionQ = new System.Data.DataColumn();
            dataColumn1 = new System.Data.DataColumn();
            dataColumnRegionID = new System.Data.DataColumn();
            dataColumnRegionDescription = new System.Data.DataColumn();
            dataColumnZoneID = new System.Data.DataColumn();
            dataColumnZoneRegionID = new System.Data.DataColumn();
            dataColumnZoneDescription = new System.Data.DataColumn();
            dataColumnZoneOffsetY = new System.Data.DataColumn();
            dataColumnZoneOffsetX = new System.Data.DataColumn();
            dataColumn15 = new System.Data.DataColumn();
            dataColumn16 = new System.Data.DataColumn();
            dataColumn17 = new System.Data.DataColumn();
            dataColumn18 = new System.Data.DataColumn();
            dataColumn19 = new System.Data.DataColumn();
            dataColumn20 = new System.Data.DataColumn();
            dataColumn21 = new System.Data.DataColumn();
            dataColumn22 = new System.Data.DataColumn();
            dataColumnText = new System.Data.DataColumn();
            dataColumnDefaultNPC = new System.Data.DataColumn();
            dataColumn28 = new System.Data.DataColumn();
            dataColumn32 = new System.Data.DataColumn();
            dataColumn23 = new System.Data.DataColumn();
            dataTableQuestCharacterClass = new System.Data.DataTable();
            dataColumnCharacterClass = new System.Data.DataColumn();
            dataColumnDescription = new System.Data.DataColumn();
            dataColumnGold = new System.Data.DataColumn();
            dataColumnSilver = new System.Data.DataColumn();
            dataColumnCopper = new System.Data.DataColumn();
            dataColumnEmblem = new System.Data.DataColumn();
            dataColumnEffect = new System.Data.DataColumn();
            dataColumnExtension = new System.Data.DataColumn();
            dataColumn73 = new System.Data.DataColumn();
            dataColumnPackSize = new System.Data.DataColumn();
            dataColumnCharges = new System.Data.DataColumn();
            dataColumnMaxCount = new System.Data.DataColumn();
            dataColumnSpellID = new System.Data.DataColumn();
            dataColumnProcSpellID = new System.Data.DataColumn();
            dataColumnPoisonCharges = new System.Data.DataColumn();
            dataColumnPoisonMaxCharges = new System.Data.DataColumn();
            dataColumnPoisonSpellID = new System.Data.DataColumn();
            dataColumnProcSpellID1 = new System.Data.DataColumn();
            dataColumnSpellID1 = new System.Data.DataColumn();
            dataColumnMaxCharges1 = new System.Data.DataColumn();
            dataColumnCharges1 = new System.Data.DataColumn();
            dataColumnIsTradable = new System.Data.DataColumn();
            dataColumnCanDropAsLoot = new System.Data.DataColumn();
            dataColumnBonus6Type = new System.Data.DataColumn();
            dataColumnBonus6 = new System.Data.DataColumn();
            dataColumnBonus7Type = new System.Data.DataColumn();
            dataColumnBonus7 = new System.Data.DataColumn();
            dataColumnBonus8Type = new System.Data.DataColumn();
            dataColumnBonus8 = new System.Data.DataColumn();
            dataColumnBonus9Type = new System.Data.DataColumn();
            dataColumnBonus9 = new System.Data.DataColumn();
            dataColumnBonus10Type = new System.Data.DataColumn();
            dataColumnBonus10 = new System.Data.DataColumn();
            dataColumn59 = new System.Data.DataColumn();
            dataColumn66 = new System.Data.DataColumn();
            dataColumnPlatinum = new System.Data.DataColumn();
            dataColumnQuestDate = new System.Data.DataColumn();
            dataColumn26 = new System.Data.DataColumn();
            dataColumn33 = new System.Data.DataColumn();
            dataColumn34 = new System.Data.DataColumn();
            dataColumn35 = new System.Data.DataColumn();
            dataColumnQuestID = new System.Data.DataColumn();
            dataColumnQuestName = new System.Data.DataColumn();
            dataColumnQuestAuthor = new System.Data.DataColumn();
            dataColumnQuestVersion = new System.Data.DataColumn();
            dataColumnQuestDescription = new System.Data.DataColumn();
            dataColumn14 = new System.Data.DataColumn();
            dataColumnMinimumLevel = new System.Data.DataColumn();
            dataColumnMaximumLevel = new System.Data.DataColumn();
            dataColumnInvintingNPC = new System.Data.DataColumn();
            dataColumn41 = new System.Data.DataColumn();
            dataColumn62 = new System.Data.DataColumn();
            dataColumn63 = new System.Data.DataColumn();
            dataColumn64 = new System.Data.DataColumn();
            dataColumn65 = new System.Data.DataColumn();
            dataColumn36 = new System.Data.DataColumn();
            dataColumn37 = new System.Data.DataColumn();
            dataColumn39 = new System.Data.DataColumn();
            dataColumn40 = new System.Data.DataColumn();
            dataColumn42 = new System.Data.DataColumn();
            dataColumn43 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(dataTableQuestCharacterClass)).BeginInit();
            this.toolStripContainerForm.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainerForm.ContentPanel.SuspendLayout();
            this.toolStripContainerForm.TopToolStripPanel.SuspendLayout();
            this.toolStripContainerForm.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageQuest.SuspendLayout();
            this.tabPageNPC.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.tabPageQuestPart.SuspendLayout();
            this.tabPageArea.SuspendLayout();
            this.tabPageLocation.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.tabPageMap.SuspendLayout();
            this.tabPageWeb.SuspendLayout();
            this.xpTaskPane.SuspendLayout();
            this.xpTGActions.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuestPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTrigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRequirement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableMob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableItemTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuestStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTriggerType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableActionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRequirementType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableeEnumeration)).BeginInit();
            this.SuspendLayout();
            // 
            // dataColumnQuestPartIF
            // 
            dataColumnQuestPartIF.AllowDBNull = false;
            dataColumnQuestPartIF.AutoIncrement = true;
            dataColumnQuestPartIF.ColumnName = "ID";
            dataColumnQuestPartIF.DataType = typeof(int);
            // 
            // dataColumnTriggerQuestPart
            // 
            dataColumnTriggerQuestPart.ColumnName = "QuestPartID";
            dataColumnTriggerQuestPart.DataType = typeof(int);
            // 
            // dataColumnTriggerType
            // 
            dataColumnTriggerType.ColumnName = "Type";
            dataColumnTriggerType.DataType = typeof(int);
            // 
            // dataColumnTriggerKeyword
            // 
            dataColumnTriggerKeyword.ColumnName = "K";
            // 
            // dataColumnTriggerObject
            // 
            dataColumnTriggerObject.ColumnName = "I";
            // 
            // dataColumnQuestTriggerID
            // 
            dataColumnQuestTriggerID.AllowDBNull = false;
            dataColumnQuestTriggerID.AutoIncrement = true;
            dataColumnQuestTriggerID.ColumnName = "ID";
            dataColumnQuestTriggerID.DataType = typeof(int);
            // 
            // datacolumnquestPartID
            // 
            datacolumnquestPartID.ColumnName = "QuestPartID";
            datacolumnquestPartID.DataType = typeof(int);
            // 
            // dataColumnRequirmentType
            // 
            dataColumnRequirmentType.ColumnName = "Type";
            dataColumnRequirmentType.DataType = typeof(int);
            // 
            // dataColumnRequirmeentN
            // 
            dataColumnRequirmeentN.ColumnName = "N";
            // 
            // dataColumnRequirementV
            // 
            dataColumnRequirementV.ColumnName = "V";
            // 
            // dataColumnRequirementComparator
            // 
            dataColumnRequirementComparator.ColumnName = "Comparator";
            dataColumnRequirementComparator.DataType = typeof(int);
            // 
            // dataColumnRequirementID
            // 
            dataColumnRequirementID.AllowDBNull = false;
            dataColumnRequirementID.AutoIncrement = true;
            dataColumnRequirementID.ColumnName = "ID";
            dataColumnRequirementID.DataType = typeof(int);
            // 
            // dataColumnActionQuestPartID
            // 
            dataColumnActionQuestPartID.ColumnName = "QuestPartID";
            dataColumnActionQuestPartID.DataType = typeof(int);
            // 
            // dataColumnActionType
            // 
            dataColumnActionType.ColumnName = "Type";
            dataColumnActionType.DataType = typeof(int);
            // 
            // dataColumnActionP
            // 
            dataColumnActionP.ColumnName = "P";
            // 
            // dataColumnActionQ
            // 
            dataColumnActionQ.ColumnName = "Q";
            // 
            // dataColumn1
            // 
            dataColumn1.AllowDBNull = false;
            dataColumn1.AutoIncrement = true;
            dataColumn1.ColumnName = "ID";
            dataColumn1.DataType = typeof(int);
            // 
            // dataColumnRegionID
            // 
            dataColumnRegionID.ColumnName = "id";
            dataColumnRegionID.DataType = typeof(int);
            // 
            // dataColumnRegionDescription
            // 
            dataColumnRegionDescription.ColumnName = "description";
            // 
            // dataColumnZoneID
            // 
            dataColumnZoneID.ColumnName = "zoneID";
            dataColumnZoneID.DataType = typeof(int);
            // 
            // dataColumnZoneRegionID
            // 
            dataColumnZoneRegionID.ColumnName = "regionID";
            dataColumnZoneRegionID.DataType = typeof(int);
            // 
            // dataColumnZoneDescription
            // 
            dataColumnZoneDescription.ColumnName = "description";
            // 
            // dataColumnZoneOffsetY
            // 
            dataColumnZoneOffsetY.ColumnName = "offsety";
            dataColumnZoneOffsetY.DataType = typeof(int);
            // 
            // dataColumnZoneOffsetX
            // 
            dataColumnZoneOffsetX.ColumnName = "offsetx";
            dataColumnZoneOffsetX.DataType = typeof(int);
            // 
            // dataColumn15
            // 
            dataColumn15.AutoIncrement = true;
            dataColumn15.ColumnName = "ID";
            dataColumn15.DataType = typeof(int);
            // 
            // dataColumn16
            // 
            dataColumn16.ColumnName = "Name";
            // 
            // dataColumn17
            // 
            dataColumn17.Caption = "Region";
            dataColumn17.ColumnName = "RegionID";
            dataColumn17.DataType = typeof(int);
            // 
            // dataColumn18
            // 
            dataColumn18.AllowDBNull = false;
            dataColumn18.ColumnName = "X";
            dataColumn18.DataType = typeof(int);
            dataColumn18.DefaultValue = 0;
            // 
            // dataColumn19
            // 
            dataColumn19.AllowDBNull = false;
            dataColumn19.ColumnName = "Y";
            dataColumn19.DataType = typeof(int);
            dataColumn19.DefaultValue = 0;
            // 
            // dataColumn20
            // 
            dataColumn20.AllowDBNull = false;
            dataColumn20.ColumnName = "Z";
            dataColumn20.DataType = typeof(int);
            dataColumn20.DefaultValue = 0;
            // 
            // dataColumn21
            // 
            dataColumn21.AllowDBNull = false;
            dataColumn21.ColumnName = "Heading";
            dataColumn21.DataType = typeof(int);
            dataColumn21.DefaultValue = 0;
            // 
            // dataColumn22
            // 
            dataColumn22.ColumnName = "ObjectName";
            // 
            // dataColumnText
            // 
            dataColumnText.Caption = "Text";
            dataColumnText.ColumnName = "text";
            dataColumnText.DefaultValue = "";
            // 
            // dataColumnDefaultNPC
            // 
            dataColumnDefaultNPC.ColumnName = "defaultNPC";
            // 
            // dataColumn28
            // 
            dataColumn28.ColumnName = "width";
            dataColumn28.DataType = typeof(int);
            // 
            // dataColumn32
            // 
            dataColumn32.ColumnName = "height";
            dataColumn32.DataType = typeof(int);
            // 
            // dataColumn23
            // 
            dataColumn23.AllowDBNull = false;
            dataColumn23.AutoIncrement = true;
            dataColumn23.ColumnName = "Position";
            dataColumn23.DataType = typeof(int);
            // 
            // dataTableQuestCharacterClass
            // 
            dataTableQuestCharacterClass.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnCharacterClass,
            dataColumnDescription});
            dataTableQuestCharacterClass.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Value"}, true)});
            dataTableQuestCharacterClass.MinimumCapacity = 5;
            dataTableQuestCharacterClass.PrimaryKey = new System.Data.DataColumn[] {
        dataColumnCharacterClass};
            dataTableQuestCharacterClass.TableName = "QuestCharacterClass";
            // 
            // dataColumnCharacterClass
            // 
            dataColumnCharacterClass.AllowDBNull = false;
            dataColumnCharacterClass.ColumnName = "Value";
            dataColumnCharacterClass.DataType = typeof(int);
            // 
            // dataColumnDescription
            // 
            dataColumnDescription.ColumnName = "Description";
            // 
            // dataColumnGold
            // 
            dataColumnGold.ColumnName = "Gold";
            dataColumnGold.DataType = typeof(short);
            dataColumnGold.DefaultValue = ((short)(0));
            // 
            // dataColumnSilver
            // 
            dataColumnSilver.ColumnName = "Silver";
            dataColumnSilver.DataType = typeof(byte);
            dataColumnSilver.DefaultValue = ((byte)(0));
            // 
            // dataColumnCopper
            // 
            dataColumnCopper.ColumnName = "Copper";
            dataColumnCopper.DataType = typeof(byte);
            dataColumnCopper.DefaultValue = ((byte)(0));
            // 
            // dataColumnEmblem
            // 
            dataColumnEmblem.ColumnName = "Emblem";
            dataColumnEmblem.DataType = typeof(int);
            dataColumnEmblem.DefaultValue = 0;
            // 
            // dataColumnEffect
            // 
            dataColumnEffect.ColumnName = "Effect";
            dataColumnEffect.DataType = typeof(int);
            dataColumnEffect.DefaultValue = 0;
            // 
            // dataColumnExtension
            // 
            dataColumnExtension.Caption = "Extension";
            dataColumnExtension.ColumnName = "Extension";
            dataColumnExtension.DataType = typeof(byte);
            dataColumnExtension.DefaultValue = ((byte)(0));
            // 
            // dataColumn73
            // 
            dataColumn73.ColumnName = "MaxCount";
            dataColumn73.DataType = typeof(int);
            dataColumn73.DefaultValue = 1;
            // 
            // dataColumnPackSize
            // 
            dataColumnPackSize.ColumnName = "PackSize";
            dataColumnPackSize.DataType = typeof(int);
            dataColumnPackSize.DefaultValue = 1;
            // 
            // dataColumnCharges
            // 
            dataColumnCharges.ColumnName = "Charges";
            dataColumnCharges.DataType = typeof(int);
            dataColumnCharges.DefaultValue = 0;
            // 
            // dataColumnMaxCount
            // 
            dataColumnMaxCount.ColumnName = "MaxCharges";
            dataColumnMaxCount.DataType = typeof(int);
            dataColumnMaxCount.DefaultValue = 0;
            // 
            // dataColumnSpellID
            // 
            dataColumnSpellID.ColumnName = "SpellID";
            dataColumnSpellID.DataType = typeof(int);
            dataColumnSpellID.DefaultValue = 0;
            // 
            // dataColumnProcSpellID
            // 
            dataColumnProcSpellID.ColumnName = "ProcSpellID";
            dataColumnProcSpellID.DataType = typeof(int);
            dataColumnProcSpellID.DefaultValue = 0;
            // 
            // dataColumnPoisonCharges
            // 
            dataColumnPoisonCharges.ColumnName = "PoisonCharges";
            dataColumnPoisonCharges.DataType = typeof(int);
            dataColumnPoisonCharges.DefaultValue = 0;
            // 
            // dataColumnPoisonMaxCharges
            // 
            dataColumnPoisonMaxCharges.ColumnName = "PoisonMaxCharges";
            dataColumnPoisonMaxCharges.DataType = typeof(int);
            dataColumnPoisonMaxCharges.DefaultValue = 0;
            // 
            // dataColumnPoisonSpellID
            // 
            dataColumnPoisonSpellID.ColumnName = "PoisonSpellID";
            dataColumnPoisonSpellID.DataType = typeof(int);
            dataColumnPoisonSpellID.DefaultValue = 0;
            // 
            // dataColumnProcSpellID1
            // 
            dataColumnProcSpellID1.ColumnName = "ProcSpellID1";
            dataColumnProcSpellID1.DefaultValue = "0";
            // 
            // dataColumnSpellID1
            // 
            dataColumnSpellID1.ColumnName = "SpellID1";
            dataColumnSpellID1.DataType = typeof(int);
            dataColumnSpellID1.DefaultValue = 0;
            // 
            // dataColumnMaxCharges1
            // 
            dataColumnMaxCharges1.ColumnName = "MaxCharges1";
            dataColumnMaxCharges1.DataType = typeof(int);
            dataColumnMaxCharges1.DefaultValue = 0;
            // 
            // dataColumnCharges1
            // 
            dataColumnCharges1.ColumnName = "Charges1";
            dataColumnCharges1.DataType = typeof(int);
            dataColumnCharges1.DefaultValue = 0;
            // 
            // dataColumnIsTradable
            // 
            dataColumnIsTradable.ColumnName = "IsTradable";
            dataColumnIsTradable.DataType = typeof(bool);
            dataColumnIsTradable.DefaultValue = true;
            // 
            // dataColumnCanDropAsLoot
            // 
            dataColumnCanDropAsLoot.ColumnName = "CanDropAsLoot";
            dataColumnCanDropAsLoot.DataType = typeof(bool);
            dataColumnCanDropAsLoot.DefaultValue = true;
            // 
            // dataColumnBonus6Type
            // 
            dataColumnBonus6Type.ColumnName = "Bonus6Type";
            dataColumnBonus6Type.DataType = typeof(int);
            dataColumnBonus6Type.DefaultValue = 0;
            // 
            // dataColumnBonus6
            // 
            dataColumnBonus6.ColumnName = "Bonus6";
            dataColumnBonus6.DataType = typeof(int);
            dataColumnBonus6.DefaultValue = 0;
            // 
            // dataColumnBonus7Type
            // 
            dataColumnBonus7Type.ColumnName = "Bonus7Type";
            dataColumnBonus7Type.DataType = typeof(int);
            dataColumnBonus7Type.DefaultValue = 0;
            // 
            // dataColumnBonus7
            // 
            dataColumnBonus7.ColumnName = "Bonus7";
            dataColumnBonus7.DataType = typeof(int);
            dataColumnBonus7.DefaultValue = 0;
            // 
            // dataColumnBonus8Type
            // 
            dataColumnBonus8Type.ColumnName = "Bonus8Type";
            dataColumnBonus8Type.DataType = typeof(int);
            dataColumnBonus8Type.DefaultValue = 0;
            // 
            // dataColumnBonus8
            // 
            dataColumnBonus8.ColumnName = "Bonus8";
            dataColumnBonus8.DataType = typeof(int);
            dataColumnBonus8.DefaultValue = 0;
            // 
            // dataColumnBonus9Type
            // 
            dataColumnBonus9Type.ColumnName = "Bonus9Type";
            dataColumnBonus9Type.DataType = typeof(int);
            dataColumnBonus9Type.DefaultValue = 0;
            // 
            // dataColumnBonus9
            // 
            dataColumnBonus9.ColumnName = "Bonus9";
            dataColumnBonus9.DataType = typeof(int);
            dataColumnBonus9.DefaultValue = 0;
            // 
            // dataColumnBonus10Type
            // 
            dataColumnBonus10Type.ColumnName = "Bonus10Type";
            dataColumnBonus10Type.DataType = typeof(int);
            dataColumnBonus10Type.DefaultValue = 0;
            // 
            // dataColumnBonus10
            // 
            dataColumnBonus10.ColumnName = "Bonus10";
            dataColumnBonus10.DataType = typeof(int);
            dataColumnBonus10.DefaultValue = 0;
            // 
            // dataColumn59
            // 
            dataColumn59.ColumnName = "BodyType";
            dataColumn59.DataType = typeof(int);
            dataColumn59.DefaultValue = 0;
            // 
            // dataColumn66
            // 
            dataColumn66.ColumnName = "NPCTemplateID";
            dataColumn66.DataType = typeof(int);
            // 
            // dataColumnPlatinum
            // 
            dataColumnPlatinum.ColumnName = "Platinum";
            dataColumnPlatinum.DataType = typeof(int);
            dataColumnPlatinum.DefaultValue = 0;
            // 
            // dataColumnQuestDate
            // 
            dataColumnQuestDate.ColumnName = "Date";
            dataColumnQuestDate.DataType = typeof(System.DateTime);
            // 
            // dataColumn26
            // 
            dataColumn26.AllowDBNull = false;
            dataColumn26.ColumnName = "Category";
            dataColumn26.DefaultValue = "";
            // 
            // dataColumn33
            // 
            dataColumn33.AllowDBNull = false;
            dataColumn33.Caption = "Category";
            dataColumn33.ColumnName = "category";
            dataColumn33.DefaultValue = "";
            // 
            // dataColumn34
            // 
            dataColumn34.AllowDBNull = false;
            dataColumn34.Caption = "Category";
            dataColumn34.ColumnName = "category";
            dataColumn34.DefaultValue = "";
            // 
            // dataColumn35
            // 
            dataColumn35.AllowDBNull = false;
            dataColumn35.Caption = "Category";
            dataColumn35.ColumnName = "category";
            dataColumn35.DefaultValue = "";
            // 
            // dataColumnQuestID
            // 
            dataColumnQuestID.AllowDBNull = false;
            dataColumnQuestID.AutoIncrement = true;
            dataColumnQuestID.ColumnName = "ID";
            dataColumnQuestID.DataType = typeof(int);
            // 
            // dataColumnQuestName
            // 
            dataColumnQuestName.ColumnName = "Name";
            // 
            // dataColumnQuestAuthor
            // 
            dataColumnQuestAuthor.ColumnName = "Author";
            // 
            // dataColumnQuestVersion
            // 
            dataColumnQuestVersion.ColumnName = "Version";
            dataColumnQuestVersion.DefaultValue = "0";
            // 
            // dataColumnQuestDescription
            // 
            dataColumnQuestDescription.ColumnName = "Description";
            // 
            // dataColumn14
            // 
            dataColumn14.ColumnName = "Title";
            // 
            // dataColumnMinimumLevel
            // 
            dataColumnMinimumLevel.ColumnName = "MinimumLevel";
            dataColumnMinimumLevel.DataType = typeof(int);
            dataColumnMinimumLevel.DefaultValue = 1;
            // 
            // dataColumnMaximumLevel
            // 
            dataColumnMaximumLevel.ColumnName = "MaximumLevel";
            dataColumnMaximumLevel.DataType = typeof(int);
            dataColumnMaximumLevel.DefaultValue = 1;
            // 
            // dataColumnInvintingNPC
            // 
            dataColumnInvintingNPC.ColumnName = "InvitingNPC";
            // 
            // dataColumn41
            // 
            dataColumn41.AllowDBNull = false;
            dataColumn41.ColumnName = "Namespace";
            dataColumn41.DefaultValue = "DOL.GS.Quests";
            // 
            // dataColumn62
            // 
            dataColumn62.ColumnName = "MaxQuestCount";
            dataColumn62.DefaultValue = "1";
            // 
            // dataColumn63
            // 
            dataColumn63.ColumnName = "ScriptLoadedCode";
            // 
            // dataColumn64
            // 
            dataColumn64.ColumnName = "ScriptUnloadedCode";
            // 
            // dataColumn65
            // 
            dataColumn65.ColumnName = "InitializationCode";
            // 
            // dataColumn36
            // 
            dataColumn36.ColumnName = "CheckQuestQualificationCode";
            // 
            // dataColumn37
            // 
            dataColumn37.AllowDBNull = false;
            dataColumn37.ColumnName = "CategoryAutoGenerate";
            dataColumn37.DataType = typeof(bool);
            dataColumn37.DefaultValue = true;
            // 
            // dataColumn39
            // 
            dataColumn39.ColumnName = "Sound";
            dataColumn39.DataType = typeof(int);
            // 
            // dataColumn40
            // 
            dataColumn40.AllowDBNull = false;
            dataColumn40.ColumnName = "IsSafeArea";
            dataColumn40.DataType = typeof(bool);
            dataColumn40.DefaultValue = false;
            // 
            // dataColumn42
            // 
            dataColumn42.AllowDBNull = false;
            dataColumn42.ColumnName = "CanBroadcast";
            dataColumn42.DataType = typeof(bool);
            dataColumn42.DefaultValue = false;
            // 
            // dataColumn43
            // 
            dataColumn43.AllowDBNull = false;
            dataColumn43.ColumnName = "DisplayMessage";
            dataColumn43.DataType = typeof(bool);
            dataColumn43.DefaultValue = true;
            // 
            // toolStripContainerForm
            // 
            this.toolStripContainerForm.AccessibleDescription = null;
            this.toolStripContainerForm.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainerForm, "toolStripContainerForm");
            // 
            // toolStripContainerForm.BottomToolStripPanel
            // 
            this.toolStripContainerForm.BottomToolStripPanel.AccessibleDescription = null;
            this.toolStripContainerForm.BottomToolStripPanel.AccessibleName = null;
            this.toolStripContainerForm.BottomToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainerForm.BottomToolStripPanel, "toolStripContainerForm.BottomToolStripPanel");
            this.toolStripContainerForm.BottomToolStripPanel.Controls.Add(this.statusStrip);
            this.toolStripContainerForm.BottomToolStripPanel.Font = null;
            this.toolTip.SetToolTip(this.toolStripContainerForm.BottomToolStripPanel, resources.GetString("toolStripContainerForm.BottomToolStripPanel.ToolTip"));
            // 
            // toolStripContainerForm.ContentPanel
            // 
            this.toolStripContainerForm.ContentPanel.AccessibleDescription = null;
            this.toolStripContainerForm.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.toolStripContainerForm.ContentPanel, "toolStripContainerForm.ContentPanel");
            this.toolStripContainerForm.ContentPanel.BackgroundImage = null;
            this.toolStripContainerForm.ContentPanel.Controls.Add(this.tabControlMain);
            this.toolStripContainerForm.ContentPanel.Controls.Add(this.xpTaskPane);
            this.toolStripContainerForm.ContentPanel.Font = null;
            this.toolTip.SetToolTip(this.toolStripContainerForm.ContentPanel, resources.GetString("toolStripContainerForm.ContentPanel.ToolTip"));
            this.toolStripContainerForm.Font = null;
            // 
            // toolStripContainerForm.LeftToolStripPanel
            // 
            this.toolStripContainerForm.LeftToolStripPanel.AccessibleDescription = null;
            this.toolStripContainerForm.LeftToolStripPanel.AccessibleName = null;
            this.toolStripContainerForm.LeftToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainerForm.LeftToolStripPanel, "toolStripContainerForm.LeftToolStripPanel");
            this.toolStripContainerForm.LeftToolStripPanel.Font = null;
            this.toolTip.SetToolTip(this.toolStripContainerForm.LeftToolStripPanel, resources.GetString("toolStripContainerForm.LeftToolStripPanel.ToolTip"));
            this.toolStripContainerForm.Name = "toolStripContainerForm";
            // 
            // toolStripContainerForm.RightToolStripPanel
            // 
            this.toolStripContainerForm.RightToolStripPanel.AccessibleDescription = null;
            this.toolStripContainerForm.RightToolStripPanel.AccessibleName = null;
            this.toolStripContainerForm.RightToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainerForm.RightToolStripPanel, "toolStripContainerForm.RightToolStripPanel");
            this.toolStripContainerForm.RightToolStripPanel.Font = null;
            this.toolTip.SetToolTip(this.toolStripContainerForm.RightToolStripPanel, resources.GetString("toolStripContainerForm.RightToolStripPanel.ToolTip"));
            this.toolTip.SetToolTip(this.toolStripContainerForm, resources.GetString("toolStripContainerForm.ToolTip"));
            // 
            // toolStripContainerForm.TopToolStripPanel
            // 
            this.toolStripContainerForm.TopToolStripPanel.AccessibleDescription = null;
            this.toolStripContainerForm.TopToolStripPanel.AccessibleName = null;
            this.toolStripContainerForm.TopToolStripPanel.BackgroundImage = null;
            resources.ApplyResources(this.toolStripContainerForm.TopToolStripPanel, "toolStripContainerForm.TopToolStripPanel");
            this.toolStripContainerForm.TopToolStripPanel.Controls.Add(this.menuStripMain);
            this.toolStripContainerForm.TopToolStripPanel.Font = null;
            this.toolTip.SetToolTip(this.toolStripContainerForm.TopToolStripPanel, resources.GetString("toolStripContainerForm.TopToolStripPanel.ToolTip"));
            // 
            // statusStrip
            // 
            this.statusStrip.AccessibleDescription = null;
            this.statusStrip.AccessibleName = null;
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.BackgroundImage = null;
            this.statusStrip.Font = null;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusIcon,
            this.StatusLabel,
            this.StatusProgress});
            this.statusStrip.Name = "statusStrip";
            this.toolTip.SetToolTip(this.statusStrip, resources.GetString("statusStrip.ToolTip"));
            // 
            // StatusIcon
            // 
            this.StatusIcon.AccessibleDescription = null;
            this.StatusIcon.AccessibleName = null;
            resources.ApplyResources(this.StatusIcon, "StatusIcon");
            this.StatusIcon.BackgroundImage = null;
            this.StatusIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StatusIcon.Name = "StatusIcon";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AccessibleDescription = null;
            this.StatusLabel.AccessibleName = null;
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BackgroundImage = null;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Spring = true;
            this.StatusLabel.Click += new System.EventHandler(this.StatusLabel_Click);
            // 
            // StatusProgress
            // 
            this.StatusProgress.AccessibleDescription = null;
            this.StatusProgress.AccessibleName = null;
            resources.ApplyResources(this.StatusProgress, "StatusProgress");
            this.StatusProgress.Name = "StatusProgress";
            // 
            // tabControlMain
            // 
            this.tabControlMain.AccessibleDescription = null;
            this.tabControlMain.AccessibleName = null;
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Appearance = NETXP.Controls.Docking.TabPosition.Top;
            this.tabControlMain.BackgroundImage = null;
            this.tabControlMain.BoldSelectedPage = true;
            this.tabControlMain.Font = null;
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.PixelArea = true;
            this.tabControlMain.PixelBorder = true;
            this.tabControlMain.PositionTop = true;
            office20031.ColorTable = dynamicColorTable1;
            this.tabControlMain.Renderer = office20031;
            this.tabControlMain.ShowArrows = true;
            this.tabControlMain.ShowClose = false;
            this.tabControlMain.ShrinkPagesToFit = false;
            this.tabControlMain.TabPages.AddRange(new NETXP.Controls.Docking.TabPage[] {
            this.tabPageQuest,
            this.tabPageNPC,
            this.tabPageItem,
            this.tabPageQuestPart,
            this.tabPageArea,
            this.tabPageLocation,
            this.tabPageCode,
            this.tabPageMap,
            this.tabPageWeb});
            this.toolTip.SetToolTip(this.tabControlMain, resources.GetString("tabControlMain.ToolTip"));
            this.tabControlMain.SelectionChanged += new System.EventHandler(this.tabControlMain_SelectionChanged);
            // 
            // tabPageQuest
            // 
            this.tabPageQuest.AccessibleDescription = null;
            this.tabPageQuest.AccessibleName = null;
            resources.ApplyResources(this.tabPageQuest, "tabPageQuest");
            this.tabPageQuest.BackgroundImage = null;
            this.tabPageQuest.Controls.Add(this.questInfo);
            this.tabPageQuest.Icon = null;
            this.tabPageQuest.Name = "tabPageQuest";
            this.toolTip.SetToolTip(this.tabPageQuest, resources.GetString("tabPageQuest.ToolTip"));
            // 
            // questInfo
            // 
            this.questInfo.AccessibleDescription = null;
            this.questInfo.AccessibleName = null;
            resources.ApplyResources(this.questInfo, "questInfo");
            this.questInfo.BackgroundImage = null;
            this.questInfo.Font = null;
            this.questInfo.Name = "questInfo";
            this.toolTip.SetToolTip(this.questInfo, resources.GetString("questInfo.ToolTip"));
            // 
            // tabPageNPC
            // 
            this.tabPageNPC.AccessibleDescription = null;
            this.tabPageNPC.AccessibleName = null;
            resources.ApplyResources(this.tabPageNPC, "tabPageNPC");
            this.tabPageNPC.BackgroundImage = null;
            this.tabPageNPC.Controls.Add(this.npcView);
            this.tabPageNPC.Icon = null;
            this.tabPageNPC.Name = "tabPageNPC";
            this.toolTip.SetToolTip(this.tabPageNPC, resources.GetString("tabPageNPC.ToolTip"));
            // 
            // npcView
            // 
            this.npcView.AccessibleDescription = null;
            this.npcView.AccessibleName = null;
            resources.ApplyResources(this.npcView, "npcView");
            this.npcView.BackgroundImage = null;
            this.npcView.Font = null;
            this.npcView.Name = "npcView";
            this.toolTip.SetToolTip(this.npcView, resources.GetString("npcView.ToolTip"));
            // 
            // tabPageItem
            // 
            this.tabPageItem.AccessibleDescription = null;
            this.tabPageItem.AccessibleName = null;
            resources.ApplyResources(this.tabPageItem, "tabPageItem");
            this.tabPageItem.BackgroundImage = null;
            this.tabPageItem.Controls.Add(this.itemView);
            this.tabPageItem.Icon = null;
            this.tabPageItem.Name = "tabPageItem";
            this.toolTip.SetToolTip(this.tabPageItem, resources.GetString("tabPageItem.ToolTip"));
            // 
            // itemView
            // 
            this.itemView.AccessibleDescription = null;
            this.itemView.AccessibleName = null;
            resources.ApplyResources(this.itemView, "itemView");
            this.itemView.BackgroundImage = null;
            this.itemView.Font = null;
            this.itemView.Name = "itemView";
            this.toolTip.SetToolTip(this.itemView, resources.GetString("itemView.ToolTip"));
            // 
            // tabPageQuestPart
            // 
            this.tabPageQuestPart.AccessibleDescription = null;
            this.tabPageQuestPart.AccessibleName = null;
            resources.ApplyResources(this.tabPageQuestPart, "tabPageQuestPart");
            this.tabPageQuestPart.BackgroundImage = null;
            this.tabPageQuestPart.Controls.Add(this.questPartItems);
            this.tabPageQuestPart.Icon = null;
            this.tabPageQuestPart.Name = "tabPageQuestPart";
            this.toolTip.SetToolTip(this.tabPageQuestPart, resources.GetString("tabPageQuestPart.ToolTip"));
            // 
            // questPartItems
            // 
            this.questPartItems.AccessibleDescription = null;
            this.questPartItems.AccessibleName = null;
            this.questPartItems.ActionColor = System.Drawing.Color.RosyBrown;
            this.questPartItems.ActionSelectedColor = System.Drawing.Color.OrangeRed;
            resources.ApplyResources(this.questPartItems, "questPartItems");
            this.questPartItems.BackgroundImage = null;
            this.questPartItems.Font = null;
            this.questPartItems.ForeColor = System.Drawing.Color.Gray;
            this.questPartItems.ForeColorSelected = System.Drawing.Color.Black;
            this.questPartItems.Name = "questPartItems";
            this.questPartItems.QuestPartRow = null;
            this.questPartItems.RequirementColor = System.Drawing.Color.Tan;
            this.questPartItems.RequirementSelectedColor = System.Drawing.Color.Orange;
            this.toolTip.SetToolTip(this.questPartItems, resources.GetString("questPartItems.ToolTip"));
            this.questPartItems.TriggerColor = System.Drawing.Color.Olive;
            this.questPartItems.TriggerSelectedColor = System.Drawing.Color.Green;
            // 
            // tabPageArea
            // 
            this.tabPageArea.AccessibleDescription = null;
            this.tabPageArea.AccessibleName = null;
            resources.ApplyResources(this.tabPageArea, "tabPageArea");
            this.tabPageArea.BackgroundImage = null;
            this.tabPageArea.Controls.Add(this.areaView);
            this.tabPageArea.Icon = null;
            this.tabPageArea.Name = "tabPageArea";
            this.toolTip.SetToolTip(this.tabPageArea, resources.GetString("tabPageArea.ToolTip"));
            // 
            // areaView
            // 
            this.areaView.AccessibleDescription = null;
            this.areaView.AccessibleName = null;
            resources.ApplyResources(this.areaView, "areaView");
            this.areaView.BackgroundImage = null;
            this.areaView.Font = null;
            this.areaView.Name = "areaView";
            this.toolTip.SetToolTip(this.areaView, resources.GetString("areaView.ToolTip"));
            // 
            // tabPageLocation
            // 
            this.tabPageLocation.AccessibleDescription = null;
            this.tabPageLocation.AccessibleName = null;
            resources.ApplyResources(this.tabPageLocation, "tabPageLocation");
            this.tabPageLocation.BackgroundImage = null;
            this.tabPageLocation.Controls.Add(this.locationView);
            this.tabPageLocation.Icon = null;
            this.tabPageLocation.Name = "tabPageLocation";
            this.toolTip.SetToolTip(this.tabPageLocation, resources.GetString("tabPageLocation.ToolTip"));
            // 
            // locationView
            // 
            this.locationView.AccessibleDescription = null;
            this.locationView.AccessibleName = null;
            resources.ApplyResources(this.locationView, "locationView");
            this.locationView.BackgroundImage = null;
            this.locationView.Font = null;
            this.locationView.Name = "locationView";
            this.toolTip.SetToolTip(this.locationView, resources.GetString("locationView.ToolTip"));
            // 
            // tabPageCode
            // 
            this.tabPageCode.AccessibleDescription = null;
            this.tabPageCode.AccessibleName = null;
            resources.ApplyResources(this.tabPageCode, "tabPageCode");
            this.tabPageCode.BackgroundImage = null;
            this.tabPageCode.Controls.Add(this.customCode);
            this.tabPageCode.Icon = null;
            this.tabPageCode.Name = "tabPageCode";
            this.toolTip.SetToolTip(this.tabPageCode, resources.GetString("tabPageCode.ToolTip"));
            // 
            // customCode
            // 
            this.customCode.AccessibleDescription = null;
            this.customCode.AccessibleName = null;
            resources.ApplyResources(this.customCode, "customCode");
            this.customCode.BackgroundImage = null;
            this.customCode.Font = null;
            this.customCode.Name = "customCode";
            this.toolTip.SetToolTip(this.customCode, resources.GetString("customCode.ToolTip"));
            // 
            // tabPageMap
            // 
            this.tabPageMap.AccessibleDescription = null;
            this.tabPageMap.AccessibleName = null;
            resources.ApplyResources(this.tabPageMap, "tabPageMap");
            this.tabPageMap.BackgroundImage = null;
            this.tabPageMap.Controls.Add(this.DXControl);
            this.tabPageMap.Icon = null;
            this.tabPageMap.Name = "tabPageMap";
            this.toolTip.SetToolTip(this.tabPageMap, resources.GetString("tabPageMap.ToolTip"));
            // 
            // DXControl
            // 
            this.DXControl.AccessibleDescription = null;
            this.DXControl.AccessibleName = null;
            resources.ApplyResources(this.DXControl, "DXControl");
            this.DXControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.DXControl.BackgroundImage = null;
            this.DXControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.DXControl.Font = null;
            this.DXControl.Name = "DXControl";
            this.toolTip.SetToolTip(this.DXControl, resources.GetString("DXControl.ToolTip"));
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.AccessibleDescription = null;
            this.tabPageWeb.AccessibleName = null;
            resources.ApplyResources(this.tabPageWeb, "tabPageWeb");
            this.tabPageWeb.BackgroundImage = null;
            this.tabPageWeb.Controls.Add(this.webBrowser1);
            this.tabPageWeb.Icon = null;
            this.tabPageWeb.Name = "tabPageWeb";
            this.toolTip.SetToolTip(this.tabPageWeb, resources.GetString("tabPageWeb.ToolTip"));
            // 
            // webBrowser1
            // 
            this.webBrowser1.AccessibleDescription = null;
            this.webBrowser1.AccessibleName = null;
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.BackgroundImage = null;
            this.webBrowser1.Font = null;
            this.webBrowser1.Name = "webBrowser1";
            this.toolTip.SetToolTip(this.webBrowser1, resources.GetString("webBrowser1.ToolTip"));
            // 
            // xpTaskPane
            // 
            this.xpTaskPane.AccessibleDescription = null;
            this.xpTaskPane.AccessibleName = null;
            resources.ApplyResources(this.xpTaskPane, "xpTaskPane");
            this.xpTaskPane.BackgroundImage = null;
            this.xpTaskPane.ColorTable = dynamicColorTable2;
            this.xpTaskPane.Controls.Add(this.xpTGQuestPart);
            this.xpTaskPane.Controls.Add(this.xpTGActions);
            this.xpTaskPane.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "ShowTaskPane", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.xpTaskPane.Font = null;
            this.xpTaskPane.Name = "xpTaskPane";
            this.toolTip.SetToolTip(this.xpTaskPane, resources.GetString("xpTaskPane.ToolTip"));
            this.xpTaskPane.Visible = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.ShowTaskPane;
            // 
            // xpTGQuestPart
            // 
            this.xpTGQuestPart.AccessibleDescription = null;
            this.xpTGQuestPart.AccessibleName = null;
            resources.ApplyResources(this.xpTGQuestPart, "xpTGQuestPart");
            this.xpTGQuestPart.BackgroundImage = null;
            this.xpTGQuestPart.ColorTable = dynamicColorTable2;
            this.xpTGQuestPart.Font = null;
            this.xpTGQuestPart.Image = null;
            this.xpTGQuestPart.Name = "xpTGQuestPart";
            this.toolTip.SetToolTip(this.xpTGQuestPart, resources.GetString("xpTGQuestPart.ToolTip"));
            // 
            // xpTGActions
            // 
            this.xpTGActions.AccessibleDescription = null;
            this.xpTGActions.AccessibleName = null;
            resources.ApplyResources(this.xpTGActions, "xpTGActions");
            this.xpTGActions.BackgroundImage = null;
            this.xpTGActions.ColorTable = dynamicColorTable2;
            this.xpTGActions.Controls.Add(this.linkLabelNewQuest);
            this.xpTGActions.Controls.Add(this.linkSaveQuest);
            this.xpTGActions.Controls.Add(this.linkLoadQuest);
            this.xpTGActions.Font = null;
            this.xpTGActions.Name = "xpTGActions";
            this.xpTGActions.SpecialTasks = true;
            this.toolTip.SetToolTip(this.xpTGActions, resources.GetString("xpTGActions.ToolTip"));
            // 
            // linkLabelNewQuest
            // 
            this.linkLabelNewQuest.AccessibleDescription = null;
            this.linkLabelNewQuest.AccessibleName = null;
            resources.ApplyResources(this.linkLabelNewQuest, "linkLabelNewQuest");
            this.linkLabelNewQuest.Font = null;
            this.linkLabelNewQuest.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.add;
            this.linkLabelNewQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelNewQuest.Name = "linkLabelNewQuest";
            this.linkLabelNewQuest.TabStop = true;
            this.toolTip.SetToolTip(this.linkLabelNewQuest, resources.GetString("linkLabelNewQuest.ToolTip"));
            this.linkLabelNewQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNewQuest_LinkClicked);
            // 
            // linkSaveQuest
            // 
            this.linkSaveQuest.AccessibleDescription = null;
            this.linkSaveQuest.AccessibleName = null;
            resources.ApplyResources(this.linkSaveQuest, "linkSaveQuest");
            this.linkSaveQuest.Font = null;
            this.linkSaveQuest.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.save;
            this.linkSaveQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkSaveQuest.Name = "linkSaveQuest";
            this.linkSaveQuest.TabStop = true;
            this.toolTip.SetToolTip(this.linkSaveQuest, resources.GetString("linkSaveQuest.ToolTip"));
            this.linkSaveQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSaveQuest_LinkClicked);
            // 
            // linkLoadQuest
            // 
            this.linkLoadQuest.AccessibleDescription = null;
            this.linkLoadQuest.AccessibleName = null;
            resources.ApplyResources(this.linkLoadQuest, "linkLoadQuest");
            this.linkLoadQuest.Font = null;
            this.linkLoadQuest.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.quest;
            this.linkLoadQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLoadQuest.Name = "linkLoadQuest";
            this.linkLoadQuest.TabStop = true;
            this.toolTip.SetToolTip(this.linkLoadQuest, resources.GetString("linkLoadQuest.ToolTip"));
            this.linkLoadQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLoadQuest_LinkClicked);
            // 
            // menuStripMain
            // 
            this.menuStripMain.AccessibleDescription = null;
            this.menuStripMain.AccessibleName = null;
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.BackgroundImage = null;
            this.menuStripMain.Font = null;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStripMain.Name = "menuStripMain";
            this.toolTip.SetToolTip(this.menuStripMain, resources.GetString("menuStripMain.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.AccessibleDescription = null;
            this.fileToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.BackgroundImage = null;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.createToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.AccessibleDescription = null;
            this.newToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.BackgroundImage = null;
            this.newToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.newDocument;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.AccessibleDescription = null;
            this.openToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.BackgroundImage = null;
            this.openToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.AccessibleDescription = null;
            this.toolStripSeparator.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            this.toolStripSeparator.Name = "toolStripSeparator";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.AccessibleDescription = null;
            this.saveToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.BackgroundImage = null;
            this.saveToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.AccessibleDescription = null;
            this.saveAsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.BackgroundImage = null;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.AccessibleDescription = null;
            this.createToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.createToolStripMenuItem, "createToolStripMenuItem");
            this.createToolStripMenuItem.BackgroundImage = null;
            this.createToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.create;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AccessibleDescription = null;
            this.toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AccessibleDescription = null;
            this.exitToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.BackgroundImage = null;
            this.exitToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.delete;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.AccessibleDescription = null;
            this.viewToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.BackgroundImage = null;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTaskPane});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // toolStripMenuItemTaskPane
            // 
            this.toolStripMenuItemTaskPane.AccessibleDescription = null;
            this.toolStripMenuItemTaskPane.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItemTaskPane, "toolStripMenuItemTaskPane");
            this.toolStripMenuItemTaskPane.BackgroundImage = null;
            this.toolStripMenuItemTaskPane.Checked = true;
            this.toolStripMenuItemTaskPane.CheckOnClick = true;
            this.toolStripMenuItemTaskPane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemTaskPane.Name = "toolStripMenuItemTaskPane";
            this.toolStripMenuItemTaskPane.ShortcutKeyDisplayString = null;
            this.toolStripMenuItemTaskPane.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemTaskPane_CheckStateChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.AccessibleDescription = null;
            this.toolsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.BackgroundImage = null;
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionConverterToolStripMenuItem,
            this.dataDownloadToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.ShortcutKeyDisplayString = null;
            // 
            // positionConverterToolStripMenuItem
            // 
            this.positionConverterToolStripMenuItem.AccessibleDescription = null;
            this.positionConverterToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.positionConverterToolStripMenuItem, "positionConverterToolStripMenuItem");
            this.positionConverterToolStripMenuItem.BackgroundImage = null;
            this.positionConverterToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.globe;
            this.positionConverterToolStripMenuItem.Name = "positionConverterToolStripMenuItem";
            this.positionConverterToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.positionConverterToolStripMenuItem.Click += new System.EventHandler(this.positionConverterToolStripMenuItem_Click);
            // 
            // dataDownloadToolStripMenuItem
            // 
            this.dataDownloadToolStripMenuItem.AccessibleDescription = null;
            this.dataDownloadToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.dataDownloadToolStripMenuItem, "dataDownloadToolStripMenuItem");
            this.dataDownloadToolStripMenuItem.BackgroundImage = null;
            this.dataDownloadToolStripMenuItem.Name = "dataDownloadToolStripMenuItem";
            this.dataDownloadToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.dataDownloadToolStripMenuItem.Click += new System.EventHandler(this.dataDownloadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.AccessibleDescription = null;
            this.toolStripMenuItem1.AccessibleName = null;
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.BackgroundImage = null;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeyDisplayString = null;
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.AccessibleDescription = null;
            this.aboutToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.BackgroundImage = null;
            this.aboutToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.questpart;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.AccessibleDescription = null;
            this.creditsToolStripMenuItem.AccessibleName = null;
            resources.ApplyResources(this.creditsToolStripMenuItem, "creditsToolStripMenuItem");
            this.creditsToolStripMenuItem.BackgroundImage = null;
            this.creditsToolStripMenuItem.Image = global::DOL.Tools.QuestDesigner.Properties.Resources.info;
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.ShortcutKeyDisplayString = null;
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // dataSetQuest
            // 
            this.dataSetQuest.DataSetName = "Quest";
            this.dataSetQuest.EnforceConstraints = false;
            this.dataSetQuest.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("QuestPartXQuestTrigger", "QuestPart", "QuestPartTrigger", new string[] {
                        "ID"}, new string[] {
                        "QuestPartID"}, true),
            new System.Data.DataRelation("QuestPartXQuestRequirement", "QuestPart", "QuestPartRequirement", new string[] {
                        "ID"}, new string[] {
                        "QuestPartID"}, true),
            new System.Data.DataRelation("QuestPartXQuestAction", "QuestPart", "QuestPartAction", new string[] {
                        "ID"}, new string[] {
                        "QuestPartID"}, true)});
            this.dataSetQuest.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableQuestPart,
            this.dataTableTrigger,
            this.dataTableRequirement,
            this.dataTableAction,
            this.dataTableQuest,
            this.dataTableMob,
            this.dataTableItemTemplate,
            this.dataTableQuestStep,
            this.dataTableArea,
            this.dataTableLocation,
            dataTableQuestCharacterClass});
            this.dataSetQuest.Initialized += new System.EventHandler(this.dataSetQuest_Initialized);
            // 
            // dataTableQuestPart
            // 
            this.dataTableQuestPart.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnQuestPartIF,
            dataColumnDefaultNPC,
            dataColumn23,
            dataColumn26,
            dataColumn37,
            this.dataColumn38});
            this.dataTableQuestPart.TableName = "QuestPart";
            // 
            // dataColumn38
            // 
            this.dataColumn38.AllowDBNull = false;
            this.dataColumn38.ColumnName = "MaxExecutions";
            this.dataColumn38.DataType = typeof(int);
            this.dataColumn38.DefaultValue = -1;
            // 
            // dataTableTrigger
            // 
            this.dataTableTrigger.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnTriggerQuestPart,
            dataColumnTriggerType,
            dataColumnTriggerKeyword,
            dataColumnTriggerObject,
            dataColumnQuestTriggerID,
            this.dataColumn29});
            this.dataTableTrigger.TableName = "QuestPartTrigger";
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "TypeName";
            // 
            // dataTableRequirement
            // 
            this.dataTableRequirement.Columns.AddRange(new System.Data.DataColumn[] {
            datacolumnquestPartID,
            dataColumnRequirmentType,
            dataColumnRequirmeentN,
            dataColumnRequirementV,
            dataColumnRequirementComparator,
            dataColumnRequirementID,
            this.dataColumn30});
            this.dataTableRequirement.TableName = "QuestPartRequirement";
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "TypeName";
            // 
            // dataTableAction
            // 
            this.dataTableAction.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnActionQuestPartID,
            dataColumnActionType,
            dataColumnActionP,
            dataColumnActionQ,
            dataColumn1,
            this.dataColumn31});
            this.dataTableAction.TableName = "QuestPartAction";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "TypeName";
            // 
            // dataTableQuest
            // 
            this.dataTableQuest.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnQuestID,
            dataColumnQuestName,
            dataColumnQuestAuthor,
            dataColumnQuestDate,
            dataColumnQuestVersion,
            dataColumnQuestDescription,
            dataColumn14,
            dataColumnMinimumLevel,
            dataColumnMaximumLevel,
            dataColumnInvintingNPC,
            dataColumn41,
            dataColumn62,
            dataColumn63,
            dataColumn64,
            dataColumn65,
            dataColumn36});
            this.dataTableQuest.TableName = "Quest";
            // 
            // dataTableMob
            // 
            this.dataTableMob.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnName,
            this.dataColumnModel,
            this.dataColumnGuildName,
            this.dataColumnLevel,
            this.dataColumnX,
            this.dataColumnY,
            this.dataColumnZ,
            this.dataColumnRegion,
            this.dataColumnMobID,
            this.dataColumnClassType,
            this.dataColumnSpeed,
            this.dataColumnHeading,
            this.dataColumnSize,
            this.dataColumnEquipmentTemplateID,
            this.dataColumnFlags,
            this.dataColumnAggroLevel,
            this.dataColumnAggroRange,
            this.dataColumnMobRealm,
            this.dataColumnMobRespawnInterval,
            this.dataColumnMobFactionID,
            this.dataColumnMobMeleeDamageType,
            this.dataColumnMobItemsListTemplateID,
            this.dataColumnAddToworld,
            this.dataColumnObjectName,
            dataColumn59,
            dataColumn66});
            this.dataTableMob.TableName = "Mob";
            // 
            // dataColumnName
            // 
            this.dataColumnName.ColumnName = "Name";
            // 
            // dataColumnModel
            // 
            this.dataColumnModel.Caption = "Model";
            this.dataColumnModel.ColumnName = "Model";
            this.dataColumnModel.DataType = typeof(int);
            this.dataColumnModel.DefaultValue = 49;
            this.dataColumnModel.Namespace = "";
            // 
            // dataColumnGuildName
            // 
            this.dataColumnGuildName.ColumnName = "Guild";
            this.dataColumnGuildName.DefaultValue = "";
            // 
            // dataColumnLevel
            // 
            this.dataColumnLevel.ColumnName = "Level";
            this.dataColumnLevel.DataType = typeof(byte);
            this.dataColumnLevel.DefaultValue = ((byte)(1));
            // 
            // dataColumnX
            // 
            this.dataColumnX.ColumnName = "X";
            this.dataColumnX.DataType = typeof(int);
            this.dataColumnX.DefaultValue = 0;
            this.dataColumnX.Namespace = "";
            // 
            // dataColumnY
            // 
            this.dataColumnY.ColumnName = "Y";
            this.dataColumnY.DataType = typeof(int);
            this.dataColumnY.DefaultValue = 0;
            this.dataColumnY.Namespace = "";
            // 
            // dataColumnZ
            // 
            this.dataColumnZ.ColumnName = "Z";
            this.dataColumnZ.DataType = typeof(int);
            this.dataColumnZ.DefaultValue = 0;
            this.dataColumnZ.Namespace = "";
            // 
            // dataColumnRegion
            // 
            this.dataColumnRegion.ColumnName = "Region";
            this.dataColumnRegion.DataType = typeof(int);
            this.dataColumnRegion.DefaultValue = 0;
            this.dataColumnRegion.Namespace = "";
            // 
            // dataColumnMobID
            // 
            this.dataColumnMobID.AllowDBNull = false;
            this.dataColumnMobID.AutoIncrement = true;
            this.dataColumnMobID.Caption = "MobID";
            this.dataColumnMobID.ColumnName = "MobID";
            this.dataColumnMobID.DataType = typeof(int);
            this.dataColumnMobID.Namespace = "";
            // 
            // dataColumnClassType
            // 
            this.dataColumnClassType.ColumnName = "ClassType";
            this.dataColumnClassType.DefaultValue = "DOL.GS.GameNPC";
            this.dataColumnClassType.Namespace = "";
            // 
            // dataColumnSpeed
            // 
            this.dataColumnSpeed.ColumnName = "Speed";
            this.dataColumnSpeed.DataType = typeof(int);
            this.dataColumnSpeed.DefaultValue = 191;
            // 
            // dataColumnHeading
            // 
            this.dataColumnHeading.ColumnName = "Heading";
            this.dataColumnHeading.DataType = typeof(int);
            this.dataColumnHeading.DefaultValue = 0;
            this.dataColumnHeading.Namespace = "";
            // 
            // dataColumnSize
            // 
            this.dataColumnSize.ColumnName = "Size";
            this.dataColumnSize.DataType = typeof(byte);
            this.dataColumnSize.DefaultValue = ((byte)(50));
            this.dataColumnSize.Namespace = "";
            // 
            // dataColumnEquipmentTemplateID
            // 
            this.dataColumnEquipmentTemplateID.ColumnName = "EquipmentTemplateID";
            this.dataColumnEquipmentTemplateID.DefaultValue = "0";
            this.dataColumnEquipmentTemplateID.Namespace = "";
            // 
            // dataColumnFlags
            // 
            this.dataColumnFlags.ColumnName = "Flags";
            this.dataColumnFlags.DataType = typeof(byte);
            this.dataColumnFlags.DefaultValue = ((byte)(0));
            this.dataColumnFlags.Namespace = "";
            // 
            // dataColumnAggroLevel
            // 
            this.dataColumnAggroLevel.ColumnName = "AggroLevel";
            this.dataColumnAggroLevel.DataType = typeof(int);
            this.dataColumnAggroLevel.DefaultValue = 0;
            // 
            // dataColumnAggroRange
            // 
            this.dataColumnAggroRange.ColumnName = "AggroRange";
            this.dataColumnAggroRange.DataType = typeof(int);
            this.dataColumnAggroRange.DefaultValue = 0;
            // 
            // dataColumnMobRealm
            // 
            this.dataColumnMobRealm.ColumnName = "Realm";
            this.dataColumnMobRealm.DataType = typeof(byte);
            this.dataColumnMobRealm.DefaultValue = ((byte)(0));
            // 
            // dataColumnMobRespawnInterval
            // 
            this.dataColumnMobRespawnInterval.ColumnName = "RespawnInterval";
            this.dataColumnMobRespawnInterval.DataType = typeof(int);
            this.dataColumnMobRespawnInterval.DefaultValue = 0;
            this.dataColumnMobRespawnInterval.Namespace = "";
            // 
            // dataColumnMobFactionID
            // 
            this.dataColumnMobFactionID.ColumnName = "FactionID";
            this.dataColumnMobFactionID.DataType = typeof(int);
            this.dataColumnMobFactionID.Namespace = "";
            // 
            // dataColumnMobMeleeDamageType
            // 
            this.dataColumnMobMeleeDamageType.ColumnName = "DamageType";
            this.dataColumnMobMeleeDamageType.DataType = typeof(int);
            this.dataColumnMobMeleeDamageType.DefaultValue = 2;
            // 
            // dataColumnMobItemsListTemplateID
            // 
            this.dataColumnMobItemsListTemplateID.ColumnName = "ItemsListTemplateID";
            // 
            // dataColumnAddToworld
            // 
            this.dataColumnAddToworld.ColumnName = "AddToWorld";
            this.dataColumnAddToworld.DataType = typeof(bool);
            this.dataColumnAddToworld.DefaultValue = true;
            this.dataColumnAddToworld.Namespace = "";
            // 
            // dataColumnObjectName
            // 
            this.dataColumnObjectName.AllowDBNull = false;
            this.dataColumnObjectName.ColumnName = "ObjectName";
            this.dataColumnObjectName.DefaultValue = "objectName";
            // 
            // dataTableItemTemplate
            // 
            this.dataTableItemTemplate.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnIdNb,
            this.dataColumnItemName,
            this.dataColumnItemLevel,
            this.dataColumnDurability,
            this.dataColumnMaxDurability,
            this.dataColumnCondition,
            this.dataColumnMaxcondition,
            this.dataColumnQuality,
            this.dataColumnDPS_AF,
            this.dataColumnSPD_ABS,
            this.dataColumnHand,
            this.dataColumnTypeDamage,
            this.dataColumnObjectType,
            this.dataColumnItemType,
            this.dataColumnWeight,
            this.dataColumnItemModel,
            this.dataColumnRealm,
            this.dataColumnIsPickable,
            this.dataColumnIsDropable,
            dataColumnCanDropAsLoot,
            dataColumnIsTradable,
            this.dataColumnBonus,
            this.dataColumnBonus1,
            this.dataColumnBonus1Type,
            this.dataColumnBonus2,
            this.dataColumnBonus2Type,
            this.dataColumnBonus3,
            this.dataColumnBonus3Type,
            this.dataColumnBonus4,
            this.dataColumnBonus4Type,
            this.dataColumnBonus5,
            this.dataColumnBonus5Type,
            dataColumnBonus6,
            dataColumnBonus6Type,
            dataColumnBonus7,
            dataColumnBonus7Type,
            dataColumnBonus8,
            dataColumnBonus8Type,
            dataColumnBonus9,
            dataColumnBonus9Type,
            dataColumnBonus10,
            dataColumnBonus10Type,
            this.dataColumnExtraBonus,
            this.dataColumnExtraBonusType,
            this.dataColumnColor,
            dataColumnPlatinum,
            dataColumnGold,
            dataColumnSilver,
            dataColumnCopper,
            dataColumnEmblem,
            dataColumnEffect,
            dataColumnExtension,
            dataColumn73,
            dataColumnPackSize,
            dataColumnCharges,
            dataColumnMaxCount,
            dataColumnSpellID,
            dataColumnProcSpellID,
            dataColumnPoisonCharges,
            dataColumnPoisonMaxCharges,
            dataColumnPoisonSpellID,
            dataColumnSpellID1,
            dataColumnProcSpellID1,
            dataColumnCharges1,
            dataColumnMaxCharges1});
            this.dataTableItemTemplate.TableName = "ItemTemplate";
            // 
            // dataColumnIdNb
            // 
            this.dataColumnIdNb.AllowDBNull = false;
            this.dataColumnIdNb.Caption = "ID";
            this.dataColumnIdNb.ColumnName = "ItemTemplateID";
            // 
            // dataColumnItemName
            // 
            this.dataColumnItemName.ColumnName = "Name";
            this.dataColumnItemName.DefaultValue = "";
            // 
            // dataColumnItemLevel
            // 
            this.dataColumnItemLevel.ColumnName = "Level";
            this.dataColumnItemLevel.DataType = typeof(int);
            this.dataColumnItemLevel.DefaultValue = 1;
            // 
            // dataColumnDurability
            // 
            this.dataColumnDurability.ColumnName = "Durability";
            this.dataColumnDurability.DataType = typeof(int);
            this.dataColumnDurability.DefaultValue = 100;
            // 
            // dataColumnMaxDurability
            // 
            this.dataColumnMaxDurability.ColumnName = "MaxDurability";
            this.dataColumnMaxDurability.DataType = typeof(int);
            this.dataColumnMaxDurability.DefaultValue = 100;
            // 
            // dataColumnCondition
            // 
            this.dataColumnCondition.ColumnName = "Condition";
            this.dataColumnCondition.DataType = typeof(int);
            this.dataColumnCondition.DefaultValue = 100;
            // 
            // dataColumnMaxcondition
            // 
            this.dataColumnMaxcondition.ColumnName = "MaxCondition";
            this.dataColumnMaxcondition.DataType = typeof(int);
            this.dataColumnMaxcondition.DefaultValue = 100;
            // 
            // dataColumnQuality
            // 
            this.dataColumnQuality.ColumnName = "Quality";
            this.dataColumnQuality.DataType = typeof(int);
            this.dataColumnQuality.DefaultValue = 100;
            // 
            // dataColumnDPS_AF
            // 
            this.dataColumnDPS_AF.ColumnName = "DPS_AF";
            this.dataColumnDPS_AF.DataType = typeof(int);
            this.dataColumnDPS_AF.DefaultValue = 0;
            // 
            // dataColumnSPD_ABS
            // 
            this.dataColumnSPD_ABS.ColumnName = "SPD_ABS";
            this.dataColumnSPD_ABS.DataType = typeof(int);
            this.dataColumnSPD_ABS.DefaultValue = 0;
            // 
            // dataColumnHand
            // 
            this.dataColumnHand.ColumnName = "Hand";
            this.dataColumnHand.DataType = typeof(int);
            this.dataColumnHand.DefaultValue = 0;
            // 
            // dataColumnTypeDamage
            // 
            this.dataColumnTypeDamage.ColumnName = "Type_Damage";
            this.dataColumnTypeDamage.DataType = typeof(int);
            this.dataColumnTypeDamage.DefaultValue = 0;
            // 
            // dataColumnObjectType
            // 
            this.dataColumnObjectType.ColumnName = "Object_Type";
            this.dataColumnObjectType.DataType = typeof(int);
            this.dataColumnObjectType.DefaultValue = 0;
            // 
            // dataColumnItemType
            // 
            this.dataColumnItemType.ColumnName = "Item_Type";
            this.dataColumnItemType.DataType = typeof(int);
            this.dataColumnItemType.DefaultValue = 0;
            // 
            // dataColumnWeight
            // 
            this.dataColumnWeight.ColumnName = "Weight";
            this.dataColumnWeight.DataType = typeof(int);
            this.dataColumnWeight.DefaultValue = 1;
            // 
            // dataColumnItemModel
            // 
            this.dataColumnItemModel.ColumnName = "Model";
            this.dataColumnItemModel.DataType = typeof(int);
            this.dataColumnItemModel.DefaultValue = 488;
            // 
            // dataColumnRealm
            // 
            this.dataColumnRealm.ColumnName = "Realm";
            this.dataColumnRealm.DataType = typeof(int);
            this.dataColumnRealm.DefaultValue = 0;
            // 
            // dataColumnIsPickable
            // 
            this.dataColumnIsPickable.ColumnName = "IsPickable";
            this.dataColumnIsPickable.DataType = typeof(bool);
            this.dataColumnIsPickable.DefaultValue = true;
            // 
            // dataColumnIsDropable
            // 
            this.dataColumnIsDropable.ColumnName = "IsDropable";
            this.dataColumnIsDropable.DataType = typeof(bool);
            this.dataColumnIsDropable.DefaultValue = true;
            // 
            // dataColumnBonus
            // 
            this.dataColumnBonus.ColumnName = "Bonus";
            this.dataColumnBonus.DataType = typeof(int);
            this.dataColumnBonus.DefaultValue = 0;
            // 
            // dataColumnBonus1
            // 
            this.dataColumnBonus1.ColumnName = "Bonus1";
            this.dataColumnBonus1.DataType = typeof(int);
            this.dataColumnBonus1.DefaultValue = 0;
            // 
            // dataColumnBonus1Type
            // 
            this.dataColumnBonus1Type.ColumnName = "Bonus1Type";
            this.dataColumnBonus1Type.DataType = typeof(int);
            this.dataColumnBonus1Type.DefaultValue = 0;
            // 
            // dataColumnBonus2
            // 
            this.dataColumnBonus2.ColumnName = "Bonus2";
            this.dataColumnBonus2.DataType = typeof(int);
            this.dataColumnBonus2.DefaultValue = 0;
            // 
            // dataColumnBonus2Type
            // 
            this.dataColumnBonus2Type.ColumnName = "Bonus2Type";
            this.dataColumnBonus2Type.DataType = typeof(int);
            this.dataColumnBonus2Type.DefaultValue = 0;
            // 
            // dataColumnBonus3
            // 
            this.dataColumnBonus3.ColumnName = "Bonus3";
            this.dataColumnBonus3.DataType = typeof(int);
            this.dataColumnBonus3.DefaultValue = 0;
            // 
            // dataColumnBonus3Type
            // 
            this.dataColumnBonus3Type.ColumnName = "Bonus3Type";
            this.dataColumnBonus3Type.DataType = typeof(int);
            this.dataColumnBonus3Type.DefaultValue = 0;
            // 
            // dataColumnBonus4
            // 
            this.dataColumnBonus4.ColumnName = "Bonus4";
            this.dataColumnBonus4.DataType = typeof(int);
            this.dataColumnBonus4.DefaultValue = 0;
            // 
            // dataColumnBonus4Type
            // 
            this.dataColumnBonus4Type.ColumnName = "Bonus4Type";
            this.dataColumnBonus4Type.DataType = typeof(int);
            this.dataColumnBonus4Type.DefaultValue = 0;
            // 
            // dataColumnBonus5
            // 
            this.dataColumnBonus5.ColumnName = "Bonus5";
            this.dataColumnBonus5.DataType = typeof(int);
            this.dataColumnBonus5.DefaultValue = 0;
            // 
            // dataColumnBonus5Type
            // 
            this.dataColumnBonus5Type.ColumnName = "Bonus5Type";
            this.dataColumnBonus5Type.DataType = typeof(int);
            this.dataColumnBonus5Type.DefaultValue = 0;
            // 
            // dataColumnExtraBonus
            // 
            this.dataColumnExtraBonus.ColumnName = "ExtraBonus";
            this.dataColumnExtraBonus.DataType = typeof(int);
            this.dataColumnExtraBonus.DefaultValue = 0;
            // 
            // dataColumnExtraBonusType
            // 
            this.dataColumnExtraBonusType.ColumnName = "ExtraBonusType";
            this.dataColumnExtraBonusType.DataType = typeof(int);
            this.dataColumnExtraBonusType.DefaultValue = 0;
            // 
            // dataColumnColor
            // 
            this.dataColumnColor.ColumnName = "Color";
            this.dataColumnColor.DataType = typeof(int);
            this.dataColumnColor.DefaultValue = 0;
            // 
            // dataTableQuestStep
            // 
            this.dataTableQuestStep.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnStep,
            this.dataColumnStepDescription});
            this.dataTableQuestStep.TableName = "QuestStep";
            // 
            // dataColumnStep
            // 
            this.dataColumnStep.AllowDBNull = false;
            this.dataColumnStep.AutoIncrement = true;
            this.dataColumnStep.AutoIncrementSeed = ((long)(1));
            this.dataColumnStep.ColumnName = "Step";
            this.dataColumnStep.DataType = typeof(int);
            // 
            // dataColumnStepDescription
            // 
            this.dataColumnStepDescription.ColumnName = "Description";
            this.dataColumnStepDescription.DefaultValue = "";
            // 
            // dataTableArea
            // 
            this.dataTableArea.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            dataColumn39,
            dataColumn40,
            dataColumn42,
            dataColumn43,
            this.dataColumn44});
            this.dataTableArea.TableName = "Area";
            // 
            // dataColumn6
            // 
            this.dataColumn6.AllowDBNull = false;
            this.dataColumn6.ColumnName = "ObjectName";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Name";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "RegionID";
            this.dataColumn8.DataType = typeof(int);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "AreaType";
            this.dataColumn9.DefaultValue = "Circle";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "X";
            this.dataColumn10.DataType = typeof(int);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "Y";
            this.dataColumn11.DataType = typeof(int);
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "Z";
            this.dataColumn12.DataType = typeof(int);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "R";
            this.dataColumn13.DataType = typeof(int);
            // 
            // dataColumn44
            // 
            this.dataColumn44.AllowDBNull = false;
            this.dataColumn44.ColumnName = "CheckLOS";
            this.dataColumn44.DataType = typeof(bool);
            this.dataColumn44.DefaultValue = false;
            // 
            // dataTableLocation
            // 
            this.dataTableLocation.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumn15,
            dataColumn16,
            dataColumn17,
            dataColumn18,
            dataColumn19,
            dataColumn20,
            dataColumn21,
            dataColumn22});
            this.dataTableLocation.TableName = "Location";
            // 
            // dataSetData
            // 
            this.dataSetData.DataSetName = "QuestData";
            this.dataSetData.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTableRegion,
            this.dataTableZone,
            this.dataTableTriggerType,
            this.dataTableActionType,
            this.dataTableRequirementType,
            this.dataTableeEnumeration});
            this.dataSetData.Initialized += new System.EventHandler(this.dataSetData_Initialized);
            // 
            // dataTableRegion
            // 
            this.dataTableRegion.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnRegionID,
            dataColumnRegionDescription});
            this.dataTableRegion.TableName = "Region";
            // 
            // dataTableZone
            // 
            this.dataTableZone.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnZoneID,
            dataColumnZoneRegionID,
            dataColumnZoneDescription,
            dataColumnZoneOffsetY,
            dataColumnZoneOffsetX,
            dataColumn28,
            dataColumn32});
            this.dataTableZone.TableName = "Zone";
            // 
            // dataTableTriggerType
            // 
            this.dataTableTriggerType.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnTriggerTypeValue,
            this.dataColumnTriggerTypeDescription,
            this.dataColumnTriggerTypeHelp,
            this.dataColumnTriggerTypeK,
            this.dataColumnTriggerTypeI,
            this.dataColumnTriggerTypeID,
            dataColumnText,
            dataColumn33});
            this.dataTableTriggerType.TableName = "TriggerType";
            // 
            // dataColumnTriggerTypeValue
            // 
            this.dataColumnTriggerTypeValue.ColumnName = "value";
            // 
            // dataColumnTriggerTypeDescription
            // 
            this.dataColumnTriggerTypeDescription.ColumnName = "description";
            // 
            // dataColumnTriggerTypeHelp
            // 
            this.dataColumnTriggerTypeHelp.ColumnName = "help";
            // 
            // dataColumnTriggerTypeK
            // 
            this.dataColumnTriggerTypeK.ColumnName = "k";
            // 
            // dataColumnTriggerTypeI
            // 
            this.dataColumnTriggerTypeI.ColumnName = "i";
            // 
            // dataColumnTriggerTypeID
            // 
            this.dataColumnTriggerTypeID.ColumnName = "id";
            this.dataColumnTriggerTypeID.DataType = typeof(int);
            // 
            // dataTableActionType
            // 
            this.dataTableActionType.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnActionTypeValue,
            this.dataColumnActionTypeDescription,
            this.dataColumnActionTypeHelp,
            this.dataColumnActionTypeP,
            this.dataColumnActionTypeQ,
            this.dataColumnActionTypeID,
            this.dataColumn25,
            dataColumn34});
            this.dataTableActionType.TableName = "ActionType";
            // 
            // dataColumnActionTypeValue
            // 
            this.dataColumnActionTypeValue.ColumnName = "value";
            // 
            // dataColumnActionTypeDescription
            // 
            this.dataColumnActionTypeDescription.ColumnName = "description";
            // 
            // dataColumnActionTypeHelp
            // 
            this.dataColumnActionTypeHelp.ColumnName = "help";
            // 
            // dataColumnActionTypeP
            // 
            this.dataColumnActionTypeP.ColumnName = "p";
            // 
            // dataColumnActionTypeQ
            // 
            this.dataColumnActionTypeQ.ColumnName = "q";
            // 
            // dataColumnActionTypeID
            // 
            this.dataColumnActionTypeID.ColumnName = "id";
            this.dataColumnActionTypeID.DataType = typeof(int);
            // 
            // dataColumn25
            // 
            this.dataColumn25.Caption = "Text";
            this.dataColumn25.ColumnName = "text";
            this.dataColumn25.DefaultValue = "";
            // 
            // dataTableRequirementType
            // 
            this.dataTableRequirementType.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnRequirementTypeValue,
            this.dataColumnRequirementTypeDescription,
            this.dataColumnRequirementTypeHelp,
            this.dataColumnRequirementTypeN,
            this.dataColumnRequirementTypeV,
            this.dataColumnRequirementTypeID,
            this.dataColumn24,
            this.dataColumn27,
            dataColumn35});
            this.dataTableRequirementType.TableName = "RequirementType";
            // 
            // dataColumnRequirementTypeValue
            // 
            this.dataColumnRequirementTypeValue.ColumnName = "value";
            // 
            // dataColumnRequirementTypeDescription
            // 
            this.dataColumnRequirementTypeDescription.ColumnName = "description";
            // 
            // dataColumnRequirementTypeHelp
            // 
            this.dataColumnRequirementTypeHelp.ColumnName = "help";
            // 
            // dataColumnRequirementTypeN
            // 
            this.dataColumnRequirementTypeN.ColumnName = "n";
            // 
            // dataColumnRequirementTypeV
            // 
            this.dataColumnRequirementTypeV.ColumnName = "v";
            // 
            // dataColumnRequirementTypeID
            // 
            this.dataColumnRequirementTypeID.ColumnName = "id";
            this.dataColumnRequirementTypeID.DataType = typeof(int);
            // 
            // dataColumn24
            // 
            this.dataColumn24.Caption = "Text";
            this.dataColumn24.ColumnName = "text";
            this.dataColumn24.DefaultValue = "";
            // 
            // dataColumn27
            // 
            this.dataColumn27.Caption = "Comparator";
            this.dataColumn27.ColumnName = "comparator";
            // 
            // dataTableeEnumeration
            // 
            this.dataTableeEnumeration.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnEnumerationType,
            this.dataColumnEnumerationValue,
            this.dataColumnEnumerationName,
            this.dataColumnEnumerationDescription});
            this.dataTableeEnumeration.TableName = "eEnumeration";
            // 
            // dataColumnEnumerationType
            // 
            this.dataColumnEnumerationType.ColumnMapping = System.Data.MappingType.Attribute;
            this.dataColumnEnumerationType.ColumnName = "Type";
            // 
            // dataColumnEnumerationValue
            // 
            this.dataColumnEnumerationValue.ColumnName = "Value";
            // 
            // dataColumnEnumerationName
            // 
            this.dataColumnEnumerationName.ColumnName = "Name";
            // 
            // dataColumnEnumerationDescription
            // 
            this.dataColumnEnumerationDescription.ColumnName = "Description";
            // 
            // dataColumnRealmValue
            // 
            this.dataColumnRealmValue.ColumnName = "value";
            this.dataColumnRealmValue.DataType = typeof(byte);
            // 
            // dataColumnRealmDescription
            // 
            this.dataColumnRealmDescription.ColumnName = "description";
            // 
            // dataColumnTextTypeValue
            // 
            this.dataColumnTextTypeValue.ColumnName = "value";
            this.dataColumnTextTypeValue.DataType = typeof(int);
            // 
            // dataColumnTextTypeDescription
            // 
            this.dataColumnTextTypeDescription.Caption = "description";
            this.dataColumnTextTypeDescription.ColumnName = "description";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "value";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "description";
            // 
            // dataColumn54
            // 
            this.dataColumn54.ColumnName = "value";
            this.dataColumn54.DataType = typeof(int);
            // 
            // dataColumn55
            // 
            this.dataColumn55.ColumnName = "description";
            // 
            // dataColumn56
            // 
            this.dataColumn56.ColumnName = "value";
            this.dataColumn56.DataType = typeof(int);
            // 
            // dataColumn57
            // 
            this.dataColumn57.ColumnName = "description";
            // 
            // dataColumn60
            // 
            this.dataColumn60.ColumnName = "value";
            this.dataColumn60.DataType = typeof(int);
            // 
            // dataColumn61
            // 
            this.dataColumn61.ColumnName = "description";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "value";
            this.dataColumn4.DataType = typeof(int);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "description";
            // 
            // saveQuestDialog
            // 
            this.saveQuestDialog.DefaultExt = "qst";
            resources.ApplyResources(this.saveQuestDialog, "saveQuestDialog");
            this.saveQuestDialog.RestoreDirectory = true;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.AccessibleDescription = null;
            this.BottomToolStripPanel.AccessibleName = null;
            resources.ApplyResources(this.BottomToolStripPanel, "BottomToolStripPanel");
            this.BottomToolStripPanel.BackgroundImage = null;
            this.BottomToolStripPanel.Font = null;
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolTip.SetToolTip(this.BottomToolStripPanel, resources.GetString("BottomToolStripPanel.ToolTip"));
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.AccessibleDescription = null;
            this.TopToolStripPanel.AccessibleName = null;
            resources.ApplyResources(this.TopToolStripPanel, "TopToolStripPanel");
            this.TopToolStripPanel.BackgroundImage = null;
            this.TopToolStripPanel.Font = null;
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolTip.SetToolTip(this.TopToolStripPanel, resources.GetString("TopToolStripPanel.ToolTip"));
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.AccessibleDescription = null;
            this.RightToolStripPanel.AccessibleName = null;
            resources.ApplyResources(this.RightToolStripPanel, "RightToolStripPanel");
            this.RightToolStripPanel.BackgroundImage = null;
            this.RightToolStripPanel.Font = null;
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolTip.SetToolTip(this.RightToolStripPanel, resources.GetString("RightToolStripPanel.ToolTip"));
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.AccessibleDescription = null;
            this.LeftToolStripPanel.AccessibleName = null;
            resources.ApplyResources(this.LeftToolStripPanel, "LeftToolStripPanel");
            this.LeftToolStripPanel.BackgroundImage = null;
            this.LeftToolStripPanel.Font = null;
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolTip.SetToolTip(this.LeftToolStripPanel, resources.GetString("LeftToolStripPanel.ToolTip"));
            // 
            // ContentPanel
            // 
            this.ContentPanel.AccessibleDescription = null;
            this.ContentPanel.AccessibleName = null;
            resources.ApplyResources(this.ContentPanel, "ContentPanel");
            this.ContentPanel.BackgroundImage = null;
            this.ContentPanel.Font = null;
            this.toolTip.SetToolTip(this.ContentPanel, resources.GetString("ContentPanel.ToolTip"));
            // 
            // openQuestDialog
            // 
            this.openQuestDialog.DefaultExt = "qst";
            resources.ApplyResources(this.openQuestDialog, "openQuestDialog");
            this.openQuestDialog.RestoreDirectory = true;
            // 
            // saveScriptDialog
            // 
            resources.ApplyResources(this.saveScriptDialog, "saveScriptDialog");
            this.saveScriptDialog.RestoreDirectory = true;
            // 
            // QuestDesignerForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.toolStripContainerForm);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "MainformLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("Size", global::DOL.Tools.QuestDesigner.Properties.Settings.Default, "MainformSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Font = null;
            this.Location = global::DOL.Tools.QuestDesigner.Properties.Settings.Default.MainformLocation;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "QuestDesignerForm";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.QuestDesignerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(dataTableQuestCharacterClass)).EndInit();
            this.toolStripContainerForm.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainerForm.BottomToolStripPanel.PerformLayout();
            this.toolStripContainerForm.ContentPanel.ResumeLayout(false);
            this.toolStripContainerForm.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainerForm.TopToolStripPanel.PerformLayout();
            this.toolStripContainerForm.ResumeLayout(false);
            this.toolStripContainerForm.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlMain)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageQuest.ResumeLayout(false);
            this.tabPageNPC.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.tabPageQuestPart.ResumeLayout(false);
            this.tabPageArea.ResumeLayout(false);
            this.tabPageLocation.ResumeLayout(false);
            this.tabPageCode.ResumeLayout(false);
            this.tabPageMap.ResumeLayout(false);
            this.tabPageWeb.ResumeLayout(false);
            this.xpTaskPane.ResumeLayout(false);
            this.xpTGActions.ResumeLayout(false);
            this.xpTGActions.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetQuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuestPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTrigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRequirement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableMob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableItemTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableQuestStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableTriggerType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableActionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRequirementType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableeEnumeration)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

		private System.Data.DataColumn dataColumnName;
        private System.Data.DataColumn dataColumnModel;
        private System.Data.DataColumn dataColumnGuildName;
        private System.Data.DataColumn dataColumnLevel;
        private System.Data.DataColumn dataColumnX;
        private System.Data.DataColumn dataColumnY;
        private System.Data.DataColumn dataColumnZ;
        private System.Data.DataColumn dataColumnRegion;
        private System.Windows.Forms.SaveFileDialog saveQuestDialog;
        private System.Data.DataColumn dataColumnMobID;
        private System.Data.DataColumn dataColumnClassType;
        private System.Data.DataColumn dataColumnSpeed;
        private System.Data.DataColumn dataColumnHeading;
        private System.Data.DataColumn dataColumnSize;
        private System.Data.DataColumn dataColumnEquipmentTemplateID;
        private System.Data.DataColumn dataColumnFlags;
        private System.Data.DataColumn dataColumnAggroLevel;
        private System.Data.DataColumn dataColumnAggroRange;
		private System.Data.DataTable dataTableRegion;
		private System.Data.DataTable dataTableZone;
        private System.Data.DataColumn dataColumnIdNb;
        private System.Data.DataColumn dataColumnItemName;
        private System.Data.DataColumn dataColumnItemLevel;
        private System.Data.DataTable dataTableQuestPart;
        public System.Data.DataSet dataSetQuest;
        public System.Data.DataSet dataSetData;
        public System.Data.DataTable dataTableTrigger;
		public System.Data.DataTable dataTableRequirement;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainerForm;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.OpenFileDialog openQuestDialog;
        public System.Data.DataTable dataTableQuest;
		public System.Data.DataTable dataTableAction;
        private System.Data.DataColumn dataColumnTriggerTypeValue;
		private System.Data.DataColumn dataColumnTriggerTypeDescription;
        private System.Data.DataColumn dataColumnActionTypeValue;
		private System.Data.DataColumn dataColumnActionTypeDescription;
        private System.Data.DataColumn dataColumnRequirementTypeValue;
		private System.Data.DataColumn dataColumnRequirementTypeDescription;
        private System.Data.DataColumn dataColumnRealmValue;
		private System.Data.DataColumn dataColumnRealmDescription;
        private System.Data.DataColumn dataColumnTextTypeValue;
		private System.Data.DataColumn dataColumnTextTypeDescription;
        private System.Data.DataColumn dataColumnMobRealm;
        private System.Data.DataColumn dataColumnMobRespawnInterval;
        private System.Data.DataColumn dataColumnMobFactionID;
        private System.Data.DataColumn dataColumnMobMeleeDamageType;
		private System.Data.DataColumn dataColumnMobItemsListTemplateID;
        private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumnDurability;
        private System.Data.DataColumn dataColumnMaxDurability;
        private System.Data.DataColumn dataColumnCondition;
        private System.Data.DataColumn dataColumnMaxcondition;
        private System.Data.DataColumn dataColumnQuality;
        private System.Data.DataColumn dataColumnDPS_AF;
        private System.Data.DataColumn dataColumnSPD_ABS;
        private System.Data.DataColumn dataColumnHand;
        private System.Data.DataColumn dataColumnTypeDamage;
        private System.Data.DataTable dataTableQuestStep;
        private System.Data.DataColumn dataColumnStep;
		private System.Data.DataColumn dataColumnStepDescription;
        private System.Data.DataColumn dataColumnObjectType;
        private System.Data.DataColumn dataColumnItemType;
        private System.Data.DataColumn dataColumnWeight;
        private System.Data.DataColumn dataColumnItemModel;
        private System.Data.DataColumn dataColumnRealm;
        private System.Data.DataColumn dataColumnIsPickable;
        private System.Data.DataColumn dataColumnIsDropable;
        private System.Data.DataColumn dataColumnBonus1;
        private System.Data.DataColumn dataColumnBonus1Type;
        private System.Data.DataColumn dataColumnBonus2;
        private System.Data.DataColumn dataColumnBonus2Type;
        private System.Data.DataColumn dataColumnBonus3;
        private System.Data.DataColumn dataColumnBonus3Type;
        private System.Data.DataColumn dataColumnBonus4;
		private System.Data.DataColumn dataColumnBonus4Type;
        private System.Data.DataColumn dataColumnBonus;
		private System.Data.DataColumn dataColumnColor;
        private System.Windows.Forms.SaveFileDialog saveScriptDialog;
        private System.Data.DataColumn dataColumnAddToworld;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Data.DataColumn dataColumnTriggerTypeHelp;
        private System.Data.DataColumn dataColumnActionTypeHelp;
		private System.Data.DataColumn dataColumnActionTypeP;
		private System.Windows.Forms.ToolTip toolTip;
        private System.Data.DataColumn dataColumnTriggerTypeK;
        private System.Data.DataColumn dataColumnTriggerTypeI;
        private System.Data.DataColumn dataColumnRequirementTypeHelp;
        private System.Data.DataColumn dataColumnRequirementTypeN;
		private System.Data.DataColumn dataColumnRequirementTypeV;
        private System.Data.DataColumn dataColumn54;
		private System.Data.DataColumn dataColumn55;
        private System.Data.DataColumn dataColumn56;
        private System.Data.DataColumn dataColumn57;
        private System.Data.DataColumn dataColumn60;
		private System.Data.DataColumn dataColumn61;
        private System.Data.DataColumn dataColumnActionTypeQ;
		public System.Data.DataTable dataTableTriggerType;
		public System.Data.DataTable dataTableActionType;
        public System.Data.DataTable dataTableRequirementType;
        public System.Windows.Forms.ToolStripProgressBar StatusProgress;
        private System.Data.DataColumn dataColumnBonus5;
        private System.Data.DataColumn dataColumnBonus5Type;
        private System.Data.DataColumn dataColumnExtraBonus;
        private System.Data.DataColumn dataColumnExtraBonusType;
		private System.Data.DataColumn dataColumnObjectName;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
		public System.Data.DataTable dataTableMob;
		public System.Data.DataTable dataTableItemTemplate;
		public System.Data.DataTable dataTableArea;
		public System.Windows.Forms.ToolStripStatusLabel StatusIcon;
		private System.Data.DataColumn dataColumnTriggerTypeID;
		private System.Data.DataColumn dataColumnActionTypeID;
		private System.Data.DataColumn dataColumnRequirementTypeID;
		private System.Data.DataColumn dataColumn29;
		private System.Data.DataColumn dataColumn30;
		private System.Data.DataColumn dataColumn31;
		private NETXP.Controls.Docking.TabControl tabControlMain;
		private NETXP.Controls.Docking.TabPage tabPageQuest;
		private NETXP.Controls.Docking.TabPage tabPageNPC;
		private NETXP.Controls.Docking.TabPage tabPageItem;
		private NETXP.Controls.Docking.TabPage tabPageQuestPart;
		private NETXP.Controls.Docking.TabPage tabPageArea;
        private NETXP.Controls.Docking.TabPage tabPageCode;
        private QuestInfo questInfo;
		private Item itemView;
		private CustomCode customCode;
		private NETXP.Controls.TaskPane.XPTaskPane xpTaskPane;
		private NETXP.Controls.TaskPane.XPTaskPaneGroup xpTGActions;
        private System.Windows.Forms.LinkLabel linkLoadQuest;
		private System.Windows.Forms.LinkLabel linkSaveQuest;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTaskPane;
		private System.Data.DataColumn dataColumnEnumerationValue;
		private System.Data.DataColumn dataColumnEnumerationName;
		private System.Data.DataColumn dataColumnEnumerationDescription;
		private System.Data.DataColumn dataColumnEnumerationType;
		public System.Data.DataTable dataTableeEnumeration;
		private QuestPartItems questPartItems;
		private System.Data.DataTable dataTableLocation;
        private NETXP.Controls.Docking.TabPage tabPageLocation;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem positionConverterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Data.DataColumn dataColumn25;
		private System.Data.DataColumn dataColumn24;
        private System.Data.DataColumn dataColumn27;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private Area areaView;
        private Location locationView;
        private NETXP.Controls.Docking.TabPage tabPageMap;
        public DOL.Tools.Mapping.Forms.DXControl DXControl;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataDownloadToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelNewQuest;
        private NETXP.Controls.TaskPane.XPTaskPaneGroup xpTGQuestPart;
        private System.Data.DataColumn dataColumn38;
        private System.Data.DataColumn dataColumn44;
        private NETXP.Controls.Docking.TabPage tabPageWeb;
        private DOL.Tools.QuestDesigner.QuestDesigner.WebBrowser webBrowser1;
        public NPC npcView;		
    }
}

