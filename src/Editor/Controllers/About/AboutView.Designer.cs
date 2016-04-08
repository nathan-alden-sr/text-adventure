namespace NathanAlden.TextAdventure.Editor.Controllers.About
{
    partial class AboutView
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.LinkLabel linkLabel;
            System.Windows.Forms.PictureBox pictureBox;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Button buttonClose;
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            linkLabel = new System.Windows.Forms.LinkLabel();
            pictureBox = new System.Windows.Forms.PictureBox();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            buttonClose = new System.Windows.Forms.Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(86, 0);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(209, 28);
            label1.TabIndex = 0;
            label1.Text = "Text Adventure Editor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(88, 28);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(127, 17);
            label2.TabIndex = 1;
            label2.Text = "by Nathan Alden, Sr.";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(linkLabel);
            panel1.Controls.Add(pictureBox);
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(295, 80);
            panel1.TabIndex = 1;
            // 
            // linkLabel
            // 
            linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
            linkLabel.AutoSize = true;
            linkLabel.LinkColor = System.Drawing.Color.Blue;
            linkLabel.Location = new System.Drawing.Point(88, 63);
            linkLabel.Margin = new System.Windows.Forms.Padding(0);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new System.Drawing.Size(162, 17);
            linkLabel.TabIndex = 2;
            linkLabel.TabStop = true;
            linkLabel.Text = "Visit the GitHub repository";
            linkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
            linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // pictureBox
            // 
            pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            pictureBox.Image = global::NathanAlden.TextAdventure.Editor.ImageResources.logo;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(80, 80);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(buttonClose, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanel1.Size = new System.Drawing.Size(295, 123);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            buttonClose.Location = new System.Drawing.Point(220, 95);
            buttonClose.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new System.Drawing.Size(75, 28);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // AboutView
            // 
            this.AcceptButton = buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = buttonClose;
            this.ClientSize = new System.Drawing.Size(340, 173);
            this.ControlBox = false;
            this.Controls.Add(tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AboutView";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}