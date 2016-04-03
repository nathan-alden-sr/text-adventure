namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariables
{
    partial class WorldVariablesView
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.ContextMenuStrip contextMenuStrip;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldVariablesView));
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.listViewVariables = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label1 = new System.Windows.Forms.Label();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 15);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 17);
            label1.TabIndex = 0;
            label1.Text = "Filter by category:";
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            toolStripSeparator1,
            this.toolStripMenuItemEdit,
            toolStripSeparator2,
            this.toolStripMenuItemDelete});
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new System.Drawing.Size(108, 82);
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            this.toolStripMenuItemNew.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemNew.Text = "&New...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Edit_16x;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemEdit.Text = "&Edit...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(104, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Remove_16x;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItemDelete.Text = "&Delete";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Items.AddRange(new object[] {
            "(All)"});
            this.comboBoxCategories.Location = new System.Drawing.Point(127, 12);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(200, 25);
            this.comboBoxCategories.TabIndex = 1;
            // 
            // listViewVariables
            // 
            this.listViewVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderCategory,
            this.columnHeaderType,
            this.columnHeaderValue});
            this.listViewVariables.ContextMenuStrip = contextMenuStrip;
            this.listViewVariables.FullRowSelect = true;
            this.listViewVariables.GridLines = true;
            this.listViewVariables.Location = new System.Drawing.Point(12, 43);
            this.listViewVariables.Name = "listViewVariables";
            this.listViewVariables.Size = new System.Drawing.Size(564, 383);
            this.listViewVariables.TabIndex = 2;
            this.listViewVariables.UseCompatibleStateImageBehavior = false;
            this.listViewVariables.View = System.Windows.Forms.View.Details;
            this.listViewVariables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewVariables_MouseDown);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // columnHeaderValue
            // 
            this.columnHeaderValue.Text = "Value";
            // 
            // WorldVariablesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 438);
            this.Controls.Add(this.listViewVariables);
            this.Controls.Add(label1);
            this.Controls.Add(this.comboBoxCategories);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorldVariablesView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "World Variables";
            contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.ListView listViewVariables;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderValue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
    }
}