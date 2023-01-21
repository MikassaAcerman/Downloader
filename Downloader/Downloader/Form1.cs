using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Downloader
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download completed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                string url = textBox1.Text;
                Uri uri = new Uri(url);
                string fileName = uri.Segments[uri.Segments.Length - 1];
                if (folderBrowserDialog1.SelectedPath != "") textBox2.Text = folderBrowserDialog1.SelectedPath + fileName;
            }
            catch (Exception sss)
            {
                MessageBox.Show(sss.ToString());
            
            }


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

            try
            {
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                if (textBox1.TextLength == 0 || textBox2.TextLength == 0) MessageBox.Show("TextBoxs is empty !!!");
                else
                {
                    Uri imguri = new Uri(textBox1.Text);
                    wc.DownloadFileAsync(imguri, textBox2.Text);
                }
                textBox1.Text = "";
                progressBar1.Value = 0;
                textBox2.Text = "";

            }
            catch
            {
                MessageBox.Show("Internet error", "Message");
            }

           
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
