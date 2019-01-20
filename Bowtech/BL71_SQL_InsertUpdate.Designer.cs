namespace Bowtech
{
    partial class BL71_SQL_InsertUpdate
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
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panCol = new System.Windows.Forms.Panel();
            this.lbTableName = new System.Windows.Forms.ListBox();
            this.txtSQL = new Kevin.SyntaxTextBox.SyntaxTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbR0 = new System.Windows.Forms.RadioButton();
            this.rdbRi = new System.Windows.Forms.RadioButton();
            this.txtDataTable = new System.Windows.Forms.TextBox();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.rbtUpdate = new System.Windows.Forms.RadioButton();
            this.rbtnInsert = new System.Windows.Forms.RadioButton();
            this.cbFormat = new System.Windows.Forms.CheckBox();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.cboDB = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panSql = new System.Windows.Forms.Panel();
            this.panTableName = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panSql.SuspendLayout();
            this.panTableName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bowtech.Properties.Resources.NO;
            this.picClose.Location = new System.Drawing.Point(995, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 53;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // panCol
            // 
            this.panCol.AllowDrop = true;
            this.panCol.BackColor = System.Drawing.Color.Transparent;
            this.panCol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCol.Dock = System.Windows.Forms.DockStyle.Left;
            this.panCol.Location = new System.Drawing.Point(0, 0);
            this.panCol.Name = "panCol";
            this.panCol.Size = new System.Drawing.Size(497, 485);
            this.panCol.TabIndex = 54;
            this.panCol.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelEx_DragDrop);
            this.panCol.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelEx_DragEnter);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdbR0);
            this.groupBox1.Controls.Add(this.rdbRi);
            this.groupBox1.Controls.Add(this.txtDataTable);
            this.groupBox1.Controls.Add(this.labelX6);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(772, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 90);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DataTable";
            // 
            // rdbR0
            // 
            this.rdbR0.AutoSize = true;
            this.rdbR0.Checked = true;
            this.rdbR0.Location = new System.Drawing.Point(26, 55);
            this.rdbR0.Name = "rdbR0";
            this.rdbR0.Size = new System.Drawing.Size(66, 21);
            this.rdbR0.TabIndex = 20;
            this.rdbR0.TabStop = true;
            this.rdbR0.Text = "Row[0]";
            this.rdbR0.UseVisualStyleBackColor = true;
            // 
            // rdbRi
            // 
            this.rdbRi.AutoSize = true;
            this.rdbRi.Location = new System.Drawing.Point(113, 56);
            this.rdbRi.Name = "rdbRi";
            this.rdbRi.Size = new System.Drawing.Size(62, 21);
            this.rdbRi.TabIndex = 20;
            this.rdbRi.Text = "Row[i]";
            this.rdbRi.UseVisualStyleBackColor = true;
            // 
            // txtDataTable
            // 
            this.txtDataTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataTable.Location = new System.Drawing.Point(70, 26);
            this.txtDataTable.Name = "txtDataTable";
            this.txtDataTable.Size = new System.Drawing.Size(113, 23);
            this.txtDataTable.TabIndex = 19;
            // 
            // labelX6
            // 
            this.labelX6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX6.ForeColor = System.Drawing.Color.Black;
            this.labelX6.Location = new System.Drawing.Point(13, 25);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(56, 23);
            this.labelX6.TabIndex = 5;
            this.labelX6.Text = "参数：";
            // 
            // rbtUpdate
            // 
            this.rbtUpdate.AutoSize = true;
            this.rbtUpdate.BackColor = System.Drawing.Color.Transparent;
            this.rbtUpdate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtUpdate.ForeColor = System.Drawing.Color.Black;
            this.rbtUpdate.Location = new System.Drawing.Point(102, 23);
            this.rbtUpdate.Name = "rbtUpdate";
            this.rbtUpdate.Size = new System.Drawing.Size(84, 25);
            this.rbtUpdate.TabIndex = 59;
            this.rbtUpdate.Text = "Update";
            this.rbtUpdate.UseVisualStyleBackColor = false;
            // 
            // rbtnInsert
            // 
            this.rbtnInsert.AutoSize = true;
            this.rbtnInsert.BackColor = System.Drawing.Color.Transparent;
            this.rbtnInsert.Checked = true;
            this.rbtnInsert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnInsert.ForeColor = System.Drawing.Color.Black;
            this.rbtnInsert.Location = new System.Drawing.Point(21, 23);
            this.rbtnInsert.Name = "rbtnInsert";
            this.rbtnInsert.Size = new System.Drawing.Size(71, 25);
            this.rbtnInsert.TabIndex = 60;
            this.rbtnInsert.TabStop = true;
            this.rbtnInsert.Text = "Insert";
            this.rbtnInsert.UseVisualStyleBackColor = false;
            // 
            // cbFormat
            // 
            this.cbFormat.AutoSize = true;
            this.cbFormat.BackColor = System.Drawing.Color.Transparent;
            this.cbFormat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbFormat.ForeColor = System.Drawing.Color.Black;
            this.cbFormat.Location = new System.Drawing.Point(22, 54);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(77, 25);
            this.cbFormat.TabIndex = 58;
            this.cbFormat.Text = "格式化";
            this.cbFormat.UseVisualStyleBackColor = false;
            // 
            // txtSort
            // 
            this.txtSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSort.Location = new System.Drawing.Point(503, 225);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(153, 21);
            this.txtSort.TabIndex = 61;
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
            this.pictureBox2.TabIndex = 65;
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
            this.pictureBox1.TabIndex = 64;
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
            this.cboServer.TabIndex = 63;
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
            this.cboDB.TabIndex = 62;
            this.cboDB.SelectedIndexChanged += new System.EventHandler(this.cboDB_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.rbtUpdate);
            this.groupBox2.Controls.Add(this.rbtnInsert);
            this.groupBox2.Controls.Add(this.cbFormat);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(772, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 90);
            this.groupBox2.TabIndex = 66;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model";
            // 
            // panSql
            // 
            this.panSql.BackColor = System.Drawing.Color.Transparent;
            this.panSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSql.Controls.Add(this.txtSQL);
            this.panSql.Location = new System.Drawing.Point(661, 225);
            this.panSql.Name = "panSql";
            this.panSql.Size = new System.Drawing.Size(358, 260);
            this.panSql.TabIndex = 67;
            // 
            // panTableName
            // 
            this.panTableName.BackColor = System.Drawing.Color.Transparent;
            this.panTableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTableName.Controls.Add(this.lbTableName);
            this.panTableName.Location = new System.Drawing.Point(503, 249);
            this.panTableName.Name = "panTableName";
            this.panTableName.Size = new System.Drawing.Size(153, 236);
            this.panTableName.TabIndex = 68;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Image = global::Bowtech.Properties.Resources.b3;
            this.btnDelete.Location = new System.Drawing.Point(606, 168);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 50);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelete.TabIndex = 70;
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
            this.btnPlay.TabIndex = 69;
            this.btnPlay.TabStop = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.btnPlay_MouseLeave);
            // 
            // BL71_SQL_InsertUpdate
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 485);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.panTableName);
            this.Controls.Add(this.panSql);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cboServer);
            this.Controls.Add(this.cboDB);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panCol);
            this.Controls.Add(this.picClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_SQL_InsertUpdate";
            this.Text = "BL71_SQL_InsertUpdate";
            this.Load += new System.EventHandler(this.BL71_SQL_InsertUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panSql.ResumeLayout(false);
            this.panTableName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Panel panCol;
        private System.Windows.Forms.ListBox lbTableName;
        private Kevin.SyntaxTextBox.SyntaxTextBox txtSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbR0;
        private System.Windows.Forms.RadioButton rdbRi;
        private System.Windows.Forms.TextBox txtDataTable;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.RadioButton rbtUpdate;
        private System.Windows.Forms.RadioButton rbtnInsert;
        private System.Windows.Forms.CheckBox cbFormat;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.ComboBox cboDB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panSql;
        private System.Windows.Forms.Panel panTableName;
        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.PictureBox btnPlay;
    }
}