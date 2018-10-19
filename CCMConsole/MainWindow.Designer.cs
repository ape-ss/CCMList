namespace CCMList
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainContainer = new System.Windows.Forms.ToolStripContainer();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusIpAddress = new System.Windows.Forms.ToolStripStatusLabel();
            this.grid = new System.Windows.Forms.TableLayoutPanel();
            this.mainList = new System.Windows.Forms.TreeView();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolImages = new System.Windows.Forms.ImageList(this.components);
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.labelDomainName = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddPC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuLaunchSCCM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteNode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolbarStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetailsState = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStatusbarState = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuImportPCList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportPCList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.buttonNewFolder = new System.Windows.Forms.ToolStripButton();
            this.buttonNewNode = new System.Windows.Forms.ToolStripButton();
            this.buttonEditNode = new System.Windows.Forms.ToolStripButton();
            this.buttonConnect = new System.Windows.Forms.ToolStripButton();
            this.buttonSaveList = new System.Windows.Forms.ToolStripButton();
            this.buttonOpenList = new System.Windows.Forms.ToolStripButton();
            this.buttonOptions = new System.Windows.Forms.ToolStripButton();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainContainer.BottomToolStripPanel.SuspendLayout();
            this.mainContainer.ContentPanel.SuspendLayout();
            this.mainContainer.TopToolStripPanel.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.grid.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.groupDetails.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            // 
            // mainContainer.BottomToolStripPanel
            // 
            this.mainContainer.BottomToolStripPanel.Controls.Add(this.statusBar);
            // 
            // mainContainer.ContentPanel
            // 
            this.mainContainer.ContentPanel.Controls.Add(this.grid);
            resources.ApplyResources(this.mainContainer.ContentPanel, "mainContainer.ContentPanel");
            resources.ApplyResources(this.mainContainer, "mainContainer");
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.TopToolStripPanel
            // 
            this.mainContainer.TopToolStripPanel.Controls.Add(this.mainMenu);
            this.mainContainer.TopToolStripPanel.Controls.Add(this.toolBar);
            // 
            // statusBar
            // 
            resources.ApplyResources(this.statusBar, "statusBar");
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIpAddress});
            this.statusBar.Name = "statusBar";
            // 
            // statusIpAddress
            // 
            resources.ApplyResources(this.statusIpAddress, "statusIpAddress");
            this.statusIpAddress.Name = "statusIpAddress";
            // 
            // grid
            // 
            resources.ApplyResources(this.grid, "grid");
            this.grid.Controls.Add(this.mainList, 0, 0);
            this.grid.Controls.Add(this.groupDetails, 0, 1);
            this.grid.Name = "grid";
            // 
            // mainList
            // 
            this.mainList.ContextMenuStrip = this.contextMenu;
            resources.ApplyResources(this.mainList, "mainList");
            this.mainList.ImageList = this.toolImages;
            this.mainList.ItemHeight = 22;
            this.mainList.Name = "mainList";
            this.mainList.StateImageList = this.toolImages;
            this.mainList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.mainList_AfterSelect);
            this.mainList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainList_NodeMouseClick);
            this.mainList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.mainList_NodeMouseDoubleClick);
            this.mainList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mainList_KeyPress);
            this.mainList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainList_KeyUp);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.editNodeToolStripMenuItem,
            this.deleteNodeToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Image = global::CCMList.Properties.Resources.computer__plus;
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            resources.ApplyResources(this.addNodeToolStripMenuItem, "addNodeToolStripMenuItem");
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // editNodeToolStripMenuItem
            // 
            this.editNodeToolStripMenuItem.Image = global::CCMList.Properties.Resources.computer__pencil;
            this.editNodeToolStripMenuItem.Name = "editNodeToolStripMenuItem";
            resources.ApplyResources(this.editNodeToolStripMenuItem, "editNodeToolStripMenuItem");
            this.editNodeToolStripMenuItem.Click += new System.EventHandler(this.editNodeToolStripMenuItem_Click);
            // 
            // deleteNodeToolStripMenuItem
            // 
            this.deleteNodeToolStripMenuItem.Image = global::CCMList.Properties.Resources.computer__minus;
            this.deleteNodeToolStripMenuItem.Name = "deleteNodeToolStripMenuItem";
            resources.ApplyResources(this.deleteNodeToolStripMenuItem, "deleteNodeToolStripMenuItem");
            this.deleteNodeToolStripMenuItem.Click += new System.EventHandler(this.deleteNodeToolStripMenuItem_Click);
            // 
            // toolImages
            // 
            this.toolImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolImages.ImageStream")));
            this.toolImages.TransparentColor = System.Drawing.Color.Transparent;
            this.toolImages.Images.SetKeyName(0, "computer-network.png");
            this.toolImages.Images.SetKeyName(1, "document--plus.png");
            this.toolImages.Images.SetKeyName(2, "folder--plus.png");
            this.toolImages.Images.SetKeyName(3, "computer.png");
            this.toolImages.Images.SetKeyName(4, "folder.png");
            this.toolImages.Images.SetKeyName(5, "folder-open.png");
            this.toolImages.Images.SetKeyName(6, "folder-horizontal.png");
            this.toolImages.Images.SetKeyName(7, "folder-horizontal-open.png");
            // 
            // groupDetails
            // 
            this.groupDetails.Controls.Add(this.labelDomainName);
            this.groupDetails.Controls.Add(this.labelIPAddress);
            resources.ApplyResources(this.groupDetails, "groupDetails");
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.TabStop = false;
            // 
            // labelDomainName
            // 
            resources.ApplyResources(this.labelDomainName, "labelDomainName");
            this.labelDomainName.Name = "labelDomainName";
            // 
            // labelIPAddress
            // 
            resources.ApplyResources(this.labelIPAddress, "labelIPAddress");
            this.labelIPAddress.Name = "labelIPAddress";
            // 
            // mainMenu
            // 
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuList,
            this.menuEdit,
            this.menuView,
            this.menuTools,
            this.menuHelp});
            this.mainMenu.Name = "mainMenu";
            // 
            // menuList
            // 
            this.menuList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddFolder,
            this.menuAddPC,
            this.toolStripMenuItem2,
            this.menuLaunchSCCM,
            this.toolStripMenuItem3,
            this.menuExit});
            this.menuList.Name = "menuList";
            resources.ApplyResources(this.menuList, "menuList");
            // 
            // menuAddFolder
            // 
            this.menuAddFolder.Image = global::CCMList.Properties.Resources.folder__plus;
            this.menuAddFolder.Name = "menuAddFolder";
            resources.ApplyResources(this.menuAddFolder, "menuAddFolder");
            this.menuAddFolder.Click += new System.EventHandler(this.newgroupToolStripMenuItem_Click);
            // 
            // menuAddPC
            // 
            this.menuAddPC.Image = global::CCMList.Properties.Resources.computer__plus;
            this.menuAddPC.Name = "menuAddPC";
            resources.ApplyResources(this.menuAddPC, "menuAddPC");
            this.menuAddPC.Click += new System.EventHandler(this.newPCToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuLaunchSCCM
            // 
            this.menuLaunchSCCM.Name = "menuLaunchSCCM";
            resources.ApplyResources(this.menuLaunchSCCM, "menuLaunchSCCM");
            this.menuLaunchSCCM.Click += new System.EventHandler(this.menuLaunchSCCM_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            resources.ApplyResources(this.menuExit, "menuExit");
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProperties,
            this.menuDeleteNode});
            this.menuEdit.Name = "menuEdit";
            resources.ApplyResources(this.menuEdit, "menuEdit");
            // 
            // menuProperties
            // 
            this.menuProperties.Image = global::CCMList.Properties.Resources.computer__pencil;
            this.menuProperties.Name = "menuProperties";
            resources.ApplyResources(this.menuProperties, "menuProperties");
            this.menuProperties.Click += new System.EventHandler(this.menuProperties_Click);
            // 
            // menuDeleteNode
            // 
            this.menuDeleteNode.Image = global::CCMList.Properties.Resources.computer__minus;
            this.menuDeleteNode.Name = "menuDeleteNode";
            resources.ApplyResources(this.menuDeleteNode, "menuDeleteNode");
            this.menuDeleteNode.Click += new System.EventHandler(this.menuDeleteNode_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolbarStatus,
            this.menuDetailsState,
            this.menuStatusbarState});
            this.menuView.Name = "menuView";
            resources.ApplyResources(this.menuView, "menuView");
            // 
            // menuToolbarStatus
            // 
            this.menuToolbarStatus.Checked = true;
            this.menuToolbarStatus.CheckOnClick = true;
            this.menuToolbarStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuToolbarStatus.Name = "menuToolbarStatus";
            resources.ApplyResources(this.menuToolbarStatus, "menuToolbarStatus");
            this.menuToolbarStatus.CheckStateChanged += new System.EventHandler(this.menuToolbarStatus_CheckStateChanged);
            // 
            // menuDetailsState
            // 
            this.menuDetailsState.Checked = true;
            this.menuDetailsState.CheckOnClick = true;
            this.menuDetailsState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuDetailsState.Name = "menuDetailsState";
            resources.ApplyResources(this.menuDetailsState, "menuDetailsState");
            this.menuDetailsState.CheckStateChanged += new System.EventHandler(this.detailsToolStripMenuItem_CheckStateChanged);
            // 
            // menuStatusbarState
            // 
            this.menuStatusbarState.Checked = true;
            this.menuStatusbarState.CheckOnClick = true;
            this.menuStatusbarState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuStatusbarState.Name = "menuStatusbarState";
            resources.ApplyResources(this.menuStatusbarState, "menuStatusbarState");
            this.menuStatusbarState.CheckStateChanged += new System.EventHandler(this.statusbarToolStripMenuItem_CheckStateChanged);
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOptions,
            this.toolStripMenuItem4,
            this.menuImportPCList,
            this.menuExportPCList});
            this.menuTools.Name = "menuTools";
            resources.ApplyResources(this.menuTools, "menuTools");
            this.menuTools.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // menuOptions
            // 
            this.menuOptions.Name = "menuOptions";
            resources.ApplyResources(this.menuOptions, "menuOptions");
            this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // menuImportPCList
            // 
            this.menuImportPCList.Image = global::CCMList.Properties.Resources.folder_import;
            this.menuImportPCList.Name = "menuImportPCList";
            resources.ApplyResources(this.menuImportPCList, "menuImportPCList");
            this.menuImportPCList.Click += new System.EventHandler(this.menuImportPCList_Click);
            // 
            // menuExportPCList
            // 
            this.menuExportPCList.Image = global::CCMList.Properties.Resources.folder_export;
            this.menuExportPCList.Name = "menuExportPCList";
            resources.ApplyResources(this.menuExportPCList, "menuExportPCList");
            this.menuExportPCList.Click += new System.EventHandler(this.menuExportPCList_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuHelp.Name = "menuHelp";
            resources.ApplyResources(this.menuHelp, "menuHelp");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // toolBar
            // 
            resources.ApplyResources(this.toolBar, "toolBar");
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewFolder,
            this.buttonNewNode,
            this.buttonEditNode,
            this.buttonConnect,
            this.buttonSaveList,
            this.buttonOpenList,
            this.buttonOptions});
            this.toolBar.Name = "toolBar";
            // 
            // buttonNewFolder
            // 
            this.buttonNewFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNewFolder.Image = global::CCMList.Properties.Resources.folder__plus;
            resources.ApplyResources(this.buttonNewFolder, "buttonNewFolder");
            this.buttonNewFolder.Name = "buttonNewFolder";
            this.buttonNewFolder.Padding = new System.Windows.Forms.Padding(5);
            this.buttonNewFolder.Click += new System.EventHandler(this.buttonNewFolder_Click);
            // 
            // buttonNewNode
            // 
            this.buttonNewNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonNewNode.Image = global::CCMList.Properties.Resources.computer__plus;
            resources.ApplyResources(this.buttonNewNode, "buttonNewNode");
            this.buttonNewNode.Name = "buttonNewNode";
            this.buttonNewNode.Padding = new System.Windows.Forms.Padding(5);
            this.buttonNewNode.Click += new System.EventHandler(this.buttonNewNode_Click);
            // 
            // buttonEditNode
            // 
            this.buttonEditNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEditNode.Image = global::CCMList.Properties.Resources.computer__pencil;
            resources.ApplyResources(this.buttonEditNode, "buttonEditNode");
            this.buttonEditNode.Name = "buttonEditNode";
            this.buttonEditNode.Padding = new System.Windows.Forms.Padding(5);
            this.buttonEditNode.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonConnect.Image = global::CCMList.Properties.Resources.computer_network;
            resources.ApplyResources(this.buttonConnect, "buttonConnect");
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Padding = new System.Windows.Forms.Padding(5);
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSaveList
            // 
            this.buttonSaveList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSaveList.Image = global::CCMList.Properties.Resources.folder_export;
            resources.ApplyResources(this.buttonSaveList, "buttonSaveList");
            this.buttonSaveList.Name = "buttonSaveList";
            this.buttonSaveList.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSaveList.Click += new System.EventHandler(this.buttonSaveList_Click);
            // 
            // buttonOpenList
            // 
            this.buttonOpenList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOpenList.Image = global::CCMList.Properties.Resources.folder_import;
            resources.ApplyResources(this.buttonOpenList, "buttonOpenList");
            this.buttonOpenList.Name = "buttonOpenList";
            this.buttonOpenList.Padding = new System.Windows.Forms.Padding(5);
            this.buttonOpenList.Click += new System.EventHandler(this.buttonOpenList_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOptions.Image = global::CCMList.Properties.Resources.wrench_screwdriver;
            resources.ApplyResources(this.buttonOptions, "buttonOptions");
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Padding = new System.Windows.Forms.Padding(5);
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.openDialog, "openDialog");
            // 
            // saveDialog
            // 
            resources.ApplyResources(this.saveDialog, "saveDialog");
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            resources.ApplyResources(this.trayMenu, "trayMenu");
            this.trayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.trayMenu_Opening);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            resources.ApplyResources(this.restoreToolStripMenuItem, "restoreToolStripMenuItem");
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoreToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainContainer);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.mainContainer.BottomToolStripPanel.ResumeLayout(false);
            this.mainContainer.BottomToolStripPanel.PerformLayout();
            this.mainContainer.ContentPanel.ResumeLayout(false);
            this.mainContainer.TopToolStripPanel.ResumeLayout(false);
            this.mainContainer.TopToolStripPanel.PerformLayout();
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.grid.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer mainContainer;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ImageList toolImages;
        private System.Windows.Forms.ToolStripButton buttonNewNode;
        private System.Windows.Forms.ToolStripButton buttonNewFolder;
        private System.Windows.Forms.ToolStripButton buttonConnect;
        private System.Windows.Forms.ToolStripStatusLabel statusIpAddress;
        private System.Windows.Forms.ToolStripButton buttonSaveList;
        private System.Windows.Forms.ToolStripButton buttonOpenList;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripButton buttonOptions;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNodeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton buttonEditNode;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuList;
        private System.Windows.Forms.ToolStripMenuItem menuAddFolder;
        private System.Windows.Forms.ToolStripMenuItem menuAddPC;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuLaunchSCCM;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuProperties;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteNode;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuToolbarStatus;
        private System.Windows.Forms.ToolStripMenuItem menuDetailsState;
        private System.Windows.Forms.ToolStripMenuItem menuStatusbarState;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuImportPCList;
        private System.Windows.Forms.ToolStripMenuItem menuExportPCList;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel grid;
        private System.Windows.Forms.TreeView mainList;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.Label labelDomainName;
        private System.Windows.Forms.Label labelIPAddress;
    }
}

