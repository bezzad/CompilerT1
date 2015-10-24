namespace Compiler_T1
{
    partial class AboutForm
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
            this.lnkAzerbaycan = new System.Windows.Forms.LinkLabel();
            this.lnkUnixe = new System.Windows.Forms.LinkLabel();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lnkAzerbaycan
            // 
            this.lnkAzerbaycan.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkAzerbaycan.AutoEllipsis = true;
            this.lnkAzerbaycan.AutoSize = true;
            this.lnkAzerbaycan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkAzerbaycan.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAzerbaycan.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkAzerbaycan.Location = new System.Drawing.Point(12, 230);
            this.lnkAzerbaycan.Name = "lnkAzerbaycan";
            this.lnkAzerbaycan.Size = new System.Drawing.Size(207, 33);
            this.lnkAzerbaycan.TabIndex = 0;
            this.lnkAzerbaycan.TabStop = true;
            this.lnkAzerbaycan.Text = "www.Azerbaycan.ir";
            this.lnkAzerbaycan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkAzerbaycan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAzerbaycan_LinkClicked);
            // 
            // lnkUnixe
            // 
            this.lnkUnixe.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkUnixe.AutoEllipsis = true;
            this.lnkUnixe.AutoSize = true;
            this.lnkUnixe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkUnixe.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUnixe.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkUnixe.Location = new System.Drawing.Point(358, 230);
            this.lnkUnixe.Name = "lnkUnixe";
            this.lnkUnixe.Size = new System.Drawing.Size(184, 33);
            this.lnkUnixe.TabIndex = 0;
            this.lnkUnixe.TabStop = true;
            this.lnkUnixe.Text = "www.Unixe.co.cc";
            this.lnkUnixe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkUnixe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUnixe_LinkClicked);
            // 
            // lnkEmail
            // 
            this.lnkEmail.ActiveLinkColor = System.Drawing.SystemColors.HotTrack;
            this.lnkEmail.AutoEllipsis = true;
            this.lnkEmail.AutoSize = true;
            this.lnkEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkEmail.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEmail.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkEmail.Location = new System.Drawing.Point(132, 9);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(323, 33);
            this.lnkEmail.TabIndex = 0;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "Behzad.khosravifar@Gmail.com";
            this.lnkEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Compiler_T1.Properties.Resources.Netclear;
            this.pictureBox1.Location = new System.Drawing.Point(414, 162);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Compiler_T1.Properties.Resources.Compiler_T1_2010_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(554, 272);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lnkUnixe);
            this.Controls.Add(this.lnkAzerbaycan);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Compiler T1                                                                " +
                "                                    بهزاد خسروی فر ";
            this.TopMost = true;
            this.Click += new System.EventHandler(this.AboutForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkAzerbaycan;
        private System.Windows.Forms.LinkLabel lnkUnixe;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}