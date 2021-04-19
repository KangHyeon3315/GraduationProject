
namespace AutoTraderGUI.Layout
{
    partial class Analyze
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
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("이동평균선 5");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("이동평균선 10");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("이동평균선 20");
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("이동평균선 60");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("이동평균선 120");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("이동평균선", new System.Windows.Forms.TreeNode[] {
            treeNode49,
            treeNode50,
            treeNode51,
            treeNode52,
            treeNode53});
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("MACD");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("DMI");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("피벗 라인");
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("Parabolic SAR");
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("DeMark");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("Price Channel");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("추세 지표", new System.Windows.Forms.TreeNode[] {
            treeNode54,
            treeNode55,
            treeNode56,
            treeNode57,
            treeNode58,
            treeNode59,
            treeNode60});
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("볼린저 밴드");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("ATR");
            System.Windows.Forms.TreeNode treeNode64 = new System.Windows.Forms.TreeNode("변동성 지표", new System.Windows.Forms.TreeNode[] {
            treeNode62,
            treeNode63});
            System.Windows.Forms.TreeNode treeNode65 = new System.Windows.Forms.TreeNode("RSI");
            System.Windows.Forms.TreeNode treeNode66 = new System.Windows.Forms.TreeNode("Stocastic");
            System.Windows.Forms.TreeNode treeNode67 = new System.Windows.Forms.TreeNode("Price 오실레이터");
            System.Windows.Forms.TreeNode treeNode68 = new System.Windows.Forms.TreeNode("TRIX");
            System.Windows.Forms.TreeNode treeNode69 = new System.Windows.Forms.TreeNode("RMI");
            System.Windows.Forms.TreeNode treeNode70 = new System.Windows.Forms.TreeNode("모멘텀 지표", new System.Windows.Forms.TreeNode[] {
            treeNode65,
            treeNode66,
            treeNode67,
            treeNode68,
            treeNode69});
            System.Windows.Forms.TreeNode treeNode71 = new System.Windows.Forms.TreeNode("MFI");
            System.Windows.Forms.TreeNode treeNode72 = new System.Windows.Forms.TreeNode("시장강도 지표", new System.Windows.Forms.TreeNode[] {
            treeNode71});
            this.BasicLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CenterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OptionSearch = new System.Windows.Forms.Button();
            this.SearchText = new System.Windows.Forms.RichTextBox();
            this.ChartLayout = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.financialStatementLayout = new System.Windows.Forms.TableLayoutPanel();
            this.YearFinancialStatementViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.YearFinancialStatementListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.QuarterFinancialStatementViewLayout = new System.Windows.Forms.TableLayoutPanel();
            this.QuaterFinancialStatementListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.IndicatorViewer = new System.Windows.Forms.TreeView();
            this.BasicLayout.SuspendLayout();
            this.CenterLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ChartLayout.SuspendLayout();
            this.financialStatementLayout.SuspendLayout();
            this.YearFinancialStatementViewLayout.SuspendLayout();
            this.QuarterFinancialStatementViewLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 3;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BasicLayout.Controls.Add(this.CenterLayout, 1, 0);
            this.BasicLayout.Controls.Add(this.financialStatementLayout, 0, 0);
            this.BasicLayout.Controls.Add(this.IndicatorViewer, 2, 0);
            this.BasicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicLayout.Margin = new System.Windows.Forms.Padding(0);
            this.BasicLayout.Name = "BasicLayout";
            this.BasicLayout.RowCount = 1;
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.Size = new System.Drawing.Size(1375, 678);
            this.BasicLayout.TabIndex = 0;
            // 
            // CenterLayout
            // 
            this.CenterLayout.BackColor = System.Drawing.SystemColors.WindowText;
            this.CenterLayout.ColumnCount = 1;
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.CenterLayout.Controls.Add(this.ChartLayout, 0, 1);
            this.CenterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterLayout.Location = new System.Drawing.Point(268, 0);
            this.CenterLayout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.CenterLayout.Name = "CenterLayout";
            this.CenterLayout.RowCount = 2;
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterLayout.Size = new System.Drawing.Size(892, 675);
            this.CenterLayout.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tableLayoutPanel1.Controls.Add(this.SearchButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OptionSearch, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.SearchText, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 40);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.SearchButton.Location = new System.Drawing.Point(209, 3);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(107, 34);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "검색";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchClick);
            // 
            // OptionSearch
            // 
            this.OptionSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionSearch.Font = new System.Drawing.Font("나눔고딕", 12F);
            this.OptionSearch.Location = new System.Drawing.Point(709, 3);
            this.OptionSearch.Name = "OptionSearch";
            this.OptionSearch.Size = new System.Drawing.Size(178, 34);
            this.OptionSearch.TabIndex = 2;
            this.OptionSearch.Text = "조건검색";
            this.OptionSearch.UseVisualStyleBackColor = true;
            // 
            // SearchText
            // 
            this.SearchText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchText.Font = new System.Drawing.Font("나눔고딕", 16F);
            this.SearchText.Location = new System.Drawing.Point(3, 3);
            this.SearchText.MaxLength = 50;
            this.SearchText.Multiline = false;
            this.SearchText.Name = "SearchText";
            this.SearchText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.SearchText.Size = new System.Drawing.Size(200, 34);
            this.SearchText.TabIndex = 3;
            this.SearchText.Text = "";
            this.SearchText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchEnter);
            // 
            // ChartLayout
            // 
            this.ChartLayout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChartLayout.ColumnCount = 2;
            this.ChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.ChartLayout.Controls.Add(this.toolStrip1, 1, 0);
            this.ChartLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartLayout.Location = new System.Drawing.Point(0, 41);
            this.ChartLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ChartLayout.Name = "ChartLayout";
            this.ChartLayout.RowCount = 1;
            this.ChartLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ChartLayout.Size = new System.Drawing.Size(892, 634);
            this.ChartLayout.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(851, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(41, 633);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // financialStatementLayout
            // 
            this.financialStatementLayout.ColumnCount = 1;
            this.financialStatementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.financialStatementLayout.Controls.Add(this.YearFinancialStatementViewLayout, 0, 0);
            this.financialStatementLayout.Controls.Add(this.QuarterFinancialStatementViewLayout, 0, 1);
            this.financialStatementLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialStatementLayout.Location = new System.Drawing.Point(0, 0);
            this.financialStatementLayout.Margin = new System.Windows.Forms.Padding(0);
            this.financialStatementLayout.Name = "financialStatementLayout";
            this.financialStatementLayout.RowCount = 2;
            this.financialStatementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.financialStatementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.financialStatementLayout.Size = new System.Drawing.Size(268, 678);
            this.financialStatementLayout.TabIndex = 1;
            // 
            // YearFinancialStatementViewLayout
            // 
            this.YearFinancialStatementViewLayout.ColumnCount = 1;
            this.YearFinancialStatementViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.YearFinancialStatementViewLayout.Controls.Add(this.YearFinancialStatementListView, 0, 1);
            this.YearFinancialStatementViewLayout.Controls.Add(this.label1, 0, 0);
            this.YearFinancialStatementViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YearFinancialStatementViewLayout.Location = new System.Drawing.Point(0, 0);
            this.YearFinancialStatementViewLayout.Margin = new System.Windows.Forms.Padding(0);
            this.YearFinancialStatementViewLayout.Name = "YearFinancialStatementViewLayout";
            this.YearFinancialStatementViewLayout.RowCount = 2;
            this.YearFinancialStatementViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.YearFinancialStatementViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.YearFinancialStatementViewLayout.Size = new System.Drawing.Size(268, 339);
            this.YearFinancialStatementViewLayout.TabIndex = 2;
            // 
            // YearFinancialStatementListView
            // 
            this.YearFinancialStatementListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.YearFinancialStatementListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YearFinancialStatementListView.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.YearFinancialStatementListView.HideSelection = false;
            this.YearFinancialStatementListView.Location = new System.Drawing.Point(2, 41);
            this.YearFinancialStatementListView.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.YearFinancialStatementListView.Name = "YearFinancialStatementListView";
            this.YearFinancialStatementListView.Size = new System.Drawing.Size(266, 298);
            this.YearFinancialStatementListView.TabIndex = 1;
            this.YearFinancialStatementListView.UseCompatibleStateImageBehavior = false;
            this.YearFinancialStatementListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "정보";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "값";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "연간 재무재표";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuarterFinancialStatementViewLayout
            // 
            this.QuarterFinancialStatementViewLayout.ColumnCount = 1;
            this.QuarterFinancialStatementViewLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.QuarterFinancialStatementViewLayout.Controls.Add(this.QuaterFinancialStatementListView, 0, 1);
            this.QuarterFinancialStatementViewLayout.Controls.Add(this.label2, 0, 0);
            this.QuarterFinancialStatementViewLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuarterFinancialStatementViewLayout.Location = new System.Drawing.Point(0, 339);
            this.QuarterFinancialStatementViewLayout.Margin = new System.Windows.Forms.Padding(0);
            this.QuarterFinancialStatementViewLayout.Name = "QuarterFinancialStatementViewLayout";
            this.QuarterFinancialStatementViewLayout.RowCount = 2;
            this.QuarterFinancialStatementViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.QuarterFinancialStatementViewLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.QuarterFinancialStatementViewLayout.Size = new System.Drawing.Size(268, 339);
            this.QuarterFinancialStatementViewLayout.TabIndex = 3;
            // 
            // QuaterFinancialStatementListView
            // 
            this.QuaterFinancialStatementListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.QuaterFinancialStatementListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuaterFinancialStatementListView.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.QuaterFinancialStatementListView.HideSelection = false;
            this.QuaterFinancialStatementListView.Location = new System.Drawing.Point(2, 41);
            this.QuaterFinancialStatementListView.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.QuaterFinancialStatementListView.Name = "QuaterFinancialStatementListView";
            this.QuaterFinancialStatementListView.Size = new System.Drawing.Size(266, 298);
            this.QuaterFinancialStatementListView.TabIndex = 4;
            this.QuaterFinancialStatementListView.UseCompatibleStateImageBehavior = false;
            this.QuaterFinancialStatementListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "정보";
            this.columnHeader3.Width = 110;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "값";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "분기 재무재표";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndicatorViewer
            // 
            this.IndicatorViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IndicatorViewer.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IndicatorViewer.HideSelection = false;
            this.IndicatorViewer.Location = new System.Drawing.Point(1163, 3);
            this.IndicatorViewer.Name = "IndicatorViewer";
            treeNode49.Name = "노드8";
            treeNode49.Text = "이동평균선 5";
            treeNode50.Name = "노드9";
            treeNode50.Text = "이동평균선 10";
            treeNode51.Name = "노드10";
            treeNode51.Text = "이동평균선 20";
            treeNode52.Name = "노드11";
            treeNode52.Text = "이동평균선 60";
            treeNode53.Name = "노드12";
            treeNode53.Text = "이동평균선 120";
            treeNode54.Name = "노드7";
            treeNode54.Text = "이동평균선";
            treeNode55.Name = "노드13";
            treeNode55.Text = "MACD";
            treeNode56.Name = "노드14";
            treeNode56.Text = "DMI";
            treeNode57.Name = "노드15";
            treeNode57.Text = "피벗 라인";
            treeNode58.Name = "노드16";
            treeNode58.Text = "Parabolic SAR";
            treeNode59.Name = "노드25";
            treeNode59.Text = "DeMark";
            treeNode60.Name = "노드26";
            treeNode60.Text = "Price Channel";
            treeNode61.Name = "노드0";
            treeNode61.Text = "추세 지표";
            treeNode62.Name = "노드17";
            treeNode62.Text = "볼린저 밴드";
            treeNode63.Name = "노드22";
            treeNode63.Text = "ATR";
            treeNode64.Name = "노드1";
            treeNode64.Text = "변동성 지표";
            treeNode65.Name = "노드18";
            treeNode65.Text = "RSI";
            treeNode66.Name = "노드19";
            treeNode66.Text = "Stocastic";
            treeNode67.Name = "노드21";
            treeNode67.Text = "Price 오실레이터";
            treeNode68.Name = "노드23";
            treeNode68.Text = "TRIX";
            treeNode69.Name = "노드24";
            treeNode69.Text = "RMI";
            treeNode70.Name = "노드2";
            treeNode70.Text = "모멘텀 지표";
            treeNode71.Name = "노드20";
            treeNode71.Text = "MFI";
            treeNode72.Name = "노드3";
            treeNode72.Text = "시장강도 지표";
            this.IndicatorViewer.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode61,
            treeNode64,
            treeNode70,
            treeNode72});
            this.IndicatorViewer.Size = new System.Drawing.Size(209, 672);
            this.IndicatorViewer.TabIndex = 2;
            // 
            // Analyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasicLayout);
            this.Name = "Analyze";
            this.Size = new System.Drawing.Size(1375, 678);
            this.BasicLayout.ResumeLayout(false);
            this.CenterLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ChartLayout.ResumeLayout(false);
            this.ChartLayout.PerformLayout();
            this.financialStatementLayout.ResumeLayout(false);
            this.YearFinancialStatementViewLayout.ResumeLayout(false);
            this.YearFinancialStatementViewLayout.PerformLayout();
            this.QuarterFinancialStatementViewLayout.ResumeLayout(false);
            this.QuarterFinancialStatementViewLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.TableLayoutPanel CenterLayout;
        private System.Windows.Forms.TableLayoutPanel financialStatementLayout;
        private System.Windows.Forms.ListView YearFinancialStatementListView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button OptionSearch;
        private System.Windows.Forms.TableLayoutPanel ChartLayout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RichTextBox SearchText;
        private System.Windows.Forms.TableLayoutPanel YearFinancialStatementViewLayout;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel QuarterFinancialStatementViewLayout;
        private System.Windows.Forms.ListView QuaterFinancialStatementListView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView IndicatorViewer;
    }
}
