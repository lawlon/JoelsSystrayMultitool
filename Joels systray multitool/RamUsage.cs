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
        public DiskUsage loldisk = new DiskUsage();
        
        public void Intervals()
        {
            ramTimer.Interval = 500;
            availableRamTimer.Interval = 500;
            
        }


        public void ramTimer_Tick(object sender, EventArgs e)
        {

            var ramInBytes = Ram.GetTotalMemoryInBytes();
            var ramBitmap = new Bitmap(16, 16);

            var ramGraphics = Graphics.FromImage(ramBitmap);
            var ramInKbVar = ramInBytes / 1000;
            float ramFloatAsGB = ramInKbVar / 1000 / 1000;
            var ramUsageNextVal = ramUsageVarLol.NextValue();
            var ramUsageVal = ramUsageNextVal / 1000;
            var ramUsageGB = ramFloatAsGB - ramUsageVal;
            var ramUsageString = ramUsageGB.ToString();
            var formattedUsage = string.Join(".", Regex.Matches(ramUsageString, @"\d{1}")
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


            ContextMenu setingsMenu = new ContextMenu();
            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");


            setingsMenu.MenuItems.Add(programName);
            setingsMenu.MenuItems.Add(exitAppRamUsg);
            setingsMenu.MenuItems.Add(aboutAppRamUsg);
            setingsMenu.MenuItems.Add(ramAppSettingsUsg);

            exitAppRamUsg.Click += loldisk.ExitApp_Click;
            aboutAppRamUsg.Click += loldisk.AboutApp_Click;
            ramAppSettingsUsg.Click += loldisk.appSettings_Click;
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
            ContextMenu setingsMenu = new ContextMenu();
            MenuItem exitAppRamUsg = new MenuItem("Exit");
            MenuItem aboutAppRamUsg = new MenuItem("About");
            MenuItem ramAppSettingsUsg = new MenuItem("Settings");
            MenuItem programName = new MenuItem("Joel's Systray Multitool V 1.1");


            setingsMenu.MenuItems.Add(programName);
            setingsMenu.MenuItems.Add(exitAppRamUsg);
            setingsMenu.MenuItems.Add(aboutAppRamUsg);
            setingsMenu.MenuItems.Add(ramAppSettingsUsg);

            exitAppRamUsg.Click += loldisk.ExitApp_Click;
            aboutAppRamUsg.Click += loldisk.AboutApp_Click;
            ramAppSettingsUsg.Click += loldisk.appSettings_Click;
        }

    }
}