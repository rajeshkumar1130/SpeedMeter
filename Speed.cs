using System;
using System.Drawing;
using Echevil;
using System.Windows.Forms;

namespace speedMeter
{
    public partial class Speed : Form
    {
        static NetworkMonitor networkMonitor = new NetworkMonitor();
        static NetworkAdapter[] networkAdapters = networkMonitor.Adapters;
        public Speed()
        {
            InitializeComponent();
            TrayMenuContext();
        }

        private string getDownloadSpeed()
        {
            string text = "-1";
            foreach (var adapter in networkAdapters)
            {
                text = $"{adapter.DownloadSpeed / Math.Pow(1024, 2):N1}";
                UploadText.Text = $"DL: {text}";
            }
            return text;
        }
        private string getUploadSpeed()
        {
            string text = "-1";
            foreach (var adapter in networkAdapters)
            {
                text = $"{adapter.UploadSpeed / Math.Pow(1024, 2):N1}";
                DownloadText.Text = $"UL: {text}";
            }
            return text;
        }
        private Icon getUploadIcon()
        {
            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = getUploadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Red), new PointF(-2, -2));
                }
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }
        private Icon getDownloadIcon()
        {
            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = getDownloadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Green), new PointF(-2, -2));
                }
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }
        private void Task()
        {
            try
            {
                Download.Icon = getDownloadIcon();
                Upload.Icon = getUploadIcon();
            }
            catch (Exception ex)
            {
                //continue;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 500;
            timer.Tick += (s, ex) => Task();
            networkMonitor.StartMonitoring();
            Download.Visible = true;
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
