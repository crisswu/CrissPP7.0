using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option_ConnectDB : Form
    {
        BL71_Main Main;
        SQLite dal;
        public BL71_Option_ConnectDB(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }
        #region 切换图片
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5_3;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5;
        }

        private void btnDele_MouseEnter(object sender, EventArgs e)
        {
            btnDele.Image = Properties.Resources.b4_2;
        }

        private void btnDele_MouseLeave(object sender, EventArgs e)
        {
            btnDele.Image = Properties.Resources.b4;
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
 

        #endregion

        private void BL71_Option_ConnectDB_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            cboID.SelectedIndex = 0;
            Querys();
        }
 
        //查询数据库中的信息
        public void Querys()
        {
            cboName.DisplayMember = "Name";
            cboName.ValueMember = "ID";
            cboName.DataSource = dal.ExecuteDataTable("Select ID,Name From Sys_dbs Order By ID");
        }
        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDBName.Text == "")
            {
                Main.AlertMsg("输入IP地址或者域名！");
                errorPro.SetError(txtDBName, "输入IP地址或者域名！");
                return;
            }
            if (txtName.Text == "")
            {
                Main.AlertMsg("输入登录账号！");
                errorPro.SetError(txtName, "输入登录账号！");
                return;
            }
            if (txtInName.Text == "")
            {
                Main.AlertMsg("输入名称！");
                errorPro.SetError(txtInName, "输入名称！");
                return;
            }
            string sql = "Insert into Sys_dbs(Name,IP,Types,LoginName,Password) Values('" + txtInName.Text + "','" + txtDBName.Text + "','" + cboID.SelectedItem.ToString() + "','" + txtName.Text + "','" + txtPwd.Text + "')";
            dal.ExecuteNonQuery(sql);
            UpdateVersion();
            Main.AlertMsg("添加完成！");
            Querys();
        }
        //选择
        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboName.SelectedValue == null || cboName.SelectedValue.ToString() == "") return;
            DataTable dt = dal.ExecuteDataTable("Select ID,Name,IP,Types,LoginName,Password From Sys_dbs where ID='" + cboName.SelectedValue + "'");
            txtDBName.Text = dt.Rows[0]["IP"].ToString();
            txtName.Text = dt.Rows[0]["LoginName"].ToString();
            txtPwd.Text = dt.Rows[0]["Password"].ToString();
            txtInName.Text = dt.Rows[0]["Name"].ToString();
            if (dt.Rows[0]["Types"].ToString() == "Windows 身份验证")
                cboID.SelectedIndex = 0;
            else
                cboID.SelectedIndex = 1;
        }
        //删除
        private void btnDele_Click(object sender, EventArgs e)
        {
            if (cboName.SelectedValue == null || cboName.SelectedValue.ToString() == "") return;
            if (MessageBox.Show("确定要删除吗", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                dal.ExecuteNonQuery("Delete From Sys_dbs where ID='" + cboName.SelectedValue + "'");
                UpdateVersion();
                txtDBName.Text = "";
                cboID.SelectedIndex = 0;
                txtName.Text = "";
                txtPwd.Text = "";
                txtInName.Text = ""; 
                Main.AlertMsg("删除完成！");
                Querys();
            }
        }
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
