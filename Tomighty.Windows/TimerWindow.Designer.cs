//
//  Tomighty - http://www.tomighty.org
//
//  This software is licensed under the Apache License Version 2.0:
//  http://www.apache.org/licenses/LICENSE-2.0.txt
//

namespace Tomighty.Windows
{
    partial class TimerWindow
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
            this.timeLabel = new Tomighty.Windows.TimerWindow.TransparentLabel();
            this.pinButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleLabel = new Tomighty.Windows.TimerWindow.TransparentLabel();
            this.timerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(12, 33);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(96, 46);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "--:--";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pinButton
            // 
            this.pinButton.CausesValidation = false;
            this.pinButton.FlatAppearance.BorderSize = 0;
            this.pinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pinButton.Image = global::Tomighty.Windows.Properties.Resources.Image_Unpinned;
            this.pinButton.Location = new System.Drawing.Point(2, 2);
            this.pinButton.Name = "pinButton";
            this.pinButton.Size = new System.Drawing.Size(22, 23);
            this.pinButton.TabIndex = 1;
            this.pinButton.TabStop = false;
            this.pinButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.CausesValidation = false;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::Tomighty.Windows.Properties.Resources.Image_X;
            this.closeButton.Location = new System.Drawing.Point(95, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(22, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.TabStop = false;
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(31, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(58, 30);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timerButton
            // 
            this.timerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerButton.BackColor = System.Drawing.Color.Silver;
            this.timerButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.timerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.timerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.timerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerButton.Location = new System.Drawing.Point(12, 85);
            this.timerButton.Name = "timerButton";
            this.timerButton.Size = new System.Drawing.Size(96, 23);
            this.timerButton.TabIndex = 4;
            this.timerButton.Text = "Timer Action";
            this.timerButton.UseVisualStyleBackColor = false;
            this.timerButton.Click += new System.EventHandler(this.OnTimerButtonClick);
            // 
            // TimerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(120, 120);
            this.ControlBox = false;
            this.Controls.Add(this.timerButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.pinButton);
            this.Controls.Add(this.timeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tomighty";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private TransparentLabel timeLabel;
        private System.Windows.Forms.Button pinButton;
        private System.Windows.Forms.Button closeButton;
        private TransparentLabel titleLabel;
        private System.Windows.Forms.Button timerButton;
    }
}