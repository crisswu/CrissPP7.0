namespace Bowtech
{
    partial class BL71_Option_NoteVisble
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
            this.tvMain = new System.Windows.Forms.TreeView();
            this.btnVisble = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVisble)).BeginInit();
            this.SuspendLayout();
            // 
            // picClose
            // 
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Bowtech.Properties.Resources.NO;
            this.picClose.Location = new System.Drawing.Point(779, 1);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(28, 28);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // tvMain
            // 
            this.tvMain.BackColor = System.Drawing.Color.White;
            this.tvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvMain.CheckBoxes = true;
            this.tvMain.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvMain.ForeColor = System.Drawing.Color.Blue;
            this.tvMain.Location = new System.Drawing.Point(12, 12);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(234, 419);
            this.tvMain.TabIndex = 19;
            // 
            // btnVisble
            // 
            this.btnVisble.BackColor = System.Drawing.Color.Transparent;
            this.btnVisble.Image = global::Bowtech.Properties.Resources.b3;
            this.btnVisble.Location = new System.Drawing.Point(262, 381);
            this.btnVisble.Name = "btnVisble";
            this.btnVisble.Size = new System.Drawing.Size(50, 50);
            this.btnVisble.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnVisble.TabIndex = 18;
            this.btnVisble.TabStop = false;
            this.btnVisble.Click += new System.EventHandler(this.btnVisble_Click);
            this.btnVisble.MouseEnter += new System.EventHandler(this.btnVisble_MouseEnter);
            this.btnVisble.MouseLeave += new System.EventHandler(this.btnVisble_MouseLeave);
            // 
            // BL71_Option_NoteVisble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom_smill;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 447);
            this.Controls.Add(this.tvMain);
            this.Controls.Add(this.btnVisble);
            this.Controls.Add(this.picClose);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_Option_NoteVisble";
            this.Text = "BL71_Option_NoteVisble";
            this.Load += new System.EventHandler(this.BL71_Option_NoteVisble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVisble)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.PictureBox btnVisble;
    }
}