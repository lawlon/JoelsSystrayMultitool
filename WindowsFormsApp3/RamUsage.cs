namespace cpuUsageMonitor
{
    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using Utilities;

    public class RamUsage
    {

        private readonly NotifyIcon ramIcon = new NotifyIcon();
        private readonly NotifyIcon availableRamIcon = new NotifyIcon();

        //private MainForm mainform = new MainForm();
        private readonly ContextMenu settingsCMenu = new ContextMenu();

        // Convert bytes to gibibytes
        private readonly float ramInGB = Ram.GetTotalMemoryInBytes() / 1073741824F;

        public RamUsage()
        {
            RamUtil r = new RamUtil();

            Initialize();

            r.PerformanceCounterEventHandler += PerformanceCounterEventHandler;
        }

        ~RamUsage()
        {
            ramIcon?.Icon?.Dispose();
            ramIcon?.Dispose();

            availableRamIcon?.Icon.Dispose();
            availableRamIcon?.Dispose();

            settingsCMenu?.Dispose();
        }

        private void Initialize()
        {
            ramIcon.Visible = true;
            ramIcon.Text = "Ram Usage (GB)";

            availableRamIcon.Visible = true;
            availableRamIcon.Text = "Available RAM (GB)";

            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");

            settingsCMenu.MenuItems.Add(programName);
            settingsCMenu.MenuItems.Add(exitAppRamUsg);
            settingsCMenu.MenuItems.Add(aboutAppRamUsg);
            settingsCMenu.MenuItems.Add(ramAppSettingsUsg);

            ramIcon.ContextMenu = settingsCMenu;
            availableRamIcon.ContextMenu = settingsCMenu;

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;

        }

        private void PerformanceCounterEventHandler(object sender, PerformanceCounterEventArgs performanceCounterEventArgs)
        {
            DrawRamUsage(performanceCounterEventArgs.RAMValue);
            DrawAvailableRam(performanceCounterEventArgs.RAMValue);
        }

        public void DrawRamUsage(float ram)
        {
            ramIcon?.Icon?.Dispose();

            Bitmap ramBitmap = new Bitmap(16, 16);
            Graphics ramGraphics = Graphics.FromImage(ramBitmap);
            SolidBrush brush = new SolidBrush(Color.White);

            float ramUsageGb = ramInGB - ram / 1024;
            string sRamUsage = $"{ramUsageGb:##.#}";

            ramGraphics.Clear(Color.Transparent);

            //ramGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //ramGraphics.CompositingQuality = CompositingQuality.HighQuality;
            //ramGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            ramGraphics.DrawImageUnscaled(ramBitmap, 0, 0);

            ramGraphics.DrawString(sRamUsage,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));

            ramGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            ramIcon.Icon = Icon.FromHandle(ramBitmap.GetHicon());

            brush?.Dispose();
            ramBitmap?.Dispose();
            ramGraphics?.Dispose();
        }

        public void DrawAvailableRam(float ram)
        {
            availableRamIcon?.Icon?.Dispose();

            Bitmap availableRamBitmap = new Bitmap(16, 16);
            Graphics availableRamGraphics = Graphics.FromImage(availableRamBitmap);
            SolidBrush brush = new SolidBrush(Color.White);

            float availableRamNextValFloat = ram;
            float ramUsageVal = availableRamNextValFloat / 1024;
            string sRamUsage = $"{ramUsageVal:##.#}";

            availableRamGraphics.Clear(Color.Transparent);

            //availableRamGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //availableRamGraphics.CompositingQuality = CompositingQuality.HighQuality;
            //availableRamGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            availableRamGraphics.DrawImageUnscaled(availableRamBitmap, 0, 0);

            availableRamGraphics.DrawString(sRamUsage,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));

            availableRamGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            availableRamIcon.Icon = Icon.FromHandle(availableRamBitmap.GetHicon());

            brush?.Dispose();
            availableRamBitmap?.Dispose();
            availableRamGraphics?.Dispose();
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
            //mainform.WindowState = FormWindowState.Normal;
            //mainform.ShowInTaskbar = true;
        }
    }
}