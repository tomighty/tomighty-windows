namespace Tomighty.Windows
{
    partial class ErrorReportWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReportWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.errorDescription = new System.Windows.Forms.TextBox();
            this.reportButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(55, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Oops! Looks like you found a bug in Tomighty. Below you can see the ugly details " +
    "of the bug. There\'s nothing to worry about, it\'s totally safe to close Tomighty." +
    " We apologize for the inconvenience.";
            // 
            // errorDescription
            // 
            this.errorDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.errorDescription.BackColor = System.Drawing.Color.White;
            this.errorDescription.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorDescription.Location = new System.Drawing.Point(17, 68);
            this.errorDescription.Multiline = true;
            this.errorDescription.Name = "errorDescription";
            this.errorDescription.ReadOnly = true;
            this.errorDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorDescription.Size = new System.Drawing.Size(364, 147);
            this.errorDescription.TabIndex = 2;
            this.errorDescription.WordWrap = false;
            // 
            // reportButton
            // 
            this.reportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reportButton.Location = new System.Drawing.Point(271, 274);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(110, 23);
            this.reportButton.TabIndex = 0;
            this.reportButton.Text = "Send Report Error";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tomighty.Windows.Properties.Resources.image_warning;
            this.pictureBox1.Location = new System.Drawing.Point(17, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(17, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "Anyway, it would be great if you send us an error report by clicking the button b" +
    "elow. Don\'t worry, no personal information will be sent, we only send the techni" +
    "cal tidbits about this error.";
            // 
            // progressLabel
            // 
            this.progressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.progressLabel.Location = new System.Drawing.Point(17, 274);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(248, 23);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "Progress message";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.progressLabel.Visible = false;
            // 
            // ErrorReportWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 313);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.errorDescription);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorReportWindow";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Error - Tomighty";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ErrorReportWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox errorDescription;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label progressLabel;
    }
}