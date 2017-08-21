namespace cpuUsageMonitor
{
    using System;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;
    using Utilities;

    public class CpuUsage
    {
        private readonly NotifyIcon cpuIcon = new NotifyIcon();

        //public MainForm mainForm = new MainForm();
        private readonly ContextMenu settingsCMenu = new ContextMenu();

        public CpuUsage()
        {
            CpuUtil c = new CpuUtil();

            InitializeIcon();

            c.PerformanceCounterEventHandler += DrawCpuUsage;
        }

        ~CpuUsage()
        {
            cpuIcon?.Icon?.Dispose();
            cpuIcon?.Dispose();
        }

        private void InitializeIcon()
        {
            cpuIcon.Visible = true;
            cpuIcon.Text = "CPU Usage (%)";

            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");

            settingsCMenu.MenuItems.Add(programName);
            settingsCMenu.MenuItems.Add(exitAppRamUsg);
            settingsCMenu.MenuItems.Add(aboutAppRamUsg);
            settingsCMenu.MenuItems.Add(ramAppSettingsUsg);

            cpuIcon.ContextMenu = settingsCMenu;

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;
        }

        public void DrawCpuUsage(object sender, PerformanceCounterEventArgs e)
        {
            cpuIcon?.Icon?.Dispose();

            Bitmap cpuBitmap = new Bitmap(16, 16);
            Graphics cpuGraphics = Graphics.FromImage(cpuBitmap);
            SolidBrush brush = new SolidBrush(Color.White);

            string cpuVal = $"{e.CPUValue:##}";

            cpuGraphics.Clear(Color.Transparent);

            //cpuGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //cpuGraphics.CompositingQuality = CompositingQuality.HighQuality;
            //cpuGraphics.SmoothingMode = SmoothingMode.AntiAlias;

            cpuGraphics.DrawImageUnscaled(cpuBitmap, 0, 0);

            cpuGraphics.DrawString(cpuVal,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));

            cpuGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            cpuIcon.Icon = Icon.FromHandle(cpuBitmap.GetHicon());

            cpuBitmap?.Dispose();
            cpuGraphics?.Dispose();
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