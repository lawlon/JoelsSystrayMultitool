namespace cpuUsageMonitor
{
    using Utilities;
    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class DiskUsage
    {
        private readonly NotifyIcon diskReadTotalIcon = new NotifyIcon();

        //private MainForm mainForm = new MainForm();
        private readonly ContextMenu settingsCMenu = new ContextMenu();

        public DiskUsage()
        {
            DiskUtil d = new DiskUtil();

            InitializeIcon();

            d.PerformanceCounterEventHandler += DrawDiskUsage;
        }

        ~DiskUsage()
        {
            diskReadTotalIcon?.Icon?.Dispose();
            diskReadTotalIcon?.Dispose();
        }

        private void InitializeIcon()
        {
            diskReadTotalIcon.Visible = true;
            diskReadTotalIcon.Text = "Disk usage % (All Disks)";

            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");

            settingsCMenu.MenuItems.Add(programName);
            settingsCMenu.MenuItems.Add(exitAppRamUsg);
            settingsCMenu.MenuItems.Add(aboutAppRamUsg);
            settingsCMenu.MenuItems.Add(ramAppSettingsUsg);

            diskReadTotalIcon.ContextMenu = settingsCMenu;

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;
        }

        public void DrawDiskUsage(object sender, PerformanceCounterEventArgs performanceCounterEventArgs)
        {
            diskReadTotalIcon?.Icon?.Dispose();

            Bitmap diskBitmap = new Bitmap(16, 16);
            Graphics diskGraphics = Graphics.FromImage(diskBitmap);
            SolidBrush brush = new SolidBrush(Color.White);

            string sDiskUsage = $"{performanceCounterEventArgs.DISKValue:#:##}";

            diskGraphics.Clear(Color.Transparent);

            //diskGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //diskGraphics.CompositingQuality = CompositingQuality.HighQuality;
            //diskGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            diskGraphics.DrawImageUnscaled(diskBitmap, 0, 0);

            diskGraphics.DrawString(sDiskUsage,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));

            diskGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            diskReadTotalIcon.Icon = Icon.FromHandle(diskBitmap.GetHicon());

            diskBitmap?.Dispose();
            diskGraphics?.Dispose();
            brush?.Dispose();
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
            //mainForm.WindowState = FormWindowState.Normal;
            //mainForm.ShowInTaskbar = true;
        }
    }
}