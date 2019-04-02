namespace SignStatistics
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.signTableButton = new System.Windows.Forms.Button();
            this.allMemberTableButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.signTableFileNameTxb = new System.Windows.Forms.TextBox();
            this.allMemberTableFileNameTxb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signTableButton
            // 
            this.signTableButton.Location = new System.Drawing.Point(348, 36);
            this.signTableButton.Name = "signTableButton";
            this.signTableButton.Size = new System.Drawing.Size(75, 23);
            this.signTableButton.TabIndex = 0;
            this.signTableButton.Text = "签到表";
            this.signTableButton.UseVisualStyleBackColor = true;
            this.signTableButton.Click += new System.EventHandler(this.signTableButton_Click);
            // 
            // allMemberTableButton
            // 
            this.allMemberTableButton.Location = new System.Drawing.Point(348, 68);
            this.allMemberTableButton.Name = "allMemberTableButton";
            this.allMemberTableButton.Size = new System.Drawing.Size(75, 23);
            this.allMemberTableButton.TabIndex = 1;
            this.allMemberTableButton.Text = "全部成员";
            this.allMemberTableButton.UseVisualStyleBackColor = true;
            this.allMemberTableButton.Click += new System.EventHandler(this.allMemberTableButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(81, 135);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "开始";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // signTableFileNameTxb
            // 
            this.signTableFileNameTxb.Enabled = false;
            this.signTableFileNameTxb.Location = new System.Drawing.Point(81, 38);
            this.signTableFileNameTxb.Name = "signTableFileNameTxb";
            this.signTableFileNameTxb.Size = new System.Drawing.Size(251, 21);
            this.signTableFileNameTxb.TabIndex = 3;
            // 
            // allMemberTableFileNameTxb
            // 
            this.allMemberTableFileNameTxb.Enabled = false;
            this.allMemberTableFileNameTxb.Location = new System.Drawing.Point(81, 68);
            this.allMemberTableFileNameTxb.Name = "allMemberTableFileNameTxb";
            this.allMemberTableFileNameTxb.Size = new System.Drawing.Size(251, 21);
            this.allMemberTableFileNameTxb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "签到表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "全部成员";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(81, 103);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(342, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "进度";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 170);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.allMemberTableFileNameTxb);
            this.Controls.Add(this.signTableFileNameTxb);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.allMemberTableButton);
            this.Controls.Add(this.signTableButton);
            this.Name = "Form1";
            this.Text = "签到表生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button signTableButton;
        private System.Windows.Forms.Button allMemberTableButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox signTableFileNameTxb;
        private System.Windows.Forms.TextBox allMemberTableFileNameTxb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
    }
}

