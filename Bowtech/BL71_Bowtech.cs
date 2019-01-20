using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Bowtech
{
    public partial class BL71_Bowtech : Form
    {
        public BL71_Main Main;
        SQLite dal;
        public string SELECTID = "";//选择文本后的ID
        public string FATHERID = "";//选择父节点
        public string TOPID = "";//根节点ID
        Panel Tempanel;//交换位置时临时容器
        bool Tempkey = false;//临时交换判断是否已选中 首选项
                             // bool IsAddTsmi = false;//是否已加载移动数据

        public string AppointID = "";//判断是否为获取 指定ID  [从查询出跳转过来的数据]

        public BL71_Bowtech()
        {
            InitializeComponent();
            DoubleBuffered = true;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();
        }

        private void BL71_Bowtech_Load(object sender, EventArgs e)
        {
            wbHtml.ScriptErrorsSuppressed = true; //禁用错误脚本提示   
            this.txtContent.ConfigFile = "csharp.xml";
            this.txtContent.AcceptsTab = true;
            this.txtContent.CaseSensitive = false;
            this.txtContent.MaxUndoRedoSteps = 50;
            this.txtContent.WordWrap = false;

            panTree.BackColor = Color.FromArgb(238, 239, 242);
            panTop.BackColor = Color.FromArgb(206, 210, 221);

            if (Main.WindowState == FormWindowState.Maximized)
            {
                int mainWith = Main.Size.Width;//窗体总宽度
                int mainHeight = Main.Size.Height;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith-200, picClose.Location.Y);

                panMain.Width = mainWith - 200;
                wbHtml.Width = mainWith - 200;
                txtContent.Width = mainWith - 200;

                //42是  上边按钮空间预留出来的位置的高度
                panMain.Height = mainHeight - 115;
                wbHtml.Height = mainHeight - 115-42;
                txtContent.Height = mainHeight - 115-42;
            }

            //获取指定ID的数据
            if(AppointID!="")
                Appoint(AppointID);
        }

        //指定跳转到某一个ID项.. （从查询跳转过来的）
        public void Appoint(string ID)
        {
            string FatherID = dal.ExecuteString("Select  FatherID from Notes where ID  =" + ID);
            ChangeMode(FatherID);
            ChangeMode(ID);
        }

        #region 菜单加载
        //初次加载
        public void AddTree()
        {
            SELECTID = "";
            panTree.Controls.Clear();
            string sql = "Select * from Notes where FatherID=0 and Visble=0 Order by OrderBy desc";
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel p = new Panel();
                p.Height = 35;
                p.Dock = DockStyle.Top;
                Label lable = new Label();
                lable.Text = dt.Rows[i]["Name"].ToString();
                lable.Tag = dt.Rows[i]["ID"].ToString();
                lable.Font = new System.Drawing.Font(new FontFamily("微软雅黑"), 12, FontStyle.Regular);
                lable.Location = new Point(30, 5);
                lable.Click += new EventHandler(lable_Click);
                lable.MouseEnter += new EventHandler(lable_MouseEnter);
                lable.MouseLeave += new EventHandler(lable_MouseLeave);
                lable.AutoSize = true;
                p.Controls.Add(lable);
                p.Tag = dt.Rows[i]["ID"].ToString();
                p.Click += new EventHandler(p_Click);
                p.MouseEnter += new EventHandler(p_MouseEnter);
                p.MouseLeave += new EventHandler(p_MouseLeave);
                panTree.Controls.Add(p);
            }
            panTop.Dock = DockStyle.Top;
           
        }
        //树点击事件
        void lable_Click(object sender, EventArgs e)
        {
            Label  flable= (Label)sender;
            Panel p = (Panel)flable.Parent;
            MouseEventArgs Mouse_e = (MouseEventArgs)e;

            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Tempkey)//互换位置（第二次点击右键）
                {
                    if (p.Tag.ToString() == Tempanel.Tag.ToString())
                    {
                        flable.ForeColor = Color.Black;
                        Tempkey = false;
                        return;
                    }

                    string NowID = Tempanel.Tag.ToString();
                    string ToID = p.Tag.ToString();
                    string sql = "Select OrderBy From Notes where ID='" + NowID + "'";
                    string NowBy = dal.ExecuteScalar(sql).ToString();
                    sql = "Select OrderBy From Notes where ID='" + ToID + "'";
                    string ToBy = dal.ExecuteScalar(sql).ToString();
                    sql = "Update Notes Set OrderBy='" + ToBy + "' where ID='" + NowID + "'";
                    dal.ExecuteNonQuery(sql);
                    sql = "Update Notes Set OrderBy='" + NowBy + "' where ID='" + ToID + "'";
                    dal.ExecuteNonQuery(sql);
                    ChangeMode(TOPID);
                    Tempkey = false;
                }
                else //选中 首选项（第一次点击右键）
                {
                    flable.ForeColor = Color.FromArgb(246, 221, 41);
                    Tempkey = true;
                    Tempanel = p;
                }

            }
            else
            {
                Label lable = (Label)sender;
                SELECTID = lable.Tag.ToString();
                ChangeMode(lable.Tag.ToString());
                lable.ForeColor = Color.FromArgb(8, 66, 200);
            }
        }
        //树点击事件
        void p_Click(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            MouseEventArgs Mouse_e = (MouseEventArgs)e;

            if (Mouse_e.Button == MouseButtons.Right)
            {
                if (Tempkey)//互换位置（第二次点击右键）
                {
                    Tempkey = false;
                    if (p.Tag.ToString() == Tempanel.Tag.ToString())
                    {
                        Label lable = (Label)p.Controls[0];
                        lable.ForeColor = Color.Black;
                        return;
                    }

                    string NowID = Tempanel.Tag.ToString();
                    string ToID = p.Tag.ToString();
                    string sql = "Select OrderBy From Notes where ID='" + NowID + "'";
                    string NowBy = dal.ExecuteScalar(sql).ToString();
                    sql = "Select OrderBy From Notes where ID='" + ToID + "'";
                    string ToBy = dal.ExecuteScalar(sql).ToString();
                    sql = "Update Notes Set OrderBy='" + ToBy + "' where ID='" + NowID + "'";
                    dal.ExecuteNonQuery(sql);
                    sql = "Update Notes Set OrderBy='" + NowBy + "' where ID='" + ToID + "'";
                    dal.ExecuteNonQuery(sql);
                    if (TOPID != "" && SELECTID != "")
                        ChangeMode(TOPID);
                    else
                        AddTree();
                    
                }
                else //选中 首选项（第一次点击右键）
                {
                    Label lable = (Label)p.Controls[0];
                    lable.ForeColor = Color.FromArgb(246, 221, 41);
                    Tempkey = true;
                    Tempanel = p;
                }

            }
            else
            {
                SELECTID = p.Tag.ToString();
                ChangeMode(p.Tag.ToString());
                Label lable = (Label)p.Controls[0];
                lable.ForeColor = Color.FromArgb(8, 66, 200);
            }
        }
        //变成父类访问
        public void ChangeMode(string ID)
        {
            if (txtContent.Visible == false) return;
            string sql = "Select * from Notes where ID='"+ID+"' Order by OrderBy desc";
            DataTable dt = dal.ExecuteDataTable(sql);
            if (dt.Rows[0]["Type"].ToString() == "2")//判断如果为 内容页则加载内容信息
            {
                if (dt.Rows[0]["IsNet"].ToString() == "0")
                {
                    wbHtml.Visible = false;
                    picSave.Visible = true;
                    lblContent.Text = dt.Rows[0]["Name"].ToString();
                    lblContent.Tag = dt.Rows[0]["ID"].ToString();
                    txtContent.Text = dt.Rows[0]["Content"].ToString();
                }
                else
                {
                    wbHtml.Visible = true;
                    lblContent.Text = dt.Rows[0]["Name"].ToString();
                    wbHtml.Url = new Uri(Application.StartupPath + "\\Data\\HTML\\" + dt.Rows[0]["Content"].ToString());
                }
               
            }
            else //则为父类继续加载子类信息
            {
                Tempkey = false;
                picSave.Visible = false;
                lblContent.Text = "";
                txtContent.Text = "";
                panTree.Controls.Clear();
                Panel p = new Panel();
                p.Height = 35;
                p.Dock = DockStyle.Top;
                Label lable = new Label();
                lable.Text = dt.Rows[0]["Name"].ToString() + "[" + DGCountSun(dt.Rows[0]["ID"].ToString()) + "]";
                lable.Tag = dt.Rows[0]["ID"].ToString();
                lable.Font = new System.Drawing.Font(new FontFamily("微软雅黑"), 14, FontStyle.Bold);
                lable.Location = new Point(30, 5);
                lable.DoubleClick += new EventHandler(FLable_Click);//双击修改当前标题    
                lable.AutoSize = true;
                p.Controls.Add(lable);
                p.BackColor = Color.FromArgb(206, 210, 221);
                TOPID = ID;
                FATHERID = ID;
                ChildMode(ID);//加载其子类
                panTree.Controls.Add(p);
            }
        }
        //点击Lable 改变成文本框
        private void FLable_Click(object sender, EventArgs e)
        {
            Label lable = (Label)sender;
            Control p = lable.Parent; //获取父类容器
            TextBox tbox = new TextBox();
            Font ft = new System.Drawing.Font("微软雅黑",14,FontStyle.Bold);
            tbox.Font = ft;
            tbox.Width = 200;
            tbox.Text = lable.Text;
            tbox.Tag = lable;//把当前Lable保存到 文本框内 
            tbox.KeyDown += new KeyEventHandler(tbox_KeyDown);
            p.Controls.Remove(lable);
            p.Controls.Add(tbox);
            tbox.Focus();
            tbox.SelectAll();
        }
        // ↑方法文本框 的回车事件
        void tbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox tbox = (TextBox)sender;
                if (tbox.Text == "") return;
                Label lable = (Label)tbox.Tag;
                lable.Text = tbox.Text;
                Control p = tbox.Parent;
                p.Controls.Remove(tbox);
                p.Controls.Add(lable);
                dal.ExecuteNonQuery("Update Notes Set Name ='" + Filter(tbox.Text) + "' where ID='" + lable.Tag.ToString() + "'");
            }
            if (e.KeyCode == Keys.Escape)
            {
                TextBox tbox = (TextBox)sender;
                Label lable = (Label)tbox.Tag;
                lable.Text = tbox.Text;
                Control p = tbox.Parent;
                p.Controls.Remove(tbox);
                p.Controls.Add(lable);
            }
        }
 
        //统计子类个数
        public int DGCountSun(string ID)
        {
            string sql = @"Select Count(*) from Notes where FatherID ="+ID+" and Type!=1  and GrandID!=0";//计算出当前目录下的记录项 非目录
            int sum = dal.ExecuteInt(sql);
            sql = @"select * from Notes where  FatherID ="+ID+" and Type=1  ";//获取出目录项目
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sum += DGCountSun(dt.Rows[i]["ID"].ToString());
            }
            return sum;
        }

        //加载子类
        public void ChildMode(string FatherID)
        {
            string sql = "Select * from Notes where FatherID="+FatherID+" Order by OrderBy desc";
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Panel p = new Panel();
                p.Height = 35;
                p.Dock = DockStyle.Top;
                Label lable = new Label();
                if (dt.Rows[i]["Type"].ToString() == "2")
                    lable.Text = dt.Rows[i]["Name"].ToString();
                else
                    lable.Text = "※"+dt.Rows[i]["Name"].ToString();
                lable.Tag = dt.Rows[i]["ID"].ToString();
                lable.Font = new System.Drawing.Font(new FontFamily("微软雅黑"), 10, FontStyle.Regular);
                lable.Location = new Point(5, 5);
                lable.Click += new EventHandler(lable_Click);
                lable.MouseEnter += new EventHandler(lable_MouseEnter);
                lable.MouseLeave += new EventHandler(lable_MouseLeave);
                lable.AutoSize = true;
                p.Controls.Add(lable);
                p.Tag = dt.Rows[i]["ID"].ToString();
                p.Click += new EventHandler(p_Click);
                p.MouseEnter += new EventHandler(p_MouseEnter);
                p.MouseLeave += new EventHandler(p_MouseLeave);
                panTree.Controls.Add(p);
            }
        }
        #endregion

        #region 切图
        void lable_MouseLeave(object sender, EventArgs e)
        {
            Label lable = (Label)sender;
            Panel p = (Panel)lable.Parent;
            p.BackColor = Color.FromArgb(238, 239, 242);
        }

        void lable_MouseEnter(object sender, EventArgs e)
        {
            Label lable = (Label)sender;
            Panel p = (Panel)lable.Parent;
            p.BackColor = Color.FromArgb(145, 193, 231);
        }

        void p_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.FromArgb(238, 239, 242);
        }

        void p_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.FromArgb(145, 193, 231);
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
            picHome.Image = Properties.Resources.home2;
        }
        private void picHome_MouseLeave(object sender, EventArgs e)
        {
            picHome.Image = Properties.Resources.FUQMC;
        }
        private void picBack_MouseEnter(object sender, EventArgs e)
        {
            picBack.Image = Properties.Resources.left2;
        }
        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Properties.Resources.left;
        }

        private void picAdd_MouseEnter(object sender, EventArgs e)
        {
            picAdd.Image = Properties.Resources.b5_3;
        }

        private void picAdd_MouseLeave(object sender, EventArgs e)
        {
            picAdd.Image = Properties.Resources.b5;
        }
        private void picSave_MouseEnter(object sender, EventArgs e)
        {
            picSave.Image = Properties.Resources.b3_2;
        }

        private void picSave_MouseLeave(object sender, EventArgs e)
        {
            picSave.Image = Properties.Resources.b3;
        }
        private void picDelete_MouseEnter(object sender, EventArgs e)
        {
            picDelete.Image = Properties.Resources.b4_2;
        }

        private void picDelete_MouseLeave(object sender, EventArgs e)
        {
            picDelete.Image = Properties.Resources.b4;
        }
        #endregion

        #region 控制按钮
        //保存
        private void picSave_Click(object sender, EventArgs e)
        {
            if (SELECTID == "") return;
            if (txtContent.Text == "") return;
            if (MessageBox.Show("确定保存嘛?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                string sql = "Update Notes Set Content='" + Filter(txtContent.Text) + "' where ID ='" + SELECTID + "'";
                dal.ExecuteNonQuery(sql);
                UpdateVersion();
                Main.AlertMsg("保存完成");
            }
        }
        //过滤器
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }
        //返回主页
        private void picHome_Click(object sender, EventArgs e)
        {
            Tempkey = false;
            AddTree();
        }
        //返回上一页
        private void picBack_Click(object sender, EventArgs e)
        {
            Tempkey = false;
            if (TOPID == "") return;
            string sql = "Select * from Notes where ID=" + TOPID + " Order by OrderBy desc";
            DataTable dt = dal.ExecuteDataTable(sql);
            sql = "Select FatherID from Notes where ID=" + dt.Rows[0]["FatherID"].ToString() + " Order by OrderBy desc";
            if (dt.Rows[0]["FatherID"].ToString() == "0")
                AddTree();
            else
            {
                SELECTID = dt.Rows[0]["FatherID"].ToString();
                ChangeMode(SELECTID);
            }
        }
        #endregion

        #region 功能按钮
        //添加
        private void picAdd_Click(object sender, EventArgs e)
        {
            if (txtContent.Visible == false) return;
            if (SELECTID == "")//判断为根节点
            {
                picSave.Visible = false;
                txtContent.Visible = false;
                picClose.Visible = false;
                BL71_AddFather from = new BL71_AddFather(Main);
                from.TopLevel = false;
                from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                from.bowtech = this;
                panMain.Controls.Add(from);
                from.Dock = DockStyle.Fill;
                from.Show();
            }
            else
            {
                lblContent.Text = "";
                txtContent.Text = "";
                picSave.Visible = false;
                txtContent.Visible = false;
                picClose.Visible = false;
                BL71_AddNote from = new BL71_AddNote(Main);
                from.TopLevel = false;
                from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                from.bowtech = this;
                from.FatherID = TOPID;
                panMain.Controls.Add(from);
                from.Dock = DockStyle.Fill;
                from.Tag = Main;
                from.Show();
            }
            
        }
        //删除
        private void picDelete_Click(object sender, EventArgs e)
        {
            if (SELECTID == "") return;
            string sql = "Select Name From Notes where ID='" + SELECTID + "'";
          string  Name = dal.ExecuteString(sql);
          if (MessageBox.Show("确定要删除【" + Name + "】吗?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                string FatherID = SELECTID;
                sql = "Select * From Notes where ID='" + FatherID + "'";
                DataTable dt = dal.ExecuteDataTable(sql);
                if (dt.Rows[0]["IsNet"].ToString() == "1")
                {
                    try
                    {
                        File.Delete(Application.StartupPath + "\\Data\\HTML\\" + dt.Rows[0]["Content"].ToString());
                        wbHtml.Visible = false;
                    }
                    catch (Exception ep)
                    {
                        MessageBox.Show(ep.Message);
                    }
                }
                DeleteChiled(FatherID);
                sql = "Delete From Notes where id='" + FatherID + "'";
                dal.ExecuteNonQuery(sql);
                UpdateVersion();
                //AddTree();

                Main.AlertMsg("删除完成！");
                ChangeMode(FATHERID);
            }
        }
        //递归删除子节点
        public void DeleteChiled(string FatherID)
        {
            string sql = "Select * From Notes where FatherID='" + FatherID + "'";
            DataTable dt = dal.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Type"].ToString() != "2")
                {
                    DeleteChiled(dt.Rows[i]["ID"].ToString());
                    sql = "Delete From Notes where id='" + dt.Rows[i]["ID"].ToString() + "'";
                    dal.ExecuteNonQuery(sql);
                }
                else
                {
                    sql = "Delete From Notes where id='" + dt.Rows[i]["ID"].ToString() + "'";
                    dal.ExecuteNonQuery(sql);
                }
            }
        }

        private void panTree_MouseDown(object sender, MouseEventArgs e)
        {
            panTree.Focus();
        }
        #endregion

        #region 修改内容标题
        private void lblContent_DoubleClick(object sender, EventArgs e)
        {
            lblContent.Visible = false;
            txtUpdateCon.Visible = true;
            txtUpdateCon.Text = lblContent.Text;
            txtUpdateCon.Focus();
            txtUpdateCon.SelectAll();
        }
        // ↑方法文本框 的回车事件
        void Content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUpdateCon.Text == "") return;
                lblContent.Text = txtUpdateCon.Text;
                lblContent.Visible = true;
                txtUpdateCon.Visible = false;
                dal.ExecuteNonQuery("Update Notes Set Name ='" + Filter(txtUpdateCon.Text) + "' where ID='" + lblContent.Tag.ToString() + "'");
            }
            if (e.KeyCode == Keys.Escape)
            {
                lblContent.Visible = true;
                txtUpdateCon.Visible = false;
            }
        }
        #endregion

        private void BL71_Bowtech_Resize(object sender, EventArgs e)
        {
            if (Main.WindowState == FormWindowState.Maximized)//支持最大化
            {
                int mainWith = Main.Size.Width;//窗体总宽度
                int mainHeight = Main.Size.Height;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith - 200, picClose.Location.Y);

                panMain.Width = mainWith - 200;
                wbHtml.Width = mainWith - 200;
                txtContent.Width = mainWith - 200;

                //42是  上边按钮空间预留出来的位置的高度
                panMain.Height = mainHeight - 115;
                wbHtml.Height = mainHeight - 115 - 42;
                txtContent.Height = mainHeight - 115 - 42;
            }
            else
            {
                picClose.Location = new Point(794, 0);
                panMain.Width = 822;
                wbHtml.Width = 822;
                txtContent.Width = 822;

                //42是  上边按钮空间预留出来的位置的高度
                panMain.Height = 485;
                wbHtml.Height = 443;
                txtContent.Height = 443;
            }
        }

        //更新版本号
        public void UpdateVersion()
        {
            int dbversion = dal.ExecuteInt("Select VersionID From Version");
            dbversion++;
            dal.ExecuteNonQuery("Update Version set VersionID='"+ dbversion + "'");
            Main.lblVersion.Text = "请上传版本";
        }
    }
}
