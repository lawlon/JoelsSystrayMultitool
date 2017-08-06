namespace SystrayMultitool
{
    partial class MainForm
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
            this.cpuTimer = new System.Windows.Forms.Timer(this.components);
            this.enableCpuMonitoring = new System.Windows.Forms.CheckBox();
            this.enableRamMonitoring = new System.Windows.Forms.CheckBox();
            this.exitSettingsButton = new System.Windows.Forms.Button();
            this.ramTimer = new System.Windows.Forms.Timer(this.components);
            this.displayAvailableRAM = new System.Windows.Forms.CheckBox();
            this.saveSettingsTimer = new System.Windows.Forms.Timer(this.components);
            this.availableRamTimer = new System.Windows.Forms.Timer(this.components);
            this.runOnStartupBox = new System.Windows.Forms.CheckBox();
            this.changeCustomColors = new System.Windows.Forms.Button();
            this.enableCustomColorsBox = new System.Windows.Forms.CheckBox();
            this.DiskReadTotalTimer = new System.Windows.Forms.Timer(this.components);
            this.enableDiskUsageMonitoring = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cpuTimer
            // 
            this.cpuTimer.Interval = 350;
            this.cpuTimer.Tick += new System.EventHandler(this.cpuTimerTick);
            // 
            // enableCpuMonitoring
            // 
            this.enableCpuMonitoring.AutoSize = true;
            this.enableCpuMonitoring.BackColor = System.Drawing.SystemColors.Control;
            this.enableCpuMonitoring.Checked = true;
            this.enableCpuMonitoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCpuMonitoring.Location = new System.Drawing.Point(9, 12);
            this.enableCpuMonitoring.Name = "enableCpuMonitoring";
            this.enableCpuMonitoring.Size = new System.Drawing.Size(117, 17);
            this.enableCpuMonitoring.TabIndex = 0;
            this.enableCpuMonitoring.Text = "Display CPU usage";
            this.enableCpuMonitoring.UseVisualStyleBackColor = false;
            // 
            // enableRamMonitoring
            // 
            this.enableRamMonitoring.AutoSize = true;
            this.enableRamMonitoring.BackColor = System.Drawing.SystemColors.Control;
            this.enableRamMonitoring.Location = new System.Drawing.Point(9, 35);
            this.enableRamMonitoring.Name = "enableRamMonitoring";
            this.enableRamMonitoring.Size = new System.Drawing.Size(119, 17);
            this.enableRamMonitoring.TabIndex = 1;
            this.enableRamMonitoring.Text = "Display RAM usage";
            this.enableRamMonitoring.UseVisualStyleBackColor = false;
            // 
            // exitSettingsButton
            // 
            this.exitSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exitSettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.exitSettingsButton.Location = new System.Drawing.Point(128, 294);
            this.exitSettingsButton.Name = "exitSettingsButton";
            this.exitSettingsButton.Size = new System.Drawing.Size(81, 22);
            this.exitSettingsButton.TabIndex = 2;
            this.exitSettingsButton.Text = "Exit settings";
            this.exitSettingsButton.UseVisualStyleBackColor = false;
            this.exitSettingsButton.Click += new System.EventHandler(this.exitSettings);
            // 
            // ramTimer
            // 
            this.ramTimer.Interval = 300;
            this.ramTimer.Tick += new System.EventHandler(this.ramTimer_Tick);
            // 
            // displayAvailableRAM
            // 
            this.displayAvailableRAM.AutoSize = true;
            this.displayAvailableRAM.Location = new System.Drawing.Point(9, 58);
            this.displayAvailableRAM.Name = "displayAvailableRAM";
            this.displayAvailableRAM.Size = new System.Drawing.Size(132, 17);
            this.displayAvailableRAM.TabIndex = 5;
            this.displayAvailableRAM.Text = "Display available RAM";
            this.displayAvailableRAM.UseVisualStyleBackColor = true;
            // 
            // saveSettingsTimer
            // 
            this.saveSettingsTimer.Enabled = true;
            this.saveSettingsTimer.Interval = 300;
            this.saveSettingsTimer.Tick += new System.EventHandler(this.settingsTimer);
            // 
            // availableRamTimer
            // 
            this.availableRamTimer.Interval = 300;
            this.availableRamTimer.Tick += new System.EventHandler(this.availableRamTimer_Tick);
            // 
            // runOnStartupBox
            // 
            this.runOnStartupBox.AutoSize = true;
            this.runOnStartupBox.Location = new System.Drawing.Point(9, 81);
            this.runOnStartupBox.Name = "runOnStartupBox";
            this.runOnStartupBox.Size = new System.Drawing.Size(102, 17);
            this.runOnStartupBox.TabIndex = 8;
            this.runOnStartupBox.Text = "Run on startup?";
            this.runOnStartupBox.UseVisualStyleBackColor = true;
            this.runOnStartupBox.CheckedChanged += new System.EventHandler(this.runOnStartupCheckChanged);
            // 
            // changeCustomColors
            // 
            this.changeCustomColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeCustomColors.Location = new System.Drawing.Point(266, 282);
            this.changeCustomColors.Name = "changeCustomColors";
            this.changeCustomColors.Size = new System.Drawing.Size(81, 34);
            this.changeCustomColors.TabIndex = 9;
            this.changeCustomColors.Text = "change color text icon color";
            this.changeCustomColors.UseVisualStyleBackColor = true;
            this.changeCustomColors.Click += new System.EventHandler(this.changeColorsButton);
            // 
            // enableCustomColorsBox
            // 
            this.enableCustomColorsBox.AutoSize = true;
            this.enableCustomColorsBox.Location = new System.Drawing.Point(9, 173);
            this.enableCustomColorsBox.Name = "enableCustomColorsBox";
            this.enableCustomColorsBox.Size = new System.Drawing.Size(126, 17);
            this.enableCustomColorsBox.TabIndex = 10;
            this.enableCustomColorsBox.Text = "enable custom colors";
            this.enableCustomColorsBox.UseVisualStyleBackColor = true;
            this.enableCustomColorsBox.CheckedChanged += new System.EventHandler(this.enableCustomColors);
            // 
            // DiskReadTotalTimer
            // 
            this.DiskReadTotalTimer.Interval = 300;
            this.DiskReadTotalTimer.Tick += new System.EventHandler(this.DiskReadTotalTimer_Tick);
            // 
            // enableDiskUsageMonitoring
            // 
            this.enableDiskUsageMonitoring.AutoSize = true;
            this.enableDiskUsageMonitoring.Location = new System.Drawing.Point(9, 118);
            this.enableDiskUsageMonitoring.Name = "enableDiskUsageMonitoring";
            this.enableDiskUsageMonitoring.Size = new System.Drawing.Size(114, 17);
            this.enableDiskUsageMonitoring.TabIndex = 11;
            this.enableDiskUsageMonitoring.Text = "Display disk usage";
            this.enableDiskUsageMonitoring.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(359, 328);
            this.ControlBox = false;
            this.Controls.Add(this.enableDiskUsageMonitoring);
            this.Controls.Add(this.enableCustomColorsBox);
            this.Controls.Add(this.changeCustomColors);
            this.Controls.Add(this.runOnStartupBox);
            this.Controls.Add(this.displayAvailableRAM);
            this.Controls.Add(this.exitSettingsButton);
            this.Controls.Add(this.enableRamMonitoring);
            this.Controls.Add(this.enableCpuMonitoring);
            this.Name = "MainForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer cpuTimer;
        private System.Windows.Forms.CheckBox enableCpuMonitoring;
        private System.Windows.Forms.CheckBox enableRamMonitoring;
        private System.Windows.Forms.Button exitSettingsButton;
        private System.Windows.Forms.Timer ramTimer;
        private System.Windows.Forms.CheckBox displayAvailableRAM;
        private System.Windows.Forms.Timer saveSettingsTimer;
        private System.Windows.Forms.Timer availableRamTimer;
        private System.Windows.Forms.CheckBox runOnStartupBox;
        private System.Windows.Forms.Button changeCustomColors;
        private System.Windows.Forms.CheckBox enableCustomColorsBox;
        private System.Windows.Forms.Timer DiskReadTotalTimer;
        private System.Windows.Forms.CheckBox enableDiskUsageMonitoring;
    }
}

