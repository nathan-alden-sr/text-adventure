namespace NathanAlden.TextAdventure.Editor.Forms
{
    partial class WorldEditorForm
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
            System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
            System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
            System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldEditorForm));
            this.toolStripMenuItemOpenWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCloseWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveWorld = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveWorldAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonNewWorld = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOpenWorld = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveWorld = new System.Windows.Forms.ToolStripButton();
            this.toolStripMenuItemNewWorld = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileToolStripMenuItem,
            toolsToolStripMenuItem,
            helpToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(332, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNewWorld,
            this.toolStripMenuItemOpenWorld,
            toolStripMenuItem1,
            this.toolStripMenuItemCloseWorld,
            toolStripMenuItem3,
            this.toolStripMenuItemSaveWorld,
            this.toolStripMenuItemSaveWorldAs,
            toolStripMenuItem2,
            this.toolStripMenuItemExit});
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItemOpenWorld
            // 
            this.toolStripMenuItemOpenWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Open_16x;
            this.toolStripMenuItemOpenWorld.Name = "toolStripMenuItemOpenWorld";
            this.toolStripMenuItemOpenWorld.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemOpenWorld.Text = "&Open World...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItemCloseWorld
            // 
            this.toolStripMenuItemCloseWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Close_16x;
            this.toolStripMenuItemCloseWorld.Name = "toolStripMenuItemCloseWorld";
            this.toolStripMenuItemCloseWorld.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemCloseWorld.Text = "&Close World";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItemSaveWorld
            // 
            this.toolStripMenuItemSaveWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Save_16x;
            this.toolStripMenuItemSaveWorld.Name = "toolStripMenuItemSaveWorld";
            this.toolStripMenuItemSaveWorld.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemSaveWorld.Text = "&Save World";
            // 
            // toolStripMenuItemSaveWorldAs
            // 
            this.toolStripMenuItemSaveWorldAs.Name = "toolStripMenuItemSaveWorldAs";
            this.toolStripMenuItemSaveWorldAs.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemSaveWorldAs.Text = "Save World &As...";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemExit.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOptions});
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // toolStripMenuItemOptions
            // 
            this.toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
            this.toolStripMenuItemOptions.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItemOptions.Text = "&Options...";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemAbout.Text = "&About";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNewWorld,
            this.toolStripButtonOpenWorld,
            toolStripSeparator1,
            this.toolStripButtonSaveWorld});
            toolStrip1.Location = new System.Drawing.Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(332, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonNewWorld
            // 
            this.toolStripButtonNewWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            this.toolStripButtonNewWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewWorld.Name = "toolStripButtonNewWorld";
            this.toolStripButtonNewWorld.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewWorld.ToolTipText = "New World";
            // 
            // toolStripButtonOpenWorld
            // 
            this.toolStripButtonOpenWorld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Open_16x;
            this.toolStripButtonOpenWorld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenWorld.Name = "toolStripButtonOpenWorld";
            this.toolStripButtonOpenWorld.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenWorld.ToolTipText = "Open World";
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
            // 
            // toolStripMenuItemNewWorld
            // 
            this.toolStripMenuItemNewWorld.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            this.toolStripMenuItemNewWorld.Name = "toolStripMenuItemNewWorld";
            this.toolStripMenuItemNewWorld.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItemNewWorld.Text = "&New World...";
            // 
            // WorldEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 341);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WorldEditorForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCloseWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSaveWorldAs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNewWorld;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenWorld;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewWorld;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenWorld;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveWorld;
    }
}

