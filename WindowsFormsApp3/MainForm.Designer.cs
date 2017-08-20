namespace cpuUsageMonitor
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
            this.enableCpuMonitoring = new System.Windows.Forms.CheckBox();
            this.enableRamMonitoring = new System.Windows.Forms.CheckBox();
            this.exitSettingsButton = new System.Windows.Forms.Button();
            this.displayAvailableRAM = new System.Windows.Forms.CheckBox();
            this.runOnStartupBox = new System.Windows.Forms.CheckBox();
            this.changeCustomColors = new System.Windows.Forms.Button();
            this.enableCustomColorsBox = new System.Windows.Forms.CheckBox();
            this.enableDiskUsageMonitoring = new System.Windows.Forms.CheckBox();
            this.gBoxDisplaySettings = new System.Windows.Forms.GroupBox();
            this.gBoxAppSettings = new System.Windows.Forms.GroupBox();
            this.gBoxDisplaySettings.SuspendLayout();
            this.gBoxAppSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // enableCpuMonitoring
            // 
            this.enableCpuMonitoring.AutoSize = true;
            this.enableCpuMonitoring.BackColor = System.Drawing.SystemColors.Control;
            this.enableCpuMonitoring.Checked = true;
            this.enableCpuMonitoring.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCpuMonitoring.Location = new System.Drawing.Point(6, 19);
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
            this.enableRamMonitoring.Location = new System.Drawing.Point(6, 42);
            this.enableRamMonitoring.Name = "enableRamMonitoring";
            this.enableRamMonitoring.Size = new System.Drawing.Size(119, 17);
            this.enableRamMonitoring.TabIndex = 1;
            this.enableRamMonitoring.Text = "Display RAM usage";
            this.enableRamMonitoring.UseVisualStyleBackColor = false;
            // 
            // exitSettingsButton
            // 
            this.exitSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitSettingsButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.exitSettingsButton.Location = new System.Drawing.Point(9, 242);
            this.exitSettingsButton.Name = "exitSettingsButton";
            this.exitSettingsButton.Size = new System.Drawing.Size(81, 22);
            this.exitSettingsButton.TabIndex = 2;
            this.exitSettingsButton.Text = "Exit";
            this.exitSettingsButton.UseVisualStyleBackColor = false;
            this.exitSettingsButton.Click += new System.EventHandler(this.exitSettings);
            // 
            // displayAvailableRAM
            // 
            this.displayAvailableRAM.AutoSize = true;
            this.displayAvailableRAM.Location = new System.Drawing.Point(6, 65);
            this.displayAvailableRAM.Name = "displayAvailableRAM";
            this.displayAvailableRAM.Size = new System.Drawing.Size(133, 17);
            this.displayAvailableRAM.TabIndex = 5;
            this.displayAvailableRAM.Text = "Display Available RAM";
            this.displayAvailableRAM.UseVisualStyleBackColor = true;
            this.displayAvailableRAM.CheckedChanged += new System.EventHandler(this.displayAvailableRAM_CheckedChanged);
            // 
            // runOnStartupBox
            // 
            this.runOnStartupBox.AutoSize = true;
            this.runOnStartupBox.Location = new System.Drawing.Point(8, 52);
            this.runOnStartupBox.Name = "runOnStartupBox";
            this.runOnStartupBox.Size = new System.Drawing.Size(106, 17);
            this.runOnStartupBox.TabIndex = 8;
            this.runOnStartupBox.Text = "Run On Startup?";
            this.runOnStartupBox.UseVisualStyleBackColor = true;
            this.runOnStartupBox.CheckedChanged += new System.EventHandler(this.runOnStartupCheckChanged);
            // 
            // changeCustomColors
            // 
            this.changeCustomColors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.changeCustomColors.Location = new System.Drawing.Point(101, 236);
            this.changeCustomColors.Name = "changeCustomColors";
            this.changeCustomColors.Size = new System.Drawing.Size(81, 34);
            this.changeCustomColors.TabIndex = 9;
            this.changeCustomColors.Text = "Change Colors";
            this.changeCustomColors.UseVisualStyleBackColor = true;
            this.changeCustomColors.Click += new System.EventHandler(this.changeColorsButton);
            // 
            // enableCustomColorsBox
            // 
            this.enableCustomColorsBox.AutoSize = true;
            this.enableCustomColorsBox.Location = new System.Drawing.Point(8, 29);
            this.enableCustomColorsBox.Name = "enableCustomColorsBox";
            this.enableCustomColorsBox.Size = new System.Drawing.Size(129, 17);
            this.enableCustomColorsBox.TabIndex = 10;
            this.enableCustomColorsBox.Text = "Enable Custom Colors";
            this.enableCustomColorsBox.UseVisualStyleBackColor = true;
            this.enableCustomColorsBox.CheckedChanged += new System.EventHandler(this.enableCustomColors);
            // 
            // enableDiskUsageMonitoring
            // 
            this.enableDiskUsageMonitoring.AutoSize = true;
            this.enableDiskUsageMonitoring.Location = new System.Drawing.Point(6, 88);
            this.enableDiskUsageMonitoring.Name = "enableDiskUsageMonitoring";
            this.enableDiskUsageMonitoring.Size = new System.Drawing.Size(118, 17);
            this.enableDiskUsageMonitoring.TabIndex = 11;
            this.enableDiskUsageMonitoring.Text = "Display Disk Usage";
            this.enableDiskUsageMonitoring.UseVisualStyleBackColor = true;
            // 
            // gBoxDisplaySettings
            // 
            this.gBoxDisplaySettings.Controls.Add(this.enableCpuMonitoring);
            this.gBoxDisplaySettings.Controls.Add(this.enableDiskUsageMonitoring);
            this.gBoxDisplaySettings.Controls.Add(this.enableRamMonitoring);
            this.gBoxDisplaySettings.Controls.Add(this.displayAvailableRAM);
            this.gBoxDisplaySettings.Location = new System.Drawing.Point(9, 12);
            this.gBoxDisplaySettings.Name = "gBoxDisplaySettings";
            this.gBoxDisplaySettings.Size = new System.Drawing.Size(173, 119);
            this.gBoxDisplaySettings.TabIndex = 12;
            this.gBoxDisplaySettings.TabStop = false;
            this.gBoxDisplaySettings.Text = "Display Settings";
            // 
            // gBoxAppSettings
            // 
            this.gBoxAppSettings.Controls.Add(this.enableCustomColorsBox);
            this.gBoxAppSettings.Controls.Add(this.runOnStartupBox);
            this.gBoxAppSettings.Location = new System.Drawing.Point(9, 137);
            this.gBoxAppSettings.Name = "gBoxAppSettings";
            this.gBoxAppSettings.Size = new System.Drawing.Size(173, 83);
            this.gBoxAppSettings.TabIndex = 13;
            this.gBoxAppSettings.TabStop = false;
            this.gBoxAppSettings.Text = "Application Settings";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(194, 282);
            this.ControlBox = false;
            this.Controls.Add(this.gBoxAppSettings);
            this.Controls.Add(this.gBoxDisplaySettings);
            this.Controls.Add(this.changeCustomColors);
            this.Controls.Add(this.exitSettingsButton);
            this.Name = "MainForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gBoxDisplaySettings.ResumeLayout(false);
            this.gBoxDisplaySettings.PerformLayout();
            this.gBoxAppSettings.ResumeLayout(false);
            this.gBoxAppSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button exitSettingsButton;
        private System.Windows.Forms.Button changeCustomColors;
        private System.Windows.Forms.GroupBox gBoxDisplaySettings;
        private System.Windows.Forms.GroupBox gBoxAppSettings;
        public System.Windows.Forms.CheckBox enableCpuMonitoring;
        public System.Windows.Forms.CheckBox enableRamMonitoring;
        public System.Windows.Forms.CheckBox displayAvailableRAM;
        public System.Windows.Forms.CheckBox runOnStartupBox;
        public System.Windows.Forms.CheckBox enableCustomColorsBox;
        public System.Windows.Forms.CheckBox enableDiskUsageMonitoring;
    }
}

