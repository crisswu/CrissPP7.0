namespace Bowtech
{
    partial class BL71_SQL_Select
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
            this.panCol = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.panTableName = new System.Windows.Forms.Panel();
            this.lbTableName = new System.Windows.Forms.ListBox();
            this.panSql = new System.Windows.Forms.Panel();
            this.txtSQL = new Kevin.SyntaxTextBox.SyntaxTextBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.cboDB = new System.Windows.Forms.ComboBox();
            this.lvAll = new System.Windows.Forms.ListView();
            this.lvInner = new System.Windows.Forms.ListView();
            this.lvLeft = new System.Windows.Forms.ListView();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSum = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCount = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAvg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMax = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNull = new System.Windows.Forms.ToolStripMenuItem();
            this.picDel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            this.panTableName.SuspendLayout();
            this.panSql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).BeginInit();
            this.SuspendLayout();
            // 
            // panCol
            // 
            this.panCol.AllowDrop = true;
            this.panCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCol.Dock = System.Windows.Forms.DockStyle.Left;
            this.panCol.Location = new System.Drawing.Point(0, 0);
            this.panCol.Name = "panCol";
            this.panCol.Size = new System.Drawing.Size(497, 485);
            this.panCol.TabIndex = 14;
            this.panCol.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelEx_DragDrop);
            this.panCol.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelEx_DragEnter);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Image = global::Bowtech.Properties.Resources.b3;
            this.btnDelete.Location = new System.Drawing.Point(560, 169);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 50);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 75;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseEnter += new System.EventHandler(this.btnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.Image = global::Bowtech.Properties.Resources.play1;
            this.btnPlay.Location = new System.Drawing.Point(504, 169);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(50, 50);
            this.btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPlay.TabIndex = 74;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.btnPlay_MouseLeave);
            // 
            // panTableName
            // 
            this.panTableName.BackColor = System.Drawing.Color.Transparent;
            this.panTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTableName.Controls.Add(this.lbTableName);
            this.panTableName.Location = new System.Drawing.Point(503, 249);
            this.panTableName.Name = "panTableName";
            this.panTableName.Size = new System.Drawing.Size(153, 236);
            this.panTableName.TabIndex = 73;
            // 
            // lbTableName
            // 
            this.lbTableName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbTableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTableName.FormattingEnabled = true;
            this.lbTableName.ItemHeight = 12;
            this.lbTableName.Location = new System.Drawing.Point(0, 0);
            this.lbTableName.Name = "lbTableName";
            this.lbTableName.Size = new System.Drawing.Size(151, 234);
            this.lbTableName.TabIndex = 55;
            this.lbTableName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbTableName_MouseDown);
            // 
            // panSql
            // 
            this.panSql.BackColor = System.Drawing.Color.Transparent;
            this.panSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSql.Controls.Add(this.txtSQL);
            this.panSql.Location = new System.Drawing.Point(661, 225);
            this.panSql.Name = "panSql";
            this.panSql.Size = new System.Drawing.Size(358, 260);
            this.panSql.TabIndex = 72;
            // 
            // txtSQL
            // 
            this.txtSQL.AcceptsTab = true;
            this.txtSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSQL.CaseSensitive = false;
            this.txtSQL.ConfigFile = "csharp.xml";
            this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSQL.FilterAutoComplete = true;
            this.txtSQL.Location = new System.Drawing.Point(0, 0);
            this.txtSQL.MaxUndoRedoSteps = 50;
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(356, 258);
            this.txtSQL.TabIndex = 56;
            this.txtSQL.Text = "";
            this.txtSQL.WordWrap = false;
            // 
            // txtSort
            // 
            this.txtSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSort.Location = new System.Drawing.Point(503, 225);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(153, 21);
            this.txtSort.TabIndex = 71;
            this.txtSort.TextChanged += new System.EventHandler(this.txtSort_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Bowtech.Properties.Resources.SFYZ;
            this.pictureBox2.Location = new System.Drawing.Point(514, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Bowtech.Properties.Resources.FUQMC;
            this.pictureBox1.Location = new System.Drawing.Point(514, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // cboServer
            // 
            this.cboServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(556, 14);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(183, 29);
            this.cboServer.TabIndex = 77;
            this.cboServer.SelectedIndexChanged += new System.EventHandler(this.cboServer_SelectedIndexChanged);
            // 
            // cboDB
            // 
            this.cboDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboDB.FormattingEnabled = true;
            this.cboDB.Location = new System.Drawing.Point(556, 57);
            this.cboDB.Name = "cboDB";
            this.cboDB.Size = new System.Drawing.Size(183, 29);
            this.cboDB.TabIndex = 76;
            this.cboDB.SelectedIndexChanged += new System.EventHandler(this.cboDB_SelectedIndexChanged);
            // 
            // lvAll
            // 
            this.lvAll.Location = new System.Drawing.Point(878, 131);
            this.lvAll.Name = "lvAll";
            this.lvAll.Size = new System.Drawing.Size(140, 62);
            this.lvAll.TabIndex = 85;
            this.lvAll.TileSize = new System.Drawing.Size(128, 24);
            this.lvAll.UseCompatibleStateImageBehavior = false;
            this.lvAll.View = System.Windows.Forms.View.SmallIcon;
            this.lvAll.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvLeft_DragEnter);
            this.lvAll.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLeft_DragEnter);
            // 
            // lvInner
            // 
            this.lvInner.AllowDrop = true;
            this.lvInner.Location = new System.Drawing.Point(878, 83);
            this.lvInner.Name = "lvInner";
            this.lvInner.Size = new System.Drawing.Size(140, 42);
            this.lvInner.TabIndex = 84;
            this.lvInner.TileSize = new System.Drawing.Size(128, 24);
            this.lvInner.UseCompatibleStateImageBehavior = false;
            this.lvInner.View = System.Windows.Forms.View.SmallIcon;
            this.lvInner.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvInner_DragDrop);
            this.lvInner.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLeft_DragEnter);
            // 
            // lvLeft
            // 
            this.lvLeft.AllowDrop = true;
            this.lvLeft.Location = new System.Drawing.Point(878, 35);
            this.lvLeft.Name = "lvLeft";
            this.lvLeft.Size = new System.Drawing.Size(140, 42);
            this.lvLeft.TabIndex = 83;
            this.lvLeft.TileSize = new System.Drawing.Size(128, 24);
            this.lvLeft.UseCompatibleStateImageBehavior = false;
            this.lvLeft.View = System.Windows.Forms.View.SmallIcon;
            this.lvLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvLeft_DragDrop);
            this.lvLeft.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvLeft_DragEnter);
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bowtech.Properties.Resources.NO;
            this.picClose.Location = new System.Drawing.Point(994, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 86;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Bowtech.Properties.Resources.leftJoin;
            this.pictureBox3.Location = new System.Drawing.Point(823, 34);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Bowtech.Properties.Resources.Inner;
            this.pictureBox4.Location = new System.Drawing.Point(823, 80);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(50, 50);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 79;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Bowtech.Properties.Resources.ALL;
            this.pictureBox5.Location = new System.Drawing.Point(824, 129);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(50, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 79;
            this.pictureBox5.TabStop = false;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSum,
            this.tsmiCount,
            this.tsmiAvg,
            this.tsmiMax,
            this.tsmiMin,
            this.tsmiNull});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(121, 136);
            // 
            // tsmiSum
            // 
            this.tsmiSum.Name = "tsmiSum";
            this.tsmiSum.Size = new System.Drawing.Size(120, 22);
            this.tsmiSum.Text = "SUM";
            // 
            // tsmiCount
            // 
            this.tsmiCount.Name = "tsmiCount";
            this.tsmiCount.Size = new System.Drawing.Size(120, 22);
            this.tsmiCount.Text = "COUNT";
            // 
            // tsmiAvg
            // 
            this.tsmiAvg.Name = "tsmiAvg";
            this.tsmiAvg.Size = new System.Drawing.Size(120, 22);
            this.tsmiAvg.Text = "AVG";
            // 
            // tsmiMax
            // 
            this.tsmiMax.Name = "tsmiMax";
            this.tsmiMax.Size = new System.Drawing.Size(120, 22);
            this.tsmiMax.Text = "MAX";
            // 
            // tsmiMin
            // 
            this.tsmiMin.Name = "tsmiMin";
            this.tsmiMin.Size = new System.Drawing.Size(120, 22);
            this.tsmiMin.Text = "MIN";
            // 
            // tsmiNull
            // 
            this.tsmiNull.Name = "tsmiNull";
            this.tsmiNull.Size = new System.Drawing.Size(120, 22);
            this.tsmiNull.Text = "None";
            // 
            // picDel
            // 
            this.picDel.BackColor = System.Drawing.Color.Transparent;
            this.picDel.Image = global::Bowtech.Properties.Resources.delete;
            this.picDel.Location = new System.Drawing.Point(615, 169);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(50, 50);
            this.picDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDel.TabIndex = 75;
            this.picDel.TabStop = false;
            this.picDel.Click += new System.EventHandler(this.picDel_Click);
            this.picDel.MouseEnter += new System.EventHandler(this.picDel_MouseEnter);
            this.picDel.MouseLeave += new System.EventHandler(this.picDel_MouseLeave);
            // 
            // BL71_SQL_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 485);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.lvAll);
            this.Controls.Add(this.lvInner);
            this.Controls.Add(this.lvLeft);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.cboDB);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.picDel);
            this.Controls.Add(this.panTableName);
            this.Controls.Add(this.panSql);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.panCol);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_SQL_Select";
            this.Text = "BL71_SQL_Select";
            this.Load += new System.EventHandler(this.BL71_SQL_Select_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            this.panTableName.ResumeLayout(false);
            this.panSql.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.cms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panCol;
        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.Panel panTableName;
        private System.Windows.Forms.ListBox lbTableName;
        private System.Windows.Forms.Panel panSql;
        private Kevin.SyntaxTextBox.SyntaxTextBox txtSQL;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.ComboBox cboDB;
        private System.Windows.Forms.ListView lvAll;
        private System.Windows.Forms.ListView lvInner;
        private System.Windows.Forms.ListView lvLeft;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem tsmiSum;
        private System.Windows.Forms.ToolStripMenuItem tsmiCount;
        private System.Windows.Forms.ToolStripMenuItem tsmiAvg;
        private System.Windows.Forms.ToolStripMenuItem tsmiMax;
        private System.Windows.Forms.ToolStripMenuItem tsmiMin;
        private System.Windows.Forms.ToolStripMenuItem tsmiNull;
        private System.Windows.Forms.PictureBox picDel;
    }
}