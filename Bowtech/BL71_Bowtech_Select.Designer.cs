namespace Bowtech
{
    partial class BL71_Bowtech_Select
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
            this.components = new System.ComponentModel.Container();
            this.panFather = new System.Windows.Forms.Panel();
            this.panTree = new System.Windows.Forms.Panel();
            this.tvDetail = new System.Windows.Forms.TreeView();
            this.cmsEx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiZK = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSS = new System.Windows.Forms.ToolStripMenuItem();
            this.panTop = new System.Windows.Forms.Panel();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.picHome = new System.Windows.Forms.PictureBox();
            this.panMain = new System.Windows.Forms.Panel();
            this.lblContent = new System.Windows.Forms.Label();
            this.txtContent = new Kevin.SyntaxTextBox.SyntaxTextBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panFather.SuspendLayout();
            this.panTree.SuspendLayout();
            this.cmsEx.SuspendLayout();
            this.panTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).BeginInit();
            this.panMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panFather
            // 
            this.panFather.Controls.Add(this.panTree);
            this.panFather.Controls.Add(this.panTop);
            this.panFather.Dock = System.Windows.Forms.DockStyle.Left;
            this.panFather.Location = new System.Drawing.Point(0, 0);
            this.panFather.Name = "panFather";
            this.panFather.Size = new System.Drawing.Size(200, 485);
            this.panFather.TabIndex = 55;
            // 
            // panTree
            // 
            this.panTree.AutoScroll = true;
            this.panTree.BackColor = System.Drawing.Color.Transparent;
            this.panTree.Controls.Add(this.tvDetail);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTree.Location = new System.Drawing.Point(0, 40);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(200, 445);
            this.panTree.TabIndex = 0;
            // 
            // tvDetail
            // 
            this.tvDetail.BackColor = System.Drawing.Color.White;
            this.tvDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvDetail.ContextMenuStrip = this.cmsEx;
            this.tvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDetail.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvDetail.ForeColor = System.Drawing.Color.Blue;
            this.tvDetail.Location = new System.Drawing.Point(0, 0);
            this.tvDetail.Name = "tvDetail";
            this.tvDetail.Size = new System.Drawing.Size(200, 445);
            this.tvDetail.TabIndex = 6;
            this.tvDetail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDetail_AfterSelect);
            // 
            // cmsEx
            // 
            this.cmsEx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiZK,
            this.tsmiSS});
            this.cmsEx.Name = "cmsEx";
            this.cmsEx.Size = new System.Drawing.Size(101, 48);
            // 
            // tsmiZK
            // 
            this.tsmiZK.Name = "tsmiZK";
            this.tsmiZK.Size = new System.Drawing.Size(100, 22);
            this.tsmiZK.Text = "展开";
            this.tsmiZK.Click += new System.EventHandler(this.tsmiZK_Click);
            // 
            // tsmiSS
            // 
            this.tsmiSS.Name = "tsmiSS";
            this.tsmiSS.Size = new System.Drawing.Size(100, 22);
            this.tsmiSS.Text = "收缩";
            this.tsmiSS.Click += new System.EventHandler(this.tsmiSS_Click);
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.txtName);
            this.panTop.Controls.Add(this.picHome);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(200, 40);
            this.panTop.TabIndex = 0;
            // 
            // txtName
            // 
            // 
            // 
            // 
            this.txtName.Border.Class = "TextBoxBorder";
            this.txtName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtName.Location = new System.Drawing.Point(6, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 29);
            this.txtName.TabIndex = 5;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // picHome
            // 
            this.picHome.Image = global::Bowtech.Properties.Resources.Query;
            this.picHome.Location = new System.Drawing.Point(165, 3);
            this.picHome.Name = "picHome";
            this.picHome.Size = new System.Drawing.Size(35, 35);
            this.picHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHome.TabIndex = 0;
            this.picHome.TabStop = false;
            this.picHome.Click += new System.EventHandler(this.picHome_Click);
            this.picHome.MouseEnter += new System.EventHandler(this.picHome_MouseEnter);
            this.picHome.MouseLeave += new System.EventHandler(this.picHome_MouseLeave);
            // 
            // panMain
            // 
            this.panMain.BackColor = System.Drawing.Color.Transparent;
            this.panMain.Controls.Add(this.lblContent);
            this.panMain.Controls.Add(this.txtContent);
            this.panMain.Controls.Add(this.picClose);
            this.panMain.Location = new System.Drawing.Point(200, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(822, 485);
            this.panMain.TabIndex = 58;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblContent.Location = new System.Drawing.Point(220, 9);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(0, 25);
            this.lblContent.TabIndex = 57;
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
            // BL71_Bowtech_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 485);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panFather);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_Bowtech_Select";
            this.Text = "BL71_Bowtech_Select";
            this.Load += new System.EventHandler(this.BL71_Bowtech_Select_Load);
            this.Resize += new System.EventHandler(this.BL71_Bowtech_Select_Resize);
            this.panFather.ResumeLayout(false);
            this.panTree.ResumeLayout(false);
            this.cmsEx.ResumeLayout(false);
            this.panTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHome)).EndInit();
            this.panMain.ResumeLayout(false);
            this.panMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panFather;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.PictureBox picHome;
        private System.Windows.Forms.Panel panMain;
        public Kevin.SyntaxTextBox.SyntaxTextBox txtContent;
        public System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TreeView tvDetail;
        private DevComponents.DotNetBar.Controls.TextBoxX txtName;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.ContextMenuStrip cmsEx;
        private System.Windows.Forms.ToolStripMenuItem tsmiZK;
        private System.Windows.Forms.ToolStripMenuItem tsmiSS;
    }
}