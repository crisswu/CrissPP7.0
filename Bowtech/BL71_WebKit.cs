using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections;
using WebKit;

namespace Bowtech
{
    public partial class BL71_WebKit : Form
    {
        public string URL = "";
        public BL71_WebKit()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void BL71_ImportExcel_Load(object sender, EventArgs e)
        {
            WebKit.WebKitBrowser browser = new WebKitBrowser();
            browser.Dock = DockStyle.Fill;
            this.Controls.Add(browser);
            browser.Navigate(URL);
        }
 
 
    }
}
