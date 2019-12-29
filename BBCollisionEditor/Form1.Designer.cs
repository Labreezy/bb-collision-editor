namespace BBCollisionEditor
{
    partial class Form1
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
            this.spriteBox = new System.Windows.Forms.PictureBox();
            this.spriteList = new System.Windows.Forms.ListBox();
            this.boxList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.saveCurrentBtn = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.xlabel = new System.Windows.Forms.Label();
            this.ylabel = new System.Windows.Forms.Label();
            this.wlabel = new System.Windows.Forms.Label();
            this.hlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.spriteBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spriteBox
            // 
            this.spriteBox.BackColor = System.Drawing.Color.Black;
            this.spriteBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spriteBox.Location = new System.Drawing.Point(3, 16);
            this.spriteBox.Name = "spriteBox";
            this.spriteBox.Size = new System.Drawing.Size(845, 556);
            this.spriteBox.TabIndex = 0;
            this.spriteBox.TabStop = false;
            this.spriteBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spriteBox_MouseDown);
            this.spriteBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spriteBox_MouseMove);
            this.spriteBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spriteBox_MouseUp);
            // 
            // spriteList
            // 
            this.spriteList.FormattingEnabled = true;
            this.spriteList.Location = new System.Drawing.Point(12, 71);
            this.spriteList.Name = "spriteList";
            this.spriteList.Size = new System.Drawing.Size(163, 186);
            this.spriteList.TabIndex = 1;
            this.spriteList.SelectedIndexChanged += new System.EventHandler(this.spriteList_SelectedIndexChanged);
            // 
            // boxList
            // 
            this.boxList.FormattingEnabled = true;
            this.boxList.Location = new System.Drawing.Point(15, 263);
            this.boxList.Name = "boxList";
            this.boxList.Size = new System.Drawing.Size(163, 134);
            this.boxList.TabIndex = 2;
            this.boxList.SelectedIndexChanged += new System.EventHandler(this.boxList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveCurrentBtn
            // 
            this.saveCurrentBtn.Location = new System.Drawing.Point(38, 42);
            this.saveCurrentBtn.Name = "saveCurrentBtn";
            this.saveCurrentBtn.Size = new System.Drawing.Size(75, 23);
            this.saveCurrentBtn.TabIndex = 5;
            this.saveCurrentBtn.Text = "Save";
            this.saveCurrentBtn.UseVisualStyleBackColor = true;
            this.saveCurrentBtn.Click += new System.EventHandler(this.saveCurrentBtn_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(75, 429);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 6;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(75, 467);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 7;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            // 
            // textBoxW
            // 
            this.textBoxW.Location = new System.Drawing.Point(75, 504);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(100, 20);
            this.textBoxW.TabIndex = 8;
            this.textBoxW.TextChanged += new System.EventHandler(this.textBoxW_TextChanged);
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(75, 541);
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.Size = new System.Drawing.Size(100, 20);
            this.textBoxH.TabIndex = 9;
            this.textBoxH.TextChanged += new System.EventHandler(this.textBoxH_TextChanged);
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Location = new System.Drawing.Point(12, 429);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(57, 13);
            this.xlabel.TabIndex = 10;
            this.xlabel.Text = "X Position:";
            // 
            // ylabel
            // 
            this.ylabel.AutoSize = true;
            this.ylabel.Location = new System.Drawing.Point(12, 470);
            this.ylabel.Name = "ylabel";
            this.ylabel.Size = new System.Drawing.Size(57, 13);
            this.ylabel.TabIndex = 11;
            this.ylabel.Text = "Y Position:";
            // 
            // wlabel
            // 
            this.wlabel.AutoSize = true;
            this.wlabel.Location = new System.Drawing.Point(26, 507);
            this.wlabel.Name = "wlabel";
            this.wlabel.Size = new System.Drawing.Size(38, 13);
            this.wlabel.TabIndex = 12;
            this.wlabel.Text = "Width:";
            this.wlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // hlabel
            // 
            this.hlabel.AutoSize = true;
            this.hlabel.Location = new System.Drawing.Point(26, 544);
            this.hlabel.Name = "hlabel";
            this.hlabel.Size = new System.Drawing.Size(41, 13);
            this.hlabel.TabIndex = 13;
            this.hlabel.Text = "Height:";
            this.hlabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.spriteBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(189, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(851, 575);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.boxList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 575);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 575);
            this.Controls.Add(this.hlabel);
            this.Controls.Add(this.wlabel);
            this.Controls.Add(this.ylabel);
            this.Controls.Add(this.xlabel);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.textBoxW);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.saveCurrentBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spriteList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "BBCF Collision Editor";
            ((System.ComponentModel.ISupportInitialize)(this.spriteBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox spriteBox;
        private System.Windows.Forms.ListBox spriteList;
        private System.Windows.Forms.ListBox boxList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button saveCurrentBtn;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.TextBox textBoxH;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.Label ylabel;
        private System.Windows.Forms.Label wlabel;
        private System.Windows.Forms.Label hlabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

