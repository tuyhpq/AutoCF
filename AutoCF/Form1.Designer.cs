namespace AutoCF
{
    partial class AutoCF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCF));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnInstall = new System.Windows.Forms.Button();
            this.btnExtend = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // btnInstall
            // 
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.Location = new System.Drawing.Point(23, 21);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(79, 33);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Cài Đặt";
            this.btnInstall.UseVisualStyleBackColor = true;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // btnExtend
            // 
            this.btnExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtend.Location = new System.Drawing.Point(127, 21);
            this.btnExtend.Name = "btnExtend";
            this.btnExtend.Size = new System.Drawing.Size(79, 33);
            this.btnExtend.TabIndex = 1;
            this.btnExtend.Text = "Gia Hạn";
            this.btnExtend.UseVisualStyleBackColor = true;
            this.btnExtend.Click += new System.EventHandler(this.btnExtend_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(20, 65);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(90, 13);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Đang tải dữ liệu...";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(84, 89);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(90, 13);
            this.labelAuthor.TabIndex = 4;
            this.labelAuthor.Text = "Đang tải dữ liệu...";
            // 
            // timerTime
            // 
            this.timerTime.Interval = 30000;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // AutoCF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 111);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.btnExtend);
            this.Controls.Add(this.btnInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AutoCF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto CF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoCF_FormClosing);
            this.Load += new System.EventHandler(this.AutoCF_Load);
            this.Resize += new System.EventHandler(this.AutoCF_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.Button btnExtend;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Timer timerTime;
    }
}

