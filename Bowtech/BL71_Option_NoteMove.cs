using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option_NoteMove : Form
    {
        SQLite dal;
        public BL71_Option_NoteMove()
        {
            InitializeComponent();
            DoubleBuffered = true;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
        }

        private void BL71_Option_NoteMove_Load(object sender, EventArgs e)
        {
            AddNewMain();
            AddMove();
        }
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
        public void AddNewMain()
        {
            tvMain.Nodes.Clear();
            string sql = "Select * from Notes where FatherID=0 and Visble=0 Order by OrderBy";
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["FatherID"].ToString() == "0")
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dt.Rows[i]["Name"].ToString();
                    tn.Tag = dt.Rows[i]["ID"].ToString();
                    //AddTreeItem(dt, tn, dt.Rows[i]["ID"].ToString());
                    TreeNode tns = new TreeNode();
                    tns.Text = "";
                    tn.Nodes.Add(tns);
                    tvMain.Nodes.Add(tn);
                }
            }
        }
        bool IsAddTsmi = false;//是否已加载移动数据
        //加载移动数据
        public void AddMove()
        {
            #region 移动追加列
            if (IsAddTsmi == false)
            {
                //添加移动事件
                tsmiMove.DropDownItems.Clear();
                string sql = "Select * from Notes where FatherID=0  Order by OrderBy";
                DataTable dt = dal.ExecuteDataTable(sql);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem(dt.Rows[i]["Name"].ToString());
                    tsmi.Tag = dt.Rows[i]["ID"].ToString();
                    tsmi.Click += new EventHandler(tsmis_Click);
                    AddTSMI(tsmi, dt.Rows[i]["ID"].ToString());
                    tsmiMove.DropDownItems.Add(tsmi);
                }
                IsAddTsmi = true;
            }
            #endregion
        }
        //递归添加移动菜单
        public void AddTSMI(ToolStripMenuItem tsmi, string FatherID)
        {
            string sql = "Select * from Notes where FatherID=" + FatherID + " and Type=1";
            DataTable dt = dal.ExecuteDataTable(sql);
            if (dt == null) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ToolStripMenuItem tsmis = new ToolStripMenuItem(dt.Rows[i]["Name"].ToString());
                tsmis.Tag = dt.Rows[i]["ID"].ToString();
                tsmis.Click += new EventHandler(tsmis_Click);
                AddTSMI(tsmis, dt.Rows[i]["ID"].ToString());
                tsmi.DropDownItems.Add(tsmis);
            }
        }
        //移动更新事件
        void tsmis_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmis = (ToolStripMenuItem)sender;
            string thisID = tvMain.SelectedNode.Tag.ToString();
            string NewID = tsmis.Tag.ToString();
            string sql = "Select * From Notes where ID=" + NewID;
            DataTable dt = dal.ExecuteDataTable(sql);
            sql = "Update Notes Set FatherID=" + dt.Rows[0]["ID"] + ",GrandID=" + dt.Rows[0]["GrandID"] + " where ID=" + thisID;
            dal.ExecuteNonQuery(sql);
            UpdateVersion();
            cmsOrder.Close();
            AddNewMain();
        }
        //加载选中项目
        private void tvMain_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                string sql = "Select * from Notes where FatherID=" + e.Node.Tag + " Order by OrderBy";
                DataTable dt = dal.ExecuteDataTable(sql);
                e.Node.Nodes.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Type"].ToString() == "2")
                    {
                        TreeNode tn2 = new TreeNode();
                        tn2.Text = dt.Rows[i]["Name"].ToString();
                        tn2.Tag = dt.Rows[i]["ID"].ToString();
                        e.Node.Nodes.Add(tn2);

                    }
                    else
                    {
                        TreeNode tn2 = new TreeNode();
                        tn2.Text = dt.Rows[i]["Name"].ToString();
                        tn2.Tag = dt.Rows[i]["ID"].ToString();
                        TreeNode tns = new TreeNode();
                        tns.Text = "";
                        tn2.Nodes.Add(tns);
                        e.Node.Nodes.Add(tn2);
                    }
                }
            }
        }
        //点击默认树
        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //colorNode.ForeColor = Color.Navy;
            //tvMain.SelectedNode.ForeColor = Color.Orange;
            //colorNode = tvMain.SelectedNode;
            //btnTitle.Text = "";
            //txtContent.Text = "";
            //string sql = "Select * from Notes Where ID='" + tvMain.SelectedNode.Tag.ToString() + "'";
            //DataTable dt = dal.ExecuteDataTable(sql);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    if (dt.Rows[0]["IsNet"].ToString() == "0")
            //    {
            //        wbHtml.Visible = false;
            //        btnTitle.Text = dt.Rows[0]["Name"].ToString();
            //        txtContent.Text = dt.Rows[0]["Content"].ToString();
            //    }
            //    else
            //    {
            //        wbHtml.Visible = true;
            //        btnTitle.Text = dt.Rows[0]["Name"].ToString();
            //        wbHtml.Url = new Uri(Application.StartupPath + "\\Data\\HTML\\" + dt.Rows[0]["Content"].ToString());
            //    }
            //}
        }
        //右键设定选中项【如无事件,则选中右键有回到上一级选中项】
        private void tvMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tvMain.SelectedNode = tvMain.GetNodeAt(e.X, e.Y);
            }
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
