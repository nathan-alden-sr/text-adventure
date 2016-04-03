namespace NathanAlden.TextAdventure.Editor.Controllers.NewWorld
{
    partial class NewWorldView
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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWorldView));
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            this.pictureBoxValidationError = new System.Windows.Forms.PictureBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGenerateId = new System.Windows.Forms.Button();
            this.promptTextBoxVersion = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.promptTextBoxId = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.promptTextBoxAuthor = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.promptTextBoxWorldName = new NathanAlden.TextAdventure.Common.WindowsForms.Controls.PromptTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValidationError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(this.pictureBoxValidationError);
            flowLayoutPanel1.Controls.Add(this.buttonOk);
            flowLayoutPanel1.Controls.Add(this.buttonCancel);
            flowLayoutPanel1.Location = new System.Drawing.Point(244, 130);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(186, 28);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // pictureBoxValidationError
            // 
            this.pictureBoxValidationError.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "HasErrors", true));
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
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NathanAlden.TextAdventure.Editor.ViewModels.NewWorld.NewWorldViewModel);
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
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(430, 158);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(this.buttonGenerateId);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(this.promptTextBoxVersion);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(this.promptTextBoxId);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(this.promptTextBoxAuthor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(this.promptTextBoxWorldName);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(430, 118);
            panel1.TabIndex = 0;
            // 
            // buttonGenerateId
            // 
            this.buttonGenerateId.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonGenerateId.Location = new System.Drawing.Point(375, 0);
            this.buttonGenerateId.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGenerateId.Name = "buttonGenerateId";
            this.buttonGenerateId.Size = new System.Drawing.Size(55, 25);
            this.buttonGenerateId.TabIndex = 2;
            this.buttonGenerateId.Text = "Generate";
            this.buttonGenerateId.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(0, 96);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(54, 17);
            label4.TabIndex = 7;
            label4.Text = "Version:";
            // 
            // promptTextBoxVersion
            // 
            this.promptTextBoxVersion.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Version", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxVersion.Location = new System.Drawing.Point(82, 93);
            this.promptTextBoxVersion.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxVersion.Name = "promptTextBoxVersion";
            this.promptTextBoxVersion.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxVersion.PromptText = "e.g., 1.0";
            this.promptTextBoxVersion.Size = new System.Drawing.Size(105, 25);
            this.promptTextBoxVersion.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(0, 65);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(50, 17);
            label3.TabIndex = 5;
            label3.Text = "Author:";
            // 
            // promptTextBoxId
            // 
            this.promptTextBoxId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxId.Location = new System.Drawing.Point(82, 0);
            this.promptTextBoxId.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxId.Name = "promptTextBoxId";
            this.promptTextBoxId.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxId.PromptText = "e.g., 00000000-0000-0000-0000-000000000000";
            this.promptTextBoxId.Size = new System.Drawing.Size(287, 25);
            this.promptTextBoxId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(0, 34);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(82, 17);
            label2.TabIndex = 3;
            label2.Text = "World name:";
            // 
            // promptTextBoxAuthor
            // 
            this.promptTextBoxAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Author", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxAuthor.Location = new System.Drawing.Point(82, 62);
            this.promptTextBoxAuthor.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxAuthor.Name = "promptTextBoxAuthor";
            this.promptTextBoxAuthor.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxAuthor.PromptText = "e.g., Pat Smith";
            this.promptTextBoxAuthor.Size = new System.Drawing.Size(193, 25);
            this.promptTextBoxAuthor.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(0, 3);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(23, 17);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // promptTextBoxWorldName
            // 
            this.promptTextBoxWorldName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "WorldName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.promptTextBoxWorldName.Location = new System.Drawing.Point(82, 31);
            this.promptTextBoxWorldName.Margin = new System.Windows.Forms.Padding(0);
            this.promptTextBoxWorldName.Name = "promptTextBoxWorldName";
            this.promptTextBoxWorldName.PromptForeColor = System.Drawing.SystemColors.ControlDark;
            this.promptTextBoxWorldName.PromptText = "e.g., My World";
            this.promptTextBoxWorldName.Size = new System.Drawing.Size(193, 25);
            this.promptTextBoxWorldName.TabIndex = 4;
            // 
            // NewWorldView
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(487, 261);
            this.Controls.Add(tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewWorldView";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New World";
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValidationError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.PictureBox pictureBoxValidationError;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.BindingSource bindingSource;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxVersion;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxId;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxAuthor;
        private Common.WindowsForms.Controls.PromptTextBox promptTextBoxWorldName;
        private System.Windows.Forms.Button buttonGenerateId;
    }
}