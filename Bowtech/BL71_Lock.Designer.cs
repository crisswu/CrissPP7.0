namespace Bowtech
{
    partial class BL71_Lock
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
            this.btnPrv = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.txtPassWrod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bowtech.Properties.Resources.NO;
            this.picClose.Location = new System.Drawing.Point(995, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 52;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // btnPrv
            // 
            this.btnPrv.BackColor = System.Drawing.Color.Transparent;
            this.btnPrv.Image = global::Bowtech.Properties.Resources.InPrv1;
            this.btnPrv.Location = new System.Drawing.Point(672, 130);
            this.btnPrv.Name = "btnPrv";
            this.btnPrv.Size = new System.Drawing.Size(60, 60);
            this.btnPrv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPrv.TabIndex = 60;
            this.btnPrv.TabStop = false;
            this.btnPrv.Click += new System.EventHandler(this.btnPrv_Click);
            this.btnPrv.MouseEnter += new System.EventHandler(this.btnPrv_MouseEnter);
            this.btnPrv.MouseLeave += new System.EventHandler(this.btnPrv_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::Bowtech.Properties.Resources.ConvertColor;
            this.pictureBox5.Location = new System.Drawing.Point(211, 115);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(80, 80);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 59;
            this.pictureBox5.TabStop = false;
            // 
            // txtPassWrod
            // 
            // 
            // 
            // 
            this.txtPassWrod.Border.Class = "TextBoxBorder";
            this.txtPassWrod.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWrod.Location = new System.Drawing.Point(303, 139);
            this.txtPassWrod.Name = "txtPassWrod";
            this.txtPassWrod.PasswordChar = '*';
            this.txtPassWrod.Size = new System.Drawing.Size(361, 39);
            this.txtPassWrod.TabIndex = 0;
            this.txtPassWrod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassWrod_KeyDown);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(307, 197);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 21);
            this.lblTitle.TabIndex = 61;
            // 
            // BL71_Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 485);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnPrv);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.txtPassWrod);
            this.Controls.Add(this.picClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_Lock";
            this.Text = "BL71_ImportExcel";
            this.Load += new System.EventHandler(this.BL71_ImportExcel_Load);
            this.Resize += new System.EventHandler(this.BL71_Lock_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox btnPrv;
        private System.Windows.Forms.PictureBox pictureBox5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPassWrod;
        private System.Windows.Forms.Label lblTitle;
    }
}