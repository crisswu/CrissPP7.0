using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Qiniu.RS;
using Qiniu.RS.Model;
using Qiniu.CDN;
using Qiniu.Util;
using System.Threading;

namespace Bowtech
{
    public partial class BL71_Main : Form
    {
        //七牛 接口
        string AK = "BjSys2_mqjjij_xW_9IROgvkNcssC5qh91Nx9khH";
        string SK = "cULYrizgRT432gUWtQO1umAa29Gk1Lntb7vbj-QL";
        Point mouseOff;//鼠标移动位置变量
        bool leftFlag;//标签是否为左键
        SQLite dal;

        public BL71_Main()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        #region 头部按住移动
        private void panHead_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //点击左键按下时标注为true;
            }
        }
        private void panHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }
        private void panHead_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;
            }
        }
        #endregion

        #region 鼠标悬停切换图片
        //改变颜色
        private void lblVersion_TextChanged(object sender, EventArgs e)
        {
            if (lblVersion.Text == "需更新版本")
            {
                lblVersion.ForeColor = Color.FromArgb(234, 0, 0);
            }
            else if (lblVersion.Text == "请上传版本")
            {
                lblVersion.ForeColor = Color.FromArgb(0, 0, 255);
            }
            else
            {
                lblVersion.ForeColor = Color.FromArgb(224, 224, 224);
            }
        }

        private void lblVersion_MouseEnter(object sender, EventArgs e)
        {
            if (lblVersion.Text == "需更新版本")
            {
                lblVersion.ForeColor = Color.FromArgb(255, 215, 0);
            }
            else if (lblVersion.Text == "请上传版本")
            {
                lblVersion.ForeColor = Color.FromArgb(255, 215, 0);
            }
        }

        private void lblVersion_MouseLeave(object sender, EventArgs e)
        {
            if (lblVersion.Text == "需更新版本")
            {
                lblVersion.ForeColor = Color.FromArgb(234, 0, 0);
            }
            else if (lblVersion.Text == "请上传版本")
            {
                lblVersion.ForeColor = Color.FromArgb(0, 0, 255);
            }
        }
        private void btnNoteSave_MouseEnter(object sender, EventArgs e)
        {
            btnNoteSave.Image = Properties.Resources.man2;
        }

        private void btnNoteSave_MouseLeave(object sender, EventArgs e)
        {
            btnNoteSave.Image = Properties.Resources.man1;

        }
        private void picIEAddress_MouseEnter(object sender, EventArgs e)
        {
            picIEAddress.Image = Properties.Resources._13905_2;
        }

        private void picIEAddress_MouseLeave(object sender, EventArgs e)
        {
            picIEAddress.Image = Properties.Resources._13905;
        }
        private void picCation_MouseEnter(object sender, EventArgs e)
        {
            picCation.Image = Properties.Resources.Caption1; 
        }

        private void picCation_MouseLeave(object sender, EventArgs e)
        {
            picCation.Image = Properties.Resources.Caption2;
        }
        private void picHTML_MouseEnter(object sender, EventArgs e)
        {
            picHTML.Image = Properties.Resources.html52;
        }

        private void picHTML_MouseLeave(object sender, EventArgs e)
        {
            picHTML.Image = Properties.Resources.html51;
        }
        private void picZXH_MouseHover(object sender, EventArgs e)
        {
            picZXH.Image = Properties.Resources.ZXHHOVER;
        }
        private void picZXH_MouseLeave(object sender, EventArgs e)
        {
            picZXH.Image = Properties.Resources.ZXHLEVE;
        }
        private void picCLZ_MouseHover(object sender, EventArgs e)
        {
            picCLZ.Image = Properties.Resources.CLOSEHOVER;
        }
        private void picCLZ_MouseLeave(object sender, EventArgs e)
        {
            picCLZ.Image = Properties.Resources.CLOSELEVE;
        }
        //关闭
        private void picCLZ_Click(object sender, EventArgs e)
        {
            if (lblVersion.Text != "最新版本")
            {
                if (MessageBox.Show("当前版本未更新是否继续退出", "注意信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Hide();
                    Application.DoEvents();
                    Application.Exit();
                }
            }
            else
            {
                this.Hide();
                Application.DoEvents();
                Application.Exit();
            }
        }
        private void picZXH_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void picMain_MouseHover(object sender, EventArgs e)
        {
            picMain.Image = Properties.Resources.Iron1;
        }

        private void picMain_MouseLeave(object sender, EventArgs e)
        {
            picMain.Image = Properties.Resources.Iron2;
        }

        private void picMainQ_MouseHover(object sender, EventArgs e)
        {
            picMainQ.Image = Properties.Resources.Iron3;
        }

        private void picMainQ_MouseLeave(object sender, EventArgs e)
        {
            picMainQ.Image = Properties.Resources.Iron4;
        }

        private void picEXCEL1_MouseHover(object sender, EventArgs e)
        {
            picEXCEL1.Image = Properties.Resources.Excel2;
        }

        private void picEXCEL1_MouseLeave(object sender, EventArgs e)
        {
            picEXCEL1.Image = Properties.Resources.Excel1;
        }

        private void picEXCEL2_MouseHover(object sender, EventArgs e)
        {
            picEXCEL2.Image = Properties.Resources.Excel2;
        }

        private void picEXCEL2_MouseLeave(object sender, EventArgs e)
        {
            picEXCEL2.Image = Properties.Resources.Excel1;
        }

        private void picSQL_SELECT_MouseHover(object sender, EventArgs e)
        {
            picSQL_SELECT.Image = Properties.Resources.db4;
        }

        private void picSQL_SELECT_MouseLeave(object sender, EventArgs e)
        {
            picSQL_SELECT.Image = Properties.Resources.db2;
        }

        private void picSQL_Query_MouseHover(object sender, EventArgs e)
        {
            picSQL_Query.Image = Properties.Resources.db4;
        }

        private void picSQL_Query_MouseLeave(object sender, EventArgs e)
        {
            picSQL_Query.Image = Properties.Resources.db3;
        }

        private void picSQL_IU_MouseHover(object sender, EventArgs e)
        {
            picSQL_IU.Image = Properties.Resources.db4;
        }

        private void picSQL_IU_MouseLeave(object sender, EventArgs e)
        {
            picSQL_IU.Image = Properties.Resources.db1;
        }

        private void picSystem_MouseHover(object sender, EventArgs e)
        {
            picSystem.Image = Properties.Resources.Option2;
        }

        private void picSystem_MouseLeave(object sender, EventArgs e)
        {
            picSystem.Image = Properties.Resources.Option1;
        }
        private void picDown_MouseEnter(object sender, EventArgs e)
        {
            picDown.Image = Properties.Resources.down2;
        }

        private void picDown_MouseLeave(object sender, EventArgs e)
        {
            picDown.Image = Properties.Resources.down;
        }
        #endregion

        private void BL71_Main_Load(object sender, EventArgs e)
        {
            //不检测线程错误
            CheckForIllegalCrossThreadCalls = false;

            Qiniu.JSON.JsonHelper.JsonSerializer = new AnotherJsonSerializer();
            Qiniu.JSON.JsonHelper.JsonDeserializer = new AnotherJsonDeserializer();

            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

            lblNoteCount.Text = "Note:"+dal.ExecuteInt("Select Count(*) from Notes where type =2").ToString();

            lblEditDate.Text = dal.ExecuteString("Select EditDate From Remind");
            txtNote.Text = dal.ExecuteString("Select Notes From Remind");

            //检测版本
            Thread th = new Thread(new ThreadStart(CheckVersion));
            th.Start();

            lblMsg.Text = "";
            lblVersion.Text = "";
        }

        //打开子窗体的方式
        public void OpenForm(Form from)
        {
            panBody.Controls.Clear();
            from.TopLevel = false;
            from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panBody.Controls.Add(from);
            from.Dock = DockStyle.Fill;
            from.WindowState = this.WindowState;
            from.Tag = this;
            from.Show();
        }
 
        //笔记
        private void picMain_Click(object sender, EventArgs e)
        {
            BL71_Bowtech from = new BL71_Bowtech();
            panBody.Controls.Clear();
            from.TopLevel = false;
            from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panBody.Controls.Add(from);
            from.Dock = DockStyle.Fill;
            from.AddTree();
            from.Main = this;
            from.Show();
        }
        //查询笔记
        private void picMainQ_Click(object sender, EventArgs e)
        {
            BL71_Bowtech_Query from = new BL71_Bowtech_Query(this);
            OpenForm(from);
        }
        //导入EXCEL
        private void picEXCEL1_Click(object sender, EventArgs e)
        {
            BL71_ImportExcel from = new BL71_ImportExcel(this);
            OpenForm(from);
        }
        //导入EXCEL碎片
        private void picEXCEL2_Click(object sender, EventArgs e)
        {
            BL71_ImportExcel_Far from = new BL71_ImportExcel_Far(this);
            OpenForm(from);
        }
        //数据库查询
        private void picSQL_SELECT_Click(object sender, EventArgs e)
        {
            BL71_QueryDB from = new BL71_QueryDB();
            OpenForm(from);
        }
        //数据库 生成查询
        private void picSQL_Query_Click(object sender, EventArgs e)
        {
            BL71_SQL_Select from = new BL71_SQL_Select();
            OpenForm(from);
        }
        //数据库 生成新增修改
        private void picSQL_IU_Click(object sender, EventArgs e)
        {
            BL71_SQL_InsertUpdate from = new BL71_SQL_InsertUpdate(); 
            OpenForm(from);
        }
        //系统设置
        private void picSystem_Click(object sender, EventArgs e)
        {
            BL71_Option from = new BL71_Option(this);
            OpenForm(from);
        }
        //释放线程
        private void BL71_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }
        //最小化
        private void picDown_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)//最大化
            {
                this.WindowState = FormWindowState.Maximized;

                int mainWith = this.Size.Width;//窗体总宽度
                int closeWith = picCLZ.Width;//关闭按钮宽度
                int smorWith = picZXH.Width;//最小化宽度
                int maxWith = picDown.Width;//最大化
                int numWith = lblNoteCount.Width + 10;//计数器

                picCLZ.Location = new Point(mainWith - closeWith, picCLZ.Location.Y);
                picZXH.Location = new Point(mainWith - closeWith - smorWith, picZXH.Location.Y);
                picDown.Location = new Point(mainWith - closeWith - smorWith - maxWith, picDown.Location.Y);
                lblNoteCount.Location = new Point(mainWith - closeWith - smorWith - maxWith - numWith, lblNoteCount.Location.Y);
            }
            else //返回普通模式
            {
                this.WindowState = FormWindowState.Normal;

                picCLZ.Location = new Point(993, 1);
                picZXH.Location = new Point(963, 1);
                picDown.Location = new Point(933, 1);
                lblNoteCount.Location = new Point(841, 8);
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                this.Show();
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
            }
        }
        //点击HTML
        private void picHTML_Click(object sender, EventArgs e)
        {
            BL71_HTML from = new BL71_HTML();
            from.Main = this;
            OpenForm(from);
        }

        //私人记录
        private void picCation_Click(object sender, EventArgs e)
        {
           
            BL71_Lock from = new BL71_Lock(this);
            from.Main = this;
            OpenForm(from);
        }
        //收藏夹
        private void picIEAddress_Click(object sender, EventArgs e)
        {
            BL71_IEAddress from = new BL71_IEAddress();
            from.Main = this;
            OpenForm(from);
        }

        //检测版本
        public void CheckVersion()
        {
            try
            {
                CdnRefresh();

                // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
                // 实际应用中，请自行设置您的AccessKey和SecretKey
                Mac mac = new Mac(AK, SK);
                string bucket = "mydb";
                string marker = ""; // 首次请求时marker必须为空
                string prefix = null; // 按文件名前缀保留搜索结果
                string delimiter = null; // 目录分割字符(比如"/")
                int limit = 100; // 单次列举数量限制(最大值为1000)
                BucketManager bm = new BucketManager(mac);
                List<FileDesc> items = new List<FileDesc>();
                do
                {
                    ListResult result = bm.ListFiles(bucket, prefix, marker, limit, delimiter);
                    Console.WriteLine(result);
                    marker = result.Result.Marker;
                    if (result.Result.Items != null)
                    {
                        items.AddRange(result.Result.Items);
                    }
                } while (!string.IsNullOrEmpty(marker));


                for (int i = 0; i < items.Count; i++)
                {
                    //判断名称里是否包含 Version  例：Version0
                    if (items[i].Key.IndexOf("version")>=0)
                    {
                        string Version = items[i].Key.Substring(7);
                        Version = Version.Substring(0, Version.Length - 4);

                        int dbversion = dal.ExecuteInt("Select VersionID From Version");
                        if (Convert.ToInt32(Version) > dbversion)
                        {
                            lblVersion.Text = "需更新版本";
                        }
                        else if (Convert.ToInt32(Version) == dbversion)
                        {
                            lblVersion.Text = "最新版本";
                        }
                        else if (Convert.ToInt32(Version) < dbversion)
                        {
                            lblVersion.Text = "请上传版本";
                        }
                    }
                }
            }
            catch (Exception ep)
            {
                lblVersion.Text = "网络不给力";
            }
        }
        /// <summary>
        /// 缓存刷新
        /// </summary>
        public void CdnRefresh()
        {
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            CdnManager cdnMgr = new CdnManager(mac);
            string[] dirs = new string[] { "http://omt3z8gfa.bkt.clouddn.com/" };
            var result = cdnMgr.RefreshDirs(dirs);
            // 或者使用下面的方法
            //RefreshRequest request = new RefreshRequest();
            //request.AddDirs(dirs);
            //var result = cdnMgr.RefreshUrlsAndDirs(request);
            Console.WriteLine(result);
        }


        public void AlertMsg(string Msg)
        {
            Thread th = new Thread(new ParameterizedThreadStart(TreadMsg));
            th.Start(Msg);
        }
 
        private void TreadMsg(object Msg)
        {
            lblMsg.Text = Msg.ToString();
            lblMsg.Visible = true;
            Thread.Sleep(2000);
            lblMsg.Visible = false;
        }

        //保存 提醒
        private void btnNoteSave_Click(object sender, EventArgs e)
        {
            dal.ExecuteNonQuery("Update Remind Set Notes='"+ Filter(txtNote.Text)+ "',EditDate='"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'");
            AlertMsg("记录完成！");
            UpdateVersion();
        }
        //过滤器
        public static string Filter(string str)
        {
            if (str.IndexOf("'") >= 0)
                str = str.Replace("'", "''");
            return str;
        }

        //更新版本号
        public void UpdateVersion()
        {
            int dbversion = dal.ExecuteInt("Select VersionID From Version");
            dbversion++;
            dal.ExecuteNonQuery("Update Version set VersionID='" + dbversion + "'");
            lblVersion.Text = "请上传版本";
            lblVersion.ForeColor = Color.FromArgb(0, 0, 255);
        }

        private void lblVersion_DoubleClick(object sender, EventArgs e)
        {
            if (lblVersion.Text == "需更新版本")
            {
                BL71_Option_UpDownLoad up = new BL71_Option_UpDownLoad(this);
                up.btnDown_Click(null, null);
            }
            else if (lblVersion.Text == "请上传版本")
            {
                BL71_Option_UpDownLoad up = new BL71_Option_UpDownLoad(this);
                up.btnUp_Click(null, null);
            }
        }
    }
}
