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

namespace Bowtech
{
    public partial class BL71_ImportExcel : Form
    {
        BL71_Main Main;
        DataSet ds = new DataSet();
        DataTable newDT;
        SQLite dal;
        public BL71_ImportExcel(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }

        private void BL71_ImportExcel_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
            LoadServer();

            gvd.AllowDrop = true;
            CheckForIllegalCrossThreadCalls = false;

            newDT = new DataTable();
            newDT.Columns.Add("oldCol");
            newDT.Columns.Add("newCol");
            newDT.Columns.Add("typeCol");
            newDT.Columns.Add("sizeCol");

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
            if (cboDB.SelectedIndex >= 0  && cboDB.Text != "==请选择==")
            {
                string sql = "Update CommonDB Set DBTable='" + cboDB.Text + "'";
                dal.ExecuteNonQuery(sql);
            }
        }

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
            if (cboServer.SelectedValue == null || cboServer.SelectedValue.ToString() == "" || cboServer.SelectedValue.ToString() =="-1") return;
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
                {
                    LoadCommonDB();//加载记忆
                }

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

        private void gvd_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];

                foreach (string srcfile in files)
                {
                    string temp = srcfile.Substring(srcfile.LastIndexOf("."));
                    if (temp == ".xls" || temp == ".xlsx")
                    {
                        ds = ReadExcel(srcfile);
                        cboSheet.Items.Clear();
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                           // cboSheet.Items.Add(ds.Tables[i].TableName.Replace("$", ""));
                            cboSheet.Items.Add(new ListItem(ds.Tables[i].TableName.Replace("$", ""), ds.Tables[i].TableName));
                        }
                        //cboSheet.SelectedIndex = 0;
                    }
                    else
                    {
                        Main.AlertMsg("格式有误,支持xls、xlsx类型文件"); 
                    }
                }
            }
            catch (Exception e1)
            { 
                Main.AlertMsg(e1.Message);
            }
        }
        //Excel转换DataSet
        public DataSet ReadExcel(string filePath)
        {

            //excel 2003 使用的驱动是：
            //strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";

            //Excel 2010 使用的驱动
            //strConn = "Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";


            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 12.0;";
            string sql_F = "Select * FROM [{0}]";

            OleDbConnection conn = null;
            OleDbDataAdapter da = null;
            System.Data.DataTable tblSchema = null;
            ArrayList tblNames = new ArrayList();

            // 初始化连接，并打开
            conn = new OleDbConnection(connStr);
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            // 获取数据源的表定义元数据                        
            tblSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

            foreach (DataRow row in tblSchema.Rows)
            {
                if (row["TABLE_NAME"].ToString().Substring(row["TABLE_NAME"].ToString().Length - 1) == "$")//只有后面带$这个符号的 才是创建出来的Sheet页
                  tblNames.Add((string)row["TABLE_NAME"]); // 读取表名

                string name = row["TABLE_NAME"].ToString();
                if (name.Substring(0, 1) == "'" && name.Substring(name.Length - 1) == "'")
                    tblNames.Add((string)row["TABLE_NAME"]); // 读取表名
            }

            // 初始化适配器
            da = new OleDbDataAdapter();
            // 准备数据，导入DataSet
            DataSet ds = new DataSet();
            foreach (string tblName in tblNames)
            {
                try
                {
                    da.SelectCommand = new OleDbCommand(String.Format(sql_F, tblName), conn);

                    da.Fill(ds, tblName);

                }
                catch
                {
                    // 关闭连接
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            // 关闭连接
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return ds;
        }

        private void gvd_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewTableName.Text = "A_" + DateTime.Now.ToString("MMdd");
            if (ds != null && ds.Tables.Count != 0)
            {
               // DataTable dt = ds.Tables[cboSheet.Text + "$"];
                DataTable dt = ds.Tables[((ListItem)cboSheet.SelectedItem).Value];
                newDT.Rows.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DataRow dr = newDT.NewRow();
                    dr["oldCol"] = dt.Columns[i].ColumnName;
                    dr["newCol"] = dt.Columns[i].ColumnName;
                    dr["typeCol"] = "varchar";
                    dr["sizeCol"] = "255";
                    newDT.Rows.Add(dr);
                }
                gvd.DataSource = newDT;
            }
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play2;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play1;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (cboSheet.Text == "" || cboSheet.Items.Count == 0)
            {
                Main.AlertMsg("请先导入Excel！");
                return;
            }
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
                DataTable dt = ds.Tables[cboSheet.Text + "$"];
                proBar.Maximum = dt.Rows.Count;
                proBar.Value = 0;
                btnPlay.Enabled = false;
                Application.DoEvents();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strSql += " Insert Into " + txtNewTableName.Text + TheValue + " Values(";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        strSql += "'" + dt.Rows[i][j] + "',";
                    }
                    strSql = strSql.TrimEnd(',') + ") ";
                    proBar.Value = i + 1;
                }
                command = new SqlCommand(strSql, new SqlConnection(str));
                command.Connection.Open();
                int retCount = command.ExecuteNonQuery();
                command.Connection.Close(); 
                Main.AlertMsg("导入完成,共" + retCount + "行");
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
        private void btnDele_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4_2;
        }

        private void btnDele_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b4;
        }
        //删除表
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

                Main.AlertMsg("删除完成!");
            }
            catch (Exception ex)
            {
                Main.AlertMsg("该表不存在或已删除!");
            }
        }

        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnectDB();//设置数据库记忆
        }

    }
}
