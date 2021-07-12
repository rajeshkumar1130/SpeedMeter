
namespace speedMeter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Upload = new System.Windows.Forms.NotifyIcon(this.components);
            this.Download = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.UploadText = new System.Windows.Forms.Label();
            this.DownloadText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Upload
            // 
            this.Upload.Text = "notifyIcon1";
            this.Upload.Visible = true;
            // 
            // Download
            // 
            this.Download.Text = "notifyIcon1";
            this.Download.Visible = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // UploadText
            // 
            this.UploadText.AutoSize = true;
            this.UploadText.ForeColor = System.Drawing.Color.Red;
            this.UploadText.Location = new System.Drawing.Point(110, 133);
            this.UploadText.Name = "UploadText";
            this.UploadText.Size = new System.Drawing.Size(46, 17);
            this.UploadText.TabIndex = 0;
            this.UploadText.Text = "label1";
            // 
            // DownloadText
            // 
            this.DownloadText.AutoSize = true;
            this.DownloadText.ForeColor = System.Drawing.Color.Green;
            this.DownloadText.Location = new System.Drawing.Point(110, 214);
            this.DownloadText.Name = "DownloadText";
            this.DownloadText.Size = new System.Drawing.Size(46, 17);
            this.DownloadText.TabIndex = 1;
            this.DownloadText.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 367);
            this.Controls.Add(this.DownloadText);
            this.Controls.Add(this.UploadText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Upload;
        private System.Windows.Forms.NotifyIcon Download;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label UploadText;
        private System.Windows.Forms.Label DownloadText;
    }
}

