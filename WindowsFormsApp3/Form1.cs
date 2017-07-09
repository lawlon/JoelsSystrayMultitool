using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public int gay = 1;
        public int super = 5;
        private PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private NotifyIcon nIcon = new NotifyIcon();
        public Form1()
        {
            InitializeComponent();
            
            ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            
            timer1.Start();

        }

   

        private void AboutApp_Click(object sender, EventArgs e)
        {

            // Show a messsage box of information about the program.

            MessageBox.Show("cpuUsageMonitor v1.0 \nWritten by Joel / Azot", "About cpuUsageMonitor");
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {

            // set gay to zero so the if statement in the timer will become true and a whole bunch of shit will get disposed along with the application closing.
            gay = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(16, 16);

            // Create a new bitmap callede bmp

            Graphics gr = Graphics.FromImage(bmp);

            // Create a new drawing surface out of the bitmap

            nIcon.Visible = true;

            // Make sure the icon is actually visible.

            float meme = cpuUsage.NextValue();
            int dankMeme = (int)meme;
            gr.Clear(Color.Transparent);
            gr.DrawImageUnscaled(bmp, 0, 0);
            gr.DrawString(dankMeme.ToString(),
                new Font("Calibri", 7, FontStyle.Bold),
                new SolidBrush(Color.FromKnownColor(KnownColor.White)),
                new RectangleF(0, 3, 16, 13));
            nIcon.Icon = Icon.FromHandle(bmp.GetHicon());

            // Make a context menu and menu items.

            ContextMenu cMenu = new ContextMenu();
            MenuItem exitApp = new MenuItem("Exit");
            MenuItem aboutApp = new MenuItem("About");

            // Connect the context menu and the icon.

            nIcon.ContextMenu = cMenu;
            cMenu.MenuItems.Add(exitApp);
            cMenu.MenuItems.Add(aboutApp);

            // call the exitApp_click function when it is clicked, which closes the application.

            exitApp.Click += ExitApp_Click;
            
            if (gay == 0)
            {
                // dispose a whole bunch of shit and hopefully prevent memory leaks
                bmp.Dispose();
                cMenu.Dispose();
                gr.Dispose();
                timer1.Dispose();
                nIcon.Dispose();
                timer1.Stop();
                timer1.Dispose();
                this.Close();
                
            }
            // call the aboutApp_click function when its clicked and display a messagebox of about info.

            aboutApp.Click += AboutApp_Click;

        }
    }
}