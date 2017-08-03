using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SystrayMultitool

{
    public partial class MainForm : Form
    {

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public bool exitBool = false;
        public PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public PerformanceCounter ramUsage = new PerformanceCounter("Memory", "Available MBytes");
        public PerformanceCounter availableRam = new PerformanceCounter("Memory", "Available MBytes");
        public NotifyIcon cpuIcon = new NotifyIcon();
        public NotifyIcon ramIcon = new NotifyIcon();
        public NotifyIcon availableRamIcon = new NotifyIcon();
        public SolidBrush brushVariable = new SolidBrush(Color.White);
        public ColorDialog customColorDialog = new ColorDialog();
        public bool enableCPUColor = false;



        public long ramInKbytes()
        {
            long memKb;
            GetPhysicallyInstalledSystemMemory(out memKb);
            return memKb;
        }

        public MainForm()
        {
            
            InitializeComponent();
            ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            saveSettingsTimer.Start();
        }
        
        private void AboutApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Joel's systray multitool \nWritten by joelazot\nSource Code: ", "About Joel's systray multitool");
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {

            exitBool = true;

            //changed to true so the next tick of the timer the application will exit.

        }

        private void appSettings_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void cpuTimerTick(object sender, EventArgs e)
        {

            Bitmap cpuBitmap = new Bitmap(16, 16);

            Graphics cpuGraphics = Graphics.FromImage(cpuBitmap);

            // make a icon and shit and put it in icon tray and wire it up to the corresponding variables.

            float cpuUsageNextVal = cpuUsage.NextValue();
            int cpuUsageVal = (int)cpuUsageNextVal;
            cpuGraphics.Clear(Color.Transparent);
            cpuGraphics.DrawImageUnscaled(cpuBitmap, 0, 0);
            cpuGraphics.DrawString(cpuUsageVal.ToString(),
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brushVariable,
                new RectangleF(0, 3, 16, 13));
            cpuGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            cpuIcon.Icon = Icon.FromHandle(cpuBitmap.GetHicon());
            cpuIcon.Text = "CPU usage (%)";

            // Make a context menu and menu items.

            ContextMenu cpuCMenu = new ContextMenu();
            MenuItem exitApp = new MenuItem("Exit");
            MenuItem aboutApp = new MenuItem("About");
            MenuItem appSettings = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.0");

            // Connect the context menu and the icon.

            cpuIcon.ContextMenu = cpuCMenu;
            cpuCMenu.MenuItems.Add(programName);
            cpuCMenu.MenuItems.Add(exitApp);
            cpuCMenu.MenuItems.Add(aboutApp);
            cpuCMenu.MenuItems.Add(appSettings);

            exitApp.Click += ExitApp_Click;
            aboutApp.Click += AboutApp_Click;
            appSettings.Click += appSettings_Click;

            if (exitBool == true)
            {
                this.Close();

            }
        }

        // called when exit settings is clicked in the gui

        private void exitSettings(object sender, EventArgs e)
        {
            cpuUsageMonitor.Properties.Settings.Default.Save();
            this.WindowState = FormWindowState.Minimized;
        }

        // ram icon function / method

        private void ramTimer_Tick(object sender, EventArgs e)
        {

            Bitmap ramBitmap = new Bitmap(16, 16);

            Graphics ramGraphics = Graphics.FromImage(ramBitmap);
            long ramInKbVar = ramInKbytes();
            float ramFloatAsGB = ramInKbVar / 1000 / 1000;
            float ramUsageNextVal = availableRam.NextValue();
            float ramUsageVal = ramUsageNextVal / 1000;
            float ramUsageGB = ramFloatAsGB - ramUsageVal;
            var ramUsageString = ramUsageGB.ToString();
            var formattedUsage = String.Join(".", Regex.Matches(ramUsageString, @"\d{1}")
                .OfType<Match>()
                .Select(m => m.Value).ToArray());
            ramGraphics.Clear(Color.Transparent);
            ramGraphics.DrawImageUnscaled(ramBitmap, 0, 0);
            string woahdankmeme = new string(formattedUsage.Take(3).ToArray());
            ramGraphics.DrawString(woahdankmeme,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brushVariable,
                new RectangleF(0, 3, 16, 13));
            ramGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            ramIcon.Icon = Icon.FromHandle(ramBitmap.GetHicon());
            ramIcon.Text = "RAM / Memory in use (GB)";
            ContextMenu ramCMENU = new ContextMenu();
            MenuItem exitAppRam = new MenuItem("Exit");
            MenuItem aboutAppRam = new MenuItem("About");
            MenuItem ramAppSettings = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.0");

            // Connect the context menu and the icon.

            ramIcon.ContextMenu = ramCMENU;
            ramCMENU.MenuItems.Add(programName);
            ramCMENU.MenuItems.Add(exitAppRam);
            ramCMENU.MenuItems.Add(aboutAppRam);
            ramCMENU.MenuItems.Add(ramAppSettings);

            exitAppRam.Click += ExitApp_Click;
            aboutAppRam.Click += AboutApp_Click;
            ramAppSettings.Click += appSettings_Click;

            if (exitBool == true)
            {
                this.Close();

            }
        }

        // called when the program starts and sets some variables to their corresponding saved settings
        // also sets the brush (text) color to white if enable custom colors isnt checked.

        private void MainForm_Load(object sender, EventArgs e)
        {

            enableCpuMonitoring.Checked = cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU;
            enableRamMonitoring.Checked = cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM;
            displayAvailableRAM.Checked = cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM;
            customColorDialog.Color = cpuUsageMonitor.Properties.Settings.Default.color;
            enableCustomColorsBox.Checked = cpuUsageMonitor.Properties.Settings.Default.enablecolor;
            brushVariable.Color = cpuUsageMonitor.Properties.Settings.Default.color;
            if (!enableCustomColorsBox.Checked)
            {
                brushVariable.Color = Color.White;
            }
            
           
            
        }

        // saves settings when the application exits.

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cpuUsageMonitor.Properties.Settings.Default.Save();
       
        }

        // function that saves settings automatically, so if it unexpectedly exits your settings will still be there.
        // it also starts the timers based on settings so we don't have to start them manually and disable them.

        private void settingsTimer(object sender, EventArgs e)
        {
            if (enableCustomColorsBox.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.color = customColorDialog.Color;
                cpuUsageMonitor.Properties.Settings.Default.enablecolor = true;
            }
            if (!enableCustomColorsBox.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.color = customColorDialog.Color;
                cpuUsageMonitor.Properties.Settings.Default.enablecolor = false;
            }
            if (enableCpuMonitoring.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU = true;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if (enableRamMonitoring.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM = true;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if (displayAvailableRAM.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM = true;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if(!displayAvailableRAM.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM = false;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if (!enableCpuMonitoring.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU = false;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if (!enableRamMonitoring.Checked)
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM = false;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU == true)
            {
                enableCpuMonitoring.Checked = true;
               
                cpuUsageMonitor.Properties.Settings.Default.Save();
                cpuIcon.Visible = true;
                if (cpuTimer.Enabled.Equals(false))
                {
                    cpuTimer.Start();
                }
            }
            else
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckCPU = false;
                cpuIcon.Visible = false;
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }

            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM == true)
            {
                ramIcon.Visible = true;
                enableRamMonitoring.Checked = true;
                cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM = true;
                cpuUsageMonitor.Properties.Settings.Default.Save();
                if (ramTimer.Enabled.Equals(false))
                {
                    ramTimer.Start();
                }
            }

            else
            {
                
                cpuUsageMonitor.Properties.Settings.Default.autoCheckRAM = false;
                ramIcon.Visible = false;
                cpuUsageMonitor.Properties.Settings.Default.Save();
                if (ramTimer.Enabled == true)
                {
                    ramTimer.Stop();
                }
            }
            cpuUsageMonitor.Properties.Settings.Default.Save();

            if (cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM == true)
            {
                cpuUsageMonitor.Properties.Settings.Default.Save();
                if(availableRamTimer.Enabled.Equals(false))
                {
                    availableRamIcon.Visible = true;
                    availableRamTimer.Start();
                    cpuUsageMonitor.Properties.Settings.Default.Save();
                }

            }
            else
            {
                cpuUsageMonitor.Properties.Settings.Default.autoCheckAvailableRAM = false;
                availableRamIcon.Visible = false;
                availableRamTimer.Stop();
                cpuUsageMonitor.Properties.Settings.Default.Save();
            }
        }

        // available ram function, makes a icon and makes it display the available ram in gigabytes and updates what like twice a second.

        private void availableRamTimer_Tick(object sender, EventArgs e)
        {
            
            Bitmap availableRamBitmap = new Bitmap(16, 16);

            Graphics availableRamGraphics = Graphics.FromImage(availableRamBitmap);
            float availableRamNextValFloat = availableRam.NextValue();
            float ramUsageVal = availableRamNextValFloat / 1000;
            var formattedUsage = String.Join(".", Regex.Matches(ramUsageVal.ToString(), @"\d{1}")
                .OfType<Match>()
                .Select(m => m.Value).ToArray());
            availableRamGraphics.Clear(Color.Transparent);
            availableRamGraphics.DrawImageUnscaled(availableRamBitmap, 0, 0);
            string formattedAvailableRam = new string(formattedUsage.Take(3).ToArray());
            availableRamGraphics.DrawString(formattedAvailableRam,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brushVariable,
                new RectangleF(0, 3, 16, 13));
            availableRamGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            availableRamIcon.Icon = Icon.FromHandle(availableRamBitmap.GetHicon());
            availableRamIcon.Text = "Available RAM (GB)";

            ContextMenu availableRamCMenu = new ContextMenu();
            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.0");

            // Connect the context menu and the icon.

            availableRamIcon.ContextMenu = availableRamCMenu;
            availableRamCMenu.MenuItems.Add(programName);
            availableRamCMenu.MenuItems.Add(exitAppRamUsg);
            availableRamCMenu.MenuItems.Add(aboutAppRamUsg);
            availableRamCMenu.MenuItems.Add(ramAppSettingsUsg);
            

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;

            if (exitBool == true)
            {
                this.Close();

            }
        }

        // creates or deletes a registry key which adds this program to startup.

        private void runOnStartupCheckChanged(object sender, EventArgs e)
        {
            RegistryKey regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            string appName = "Joel's systray multitool";
            if (runOnStartupBox.Checked)
            {
                regkey.SetValue(appName, Application.ExecutablePath);
            }
            else
            {
                regkey.DeleteValue(appName, false);
            }
        }
        
        private void enableCustomColors(object sender, EventArgs e)
        {
           if (!enableCustomColorsBox.Checked)
           {
                brushVariable.Color = Color.White;
           }
           if(enableCustomColorsBox.Checked)
            {
                brushVariable.Color = customColorDialog.Color;
            }

        }

        // brings up the custom colors dialog if "enable custom colors" is checked.

        private void changeColorsButton(object sender, EventArgs e)
        {
            if (enableCustomColorsBox.Checked)
            {
                customColorDialog.ShowDialog();
                brushVariable.Color = customColorDialog.Color;
            }
        }

    }
}