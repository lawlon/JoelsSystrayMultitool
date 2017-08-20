using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace cpuUsageMonitor
{
    public class DiskUsage
    {

        private readonly PerformanceCounter diskReadTotal = new PerformanceCounter("PhysicalDisk", "Disk Reads/sec", "_Total");
        public readonly NotifyIcon diskReadTotalIcon = new NotifyIcon();
        public  SolidBrush brush = new SolidBrush(Color.White);
        private MainForm mainForm = new MainForm();
        public Timer diskTimer = new Timer();
        ContextMenu settingsCMenu = new ContextMenu();
        MenuItem exitAppRamUsg = new MenuItem("Exit");
        MenuItem aboutAppRamUsg = new MenuItem("About");
        MenuItem ramAppSettingsUsg = new MenuItem("Settings");
        MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");


        public DiskUsage()
        {
            diskTimer.Interval = 350;
            diskTimer.Tick += DiskReadTick;
            diskTimer.Start();
        }
        // destructor, disposes stuff.
        ~DiskUsage()
        {
            diskTimer?.Stop();
            diskTimer?.Dispose();

            brush?.Dispose();

            diskReadTotal?.Dispose();
            diskReadTotal.Close();

            diskReadTotalIcon?.Icon?.Dispose();
            diskReadTotalIcon?.Dispose();
            
        }

        public void DiskReadTick(object sender, EventArgs e)
        {


            string sDiskUsage = $"{diskReadTotal.NextValue():#:##}";

            Bitmap diskBitmap = new Bitmap(16, 16);

            Graphics diskGraphics = Graphics.FromImage(diskBitmap);

            diskGraphics.Clear(Color.Transparent);
            diskGraphics.DrawImageUnscaled(diskBitmap, 0, 0);
            diskGraphics.DrawString(diskReadTotal.ToString(),
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));

            diskGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            diskReadTotalIcon.Icon = Icon.FromHandle(diskBitmap.GetHicon());
            diskReadTotalIcon.Text = "Disk usage % (All Disks)";



            settingsCMenu.MenuItems.Add(programName);
            settingsCMenu.MenuItems.Add(exitAppRamUsg);
            settingsCMenu.MenuItems.Add(aboutAppRamUsg);
            settingsCMenu.MenuItems.Add(ramAppSettingsUsg);

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;

        }

        public void AboutApp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Joel's systray multitool V 1.1 \nWritten by joelazot\nSource Code:  ",
                "About Joel's systray multitool");
        }

        public void ExitApp_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();

        }

        public void appSettings_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.ShowInTaskbar = true;
        }
    }
}