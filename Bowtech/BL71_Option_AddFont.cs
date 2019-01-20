using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Bowtech
{
    public partial class BL71_Option_AddFont : Form
    {
        BL71_Main Main;
        SQLite dal;
        public BL71_Option_AddFont(BL71_Main M)
        {
            InitializeComponent();
            DoubleBuffered = true;

            Main = M;
        }
        #region 切换图片
        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5_3;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.b5;
        }

        private void picClose_MouseEnter(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO_2;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            picClose.Image = Properties.Resources.NO;
        }
 

        #endregion

        private void BL71_Option_ConnectDB_Load(object sender, EventArgs e)
        {
            dal = new SQLite();
            dal.DBPath = Application.StartupPath + "\\Bowtech.db";
            dal.InitDB();

        }
 
 
        //退出
        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //回车事件
        private void txtFontName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddFont();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddFont();
        }
        //添加关键字
        public void AddFont()
        {
            try
            {
                string path = Application.StartupPath + "\\csharp.xml";
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(path);

                XmlNode xmlNode = xmlDocument.DocumentElement;//获取所有节点

                foreach (XmlNode node in xmlNode)
                {
                    foreach (XmlNode nodeC in node.ChildNodes)
                    {
                        if (nodeC.Name == "Token")
                        {
                            if (txtFontName.Text.Trim() == nodeC.InnerText.Trim())
                            {
                                Main.AlertMsg("已存在该关键字！");
                                return ;
                            }
                        }
                    }
                }


                XmlNode nodeNew = xmlDocument.CreateElement("Descriptor");//创建一级子节点

                XmlNode nd = xmlDocument.CreateElement("Token");//创建二级子节点
                nd.InnerText = txtFontName.Text;
                nodeNew.AppendChild(nd);

                XmlNode CloseToken = xmlDocument.CreateElement("CloseToken");
                CloseToken.InnerText = "";
                nodeNew.AppendChild(CloseToken);

                XmlNode Color = xmlDocument.CreateElement("Color");
                Color.InnerText = "43,145,175";
                nodeNew.AppendChild(Color);

                XmlNode Font = xmlDocument.CreateElement("Font");
                Font.InnerText = "宋体,20";
                nodeNew.AppendChild(Font);

                XmlNode DescriptorType = xmlDocument.CreateElement("DescriptorType");
                DescriptorType.InnerText = "Word";
                nodeNew.AppendChild(DescriptorType);

                XmlNode DescriptorRecognition = xmlDocument.CreateElement("DescriptorRecognition");
                DescriptorRecognition.InnerText = "WholeWord";
                nodeNew.AppendChild(DescriptorRecognition);

                XmlNode UseForAutoComplete = xmlDocument.CreateElement("UseForAutoComplete");
                UseForAutoComplete.InnerText = "True";
                nodeNew.AppendChild(UseForAutoComplete);

                xmlNode.AppendChild(nodeNew);
                xmlDocument.AppendChild(xmlNode);
                xmlDocument.Save("csharp.XML");
                txtFontName.Text = "";
                Main.AlertMsg("添加完成！");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

 
    }
}
