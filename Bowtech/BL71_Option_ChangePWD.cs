using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option_ChangePWD : Form
    {
        BL71_Main Main;
        SQLite dal;
        public BL71_Option_ChangePWD(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Main = M;

        }

        private void BL71_Option_NoteVisble_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
        }
        
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisble_Click(object sender, EventArgs e)
        {
            if (txtOldPwd.Text == "")
            {
                Main.AlertMsg("输入旧密码"); 
                return;
            }
            if (txtNew1.Text == "")
            {
                Main.AlertMsg("输入新密码"); 
                return;
            }
            if (txtNew2.Text == "")
            {
                Main.AlertMsg("输入确认密码"); 
                return;
            }
            if (txtTitle.Text == "")
            {
                Main.AlertMsg("输入提示信息"); 
                return;
            }
            if (txtNew1.Text != txtNew2.Text)
            {
                Main.AlertMsg("两次密码不一致"); 
                return;
            }
            EncryUtil EU = new EncryUtil();//加密类

            string strOld = "Select PassWord From PassWord";
            string pwd = dal.ExecuteString(strOld);
            if (EU.Enc(txtOldPwd.Text) != pwd)
            {
                Main.AlertMsg("旧始密码错误");
                return;
            }

            string sql = "Update PassWord Set password='" + EU.Enc(txtNew1.Text) + "',Title='"+txtTitle.Text+"'";
            dal.ExecuteNonQuery(sql);
            UpdateVersion();

            txtOldPwd.Text = "";
            txtNew1.Text ="";
            txtNew2.Text = "";
            txtTitle.Text = "";
             
            Main.AlertMsg("保存完成");
        }
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
        private void btnVisble_MouseEnter(object sender, EventArgs e)
        {
            btnGo.Image = Properties.Resources.b3_2;
        }

        private void btnVisble_MouseLeave(object sender, EventArgs e)
        {
            btnGo.Image = Properties.Resources.b3;
        }

        //更新版本号
        public void UpdateVersion()
        {
            int dbversion = dal.ExecuteInt("Select VersionID From Version");
            dbversion++;
            dal.ExecuteNonQuery("Update Version set VersionID='" + dbversion + "'");
        }

    }
}
