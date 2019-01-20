using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace Bowtech
{
    public partial class BL71_SQL_Select : Form
    {
        SQLite dal;
        List<Contronls_Model> AllModel = new List<Contronls_Model>();//保存所有已有连接的数据  计算SQL需要使用它
        List<string> ABC = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "G", "K", "L",
            "M", "N", "O", "P", "Q", "R", "S","T","U","V","W","X","Y","Z"}; //分配当前 as 表名
        int Index = 0;//当前索引
        Dictionary<string, Panel> AllContr = new Dictionary<string, Panel>();//所有集合
        string OnePanel = "";//被拖出来的第一个控件
        string TwoPanel = "";//被拖出来的第二个控件
        CheckedListBox SelectRight;

        public BL71_SQL_Select()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void BL71_SQL_Select_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
           
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            LoadServer();
            tsmiSum.Click += new EventHandler(tsmiSum_Click);
            tsmiCount.Click += new EventHandler(tsmiCount_Click);
            tsmiAvg.Click += new EventHandler(tsmiAvg_Click);
            tsmiMax.Click += new EventHandler(tsmiMax_Click);
            tsmiMin.Click += new EventHandler(tsmiMin_Click);
            tsmiNull.Click += new EventHandler(tsmiNull_Click);

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
        #region 聚合函数事件
        void tsmiNull_Click(object sender, EventArgs e)
        {

            string temp = SelectRight.SelectedItem.ToString();
            if (temp.IndexOf("as") > 0)
            {
                temp = temp.Substring(temp.IndexOf("as") + 3);
                SelectRight.Items[SelectRight.SelectedIndex] = temp;
            }
        }

        void tsmiMin_Click(object sender, EventArgs e)
        {
            SelectRight.Items[SelectRight.SelectedIndex] = "Min(" + SelectRight.SelectedItem + ") as " + SelectRight.SelectedItem;
        }

        void tsmiMax_Click(object sender, EventArgs e)
        {
            SelectRight.Items[SelectRight.SelectedIndex] = "Max(" + SelectRight.SelectedItem + ") as " + SelectRight.SelectedItem;
        }

        void tsmiAvg_Click(object sender, EventArgs e)
        {
            SelectRight.Items[SelectRight.SelectedIndex] = "Avg(" + SelectRight.SelectedItem + ") as " + SelectRight.SelectedItem;
        }

        void tsmiCount_Click(object sender, EventArgs e)
        {
            SelectRight.Items[SelectRight.SelectedIndex] = "Count(" + SelectRight.SelectedItem + ") as " + SelectRight.SelectedItem;
        }

        void tsmiSum_Click(object sender, EventArgs e)
        {
            SelectRight.Items[SelectRight.SelectedIndex] = "Sum(" + SelectRight.SelectedItem + ") as " + SelectRight.SelectedItem;
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
        #region 切图
        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play2;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Properties.Resources.play1;
        }

        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b3_2;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.b3;
        }
        #endregion
        #region 各种拖动事件
        //拖动事件
        private void checkedListBox_MouseDown(object sender, MouseEventArgs e)
        {
            CheckedListBox clb = (CheckedListBox)sender;
            //调用DoDragDrop方法
            if (clb.SelectedItem != null)
            {
                clb.DoDragDrop(clb.SelectedItem, DragDropEffects.Copy);
            }
        }
        //设置标题可以移动换位置
        void l_MouseUp(object sender, MouseEventArgs e)
        {
            Label l = (Label)sender;
            Panel panel1 = AllContr[l.Tag.ToString()];
            panel1.Location = panCol.PointToClient(Cursor.Position);
        }
        //动态生成改变位置
        void p_MouseUp(object sender, MouseEventArgs e)
        {
            Panel panel1 = (Panel)sender;
            panel1.Location = panCol.PointToClient(Cursor.Position);
        }
        //动态生成列表拖动事件【拖出来的列】
        void cb_MouseDown(object sender, MouseEventArgs e)
        {
            CheckedListBox cb = (CheckedListBox)sender;
            if (cb.SelectedItem != null)
            {

                if (lvLeft.Items.Count == 0 && lvInner.Items.Count == 0) //若第一次拖进去 
                {
                    OnePanel = cb.Tag.ToString(); //获取当前对象  例如 A B C D
                }
                else if (lvLeft.Items.Count == 1 && lvInner.Items.Count == 0)//已经有一条数据的
                {
                    TwoPanel = cb.Tag.ToString();
                }
                else if (lvLeft.Items.Count == 0 && lvInner.Items.Count == 1)//已经有一条数据的
                {
                    TwoPanel = cb.Tag.ToString();
                }
                cb.DoDragDrop(cb.SelectedItem, DragDropEffects.Copy);
            }

            if (e.Button == MouseButtons.Right)
            {
                int posindex = cb.IndexFromPoint(new Point(e.X, e.Y));
                cb.ContextMenuStrip = null;
                if (posindex >= 0 && posindex < cb.Items.Count)
                {
                    cb.SelectedIndex = posindex;
                    SelectRight = cb;
                    cms.Show(cb, new Point(e.X, e.Y));
                }
            }
            cb.Refresh();
        }
        //反选
        void btUnAll_Click(object sender, EventArgs e)
        {
            Button btAll = (Button)sender;
            CheckedListBox cb = (CheckedListBox)btAll.Tag;
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SetItemChecked(i, false);
            }
        }
        //全选
        void btAll_Click(object sender, EventArgs e)
        {
            Button btAll = (Button)sender;
            CheckedListBox cb = (CheckedListBox)btAll.Tag;
            for (int i = 0; i < cb.Items.Count; i++)
            {
                cb.SetItemChecked(i, true);
            }
        }
        //左连接接受事件
        private void lvLeft_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //左连接接受事件 【Left】
        private void lvLeft_DragDrop(object sender, DragEventArgs e)
        {
            string item = (string)e.Data.GetData(e.Data.GetFormats()[0]);
            lvLeft.Items.Add(item);
            Application.DoEvents();
            Thread.Sleep(200);
            if (lvInner.Items.Count > 0)//判断如果Inner已有值 则清空
            {
                OnePanel = TwoPanel;
                lvInner.Items.Clear();
            }
            if (lvLeft.Items.Count > 1)//判断如果 自身已有值 
            {
                string NewItem = OnePanel + "." + lvLeft.Items[0].Text;
                NewItem += "=" + TwoPanel + "." + lvLeft.Items[1].Text;
                lvAll.Items.Add(NewItem);
                lvLeft.Items.Clear();

                Contronls_Model cm = new Contronls_Model();
                cm.JoinName = "Left Join";
                cm.JoinString = NewItem;
                cm.A_Name = OnePanel;
                cm.B_Name = TwoPanel;
                cm.A_TableName = AllContr[OnePanel].Tag.ToString();
                cm.B_TableName = AllContr[TwoPanel].Tag.ToString();
                cm.OnePanel = AllContr[OnePanel];
                cm.TwoPanel = AllContr[TwoPanel];
                AllModel.Add(cm);//保存到集合当中
                WorksOfGod();//生成SQL
            }
        }
        //内连接接受事件 【Inner】
        private void lvInner_DragDrop(object sender, DragEventArgs e)
        {
            string item = (string)e.Data.GetData(e.Data.GetFormats()[0]);
            lvInner.Items.Add(item);
            Application.DoEvents();
            Thread.Sleep(200);
            if (lvLeft.Items.Count > 0)//判断如果Inner已有值 则清空
            {
                OnePanel = TwoPanel;
                lvLeft.Items.Clear();
            }
            if (lvInner.Items.Count > 1)//判断如果 自身已有值 
            {
                string NewItem = OnePanel + "." + lvInner.Items[0].Text;
                NewItem += "=" + TwoPanel + "." + lvInner.Items[1].Text;
                lvAll.Items.Add(NewItem);
                lvInner.Items.Clear();

                Contronls_Model cm = new Contronls_Model();
                cm.JoinName = "Inner Join";
                cm.JoinString = NewItem;
                cm.A_Name = OnePanel;
                cm.B_Name = TwoPanel;
                cm.A_TableName = AllContr[OnePanel].Tag.ToString();
                cm.B_TableName = AllContr[TwoPanel].Tag.ToString();
                cm.OnePanel = AllContr[OnePanel];
                cm.TwoPanel = AllContr[TwoPanel];
                AllModel.Add(cm);//保存到集合当中
                WorksOfGod();//生成SQL
            }
        }
        //panle获取拖动数据
        private void panelEx_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        //panle获取拖动值
        private void panelEx_DragDrop(object sender, DragEventArgs e)
        {
            //获取值
            string item = (string)e.Data.GetData(e.Data.GetFormats()[0]);
            DataTable dt = getDataSet(cboDB.Text, item);
            panCol.Controls.Add(NewAddControl(dt, item));

            if (AllContr.Count == 1)
            {
                WorksOneSql();
            }
            else if (AllContr.Count > 1 && AllModel.Count > 0)
                WorksOfGod();
        }
        //数据表的拖动事件
        private void lbTableName_MouseDown(object sender, MouseEventArgs e)
        {
            //调用DoDragDrop方法
            if (lbTableName.SelectedItem != null)
            {
                lbTableName.DoDragDrop(lbTableName.SelectedItem, DragDropEffects.Copy);
            }
        }
        //删除控件方法
        void btDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            panCol.Controls.Remove(AllContr[btn.Tag.ToString()]);
            AllContr.Remove(btn.Tag.ToString());

            for (int i = 0; i < AllModel.Count; i++)
            {
                Contronls_Model item = AllModel[i];
                if (item.A_Name == btn.Tag.ToString() || item.B_Name == btn.Tag.ToString())
                {
                    AllModel.Remove(item);
                    i--;
                }
            }
        }
        #endregion
        //筛选表
        private void txtSort_TextChanged(object sender, EventArgs e)
        {
            if (txtSort.Text == "")
            {
                //重新加载
                cboDB_SelectedIndexChanged(null, null);
                return;
            }
            lbTableName.DataSource = getAllTableName(cboDB.Text, txtSort.Text);
        }
        // 查询指定数据库返回数据集 只为列 这里有Top1
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
                SqlDataAdapter adapter = new SqlDataAdapter("select top 1 * from [" + table + "]", con);
                adapter.Fill(dateSet, "table");
                return dateSet.Tables[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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
        //查询数据库
        private void cboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDB.Text != "==请选择==")
            {
                // cboTable.DataSource = getAllTableName(cboDB.Text);
                lbTableName.DataSource = getAllTableName(cboDB.Text);
                SetConnectDB();
            }
            else
                lbTableName.DataSource = null;
        }
        // 查询所有表名
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
        //生成SQL
        public void WorksOfGod()
        {
            string Select = "";
            string From = "";
            string Group = "\r\nGroup by ";
            bool isGroup = false;
            List<string> tempName = new List<string>();
            for (int i = 0; i < AllModel.Count; i++)
            {
                //================  Select
                Contronls_Model cm = AllModel[i];
                CheckedListBox cb1 = (CheckedListBox)cm.OnePanel.Controls[1];//获取选中的 列表
                CheckedListBox cb2 = (CheckedListBox)cm.TwoPanel.Controls[1];//获取选中的 列表
                if (!tempName.Contains(cm.A_Name))
                {
                    for (int c = 0; c < cb1.CheckedItems.Count; c++)
                    {
                        //Select += cm.A_Name + "." + cb1.CheckedItems[c] + ",";
                        if (cb1.CheckedItems[c].ToString().IndexOf(" as ") > 0)//判断已有聚合函数
                        {
                            isGroup = true;
                            Select += GroupJGC(cm.A_Name, cb1.CheckedItems[c].ToString()) + ",";
                        }
                        else
                        {
                            Select += cm.A_Name + "." + cb1.CheckedItems[c] + ",";
                            Group += cm.A_Name + "." + cb1.CheckedItems[c] + ",";
                        }
                    }
                }
                if (!tempName.Contains(cm.B_Name))
                {
                    for (int c = 0; c < cb2.CheckedItems.Count; c++)
                    {
                        //Select += cm.B_Name + "." + cb2.CheckedItems[c] + ",";
                        if (cb2.CheckedItems[c].ToString().IndexOf(" as ") > 0)//判断已有聚合函数
                        {
                            isGroup = true;
                            Select += GroupJGC(cm.B_Name, cb2.CheckedItems[c].ToString()) + ",";
                        }
                        else
                        {
                            Select += cm.B_Name + "." + cb2.CheckedItems[c] + ",";
                            Group += cm.B_Name + "." + cb2.CheckedItems[c] + ",";
                        }
                    }
                }

                //=============== From
                if (i == 0)//第一次赋值
                    From += cm.A_TableName + " AS " + cm.A_Name + " " + cm.JoinName + " " + cm.B_TableName + " AS " + cm.B_Name + " on " + cm.JoinString;
                else
                {
                    if (!tempName.Contains(cm.A_Name))
                        From += " " + cm.JoinName + " " + cm.A_TableName + " AS " + cm.A_Name + " on " + cm.JoinString;
                    if (!tempName.Contains(cm.B_Name))
                        From += " " + cm.JoinName + " " + cm.B_TableName + " AS " + cm.B_Name + " on " + cm.JoinString;
                }

                tempName.Add(cm.A_Name);
                tempName.Add(cm.B_Name);

            }
            Select = Select.TrimEnd(',');
            Group = Group.TrimEnd(',');
            txtSQL.Text = "Select " + Select + " From " + From;
          //  AutoLine();
            txtSQL.Text += "\r\nWhere 1=1 ";
            if (isGroup)
                txtSQL.Text += Group;

            txtSQL.Text += "\n\n";
            txtSQL.Text += "---------------------------生成方法----------------------------------";
            txtSQL.Text += "\n\n";
            txtSQL.Text += "public DataTable Get" + AllModel[0].A_TableName + "()\n{\r       " + "string sql = @\"Select " + Select + " From " + From + " ";
            txtSQL.Text += " Where 1=1 \";\r";
            txtSQL.Text += "return dal.ExecuteDataTable(sql);\r";
            txtSQL.Text += "}";
            AutoLine();
            if (isGroup)
                txtSQL.Text += Group;

        }
        //聚合函数列加工成
        public string GroupJGC(string title, string col)
        {
            string NewStr = "";
            if (col.IndexOf("Sum(") >= 0)
            {
                NewStr = "Sum(" + title + "." + col.Substring(4);
            }
            if (col.IndexOf("Count(") >= 0)
            {
                NewStr = "Count(" + title + "." + col.Substring(6);
            }
            if (col.IndexOf("Avg(") >= 0)
            {
                NewStr = "Avg(" + title + "." + col.Substring(4);
            }
            if (col.IndexOf("Max(") >= 0)
            {
                NewStr = "Max(" + title + "." + col.Substring(4);
            }
            if (col.IndexOf("Min(") >= 0)
            {
                NewStr = "Min(" + title + "." + col.Substring(4);
            }
            return NewStr;
        }
        //生成单一SQL
        public void WorksOneSql()
        {
            if (AllContr.Count == 0) return;
            string Select = "";
            string From = "";
            string Group = "\r\nGroup by ";
            bool isGroup = false;
            CheckedListBox cb1 = (CheckedListBox)AllContr[ABC[Index - 1]].Controls[1];//获取选中的 列表
            for (int c = 0; c < cb1.CheckedItems.Count; c++)
            {
                Select += cb1.CheckedItems[c] + ",";
                if (cb1.CheckedItems[c].ToString().IndexOf(" as ") > 0)//判断已有聚合函数
                {
                    isGroup = true;
                }
                else
                {
                    Group += cb1.CheckedItems[c] + ",";
                }
            }
            From += AllContr[ABC[Index - 1]].Tag;

            Select = Select.TrimEnd(',');
            Group = Group.TrimEnd(',');
            txtSQL.Text = "Select " + Select + " From " + From;
           // AutoLine();
            txtSQL.Text += " Where 1=1 ";
            if (isGroup)
                txtSQL.Text += Group;

            txtSQL.Text += "\n\n";
            txtSQL.Text += "---------------------------生成方法----------------------------------";
            txtSQL.Text += "\n\n";
            txtSQL.Text += "public DataTable Get" + From + "()\n{\r       " + "string sql = @\"Select " + Select + " From " + From + " ";
            txtSQL.Text += " Where 1=1 \";\r";
            txtSQL.Text += "return dal.ExecuteDataTable(sql);\r";
            txtSQL.Text += "}";
            AutoLine();
            if (isGroup)
                txtSQL.Text += Group;

        }
        //自动换行
        public void AutoLine()
        {
            int Max = 30;//最大字符
            string NewSelect = "";
            string NewFrom = "";
            string NewJoin = "";
            string text = txtSQL.Text;
            string select = text.Substring(7, text.IndexOf("From") - 8);
            string[] sp = select.Split(',');
            string from = text.Substring(text.IndexOf("From"));

            int temp = Max;
            for (int i = 0; i < sp.Length; i++)
            {
                if ((temp <= 0 || temp < sp[i].Length + 1) && i != sp.Length - 1)
                {
                    NewSelect += sp[i] + "," + "\r";
                    temp = Max;
                }
                else
                    NewSelect += sp[i] + ",";

                temp -= sp[i].Length + 1;
            }
            NewSelect = NewSelect.TrimEnd(',');

            string LastJoin = "";//排除From Table 之后的字符串
            if (from.IndexOf("Left Join") >= 0)
            {
                NewFrom += from.Substring(0, from.IndexOf("Left Join"));
                LastJoin = from.Substring(from.IndexOf("Left Join"));
            }
            else if (from.IndexOf("Inner Join") >= 0)
            {
                NewFrom += from.Substring(0, from.IndexOf("Inner Join"));
                LastJoin = from.Substring(from.IndexOf("Inner Join"));
            }
            else
                NewFrom += from;

            if (LastJoin != "")
                SplJoin(LastJoin, ref NewJoin);

            txtSQL.Text = "Select \r" + NewSelect + "\r" + NewFrom + "\r" + NewJoin;
        }
        //递归截取Left Inner Join
        public void SplJoin(string sql, ref string NewJoin)
        {
            if (sql.Substring(0, 4) == "Left")
            {
                if (sql.Substring(10).IndexOf("Join") > 10)//判断是否有下一个连接
                {
                    string tempThis = sql.Substring(9);//排除掉头部  Left Join
                    string str = tempThis.Substring(0, tempThis.IndexOf(" Join")); //筛选到 第二个Join前面
                    if (str.Substring(str.Length - 1) == "t")//如果最后一个字符 为t  代表 下一个是 left
                    {
                        NewJoin += "Left Join " + str.Substring(0, str.Length - 5) + " \r\n";
                        string LastThis = tempThis.Substring(tempThis.IndexOf("Left Join"));
                        SplJoin(LastThis, ref NewJoin);
                    }
                    else //则下一个 连接 是 Inner jon
                    {
                        NewJoin += "Left Join " + str.Substring(0, str.Length - 5) + " \r\n";
                        string LastThis = tempThis.Substring(tempThis.IndexOf("Inner Join"));
                        SplJoin(LastThis, ref NewJoin);
                    }
                }
                else
                {
                    NewJoin += sql;
                }
            }
            else
            {
                if (sql.Substring(10).IndexOf("Join") > 10)//判断是否有下一个连接
                {
                    string tempThis = sql.Substring(10);//排除掉头部  Left Join
                    string str = tempThis.Substring(0, tempThis.IndexOf(" Join")); //筛选到 第二个Join前面
                    if (str.Substring(str.Length - 1) == "t")//如果最后一个字符 为t  代表 下一个是 left
                    {
                        NewJoin += "Inner Join " + str.Substring(0, str.Length - 5) + " \r\n";
                        string LastThis = tempThis.Substring(tempThis.IndexOf("Left Join"));
                        SplJoin(LastThis, ref NewJoin);
                    }
                    else //则下一个 连接 是 Inner jon
                    {
                        NewJoin += "Inner Join " + str.Substring(0, str.Length - 5) + " \r\n";
                        string LastThis = tempThis.Substring(tempThis.IndexOf("Inner Join"));
                        SplJoin(LastThis, ref NewJoin);
                    }
                }
                else
                {
                    NewJoin += sql;
                }
            }
        }
        //生成控件
        public Panel NewAddControl(DataTable dt, string title)
        {
            Panel p = new Panel();
            p.AllowDrop = true;
            p.MouseUp += new MouseEventHandler(p_MouseUp);
            p.BackColor = Color.White;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Height = 160;
            p.Tag = title;

            //设置表名
            Label l = new Label();
            l.Font = new Font("微软雅黑", 14);
            l.AutoSize = true;
            l.Text = title + "[" + ABC[Index] + "]";
            l.Tag = ABC[Index];
            l.MouseUp += new MouseEventHandler(l_MouseUp);
            p.Controls.Add(l);
            if (l.Width < 130)
                p.Width = 130;
            else
                p.Width = l.Width;

            //设置列表
            CheckedListBox cb = new CheckedListBox();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                cb.Items.Add(dt.Columns[i].Caption, true);
            }
            cb.CheckOnClick = true;
            cb.Location = new Point(2, 30);
            cb.MouseDown += new MouseEventHandler(cb_MouseDown);
            p.Controls.Add(cb);
            cb.Height = 100;
            if (l.Width < 100)
                cb.Width = 145;
            else
                cb.Width = p.Width - 5;
            cb.Tag = ABC[Index];

            Button btAll = new Button();
            btAll.Text = "全选";
            btAll.Size = new System.Drawing.Size(40, 23);
            btAll.Location = new Point(2, 130);
            btAll.Click += new EventHandler(btAll_Click);
            btAll.Tag = cb;
            p.Controls.Add(btAll);

            Button btUnAll = new Button();
            btUnAll.Text = "反选";
            btUnAll.Size = new System.Drawing.Size(40, 23);
            btUnAll.Location = new Point(44, 130);
            btUnAll.Tag = cb;
            btUnAll.Click += new EventHandler(btUnAll_Click);
            p.Controls.Add(btUnAll);

            Button btDel = new Button();
            btDel.Text = "删除";
            btDel.Size = new System.Drawing.Size(40, 23);
            btDel.Location = new Point(86, 130);
            btDel.Tag = ABC[Index];
            btDel.Click += new EventHandler(btDel_Click);
            p.Controls.Add(btDel);

            p.Location = panCol.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            AllContr.Add(ABC[Index], p);
            Index++;//更新索引
            return p;
        }
        //生成
        private void btnPlay_Click(object sender, EventArgs e)
        {
            txtSQL.Text = "";
            if (AllContr.Count == 1)
            {
                WorksOneSql();
            }
            else if (AllContr.Count > 1 && AllModel.Count > 0)
                WorksOfGod();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtSQL.Text != "")
            {
                Clipboard.SetText(txtSQL.Text);
            }
        }

        private void picDel_MouseEnter(object sender, EventArgs e)
        {
            picDel.Image = Properties.Resources.delete1;
        }

        private void picDel_MouseLeave(object sender, EventArgs e)
        {
            picDel.Image = Properties.Resources.delete;
        }

        private void picDel_Click(object sender, EventArgs e)
        {
            txtSQL.Text = "";
            lvLeft.Items.Clear();
            lvInner.Items.Clear();
            lvAll.Items.Clear();
            AllModel.Clear();
            AllContr.Clear();
            panCol.Controls.Clear();
            OnePanel = "";
            TwoPanel = "";
            Index = 0;
        }
    }
}
