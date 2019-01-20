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
    public partial class BL71_IEAddress : Form
    {
        public  BL71_Main Main;
        SQLite dal;

        public BL71_IEAddress()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void BL71_ImportExcel_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            AddIEAddress();
        }

        public void AddIEAddress()
        {
            if (dal == null) return;
            panMain.Controls.Clear();
            DataTable dt = dal.ExecuteDataTable("Select Title,IEAddress From IEAddress order By Sort");

            int padding = 25;//左边距
            int top = 10;//上边距

            for (int i = 1; i < dt.Rows.Count+1; i++)
            {
                if (Main.Width == 2560)//在分辨率为 2560下
                {
                    if (i % 18 == 0 && i != 0)
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding = 25;
                        top += 50;
                    }
                    else
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding += 140;
                    }
                }
                else if (Main.Width == 1920) //分辨率 1920*1080
                {
                    if (i % 13 == 0 && i != 0)
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding = 25;
                        top += 50;
                    }
                    else
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding += 140;
                    }
                }
                else //默认 1024
                {
                    if (i % 7 == 0 && i != 0)
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding = 25;
                        top += 50;
                    }
                    else
                    {
                        Button b = new Button();
                        b.BackgroundImage = Properties.Resources.BTN;
                        b.BackgroundImageLayout = ImageLayout.Stretch;
                        b.Size = new Size(130, 40);
                        b.Text = dt.Rows[i - 1]["Title"].ToString();
                        b.Tag = dt.Rows[i - 1]["IEAddress"].ToString();
                        b.Location = new Point(padding, top);
                        b.Click += B_Click;

                        panMain.Controls.Add(b);
                        padding += 140;
                    }
                }
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            GoHTML(b.Tag.ToString());
        }

        //执行HTML
        public void GoHTML(string URL)
        {
            BL71_WebKit from = new BL71_WebKit();
            from.URL = URL;
            Main.OpenForm(from);
            this.Close();
        }

        private void BL71_IEAddress_Resize(object sender, EventArgs e)
        {
            if(Main!=null)
              AddIEAddress();
        }
    }
}
