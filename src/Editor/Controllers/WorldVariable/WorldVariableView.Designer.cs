namespace NathanAlden.TextAdventure.Editor.Controllers.WorldVariable
{
    partial class WorldVariableView
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldVariableView));
            this.bindingComboBoxType = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.BindingComboBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.promptTextBoxValue = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.promptTextBoxName = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.promptTextBoxCategory = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.pictureBoxValidationError = new System.Windows.Forms.PictureBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValidationError)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(360, 206);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(this.bindingComboBoxType);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(this.promptTextBoxValue);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(this.promptTextBoxName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(this.promptTextBoxCategory);
            panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(360, 168);
            panel1.TabIndex = 0;
            // 
            // bindingComboBoxType
            // 
            this.bindingComboBoxType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource, "Type", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.bindingComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bindingComboBoxType.FormattingEnabled = true;
            this.bindingComboBoxType.Location = new System.Drawing.Point(64, 62);
            this.bindingComboBoxType.Margin = new System.Windows.Forms.Padding(0);
            this.bindingComboBoxType.Name = "bindingComboBoxType";
            this.bindingComboBoxType.Size = new System.Drawing.Size(105, 25);
            this.bindingComboBoxType.TabIndex = 6;
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = false;
            this.bindingSource.DataSource = typeof(NathanAlden.TextAdventure.Editor.Controllers.WorldVariables.WorldVariableViewModel);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(0, 96);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(42, 17);
            label4.TabIndex = 7;
            label4.Text = "Value:";
            // 
            // promptTextBoxValue
            // 
            this.promptTextBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.promptTextBoxValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Value", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxValue.Location = new System.Drawing.Point(64, 93);
            this.promptTextBoxValue.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxValue.MaxLength = 0;
            this.promptTextBoxValue.Multiline = true;
            this.promptTextBoxValue.Name = "promptTextBoxValue";
            this.promptTextBoxValue.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxValue.PromptText = "(optional)";
            this.promptTextBoxValue.Size = new System.Drawing.Size(296, 75);
            this.promptTextBoxValue.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(0, 65);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(38, 17);
            label3.TabIndex = 5;
            label3.Text = "Type:";
            // 
            // promptTextBoxName
            // 
            this.promptTextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.promptTextBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxName.Location = new System.Drawing.Point(64, 0);
            this.promptTextBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxName.Name = "promptTextBoxName";
            this.promptTextBoxName.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxName.Size = new System.Drawing.Size(296, 25);
            this.promptTextBoxName.TabIndex = 1;
            this.promptTextBoxName.Leave += new System.EventHandler(this.promptTextBoxName_Leave);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 34);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 17);
            label2.TabIndex = 3;
            label2.Text = "Category:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 3);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 17);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // promptTextBoxCategory
            // 
            this.promptTextBoxCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Category", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxCategory.Location = new System.Drawing.Point(64, 31);
            this.promptTextBoxCategory.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxCategory.Name = "promptTextBoxCategory";
            this.promptTextBoxCategory.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxCategory.PromptText = "(optional)";
            this.promptTextBoxCategory.Size = new System.Drawing.Size(193, 25);
            this.promptTextBoxCategory.TabIndex = 4;
            this.promptTextBoxCategory.Leave += new System.EventHandler(this.promptTextBoxCategory_Leave);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(this.pictureBoxValidationError);
            flowLayoutPanel1.Controls.Add(this.buttonOk);
            flowLayoutPanel1.Controls.Add(this.buttonCancel);
            flowLayoutPanel1.Location = new System.Drawing.Point(174, 178);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(186, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // pictureBoxValidationError
            // 
            this.pictureBoxValidationError.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "HasErrors", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.pictureBoxValidationError.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxValidationError.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxValidationError.Image")));
            this.pictureBoxValidationError.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxValidationError.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxValidationError.Name = "pictureBoxValidationError";
            this.pictureBoxValidationError.Size = new System.Drawing.Size(16, 28);
            this.pictureBoxValidationError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxValidationError.TabIndex = 2;
            this.pictureBoxValidationError.TabStop = false;
            // 
            // buttonOk
            // 
            this.buttonOk.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSource, "IsValid", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(26, 0);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 28);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(111, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 28);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // WorldVariableView
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(384, 230);
            this.Controls.Add(tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 219);
            this.Name = "WorldVariableView";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValidationError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxValue;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxName;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxCategory;
        private System.Windows.Forms.PictureBox pictureBoxValidationError;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private NathanAlden.TextAdventure.Common.WindowsForms.Controls.BindingComboBox bindingComboBoxType;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}