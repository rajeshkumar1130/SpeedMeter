using System;
using System.Drawing;
using Echevil;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace speedMeter
{
    public partial class Speed : Form
    {
        static NetworkMonitor networkMonitor = new NetworkMonitor();
        static NetworkAdapter[] networkAdapters = networkMonitor.Adapters;


        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);
        public Speed()
        {
            InitializeComponent();
            TrayMenuContext();
        }

        private string GetDownloadSpeed()
        {
            string text = "-1";
            long dlSpeed = 0;
            foreach (var adapter in networkAdapters)
            {
                dlSpeed += adapter.DownloadSpeed;
            }

            //text = $"{adapter.DownloadSpeed / Math.Pow(1024, 2):N1}";
            text = $"{dlSpeed / Math.Pow(1024, 1):N1}";
            DownloadText.Text = $"DL: {text}";
            return text;
        }
        private string GetUploadSpeed()
        {
            string text = "-1";
            long ulSpeed = 0;
            foreach (var adapter in networkAdapters)
            {
                ulSpeed += adapter.UploadSpeed;
            }

            text = $"{ulSpeed / Math.Pow(1024, 1):N1}";
            UploadText.Text = $"UL: {text}";
            return text;
        }
        private Icon GetUploadIcon()
        {
            //release previous handle
            if (Upload.Icon != null)
            {
                DestroyIcon(Upload.Icon.Handle);
            }

            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = GetUploadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Red), new PointF(-2, 4));
                }
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }
        private Icon GetDownloadIcon()
        {
            //release previous handle
            if (Upload.Icon != null)
            {
                DestroyIcon(Download.Icon.Handle);
            }

            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = GetDownloadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Green), new PointF(-2, 4));
                }
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }
        private void Task()
        {
            Download.Icon = GetDownloadIcon();
            Upload.Icon = GetUploadIcon();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += (s, ex) => Task();
            networkMonitor.StartMonitoring();
            Download.Visible = true;
            System.Threading.Thread.Sleep(100);
            Upload.Visible = true;
        }

        private void TrayMenuContext()
        {
            this.Download.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.Download.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);

            this.Upload.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.Upload.ContextMenuStrip.Items.Add("Exit", null, this.MenuExit_Click);
        }

        void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Download.Visible = false;
            Upload.Visible = false;
        }
    }
}
