namespace TelnetTemp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostLabel = new System.Windows.Forms.Label();
            this.telnetLabel = new System.Windows.Forms.Label();
            this.telnetTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.intervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.autorunCheckBox = new System.Windows.Forms.CheckBox();
            this.hideToTrayCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(20, 38);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host";
            // 
            // telnetLabel
            // 
            this.telnetLabel.AutoSize = true;
            this.telnetLabel.Location = new System.Drawing.Point(12, 12);
            this.telnetLabel.Name = "telnetLabel";
            this.telnetLabel.Size = new System.Drawing.Size(37, 13);
            this.telnetLabel.TabIndex = 1;
            this.telnetLabel.Text = "Telnet";
            // 
            // telnetTextBox
            // 
            this.telnetTextBox.Location = new System.Drawing.Point(55, 9);
            this.telnetTextBox.Name = "telnetTextBox";
            this.telnetTextBox.Size = new System.Drawing.Size(164, 20);
            this.telnetTextBox.TabIndex = 2;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(55, 35);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(506, 20);
            this.hostTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Port";
            // 
            // portNumeric
            // 
            this.portNumeric.Location = new System.Drawing.Point(257, 9);
            this.portNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.portNumeric.Name = "portNumeric";
            this.portNumeric.Size = new System.Drawing.Size(63, 20);
            this.portNumeric.TabIndex = 5;
            this.portNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portNumeric.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Interval";
            // 
            // intervalNumeric
            // 
            this.intervalNumeric.Location = new System.Drawing.Point(55, 61);
            this.intervalNumeric.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.intervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalNumeric.Name = "intervalNumeric";
            this.intervalNumeric.Size = new System.Drawing.Size(83, 20);
            this.intervalNumeric.TabIndex = 7;
            this.intervalNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "min";
            // 
            // autorunCheckBox
            // 
            this.autorunCheckBox.AutoSize = true;
            this.autorunCheckBox.Location = new System.Drawing.Point(55, 87);
            this.autorunCheckBox.Name = "autorunCheckBox";
            this.autorunCheckBox.Size = new System.Drawing.Size(63, 17);
            this.autorunCheckBox.TabIndex = 9;
            this.autorunCheckBox.Text = "Autorun";
            this.autorunCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.autorunCheckBox.UseVisualStyleBackColor = true;
            // 
            // hideToTrayCheckBox
            // 
            this.hideToTrayCheckBox.AutoSize = true;
            this.hideToTrayCheckBox.Location = new System.Drawing.Point(55, 110);
            this.hideToTrayCheckBox.Name = "hideToTrayCheckBox";
            this.hideToTrayCheckBox.Size = new System.Drawing.Size(80, 17);
            this.hideToTrayCheckBox.TabIndex = 10;
            this.hideToTrayCheckBox.Text = "Hide to tray";
            this.hideToTrayCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hideToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 147);
            this.Controls.Add(this.hideToTrayCheckBox);
            this.Controls.Add(this.autorunCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.intervalNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.telnetTextBox);
            this.Controls.Add(this.telnetLabel);
            this.Controls.Add(this.hostLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelnetTemp [Settings]";
            ((System.ComponentModel.ISupportInitialize)(this.portNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label telnetLabel;
        private System.Windows.Forms.TextBox telnetTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown portNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown intervalNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox autorunCheckBox;
        private System.Windows.Forms.CheckBox hideToTrayCheckBox;
    }
}

