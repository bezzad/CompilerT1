namespace Compiler_T1
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timerOpenDataSource = new System.Windows.Forms.Timer(this.components);
            this.btnScaner = new System.Windows.Forms.Button();
            this.rtxtBody = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTree = new System.Windows.Forms.Button();
            this.btnParser = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.dgvScaner = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaner)).BeginInit();
            this.SuspendLayout();
            // 
            // timerOpenDataSource
            // 
            this.timerOpenDataSource.Interval = 1;
            this.timerOpenDataSource.Tick += new System.EventHandler(this.timerOpenDataSource_Tick);
            // 
            // btnScaner
            // 
            this.btnScaner.BackgroundImage = global::Compiler_T1.Properties.Resources.search2;
            this.btnScaner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnScaner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScaner.Location = new System.Drawing.Point(8, 21);
            this.btnScaner.Name = "btnScaner";
            this.btnScaner.Size = new System.Drawing.Size(50, 49);
            this.btnScaner.TabIndex = 4;
            this.btnScaner.Text = "&Scaner";
            this.btnScaner.UseVisualStyleBackColor = true;
            this.btnScaner.Click += new System.EventHandler(this.btnScaner_Click);
            // 
            // rtxtBody
            // 
            this.rtxtBody.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtxtBody.Location = new System.Drawing.Point(12, 87);
            this.rtxtBody.Name = "rtxtBody";
            this.rtxtBody.Size = new System.Drawing.Size(320, 363);
            this.rtxtBody.TabIndex = 5;
            this.rtxtBody.Text = "";
            this.rtxtBody.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtBody_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTree);
            this.groupBox1.Controls.Add(this.btnParser);
            this.groupBox1.Controls.Add(this.btnScaner);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(178, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compile Tools";
            // 
            // btnTree
            // 
            this.btnTree.BackgroundImage = global::Compiler_T1.Properties.Resources.Netclear;
            this.btnTree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTree.Location = new System.Drawing.Point(120, 21);
            this.btnTree.Name = "btnTree";
            this.btnTree.Size = new System.Drawing.Size(50, 49);
            this.btnTree.TabIndex = 4;
            this.btnTree.Text = "&Tree";
            this.btnTree.UseVisualStyleBackColor = true;
            this.btnTree.Click += new System.EventHandler(this.btnTree_Click);
            // 
            // btnParser
            // 
            this.btnParser.BackgroundImage = global::Compiler_T1.Properties.Resources.app;
            this.btnParser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnParser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParser.Location = new System.Drawing.Point(64, 21);
            this.btnParser.Name = "btnParser";
            this.btnParser.Size = new System.Drawing.Size(50, 49);
            this.btnParser.TabIndex = 4;
            this.btnParser.Text = "&Parser";
            this.btnParser.UseVisualStyleBackColor = true;
            this.btnParser.Click += new System.EventHandler(this.btnParser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAbout);
            this.groupBox2.Controls.Add(this.btnHelp);
            this.groupBox2.Location = new System.Drawing.Point(209, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(123, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contact";
            // 
            // btnAbout
            // 
            this.btnAbout.BackgroundImage = global::Compiler_T1.Properties.Resources.LXP_Everest;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Location = new System.Drawing.Point(67, 23);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(50, 49);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "&About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImage = global::Compiler_T1.Properties.Resources.Acrobat_Reader;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelp.Location = new System.Drawing.Point(6, 23);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(50, 49);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dgvScaner
            // 
            this.dgvScaner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScaner.Location = new System.Drawing.Point(349, 10);
            this.dgvScaner.Name = "dgvScaner";
            this.dgvScaner.RowHeadersWidth = 30;
            this.dgvScaner.Size = new System.Drawing.Size(333, 440);
            this.dgvScaner.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 462);
            this.Controls.Add(this.dgvScaner);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtxtBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(700, 490);
            this.Name = "MainForm";
            this.Text = "Compiler T1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScaner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerOpenDataSource;
        private System.Windows.Forms.Button btnScaner;
        private System.Windows.Forms.RichTextBox rtxtBody;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTree;
        private System.Windows.Forms.Button btnParser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DataGridView dgvScaner;
    }
}

