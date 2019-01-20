using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option_NoteVisble : Form
    {
        BL71_Main Main;
        SQLite dal;
        public BL71_Option_NoteVisble(BL71_Main M)
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
            AddNewMain();
        }
        public void AddNewMain()
        {
            tvMain.Nodes.Clear();
            string sql = "Select * from Notes where FatherID=0  Order by OrderBy";
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["FatherID"].ToString() == "0")
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dt.Rows[i]["Name"].ToString();
                    tn.Tag = dt.Rows[i]["ID"].ToString();
                    if (dt.Rows[i]["Visble"].ToString() == "1")
                        tn.Checked = true;
                    tvMain.Nodes.Add(tn);
                }
            }
        }
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisble_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tvMain.Nodes.Count; i++)
            {
                string visble = tvMain.Nodes[i].Checked ? "1" : "0";
                string sql = "Update Notes Set Visble='" + visble + "' where ID='" + tvMain.Nodes[i].Tag + "'";
                dal.ExecuteNonQuery(sql);

                UpdateVersion();
            }
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
            btnVisble.Image = Properties.Resources.b3_2;
        }

        private void btnVisble_MouseLeave(object sender, EventArgs e)
        {
            btnVisble.Image = Properties.Resources.b3;
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
