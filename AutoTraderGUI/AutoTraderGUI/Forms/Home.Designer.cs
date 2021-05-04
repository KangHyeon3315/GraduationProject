
namespace AutoTraderGUI.Forms
{
    partial class Home
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.AlgorithmInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogViewer = new System.Windows.Forms.ListView();
            this.InfoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompanyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogTextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(902, 620);
            this.splitContainer1.SplitterDistance = 158;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 620);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 143);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.AlgorithmInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LogViewer);
            this.splitContainer2.Size = new System.Drawing.Size(734, 474);
            this.splitContainer2.SplitterDistance = 340;
            this.splitContainer2.TabIndex = 0;
            // 
            // AlgorithmInfo
            // 
            this.AlgorithmInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.AlgorithmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmInfo.GridLines = true;
            this.AlgorithmInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.AlgorithmInfo.HideSelection = false;
            this.AlgorithmInfo.Location = new System.Drawing.Point(0, 0);
            this.AlgorithmInfo.Name = "AlgorithmInfo";
            this.AlgorithmInfo.Size = new System.Drawing.Size(734, 340);
            this.AlgorithmInfo.TabIndex = 9;
            this.AlgorithmInfo.UseCompatibleStateImageBehavior = false;
            this.AlgorithmInfo.View = System.Windows.Forms.View.Details;
            this.AlgorithmInfo.Resize += new System.EventHandler(this.ResizeEvent);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "알고리즘 번호";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "수익률";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "손익비";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "최대 누적 하락 수익률";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "최대 미실현 수익";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "최대 미실현 손실";
            this.columnHeader6.Width = 180;
            // 
            // LogViewer
            // 
            this.LogViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoHeader,
            this.TimeHeader,
            this.TaskHeader,
            this.CompanyHeader,
            this.LogTextHeader});
            this.LogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewer.HideSelection = false;
            this.LogViewer.Location = new System.Drawing.Point(0, 0);
            this.LogViewer.MultiSelect = false;
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.Size = new System.Drawing.Size(734, 130);
            this.LogViewer.TabIndex = 5;
            this.LogViewer.UseCompatibleStateImageBehavior = false;
            this.LogViewer.View = System.Windows.Forms.View.Details;
            // 
            // InfoHeader
            // 
            this.InfoHeader.Text = "Info";
            this.InfoHeader.Width = 41;
            // 
            // TimeHeader
            // 
            this.TimeHeader.Text = "Time";
            this.TimeHeader.Width = 120;
            // 
            // TaskHeader
            // 
            this.TaskHeader.Text = "Task";
            this.TaskHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TaskHeader.Width = 180;
            // 
            // CompanyHeader
            // 
            this.CompanyHeader.Text = "Company";
            this.CompanyHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CompanyHeader.Width = 180;
            // 
            // LogTextHeader
            // 
            this.LogTextHeader.Text = "Log";
            this.LogTextHeader.Width = 360;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(734, 134);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(317, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 128);
            this.groupBox1.TabIndex = 4;
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
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(902, 620);
            this.Resize += new System.EventHandler(this.ResizeEvent);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView AlgorithmInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView LogViewer;
        private System.Windows.Forms.ColumnHeader InfoHeader;
        private System.Windows.Forms.ColumnHeader TimeHeader;
        private System.Windows.Forms.ColumnHeader TaskHeader;
        private System.Windows.Forms.ColumnHeader CompanyHeader;
        private System.Windows.Forms.ColumnHeader LogTextHeader;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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
