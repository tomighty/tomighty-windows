namespace Tomighty.Windows
{
    partial class UserPreferencesForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.longBreakDurationTextBox = new System.Windows.Forms.NumericUpDown();
            this.shortBreakDurationTextBox = new System.Windows.Forms.NumericUpDown();
            this.pomodoroDurationTextBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maxPomodoroCountTextBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longBreakDurationTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortBreakDurationTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pomodoroDurationTextBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxPomodoroCountTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.longBreakDurationTextBox);
            this.groupBox1.Controls.Add(this.shortBreakDurationTextBox);
            this.groupBox1.Controls.Add(this.pomodoroDurationTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Time";
            // 
            // longBreakDurationTextBox
            // 
            this.longBreakDurationTextBox.Location = new System.Drawing.Point(69, 80);
            this.longBreakDurationTextBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.longBreakDurationTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.longBreakDurationTextBox.Name = "longBreakDurationTextBox";
            this.longBreakDurationTextBox.Size = new System.Drawing.Size(52, 20);
            this.longBreakDurationTextBox.TabIndex = 7;
            this.longBreakDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.longBreakDurationTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shortBreakDurationTextBox
            // 
            this.shortBreakDurationTextBox.Location = new System.Drawing.Point(69, 54);
            this.shortBreakDurationTextBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.shortBreakDurationTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shortBreakDurationTextBox.Name = "shortBreakDurationTextBox";
            this.shortBreakDurationTextBox.Size = new System.Drawing.Size(52, 20);
            this.shortBreakDurationTextBox.TabIndex = 4;
            this.shortBreakDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.shortBreakDurationTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pomodoroDurationTextBox
            // 
            this.pomodoroDurationTextBox.Location = new System.Drawing.Point(69, 28);
            this.pomodoroDurationTextBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.pomodoroDurationTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pomodoroDurationTextBox.Name = "pomodoroDurationTextBox";
            this.pomodoroDurationTextBox.Size = new System.Drawing.Size(52, 20);
            this.pomodoroDurationTextBox.TabIndex = 1;
            this.pomodoroDurationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.pomodoroDurationTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "minutes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "&Long break";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "minutes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "&Short break";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "minutes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Pomodoro";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.maxPomodoroCountTextBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Long Break Cycle";
            // 
            // maxPomodoroCountTextBox
            // 
            this.maxPomodoroCountTextBox.Location = new System.Drawing.Point(10, 48);
            this.maxPomodoroCountTextBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.maxPomodoroCountTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxPomodoroCountTextBox.Name = "maxPomodoroCountTextBox";
            this.maxPomodoroCountTextBox.Size = new System.Drawing.Size(52, 20);
            this.maxPomodoroCountTextBox.TabIndex = 1;
            this.maxPomodoroCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maxPomodoroCountTextBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "&Number of pomodoros before a long break:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(87, 233);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "O&K";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OnOkButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(168, 233);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // UserPreferencesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(255, 268);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserPreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tomighty Preferences";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.longBreakDurationTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortBreakDurationTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pomodoroDurationTextBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxPomodoroCountTextBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown maxPomodoroCountTextBox;
        private System.Windows.Forms.NumericUpDown longBreakDurationTextBox;
        private System.Windows.Forms.NumericUpDown shortBreakDurationTextBox;
        private System.Windows.Forms.NumericUpDown pomodoroDurationTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}