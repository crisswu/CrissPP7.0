using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bowtech
{
    public partial class BL71_Option : Form
    {
        public BL71_Main Main;
        public BL71_Option(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }

        private void BL71_Option_Load(object sender, EventArgs e)
        {

            // panTree.BackColor = Color.FromArgb(238, 239, 242);
            panTree.BackColor = Color.FromArgb(224, 224, 224);
        }
        //打开子窗体的方式
        public void OpenForm(Form from)
        {
            panMain.Controls.Clear();
            from.TopLevel = false;
            from.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panMain.Controls.Add(from);
            from.Dock = DockStyle.Fill;
            from.Show();
        }
        private void panSys1_MouseEnter(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            p.BackColor = Color.FromArgb(145, 193, 231);
        }

        private void panSys1_MouseLeave(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            //p.BackColor = Color.FromArgb(238, 239, 242);
            p.BackColor = Color.FromArgb(224, 224, 224);
        }
        private void lab_MouseEnter(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            Panel p = (Panel)lab.Parent;
            p.BackColor = Color.FromArgb(145, 193, 231);
        }

        private void lab_MouseLeave(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            Panel p = (Panel)lab.Parent;
            //p.BackColor = Color.FromArgb(238, 239, 242);
            p.BackColor = Color.FromArgb(224, 224, 224);
        }

        private void panSys1_Click(object sender, EventArgs e)
        {
            BL71_Option_ConnectDB from = new BL71_Option_ConnectDB(Main);
            OpenForm(from);
        }

        private void panSys2_Click(object sender, EventArgs e)
        {
            BL71_Option_NoteVisble from = new BL71_Option_NoteVisble(Main);
            OpenForm(from);
        }

        private void panSys3_Click(object sender, EventArgs e)
        {
            BL71_Option_NoteMove from = new BL71_Option_NoteMove();
            OpenForm(from);
        }

        private void panSys4_Click(object sender, EventArgs e)
        {
            BL71_Option_AddFont from = new BL71_Option_AddFont(Main);
            OpenForm(from);
        }

        private void panSys5_Click(object sender, EventArgs e)
        {
            BL71_Option_UpDownLoad from = new BL71_Option_UpDownLoad(Main);
            OpenForm(from);
        }

        private void panSys6_Click(object sender, EventArgs e)
        {
            BL71_Option_DonwnFile from = new BL71_Option_DonwnFile(Main);
            OpenForm(from);
        }
        //修改密码
        private void panSys7_Click(object sender, EventArgs e)
        {
            BL71_Option_ChangePWD from = new BL71_Option_ChangePWD(Main);
            OpenForm(from);
        }

        //网址维护
        private void panSys8_Click(object sender, EventArgs e)
        {
            BL71_Option_IEManage from = new BL71_Option_IEManage(Main);
            OpenForm(from);
        }
    }
}
