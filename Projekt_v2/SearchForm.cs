using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_v2
{
    public partial class FormWebBrowser : Form
    {
        private string url;
        public FormWebBrowser(string url)
        {
            InitializeComponent();
            this.url = url;
            this.Load += FormWebBrowser_Load;
        }

        private void FormWebBrowser_Load(object sender, EventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;

            this.Controls.Add(webBrowser);

            webBrowser.Navigate(url);
        }
    }
}
