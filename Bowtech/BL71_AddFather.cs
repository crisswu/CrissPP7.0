using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_AddFather : Form
    {
        SQLite dal;
        public BL71_Bowtech bowtech;
        public BL71_Main Main;
        public string ID = "";

        public BL71_AddFather(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            Main = M;
        }

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
            bowtech.txtContent.Visible = true;
            bowtech.picClose.Visible = true;
            this.Close();
        }
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5_3;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5;
        }
        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAddFather.Text == "")
            {
                Main.AlertMsg("输入根节点名称");
                return;
            }

            int maxID = dal.ExecuteInt("Select Max(ID) from Notes");
            maxID++;
            string sql = "Insert into Notes(ID,Name,Type,Content,FatherID,GrandID,OrderBy) values(" + maxID + ",'" + Filter(txtAddFather.Text) + "',0,'',0,0," + maxID + ")";
            dal.ExecuteNonQuery(sql);

            UpdateVersion();

            bowtech.txtContent.Visible = true;
            bowtech.picClose.Visible = true;
            this.Close();
        }
        //过滤器
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }

        //更新版本号
        public void UpdateVersion()
        {
            int dbversion = dal.ExecuteInt("Select VersionID From Version");
            dbversion++;
            dal.ExecuteNonQuery("Update Version set VersionID='" + dbversion + "'");
            Main.lblVersion.Text = "请上传版本";

            Main.AlertMsg("保存完成！");
            bowtech.ChangeMode(bowtech.FATHERID);
        }
    }
}
