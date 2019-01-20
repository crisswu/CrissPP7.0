using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option_IEManage : Form
    {
        BL71_Main Main;
        SQLite dal;
        public BL71_Option_IEManage(BL71_Main M)
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

            Querys();

            int sort = dal.ExecuteInt("Select Max(Sort) From IEAddress");
            sort++;
            txtSort.Text = sort.ToString();
        }
        
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisble_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
            {
                Main.AlertMsg("输入标题"); 
                return;
            }
            if (txtIEAddress.Text == "")
            {
                Main.AlertMsg("输入网址"); 
                return;
            }
            if (txtSort.Text == "")
            {
                Main.AlertMsg("输入排序"); 
                return;
            }

            int sort = dal.ExecuteInt("Select Count(*) From IEAddress where Title='" + Filter(txtTitle.Text) + "'");
            if (sort > 0)//修改
            {
                string strOld = "Update IEAddress Set IEAddress='" + Filter(txtIEAddress.Text) + "',Sort='" + Filter(txtSort.Text) + "' where Title='"+ Filter(txtTitle.Text) + "'";
                dal.ExecuteNonQuery(strOld);
                UpdateVersion();
            }
            else //新增
            {
                string strOld = "Insert into IEAddress(Title,IEAddress,Sort) values('" + Filter(txtTitle.Text) + "','" + Filter(txtIEAddress.Text) + "','" + Filter(txtSort.Text) + "')";
                dal.ExecuteNonQuery(strOld);
                UpdateVersion();
            }
           
            txtTitle.Text = "";
            txtIEAddress.Text ="";
            txtSort.Text = "";

            txtTitle.Focus();

            Querys();

            int sort1 = dal.ExecuteInt("Select Max(Sort) From IEAddress");
            sort1++;
            txtSort.Text = sort1.ToString();
        }

        //查询
        public void Querys()
        {
            string sql = "Select Title,IEAddress,Sort From IEAddress Order by Sort desc";
            DataTable dt = dal.ExecuteDataTable(sql);
            grd.DataSource = dt;
        }

        #region 切换图片
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
        private void btnDele_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4_2;
        }

        private void btnDele_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4;
        }
        #endregion

        //判断是否为数字
        public static bool IsNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }

        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗!", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                string strOld = "Delete From IEAddress Where Title='" + grd.SelectedRows[0].Cells[0].Value + "'";
                dal.ExecuteNonQuery(strOld);
                UpdateVersion();
                Querys();
            }
        }
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }

        private void grd_DoubleClick(object sender, EventArgs e)
        {
            txtIEAddress.Text = grd.SelectedRows[0].Cells[1].Value.ToString();
            txtTitle.Text = grd.SelectedRows[0].Cells[0].Value.ToString();
            txtSort.Text = grd.SelectedRows[0].Cells[2].Value.ToString();
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
