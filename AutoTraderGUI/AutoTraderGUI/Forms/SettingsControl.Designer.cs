
namespace AutoTraderGUI.Forms
{
    partial class SettingsControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Apply = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.BasicLayout = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DBPW = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DBID = new System.Windows.Forms.TextBox();
            this.DBPort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DBIP = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DartCollectorSearchButton = new System.Windows.Forms.Button();
            this.APICollectorSartchButton = new System.Windows.Forms.Button();
            this.InterpreterSearchButton = new System.Windows.Forms.Button();
            this.DartAPI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RequestsInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxRequestsCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DartCollectorPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.APICollectorPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InterpreterPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2.SuspendLayout();
            this.BasicLayout.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Apply, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Cancelbutton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(708, 633);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 34);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Apply
            // 
            this.Apply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Apply.Location = new System.Drawing.Point(3, 3);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(94, 28);
            this.Apply.TabIndex = 0;
            this.Apply.Text = "적용";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.ApplicationButtonClick);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancelbutton.Location = new System.Drawing.Point(103, 3);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(94, 28);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "취소";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancel);
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 1;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.Controls.Add(this.groupBox2, 0, 1);
            this.BasicLayout.Controls.Add(this.groupBox1, 0, 0);
            this.BasicLayout.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.BasicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicLayout.Name = "BasicLayout";
            this.BasicLayout.RowCount = 4;
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 269F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicLayout.Size = new System.Drawing.Size(911, 670);
            this.BasicLayout.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DBPW);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.DBID);
            this.groupBox2.Controls.Add(this.DBPort);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.DBIP);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox2.Location = new System.Drawing.Point(3, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(812, 165);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database 설정";
            // 
            // DBPW
            // 
            this.DBPW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBPW.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DBPW.Location = new System.Drawing.Point(161, 123);
            this.DBPW.Name = "DBPW";
            this.DBPW.Size = new System.Drawing.Size(645, 29);
            this.DBPW.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label9.Location = new System.Drawing.Point(8, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "DB PW";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label10.Location = new System.Drawing.Point(8, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 21);
            this.label10.TabIndex = 16;
            this.label10.Text = "DB ID";
            // 
            // DBID
            // 
            this.DBID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBID.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DBID.Location = new System.Drawing.Point(161, 88);
            this.DBID.Name = "DBID";
            this.DBID.Size = new System.Drawing.Size(645, 29);
            this.DBID.TabIndex = 17;
            // 
            // DBPort
            // 
            this.DBPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBPort.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DBPort.Location = new System.Drawing.Point(161, 53);
            this.DBPort.Name = "DBPort";
            this.DBPort.Size = new System.Drawing.Size(645, 29);
            this.DBPort.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label7.Location = new System.Drawing.Point(9, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "DB Port";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label8.Location = new System.Drawing.Point(9, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "DB IP";
            // 
            // DBIP
            // 
            this.DBIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DBIP.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DBIP.Location = new System.Drawing.Point(161, 18);
            this.DBIP.Name = "DBIP";
            this.DBIP.Size = new System.Drawing.Size(645, 29);
            this.DBIP.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DartCollectorSearchButton);
            this.groupBox1.Controls.Add(this.APICollectorSartchButton);
            this.groupBox1.Controls.Add(this.InterpreterSearchButton);
            this.groupBox1.Controls.Add(this.DartAPI);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.RequestsInterval);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.MaxRequestsCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DartCollectorPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.APICollectorPath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.InterpreterPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 254);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collector 설정";
            // 
            // DartCollectorSearchButton
            // 
            this.DartCollectorSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DartCollectorSearchButton.Location = new System.Drawing.Point(722, 97);
            this.DartCollectorSearchButton.Name = "DartCollectorSearchButton";
            this.DartCollectorSearchButton.Size = new System.Drawing.Size(84, 29);
            this.DartCollectorSearchButton.TabIndex = 14;
            this.DartCollectorSearchButton.Text = "찾아보기";
            this.DartCollectorSearchButton.UseVisualStyleBackColor = true;
            this.DartCollectorSearchButton.Click += new System.EventHandler(this.DartCollectorSearch);
            // 
            // APICollectorSartchButton
            // 
            this.APICollectorSartchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.APICollectorSartchButton.Location = new System.Drawing.Point(722, 63);
            this.APICollectorSartchButton.Name = "APICollectorSartchButton";
            this.APICollectorSartchButton.Size = new System.Drawing.Size(84, 29);
            this.APICollectorSartchButton.TabIndex = 13;
            this.APICollectorSartchButton.Text = "찾아보기";
            this.APICollectorSartchButton.UseVisualStyleBackColor = true;
            this.APICollectorSartchButton.Click += new System.EventHandler(this.APICollectorSearch);
            // 
            // InterpreterSearchButton
            // 
            this.InterpreterSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InterpreterSearchButton.Location = new System.Drawing.Point(722, 27);
            this.InterpreterSearchButton.Name = "InterpreterSearchButton";
            this.InterpreterSearchButton.Size = new System.Drawing.Size(84, 29);
            this.InterpreterSearchButton.TabIndex = 12;
            this.InterpreterSearchButton.Text = "찾아보기";
            this.InterpreterSearchButton.UseVisualStyleBackColor = true;
            this.InterpreterSearchButton.Click += new System.EventHandler(this.InterpreterSearch);
            // 
            // DartAPI
            // 
            this.DartAPI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DartAPI.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DartAPI.Location = new System.Drawing.Point(161, 202);
            this.DartAPI.Name = "DartAPI";
            this.DartAPI.Size = new System.Drawing.Size(645, 29);
            this.DartAPI.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.Location = new System.Drawing.Point(9, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dart API Key";
            // 
            // RequestsInterval
            // 
            this.RequestsInterval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestsInterval.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.RequestsInterval.Location = new System.Drawing.Point(161, 167);
            this.RequestsInterval.Name = "RequestsInterval";
            this.RequestsInterval.Size = new System.Drawing.Size(645, 29);
            this.RequestsInterval.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.Location = new System.Drawing.Point(9, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "호출 간격";
            // 
            // MaxRequestsCount
            // 
            this.MaxRequestsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxRequestsCount.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MaxRequestsCount.Location = new System.Drawing.Point(161, 132);
            this.MaxRequestsCount.Name = "MaxRequestsCount";
            this.MaxRequestsCount.Size = new System.Drawing.Size(645, 29);
            this.MaxRequestsCount.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.Location = new System.Drawing.Point(9, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "최대 호출횟수";
            // 
            // DartCollectorPath
            // 
            this.DartCollectorPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DartCollectorPath.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DartCollectorPath.Location = new System.Drawing.Point(161, 97);
            this.DartCollectorPath.Name = "DartCollectorPath";
            this.DartCollectorPath.Size = new System.Drawing.Size(555, 29);
            this.DartCollectorPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "DartCollector 경로";
            // 
            // APICollectorPath
            // 
            this.APICollectorPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.APICollectorPath.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.APICollectorPath.Location = new System.Drawing.Point(161, 62);
            this.APICollectorPath.Name = "APICollectorPath";
            this.APICollectorPath.Size = new System.Drawing.Size(555, 29);
            this.APICollectorPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "APICollector 경로";
            // 
            // InterpreterPath
            // 
            this.InterpreterPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InterpreterPath.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.InterpreterPath.Location = new System.Drawing.Point(161, 27);
            this.InterpreterPath.Name = "InterpreterPath";
            this.InterpreterPath.Size = new System.Drawing.Size(555, 29);
            this.InterpreterPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "인터프리터 경로";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasicLayout);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(911, 670);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.BasicLayout.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox DBPW;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox DBID;
        public System.Windows.Forms.TextBox DBPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox DBIP;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox DartAPI;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox RequestsInterval;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox MaxRequestsCount;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox DartCollectorPath;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox APICollectorPath;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox InterpreterPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DartCollectorSearchButton;
        private System.Windows.Forms.Button APICollectorSartchButton;
        private System.Windows.Forms.Button InterpreterSearchButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
