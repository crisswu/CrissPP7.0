namespace Bowtech
{
    partial class BL71_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BL71_Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panBody = new System.Windows.Forms.Panel();
            this.lblEditDate = new System.Windows.Forms.Label();
            this.btnNoteSave = new System.Windows.Forms.PictureBox();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.panHead = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.picIEAddress = new System.Windows.Forms.PictureBox();
            this.picCation = new System.Windows.Forms.PictureBox();
            this.picHTML = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblNoteCount = new System.Windows.Forms.Label();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.picSystem = new System.Windows.Forms.PictureBox();
            this.picSQL_IU = new System.Windows.Forms.PictureBox();
            this.picSQL_Query = new System.Windows.Forms.PictureBox();
            this.picSQL_SELECT = new System.Windows.Forms.PictureBox();
            this.picEXCEL2 = new System.Windows.Forms.PictureBox();
            this.picEXCEL1 = new System.Windows.Forms.PictureBox();
            this.picMainQ = new System.Windows.Forms.PictureBox();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.picZXH = new System.Windows.Forms.PictureBox();
            this.picCLZ = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoteSave)).BeginInit();
            this.panHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIEAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHTML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_IU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_Query)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_SELECT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEXCEL2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEXCEL1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZXH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCLZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "Criss++";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panBody
            // 
            this.panBody.AllowDrop = true;
            this.panBody.BackColor = System.Drawing.Color.Transparent;
            this.panBody.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDown;
            this.panBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panBody.Controls.Add(this.lblEditDate);
            this.panBody.Controls.Add(this.btnNoteSave);
            this.panBody.Controls.Add(this.txtNote);
            this.panBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBody.Location = new System.Drawing.Point(0, 115);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(1024, 485);
            this.panBody.TabIndex = 1;
            // 
            // lblEditDate
            // 
            this.lblEditDate.AutoSize = true;
            this.lblEditDate.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEditDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEditDate.Location = new System.Drawing.Point(13, 9);
            this.lblEditDate.Name = "lblEditDate";
            this.lblEditDate.Size = new System.Drawing.Size(69, 19);
            this.lblEditDate.TabIndex = 11;
            this.lblEditDate.Text = "修改日期";
            // 
            // btnNoteSave
            // 
            this.btnNoteSave.Image = global::Bowtech.Properties.Resources.man1;
            this.btnNoteSave.Location = new System.Drawing.Point(410, 371);
            this.btnNoteSave.Name = "btnNoteSave";
            this.btnNoteSave.Size = new System.Drawing.Size(100, 100);
            this.btnNoteSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNoteSave.TabIndex = 1;
            this.btnNoteSave.TabStop = false;
            this.btnNoteSave.Click += new System.EventHandler(this.btnNoteSave_Click);
            this.btnNoteSave.MouseEnter += new System.EventHandler(this.btnNoteSave_MouseEnter);
            this.btnNoteSave.MouseLeave += new System.EventHandler(this.btnNoteSave_MouseLeave);
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNote.Location = new System.Drawing.Point(13, 33);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(390, 438);
            this.txtNote.TabIndex = 0;
            this.txtNote.Text = "";
            // 
            // panHead
            // 
            this.panHead.BackColor = System.Drawing.Color.Transparent;
            this.panHead.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_Title;
            this.panHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panHead.Controls.Add(this.lblMsg);
            this.panHead.Controls.Add(this.picIEAddress);
            this.panHead.Controls.Add(this.picCation);
            this.panHead.Controls.Add(this.picHTML);
            this.panHead.Controls.Add(this.lblVersion);
            this.panHead.Controls.Add(this.lblNoteCount);
            this.panHead.Controls.Add(this.picDown);
            this.panHead.Controls.Add(this.picSystem);
            this.panHead.Controls.Add(this.picSQL_IU);
            this.panHead.Controls.Add(this.picSQL_Query);
            this.panHead.Controls.Add(this.picSQL_SELECT);
            this.panHead.Controls.Add(this.picEXCEL2);
            this.panHead.Controls.Add(this.picEXCEL1);
            this.panHead.Controls.Add(this.picMainQ);
            this.panHead.Controls.Add(this.picMain);
            this.panHead.Controls.Add(this.picZXH);
            this.panHead.Controls.Add(this.picCLZ);
            this.panHead.Controls.Add(this.pictureBox1);
            this.panHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHead.Location = new System.Drawing.Point(0, 0);
            this.panHead.Name = "panHead";
            this.panHead.Size = new System.Drawing.Size(1024, 115);
            this.panHead.TabIndex = 0;
            this.panHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseDown);
            this.panHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseMove);
            this.panHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panHead_MouseUp);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Yellow;
            this.lblMsg.Location = new System.Drawing.Point(121, 8);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(74, 21);
            this.lblMsg.TabIndex = 11;
            this.lblMsg.Text = "提示信息";
            // 
            // picIEAddress
            // 
            this.picIEAddress.Image = global::Bowtech.Properties.Resources._13905;
            this.picIEAddress.Location = new System.Drawing.Point(741, 34);
            this.picIEAddress.Name = "picIEAddress";
            this.picIEAddress.Size = new System.Drawing.Size(70, 70);
            this.picIEAddress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIEAddress.TabIndex = 10;
            this.picIEAddress.TabStop = false;
            this.picIEAddress.Click += new System.EventHandler(this.picIEAddress_Click);
            this.picIEAddress.MouseEnter += new System.EventHandler(this.picIEAddress_MouseEnter);
            this.picIEAddress.MouseLeave += new System.EventHandler(this.picIEAddress_MouseLeave);
            // 
            // picCation
            // 
            this.picCation.Image = global::Bowtech.Properties.Resources.Caption2;
            this.picCation.Location = new System.Drawing.Point(253, 39);
            this.picCation.Name = "picCation";
            this.picCation.Size = new System.Drawing.Size(65, 65);
            this.picCation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCation.TabIndex = 9;
            this.picCation.TabStop = false;
            this.picCation.Click += new System.EventHandler(this.picCation_Click);
            this.picCation.MouseEnter += new System.EventHandler(this.picCation_MouseEnter);
            this.picCation.MouseLeave += new System.EventHandler(this.picCation_MouseLeave);
            // 
            // picHTML
            // 
            this.picHTML.Image = global::Bowtech.Properties.Resources.html51;
            this.picHTML.Location = new System.Drawing.Point(673, 34);
            this.picHTML.Name = "picHTML";
            this.picHTML.Size = new System.Drawing.Size(70, 70);
            this.picHTML.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHTML.TabIndex = 8;
            this.picHTML.TabStop = false;
            this.picHTML.Click += new System.EventHandler(this.picHTML_Click);
            this.picHTML.MouseEnter += new System.EventHandler(this.picHTML_MouseEnter);
            this.picHTML.MouseLeave += new System.EventHandler(this.picHTML_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.Location = new System.Drawing.Point(768, 8);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(65, 19);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "版本说明";
            this.lblVersion.TextChanged += new System.EventHandler(this.lblVersion_TextChanged);
            this.lblVersion.DoubleClick += new System.EventHandler(this.lblVersion_DoubleClick);
            this.lblVersion.MouseEnter += new System.EventHandler(this.lblVersion_MouseEnter);
            this.lblVersion.MouseLeave += new System.EventHandler(this.lblVersion_MouseLeave);
            // 
            // lblNoteCount
            // 
            this.lblNoteCount.AutoSize = true;
            this.lblNoteCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNoteCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNoteCount.Location = new System.Drawing.Point(841, 8);
            this.lblNoteCount.Name = "lblNoteCount";
            this.lblNoteCount.Size = new System.Drawing.Size(92, 20);
            this.lblNoteCount.TabIndex = 7;
            this.lblNoteCount.Text = "Note:1000";
            // 
            // picDown
            // 
            this.picDown.Image = ((System.Drawing.Image)(resources.GetObject("picDown.Image")));
            this.picDown.Location = new System.Drawing.Point(933, 1);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(30, 30);
            this.picDown.TabIndex = 6;
            this.picDown.TabStop = false;
            this.picDown.Click += new System.EventHandler(this.picDown_Click);
            this.picDown.MouseEnter += new System.EventHandler(this.picDown_MouseEnter);
            this.picDown.MouseLeave += new System.EventHandler(this.picDown_MouseLeave);
            // 
            // picSystem
            // 
            this.picSystem.Image = global::Bowtech.Properties.Resources.Option1;
            this.picSystem.Location = new System.Drawing.Point(815, 38);
            this.picSystem.Name = "picSystem";
            this.picSystem.Size = new System.Drawing.Size(65, 65);
            this.picSystem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSystem.TabIndex = 5;
            this.picSystem.TabStop = false;
            this.picSystem.Click += new System.EventHandler(this.picSystem_Click);
            this.picSystem.MouseEnter += new System.EventHandler(this.picSystem_MouseHover);
            this.picSystem.MouseLeave += new System.EventHandler(this.picSystem_MouseLeave);
            // 
            // picSQL_IU
            // 
            this.picSQL_IU.Image = global::Bowtech.Properties.Resources.db1;
            this.picSQL_IU.Location = new System.Drawing.Point(606, 35);
            this.picSQL_IU.Name = "picSQL_IU";
            this.picSQL_IU.Size = new System.Drawing.Size(70, 70);
            this.picSQL_IU.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSQL_IU.TabIndex = 5;
            this.picSQL_IU.TabStop = false;
            this.picSQL_IU.Click += new System.EventHandler(this.picSQL_IU_Click);
            this.picSQL_IU.MouseEnter += new System.EventHandler(this.picSQL_IU_MouseHover);
            this.picSQL_IU.MouseLeave += new System.EventHandler(this.picSQL_IU_MouseLeave);
            // 
            // picSQL_Query
            // 
            this.picSQL_Query.Image = global::Bowtech.Properties.Resources.db3;
            this.picSQL_Query.Location = new System.Drawing.Point(538, 35);
            this.picSQL_Query.Name = "picSQL_Query";
            this.picSQL_Query.Size = new System.Drawing.Size(70, 70);
            this.picSQL_Query.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSQL_Query.TabIndex = 5;
            this.picSQL_Query.TabStop = false;
            this.picSQL_Query.Click += new System.EventHandler(this.picSQL_Query_Click);
            this.picSQL_Query.MouseEnter += new System.EventHandler(this.picSQL_Query_MouseHover);
            this.picSQL_Query.MouseLeave += new System.EventHandler(this.picSQL_Query_MouseLeave);
            // 
            // picSQL_SELECT
            // 
            this.picSQL_SELECT.Image = global::Bowtech.Properties.Resources.db2;
            this.picSQL_SELECT.Location = new System.Drawing.Point(468, 36);
            this.picSQL_SELECT.Name = "picSQL_SELECT";
            this.picSQL_SELECT.Size = new System.Drawing.Size(70, 70);
            this.picSQL_SELECT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSQL_SELECT.TabIndex = 5;
            this.picSQL_SELECT.TabStop = false;
            this.picSQL_SELECT.Click += new System.EventHandler(this.picSQL_SELECT_Click);
            this.picSQL_SELECT.MouseEnter += new System.EventHandler(this.picSQL_SELECT_MouseHover);
            this.picSQL_SELECT.MouseLeave += new System.EventHandler(this.picSQL_SELECT_MouseLeave);
            // 
            // picEXCEL2
            // 
            this.picEXCEL2.Image = global::Bowtech.Properties.Resources.Excel1;
            this.picEXCEL2.Location = new System.Drawing.Point(395, 39);
            this.picEXCEL2.Name = "picEXCEL2";
            this.picEXCEL2.Size = new System.Drawing.Size(65, 65);
            this.picEXCEL2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEXCEL2.TabIndex = 5;
            this.picEXCEL2.TabStop = false;
            this.picEXCEL2.Click += new System.EventHandler(this.picEXCEL2_Click);
            this.picEXCEL2.MouseEnter += new System.EventHandler(this.picEXCEL2_MouseHover);
            this.picEXCEL2.MouseLeave += new System.EventHandler(this.picEXCEL2_MouseLeave);
            // 
            // picEXCEL1
            // 
            this.picEXCEL1.Image = global::Bowtech.Properties.Resources.Excel1;
            this.picEXCEL1.Location = new System.Drawing.Point(324, 39);
            this.picEXCEL1.Name = "picEXCEL1";
            this.picEXCEL1.Size = new System.Drawing.Size(65, 65);
            this.picEXCEL1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEXCEL1.TabIndex = 5;
            this.picEXCEL1.TabStop = false;
            this.picEXCEL1.Click += new System.EventHandler(this.picEXCEL1_Click);
            this.picEXCEL1.MouseEnter += new System.EventHandler(this.picEXCEL1_MouseHover);
            this.picEXCEL1.MouseLeave += new System.EventHandler(this.picEXCEL1_MouseLeave);
            // 
            // picMainQ
            // 
            this.picMainQ.Image = global::Bowtech.Properties.Resources.Iron4;
            this.picMainQ.Location = new System.Drawing.Point(186, 42);
            this.picMainQ.Name = "picMainQ";
            this.picMainQ.Size = new System.Drawing.Size(60, 60);
            this.picMainQ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMainQ.TabIndex = 4;
            this.picMainQ.TabStop = false;
            this.picMainQ.Click += new System.EventHandler(this.picMainQ_Click);
            this.picMainQ.MouseEnter += new System.EventHandler(this.picMainQ_MouseHover);
            this.picMainQ.MouseLeave += new System.EventHandler(this.picMainQ_MouseLeave);
            // 
            // picMain
            // 
            this.picMain.Image = global::Bowtech.Properties.Resources.Iron2;
            this.picMain.InitialImage = null;
            this.picMain.Location = new System.Drawing.Point(118, 40);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(65, 65);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMain.TabIndex = 3;
            this.picMain.TabStop = false;
            this.picMain.Click += new System.EventHandler(this.picMain_Click);
            this.picMain.MouseEnter += new System.EventHandler(this.picMain_MouseHover);
            this.picMain.MouseLeave += new System.EventHandler(this.picMain_MouseLeave);
            // 
            // picZXH
            // 
            this.picZXH.Image = global::Bowtech.Properties.Resources.ZXHLEVE;
            this.picZXH.Location = new System.Drawing.Point(963, 1);
            this.picZXH.Name = "picZXH";
            this.picZXH.Size = new System.Drawing.Size(30, 30);
            this.picZXH.TabIndex = 2;
            this.picZXH.TabStop = false;
            this.picZXH.Click += new System.EventHandler(this.picZXH_Click);
            this.picZXH.MouseEnter += new System.EventHandler(this.picZXH_MouseHover);
            this.picZXH.MouseLeave += new System.EventHandler(this.picZXH_MouseLeave);
            // 
            // picCLZ
            // 
            this.picCLZ.Image = ((System.Drawing.Image)(resources.GetObject("picCLZ.Image")));
            this.picCLZ.Location = new System.Drawing.Point(993, 1);
            this.picCLZ.Name = "picCLZ";
            this.picCLZ.Size = new System.Drawing.Size(30, 30);
            this.picCLZ.TabIndex = 1;
            this.picCLZ.TabStop = false;
            this.picCLZ.Click += new System.EventHandler(this.picCLZ_Click);
            this.picCLZ.MouseEnter += new System.EventHandler(this.picCLZ_MouseHover);
            this.picCLZ.MouseLeave += new System.EventHandler(this.picCLZ_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bowtech.Properties.Resources.MyNewHead;
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BL71_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.panBody);
            this.Controls.Add(this.panHead);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BL71_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Criss++";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BL71_Main_FormClosed);
            this.Load += new System.EventHandler(this.BL71_Main_Load);
            this.panBody.ResumeLayout(false);
            this.panBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNoteSave)).EndInit();
            this.panHead.ResumeLayout(false);
            this.panHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIEAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHTML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_IU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_Query)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSQL_SELECT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEXCEL2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEXCEL1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMainQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZXH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCLZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panHead;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCLZ;
        private System.Windows.Forms.PictureBox picZXH;
        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.PictureBox picMainQ;
        private System.Windows.Forms.PictureBox picSQL_Query;
        private System.Windows.Forms.PictureBox picSQL_SELECT;
        private System.Windows.Forms.PictureBox picEXCEL2;
        private System.Windows.Forms.PictureBox picEXCEL1;
        private System.Windows.Forms.PictureBox picSystem;
        private System.Windows.Forms.PictureBox picSQL_IU;
        private System.Windows.Forms.PictureBox picDown;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lblNoteCount;
        private System.Windows.Forms.PictureBox picHTML;
        private System.Windows.Forms.PictureBox picCation;
        public System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.PictureBox picIEAddress;
        private System.Windows.Forms.Label lblMsg;
        public System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.PictureBox btnNoteSave;
        private System.Windows.Forms.Label lblEditDate;
    }
}