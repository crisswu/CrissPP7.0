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
    public partial class BL71_AddNote : Form
    {
        SQLite dal;
        public BL71_Main Main;
        public BL71_Bowtech bowtech;
        public string ID = "";
        public string FatherID = "";
        public string FatherName = "";
        public bool Keys = false;

        public BL71_AddNote(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            Main = M;
        }

        private void BL71_AddNote_Load(object sender, EventArgs e)
        {
            string sql = "Select Name From Notes where ID='"+FatherID+"'";
            FatherName = dal.ExecuteString(sql);
            txtAddFather.Text = FatherName;
            txtContent.Focus();
        }

        #region 切图
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
            bowtech.txtContent.Visible = true;
            bowtech.picClose.Visible = true;
            this.Close();
        }
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnlock.Image = Properties.Resources.b5_3;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnlock.Image = Properties.Resources.b5;
        }
        private void picDown_MouseEnter(object sender, EventArgs e)
        {
            picDown.Image = Properties.Resources.b3_2;
        }

        private void picDown_MouseHover(object sender, EventArgs e)
        {
            picDown.Image = Properties.Resources.b3;
        }

        private void btnNote_MouseEnter(object sender, EventArgs e)
        {
            btnNote.Image = Properties.Resources.b5_3;
        }

        private void btnNote_MouseLeave(object sender, EventArgs e)
        {
            btnNote.Image = Properties.Resources.b5;
        }
        //解锁
        private void btnlock_MouseEnter(object sender, EventArgs e)
        {
            if (Keys == false)
            {
                btnlock.Image = Properties.Resources.lock2;
            }
            else
            {
                btnlock.Image = Properties.Resources.key1;
            }
        }
        //解锁
        private void btnlock_MouseLeave(object sender, EventArgs e)
        {
            if (Keys == false)
            {
                btnlock.Image = Properties.Resources._lock;
            }
            else
            {
                btnlock.Image = Properties.Resources.key;
            }
        }
        #endregion

        //增加根目录
        private void btnAdd_Click()
        {
            if (txtAddFather.Text == "")
            {
                Main.AlertMsg("输入目录名称！");
                txtAddFather.Focus();
                return;
            }
            int maxID = dal.ExecuteInt("Select Max(ID) from Notes");
            maxID++;
            string GrandID = dal.ExecuteString("Select GrandID from Notes where ID=" + FatherID + "");
            if (GrandID == "0")
                GrandID = FatherID;
            string sql = "Insert into Notes(ID,Name,Type,Content,FatherID,GrandID,OrderBy) values(" + maxID + ",'" + Filter(txtAddFather.Text) + "',1,''," + FatherID + "," + GrandID + "," + maxID + ")";
            dal.ExecuteNonQuery(sql);

            bowtech.txtContent.Visible = true;
            bowtech.picClose.Visible = true;
            this.Close();
        }
        //过滤器
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }
       
        //解锁
        private void btnlock_Click(object sender, EventArgs e)
        {
            if (Keys==false)//进入增加目录模式
            {
                txtAddFather.Text = "";
                Keys = true;
                txtAddFather.Enabled = true;
                btnlock.Image = Properties.Resources.key;
                txtContent.Enabled = false;
                txtUrl.Enabled = false;
                picDown.Enabled = false;
                txtXZX.Enabled = false;
                txtAddFather.Focus();
            }
            else
            {
                txtAddFather.Text = FatherName;
                Keys = false;
                txtAddFather.Enabled = false;
                btnlock.Image = Properties.Resources._lock;
                txtContent.Enabled = true;
                txtUrl.Enabled = true;
                picDown.Enabled = true;
                txtXZX.Enabled = true;
                txtContent.Focus();
            }
        }
        // 添加
        private void btnNote_Click(object sender, EventArgs e)
        {
            if (Keys)//增加目录模式
            {
                btnAdd_Click();
                UpdateVersion();
            }
            else
            {
                AddNote();
                UpdateVersion();
            }
        }
        //新增模式
        public void AddNote()
        {
            if (txtContent.Text == "")
            {
                Main.AlertMsg("输入标题！");
                txtContent.Focus();
                return;
            }
            if (txtXZX.Text == "")
            {
                Main.AlertMsg("输入内容！");
                txtXZX.Focus();
                return;
            }

            int maxID = dal.ExecuteInt("Select Max(ID) from Notes");
            maxID++;
            string GrandID = dal.ExecuteString("Select GrandID from Notes where ID=" + FatherID + "");
            string sql = "Insert into Notes(ID,Name,Type,Content,FatherID,GrandID,OrderBy) values(" + maxID + ",'" + Filter(txtContent.Text) + "',2,'" + Filter(txtXZX.Text) + "'," + FatherID + "," + GrandID + "," + maxID + ")";
            dal.ExecuteNonQuery(sql);

            bowtech.txtContent.Visible = true;
            bowtech.picClose.Visible = true;
            this.Close();
        }
        //下载
        private void picDown_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "")
            {
                Main.AlertMsg("请输入网页地址！"); 
                txtUrl.Focus();
                return;
            }

            try
            {
                if (txtContent.Text == "")
                {
                    Main.AlertMsg("输入标题！"); 
                    txtContent.Focus();
                    return;
                }
                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Data"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Data");
                }
                if (!Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Data\\HTML"))
                {
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Data\\HTML");
                }

                string name = Guid.NewGuid().ToString() + ".mht";
                string Path = Application.StartupPath + "\\Data\\HTML\\" + name;
                string url;
                url = txtUrl.Text;
                CDO.IMessage msg = new CDO.MessageClass();
                CDO.Configuration c = new CDO.Configuration();
                msg.Configuration = c;

                // 第一参数为url，第二参数为支持格式，第三参数为用户ID，第四参数为用户密码 
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressAll, "", "");
                msg.GetStream().SaveToFile(Path, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);

                int maxID = dal.ExecuteInt("Select Max(ID) from Notes");
                maxID++;
                string GrandID = dal.ExecuteString("Select GrandID from Notes where ID=" + FatherID + "");
                string sql = "Insert into Notes(ID,Name,Type,Content,FatherID,GrandID,OrderBy,IsNet) values(" + maxID + ",'" + Filter(txtContent.Text) + "',2,'" + name + "'," + FatherID + "," + GrandID + "," + maxID + ",1)";
                dal.ExecuteNonQuery(sql);

                UpdateVersion();

                bowtech.txtContent.Visible = true;
                bowtech.picClose.Visible = true;
                this.Close();


            }
            catch (Exception ep)
            {
                MessageBox.Show(ep.Message);
            }
        }

        //更新版本号
        public void UpdateVersion()
        {
            int dbversion = dal.ExecuteInt("Select VersionID From Version");
            dbversion++;
            dal.ExecuteNonQuery("Update Version set VersionID='" + dbversion + "'");
            Main.lblVersion.Text = "请上传版本";
            Main.AlertMsg("保存完成！");
            bowtech.ChangeMode(bowtech.FATHERID);
        }



    }
}
