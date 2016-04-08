namespace NathanAlden.TextAdventure.Editor.Controllers.World
{
    partial class WorldView
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
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewWorld;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenWorld;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVariables;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTools;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
            System.Windows.Forms.ToolStrip toolStripFile;
            System.Windows.Forms.ToolStripButton toolStripButtonNewWorld;
            System.Windows.Forms.ToolStripButton toolStripButtonOpenWorld;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripButton toolStripButtonWorldVariables;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldView));
            this.toolStripMenuItemCloseWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveWorldAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonSaveWorld = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.toolStripWorld = new System.Windows.Forms.ToolStrip();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemNewWorld = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOpenWorld = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemVariables = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            toolStripFile = new System.Windows.Forms.ToolStrip();
            toolStripButtonNewWorld = new System.Windows.Forms.ToolStripButton();
            toolStripButtonOpenWorld = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripButtonWorldVariables = new System.Windows.Forms.ToolStripButton();
            menuStrip1.SuspendLayout();
            toolStripFile.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.toolStripWorld.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItemFile,
            this.toolStripMenuItemWorld,
            toolStripMenuItemTools,
            toolStripMenuItemHelp});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(332, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFile
            // 
            toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItemNewWorld,
            toolStripMenuItemOpenWorld,
            toolStripMenuItem1,
            this.toolStripMenuItemCloseWorld,
            toolStripMenuItem3,
            this.toolStripMenuItemSaveWorld,
            this.toolStripMenuItemSaveWorldAs,
            toolStripMenuItem2,
            toolStripMenuItemExit});
            toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            toolStripMenuItemFile.Size = new System.Drawing.Size(37, 20);
            toolStripMenuItemFile.Text = "&File";
            // 
            // toolStripMenuItemNewWorld
            // 
            toolStripMenuItemNewWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            toolStripMenuItemNewWorld.Name = "toolStripMenuItemNewWorld";
            toolStripMenuItemNewWorld.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            toolStripMenuItemNewWorld.Size = new System.Drawing.Size(190, 22);
            toolStripMenuItemNewWorld.Text = "&New World...";
            toolStripMenuItemNewWorld.Click += new System.EventHandler(this.toolStripMenuItemNewWorld_Click);
            // 
            // toolStripMenuItemOpenWorld
            // 
            toolStripMenuItemOpenWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Open_16x;
            toolStripMenuItemOpenWorld.Name = "toolStripMenuItemOpenWorld";
            toolStripMenuItemOpenWorld.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            toolStripMenuItemOpenWorld.Size = new System.Drawing.Size(190, 22);
            toolStripMenuItemOpenWorld.Text = "&Open World...";
            toolStripMenuItemOpenWorld.Click += new System.EventHandler(this.toolStripMenuItemOpenWorld_Click);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItemCloseWorld
            // 
            this.toolStripMenuItemCloseWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Close_16x;
            this.toolStripMenuItemCloseWorld.Name = "toolStripMenuItemCloseWorld";
            this.toolStripMenuItemCloseWorld.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemCloseWorld.Text = "&Close World";
            this.toolStripMenuItemCloseWorld.Click += new System.EventHandler(this.toolStripMenuItemCloseWorld_Click);
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItemSaveWorld
            // 
            this.toolStripMenuItemSaveWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Save_16x;
            this.toolStripMenuItemSaveWorld.Name = "toolStripMenuItemSaveWorld";
            this.toolStripMenuItemSaveWorld.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItemSaveWorld.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemSaveWorld.Text = "&Save World";
            this.toolStripMenuItemSaveWorld.Click += new System.EventHandler(this.toolStripMenuItemSaveWorld_Click);
            // 
            // toolStripMenuItemSaveWorldAs
            // 
            this.toolStripMenuItemSaveWorldAs.Name = "toolStripMenuItemSaveWorldAs";
            this.toolStripMenuItemSaveWorldAs.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemSaveWorldAs.Text = "Save World &As...";
            this.toolStripMenuItemSaveWorldAs.Click += new System.EventHandler(this.toolStripMenuItemSaveWorldAs_Click);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // toolStripMenuItemExit
            // 
            toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            toolStripMenuItemExit.ShortcutKeyDisplayString = "Alt+F4";
            toolStripMenuItemExit.Size = new System.Drawing.Size(190, 22);
            toolStripMenuItemExit.Text = "E&xit";
            toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemWorld
            // 
            this.toolStripMenuItemWorld.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItemVariables});
            this.toolStripMenuItemWorld.Name = "toolStripMenuItemWorld";
            this.toolStripMenuItemWorld.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItemWorld.Text = "&World";
            // 
            // toolStripMenuItemVariables
            // 
            toolStripMenuItemVariables.Image = global::NathanAlden.TextAdventure.Editor.IconResources.VariableProperty_16x;
            toolStripMenuItemVariables.Name = "toolStripMenuItemVariables";
            toolStripMenuItemVariables.Size = new System.Drawing.Size(129, 22);
            toolStripMenuItemVariables.Text = "&Variables...";
            toolStripMenuItemVariables.Click += new System.EventHandler(this.toolStripMenuItemVariables_Click);
            // 
            // toolStripMenuItemTools
            // 
            toolStripMenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItemOptions});
            toolStripMenuItemTools.Name = "toolStripMenuItemTools";
            toolStripMenuItemTools.Size = new System.Drawing.Size(47, 20);
            toolStripMenuItemTools.Text = "&Tools";
            // 
            // toolStripMenuItemOptions
            // 
            toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
            toolStripMenuItemOptions.Size = new System.Drawing.Size(125, 22);
            toolStripMenuItemOptions.Text = "&Options...";
            toolStripMenuItemOptions.Click += new System.EventHandler(this.toolStripMenuItemOptions_Click);
            // 
            // toolStripMenuItemHelp
            // 
            toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItemAbout});
            toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            toolStripMenuItemHelp.Size = new System.Drawing.Size(44, 20);
            toolStripMenuItemHelp.Text = "&Help";
            // 
            // toolStripMenuItemAbout
            // 
            toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            toolStripMenuItemAbout.Text = "&About";
            toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // toolStripFile
            // 
            toolStripFile.Dock = System.Windows.Forms.DockStyle.None;
            toolStripFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripButtonNewWorld,
            toolStripButtonOpenWorld,
            toolStripSeparator1,
            this.toolStripButtonSaveWorld});
            toolStripFile.Location = new System.Drawing.Point(3, 0);
            toolStripFile.Name = "toolStripFile";
            toolStripFile.Size = new System.Drawing.Size(78, 25);
            toolStripFile.TabIndex = 1;
            toolStripFile.Text = "toolStrip1";
            // 
            // toolStripButtonNewWorld
            // 
            toolStripButtonNewWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonNewWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            toolStripButtonNewWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonNewWorld.Name = "toolStripButtonNewWorld";
            toolStripButtonNewWorld.Size = new System.Drawing.Size(23, 22);
            toolStripButtonNewWorld.ToolTipText = "New World";
            toolStripButtonNewWorld.Click += new System.EventHandler(this.toolStripButtonNewWorld_Click);
            // 
            // toolStripButtonOpenWorld
            // 
            toolStripButtonOpenWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonOpenWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Open_16x;
            toolStripButtonOpenWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonOpenWorld.Name = "toolStripButtonOpenWorld";
            toolStripButtonOpenWorld.Size = new System.Drawing.Size(23, 22);
            toolStripButtonOpenWorld.ToolTipText = "Open World";
            toolStripButtonOpenWorld.Click += new System.EventHandler(this.toolStripButtonOpenWorld_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveWorld
            // 
            this.toolStripButtonSaveWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Save_16x;
            this.toolStripButtonSaveWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveWorld.Name = "toolStripButtonSaveWorld";
            this.toolStripButtonSaveWorld.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveWorld.ToolTipText = "Save World";
            this.toolStripButtonSaveWorld.Click += new System.EventHandler(this.toolStripButtonSaveWorld_Click);
            // 
            // toolStripButtonWorldVariables
            // 
            toolStripButtonWorldVariables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonWorldVariables.Image = global::NathanAlden.TextAdventure.Editor.IconResources.VariableProperty_16x;
            toolStripButtonWorldVariables.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonWorldVariables.Name = "toolStripButtonWorldVariables";
            toolStripButtonWorldVariables.Size = new System.Drawing.Size(23, 22);
            toolStripButtonWorldVariables.ToolTipText = "Variables";
            toolStripButtonWorldVariables.Click += new System.EventHandler(this.toolStripButtonWorldVariables_Click);
            // 
            // toolStripContainer
            // 
            this.toolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(332, 252);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(332, 277);
            this.toolStripContainer.TabIndex = 2;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(toolStripFile);
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripWorld);
            // 
            // toolStripWorld
            // 
            this.toolStripWorld.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripWorld.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripWorld.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripButtonWorldVariables});
            this.toolStripWorld.Location = new System.Drawing.Point(81, 0);
            this.toolStripWorld.Name = "toolStripWorld";
            this.toolStripWorld.Size = new System.Drawing.Size(57, 25);
            this.toolStripWorld.TabIndex = 2;
            // 
            // WorldView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 301);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "WorldView";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStripFile.ResumeLayout(false);
            toolStripFile.PerformLayout();
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.toolStripWorld.ResumeLayout(false);
            this.toolStripWorld.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveWorldAs;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWorld;
        private System.Windows.Forms.ToolStrip toolStripWorld;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
    }
}

