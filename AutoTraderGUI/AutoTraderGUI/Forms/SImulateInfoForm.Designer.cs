
namespace AutoTraderGUI.Forms
{
    partial class SImulateInfoForm
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
            this.DatePanel = new System.Windows.Forms.TableLayoutPanel();
            this.DateText = new System.Windows.Forms.Label();
            this.SimulateProgressText = new System.Windows.Forms.Label();
            this.EvaluationPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.EvaluationAssets = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.AverageYieldPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.AverageYield = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WinRate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ProfitLossRatePanel = new System.Windows.Forms.TableLayoutPanel();
            this.ProfitLossRatio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BasicPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SimulatingButton = new System.Windows.Forms.Button();
            this.ProgressPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SimulateProgress = new System.Windows.Forms.ProgressBar();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.MDDPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.MDDText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DatePanel.SuspendLayout();
            this.EvaluationPanel.SuspendLayout();
            this.AverageYieldPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ProfitLossRatePanel.SuspendLayout();
            this.BasicPanel.SuspendLayout();
            this.ProgressPanel.SuspendLayout();
            this.MDDPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatePanel
            // 
            this.DatePanel.ColumnCount = 3;
            this.DatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.DatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.DatePanel.Controls.Add(this.DateText, 0, 0);
            this.DatePanel.Controls.Add(this.SimulateProgressText, 2, 0);
            this.DatePanel.Location = new System.Drawing.Point(3, 190);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Padding = new System.Windows.Forms.Padding(3);
            this.DatePanel.RowCount = 1;
            this.DatePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DatePanel.Size = new System.Drawing.Size(297, 44);
            this.DatePanel.TabIndex = 2;
            // 
            // DateText
            // 
            this.DateText.AutoSize = true;
            this.DateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.DateText.Location = new System.Drawing.Point(6, 3);
            this.DateText.Name = "DateText";
            this.DateText.Size = new System.Drawing.Size(112, 38);
            this.DateText.TabIndex = 6;
            this.DateText.Text = "0000-00-00";
            this.DateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SimulateProgressText
            // 
            this.SimulateProgressText.AutoSize = true;
            this.SimulateProgressText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulateProgressText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.SimulateProgressText.Location = new System.Drawing.Point(191, 3);
            this.SimulateProgressText.Name = "SimulateProgressText";
            this.SimulateProgressText.Size = new System.Drawing.Size(100, 38);
            this.SimulateProgressText.TabIndex = 10;
            this.SimulateProgressText.Text = "0000/0000";
            this.SimulateProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EvaluationPanel
            // 
            this.EvaluationPanel.ColumnCount = 3;
            this.EvaluationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.EvaluationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EvaluationPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.EvaluationPanel.Controls.Add(this.label14, 0, 0);
            this.EvaluationPanel.Controls.Add(this.EvaluationAssets, 0, 0);
            this.EvaluationPanel.Controls.Add(this.label12, 0, 0);
            this.EvaluationPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EvaluationPanel.Location = new System.Drawing.Point(3, 240);
            this.EvaluationPanel.Name = "EvaluationPanel";
            this.EvaluationPanel.Padding = new System.Windows.Forms.Padding(3);
            this.EvaluationPanel.RowCount = 1;
            this.EvaluationPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EvaluationPanel.Size = new System.Drawing.Size(297, 44);
            this.EvaluationPanel.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label14.Location = new System.Drawing.Point(266, 3);
            this.label14.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 38);
            this.label14.TabIndex = 8;
            this.label14.Text = "원";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EvaluationAssets
            // 
            this.EvaluationAssets.AutoSize = true;
            this.EvaluationAssets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluationAssets.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.EvaluationAssets.Location = new System.Drawing.Point(123, 3);
            this.EvaluationAssets.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.EvaluationAssets.Name = "EvaluationAssets";
            this.EvaluationAssets.Size = new System.Drawing.Size(143, 38);
            this.EvaluationAssets.TabIndex = 7;
            this.EvaluationAssets.Text = "10,000,000";
            this.EvaluationAssets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label12.Location = new System.Drawing.Point(6, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 38);
            this.label12.TabIndex = 6;
            this.label12.Text = "평가금";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AverageYieldPanel
            // 
            this.AverageYieldPanel.ColumnCount = 3;
            this.AverageYieldPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.AverageYieldPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AverageYieldPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.AverageYieldPanel.Controls.Add(this.label1, 0, 0);
            this.AverageYieldPanel.Controls.Add(this.AverageYield, 0, 0);
            this.AverageYieldPanel.Controls.Add(this.label3, 0, 0);
            this.AverageYieldPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AverageYieldPanel.Location = new System.Drawing.Point(3, 440);
            this.AverageYieldPanel.Name = "AverageYieldPanel";
            this.AverageYieldPanel.Padding = new System.Windows.Forms.Padding(3);
            this.AverageYieldPanel.RowCount = 1;
            this.AverageYieldPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AverageYieldPanel.Size = new System.Drawing.Size(297, 44);
            this.AverageYieldPanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(266, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 38);
            this.label1.TabIndex = 11;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AverageYield
            // 
            this.AverageYield.AutoSize = true;
            this.AverageYield.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AverageYield.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.AverageYield.Location = new System.Drawing.Point(150, 3);
            this.AverageYield.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.AverageYield.Name = "AverageYield";
            this.AverageYield.Size = new System.Drawing.Size(116, 38);
            this.AverageYield.TabIndex = 10;
            this.AverageYield.Text = "0";
            this.AverageYield.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "거래 평균 수익률";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.WinRate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 290);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 44);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // WinRate
            // 
            this.WinRate.AutoSize = true;
            this.WinRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WinRate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.WinRate.Location = new System.Drawing.Point(123, 3);
            this.WinRate.Name = "WinRate";
            this.WinRate.Size = new System.Drawing.Size(168, 38);
            this.WinRate.TabIndex = 13;
            this.WinRate.Text = "0000 / 0000";
            this.WinRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.Location = new System.Drawing.Point(6, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 38);
            this.label5.TabIndex = 6;
            this.label5.Text = "거래 승률";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfitLossRatePanel
            // 
            this.ProfitLossRatePanel.ColumnCount = 2;
            this.ProfitLossRatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.ProfitLossRatePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProfitLossRatePanel.Controls.Add(this.ProfitLossRatio, 0, 0);
            this.ProfitLossRatePanel.Controls.Add(this.label4, 0, 0);
            this.ProfitLossRatePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ProfitLossRatePanel.Location = new System.Drawing.Point(3, 340);
            this.ProfitLossRatePanel.Name = "ProfitLossRatePanel";
            this.ProfitLossRatePanel.Padding = new System.Windows.Forms.Padding(3);
            this.ProfitLossRatePanel.RowCount = 1;
            this.ProfitLossRatePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProfitLossRatePanel.Size = new System.Drawing.Size(297, 44);
            this.ProfitLossRatePanel.TabIndex = 6;
            // 
            // ProfitLossRatio
            // 
            this.ProfitLossRatio.AutoSize = true;
            this.ProfitLossRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfitLossRatio.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.ProfitLossRatio.Location = new System.Drawing.Point(123, 3);
            this.ProfitLossRatio.Name = "ProfitLossRatio";
            this.ProfitLossRatio.Size = new System.Drawing.Size(168, 38);
            this.ProfitLossRatio.TabIndex = 15;
            this.ProfitLossRatio.Text = "0000 / 0000";
            this.ProfitLossRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 38);
            this.label4.TabIndex = 6;
            this.label4.Text = "거래 손익비";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BasicPanel
            // 
            this.BasicPanel.BackColor = System.Drawing.SystemColors.Window;
            this.BasicPanel.ColumnCount = 1;
            this.BasicPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicPanel.Controls.Add(this.SimulatingButton, 0, 0);
            this.BasicPanel.Controls.Add(this.ProgressPanel, 0, 4);
            this.BasicPanel.Controls.Add(this.DatePanel, 0, 5);
            this.BasicPanel.Controls.Add(this.EvaluationPanel, 0, 6);
            this.BasicPanel.Controls.Add(this.AnalyzeButton, 0, 2);
            this.BasicPanel.Controls.Add(this.tableLayoutPanel1, 0, 7);
            this.BasicPanel.Controls.Add(this.ProfitLossRatePanel, 0, 8);
            this.BasicPanel.Controls.Add(this.AverageYieldPanel, 0, 10);
            this.BasicPanel.Controls.Add(this.MDDPanel, 0, 9);
            this.BasicPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicPanel.Location = new System.Drawing.Point(0, 0);
            this.BasicPanel.Name = "BasicPanel";
            this.BasicPanel.RowCount = 12;
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BasicPanel.Size = new System.Drawing.Size(305, 627);
            this.BasicPanel.TabIndex = 8;
            // 
            // SimulatingButton
            // 
            this.SimulatingButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulatingButton.FlatAppearance.BorderSize = 0;
            this.SimulatingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SimulatingButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SimulatingButton.Location = new System.Drawing.Point(0, 0);
            this.SimulatingButton.Margin = new System.Windows.Forms.Padding(0);
            this.SimulatingButton.Name = "SimulatingButton";
            this.SimulatingButton.Size = new System.Drawing.Size(305, 40);
            this.SimulatingButton.TabIndex = 4;
            this.SimulatingButton.Text = "시뮬레이트 시작";
            this.SimulatingButton.UseVisualStyleBackColor = true;
            this.SimulatingButton.Click += new System.EventHandler(this.SimulatingButton_Click);
            // 
            // ProgressPanel
            // 
            this.ProgressPanel.ColumnCount = 1;
            this.ProgressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProgressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ProgressPanel.Controls.Add(this.SimulateProgress, 0, 0);
            this.ProgressPanel.Location = new System.Drawing.Point(3, 140);
            this.ProgressPanel.Name = "ProgressPanel";
            this.ProgressPanel.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ProgressPanel.RowCount = 1;
            this.ProgressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ProgressPanel.Size = new System.Drawing.Size(297, 44);
            this.ProgressPanel.TabIndex = 1;
            // 
            // SimulateProgress
            // 
            this.SimulateProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SimulateProgress.Location = new System.Drawing.Point(0, 6);
            this.SimulateProgress.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.SimulateProgress.Name = "SimulateProgress";
            this.SimulateProgress.Size = new System.Drawing.Size(294, 32);
            this.SimulateProgress.TabIndex = 1;
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnalyzeButton.FlatAppearance.BorderSize = 0;
            this.AnalyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyzeButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.AnalyzeButton.Location = new System.Drawing.Point(0, 47);
            this.AnalyzeButton.Margin = new System.Windows.Forms.Padding(0);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Size = new System.Drawing.Size(305, 40);
            this.AnalyzeButton.TabIndex = 8;
            this.AnalyzeButton.Text = "거래기록 분석";
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // MDDPanel
            // 
            this.MDDPanel.ColumnCount = 3;
            this.MDDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.MDDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MDDPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.MDDPanel.Controls.Add(this.label24, 0, 0);
            this.MDDPanel.Controls.Add(this.MDDText, 0, 0);
            this.MDDPanel.Controls.Add(this.label6, 0, 0);
            this.MDDPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MDDPanel.Location = new System.Drawing.Point(3, 390);
            this.MDDPanel.Name = "MDDPanel";
            this.MDDPanel.Padding = new System.Windows.Forms.Padding(3);
            this.MDDPanel.RowCount = 1;
            this.MDDPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MDDPanel.Size = new System.Drawing.Size(297, 44);
            this.MDDPanel.TabIndex = 7;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label24.Location = new System.Drawing.Point(266, 3);
            this.label24.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(25, 38);
            this.label24.TabIndex = 18;
            this.label24.Text = "%";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MDDText
            // 
            this.MDDText.AutoSize = true;
            this.MDDText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MDDText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MDDText.Location = new System.Drawing.Point(123, 3);
            this.MDDText.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.MDDText.Name = "MDDText";
            this.MDDText.Size = new System.Drawing.Size(143, 38);
            this.MDDText.TabIndex = 17;
            this.MDDText.Text = "0";
            this.MDDText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.Location = new System.Drawing.Point(6, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 38);
            this.label6.TabIndex = 6;
            this.label6.Text = "MDD";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SImulateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.BasicPanel);
            this.Name = "SImulateInfoForm";
            this.Size = new System.Drawing.Size(305, 627);
            this.DatePanel.ResumeLayout(false);
            this.DatePanel.PerformLayout();
            this.EvaluationPanel.ResumeLayout(false);
            this.EvaluationPanel.PerformLayout();
            this.AverageYieldPanel.ResumeLayout(false);
            this.AverageYieldPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ProfitLossRatePanel.ResumeLayout(false);
            this.ProfitLossRatePanel.PerformLayout();
            this.BasicPanel.ResumeLayout(false);
            this.ProgressPanel.ResumeLayout(false);
            this.MDDPanel.ResumeLayout(false);
            this.MDDPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel DatePanel;
        private System.Windows.Forms.TableLayoutPanel EvaluationPanel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label EvaluationAssets;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel AverageYieldPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AverageYield;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label WinRate;
        private System.Windows.Forms.TableLayoutPanel ProfitLossRatePanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label ProfitLossRatio;
        private System.Windows.Forms.TableLayoutPanel BasicPanel;
        private System.Windows.Forms.TableLayoutPanel ProgressPanel;
        private System.Windows.Forms.ProgressBar SimulateProgress;
        public System.Windows.Forms.Button SimulatingButton;
        public System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.Label SimulateProgressText;
        private System.Windows.Forms.Label DateText;
        private System.Windows.Forms.TableLayoutPanel MDDPanel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label MDDText;
        private System.Windows.Forms.Label label6;
    }
}
