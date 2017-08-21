namespace cpuUsageMonitor
{
    using Microsoft.Win32;
    using Properties;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private readonly NotifyIcon loadingIcon = new NotifyIcon();
        private readonly ColorDialog customColorDialog = new ColorDialog();
        private readonly ContextMenu settingsMenu = new ContextMenu();

        //public bool enableCPUColor = false;
        //public bool exitBool;

        private readonly SolidBrush brush = new SolidBrush(Color.White);

        private readonly RegistryKey regkey =
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        public MainForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;

            InitializeIcon();
            InitializeClasses();
        }

        private void InitializeIcon()
        {
            this.loadingIcon.Visible = true;
            this.loadingIcon.Text = "Access Settings";

            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");

            settingsMenu.MenuItems.Add(programName);
            settingsMenu.MenuItems.Add(exitAppRamUsg);
            settingsMenu.MenuItems.Add(aboutAppRamUsg);
            settingsMenu.MenuItems.Add(ramAppSettingsUsg);

            loadingIcon.ContextMenu = settingsMenu;

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;
        }

        private void InitializeClasses()
        {
            RamUsage ramUsage = new RamUsage();
            CpuUsage cpuUsage = new CpuUsage();
            DiskUsage diskUsage = new DiskUsage();
        }

        ~MainForm()
        {
            brush?.Dispose();
        }

        private void AboutApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Joel's systray multitool V 1.1 \nWritten by joelazot\nSource Code:  ",
                "About Joel's systray multitool");
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            //changed to true so the next tick of the timer the application will exit.
        }

        private void appSettings_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
        }

        // called when exit settings is clicked in the gui

        private void exitSettings(object sender, EventArgs e)
        {
            Settings.Default.Save();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            enableCpuMonitoring.Checked = Settings.Default.autoCheckCPU;
            enableRamMonitoring.Checked = Settings.Default.autoCheckRAM;
            displayAvailableRAM.Checked = Settings.Default.autoCheckAvailableRAM;

            enableDiskUsageMonitoring.Checked = Settings.Default.autoCheckDisk;
            customColorDialog.Color = Settings.Default.color;
            enableCustomColorsBox.Checked = Settings.Default.enablecolor;
            brush.Color = Settings.Default.color;

            #region IconStuff

            if (!enableCpuMonitoring.Checked && !enableDiskUsageMonitoring.Checked && !enableRamMonitoring.Checked && !displayAvailableRAM.Checked)
            {
                var loadingBitmap = new Bitmap(16, 16);
                var loadingGraphics = Graphics.FromImage(loadingBitmap);
                loadingGraphics.Clear(Color.Transparent);
                loadingGraphics.DrawImageUnscaled(loadingBitmap, 0, 0);
                loadingGraphics.DrawString("",
                    new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                    brush,
                    new RectangleF(0, 3, 16, 13));
                loadingGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                loadingIcon.Icon = Icon.FromHandle(loadingBitmap.GetHicon());

                this.ShowInTaskbar = true;
            }

            #endregion IconStuff

            /*#region this gonna be really fucking ugly sorry lads

            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM == true)
            {
                lolramusage.availableRamIcon.Visible = true;
                lolramusage.availableRamTimer.Start();
            }
            else
            {
                lolramusage.availableRamIcon.Visible = false;
            }
            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU == true)
            {
                lolcpu.cpuTimer.Start();
                lolcpu.cpuIcon.Visible = true;
            }
            else
            {
                lolcpu.cpuIcon.Visible = false;
            }
            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM == true)
            {
                lolramusage.ramTimer.Start();
                lolramusage.ramIcon.Visible = true;
            }
            else
            {
                lolramusage.ramIcon.Visible = false;
            }
            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckDisk == true)
            {
                loldisk.diskTimer.Start();
                loldisk.diskReadTotalIcon.Visible = true;
            }
            else
            {
                loldisk.diskReadTotalIcon.Visible = false;
            }

            #endregion this gonna be really fucking ugly sorry lads*/
        }

        // saves settings when the application exits.

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        // creates or deletes a registry key which adds this program to startup.

        private void runOnStartupCheckChanged(object sender, EventArgs e)
        {
            var regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            var appName = "Joel's systray multitool";
            if (runOnStartupBox.Checked)
                regkey.SetValue(appName, Application.ExecutablePath);
            else
                regkey.DeleteValue(appName, false);
        }

        private void enableCustomColors(object sender, EventArgs e)
        {
            /*brush.Color = customColorDialog.Color;
            //lolramusage.brushvariable.Color = customColorDialog.Color;
            loldisk.brush.Color = customColorDialog.Color;
            lolcpu.brush.Color = customColorDialog.Color;
            //lolramusage.brushvariable.Color = customColorDialog.Color;
            loldisk.brush.Color = customColorDialog.Color;
            lolcpu.brush.Color = customColorDialog.Color;*/
        }

        // brings up the custom colors dialog if "enable custom colors" is checked.

        private void changeColorsButton(object sender, EventArgs e)
        {
            if (enableCustomColorsBox.Checked)
            {
                customColorDialog.ShowDialog();
                brush.Color = customColorDialog.Color;
            }
        }



        #region to do list for this program

        /* figure out how to get cpu temps
        add disk usage with options for a specific disk to be selected
        make program look beautiful xd
        */

        #endregion to do list for this program
    }
}