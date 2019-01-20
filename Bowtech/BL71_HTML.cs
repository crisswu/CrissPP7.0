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
using WebKit;

namespace Bowtech
{
    public partial class BL71_HTML : Form
    {
        public  BL71_Main Main;
        public BL71_HTML()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void BL71_ImportExcel_Load(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                int mainWith = this.Size.Width;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith, picClose.Location.Y);
            }
        }
        //执行HTML
        public void GoHTML(string URL)
        {
            BL71_WebKit from = new BL71_WebKit();
            from.URL = URL;
            Main.OpenForm(from);
            this.Close();
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
        private void picFormat_MouseEnter(object sender, EventArgs e)
        {
            picFormat.Image = Properties.Resources.ChangeGo3; 
        }

        private void picFormat_MouseLeave(object sender, EventArgs e)
        {
            picFormat.Image = Properties.Resources.Format;
        }
        private void btnBaiDuFanYi_MouseEnter(object sender, EventArgs e)
        {
            btnBaiDuFanYi.Image = Properties.Resources.ChangeGo3;
        }

        private void btnBaiDuFanYi_MouseLeave(object sender, EventArgs e)
        {
            btnBaiDuFanYi.Image = Properties.Resources.baidu;
        }
        //百度翻译
        private void btnBaiDuFanYi_Click(object sender, EventArgs e)
        {
            GoHTML("http://fanyi.baidu.com/translate");
        }

        private void picJson_MouseEnter(object sender, EventArgs e)
        {
            picJson.Image = Properties.Resources.ChangeGo3;
        }

        private void picJson_MouseLeave(object sender, EventArgs e)
        {
            picJson.Image = Properties.Resources.Json;
        }

        private void picJson_Click(object sender, EventArgs e)
        {
            GoHTML("http://www.bejson.com/");
        }

        private void picColor_MouseEnter(object sender, EventArgs e)
        {
            picColor.Image = Properties.Resources.ChangeGo3;
        }

        private void picColor_MouseLeave(object sender, EventArgs e)
        {
            picColor.Image = Properties.Resources.ConvertColor;
        }

        private void picColor_Click(object sender, EventArgs e)
        {
            GoHTML("http://www.sioe.cn/yingyong/yanse-rgb-16/");
        }

        private void picSeeColor_MouseEnter(object sender, EventArgs e)
        {
            picSeeColor.Image = Properties.Resources.ChangeGo3;
        }

        private void picSeeColor_MouseLeave(object sender, EventArgs e)
        {
            picSeeColor.Image = Properties.Resources.SeeColor;
        }

        private void picSeeColor_Click(object sender, EventArgs e)
        {
            GoHTML("http://www.qqai.net/tool/yansedaima/");
        }

        private void BL71_HTML_Resize(object sender, EventArgs e)
        {
            if (Main.WindowState == FormWindowState.Maximized)//支持最大化
            {
                int mainWith = this.Size.Width;//窗体总宽度
                int closeWith = picClose.Width;//关闭按钮宽度
                picClose.Location = new Point(mainWith - closeWith, picClose.Location.Y);
            }
            else
            {
                picClose.Location = new Point(995, 1);
            }
        }

        private void picFormat_Click(object sender, EventArgs e)
        {
            GoHTML("http://tool.oschina.net/codeformat/json");
        }

        private void PicBase_MouseEnter(object sender, EventArgs e)
        {
            PicBase.Image = Properties.Resources.ChangeGo3;
        }

        private void PicBase_MouseLeave(object sender, EventArgs e)
        {
            PicBase.Image = Properties.Resources.base64;
        }

        private void PicBase_Click(object sender, EventArgs e)
        {
            GoHTML("http://cli.im/");
        }
    }
}
