using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Bowtech
{
    public partial class BL71_QueryDB : Form
    {
        SQLite dal;
        public BL71_QueryDB()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void BL71_QueryDB_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false; 
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            LoadServer();

            LoadCommonDB();//加载记忆
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

        //加载服务器
        public void LoadServer()
        {
            DataTable dt = dal.ExecuteDataTable("Select ID,Name From Sys_dbs Order By ID"); //添加 请选择 是因为文本框初始化Selectindexchanged 设置了 记忆始终为第一项 So..
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
            cboTable.DataSource = null;
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
        //查询数据库
        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDB.Text != "==请选择==" && cboDB.Text != "")
            {
                cboTable.DataSource = getAllTableName(cboDB.Text);
                SetConnectDB();
            }
            else
                cboTable.DataSource = null;

           
        }
        ///查询所有表名
        public List<string> getAllTableName(string database)
        {
            //打开连接
            List<string> list = new List<string>();
            string str = "";

            if (StateClass.UserLogin)
            {
                str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
            }
            else
            {
                str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";Integrated Security=True";
            }

            SqlConnection sqlcn = new SqlConnection(str);
            sqlcn.Open();
            //使用信息架构视图
            SqlCommand sqlcmd = new SqlCommand("SELECT OBJECT_NAME (id) as T FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0 order by T", sqlcn);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr.GetString(0));
            }
            dr.Close();
            return list;
        }
        //记录当前选择过的数据表
        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "Update CommonDB Set DBTable='" + cboTable.Text + "'";
            if (dal.ExecuteNonQueryReturn(sql) == 0)
            {
                sql = "Insert into CommonDB(DBName,DBTable) values('','" + cboTable.Text + "')";
                dal.ExecuteNonQuery(sql);
            }
        }

        private void txtSort_TextChanged(object sender, EventArgs e)
        {
            if (txtSort.Text == "")
            {
                //重新加载
                cboDB_SelectedIndexChanged(null, null);
                return;
            }
            if (cboDB.Text!="")
              cboTable.DataSource = getAllTableName(cboDB.Text, txtSort.Text);
        }
        // 查询所有表名
        public List<string> getAllTableName(string database, string like)
        {
            //打开连接
            List<string> list = new List<string>();
            string str = "";

            if (StateClass.UserLogin)
            {
                str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
            }
            else
            {
                str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";Integrated Security=True";
            }

            SqlConnection sqlcn = new SqlConnection(str);
            sqlcn.Open();
            //使用信息架构视图
            SqlCommand sqlcmd = new SqlCommand("SELECT OBJECT_NAME (id) as T FROM sysobjects WHERE xtype = 'U' AND OBJECTPROPERTY (id, 'IsMSShipped') = 0 and name like '%" + like + "%' order by T", sqlcn);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            while (dr.Read())
            {
                list.Add(dr.GetString(0));
            }
            dr.Close();
            return list;
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play2; 
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play1; 
        }
        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
        //执行
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (cboDB.Text == "")
            {
                MessageBox.Show("请选择数据库！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    DataTable dt;
                    if (txtSQL.Text == "")
                    {
                        dt = getDataSet(cboDB.Text, cboTable.Text);
                    }
                    else
                    {
                        dt = getDataSetByText(cboDB.Text, txtSQL.Text);
                    }
                    if (dt != null)
                    {
                        gvd.DataSource = dt;
                        if (gvd.Columns.Count == 1)
                        {
                            gvd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        // 查询指定数据库返回数据集
        public DataTable getDataSet(string database, string table)
        {
            try
            {
                string str = "";
                if (StateClass.UserLogin)
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
                }
                else
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + database + ";Integrated Security=True";
                }

                DataSet dateSet = new DataSet();
                SqlConnection con = new SqlConnection(str);
                SqlDataAdapter adapter = new SqlDataAdapter("select * from [" + table + "]", con);
                adapter.Fill(dateSet, "table");
                return dateSet.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        // 插入数据库语句 返回结果
        public DataTable getDataSetByText(string dbName, string sql)
        {
            try
            {
                string str = "";
                if (StateClass.UserLogin)
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + dbName + ";User ID=" + StateClass.UserName + ";Password=" + StateClass.UserPass;
                }
                else
                {
                    str = "Data Source=" + StateClass.DbName + ";Initial Catalog=" + dbName + ";Integrated Security=True";
                }
                if (sql.ToLower().IndexOf("select") > -1)//是否为查询语句
                {
                    DataSet dateSet = new DataSet();
                    SqlConnection con = new SqlConnection(str);
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                    adapter.Fill(dateSet, "tables");
                    return dateSet.Tables[0];
                }
                else if (sql.Length > 6 && sql.ToLower().Substring(0, 5) == "where")
                {
                    DataSet dateSet = new DataSet();
                    SqlConnection con = new SqlConnection(str);
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from [" + cboTable.Text + "]" + sql, con);
                    adapter.Fill(dateSet, "table");
                    return dateSet.Tables[0];
                }
                else
                {
                    SqlCommand command = new SqlCommand(sql, new SqlConnection(str));
                    command.Connection.Open();
                    int ret = command.ExecuteNonQuery();
                    command.Connection.Close();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("消息");
                    DataRow dr = dt.NewRow();
                    if (ret == -1)
                    {
                        dr["消息"] = "命令已成功完成。";
                    }
                    else
                    {
                        dr["消息"] = "(" + ret + " 行受影响)";
                    }
                    dt.Rows.Add(dr);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "无法找到表 0。")
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("消息");
                    DataRow dr = dt.NewRow();
                    dr["消息"] = "执行完成！";
                    dt.Rows.Add(dr);
                    return dt;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("消息");
                    DataRow dr = dt.NewRow();
                    dr["消息"] = ex.Message;
                    dt.Rows.Add(dr);
                    return dt;
                }
            }
        }
        //关闭当前窗体
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 
    }
}
