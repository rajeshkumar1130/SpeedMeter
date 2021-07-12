using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Echevil;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace speedMeter
{
    public partial class Form1 : Form
    {
        static NetworkMonitor networkMonitor = new NetworkMonitor();
        static NetworkAdapter[] networkAdapters = networkMonitor.Adapters;
        public Form1()
        {
            InitializeComponent();
        }

        private string getDownloadSpeed()
        {
            string text = "-1";
            foreach (var adapter in networkAdapters)
            {
                text = $"{adapter.DownloadSpeed / Math.Pow(1024, 2):N1}";
                UploadText.Text = $"Отдача: {text}";
            }
            return text;
            //return text + "\nMB\\s";
        }
        private string getUploadSpeed()
        {
            string text = "-1";
            foreach (var adapter in networkAdapters)
            {
                text = $"{adapter.UploadSpeed / Math.Pow(1024, 2):N1}";
                DownloadText.Text = $"Загрузка: {text}";
            }
            return text;
            //return text + "\nMB\\s";
        }
        private Icon getUploadIcon()
        {
            using (Bitmap bitmap = new Bitmap(32, 32))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Font font = new Font("Microsoft Sans Serif", 26, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = getUploadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Red), new PointF(-6, -2));
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
                    Font font = new Font("Microsoft Sans Serif", 26, FontStyle.Regular, GraphicsUnit.Pixel);
                    string iconText = getDownloadSpeed();
                    g.DrawString(iconText, font, new SolidBrush(Color.Green), new PointF(-6, -2));
                }
                return Icon.FromHandle(bitmap.GetHicon());
            }
        }
        private void task()
        {
            Upload.Icon = getUploadIcon();
            Download.Icon = getDownloadIcon();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += (s, ex) => task();
            networkMonitor.StartMonitoring();
            Upload.Visible = true;
            Download.Visible = true;
        }
    }
}
