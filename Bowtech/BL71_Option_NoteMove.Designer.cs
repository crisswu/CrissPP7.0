namespace Bowtech
{
    partial class BL71_Option_NoteMove
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
            this.picClose = new System.Windows.Forms.PictureBox();
            this.tvMain = new System.Windows.Forms.TreeView();
            this.cmsOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.cmsOrder.SuspendLayout();
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
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            // 
            // tvMain
            // 
            this.tvMain.BackColor = System.Drawing.Color.White;
            this.tvMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvMain.ContextMenuStrip = this.cmsOrder;
            this.tvMain.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvMain.ForeColor = System.Drawing.Color.Blue;
            this.tvMain.Location = new System.Drawing.Point(12, 12);
            this.tvMain.Name = "tvMain";
            this.tvMain.Size = new System.Drawing.Size(230, 423);
            this.tvMain.TabIndex = 3;
            this.tvMain.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterExpand);
            this.tvMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMain_AfterSelect);
            this.tvMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvMain_MouseDown);
            // 
            // cmsOrder
            // 
            this.cmsOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMove});
            this.cmsOrder.Name = "cmsOrder";
            this.cmsOrder.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiMove
            // 
            this.tsmiMove.Name = "tsmiMove";
            this.tsmiMove.Size = new System.Drawing.Size(100, 22);
            this.tsmiMove.Text = "移动";
            // 
            // BL71_Option_NoteMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Bowtech.Properties.Resources.Bl71_BlackDownFrom_smill;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(808, 447);
            this.Controls.Add(this.picClose);
            this.Controls.Add(this.tvMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BL71_Option_NoteMove";
            this.Text = "BL71_Option_NoteMove";
            this.Load += new System.EventHandler(this.BL71_Option_NoteMove_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.cmsOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.TreeView tvMain;
        private System.Windows.Forms.ContextMenuStrip cmsOrder;
        private System.Windows.Forms.ToolStripMenuItem tsmiMove;
    }
}