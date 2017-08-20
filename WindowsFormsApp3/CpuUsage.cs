namespace cpuUsageMonitor
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class CpuUsage
    {
        public NotifyIcon cpuIcon = new NotifyIcon();
        public SolidBrush brush = new SolidBrush(Color.White);
        public PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        public Timer cpuTimer = new Timer();
        public MainForm mainForm = new MainForm();
        ContextMenu settingsCMenu = new ContextMenu();
        MenuItem exitAppRamUsg = new MenuItem("Exit");
        MenuItem aboutAppRamUsg = new MenuItem("About");
        MenuItem ramAppSettingsUsg = new MenuItem("Settings");
        MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");


        public CpuUsage()
        {
            cpuTimer.Interval = 350;
        }

        public CpuUsage(int interval)
        {
            cpuTimer.Interval = interval;
            cpuTimer.Tick += cpuTimerTick;
            cpuTimer?.Start();
        }

        ~CpuUsage()
        {
            cpuTimer?.Stop();
            cpuTimer?.Dispose();

            cpuUsage?.Dispose();
            cpuUsage?.Close();

            brush?.Dispose();

            cpuIcon?.Icon?.Dispose();
            cpuIcon?.Dispose();
        }

        public void cpuTimerTick(object sender, EventArgs e)
        {

            Bitmap cpuBitmap = new Bitmap(16, 16);
            Graphics cpuGraphics = Graphics.FromImage(cpuBitmap);

            int cpuUsageVal = (int)cpuUsage.NextValue();

            cpuGraphics.Clear(Color.Transparent);
            cpuGraphics.DrawImageUnscaled(cpuBitmap, 0, 0);
            cpuGraphics.DrawString(cpuUsageVal.ToString(),
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brush,
                new RectangleF(0, 3, 16, 13));
            cpuGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

            cpuIcon.Icon = Icon.FromHandle(cpuBitmap.GetHicon());
            cpuIcon.Text = "CPU usage (%)";


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

            //changed to true so the next tick of the timer the application will exit.
        }

        public void appSettings_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Normal;
            mainForm.ShowInTaskbar = true;
        }

    }
}