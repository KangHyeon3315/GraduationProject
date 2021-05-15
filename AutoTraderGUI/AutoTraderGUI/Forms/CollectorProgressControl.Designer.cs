
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
            this.InfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RequestsCountPanel = new System.Windows.Forms.TableLayoutPanel();
            this.RqCountText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TargetPanel = new System.Windows.Forms.TableLayoutPanel();
            this.CompanyText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TaskInfoText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainTaskPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.TitleText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.CompanyCountText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CompleteCountText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.InfoPanel.SuspendLayout();
            this.RequestsCountPanel.SuspendLayout();
            this.TargetPanel.SuspendLayout();
            this.TaskPanel.SuspendLayout();
            this.MainTaskPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoPanel
            // 
            this.InfoPanel.ColumnCount = 2;
            this.InfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.InfoPanel.Controls.Add(this.RequestsCountPanel, 1, 1);
            this.InfoPanel.Controls.Add(this.TargetPanel, 0, 1);
            this.InfoPanel.Controls.Add(this.TaskPanel, 1, 0);
            this.InfoPanel.Controls.Add(this.MainTaskPanel, 0, 0);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.RowCount = 2;
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InfoPanel.Size = new System.Drawing.Size(1054, 100);
            this.InfoPanel.TabIndex = 6;
            // 
            // RequestsCountPanel
            // 
            this.RequestsCountPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.RequestsCountPanel.ColumnCount = 2;
            this.RequestsCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RequestsCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RequestsCountPanel.Controls.Add(this.RqCountText, 0, 0);
            this.RequestsCountPanel.Controls.Add(this.label2, 0, 0);
            this.RequestsCountPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestsCountPanel.Location = new System.Drawing.Point(527, 50);
            this.RequestsCountPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RequestsCountPanel.Name = "RequestsCountPanel";
            this.RequestsCountPanel.RowCount = 1;
            this.RequestsCountPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RequestsCountPanel.Size = new System.Drawing.Size(527, 50);
            this.RequestsCountPanel.TabIndex = 3;
            // 
            // RqCountText
            // 
            this.RqCountText.AutoSize = true;
            this.RqCountText.BackColor = System.Drawing.SystemColors.Window;
            this.RqCountText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RqCountText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.RqCountText.Location = new System.Drawing.Point(263, 0);
            this.RqCountText.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.RqCountText.Name = "RqCountText";
            this.RqCountText.Size = new System.Drawing.Size(263, 49);
            this.RqCountText.TabIndex = 5;
            this.RqCountText.Text = "0";
            this.RqCountText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label2.Location = new System.Drawing.Point(1, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 49);
            this.label2.TabIndex = 4;
            this.label2.Text = "요청 횟수";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TargetPanel
            // 
            this.TargetPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.TargetPanel.ColumnCount = 2;
            this.TargetPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TargetPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TargetPanel.Controls.Add(this.CompanyText, 0, 0);
            this.TargetPanel.Controls.Add(this.label3, 0, 0);
            this.TargetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TargetPanel.Location = new System.Drawing.Point(0, 50);
            this.TargetPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TargetPanel.Name = "TargetPanel";
            this.TargetPanel.RowCount = 1;
            this.TargetPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TargetPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TargetPanel.Size = new System.Drawing.Size(527, 50);
            this.TargetPanel.TabIndex = 2;
            // 
            // CompanyText
            // 
            this.CompanyText.AutoSize = true;
            this.CompanyText.BackColor = System.Drawing.SystemColors.Window;
            this.CompanyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.CompanyText.Location = new System.Drawing.Point(263, 0);
            this.CompanyText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.CompanyText.Name = "CompanyText";
            this.CompanyText.Size = new System.Drawing.Size(264, 49);
            this.CompanyText.TabIndex = 7;
            this.CompanyText.Text = "None";
            this.CompanyText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.Location = new System.Drawing.Point(1, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(261, 49);
            this.label3.TabIndex = 6;
            this.label3.Text = "대상 : ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TaskPanel
            // 
            this.TaskPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.TaskPanel.ColumnCount = 2;
            this.TaskPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaskPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaskPanel.Controls.Add(this.TaskInfoText, 0, 0);
            this.TaskPanel.Controls.Add(this.label1, 0, 0);
            this.TaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskPanel.Location = new System.Drawing.Point(527, 0);
            this.TaskPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TaskPanel.Name = "TaskPanel";
            this.TaskPanel.RowCount = 1;
            this.TaskPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TaskPanel.Size = new System.Drawing.Size(527, 50);
            this.TaskPanel.TabIndex = 1;
            // 
            // TaskInfoText
            // 
            this.TaskInfoText.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TaskInfoText.AutoSize = true;
            this.TaskInfoText.BackColor = System.Drawing.SystemColors.Window;
            this.TaskInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskInfoText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.TaskInfoText.Location = new System.Drawing.Point(263, 1);
            this.TaskInfoText.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.TaskInfoText.Name = "TaskInfoText";
            this.TaskInfoText.Size = new System.Drawing.Size(263, 48);
            this.TaskInfoText.TabIndex = 3;
            this.TaskInfoText.Text = "None";
            this.TaskInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(1, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "작업 단계 : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainTaskPanel
            // 
            this.MainTaskPanel.BackColor = System.Drawing.SystemColors.ControlText;
            this.MainTaskPanel.ColumnCount = 2;
            this.MainTaskPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTaskPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTaskPanel.Controls.Add(this.label5, 0, 0);
            this.MainTaskPanel.Controls.Add(this.TitleText, 1, 0);
            this.MainTaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTaskPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTaskPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainTaskPanel.Name = "MainTaskPanel";
            this.MainTaskPanel.RowCount = 1;
            this.MainTaskPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTaskPanel.Size = new System.Drawing.Size(527, 50);
            this.MainTaskPanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.Location = new System.Drawing.Point(1, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(261, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "현재 실행중인 작업 : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.BackColor = System.Drawing.SystemColors.Window;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.TitleText.Location = new System.Drawing.Point(263, 1);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(264, 48);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "None";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressPanel);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 34);
            this.panel1.TabIndex = 7;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.CompanyCountText);
            this.progressPanel.Controls.Add(this.label6);
            this.progressPanel.Controls.Add(this.CompleteCountText);
            this.progressPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.progressPanel.Location = new System.Drawing.Point(958, 0);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(96, 34);
            this.progressPanel.TabIndex = 9;
            // 
            // CompanyCountText
            // 
            this.CompanyCountText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyCountText.AutoSize = true;
            this.CompanyCountText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.CompanyCountText.Location = new System.Drawing.Point(50, 7);
            this.CompanyCountText.Name = "CompanyCountText";
            this.CompanyCountText.Size = new System.Drawing.Size(46, 21);
            this.CompanyCountText.TabIndex = 16;
            this.CompanyCountText.Text = "0000";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.Location = new System.Drawing.Point(40, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "/";
            // 
            // CompleteCountText
            // 
            this.CompleteCountText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompleteCountText.AutoSize = true;
            this.CompleteCountText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.CompleteCountText.Location = new System.Drawing.Point(0, 8);
            this.CompleteCountText.Name = "CompleteCountText";
            this.CompleteCountText.Size = new System.Drawing.Size(46, 21);
            this.CompleteCountText.TabIndex = 14;
            this.CompleteCountText.Text = "0000";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 6);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(952, 24);
            this.progressBar1.TabIndex = 8;
            // 
            // CollectorProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InfoPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CollectorProgressControl";
            this.Size = new System.Drawing.Size(1054, 134);
            this.InfoPanel.ResumeLayout(false);
            this.RequestsCountPanel.ResumeLayout(false);
            this.RequestsCountPanel.PerformLayout();
            this.TargetPanel.ResumeLayout(false);
            this.TargetPanel.PerformLayout();
            this.TaskPanel.ResumeLayout(false);
            this.TaskPanel.PerformLayout();
            this.MainTaskPanel.ResumeLayout(false);
            this.MainTaskPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel InfoPanel;
        private System.Windows.Forms.TableLayoutPanel RequestsCountPanel;
        public System.Windows.Forms.Label RqCountText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TargetPanel;
        public System.Windows.Forms.Label CompanyText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel TaskPanel;
        public System.Windows.Forms.Label TaskInfoText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel MainTaskPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel progressPanel;
        public System.Windows.Forms.Label CompanyCountText;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label CompleteCountText;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}
