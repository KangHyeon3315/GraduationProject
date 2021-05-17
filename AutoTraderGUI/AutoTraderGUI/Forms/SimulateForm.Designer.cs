
namespace AutoTraderGUI.Forms
{
    partial class SimulateForm
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
            this.components = new System.ComponentModel.Container();
            this.BasicLayout = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AlgorithmCombo = new System.Windows.Forms.ComboBox();
            this.SimulateUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.InitialAssets = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Charge = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Tax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LoadSimulation = new System.Windows.Forms.Button();
            this.ChartPanel = new System.Windows.Forms.Panel();
            this.SimulateInfoPanel = new System.Windows.Forms.Panel();
            this.MonitoringViewer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BasicLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 2;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.BasicLayout.Controls.Add(this.button1, 1, 0);
            this.BasicLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.BasicLayout.Controls.Add(this.ChartPanel, 0, 1);
            this.BasicLayout.Controls.Add(this.SimulateInfoPanel, 1, 1);
            this.BasicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicLayout.Name = "BasicLayout";
            this.BasicLayout.RowCount = 2;
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BasicLayout.Size = new System.Drawing.Size(1778, 1000);
            this.BasicLayout.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1481, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "알고리즘 추가 및 선택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AlgorithmManageClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 17;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AlgorithmCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.SimulateUnit, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.InitialAssets, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.Charge, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 14, 0);
            this.tableLayoutPanel1.Controls.Add(this.Tax, 13, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoadSimulation, 15, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1472, 34);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "알고리즘";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AlgorithmCombo
            // 
            this.AlgorithmCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmCombo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AlgorithmCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AlgorithmCombo.FormattingEnabled = true;
            this.AlgorithmCombo.Location = new System.Drawing.Point(84, 3);
            this.AlgorithmCombo.Name = "AlgorithmCombo";
            this.AlgorithmCombo.Size = new System.Drawing.Size(174, 28);
            this.AlgorithmCombo.TabIndex = 4;
            // 
            // SimulateUnit
            // 
            this.SimulateUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulateUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SimulateUnit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SimulateUnit.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.SimulateUnit.FormattingEnabled = true;
            this.SimulateUnit.Items.AddRange(new object[] {
            "일",
            "분"});
            this.SimulateUnit.Location = new System.Drawing.Point(344, 3);
            this.SimulateUnit.Name = "SimulateUnit";
            this.SimulateUnit.Size = new System.Drawing.Size(63, 29);
            this.SimulateUnit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.Location = new System.Drawing.Point(290, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 34);
            this.label4.TabIndex = 5;
            this.label4.Text = "단위";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Window;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.Location = new System.Drawing.Point(445, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 34);
            this.label6.TabIndex = 7;
            this.label6.Text = "초기자산";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InitialAssets
            // 
            this.InitialAssets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InitialAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InitialAssets.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.InitialAssets.Location = new System.Drawing.Point(532, 3);
            this.InitialAssets.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.InitialAssets.Name = "InitialAssets";
            this.InitialAssets.Size = new System.Drawing.Size(135, 29);
            this.InitialAssets.TabIndex = 8;
            this.InitialAssets.Text = "10,000,000";
            this.InitialAssets.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.InitialAssets.Leave += new System.EventHandler(this.InitialAssets_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Window;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label7.Location = new System.Drawing.Point(667, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 34);
            this.label7.TabIndex = 9;
            this.label7.Text = "원";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label8.Location = new System.Drawing.Point(715, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 34);
            this.label8.TabIndex = 10;
            this.label8.Text = "수수료";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Charge
            // 
            this.Charge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Charge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Charge.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Charge.Location = new System.Drawing.Point(788, 3);
            this.Charge.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Charge.Name = "Charge";
            this.Charge.Size = new System.Drawing.Size(77, 29);
            this.Charge.TabIndex = 11;
            this.Charge.Text = "0.00015";
            this.Charge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Window;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(865, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 34);
            this.label9.TabIndex = 12;
            this.label9.Text = "%";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label11.Location = new System.Drawing.Point(1082, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 34);
            this.label11.TabIndex = 14;
            this.label11.Text = "%";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Tax
            // 
            this.Tax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tax.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.Tax.Location = new System.Drawing.Point(1003, 3);
            this.Tax.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.Tax.Name = "Tax";
            this.Tax.Size = new System.Drawing.Size(79, 29);
            this.Tax.TabIndex = 15;
            this.Tax.Text = "0.00015";
            this.Tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Window;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label10.Location = new System.Drawing.Point(934, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 34);
            this.label10.TabIndex = 13;
            this.label10.Text = "세금";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadSimulation
            // 
            this.LoadSimulation.BackColor = System.Drawing.SystemColors.Window;
            this.LoadSimulation.FlatAppearance.BorderSize = 0;
            this.LoadSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadSimulation.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.LoadSimulation.Location = new System.Drawing.Point(1115, 3);
            this.LoadSimulation.Name = "LoadSimulation";
            this.LoadSimulation.Size = new System.Drawing.Size(169, 28);
            this.LoadSimulation.TabIndex = 16;
            this.LoadSimulation.Text = "시뮬레이션 불러오기";
            this.LoadSimulation.UseVisualStyleBackColor = false;
            this.LoadSimulation.Click += new System.EventHandler(this.LoadSimulation_Click);
            // 
            // ChartPanel
            // 
            this.ChartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartPanel.Location = new System.Drawing.Point(3, 43);
            this.ChartPanel.Name = "ChartPanel";
            this.ChartPanel.Size = new System.Drawing.Size(1472, 954);
            this.ChartPanel.TabIndex = 5;
            // 
            // SimulateInfoPanel
            // 
            this.SimulateInfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulateInfoPanel.Location = new System.Drawing.Point(1481, 43);
            this.SimulateInfoPanel.Name = "SimulateInfoPanel";
            this.SimulateInfoPanel.Size = new System.Drawing.Size(294, 954);
            this.SimulateInfoPanel.TabIndex = 6;
            // 
            // MonitoringViewer
            // 
            this.MonitoringViewer.Tick += new System.EventHandler(this.MonitoringViewer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // SimulateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasicLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SimulateForm";
            this.Size = new System.Drawing.Size(1778, 1000);
            this.BasicLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SimulateUnit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox InitialAssets;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Charge;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Tax;
        private System.Windows.Forms.Timer MonitoringViewer;
        private System.Windows.Forms.Panel ChartPanel;
        private System.Windows.Forms.Panel SimulateInfoPanel;
        private System.Windows.Forms.Button LoadSimulation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox AlgorithmCombo;
    }
}
