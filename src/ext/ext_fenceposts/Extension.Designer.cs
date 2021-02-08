namespace ext_fenceposts
{
    partial class frmExtension
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
            this.prgBottom = new System.Windows.Forms.ProgressBar();
            this.prgTop = new System.Windows.Forms.ProgressBar();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnDump = new System.Windows.Forms.Button();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.cmsStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstStringBounds = new System.Windows.Forms.ListBox();
            this.lstPointerTables = new System.Windows.Forms.ListBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splConfigure = new System.Windows.Forms.SplitContainer();
            this.splBounds = new System.Windows.Forms.SplitContainer();
            this.tlsPointerTables = new System.Windows.Forms.ToolStrip();
            this.tslEntries = new System.Windows.Forms.ToolStripLabel();
            this.tsbPointerTableAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbPointerTableProperties = new System.Windows.Forms.ToolStripButton();
            this.tsbPointerTableDelete = new System.Windows.Forms.ToolStripButton();
            this.tlsStringBounds = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsbStringBoundAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbStringBoundProperties = new System.Windows.Forms.ToolStripButton();
            this.tsbStringBoundDelete = new System.Windows.Forms.ToolStripButton();
            this.splStatus = new System.Windows.Forms.SplitContainer();
            this.pnlCommands = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.chkCleanDump = new System.Windows.Forms.CheckBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnInject = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tsbGameSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.tslDumpUsing = new System.Windows.Forms.ToolStripLabel();
            this.cmsStatus.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splConfigure)).BeginInit();
            this.splConfigure.Panel1.SuspendLayout();
            this.splConfigure.Panel2.SuspendLayout();
            this.splConfigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splBounds)).BeginInit();
            this.splBounds.Panel1.SuspendLayout();
            this.splBounds.Panel2.SuspendLayout();
            this.splBounds.SuspendLayout();
            this.tlsPointerTables.SuspendLayout();
            this.tlsStringBounds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splStatus)).BeginInit();
            this.splStatus.Panel1.SuspendLayout();
            this.splStatus.SuspendLayout();
            this.pnlCommands.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgBottom
            // 
            this.prgBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBottom.Location = new System.Drawing.Point(0, 32);
            this.prgBottom.Margin = new System.Windows.Forms.Padding(0);
            this.prgBottom.Maximum = 1000;
            this.prgBottom.Name = "prgBottom";
            this.prgBottom.Size = new System.Drawing.Size(862, 21);
            this.prgBottom.Step = 1;
            this.prgBottom.TabIndex = 0;
            // 
            // prgTop
            // 
            this.prgTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgTop.Location = new System.Drawing.Point(0, 6);
            this.prgTop.Margin = new System.Windows.Forms.Padding(0);
            this.prgTop.Maximum = 1000;
            this.prgTop.Name = "prgTop";
            this.prgTop.Size = new System.Drawing.Size(862, 21);
            this.prgTop.Step = 1;
            this.prgTop.TabIndex = 1;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(93, 17);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(483, 21);
            this.txtFilename.TabIndex = 3;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(582, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 21);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnDump
            // 
            this.btnDump.Location = new System.Drawing.Point(337, 41);
            this.btnDump.Name = "btnDump";
            this.btnDump.Size = new System.Drawing.Size(157, 21);
            this.btnDump.TabIndex = 5;
            this.btnDump.Text = "Dump!";
            this.btnDump.UseVisualStyleBackColor = true;
            this.btnDump.Click += new System.EventHandler(this.btnDump_Click);
            // 
            // lstStatus
            // 
            this.lstStatus.ContextMenuStrip = this.cmsStatus;
            this.lstStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStatus.Enabled = false;
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.IntegralHeight = false;
            this.lstStatus.ItemHeight = 12;
            this.lstStatus.Location = new System.Drawing.Point(0, 75);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(666, 338);
            this.lstStatus.TabIndex = 6;
            this.lstStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstStatus_KeyDown);
            this.lstStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstStatus_MouseDown);
            // 
            // cmsStatus
            // 
            this.cmsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyOffsetToolStripMenuItem});
            this.cmsStatus.Name = "cmsStatus";
            this.cmsStatus.Size = new System.Drawing.Size(146, 26);
            this.cmsStatus.Opening += new System.ComponentModel.CancelEventHandler(this.cmsStatus_Opening);
            // 
            // copyOffsetToolStripMenuItem
            // 
            this.copyOffsetToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_copy;
            this.copyOffsetToolStripMenuItem.Name = "copyOffsetToolStripMenuItem";
            this.copyOffsetToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.copyOffsetToolStripMenuItem.Text = "&Copy Offset";
            this.copyOffsetToolStripMenuItem.Click += new System.EventHandler(this.copyOffsetToolStripMenuItem_Click);
            // 
            // lstStringBounds
            // 
            this.lstStringBounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStringBounds.Enabled = false;
            this.lstStringBounds.FormattingEnabled = true;
            this.lstStringBounds.IntegralHeight = false;
            this.lstStringBounds.ItemHeight = 12;
            this.lstStringBounds.Location = new System.Drawing.Point(0, 25);
            this.lstStringBounds.Name = "lstStringBounds";
            this.lstStringBounds.Size = new System.Drawing.Size(192, 199);
            this.lstStringBounds.TabIndex = 9;
            this.lstStringBounds.SelectedIndexChanged += new System.EventHandler(this.lstStringBounds_SelectedIndexChanged);
            this.lstStringBounds.DoubleClick += new System.EventHandler(this.lstStringBounds_DoubleClick);
            // 
            // lstPointerTables
            // 
            this.lstPointerTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPointerTables.Enabled = false;
            this.lstPointerTables.FormattingEnabled = true;
            this.lstPointerTables.IntegralHeight = false;
            this.lstPointerTables.ItemHeight = 12;
            this.lstPointerTables.Location = new System.Drawing.Point(0, 25);
            this.lstPointerTables.Name = "lstPointerTables";
            this.lstPointerTables.Size = new System.Drawing.Size(192, 160);
            this.lstPointerTables.TabIndex = 10;
            this.lstPointerTables.SelectedIndexChanged += new System.EventHandler(this.lstPointerTables_SelectedIndexChanged);
            this.lstPointerTables.DoubleClick += new System.EventHandler(this.lstPointerTables_DoubleClick);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splConfigure);
            this.pnlMain.Controls.Add(this.pnlProgress);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(6);
            this.pnlMain.Size = new System.Drawing.Size(874, 479);
            this.pnlMain.TabIndex = 14;
            // 
            // splConfigure
            // 
            this.splConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splConfigure.Enabled = false;
            this.splConfigure.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splConfigure.Location = new System.Drawing.Point(6, 6);
            this.splConfigure.Name = "splConfigure";
            // 
            // splConfigure.Panel1
            // 
            this.splConfigure.Panel1.Controls.Add(this.splBounds);
            // 
            // splConfigure.Panel2
            // 
            this.splConfigure.Panel2.Controls.Add(this.splStatus);
            this.splConfigure.Size = new System.Drawing.Size(862, 413);
            this.splConfigure.SplitterDistance = 192;
            this.splConfigure.TabIndex = 0;
            // 
            // splBounds
            // 
            this.splBounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBounds.Enabled = false;
            this.splBounds.Location = new System.Drawing.Point(0, 0);
            this.splBounds.Name = "splBounds";
            this.splBounds.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splBounds.Panel1
            // 
            this.splBounds.Panel1.Controls.Add(this.lstPointerTables);
            this.splBounds.Panel1.Controls.Add(this.tlsPointerTables);
            // 
            // splBounds.Panel2
            // 
            this.splBounds.Panel2.Controls.Add(this.lstStringBounds);
            this.splBounds.Panel2.Controls.Add(this.tlsStringBounds);
            this.splBounds.Size = new System.Drawing.Size(192, 413);
            this.splBounds.SplitterDistance = 185;
            this.splBounds.TabIndex = 0;
            // 
            // tlsPointerTables
            // 
            this.tlsPointerTables.AutoSize = false;
            this.tlsPointerTables.BackColor = System.Drawing.Color.Transparent;
            this.tlsPointerTables.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsPointerTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEntries,
            this.tsbPointerTableAdd,
            this.tsbPointerTableProperties,
            this.tsbPointerTableDelete});
            this.tlsPointerTables.Location = new System.Drawing.Point(0, 0);
            this.tlsPointerTables.Name = "tlsPointerTables";
            this.tlsPointerTables.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tlsPointerTables.Size = new System.Drawing.Size(192, 25);
            this.tlsPointerTables.TabIndex = 1;
            // 
            // tslEntries
            // 
            this.tslEntries.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslEntries.Name = "tslEntries";
            this.tslEntries.Size = new System.Drawing.Size(44, 20);
            this.tslEntries.Text = "指针表";
            // 
            // tsbPointerTableAdd
            // 
            this.tsbPointerTableAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPointerTableAdd.Enabled = false;
            this.tsbPointerTableAdd.Image = global::ext_fenceposts.Properties.Resources.menu_add;
            this.tsbPointerTableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPointerTableAdd.Name = "tsbPointerTableAdd";
            this.tsbPointerTableAdd.Size = new System.Drawing.Size(23, 20);
            this.tsbPointerTableAdd.Text = "添加指针表";
            this.tsbPointerTableAdd.Click += new System.EventHandler(this.tsbPointerTableAdd_Click);
            // 
            // tsbPointerTableProperties
            // 
            this.tsbPointerTableProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPointerTableProperties.Enabled = false;
            this.tsbPointerTableProperties.Image = global::ext_fenceposts.Properties.Resources.menu_properties;
            this.tsbPointerTableProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPointerTableProperties.Name = "tsbPointerTableProperties";
            this.tsbPointerTableProperties.Size = new System.Drawing.Size(23, 20);
            this.tsbPointerTableProperties.Text = "指针表属性";
            this.tsbPointerTableProperties.Click += new System.EventHandler(this.tsbPointerTableProperties_Click);
            // 
            // tsbPointerTableDelete
            // 
            this.tsbPointerTableDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPointerTableDelete.Enabled = false;
            this.tsbPointerTableDelete.Image = global::ext_fenceposts.Properties.Resources.menu_delete;
            this.tsbPointerTableDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPointerTableDelete.Name = "tsbPointerTableDelete";
            this.tsbPointerTableDelete.Size = new System.Drawing.Size(23, 20);
            this.tsbPointerTableDelete.Text = "删除指针表";
            this.tsbPointerTableDelete.Click += new System.EventHandler(this.tsbPointerTableDelete_Click);
            // 
            // tlsStringBounds
            // 
            this.tlsStringBounds.AutoSize = false;
            this.tlsStringBounds.BackColor = System.Drawing.Color.Transparent;
            this.tlsStringBounds.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsStringBounds.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbStringBoundAdd,
            this.tsbStringBoundProperties,
            this.tsbStringBoundDelete});
            this.tlsStringBounds.Location = new System.Drawing.Point(0, 0);
            this.tlsStringBounds.Name = "tlsStringBounds";
            this.tlsStringBounds.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tlsStringBounds.Size = new System.Drawing.Size(192, 25);
            this.tlsStringBounds.TabIndex = 2;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(68, 20);
            this.toolStripLabel1.Text = "字符串边界";
            // 
            // tsbStringBoundAdd
            // 
            this.tsbStringBoundAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStringBoundAdd.Enabled = false;
            this.tsbStringBoundAdd.Image = global::ext_fenceposts.Properties.Resources.menu_add;
            this.tsbStringBoundAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStringBoundAdd.Name = "tsbStringBoundAdd";
            this.tsbStringBoundAdd.Size = new System.Drawing.Size(23, 20);
            this.tsbStringBoundAdd.Text = "添加转储边界";
            this.tsbStringBoundAdd.Click += new System.EventHandler(this.tsbStringBoundAdd_Click);
            // 
            // tsbStringBoundProperties
            // 
            this.tsbStringBoundProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStringBoundProperties.Enabled = false;
            this.tsbStringBoundProperties.Image = global::ext_fenceposts.Properties.Resources.menu_properties;
            this.tsbStringBoundProperties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStringBoundProperties.Name = "tsbStringBoundProperties";
            this.tsbStringBoundProperties.Size = new System.Drawing.Size(23, 20);
            this.tsbStringBoundProperties.Text = "转储绑定属性";
            this.tsbStringBoundProperties.Click += new System.EventHandler(this.tsbStringBoundProperties_Click);
            // 
            // tsbStringBoundDelete
            // 
            this.tsbStringBoundDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStringBoundDelete.Enabled = false;
            this.tsbStringBoundDelete.Image = global::ext_fenceposts.Properties.Resources.menu_delete;
            this.tsbStringBoundDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStringBoundDelete.Name = "tsbStringBoundDelete";
            this.tsbStringBoundDelete.Size = new System.Drawing.Size(23, 20);
            this.tsbStringBoundDelete.Text = "删除转储边界";
            this.tsbStringBoundDelete.Click += new System.EventHandler(this.tsbStringBoundDelete_Click);
            // 
            // splStatus
            // 
            this.splStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splStatus.Location = new System.Drawing.Point(0, 0);
            this.splStatus.Name = "splStatus";
            this.splStatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splStatus.Panel1
            // 
            this.splStatus.Panel1.Controls.Add(this.lstStatus);
            this.splStatus.Panel1.Controls.Add(this.pnlCommands);
            this.splStatus.Panel2Collapsed = true;
            this.splStatus.Size = new System.Drawing.Size(666, 413);
            this.splStatus.SplitterDistance = 327;
            this.splStatus.TabIndex = 0;
            // 
            // pnlCommands
            // 
            this.pnlCommands.Controls.Add(this.groupBox1);
            this.pnlCommands.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommands.Location = new System.Drawing.Point(0, 0);
            this.pnlCommands.Name = "pnlCommands";
            this.pnlCommands.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.pnlCommands.Size = new System.Drawing.Size(666, 75);
            this.pnlCommands.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOptions);
            this.groupBox1.Controls.Add(this.chkCleanDump);
            this.groupBox1.Controls.Add(this.lblFile);
            this.groupBox1.Controls.Add(this.btnInject);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.btnDump);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 71);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制面板";
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(9, 41);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(157, 21);
            this.btnOptions.TabIndex = 11;
            this.btnOptions.Text = "选项";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // chkCleanDump
            // 
            this.chkCleanDump.Location = new System.Drawing.Point(172, 43);
            this.chkCleanDump.Name = "chkCleanDump";
            this.chkCleanDump.Size = new System.Drawing.Size(157, 18);
            this.chkCleanDump.TabIndex = 10;
            this.chkCleanDump.Text = "清除Dump";
            this.chkCleanDump.UseVisualStyleBackColor = true;
            this.chkCleanDump.CheckedChanged += new System.EventHandler(this.chkCleanDump_CheckedChanged);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(46, 20);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(41, 12);
            this.lblFile.TabIndex = 9;
            this.lblFile.Text = "文件：";
            // 
            // btnInject
            // 
            this.btnInject.Location = new System.Drawing.Point(500, 41);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(157, 21);
            this.btnInject.TabIndex = 8;
            this.btnInject.Text = "注入！";
            this.btnInject.UseVisualStyleBackColor = true;
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.prgTop);
            this.pnlProgress.Controls.Add(this.prgBottom);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgress.Location = new System.Drawing.Point(6, 419);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlProgress.Size = new System.Drawing.Size(862, 54);
            this.pnlProgress.TabIndex = 1;
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(874, 25);
            this.mnuMain.TabIndex = 16;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "&文件";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "&新建";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_open;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&打开";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "&保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_save_as;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "&另存为...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::ext_fenceposts.Properties.Resources.menu_exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "&退出";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNew.Image = global::ext_fenceposts.Properties.Resources.menu_new;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(23, 20);
            this.tsbNew.Text = "新建KUP文件";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = global::ext_fenceposts.Properties.Resources.menu_open;
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 20);
            this.tsbOpen.Text = "打开KUP文件";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::ext_fenceposts.Properties.Resources.menu_save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 20);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAs.Enabled = false;
            this.tsbSaveAs.Image = global::ext_fenceposts.Properties.Resources.menu_save_as;
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(23, 20);
            this.tsbSaveAs.Text = "另存为...";
            this.tsbSaveAs.Click += new System.EventHandler(this.tsbSaveAs_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.AutoSize = false;
            this.tlsMain.BackColor = System.Drawing.Color.Transparent;
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbOpen,
            this.tsbSave,
            this.tsbSaveAs,
            this.tsbGameSelect,
            this.tslDumpUsing});
            this.tlsMain.Location = new System.Drawing.Point(0, 25);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tlsMain.Size = new System.Drawing.Size(874, 25);
            this.tlsMain.TabIndex = 15;
            // 
            // tsbGameSelect
            // 
            this.tsbGameSelect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbGameSelect.Enabled = false;
            this.tsbGameSelect.Image = global::ext_fenceposts.Properties.Resources.game_none;
            this.tsbGameSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGameSelect.Name = "tsbGameSelect";
            this.tsbGameSelect.Size = new System.Drawing.Size(93, 20);
            this.tsbGameSelect.Text = "No Game";
            // 
            // tslDumpUsing
            // 
            this.tslDumpUsing.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslDumpUsing.Name = "tslDumpUsing";
            this.tslDumpUsing.Size = new System.Drawing.Size(68, 20);
            this.tslDumpUsing.Text = "转储使用：";
            // 
            // frmExtension
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 529);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmExtension";
            this.Text = "Fenceposts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fenceposts_FormClosing);
            this.Load += new System.EventHandler(this.Fenceposts_Load);
            this.cmsStatus.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splConfigure.Panel1.ResumeLayout(false);
            this.splConfigure.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splConfigure)).EndInit();
            this.splConfigure.ResumeLayout(false);
            this.splBounds.Panel1.ResumeLayout(false);
            this.splBounds.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBounds)).EndInit();
            this.splBounds.ResumeLayout(false);
            this.tlsPointerTables.ResumeLayout(false);
            this.tlsPointerTables.PerformLayout();
            this.tlsStringBounds.ResumeLayout(false);
            this.tlsStringBounds.PerformLayout();
            this.splStatus.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splStatus)).EndInit();
            this.splStatus.ResumeLayout(false);
            this.pnlCommands.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgBottom;
        private System.Windows.Forms.ProgressBar prgTop;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDump;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.ListBox lstStringBounds;
        private System.Windows.Forms.ListBox lstPointerTables;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splConfigure;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.SplitContainer splBounds;
        private System.Windows.Forms.ToolStrip tlsPointerTables;
        private System.Windows.Forms.ToolStripLabel tslEntries;
        private System.Windows.Forms.ToolStripButton tsbPointerTableAdd;
        private System.Windows.Forms.ToolStripButton tsbPointerTableProperties;
        private System.Windows.Forms.ToolStripButton tsbPointerTableDelete;
        private System.Windows.Forms.ToolStrip tlsStringBounds;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbStringBoundAdd;
        private System.Windows.Forms.ToolStripButton tsbStringBoundProperties;
        private System.Windows.Forms.ToolStripButton tsbStringBoundDelete;
        private System.Windows.Forms.SplitContainer splStatus;
        private System.Windows.Forms.Panel pnlCommands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAs;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbGameSelect;
        private System.Windows.Forms.ToolStripLabel tslDumpUsing;
        private System.Windows.Forms.ContextMenuStrip cmsStatus;
        private System.Windows.Forms.ToolStripMenuItem copyOffsetToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkCleanDump;
        private System.Windows.Forms.Button btnOptions;
    }
}