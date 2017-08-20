namespace cpuUsageMonitor
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    

    internal class RamUsage
    {
        public NotifyIcon ramIcon = new NotifyIcon();
        public NotifyIcon availableRamIcon = new NotifyIcon();
        public Timer ramTimer = new Timer();
        public Timer availableRamTimer = new Timer();
        private readonly PerformanceCounter ramUsageVarLol = new PerformanceCounter("Memory", "Available MBytes");
        public SolidBrush brushvariable = new SolidBrush(Color.White);
        public Ram GetRam = new Ram();
        public MainForm mainform = new MainForm();
        ContextMenu settingsCMenu = new ContextMenu();
        MenuItem exitAppRamUsg = new MenuItem("Exit");
        MenuItem aboutAppRamUsg = new MenuItem("About");
        MenuItem ramAppSettingsUsg = new MenuItem("Settings");
        MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");
        float ramInGB = Ram.GetTotalMemoryInBytes() / 1000 / 1000 / 1000;

        public void Intervals()
        {
            ramTimer.Interval = 500;
            availableRamTimer.Interval = 500;
            
        }


        ~RamUsage()
        {
            ramIcon?.Dispose();
            ramIcon?.Icon?.Dispose();

            availableRamIcon?.Icon.Dispose();
            availableRamIcon?.Dispose();

            ramUsageVarLol?.Dispose();
            ramUsageVarLol?.Close();

            brushvariable?.Dispose();

            ramTimer?.Stop();
            ramTimer?.Dispose();

            settingsCMenu?.Dispose();

            exitAppRamUsg?.Dispose();
            aboutAppRamUsg?.Dispose();
            ramAppSettingsUsg?.Dispose();
            programName?.Dispose();

        }

        public void ramTimer_Tick(object sender, EventArgs e)
        {

            var ramBitmap = new Bitmap(16, 16);
            var ramGraphics = Graphics.FromImage(ramBitmap);

            var ramUsageNextVal = ramUsageVarLol.NextValue();
            var ramUsageGB = ramInGB - ramUsageNextVal / 1000;

            var formattedUsage = string.Join(".", Regex.Matches(ramUsageGB.ToString(), @"\d{1}")
                .OfType<Match>()
                .Select(m => m.Value).ToArray());
            ramGraphics.Clear(Color.Transparent);
            ramGraphics.DrawImageUnscaled(ramBitmap, 0, 0);

            var woahdankmeme = new string(formattedUsage.Take(3).ToArray());
            ramGraphics.DrawString(woahdankmeme,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brushvariable,
                new RectangleF(0, 3, 16, 13));
            ramGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            ramIcon.Icon = Icon.FromHandle(ramBitmap.GetHicon());




            settingsCMenu.MenuItems.Add(programName);
            settingsCMenu.MenuItems.Add(exitAppRamUsg);
            settingsCMenu.MenuItems.Add(aboutAppRamUsg);
            settingsCMenu.MenuItems.Add(ramAppSettingsUsg);

            exitAppRamUsg.Click += ExitApp_Click;
            aboutAppRamUsg.Click += AboutApp_Click;
            ramAppSettingsUsg.Click += appSettings_Click;
        }


        public void availableRamTimer_Tick(object sender, EventArgs e)
        {
            var availableRamBitmap = new Bitmap(16, 16);

            var availableRamGraphics = Graphics.FromImage(availableRamBitmap);
            var availableRamNextValFloat = ramUsageVarLol.NextValue();
            var ramUsageVal = availableRamNextValFloat / 1000;
            var formattedUsage = string.Join(".", Regex.Matches(ramUsageVal.ToString(), @"\d{1}")
                .OfType<Match>()
                .Select(m => m.Value).ToArray());

            availableRamGraphics.Clear(Color.Transparent);
            availableRamGraphics.DrawImageUnscaled(availableRamBitmap, 0, 0);

            var formattedAvailableRam = new string(formattedUsage.Take(3).ToArray());

            availableRamGraphics.DrawString(formattedAvailableRam,
                new Font("Trebuchet MS", 8.8f, FontStyle.Regular, GraphicsUnit.Pixel),
                brushvariable,
                new RectangleF(0, 3, 16, 13));

            availableRamGraphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
            availableRamIcon.Icon = Icon.FromHandle(availableRamBitmap.GetHicon());
            availableRamIcon.Text = "Available RAM (GB)";


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
            mainform.WindowState = FormWindowState.Normal;
            mainform.ShowInTaskbar = true;
        }

    }
}