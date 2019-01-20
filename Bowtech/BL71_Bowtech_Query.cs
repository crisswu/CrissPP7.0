using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Bowtech_Query : Form
    {
        public BL71_Main Main;
        SQLite dal;
        TreeNode colorNode = new TreeNode();//设置选中目录节点的颜色
        TreeNode colorDetail = new TreeNode();//设置选中目录节点的颜色
        public BL71_Bowtech_Query(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            Main = M;
        }

        private void BL71_Bowtech_Select_Load(object sender, EventArgs e)
        {

            this.txtContent.ConfigFile = "csharp.xml";
            this.txtContent.AcceptsTab = true;
            this.txtContent.CaseSensitive = false;
            this.txtContent.MaxUndoRedoSteps = 50;
            this.txtContent.WordWrap = false;

            panTree.BackColor = Color.FromArgb(238, 239, 242);
            panTop.BackColor = Color.FromArgb(206, 210, 221);
            tvDetail.BackColor = Color.FromArgb(238, 239, 242);

            if (Main.WindowState == FormWindowState.Maximized)
            {
                int mainWith = Main.Size.Width;//窗体总宽度
                int mainHeight = Main.Size.Height;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith - 200, picClose.Location.Y);

                panMain.Width = mainWith - 200;
                txtContent.Width = mainWith - 200;

                //42是  上边按钮空间预留出来的位置的高度
                panMain.Height = mainHeight - 115;
                txtContent.Height = mainHeight - 115 - 42;
            }
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
            this.Close();
        }

        private void picHome_MouseEnter(object sender, EventArgs e)
        {
            picHome.Image = Properties.Resources.Query1;
        }

        private void picHome_MouseLeave(object sender, EventArgs e)
        {
            picHome.Image = Properties.Resources.Query;
        }
        //过滤器
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }
        private void picHome_Click(object sender, EventArgs e)
        {
            string sql = "Select * From Notes Where Type!=0";
            //增加多个 or 的联合查询
            if (txtName.Text.ToLower().IndexOf(" or ") > 0)
            {
                List<string> list = new List<string>();
                GetParamOr(txtName.Text, ref list);

                sql += " and (Name like '%" + Filter(list[0]) + "%' or Content Like '%" + Filter(list[0]) + "%')";
                for (int i = 1; i < list.Count; i++)
                {
                    sql += " or (Name like '%" + Filter(list[i]) + "%' or Content Like '%" + Filter(list[i]) + "%')";
                }
            }
            else if (txtName.Text.ToLower().IndexOf(" and ") > 0)//增加 多个 and 的条件查询
            {
                List<string> list = new List<string>();
                GetParamAnd(txtName.Text, ref list);

                for (int i = 0; i < list.Count; i++)
                {
                    sql += " and (Name like '%" + Filter(list[i]) + "%' or Content Like '%" + Filter(list[i]) + "%')";
                }
            }
            else if(txtName.Text != "")
                sql += " and Name like '%" + Filter(txtName.Text) + "%' or Content Like '%" + Filter(txtName.Text) + "%'";
 
            DataTable dt = dal.ExecuteDataTable(sql);
            tvDetail.Nodes.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dt.Rows[i]["Name"].ToString();
                tn.Tag = dt.Rows[i]["ID"].ToString();
                AddTreeItemDetail(tn, dt.Rows[i]["FatherID"].ToString());
            }
            if (tvDetail.Nodes.Count == 0)
            {
                Main.AlertMsg("没找到结果！");
                txtName.SelectAll();
            }
        }
        //把多个or的参数 分割到List中
        public void GetParamOr(string where, ref List<string> list)
        {
            if (where.ToLower().IndexOf(" or ") >= 0)
            {
                string str = where.Substring(0, where.ToLower().IndexOf(" or "));
                list.Add(str);
                string newStr = where.Substring(where.ToLower().IndexOf(" or "));
                if (newStr.Length > 4)
                    newStr = newStr.Substring(4);
                GetParamOr(newStr, ref list);
            }
            else
                list.Add(where);
        }
        //把多个and的参数 分割到List中
        public void GetParamAnd(string where, ref List<string> list)
        {
            if (where.ToLower().IndexOf(" and ") >= 0)
            {
                string str = where.Substring(0, where.ToLower().IndexOf(" and "));
                list.Add(str);
                string newStr = where.Substring(where.ToLower().IndexOf(" and "));
                if (newStr.Length > 5)
                    newStr = newStr.Substring(5);
                GetParamAnd(newStr, ref list);
            }
            else
                list.Add(where);
        }

        //递归填充查询树
        public void AddTreeItemDetail(TreeNode tn, string FatherID)
        {
            string sql = "Select * From Notes Where ID='" + FatherID + "'";
            DataTable dt = dal.ExecuteDataTable(sql);
            if (!IsInFatherID(dt, tn))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["FatherID"].ToString() == "0")
                    {
                        TreeNode tn2 = new TreeNode();
                        tn2.Text = dt.Rows[i]["Name"].ToString();
                        tn2.Tag = dt.Rows[i]["ID"].ToString();
                        tn2.Nodes.Add(tn);
                        tvDetail.Nodes.Add(tn2);
                    }
                    else
                    {
                        TreeNode tn2 = new TreeNode();
                        tn2.Text = dt.Rows[i]["Name"].ToString();
                        tn2.Tag = dt.Rows[i]["ID"].ToString();
                        tn2.Nodes.Add(tn);
                        AddTreeItemDetail(tn2, dt.Rows[i]["FatherID"].ToString());
                    }
                }
            }

        }
        public bool IsInFatherDG(TreeNodeCollection tnc, DataTable dt, TreeNode tn)
        {
            for (int i = 0; i < tnc.Count; i++)
            {
                if (tnc[i].Tag.ToString() == dt.Rows[0]["ID"].ToString())
                {
                    tnc[i].Nodes.Add(tn);
                    return true;
                }
                else if (tnc[i].Nodes.Count != 0)
                {
                    bool tem = IsInFatherDG(tnc[i].Nodes, dt, tn);
                    if (tem)
                        return true;
                }
            }
            return false;
        }
        public bool IsInFatherID(DataTable dt, TreeNode tn)
        {
            TreeNodeCollection tnc = tvDetail.Nodes;
            return IsInFatherDG(tnc, dt, tn);
        }

        private void tvDetail_AfterSelect(object sender, TreeViewEventArgs e)
        {
            colorDetail.ForeColor = Color.Navy;
            tvDetail.SelectedNode.ForeColor = Color.Orange;
            colorDetail = tvDetail.SelectedNode;
            lblContent.Text = "";
            txtContent.Text = "";
            string sql = "Select * from Notes Where ID='" + tvDetail.SelectedNode.Tag.ToString() + "'";
            DataTable dt = dal.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                lblContent.Text = dt.Rows[0]["Name"].ToString();
                txtContent.Text = dt.Rows[0]["Content"].ToString();

            }
        }
        //展开
        private void tsmiZK_Click(object sender, EventArgs e)
        {
            tvDetail.ExpandAll();
        }
        //收缩
        private void tsmiSS_Click(object sender, EventArgs e)
        {
            tvDetail.CollapseAll();
        }

        private void BL71_Bowtech_Select_Resize(object sender, EventArgs e)
        {
            if (Main != null)
            {
                if (Main.WindowState == FormWindowState.Maximized)//支持最大化
                {
                    int mainWith = Main.Size.Width;//窗体总宽度
                    int mainHeight = Main.Size.Height;//窗体总宽度
                    int closeWith = picClose.Width;//关闭按钮宽度
                    picClose.Location = new Point(mainWith - closeWith - 200, picClose.Location.Y);

                    panMain.Width = mainWith - 200;
                    txtContent.Width = mainWith - 200;

                    //42是  上边按钮空间预留出来的位置的高度
                    panMain.Height = mainHeight - 115;
                    txtContent.Height = mainHeight - 115 - 42;
                }
                else
                {
                    picClose.Location = new Point(794, 0);
                    panMain.Width = 822;
                    txtContent.Width = 822;

                    //42是  上边按钮空间预留出来的位置的高度
                    panMain.Height = 485;
                    txtContent.Height = 443;
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                picHome_Click(null, null);
            }
        }
    }
}
