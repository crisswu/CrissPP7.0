using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.InteropServices;

namespace Bowtech
{
    [ComVisible(true)]
    public partial class BL71_ImportExcel_Far : Form
    {
        DataSet ds = new DataSet();
        DataTable newDT;
        DataTable conDT;
        SQLite dal;
        string content = "";
        private BL71_Main Main;

        public BL71_ImportExcel_Far(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }

        private void BL71_ImportExcel_Far_Load(object sender, EventArgs e)
        {
            gvd.AllowDrop = true;
            CheckForIllegalCrossThreadCalls = false;

            newDT = new DataTable();
            newDT.Columns.Add("oldCol");
            newDT.Columns.Add("newCol");
            newDT.Columns.Add("typeCol");
            newDT.Columns.Add("sizeCol");

            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            LoadServer();

            LoadCommonDB();//加载记忆

            this.webBW.Url = new System.Uri(Application.StartupPath + "\\kindeditor\\e.html", System.UriKind.Absolute);
            this.webBW.ObjectForScripting = this;
        }
        public void LoadCommonDB()
        {
            string sql = "Select * from CommonDB";
            DataTable dt = dal.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DBName"].ToString() != "")
                {
                    cboServer.Text = dt.Rows[0]["DBName"].ToString();

                }
                if (dt.Rows[0]["DBTable"].ToString() != "")
                {
                    cboDB.Text = dt.Rows[0]["DBTable"].ToString();
                }
            }
        }
        //设置数据库记忆
        public void SetConnectDB()
        {
            if (cboServer.SelectedIndex >= 0 && cboServer.Text != "==请选择==")
            {
                string sql = "Update CommonDB Set DBName='" + cboServer.Text + "'";
                dal.ExecuteNonQuery(sql);
            }
            if (cboDB.SelectedIndex >= 0 && cboDB.Text != "==请选择==")
            {
                string sql = "Update CommonDB Set DBTable='" + cboDB.Text + "'";
                dal.ExecuteNonQuery(sql);
            }
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

        #region 切图
        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play2;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play1;
        }
        private void btnDele_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4_2;
        }

        private void btnDele_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4;
        }

        private void btnShengCheng_MouseEnter(object sender, EventArgs e)
        {
            btnShengCheng.Image = Properties.Resources.shegnCheng;
        }

        private void btnShengCheng_MouseLeave(object sender, EventArgs e)
        {
            btnShengCheng.Image = Properties.Resources.shegnCheng1;
        }
        #endregion

        #region 配置数据库
        //加载服务器
        public void LoadServer()
        {
            DataTable dt = dal.ExecuteDataTable("Select ID,Name From Sys_dbs Order By ID");
            DataRow dr = dt.NewRow();
            dr[0] = "-1";
            dr[1] = "==请选择==";
            dt.Rows.Add(dr);
            DataView dv = dt.Copy().DefaultView;
            dv.Sort = "ID";
            dt.Clear();
            dt = dv.ToTable();

            cboServer.DisplayMember = "Name";
            cboServer.ValueMember = "ID";
            cboServer.DataSource = dt;
        }
        //选择服务器
        private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServer.SelectedValue == null || cboServer.SelectedValue.ToString() == "" || cboServer.SelectedValue.ToString() == "-1") return;
            cboDB.DataSource = null;
            DataTable dt = dal.ExecuteDataTable("Select ID,Name,IP,Types,LoginName,Password From Sys_dbs where ID='" + cboServer.SelectedValue + "'");

            StateClass.ConnStr = "Data Source=" + dt.Rows[0]["IP"].ToString() + ";integrated security=true;";
            StateClass.DbName = dt.Rows[0]["IP"].ToString();
            if (dt.Rows[0]["Types"].ToString() == "SQL Server 身份验证")
            {
                StateClass.ConnStr = "Data Source=" + StateClass.DbName + ";User ID=" + dt.Rows[0]["LoginName"].ToString() + ";Password=" + dt.Rows[0]["Password"].ToString() + ";";
                StateClass.UserLogin = true;
                StateClass.UserName = dt.Rows[0]["LoginName"].ToString();
                StateClass.UserPass = dt.Rows[0]["Password"].ToString();
            }
            thread = new Thread(new ThreadStart(GetTimes));
            thread.Start();
            SetConnectDB();
        }
        Thread thread;
        //测试数据库连接是否成功
        public bool connectionDBTest()
        {
            SqlConnection con = new SqlConnection(StateClass.ConnStr);
            try
            {
                con.Open();
                return true;
            }
            catch (Exception ep)
            {
                return false;
            }
            finally
            {
                con.Close();
            }

        }
        //线程执行操作
        public void GetTimes()
        {
            bool back = connectionDBTest();
            if (back == true)
            {
                setComboBoxByTable(cboDB);//加载数据库
            }
            thread.Abort();
        }
        //为comboBox添加数据库
        public void setComboBoxByTable(object obj)
        {
            ComboBox cob = obj as ComboBox;
            cob.Text = "";
            try
            {
                ///筛选系统数据库....
                string[] str = { "tempdb", "model", "AdventureWorksDW", "AdventureWorks", "msdb", "master", "ReportServer", "ReportServerTempDB" };
                List<string> list = getAllDateBaseName();
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].ToString() == str[i].ToString())
                        {
                            list.RemoveAt(j);
                        }
                    }
                }
                list.Insert(0, "==请选择==");
                cob.DataSource = list;
                if (cob.Text == "")
                {
                    cob.Text = "";
                    cboDB.Text = "无用户数据库";
                }
                else
                    LoadCommonDB();//加载记忆

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // 查询所有数据库名
        public List<string> getAllDateBaseName()
        {
            List<string> list = new List<string>();
            string sql = "use master select name from sysdatabases";
            string conn = "";
            if (StateClass.UserLogin)
            {
                conn = "Data Source=" + StateClass.DbName + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
            }
            else
            {
                conn = "Data Source=" + StateClass.DbName + ";Integrated Security=True";
            }
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
            return list;
        }
        #endregion

        //HTML编辑器必须有的
        public string GetContent()
        {
            return content;
        }
        //HTML编辑器必须有的
        public void RequestContent(string str)
        {
            content = str;
        }
        //生成
        private void btnShengCheng_Click(object sender, EventArgs e)
        {
            try
            {
                txtNewTableName.Text = "A_" + DateTime.Now.ToString("MMdd");
                string html = content;
                html = DelHead(html);//去头
                List<string> rows = GetRow(html);//返回行集合
                int ColNumber = HowCols(rows[0]);//返回列数
                conDT = new DataTable();//创建出列
                for (int i = 0; i < ColNumber; i++)
                {
                    conDT.Columns.Add("T" + (i + 1));
                }
                //生成最终DataTable
                for (int i = 0; i < rows.Count; i++)
                {
                    AddRow(rows[i]);
                }

                newDT.Rows.Clear();
                for (int i = 0; i < conDT.Columns.Count; i++)
                {
                    DataRow dr = newDT.NewRow();
                    dr["oldCol"] = conDT.Columns[i].ColumnName;
                    dr["newCol"] = conDT.Columns[i].ColumnName;
                    dr["typeCol"] = "varchar";
                    dr["sizeCol"] = "255";
                    newDT.Rows.Add(dr);
                }
                gvd.DataSource = newDT;

            }
            catch (Exception ep)
            {
                MessageBox.Show("格式不正确!");
            }
        }
        //去除头部<tr>之前的去掉
        public string DelHead(string str)
        {
            return str.Substring(str.IndexOf("<tr"));
        }
        //返回行集合
        public List<string> GetRow(string str)
        {
            List<string> list = new List<string>();
            ProcessRow(list, str);//递归加工取出行集合
            return list;
        }
        //递归加工行集合
        public void ProcessRow(List<string> list, string str)
        {
            if (str.IndexOf("</tr>") == -1)
                return;
            string temp = str.Substring(0, str.IndexOf("</tr>") + 5);
            str = str.Substring(str.IndexOf("</tr>") + 5);
            temp = temp.Trim();
            list.Add(temp);
            ProcessRow(list, str);
        }
        //返回列数目
        public int HowCols(string str)
        {
            int count = 0;
            AddCol(ref count, str);
            return count;
        }
        //递归获取列数
        public void AddCol(ref int count, string str)
        {
            if (str.IndexOf("</td>") == -1)
                return;
            str = str.Substring(str.IndexOf("</td>") + 5);
            count++;
            AddCol(ref count, str);
        }
        //追加行
        public void AddRow(string str)
        {
            DataRow dr = conDT.NewRow();
            DGRow(dr, 0, str);
        }
        //取值
        public void DGRow(DataRow dr, int index, string str)
        {
            if (str.IndexOf("<td") == -1)
            {
                conDT.Rows.Add(dr);
                return;
            }
            str = str.Substring(str.IndexOf("<td"));
            str = str.Substring(str.IndexOf(">") + 1);
            string temp = str.Substring(0, str.IndexOf("</td>"));
            dr[index] = temp.Trim();
            str = str.Substring(str.IndexOf("</td>") + 5);
            index++;
            DGRow(dr, index, str);
        }
        //创建
        private void btnPlay_Click(object sender, EventArgs e)
        {
            string str = content;
            if (txtNewTableName.Text == "")
            {
                Main.AlertMsg("请输入新表名称！"); 
                txtNewTableName.Focus();
                return;
            }
            Thread myThread = new Thread(ThreadInDB);
            myThread.Start();
        }
        //多线程添加数据库
        public void ThreadInDB()
        {
            string TheValue = "("; //用于拼接 Insert into 中的 value 
            string sql = "Use " + cboDB.Text + " Create Table [" + txtNewTableName.Text + "] ( ";
            for (int i = 0; i < gvd.RowCount; i++)
            {
                sql += " [" + gvd.Rows[i].Cells[1].Value + "] " + getType(gvd.Rows[i].Cells[2].Value.ToString(), gvd.Rows[i].Cells[3].Value.ToString()) + ",";
                TheValue += "[" + gvd.Rows[i].Cells[1].Value + "],";
            }
            sql = sql.TrimEnd(',') + ")";
            TheValue = TheValue.TrimEnd(',') + ")";

            try
            {
                string str = "";
                if (StateClass.UserLogin)
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + cboDB.Text + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
                }
                else
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + cboDB.Text + ";Integrated Security=True";
                }

                SqlCommand command = new SqlCommand(sql, new SqlConnection(str));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

                string strSql = "";

                proBar.Maximum = conDT.Rows.Count;
                proBar.Value = 0;
                btnPlay.Enabled = false;
                Application.DoEvents();
                for (int i = 0; i < conDT.Rows.Count; i++)
                {
                    strSql += " Insert Into " + txtNewTableName.Text + TheValue + " Values(";
                    for (int j = 0; j < conDT.Columns.Count; j++)
                    {
                        strSql += "'" + conDT.Rows[i][j] + "',";
                    }
                    strSql = strSql.TrimEnd(',') + ") ";
                    proBar.Value = i + 1;
                }
                command = new SqlCommand(strSql, new SqlConnection(str));
                command.Connection.Open();
                int retCount = command.ExecuteNonQuery();
                command.Connection.Close(); 
                Main.AlertMsg("导入完成,共" + retCount + "行！");
                proBar.Value = 0;
                btnPlay.Enabled = true;
                Application.DoEvents();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Main.AlertMsg(ex.Message);
                proBar.Value = 0;
                btnPlay.Enabled = true;
                Application.DoEvents();
            }
        }

        //返回类型
        public string getType(string type, string size)
        {
            switch (type)
            {
                case "varchar":
                    return "varchar(" + size + ")";
                case "decimal":
                    return "decimal(" + size + ")";
                case "float":
                    return "float";
                case "int":
                    return "int";
            }
            return "";
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewTableName.Text == "")
                {
                    Main.AlertMsg("请输入要删除的表名！"); 
                    txtNewTableName.Focus();
                    return;
                }
                if (MessageBox.Show("确定删除【" + txtNewTableName.Text + "】表吗？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;

                string sql = "Drop Table " + txtNewTableName.Text;
                string str = "";
                if (StateClass.UserLogin)
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + cboDB.Text + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
                }
                else
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + cboDB.Text + ";Integrated Security=True";
                }

                SqlCommand command = new SqlCommand(sql, new SqlConnection(str));
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                 
                Main.AlertMsg("删除完成！");
            }
            catch (Exception ex)
            {
                Main.AlertMsg("该表不存在,或已删除！");
            }
        }

        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnectDB();
        }
    }
}
