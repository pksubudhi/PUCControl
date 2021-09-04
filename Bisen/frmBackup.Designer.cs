namespace BisEn
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.btnCloseIn = new System.Windows.Forms.PictureBox();
            this.btnCloseOut = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.optDef = new System.Windows.Forms.RadioButton();
            this.optCustom = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 39);
            this.label2.TabIndex = 95;
            this.label2.Text = "Take Backup of your Data..";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(460, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(48, 48);
            this.btnBack.TabIndex = 100;
            this.btnBack.TabStop = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(514, 15);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(48, 48);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 99;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnCloseIn
            // 
            this.btnCloseIn.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseIn.Image = global::BisEn.Properties.Resources.CloseMove;
            this.btnCloseIn.Location = new System.Drawing.Point(568, 270);
            this.btnCloseIn.Name = "btnCloseIn";
            this.btnCloseIn.Size = new System.Drawing.Size(48, 48);
            this.btnCloseIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCloseIn.TabIndex = 98;
            this.btnCloseIn.TabStop = false;
            this.btnCloseIn.Visible = false;
            // 
            // btnCloseOut
            // 
            this.btnCloseOut.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseOut.Image = global::BisEn.Properties.Resources.CloseIcon;
            this.btnCloseOut.Location = new System.Drawing.Point(622, 270);
            this.btnCloseOut.Name = "btnCloseOut";
            this.btnCloseOut.Size = new System.Drawing.Size(48, 48);
            this.btnCloseOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCloseOut.TabIndex = 97;
            this.btnCloseOut.TabStop = false;
            this.btnCloseOut.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = global::BisEn.Properties.Resources.CloseIcon;
            this.btnClose.Location = new System.Drawing.Point(568, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 96;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(89, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 69);
            this.label1.TabIndex = 102;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Target File Name";
            // 
            // lblTarget
            // 
            this.lblTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblTarget.ForeColor = System.Drawing.Color.White;
            this.lblTarget.Location = new System.Drawing.Point(89, 232);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(461, 23);
            this.lblTarget.TabIndex = 104;
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(475, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 106;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // optDef
            // 
            this.optDef.AutoSize = true;
            this.optDef.Checked = true;
            this.optDef.Location = new System.Drawing.Point(89, 172);
            this.optDef.Name = "optDef";
            this.optDef.Size = new System.Drawing.Size(187, 17);
            this.optDef.TabIndex = 108;
            this.optDef.TabStop = true;
            this.optDef.Text = "Keep backup in the Default Folder";
            this.optDef.UseVisualStyleBackColor = true;
            // 
            // optCustom
            // 
            this.optCustom.AutoSize = true;
            this.optCustom.Location = new System.Drawing.Point(347, 172);
            this.optCustom.Name = "optCustom";
            this.optCustom.Size = new System.Drawing.Size(203, 17);
            this.optCustom.TabIndex = 109;
            this.optCustom.Text = "Take backup in a folder that I choose";
            this.optCustom.UseVisualStyleBackColor = true;
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 314);
            this.Controls.Add(this.optCustom);
            this.Controls.Add(this.optDef);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnCloseIn);
            this.Controls.Add(this.btnCloseOut);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.Green;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup...";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnBack;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.PictureBox btnCloseIn;
        private System.Windows.Forms.PictureBox btnCloseOut;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton optDef;
        private System.Windows.Forms.RadioButton optCustom;
    }
}