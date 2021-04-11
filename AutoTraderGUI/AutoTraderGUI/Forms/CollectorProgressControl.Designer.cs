
namespace AutoTraderGUI.Forms
{
    partial class CollectorProgressControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CompanyCountText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CompleteCountText = new System.Windows.Forms.Label();
            this.TaskInfoText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CompanyText = new System.Windows.Forms.Label();
            this.RqCountText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CompanyCountText);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CompleteCountText);
            this.groupBox1.Controls.Add(this.TaskInfoText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CompanyText);
            this.groupBox1.Controls.Add(this.RqCountText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collector";
            // 
            // CompanyCountText
            // 
            this.CompanyCountText.AutoSize = true;
            this.CompanyCountText.Location = new System.Drawing.Point(362, 64);
            this.CompanyCountText.Name = "CompanyCountText";
            this.CompanyCountText.Size = new System.Drawing.Size(29, 12);
            this.CompanyCountText.TabIndex = 10;
            this.CompanyCountText.Text = "0000";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 89);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(402, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(352, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "TaskInfo : ";
            // 
            // CompleteCountText
            // 
            this.CompleteCountText.AutoSize = true;
            this.CompleteCountText.Location = new System.Drawing.Point(324, 64);
            this.CompleteCountText.Name = "CompleteCountText";
            this.CompleteCountText.Size = new System.Drawing.Size(29, 12);
            this.CompleteCountText.TabIndex = 8;
            this.CompleteCountText.Text = "0000";
            // 
            // TaskInfoText
            // 
            this.TaskInfoText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TaskInfoText.AutoSize = true;
            this.TaskInfoText.Location = new System.Drawing.Point(77, 35);
            this.TaskInfoText.Name = "TaskInfoText";
            this.TaskInfoText.Size = new System.Drawing.Size(35, 12);
            this.TaskInfoText.TabIndex = 2;
            this.TaskInfoText.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Progress : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "RequestsCount : ";
            // 
            // CompanyText
            // 
            this.CompanyText.AutoSize = true;
            this.CompanyText.Location = new System.Drawing.Point(84, 64);
            this.CompanyText.Name = "CompanyText";
            this.CompanyText.Size = new System.Drawing.Size(35, 12);
            this.CompanyText.TabIndex = 6;
            this.CompanyText.Text = "None";
            // 
            // RqCountText
            // 
            this.RqCountText.AutoSize = true;
            this.RqCountText.Location = new System.Drawing.Point(375, 35);
            this.RqCountText.Name = "RqCountText";
            this.RqCountText.Size = new System.Drawing.Size(11, 12);
            this.RqCountText.TabIndex = 4;
            this.RqCountText.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Company : ";
            // 
            // CollectorProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CollectorProgressControl";
            this.Size = new System.Drawing.Size(423, 136);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label CompanyCountText;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label CompleteCountText;
        public System.Windows.Forms.Label TaskInfoText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label CompanyText;
        public System.Windows.Forms.Label RqCountText;
        private System.Windows.Forms.Label label3;
    }
}
