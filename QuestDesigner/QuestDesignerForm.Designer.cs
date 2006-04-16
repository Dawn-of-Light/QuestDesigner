namespace QuestDesigner
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
			QuestDesigner.Controls.HeaderStrip headerStripArea;
			System.Windows.Forms.ToolStripLabel toolStripLabelArea;
			QuestDesigner.Controls.HeaderStrip headerStripCustomCode;
			System.Windows.Forms.ToolStripLabel toolStripLabelCustomCode;
			System.Data.DataColumn dataColumnText;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestDesignerForm));
			NETXP.Controls.Docking.Renderers.Office2003 office20032 = new NETXP.Controls.Docking.Renderers.Office2003();
			NETXP.Library.DynamicColorTable dynamicColorTable3 = new NETXP.Library.DynamicColorTable();
			NETXP.Library.DynamicColorTable dynamicColorTable4 = new NETXP.Library.DynamicColorTable();
			this.dataSetQuest = new System.Data.DataSet();
			this.dataTableQuestPart = new System.Data.DataTable();
			this.dataTableTrigger = new System.Data.DataTable();
			this.dataColumn29 = new System.Data.DataColumn();
			this.dataTableRequirement = new System.Data.DataTable();
			this.dataColumn30 = new System.Data.DataColumn();
			this.dataTableAction = new System.Data.DataTable();
			this.dataColumn31 = new System.Data.DataColumn();
			this.dataTableQuest = new System.Data.DataTable();
			this.dataColumnQuestID = new System.Data.DataColumn();
			this.dataColumnQuestName = new System.Data.DataColumn();
			this.dataColumnQuestAuthor = new System.Data.DataColumn();
			this.dataColumnQuestDate = new System.Data.DataColumn();
			this.dataColumnQuestVersion = new System.Data.DataColumn();
			this.dataColumnQuestDescription = new System.Data.DataColumn();
			this.dataColumn14 = new System.Data.DataColumn();
			this.dataColumnMinimumLevel = new System.Data.DataColumn();
			this.dataColumnMaximumLevel = new System.Data.DataColumn();
			this.dataColumnInvintingNPC = new System.Data.DataColumn();
			this.dataColumn41 = new System.Data.DataColumn();
			this.dataColumn62 = new System.Data.DataColumn();
			this.dataColumn63 = new System.Data.DataColumn();
			this.dataColumn64 = new System.Data.DataColumn();
			this.dataColumn65 = new System.Data.DataColumn();
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
			this.dataColumnMaxQuality = new System.Data.DataColumn();
			this.dataColumnDPS_AF = new System.Data.DataColumn();
			this.dataColumnSPD_ABS = new System.Data.DataColumn();
			this.dataColumnHand = new System.Data.DataColumn();
			this.dataColumnTypeDamage = new System.Data.DataColumn();
			this.dataColumnObjectType = new System.Data.DataColumn();
			this.dataColumnItemType = new System.Data.DataColumn();
			this.dataColumnWeight = new System.Data.DataColumn();
			this.dataColumn26 = new System.Data.DataColumn();
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
			this.dataColumnGold = new System.Data.DataColumn();
			this.dataColumnSilver = new System.Data.DataColumn();
			this.dataColumnCopper = new System.Data.DataColumn();
			this.dataColumnEmblem = new System.Data.DataColumn();
			this.dataColumnEffect = new System.Data.DataColumn();
			this.dataColumnModelExtension = new System.Data.DataColumn();
			this.dataColumn73 = new System.Data.DataColumn();
			this.dataColumn74 = new System.Data.DataColumn();
			this.dataColumn75 = new System.Data.DataColumn();
			this.dataColumnMaxCount = new System.Data.DataColumn();
			this.dataColumnSpellID = new System.Data.DataColumn();
			this.dataColumnProcSpellID = new System.Data.DataColumn();
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
			this.dataTableLocation = new System.Data.DataTable();
			this.dataColumn23 = new System.Data.DataColumn();
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
			this.dataTableHand = new System.Data.DataTable();
			this.dataColumnHandValue = new System.Data.DataColumn();
			this.dataColumnHandDescription = new System.Data.DataColumn();
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
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
			this.bindingSourceMob = new System.Windows.Forms.BindingSource(this.components);
			this.questPartItems = new QuestDesigner.QuestPartItems();
			this.bindingSourceTextType = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSourceRequirementType = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSourceComparator = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSourceActionType = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSourceTriggerType = new System.Windows.Forms.BindingSource(this.components);
			this.dataGridArea = new System.Windows.Forms.DataGridView();
			this.AreaObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AreaRegionID = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bindingSourceRegion = new System.Windows.Forms.BindingSource(this.components);
			this.AreaType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.bindingSourceArea = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripContainerForm = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusIcon = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tabControlMain = new NETXP.Controls.Docking.TabControl();
			this.tabPageQuest = new NETXP.Controls.Docking.TabPage();
			this.questInfo = new QuestDesigner.QuestInfo();
			this.tabPageNPC = new NETXP.Controls.Docking.TabPage();
			this.npcView = new QuestDesigner.NPC();
			this.tabPageItem = new NETXP.Controls.Docking.TabPage();
			this.itemView = new QuestDesigner.Item();
			this.tabPageQuestPart = new NETXP.Controls.Docking.TabPage();
			this.tabPageArea = new NETXP.Controls.Docking.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.propertyGridArea = new System.Windows.Forms.PropertyGrid();
			this.tabPageLocation = new NETXP.Controls.Docking.TabPage();
			this.splitContainerLocation = new System.Windows.Forms.SplitContainer();
			this.dataGridViewLocation = new System.Windows.Forms.DataGridView();
			this.LocationObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LocationRegionID = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.xDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.yDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.zDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.headingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bindingSourceLocation = new System.Windows.Forms.BindingSource(this.components);
			this.propertyGridLocation = new System.Windows.Forms.PropertyGrid();
			this.headerStrip3 = new QuestDesigner.Controls.HeaderStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tabPageCode = new NETXP.Controls.Docking.TabPage();
			this.customCode = new QuestDesigner.CustomCode();
			this.xpTaskPane = new NETXP.Controls.TaskPane.XPTaskPane();
			this.xpTGActions = new NETXP.Controls.TaskPane.XPTaskPaneGroup();
			this.linkSaveQuest = new System.Windows.Forms.LinkLabel();
			this.linkCreateQuest = new System.Windows.Forms.LinkLabel();
			this.linkLoadQuest = new System.Windows.Forms.LinkLabel();
			this.openQuestDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveScriptDialog = new System.Windows.Forms.SaveFileDialog();
			this.bindingSourceZone = new System.Windows.Forms.BindingSource(this.components);
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.imageListNPC = new System.Windows.Forms.ImageList(this.components);
			this.bindingSourceQuestPart = new System.Windows.Forms.BindingSource(this.components);
			this.bindingSourceEmote = new System.Windows.Forms.BindingSource(this.components);
			this.mapViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			headerStripArea = new QuestDesigner.Controls.HeaderStrip();
			toolStripLabelArea = new System.Windows.Forms.ToolStripLabel();
			headerStripCustomCode = new QuestDesigner.Controls.HeaderStrip();
			toolStripLabelCustomCode = new System.Windows.Forms.ToolStripLabel();
			dataColumnText = new System.Data.DataColumn();
			headerStripArea.SuspendLayout();
			headerStripCustomCode.SuspendLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.dataTableHand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTableeEnumeration)).BeginInit();
			this.menuStripMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceMob)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTextType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceRequirementType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceComparator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceActionType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTriggerType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridArea)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceArea)).BeginInit();
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
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPageLocation.SuspendLayout();
			this.splitContainerLocation.Panel1.SuspendLayout();
			this.splitContainerLocation.Panel2.SuspendLayout();
			this.splitContainerLocation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceLocation)).BeginInit();
			this.headerStrip3.SuspendLayout();
			this.tabPageCode.SuspendLayout();
			this.xpTaskPane.SuspendLayout();
			this.xpTGActions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceZone)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuestPart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmote)).BeginInit();
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
			dataColumn18.ColumnName = "X";
			dataColumn18.DataType = typeof(int);
			// 
			// dataColumn19
			// 
			dataColumn19.ColumnName = "Y";
			dataColumn19.DataType = typeof(int);
			// 
			// dataColumn20
			// 
			dataColumn20.ColumnName = "Z";
			dataColumn20.DataType = typeof(int);
			// 
			// dataColumn21
			// 
			dataColumn21.ColumnName = "Heading";
			dataColumn21.DataType = typeof(int);
			// 
			// dataColumn22
			// 
			dataColumn22.ColumnName = "ObjectName";
			// 
			// headerStripArea
			// 
			headerStripArea.AutoSize = false;
			headerStripArea.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			headerStripArea.ForeColor = System.Drawing.Color.Gray;
			headerStripArea.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			headerStripArea.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabelArea});
			headerStripArea.Location = new System.Drawing.Point(0, 0);
			headerStripArea.Name = "headerStripArea";
			headerStripArea.Size = new System.Drawing.Size(274, 25);
			headerStripArea.TabIndex = 1;
			headerStripArea.Text = "headerStrip1";
			// 
			// toolStripLabelArea
			// 
			toolStripLabelArea.Name = "toolStripLabelArea";
			toolStripLabelArea.Size = new System.Drawing.Size(53, 22);
			toolStripLabelArea.Text = "Areas";
			// 
			// headerStripCustomCode
			// 
			headerStripCustomCode.AutoSize = false;
			headerStripCustomCode.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			headerStripCustomCode.ForeColor = System.Drawing.Color.Gray;
			headerStripCustomCode.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			headerStripCustomCode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripLabelCustomCode});
			headerStripCustomCode.Location = new System.Drawing.Point(0, 0);
			headerStripCustomCode.Name = "headerStripCustomCode";
			headerStripCustomCode.Size = new System.Drawing.Size(472, 25);
			headerStripCustomCode.TabIndex = 2;
			headerStripCustomCode.Text = "headerStrip1";
			headerStripCustomCode.Visible = false;
			// 
			// toolStripLabelCustomCode
			// 
			toolStripLabelCustomCode.Name = "toolStripLabelCustomCode";
			toolStripLabelCustomCode.Size = new System.Drawing.Size(114, 22);
			toolStripLabelCustomCode.Text = "Custom Code";
			// 
			// dataColumnText
			// 
			dataColumnText.Caption = "Text";
			dataColumnText.ColumnName = "text";
			dataColumnText.DefaultValue = "";
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
            this.dataTableLocation});
			// 
			// dataTableQuestPart
			// 
			this.dataTableQuestPart.Columns.AddRange(new System.Data.DataColumn[] {
            dataColumnQuestPartIF});
			this.dataTableQuestPart.TableName = "QuestPart";
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
            this.dataColumnQuestID,
            this.dataColumnQuestName,
            this.dataColumnQuestAuthor,
            this.dataColumnQuestDate,
            this.dataColumnQuestVersion,
            this.dataColumnQuestDescription,
            this.dataColumn14,
            this.dataColumnMinimumLevel,
            this.dataColumnMaximumLevel,
            this.dataColumnInvintingNPC,
            this.dataColumn41,
            this.dataColumn62,
            this.dataColumn63,
            this.dataColumn64,
            this.dataColumn65});
			this.dataTableQuest.TableName = "Quest";
			// 
			// dataColumnQuestID
			// 
			this.dataColumnQuestID.AllowDBNull = false;
			this.dataColumnQuestID.AutoIncrement = true;
			this.dataColumnQuestID.ColumnName = "ID";
			this.dataColumnQuestID.DataType = typeof(int);
			// 
			// dataColumnQuestName
			// 
			this.dataColumnQuestName.ColumnName = "Name";
			// 
			// dataColumnQuestAuthor
			// 
			this.dataColumnQuestAuthor.ColumnName = "Author";
			// 
			// dataColumnQuestDate
			// 
			this.dataColumnQuestDate.ColumnName = "Date";
			this.dataColumnQuestDate.DataType = typeof(System.DateTime);
			// 
			// dataColumnQuestVersion
			// 
			this.dataColumnQuestVersion.ColumnName = "Version";
			this.dataColumnQuestVersion.DefaultValue = "0";
			// 
			// dataColumnQuestDescription
			// 
			this.dataColumnQuestDescription.ColumnName = "Description";
			// 
			// dataColumn14
			// 
			this.dataColumn14.ColumnName = "Title";
			// 
			// dataColumnMinimumLevel
			// 
			this.dataColumnMinimumLevel.ColumnName = "MinimumLevel";
			this.dataColumnMinimumLevel.DataType = typeof(int);
			this.dataColumnMinimumLevel.DefaultValue = 1;
			// 
			// dataColumnMaximumLevel
			// 
			this.dataColumnMaximumLevel.ColumnName = "MaximumLevel";
			this.dataColumnMaximumLevel.DataType = typeof(int);
			this.dataColumnMaximumLevel.DefaultValue = 1;
			// 
			// dataColumnInvintingNPC
			// 
			this.dataColumnInvintingNPC.ColumnName = "InvitingNPC";
			// 
			// dataColumn41
			// 
			this.dataColumn41.AllowDBNull = false;
			this.dataColumn41.ColumnName = "Namespace";
			this.dataColumn41.DefaultValue = "DOL.GS.Quests";
			// 
			// dataColumn62
			// 
			this.dataColumn62.ColumnName = "MaxQuestCount";
			this.dataColumn62.DefaultValue = "1";
			// 
			// dataColumn63
			// 
			this.dataColumn63.ColumnName = "ScriptLoadedCode";
			// 
			// dataColumn64
			// 
			this.dataColumn64.ColumnName = "ScriptUnloadedCode";
			// 
			// dataColumn65
			// 
			this.dataColumn65.ColumnName = "InitializationCode";
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
            this.dataColumnObjectName});
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
			this.dataColumnClassType.DefaultValue = "DOL.GS.GameMob";
			this.dataColumnClassType.Namespace = "";
			// 
			// dataColumnSpeed
			// 
			this.dataColumnSpeed.ColumnName = "Speed";
			this.dataColumnSpeed.DataType = typeof(int);
			this.dataColumnSpeed.DefaultValue = 100;
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
			this.dataColumnEquipmentTemplateID.Namespace = "";
			// 
			// dataColumnFlags
			// 
			this.dataColumnFlags.ColumnName = "Flags";
			this.dataColumnFlags.DataType = typeof(byte);
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
			this.dataColumnMobRespawnInterval.DefaultValue = -1;
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
			this.dataColumnObjectName.ColumnName = "ObjectName";
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
            this.dataColumnMaxQuality,
            this.dataColumnDPS_AF,
            this.dataColumnSPD_ABS,
            this.dataColumnHand,
            this.dataColumnTypeDamage,
            this.dataColumnObjectType,
            this.dataColumnItemType,
            this.dataColumnWeight,
            this.dataColumn26,
            this.dataColumnRealm,
            this.dataColumnIsPickable,
            this.dataColumnIsDropable,
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
            this.dataColumnExtraBonus,
            this.dataColumnExtraBonusType,
            this.dataColumnColor,
            this.dataColumnGold,
            this.dataColumnSilver,
            this.dataColumnCopper,
            this.dataColumnEmblem,
            this.dataColumnEffect,
            this.dataColumnModelExtension,
            this.dataColumn73,
            this.dataColumn74,
            this.dataColumn75,
            this.dataColumnMaxCount,
            this.dataColumnSpellID,
            this.dataColumnProcSpellID});
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
			// dataColumnMaxQuality
			// 
			this.dataColumnMaxQuality.ColumnName = "MaxQuality";
			this.dataColumnMaxQuality.DataType = typeof(int);
			this.dataColumnMaxQuality.DefaultValue = 100;
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
			// dataColumn26
			// 
			this.dataColumn26.ColumnName = "Model";
			this.dataColumn26.DataType = typeof(int);
			this.dataColumn26.DefaultValue = 0;
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
			// dataColumnGold
			// 
			this.dataColumnGold.ColumnName = "Gold";
			this.dataColumnGold.DataType = typeof(short);
			this.dataColumnGold.DefaultValue = ((short)(0));
			// 
			// dataColumnSilver
			// 
			this.dataColumnSilver.ColumnName = "Silver";
			this.dataColumnSilver.DataType = typeof(byte);
			this.dataColumnSilver.DefaultValue = ((byte)(0));
			// 
			// dataColumnCopper
			// 
			this.dataColumnCopper.ColumnName = "Copper";
			this.dataColumnCopper.DataType = typeof(byte);
			this.dataColumnCopper.DefaultValue = ((byte)(0));
			// 
			// dataColumnEmblem
			// 
			this.dataColumnEmblem.ColumnName = "Emblem";
			this.dataColumnEmblem.DataType = typeof(int);
			// 
			// dataColumnEffect
			// 
			this.dataColumnEffect.ColumnName = "Effect";
			this.dataColumnEffect.DataType = typeof(int);
			// 
			// dataColumnModelExtension
			// 
			this.dataColumnModelExtension.ColumnName = "ModelExtension";
			this.dataColumnModelExtension.DataType = typeof(byte);
			// 
			// dataColumn73
			// 
			this.dataColumn73.ColumnName = "MaxCount";
			this.dataColumn73.DataType = typeof(int);
			// 
			// dataColumn74
			// 
			this.dataColumn74.ColumnName = "PackSize";
			this.dataColumn74.DataType = typeof(int);
			// 
			// dataColumn75
			// 
			this.dataColumn75.ColumnName = "Charges";
			this.dataColumn75.DataType = typeof(int);
			// 
			// dataColumnMaxCount
			// 
			this.dataColumnMaxCount.ColumnName = "MaxCharges";
			this.dataColumnMaxCount.DataType = typeof(int);
			// 
			// dataColumnSpellID
			// 
			this.dataColumnSpellID.ColumnName = "SpellID";
			this.dataColumnSpellID.DataType = typeof(int);
			// 
			// dataColumnProcSpellID
			// 
			this.dataColumnProcSpellID.ColumnName = "ProcSpellID";
			this.dataColumnProcSpellID.DataType = typeof(int);
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
            this.dataColumn13});
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
            dataColumn22,
            this.dataColumn23});
			this.dataTableLocation.TableName = "Location";
			// 
			// dataColumn23
			// 
			this.dataColumn23.Caption = "Zone";
			this.dataColumn23.ColumnName = "ZoneID";
			this.dataColumn23.DataType = typeof(int);
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
            this.dataTableHand,
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
            dataColumnZoneOffsetX});
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
            dataColumnText});
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
            this.dataColumn25});
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
            this.dataColumn27});
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
			// dataTableHand
			// 
			this.dataTableHand.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumnHandValue,
            this.dataColumnHandDescription});
			this.dataTableHand.TableName = "Hand";
			// 
			// dataColumnHandValue
			// 
			this.dataColumnHandValue.ColumnName = "value";
			this.dataColumnHandValue.DataType = typeof(int);
			// 
			// dataColumnHandDescription
			// 
			this.dataColumnHandDescription.ColumnName = "description";
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
			this.dataColumnEnumerationType.ColumnName = "Type";
			// 
			// dataColumnEnumerationValue
			// 
			this.dataColumnEnumerationValue.ColumnName = "Value";
			this.dataColumnEnumerationValue.DataType = typeof(int);
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
			this.saveQuestDialog.Filter = "Quest Data Files|*.qst";
			this.saveQuestDialog.RestoreDirectory = true;
			this.saveQuestDialog.Title = "Save Quest";
			// 
			// BottomToolStripPanel
			// 
			this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// TopToolStripPanel
			// 
			this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// menuStripMain
			// 
			this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(446, 24);
			this.menuStripMain.TabIndex = 1;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
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
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(146, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
			// 
			// createToolStripMenuItem
			// 
			this.createToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createToolStripMenuItem.Image")));
			this.createToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.createToolStripMenuItem.Name = "createToolStripMenuItem";
			this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.createToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.createToolStripMenuItem.Text = "&Create";
			this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemTaskPane});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// toolStripMenuItemTaskPane
			// 
			this.toolStripMenuItemTaskPane.Checked = true;
			this.toolStripMenuItemTaskPane.CheckOnClick = true;
			this.toolStripMenuItemTaskPane.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripMenuItemTaskPane.Name = "toolStripMenuItemTaskPane";
			this.toolStripMenuItemTaskPane.Size = new System.Drawing.Size(161, 22);
			this.toolStripMenuItemTaskPane.Text = "Show TaskPane";
			this.toolStripMenuItemTaskPane.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.toolStripMenuItemTaskPane.CheckStateChanged += new System.EventHandler(this.toolStripMenuItemTaskPane_CheckStateChanged);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.positionConverterToolStripMenuItem,
            this.mapViewerToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// positionConverterToolStripMenuItem
			// 
			this.positionConverterToolStripMenuItem.Image = global::QuestDesigner.Properties.Resources.globe;
			this.positionConverterToolStripMenuItem.Name = "positionConverterToolStripMenuItem";
			this.positionConverterToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.positionConverterToolStripMenuItem.Text = "Position Converter...";
			this.positionConverterToolStripMenuItem.Click += new System.EventHandler(this.positionConverterToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(25, 20);
			this.toolStripMenuItem1.Text = "?";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// RightToolStripPanel
			// 
			this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// LeftToolStripPanel
			// 
			this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// ContentPanel
			// 
			this.ContentPanel.AutoScroll = true;
			this.ContentPanel.Size = new System.Drawing.Size(636, 305);
			// 
			// bindingSourceMob
			// 
			this.bindingSourceMob.DataMember = "Mob";
			this.bindingSourceMob.DataSource = this.dataSetQuest;
			// 
			// questPartItems
			// 
			this.questPartItems.ActionColor = System.Drawing.Color.RosyBrown;
			this.questPartItems.ActionSelectedColor = System.Drawing.Color.OrangeRed;
			this.questPartItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.questPartItems.ForeColor = System.Drawing.Color.Gray;
			this.questPartItems.ForeColorSelected = System.Drawing.Color.Black;
			this.questPartItems.Location = new System.Drawing.Point(0, 0);
			this.questPartItems.Name = "questPartItems";
			this.questPartItems.RequirementColor = System.Drawing.Color.Tan;
			this.questPartItems.RequirementSelectedColor = System.Drawing.Color.Orange;
			this.questPartItems.Size = new System.Drawing.Size(274, 236);
			this.questPartItems.TabIndex = 0;
			this.questPartItems.TriggerColor = System.Drawing.Color.Olive;
			this.questPartItems.TriggerSelectedColor = System.Drawing.Color.Green;
			// 
			// bindingSourceTextType
			// 
			this.bindingSourceTextType.AllowNew = false;
			this.bindingSourceTextType.DataMember = "eEnumeration";
			this.bindingSourceTextType.DataSource = this.dataSetData;
			this.bindingSourceTextType.Filter = "Type=\'eTextType\'";
			this.bindingSourceTextType.Sort = "Description";
			// 
			// bindingSourceRequirementType
			// 
			this.bindingSourceRequirementType.DataMember = "RequirementType";
			this.bindingSourceRequirementType.DataSource = this.dataSetData;
			// 
			// bindingSourceComparator
			// 
			this.bindingSourceComparator.DataMember = "eEnumeration";
			this.bindingSourceComparator.DataSource = this.dataSetData;
			this.bindingSourceComparator.Filter = "Type=\'eComparator\'";
			this.bindingSourceComparator.Sort = "Value";
			// 
			// bindingSourceActionType
			// 
			this.bindingSourceActionType.DataMember = "ActionType";
			this.bindingSourceActionType.DataSource = this.dataSetData;
			// 
			// bindingSourceTriggerType
			// 
			this.bindingSourceTriggerType.DataMember = "TriggerType";
			this.bindingSourceTriggerType.DataSource = this.dataSetData;
			// 
			// dataGridArea
			// 
			this.dataGridArea.AutoGenerateColumns = false;
			this.dataGridArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AreaObjectName,
            this.AreaName,
            this.AreaRegionID,
            this.AreaType});
			this.dataGridArea.DataSource = this.bindingSourceArea;
			this.dataGridArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridArea.Location = new System.Drawing.Point(0, 0);
			this.dataGridArea.Name = "dataGridArea";
			this.dataGridArea.Size = new System.Drawing.Size(149, 211);
			this.dataGridArea.TabIndex = 0;
			this.dataGridArea.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridArea_RowValidating);
			this.dataGridArea.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridArea_DefaultValuesNeeded);
			this.dataGridArea.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridArea_DataError);
			this.dataGridArea.SelectionChanged += new System.EventHandler(this.dataGridArea_SelectionChanged);
			// 
			// AreaObjectName
			// 
			this.AreaObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AreaObjectName.DataPropertyName = "ObjectName";
			this.AreaObjectName.HeaderText = "ObjectName";
			this.AreaObjectName.Name = "AreaObjectName";
			// 
			// AreaName
			// 
			this.AreaName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AreaName.DataPropertyName = "Name";
			this.AreaName.HeaderText = "Name";
			this.AreaName.Name = "AreaName";
			// 
			// AreaRegionID
			// 
			this.AreaRegionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AreaRegionID.DataPropertyName = "RegionID";
			this.AreaRegionID.DataSource = this.bindingSourceRegion;
			this.AreaRegionID.DisplayMember = "description";
			this.AreaRegionID.FillWeight = 80F;
			this.AreaRegionID.HeaderText = "RegionID";
			this.AreaRegionID.Name = "AreaRegionID";
			this.AreaRegionID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.AreaRegionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.AreaRegionID.ValueMember = "id";
			// 
			// bindingSourceRegion
			// 
			this.bindingSourceRegion.DataMember = "Region";
			this.bindingSourceRegion.DataSource = this.dataSetData;
			this.bindingSourceRegion.Sort = "description";
			// 
			// AreaType
			// 
			this.AreaType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.AreaType.DataPropertyName = "AreaType";
			this.AreaType.FillWeight = 60F;
			this.AreaType.HeaderText = "AreaType";
			this.AreaType.Items.AddRange(new object[] {
            "Circle",
            "Square"});
			this.AreaType.Name = "AreaType";
			this.AreaType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.AreaType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// bindingSourceArea
			// 
			this.bindingSourceArea.DataMember = "Area";
			this.bindingSourceArea.DataSource = this.dataSetQuest;
			// 
			// toolStripContainerForm
			// 
			// 
			// toolStripContainerForm.BottomToolStripPanel
			// 
			this.toolStripContainerForm.BottomToolStripPanel.Controls.Add(this.statusStrip);
			// 
			// toolStripContainerForm.ContentPanel
			// 
			this.toolStripContainerForm.ContentPanel.AutoScroll = true;
			this.toolStripContainerForm.ContentPanel.Controls.Add(this.tabControlMain);
			this.toolStripContainerForm.ContentPanel.Controls.Add(this.xpTaskPane);
			this.toolStripContainerForm.ContentPanel.Size = new System.Drawing.Size(446, 261);
			this.toolStripContainerForm.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainerForm.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainerForm.Name = "toolStripContainerForm";
			this.toolStripContainerForm.Size = new System.Drawing.Size(446, 307);
			this.toolStripContainerForm.TabIndex = 0;
			this.toolStripContainerForm.Text = "toolStripContainer2";
			// 
			// toolStripContainerForm.TopToolStripPanel
			// 
			this.toolStripContainerForm.TopToolStripPanel.Controls.Add(this.menuStripMain);
			// 
			// statusStrip
			// 
			this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusIcon,
            this.StatusLabel,
            this.StatusProgress});
			this.statusStrip.Location = new System.Drawing.Point(0, 0);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(446, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// StatusIcon
			// 
			this.StatusIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.StatusIcon.Name = "StatusIcon";
			this.StatusIcon.Size = new System.Drawing.Size(0, 17);
			// 
			// StatusLabel
			// 
			this.StatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(329, 17);
			this.StatusLabel.Spring = true;
			this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StatusProgress
			// 
			this.StatusProgress.Name = "StatusProgress";
			this.StatusProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// tabControlMain
			// 
			this.tabControlMain.Appearance = NETXP.Controls.Docking.TabPosition.Top;
			this.tabControlMain.BoldSelectedPage = true;
			this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlMain.Location = new System.Drawing.Point(168, 0);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.PixelArea = true;
			this.tabControlMain.PixelBorder = true;
			this.tabControlMain.PositionTop = true;
			office20032.ColorTable = dynamicColorTable3;
			this.tabControlMain.Renderer = office20032;
			this.tabControlMain.ShowArrows = true;
			this.tabControlMain.ShowClose = false;
			this.tabControlMain.ShrinkPagesToFit = false;
			this.tabControlMain.Size = new System.Drawing.Size(278, 261);
			this.tabControlMain.TabIndex = 3;
			this.tabControlMain.TabPages.AddRange(new NETXP.Controls.Docking.TabPage[] {
            this.tabPageQuest,
            this.tabPageNPC,
            this.tabPageItem,
            this.tabPageQuestPart,
            this.tabPageArea,
            this.tabPageLocation,
            this.tabPageCode});
			// 
			// tabPageQuest
			// 
			this.tabPageQuest.Controls.Add(this.questInfo);
			this.tabPageQuest.Location = new System.Drawing.Point(2, 23);
			this.tabPageQuest.Name = "tabPageQuest";
			this.tabPageQuest.Size = new System.Drawing.Size(274, 236);
			this.tabPageQuest.TabIndex = 3;
			this.tabPageQuest.Title = "QuestInfo";
			this.tabPageQuest.ToolTipText = "Detailed Information about Quest";
			// 
			// questInfo
			// 
			this.questInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.questInfo.Location = new System.Drawing.Point(0, 0);
			this.questInfo.Name = "questInfo";
			this.questInfo.Size = new System.Drawing.Size(274, 236);
			this.questInfo.TabIndex = 28;
			// 
			// tabPageNPC
			// 
			this.tabPageNPC.Controls.Add(this.npcView);
			this.tabPageNPC.Location = new System.Drawing.Point(2, 23);
			this.tabPageNPC.Name = "tabPageNPC";
			this.tabPageNPC.Size = new System.Drawing.Size(274, 236);
			this.tabPageNPC.TabIndex = 4;
			this.tabPageNPC.Title = "NPC";
			this.tabPageNPC.ToolTipText = "NPC\'s associated with the quest";
			// 
			// npcView
			// 
			this.npcView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.npcView.Location = new System.Drawing.Point(0, 0);
			this.npcView.Name = "npcView";
			this.npcView.Size = new System.Drawing.Size(274, 236);
			this.npcView.TabIndex = 0;
			// 
			// tabPageItem
			// 
			this.tabPageItem.Controls.Add(this.itemView);
			this.tabPageItem.Location = new System.Drawing.Point(2, 23);
			this.tabPageItem.Name = "tabPageItem";
			this.tabPageItem.Size = new System.Drawing.Size(274, 236);
			this.tabPageItem.TabIndex = 5;
			this.tabPageItem.Title = "Item";
			this.tabPageItem.ToolTipText = "Item\'s associated with the quest";
			// 
			// itemView
			// 
			this.itemView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.itemView.Location = new System.Drawing.Point(0, 0);
			this.itemView.Name = "itemView";
			this.itemView.Size = new System.Drawing.Size(274, 236);
			this.itemView.TabIndex = 0;
			// 
			// tabPageQuestPart
			// 
			this.tabPageQuestPart.Controls.Add(this.questPartItems);
			this.tabPageQuestPart.Location = new System.Drawing.Point(2, 23);
			this.tabPageQuestPart.Name = "tabPageQuestPart";
			this.tabPageQuestPart.Size = new System.Drawing.Size(274, 236);
			this.tabPageQuestPart.TabIndex = 6;
			this.tabPageQuestPart.Title = "QuestPart";
			this.tabPageQuestPart.ToolTipText = "QuestPart\'s making up the whole logic of a quest";
			// 
			// tabPageArea
			// 
			this.tabPageArea.Controls.Add(this.splitContainer1);
			this.tabPageArea.Controls.Add(headerStripArea);
			this.tabPageArea.Location = new System.Drawing.Point(2, 23);
			this.tabPageArea.Name = "tabPageArea";
			this.tabPageArea.Size = new System.Drawing.Size(274, 236);
			this.tabPageArea.TabIndex = 7;
			this.tabPageArea.Title = "Area";
			this.tabPageArea.ToolTipText = "Area\'s used within a quest";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridArea);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.propertyGridArea);
			this.splitContainer1.Size = new System.Drawing.Size(274, 211);
			this.splitContainer1.SplitterDistance = 149;
			this.splitContainer1.TabIndex = 2;
			// 
			// propertyGridArea
			// 
			this.propertyGridArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGridArea.Location = new System.Drawing.Point(0, 0);
			this.propertyGridArea.Name = "propertyGridArea";
			this.propertyGridArea.Size = new System.Drawing.Size(121, 211);
			this.propertyGridArea.TabIndex = 0;
			// 
			// tabPageLocation
			// 
			this.tabPageLocation.Controls.Add(this.splitContainerLocation);
			this.tabPageLocation.Controls.Add(this.headerStrip3);
			this.tabPageLocation.Location = new System.Drawing.Point(2, 23);
			this.tabPageLocation.Name = "tabPageLocation";
			this.tabPageLocation.Size = new System.Drawing.Size(274, 236);
			this.tabPageLocation.TabIndex = 9;
			this.tabPageLocation.Title = "Location";
			this.tabPageLocation.ToolTipText = "Define Locations used for QuestParts";
			// 
			// splitContainerLocation
			// 
			this.splitContainerLocation.DataBindings.Add(new System.Windows.Forms.Binding("SplitterDistance", global::QuestDesigner.Properties.Settings.Default, "locationSplitterDistance", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.splitContainerLocation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerLocation.Location = new System.Drawing.Point(0, 25);
			this.splitContainerLocation.Name = "splitContainerLocation";
			// 
			// splitContainerLocation.Panel1
			// 
			this.splitContainerLocation.Panel1.Controls.Add(this.dataGridViewLocation);
			// 
			// splitContainerLocation.Panel2
			// 
			this.splitContainerLocation.Panel2.Controls.Add(this.propertyGridLocation);
			this.splitContainerLocation.Size = new System.Drawing.Size(274, 211);
			this.splitContainerLocation.SplitterDistance = global::QuestDesigner.Properties.Settings.Default.locationSplitterDistance;
			this.splitContainerLocation.TabIndex = 5;
			// 
			// dataGridViewLocation
			// 
			this.dataGridViewLocation.AutoGenerateColumns = false;
			this.dataGridViewLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationObjectName,
            this.LocationName,
            this.LocationRegionID,
            this.xDataGridViewTextBoxColumn,
            this.yDataGridViewTextBoxColumn,
            this.zDataGridViewTextBoxColumn,
            this.headingDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
			this.dataGridViewLocation.DataSource = this.bindingSourceLocation;
			this.dataGridViewLocation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridViewLocation.Location = new System.Drawing.Point(0, 0);
			this.dataGridViewLocation.Name = "dataGridViewLocation";
			this.dataGridViewLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewLocation.Size = new System.Drawing.Size(223, 211);
			this.dataGridViewLocation.TabIndex = 2;
			this.dataGridViewLocation.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewLocation_RowValidating);
			this.dataGridViewLocation.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewLocation_DefaultValuesNeeded);
			this.dataGridViewLocation.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewLocation_DataError);
			this.dataGridViewLocation.SelectionChanged += new System.EventHandler(this.dataGridViewLocation_SelectionChanged);
			// 
			// LocationObjectName
			// 
			this.LocationObjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LocationObjectName.DataPropertyName = "ObjectName";
			this.LocationObjectName.HeaderText = "ObjectName";
			this.LocationObjectName.Name = "LocationObjectName";
			// 
			// LocationName
			// 
			this.LocationName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LocationName.DataPropertyName = "Name";
			this.LocationName.HeaderText = "Name";
			this.LocationName.Name = "LocationName";
			// 
			// LocationRegionID
			// 
			this.LocationRegionID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.LocationRegionID.DataPropertyName = "RegionID";
			this.LocationRegionID.DataSource = this.bindingSourceRegion;
			this.LocationRegionID.DisplayMember = "description";
			this.LocationRegionID.FillWeight = 80F;
			this.LocationRegionID.HeaderText = "RegionID";
			this.LocationRegionID.Name = "LocationRegionID";
			this.LocationRegionID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.LocationRegionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.LocationRegionID.ValueMember = "id";
			// 
			// xDataGridViewTextBoxColumn
			// 
			this.xDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.xDataGridViewTextBoxColumn.DataPropertyName = "X";
			this.xDataGridViewTextBoxColumn.FillWeight = 50F;
			this.xDataGridViewTextBoxColumn.HeaderText = "X";
			this.xDataGridViewTextBoxColumn.Name = "xDataGridViewTextBoxColumn";
			// 
			// yDataGridViewTextBoxColumn
			// 
			this.yDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.yDataGridViewTextBoxColumn.DataPropertyName = "Y";
			this.yDataGridViewTextBoxColumn.FillWeight = 50F;
			this.yDataGridViewTextBoxColumn.HeaderText = "Y";
			this.yDataGridViewTextBoxColumn.Name = "yDataGridViewTextBoxColumn";
			// 
			// zDataGridViewTextBoxColumn
			// 
			this.zDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.zDataGridViewTextBoxColumn.DataPropertyName = "Z";
			this.zDataGridViewTextBoxColumn.FillWeight = 50F;
			this.zDataGridViewTextBoxColumn.HeaderText = "Z";
			this.zDataGridViewTextBoxColumn.Name = "zDataGridViewTextBoxColumn";
			// 
			// headingDataGridViewTextBoxColumn
			// 
			this.headingDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.headingDataGridViewTextBoxColumn.DataPropertyName = "Heading";
			this.headingDataGridViewTextBoxColumn.FillWeight = 50F;
			this.headingDataGridViewTextBoxColumn.HeaderText = "Heading";
			this.headingDataGridViewTextBoxColumn.Name = "headingDataGridViewTextBoxColumn";
			// 
			// iDDataGridViewTextBoxColumn
			// 
			this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
			this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
			this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
			this.iDDataGridViewTextBoxColumn.Visible = false;
			// 
			// bindingSourceLocation
			// 
			this.bindingSourceLocation.DataMember = "Location";
			this.bindingSourceLocation.DataSource = this.dataSetQuest;
			// 
			// propertyGridLocation
			// 
			this.propertyGridLocation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGridLocation.Location = new System.Drawing.Point(0, 0);
			this.propertyGridLocation.Name = "propertyGridLocation";
			this.propertyGridLocation.Size = new System.Drawing.Size(47, 211);
			this.propertyGridLocation.TabIndex = 3;
			// 
			// headerStrip3
			// 
			this.headerStrip3.AutoSize = false;
			this.headerStrip3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
			this.headerStrip3.ForeColor = System.Drawing.Color.Gray;
			this.headerStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.headerStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3});
			this.headerStrip3.Location = new System.Drawing.Point(0, 0);
			this.headerStrip3.Name = "headerStrip3";
			this.headerStrip3.Size = new System.Drawing.Size(274, 25);
			this.headerStrip3.TabIndex = 6;
			this.headerStrip3.Text = "headerStrip3";
			// 
			// toolStripLabel3
			// 
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(85, 22);
			this.toolStripLabel3.Text = "Locations";
			// 
			// tabPageCode
			// 
			this.tabPageCode.Controls.Add(this.customCode);
			this.tabPageCode.Controls.Add(headerStripCustomCode);
			this.tabPageCode.Location = new System.Drawing.Point(2, 23);
			this.tabPageCode.Name = "tabPageCode";
			this.tabPageCode.Size = new System.Drawing.Size(274, 236);
			this.tabPageCode.TabIndex = 8;
			this.tabPageCode.Title = "CustomCode";
			this.tabPageCode.ToolTipText = "CustomCode of the quest ";
			// 
			// customCode
			// 
			this.customCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customCode.Location = new System.Drawing.Point(0, 0);
			this.customCode.Name = "customCode";
			this.customCode.Size = new System.Drawing.Size(274, 236);
			this.customCode.TabIndex = 3;
			// 
			// xpTaskPane
			// 
			this.xpTaskPane.AutoScroll = true;
			this.xpTaskPane.ColorTable = dynamicColorTable4;
			this.xpTaskPane.Controls.Add(this.xpTGActions);
			this.xpTaskPane.DataBindings.Add(new System.Windows.Forms.Binding("Visible", global::QuestDesigner.Properties.Settings.Default, "ShowTaskPane", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.xpTaskPane.Dock = System.Windows.Forms.DockStyle.Left;
			this.xpTaskPane.Location = new System.Drawing.Point(0, 0);
			this.xpTaskPane.Name = "xpTaskPane";
			this.xpTaskPane.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			this.xpTaskPane.Size = new System.Drawing.Size(168, 261);
			this.xpTaskPane.TabIndex = 29;
			this.xpTaskPane.Text = "xpTaskPane1";
			this.xpTaskPane.Visible = global::QuestDesigner.Properties.Settings.Default.ShowTaskPane;
			// 
			// xpTGActions
			// 
			this.xpTGActions.ColorTable = dynamicColorTable3;
			this.xpTGActions.Controls.Add(this.linkSaveQuest);
			this.xpTGActions.Controls.Add(this.linkCreateQuest);
			this.xpTGActions.Controls.Add(this.linkLoadQuest);
			this.xpTGActions.Image = ((System.Drawing.Image)(resources.GetObject("xpTGActions.Image")));
			this.xpTGActions.Location = new System.Drawing.Point(13, 3);
			this.xpTGActions.Name = "xpTGActions";
			this.xpTGActions.Size = new System.Drawing.Size(144, 116);
			this.xpTGActions.SpecialTasks = true;
			this.xpTGActions.TabIndex = 0;
			this.xpTGActions.Text = "Actions";
			// 
			// linkSaveQuest
			// 
			this.linkSaveQuest.AutoSize = true;
			this.linkSaveQuest.Image = ((System.Drawing.Image)(resources.GetObject("linkSaveQuest.Image")));
			this.linkSaveQuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkSaveQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkSaveQuest.Location = new System.Drawing.Point(11, 68);
			this.linkSaveQuest.Name = "linkSaveQuest";
			this.linkSaveQuest.Padding = new System.Windows.Forms.Padding(18, 2, 0, 2);
			this.linkSaveQuest.Size = new System.Drawing.Size(93, 17);
			this.linkSaveQuest.TabIndex = 2;
			this.linkSaveQuest.TabStop = true;
			this.linkSaveQuest.Text = "Save Quest ...";
			// 
			// linkCreateQuest
			// 
			this.linkCreateQuest.AutoSize = true;
			this.linkCreateQuest.Image = global::QuestDesigner.Properties.Resources.questpart;
			this.linkCreateQuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkCreateQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkCreateQuest.Location = new System.Drawing.Point(11, 88);
			this.linkCreateQuest.Name = "linkCreateQuest";
			this.linkCreateQuest.Padding = new System.Windows.Forms.Padding(18, 2, 0, 2);
			this.linkCreateQuest.Size = new System.Drawing.Size(99, 17);
			this.linkCreateQuest.TabIndex = 1;
			this.linkCreateQuest.TabStop = true;
			this.linkCreateQuest.Text = "Create Quest ...";
			this.linkCreateQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCreateQuest_LinkClicked);
			// 
			// linkLoadQuest
			// 
			this.linkLoadQuest.AutoSize = true;
			this.linkLoadQuest.Image = global::QuestDesigner.Properties.Resources.quest;
			this.linkLoadQuest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLoadQuest.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLoadQuest.Location = new System.Drawing.Point(11, 48);
			this.linkLoadQuest.Name = "linkLoadQuest";
			this.linkLoadQuest.Padding = new System.Windows.Forms.Padding(18, 2, 0, 2);
			this.linkLoadQuest.Size = new System.Drawing.Size(92, 17);
			this.linkLoadQuest.TabIndex = 0;
			this.linkLoadQuest.TabStop = true;
			this.linkLoadQuest.Text = "Load Quest ...";
			this.linkLoadQuest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLoadQuest_LinkClicked);
			// 
			// openQuestDialog
			// 
			this.openQuestDialog.DefaultExt = "qst";
			this.openQuestDialog.Filter = "Quest Data Files|*.qst";
			this.openQuestDialog.RestoreDirectory = true;
			this.openQuestDialog.Title = "Load Quest";
			// 
			// saveScriptDialog
			// 
			this.saveScriptDialog.DefaultExt = "cs";
			this.saveScriptDialog.Filter = "C# Source File|*.cs";
			this.saveScriptDialog.RestoreDirectory = true;
			this.saveScriptDialog.Title = "Save Questscript";
			// 
			// bindingSourceZone
			// 
			this.bindingSourceZone.DataMember = "Zone";
			this.bindingSourceZone.DataSource = this.dataSetData;
			this.bindingSourceZone.Sort = "description";
			// 
			// imageListNPC
			// 
			this.imageListNPC.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListNPC.ImageStream")));
			this.imageListNPC.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListNPC.Images.SetKeyName(0, "user.ico");
			// 
			// bindingSourceQuestPart
			// 
			this.bindingSourceQuestPart.DataMember = "QuestPart";
			this.bindingSourceQuestPart.DataSource = this.dataSetQuest;
			// 
			// bindingSourceEmote
			// 
			this.bindingSourceEmote.AllowNew = false;
			this.bindingSourceEmote.DataMember = "eEnumeration";
			this.bindingSourceEmote.DataSource = this.dataSetData;
			this.bindingSourceEmote.Filter = "Type=\'eEmote\'";
			this.bindingSourceEmote.Sort = "Description";
			// 
			// mapViewerToolStripMenuItem
			// 
			this.mapViewerToolStripMenuItem.Name = "mapViewerToolStripMenuItem";
			this.mapViewerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.mapViewerToolStripMenuItem.Text = "Map Viewer...";
			this.mapViewerToolStripMenuItem.Click += new System.EventHandler(this.mapViewerToolStripMenuItem_Click);
			// 
			// QuestDesignerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 307);
			this.Controls.Add(this.toolStripContainerForm);
			this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::QuestDesigner.Properties.Settings.Default, "MainformLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = global::QuestDesigner.Properties.Settings.Default.MainformLocation;
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "QuestDesignerForm";
			this.Text = "QuestDesigner";
			this.Load += new System.EventHandler(this.QuestDesignerForm_Load);
			headerStripArea.ResumeLayout(false);
			headerStripArea.PerformLayout();
			headerStripCustomCode.ResumeLayout(false);
			headerStripCustomCode.PerformLayout();
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
			((System.ComponentModel.ISupportInitialize)(this.dataTableHand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTableeEnumeration)).EndInit();
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceMob)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTextType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceRequirementType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceComparator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceActionType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceTriggerType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridArea)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegion)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceArea)).EndInit();
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
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tabPageLocation.ResumeLayout(false);
			this.splitContainerLocation.Panel1.ResumeLayout(false);
			this.splitContainerLocation.Panel2.ResumeLayout(false);
			this.splitContainerLocation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceLocation)).EndInit();
			this.headerStrip3.ResumeLayout(false);
			this.headerStrip3.PerformLayout();
			this.tabPageCode.ResumeLayout(false);
			this.xpTaskPane.ResumeLayout(false);
			this.xpTGActions.ResumeLayout(false);
			this.xpTGActions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceZone)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceQuestPart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmote)).EndInit();
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
        private System.Data.DataColumn dataColumnQuestID;
        private System.Data.DataColumn dataColumnQuestName;
        private System.Data.DataColumn dataColumnQuestAuthor;
        private System.Data.DataColumn dataColumnQuestDate;
        private System.Data.DataColumn dataColumnQuestVersion;
        private System.Data.DataColumn dataColumnQuestDescription;
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
        private System.Data.DataColumn dataColumnMaxQuality;
        private System.Data.DataColumn dataColumnDPS_AF;
        private System.Data.DataColumn dataColumnSPD_ABS;
        private System.Data.DataColumn dataColumnHand;
        private System.Data.DataColumn dataColumnTypeDamage;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumnMinimumLevel;
		private System.Data.DataColumn dataColumnMaximumLevel;
		private System.Data.DataColumn dataColumnInvintingNPC;
        private System.Data.DataTable dataTableQuestStep;
        private System.Data.DataColumn dataColumnStep;
		private System.Data.DataColumn dataColumnStepDescription;
        private System.Data.DataColumn dataColumnObjectType;
        private System.Data.DataColumn dataColumnItemType;
        private System.Data.DataColumn dataColumnWeight;
        private System.Data.DataColumn dataColumn26;
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
		private System.Data.DataColumn dataColumn41;
        private System.Data.DataColumn dataColumnGold;
        private System.Data.DataColumn dataColumnSilver;
		private System.Data.DataColumn dataColumnCopper;
		public System.Windows.Forms.BindingSource bindingSourceMob;
        public System.Windows.Forms.BindingSource bindingSourceRegion;
        public System.Windows.Forms.BindingSource bindingSourceZone;
		public System.Windows.Forms.BindingSource bindingSourceTriggerType;
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
        private System.Data.DataTable dataTableHand;
        private System.Data.DataColumn dataColumnHandValue;
		private System.Data.DataColumn dataColumnHandDescription;
        private System.Data.DataColumn dataColumn60;
		private System.Data.DataColumn dataColumn61;
		private System.Data.DataColumn dataColumnActionTypeQ;
		private System.Data.DataColumn dataColumn62;
        private System.Data.DataColumn dataColumn63;
        private System.Data.DataColumn dataColumn64;
		private System.Data.DataColumn dataColumn65;
		public System.Data.DataTable dataTableTriggerType;
		public System.Data.DataTable dataTableActionType;
        public System.Data.DataTable dataTableRequirementType;
        public System.Windows.Forms.ToolStripProgressBar StatusProgress;
        public System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Data.DataColumn dataColumnEmblem;
        private System.Data.DataColumn dataColumnEffect;
        private System.Data.DataColumn dataColumnModelExtension;
        private System.Data.DataColumn dataColumnBonus5;
        private System.Data.DataColumn dataColumnBonus5Type;
        private System.Data.DataColumn dataColumnExtraBonus;
        private System.Data.DataColumn dataColumnExtraBonusType;
        private System.Data.DataColumn dataColumn73;
        private System.Data.DataColumn dataColumn74;
        private System.Data.DataColumn dataColumn75;
        private System.Data.DataColumn dataColumnMaxCount;
        private System.Data.DataColumn dataColumnSpellID;
		private System.Data.DataColumn dataColumnProcSpellID;
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
		private System.Windows.Forms.DataGridView dataGridArea;
		private System.Windows.Forms.BindingSource bindingSourceArea;
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
		private System.Windows.Forms.BindingSource bindingSourceRequirementType;
		private System.Windows.Forms.BindingSource bindingSourceTextType;
		private System.Windows.Forms.BindingSource bindingSourceComparator;
		private System.Windows.Forms.BindingSource bindingSourceActionType;
		private QuestInfo questInfo;
		private System.Windows.Forms.ImageList imageListNPC;
		private NPC npcView;
		private Item itemView;
		private CustomCode customCode;
		private NETXP.Controls.TaskPane.XPTaskPane xpTaskPane;
		private NETXP.Controls.TaskPane.XPTaskPaneGroup xpTGActions;
		private System.Windows.Forms.LinkLabel linkLoadQuest;
		private System.Windows.Forms.LinkLabel linkCreateQuest;
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
		private System.Windows.Forms.SplitContainer splitContainerLocation;
		private System.Windows.Forms.DataGridView dataGridViewLocation;
		private QuestDesigner.Controls.HeaderStrip headerStrip3;
		private System.Windows.Forms.ToolStripLabel toolStripLabel3;
		private System.Windows.Forms.PropertyGrid propertyGridLocation;
		private System.Windows.Forms.BindingSource bindingSourceLocation;
		private System.Data.DataColumn dataColumn23;
		private System.Windows.Forms.DataGridViewTextBoxColumn LocationObjectName;
		private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
		private System.Windows.Forms.DataGridViewComboBoxColumn LocationRegionID;
		private System.Windows.Forms.DataGridViewTextBoxColumn xDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn yDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn zDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn headingDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PropertyGrid propertyGridArea;
		private System.Windows.Forms.DataGridViewTextBoxColumn AreaObjectName;
		private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
		private System.Windows.Forms.DataGridViewComboBoxColumn AreaRegionID;
		private System.Windows.Forms.DataGridViewComboBoxColumn AreaType;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem positionConverterToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.BindingSource bindingSourceQuestPart;
		private System.Data.DataColumn dataColumn25;
		private System.Data.DataColumn dataColumn24;
		private System.Data.DataColumn dataColumn27;
		private System.Windows.Forms.BindingSource bindingSourceEmote;
		private System.Windows.Forms.ToolStripMenuItem mapViewerToolStripMenuItem;		
    }
}

