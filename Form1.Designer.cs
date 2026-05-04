namespace DraftMaster
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            mainTabCtrl = new TabControl();
            writingTab = new TabPage();
            splitDraftingContainer = new SplitContainer();
            panel2 = new Panel();
            saveDraftBtn = new Button();
            deleteLockButton = new Button();
            draftsTreeView = new TreeView();
            draftingTextBox = new RichTextBox();
            mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newProjectToolStripMenuItem = new ToolStripMenuItem();
            openProjectToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveDraftToolStripMenuItem = new ToolStripMenuItem();
            saveMatrixToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            outliningTab = new TabPage();
            plottingSplitContainer = new SplitContainer();
            panel1 = new Panel();
            saveOutlineBtn = new Button();
            newGridBtn = new Button();
            plottingTreeView = new TreeView();
            treeView1 = new TreeView();
            plottingDataGridView = new DataGridView();
            outliningContextMenu = new ContextMenuStrip(components);
            addColumnToolStripMenuItem = new ToolStripMenuItem();
            deleteColumnToolStripMenuItem = new ToolStripMenuItem();
            settingsTab = new TabPage();
            settingsPanel = new Panel();
            themeGroupBox = new GroupBox();
            darkModeRadioBtn = new RadioButton();
            lightModeRadioBtn = new RadioButton();
            exportToolStripMenuItem = new ToolStripMenuItem();
            mainTabCtrl.SuspendLayout();
            writingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitDraftingContainer).BeginInit();
            splitDraftingContainer.Panel1.SuspendLayout();
            splitDraftingContainer.Panel2.SuspendLayout();
            splitDraftingContainer.SuspendLayout();
            panel2.SuspendLayout();
            mainMenuStrip.SuspendLayout();
            outliningTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)plottingSplitContainer).BeginInit();
            plottingSplitContainer.Panel1.SuspendLayout();
            plottingSplitContainer.Panel2.SuspendLayout();
            plottingSplitContainer.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)plottingDataGridView).BeginInit();
            outliningContextMenu.SuspendLayout();
            settingsTab.SuspendLayout();
            settingsPanel.SuspendLayout();
            themeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabCtrl
            // 
            mainTabCtrl.Controls.Add(writingTab);
            mainTabCtrl.Controls.Add(outliningTab);
            mainTabCtrl.Controls.Add(settingsTab);
            mainTabCtrl.Dock = DockStyle.Fill;
            mainTabCtrl.Location = new Point(0, 0);
            mainTabCtrl.Name = "mainTabCtrl";
            mainTabCtrl.SelectedIndex = 0;
            mainTabCtrl.Size = new Size(1584, 861);
            mainTabCtrl.TabIndex = 0;
            // 
            // writingTab
            // 
            writingTab.Controls.Add(splitDraftingContainer);
            writingTab.Location = new Point(4, 24);
            writingTab.Name = "writingTab";
            writingTab.Padding = new Padding(3);
            writingTab.Size = new Size(1576, 833);
            writingTab.TabIndex = 0;
            writingTab.Text = "Drafting";
            writingTab.UseVisualStyleBackColor = true;
            // 
            // splitDraftingContainer
            // 
            splitDraftingContainer.Dock = DockStyle.Fill;
            splitDraftingContainer.FixedPanel = FixedPanel.Panel1;
            splitDraftingContainer.Location = new Point(3, 3);
            splitDraftingContainer.Name = "splitDraftingContainer";
            // 
            // splitDraftingContainer.Panel1
            // 
            splitDraftingContainer.Panel1.Controls.Add(panel2);
            splitDraftingContainer.Panel1.Controls.Add(draftsTreeView);
            // 
            // splitDraftingContainer.Panel2
            // 
            splitDraftingContainer.Panel2.Controls.Add(draftingTextBox);
            splitDraftingContainer.Panel2.Controls.Add(mainMenuStrip);
            splitDraftingContainer.Size = new Size(1570, 827);
            splitDraftingContainer.SplitterDistance = 250;
            splitDraftingContainer.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(saveDraftBtn);
            panel2.Controls.Add(deleteLockButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 727);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 100);
            panel2.TabIndex = 1;
            // 
            // saveDraftBtn
            // 
            saveDraftBtn.Location = new Point(5, 32);
            saveDraftBtn.Name = "saveDraftBtn";
            saveDraftBtn.Size = new Size(75, 23);
            saveDraftBtn.TabIndex = 3;
            saveDraftBtn.Text = "Save Draft";
            saveDraftBtn.UseVisualStyleBackColor = true;
            saveDraftBtn.Click += saveDraftBtn_Click;
            // 
            // deleteLockButton
            // 
            deleteLockButton.Location = new Point(5, 3);
            deleteLockButton.Name = "deleteLockButton";
            deleteLockButton.Size = new Size(97, 23);
            deleteLockButton.TabIndex = 0;
            deleteLockButton.Text = "Lock Deletes";
            deleteLockButton.UseVisualStyleBackColor = true;
            deleteLockButton.Click += deleteLockButton_Click;
            // 
            // draftsTreeView
            // 
            draftsTreeView.Dock = DockStyle.Fill;
            draftsTreeView.Location = new Point(0, 0);
            draftsTreeView.Name = "draftsTreeView";
            draftsTreeView.Size = new Size(250, 827);
            draftsTreeView.TabIndex = 0;
            draftsTreeView.NodeMouseClick += draftsTreeView_NodeMouseClick;
            // 
            // draftingTextBox
            // 
            draftingTextBox.Dock = DockStyle.Fill;
            draftingTextBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            draftingTextBox.Location = new Point(0, 24);
            draftingTextBox.Name = "draftingTextBox";
            draftingTextBox.Size = new Size(1316, 803);
            draftingTextBox.TabIndex = 1;
            draftingTextBox.Text = "";
            draftingTextBox.KeyDown += draftingTextBox_KeyDown;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(1316, 24);
            mainMenuStrip.TabIndex = 2;
            mainMenuStrip.Text = "File";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newProjectToolStripMenuItem, openProjectToolStripMenuItem, saveToolStripMenuItem, exportToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            newProjectToolStripMenuItem.Size = new Size(180, 22);
            newProjectToolStripMenuItem.Text = "New Project";
            newProjectToolStripMenuItem.Click += newProjectToolStripMenuItem_Click;
            // 
            // openProjectToolStripMenuItem
            // 
            openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            openProjectToolStripMenuItem.Size = new Size(180, 22);
            openProjectToolStripMenuItem.Text = "Open Project...";
            openProjectToolStripMenuItem.Click += openProjectToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveDraftToolStripMenuItem, saveMatrixToolStripMenuItem });
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveDraftToolStripMenuItem
            // 
            saveDraftToolStripMenuItem.Name = "saveDraftToolStripMenuItem";
            saveDraftToolStripMenuItem.Size = new Size(183, 22);
            saveDraftToolStripMenuItem.Text = "Save Current Draft";
            saveDraftToolStripMenuItem.Click += saveDraftToolStripMenuItem_Click;
            // 
            // saveMatrixToolStripMenuItem
            // 
            saveMatrixToolStripMenuItem.Name = "saveMatrixToolStripMenuItem";
            saveMatrixToolStripMenuItem.Size = new Size(183, 22);
            saveMatrixToolStripMenuItem.Text = "Save Current Outline";
            saveMatrixToolStripMenuItem.Click += saveMatrixToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(180, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // outliningTab
            // 
            outliningTab.Controls.Add(plottingSplitContainer);
            outliningTab.Location = new Point(4, 24);
            outliningTab.Name = "outliningTab";
            outliningTab.Padding = new Padding(3);
            outliningTab.Size = new Size(1576, 833);
            outliningTab.TabIndex = 1;
            outliningTab.Text = "Outlining";
            outliningTab.UseVisualStyleBackColor = true;
            // 
            // plottingSplitContainer
            // 
            plottingSplitContainer.Dock = DockStyle.Fill;
            plottingSplitContainer.FixedPanel = FixedPanel.Panel1;
            plottingSplitContainer.Location = new Point(3, 3);
            plottingSplitContainer.Name = "plottingSplitContainer";
            // 
            // plottingSplitContainer.Panel1
            // 
            plottingSplitContainer.Panel1.Controls.Add(panel1);
            plottingSplitContainer.Panel1.Controls.Add(plottingTreeView);
            plottingSplitContainer.Panel1.Controls.Add(treeView1);
            // 
            // plottingSplitContainer.Panel2
            // 
            plottingSplitContainer.Panel2.Controls.Add(plottingDataGridView);
            plottingSplitContainer.Size = new Size(1570, 827);
            plottingSplitContainer.SplitterDistance = 250;
            plottingSplitContainer.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(saveOutlineBtn);
            panel1.Controls.Add(newGridBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 727);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 100);
            panel1.TabIndex = 1;
            // 
            // saveOutlineBtn
            // 
            saveOutlineBtn.Location = new Point(5, 32);
            saveOutlineBtn.Name = "saveOutlineBtn";
            saveOutlineBtn.Size = new Size(98, 23);
            saveOutlineBtn.TabIndex = 1;
            saveOutlineBtn.Text = "Save Outline";
            saveOutlineBtn.UseVisualStyleBackColor = true;
            saveOutlineBtn.Click += saveOutlineBtn_Click;
            // 
            // newGridBtn
            // 
            newGridBtn.Location = new Point(5, 3);
            newGridBtn.Name = "newGridBtn";
            newGridBtn.Size = new Size(98, 23);
            newGridBtn.TabIndex = 0;
            newGridBtn.Text = "New Outline";
            newGridBtn.UseVisualStyleBackColor = true;
            newGridBtn.Click += newGridBtn_Click;
            // 
            // plottingTreeView
            // 
            plottingTreeView.Dock = DockStyle.Fill;
            plottingTreeView.Location = new Point(0, 0);
            plottingTreeView.Name = "plottingTreeView";
            plottingTreeView.Size = new Size(250, 827);
            plottingTreeView.TabIndex = 1;
            plottingTreeView.NodeMouseClick += plottingTreeView_NodeMouseClick;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(269, 525);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(121, 97);
            treeView1.TabIndex = 0;
            // 
            // plottingDataGridView
            // 
            plottingDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            plottingDataGridView.ContextMenuStrip = outliningContextMenu;
            plottingDataGridView.Dock = DockStyle.Fill;
            plottingDataGridView.Location = new Point(0, 0);
            plottingDataGridView.Name = "plottingDataGridView";
            plottingDataGridView.Size = new Size(1316, 827);
            plottingDataGridView.TabIndex = 0;
            // 
            // outliningContextMenu
            // 
            outliningContextMenu.Items.AddRange(new ToolStripItem[] { addColumnToolStripMenuItem, deleteColumnToolStripMenuItem });
            outliningContextMenu.Name = "outliningContextMenu";
            outliningContextMenu.Size = new Size(154, 48);
            // 
            // addColumnToolStripMenuItem
            // 
            addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            addColumnToolStripMenuItem.Size = new Size(153, 22);
            addColumnToolStripMenuItem.Text = "Add Column";
            addColumnToolStripMenuItem.Click += addColumnToolStripMenuItem_Click;
            // 
            // deleteColumnToolStripMenuItem
            // 
            deleteColumnToolStripMenuItem.Name = "deleteColumnToolStripMenuItem";
            deleteColumnToolStripMenuItem.Size = new Size(153, 22);
            deleteColumnToolStripMenuItem.Text = "Delete Column";
            deleteColumnToolStripMenuItem.Click += deleteColumnToolStripMenuItem_Click;
            // 
            // settingsTab
            // 
            settingsTab.Controls.Add(settingsPanel);
            settingsTab.Location = new Point(4, 24);
            settingsTab.Name = "settingsTab";
            settingsTab.Padding = new Padding(3);
            settingsTab.Size = new Size(1576, 833);
            settingsTab.TabIndex = 2;
            settingsTab.Text = "Settings";
            settingsTab.UseVisualStyleBackColor = true;
            // 
            // settingsPanel
            // 
            settingsPanel.AutoScroll = true;
            settingsPanel.Controls.Add(themeGroupBox);
            settingsPanel.Dock = DockStyle.Fill;
            settingsPanel.Location = new Point(3, 3);
            settingsPanel.Name = "settingsPanel";
            settingsPanel.Size = new Size(1570, 827);
            settingsPanel.TabIndex = 0;
            // 
            // themeGroupBox
            // 
            themeGroupBox.Controls.Add(darkModeRadioBtn);
            themeGroupBox.Controls.Add(lightModeRadioBtn);
            themeGroupBox.Location = new Point(0, 3);
            themeGroupBox.Name = "themeGroupBox";
            themeGroupBox.Size = new Size(200, 100);
            themeGroupBox.TabIndex = 0;
            themeGroupBox.TabStop = false;
            themeGroupBox.Text = "Theme";
            // 
            // darkModeRadioBtn
            // 
            darkModeRadioBtn.AutoSize = true;
            darkModeRadioBtn.Location = new Point(36, 54);
            darkModeRadioBtn.Name = "darkModeRadioBtn";
            darkModeRadioBtn.Size = new Size(49, 19);
            darkModeRadioBtn.TabIndex = 1;
            darkModeRadioBtn.TabStop = true;
            darkModeRadioBtn.Text = "Dark";
            darkModeRadioBtn.UseVisualStyleBackColor = true;
            darkModeRadioBtn.CheckedChanged += darkModeRadioBtn_CheckedChanged;
            // 
            // lightModeRadioBtn
            // 
            lightModeRadioBtn.AutoSize = true;
            lightModeRadioBtn.Location = new Point(36, 29);
            lightModeRadioBtn.Name = "lightModeRadioBtn";
            lightModeRadioBtn.Size = new Size(52, 19);
            lightModeRadioBtn.TabIndex = 0;
            lightModeRadioBtn.TabStop = true;
            lightModeRadioBtn.Text = "Light";
            lightModeRadioBtn.UseVisualStyleBackColor = true;
            lightModeRadioBtn.CheckedChanged += lightModeRadioBtn_CheckedChanged;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(180, 22);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(mainTabCtrl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caulfield";
            mainTabCtrl.ResumeLayout(false);
            writingTab.ResumeLayout(false);
            splitDraftingContainer.Panel1.ResumeLayout(false);
            splitDraftingContainer.Panel2.ResumeLayout(false);
            splitDraftingContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitDraftingContainer).EndInit();
            splitDraftingContainer.ResumeLayout(false);
            panel2.ResumeLayout(false);
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            outliningTab.ResumeLayout(false);
            plottingSplitContainer.Panel1.ResumeLayout(false);
            plottingSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)plottingSplitContainer).EndInit();
            plottingSplitContainer.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)plottingDataGridView).EndInit();
            outliningContextMenu.ResumeLayout(false);
            settingsTab.ResumeLayout(false);
            settingsPanel.ResumeLayout(false);
            themeGroupBox.ResumeLayout(false);
            themeGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl mainTabCtrl;
        private TabPage writingTab;
        private TabPage outliningTab;
        private TabPage settingsTab;
        private SplitContainer splitDraftingContainer;
        private TreeView draftsTreeView;
        private RichTextBox draftingTextBox;
        private Button deleteLockButton;
        private SplitContainer plottingSplitContainer;
        private TreeView treeView1;
        private TreeView plottingTreeView;
        private DataGridView plottingDataGridView;
        private Panel settingsPanel;
        private GroupBox themeGroupBox;
        private RadioButton darkModeRadioBtn;
        private RadioButton lightModeRadioBtn;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newProjectToolStripMenuItem;
        private ToolStripMenuItem openProjectToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem saveDraftToolStripMenuItem;
        private ToolStripMenuItem saveMatrixToolStripMenuItem;
        private Panel panel1;
        private Button newGridBtn;
        private Panel panel2;
        private ContextMenuStrip outliningContextMenu;
        private ToolStripMenuItem addColumnToolStripMenuItem;
        private ToolStripMenuItem deleteColumnToolStripMenuItem;
        private Button saveDraftBtn;
        private Button saveOutlineBtn;
        private ToolStripMenuItem exportToolStripMenuItem;
    }
}
