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
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
            System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.Button buttonCancel;
            System.Windows.Forms.Button buttonOk;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldVariablesView));
            this.dataGridViewVariables = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.bindingSourceFilter = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceVariables = new System.Windows.Forms.BindingSource(this.components);
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel1 = new System.Windows.Forms.Panel();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            buttonCancel = new System.Windows.Forms.Button();
            buttonOk = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFilter)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVariables)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(this.dataGridViewVariables);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(this.comboBoxCategories);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(426, 148);
            panel1.TabIndex = 0;
            // 
            // dataGridViewVariables
            // 
            this.dataGridViewVariables.AllowUserToAddRows = false;
            this.dataGridViewVariables.AllowUserToDeleteRows = false;
            this.dataGridViewVariables.AllowUserToResizeRows = false;
            this.dataGridViewVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.columnCategory,
            this.columnType,
            this.columnValue});
            this.dataGridViewVariables.ContextMenuStrip = this.contextMenuStrip;
            this.dataGridViewVariables.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewVariables.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridViewVariables.Name = "dataGridViewVariables";
            this.dataGridViewVariables.ReadOnly = true;
            this.dataGridViewVariables.RowHeadersVisible = false;
            this.dataGridViewVariables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVariables.Size = new System.Drawing.Size(426, 157);
            this.dataGridViewVariables.TabIndex = 0;
            this.dataGridViewVariables.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewVariables_CellMouseDoubleClick);
            this.dataGridViewVariables.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewVariables_KeyDown);
            this.dataGridViewVariables.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewVariables_MouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemNew,
            toolStripMenuItem1,
            this.toolStripMenuItemEdit,
            toolStripMenuItem2,
            this.toolStripMenuItemDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 82);
            // 
            // toolStripMenuItemNew
            // 
            this.toolStripMenuItemNew.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Create_16x;
            this.toolStripMenuItemNew.Name = "toolStripMenuItemNew";
            this.toolStripMenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItemNew.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemNew.Text = "&New...";
            this.toolStripMenuItemNew.Click += new System.EventHandler(this.toolStripMenuItemNew_Click);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Edit_16x;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemEdit.Text = "&Edit...";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(147, 6);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::NathanAlden.TextAdventure.Editor.IconResources.Remove_16x;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItemDelete.Text = "&Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(-3, 3);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(112, 17);
            label1.TabIndex = 1;
            label1.Text = "Filter by category:";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DataSource = this.bindingSourceFilter;
            this.comboBoxCategories.DisplayMember = "Name";
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(115, 0);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(200, 25);
            this.comboBoxCategories.TabIndex = 2;
            this.comboBoxCategories.ValueMember = "Category";
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
            // 
            // bindingSourceFilter
            // 
            this.bindingSourceFilter.DataSource = typeof(NathanAlden.TextAdventure.Editor.Controllers.WorldVariables.CategoryFilterViewModel);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new System.Drawing.Size(426, 186);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(buttonCancel);
            flowLayoutPanel1.Controls.Add(buttonOk);
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new System.Drawing.Point(266, 158);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(160, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            buttonCancel.Location = new System.Drawing.Point(85, 0);
            buttonCancel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(75, 28);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonOk.Location = new System.Drawing.Point(0, 0);
            buttonOk.Margin = new System.Windows.Forms.Padding(0);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(75, 28);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            // 
            // bindingSourceVariables
            // 
            this.bindingSourceVariables.AllowNew = false;
            this.bindingSourceVariables.DataSource = typeof(NathanAlden.TextAdventure.Editor.Controllers.WorldVariables.WorldVariableViewModel);
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "Name";
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnCategory
            // 
            this.columnCategory.DataPropertyName = "Category";
            this.columnCategory.HeaderText = "Category";
            this.columnCategory.Name = "columnCategory";
            this.columnCategory.ReadOnly = true;
            // 
            // columnType
            // 
            this.columnType.DataPropertyName = "TypeDescription";
            this.columnType.HeaderText = "Type";
            this.columnType.Name = "columnType";
            this.columnType.ReadOnly = true;
            // 
            // columnValue
            // 
            this.columnValue.DataPropertyName = "Value";
            this.columnValue.HeaderText = "Value";
            this.columnValue.Name = "columnValue";
            this.columnValue.ReadOnly = true;
            this.columnValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // WorldVariablesView
            // 
            this.AcceptButton = buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = buttonCancel;
            this.ClientSize = new System.Drawing.Size(456, 216);
            this.Controls.Add(tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(472, 255);
            this.Name = "WorldVariablesView";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "World Variables";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVariables)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFilter)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVariables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCategories;
        private System.Windows.Forms.DataGridView dataGridViewVariables;
        private System.Windows.Forms.BindingSource bindingSourceVariables;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.BindingSource bindingSourceFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnValue;
    }
}