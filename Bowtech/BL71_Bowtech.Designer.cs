namespace Bowtech
{
    partial class BL71_Bowtech
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panTree = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panTop = new System.Windows.Forms.Panel();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.panFather = new System.Windows.Forms.Panel();
            this.txtContent = new Kevin.SyntaxTextBox.SyntaxTextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.panMain = new System.Windows.Forms.Panel();
            this.txtUpdateCon = new System.Windows.Forms.TextBox();
            this.wbHtml = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.panFather.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panTree
            // 
            this.panTree.AutoScroll = true;
            this.panTree.BackColor = System.Drawing.Color.Transparent;
            this.panTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTree.Location = new System.Drawing.Point(0, 40);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(200, 445);
            this.panTree.TabIndex = 0;
            this.panTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTree_MouseDown);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bowtech.Properties.Resources.NO;
            this.picClose.Location = new System.Drawing.Point(794, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 53;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.picAdd);
            this.panTop.Controls.Add(this.picDelete);
            this.panTop.Controls.Add(this.picBack);
            this.panTop.Controls.Add(this.picHome);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(200, 40);
            this.panTop.TabIndex = 0;
            // 
            // picAdd
            // 
            this.picAdd.Image = global::Bowtech.Properties.Resources.b5;
            this.picAdd.Location = new System.Drawing.Point(152, 2);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(35, 35);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 0;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            this.picAdd.MouseEnter += new System.EventHandler(this.picAdd_MouseEnter);
            this.picAdd.MouseLeave += new System.EventHandler(this.picAdd_MouseLeave);
            // 
            // picDelete
            // 
            this.picDelete.Image = global::Bowtech.Properties.Resources.b4;
            this.picDelete.Location = new System.Drawing.Point(103, 2);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(35, 35);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 0;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            this.picDelete.MouseEnter += new System.EventHandler(this.picDelete_MouseEnter);
            this.picDelete.MouseLeave += new System.EventHandler(this.picDelete_MouseLeave);
            // 
            // picBack
            // 
            this.picBack.Image = global::Bowtech.Properties.Resources.left;
            this.picBack.Location = new System.Drawing.Point(57, 2);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(35, 35);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 0;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            this.picBack.MouseEnter += new System.EventHandler(this.picBack_MouseEnter);
            this.picBack.MouseLeave += new System.EventHandler(this.picBack_MouseLeave);
            // 
            // picHome
            // 
            this.picHome.Image = global::Bowtech.Properties.Resources.FUQMC;
            this.picHome.Location = new System.Drawing.Point(11, 2);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(35, 35);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 0;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            this.picHome.MouseEnter += new System.EventHandler(this.picHome_MouseEnter);
            this.picHome.MouseLeave += new System.EventHandler(this.picHome_MouseLeave);
            // 
            // panFather
            // 
            this.panFather.Controls.Add(this.panTree);
            this.panFather.Controls.Add(this.panTop);
            this.panFather.Dock = System.Windows.Forms.DockStyle.Left;
            this.panFather.Location = new System.Drawing.Point(0, 0);
            this.panFather.Name = "panFather";
            this.panFather.Size = new System.Drawing.Size(200, 485);
            this.panFather.TabIndex = 54;
            // 
            // txtContent
            // 
            this.txtContent.AcceptsTab = true;
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.CaseSensitive = false;
            this.txtContent.ConfigFile = "csharp.xml";
            this.txtContent.FilterAutoComplete = true;
            this.txtContent.Location = new System.Drawing.Point(0, 40);
            this.txtContent.MaxUndoRedoSteps = 50;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(822, 443);
            this.txtContent.TabIndex = 55;
            this.txtContent.Text = "";
            this.txtContent.WordWrap = false;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.Location = new System.Drawing.Point(420, 7);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(0, 25);
            this.lblContent.TabIndex = 56;
            this.lblContent.DoubleClick += new System.EventHandler(this.lblContent_DoubleClick);
            // 
            // picSave
            // 
            this.picSave.BackColor = System.Drawing.Color.Transparent;
            this.picSave.Image = global::Bowtech.Properties.Resources.b3;
            this.picSave.Location = new System.Drawing.Point(7, 3);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(35, 35);
            this.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSave.TabIndex = 0;
            this.picSave.TabStop = false;
            this.picSave.Visible = false;
            this.picSave.Click += new System.EventHandler(this.picSave_Click);
            this.picSave.MouseEnter += new System.EventHandler(this.picSave_MouseEnter);
            this.picSave.MouseLeave += new System.EventHandler(this.picSave_MouseLeave);
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Transparent;
            this.panMain.Controls.Add(this.txtUpdateCon);
            this.panMain.Controls.Add(this.wbHtml);
            this.panMain.Controls.Add(this.txtContent);
            this.panMain.Controls.Add(this.picSave);
            this.panMain.Controls.Add(this.picClose);
            this.panMain.Location = new System.Drawing.Point(200, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(822, 485);
            this.panMain.TabIndex = 57;
            // 
            // txtUpdateCon
            // 
            this.txtUpdateCon.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUpdateCon.Location = new System.Drawing.Point(222, 4);
            this.txtUpdateCon.Name = "txtUpdateCon";
            this.txtUpdateCon.Size = new System.Drawing.Size(429, 32);
            this.txtUpdateCon.TabIndex = 57;
            this.txtUpdateCon.Visible = false;
            this.txtUpdateCon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Content_KeyDown);
            // 
            // wbHtml
            // 
            this.wbHtml.Location = new System.Drawing.Point(0, 40);
            this.wbHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtml.Name = "wbHtml";
            this.wbHtml.Size = new System.Drawing.Size(822, 443);
            this.wbHtml.TabIndex = 56;
            this.wbHtml.Visible = false;
            // 
            // BL71_Bowtech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 485);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panFather);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_Bowtech";
            this.Text = "BL71_Bowtech";
            this.Load += new System.EventHandler(this.BL71_Bowtech_Load);
            this.Resize += new System.EventHandler(this.BL71_Bowtech_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.panFather.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Panel panFather;
        private System.Windows.Forms.PictureBox picAdd;
        private System.Windows.Forms.PictureBox picDelete;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Panel panMain;
        public System.Windows.Forms.PictureBox picClose;
        public Kevin.SyntaxTextBox.SyntaxTextBox txtContent;
        public System.Windows.Forms.PictureBox picSave;
        private System.Windows.Forms.WebBrowser wbHtml;
        private System.Windows.Forms.TextBox txtUpdateCon;
    }
}