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
    public partial class BL71_Lock : Form
    {
        public  BL71_Main Main;
        SQLite dal;

        public BL71_Lock(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }

        private void BL71_ImportExcel_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            txtPassWrod.Focus();

            if (Main.WindowState == FormWindowState.Maximized)
            {
                int mainWith = Main.Size.Width;//窗体总宽度
                int mainHeight = Main.Size.Height;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith - 200, picClose.Location.Y);
            }
        }
        //执行HTML
        public void GoHTML(string URL)
        {

        }

        #region 关闭窗体
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
        //关闭当前窗体
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void btnPrv_MouseEnter(object sender, EventArgs e)
        {
            btnPrv.Image = Properties.Resources.InPrv2;
        }

        private void btnPrv_MouseLeave(object sender, EventArgs e)
        {
            btnPrv.Image = Properties.Resources.InPrv1;
        }
        //进入密码
        private void btnPrv_Click(object sender, EventArgs e)
        {
            EncryUtil EU = new EncryUtil();//加密类
            string strOld = "Select PassWord From PassWord";
            string pwd = dal.ExecuteString(strOld);
            if (EU.Enc(txtPassWrod.Text) != pwd)
            {
                lblTitle.Text = "提示信息:" + dal.ExecuteString("Select Title From PassWord");
                txtPassWrod.SelectAll();
                return;
            }
            else
            {
                btnPrv.Image = Properties.Resources.InPrv2;
                Application.DoEvents();

                BL71_Private from = new BL71_Private(Main);
                Main.panBody.Controls.Clear();
                from.TopLevel = false;
                from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Main.panBody.Controls.Add(from);
                from.Dock = DockStyle.Fill;
                from.Main = Main;
                from.AddTree();
                from.Show();
            }


        }

        private void txtPassWrod_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
                btnPrv_Click(null, null);
        }

        private void BL71_Lock_Resize(object sender, EventArgs e)
        {
            if (Main.WindowState == FormWindowState.Maximized)//支持最大化
            {
                int mainWith = Main.Size.Width;//窗体总宽度
                int mainHeight = Main.Size.Height;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith - 200, picClose.Location.Y);

 
            }
            else
            {
                picClose.Location = new Point(794, 0);
 
            }
        }
    }
}
