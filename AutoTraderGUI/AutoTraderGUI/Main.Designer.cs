
namespace AutoTraderGUI
{
    partial class Main
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.작업ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPICollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dartCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보입력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.과거로그보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TabMenu = new System.Windows.Forms.ToolStrip();
            this.MainToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AnalyzeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SimulationToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TradeToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.TabMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.작업ToolStripMenuItem,
            this.설정ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 작업ToolStripMenuItem
            // 
            this.작업ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPICollectorToolStripMenuItem,
            this.dartCollectorToolStripMenuItem});
            this.작업ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.작업ToolStripMenuItem.Name = "작업ToolStripMenuItem";
            this.작업ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.작업ToolStripMenuItem.Text = "작업";
            // 
            // aPICollectorToolStripMenuItem
            // 
            this.aPICollectorToolStripMenuItem.Name = "aPICollectorToolStripMenuItem";
            this.aPICollectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aPICollectorToolStripMenuItem.Text = "API Collector";
            this.aPICollectorToolStripMenuItem.Click += new System.EventHandler(this.APICollectorToolStripMenuItem_Click);
            // 
            // dartCollectorToolStripMenuItem
            // 
            this.dartCollectorToolStripMenuItem.Name = "dartCollectorToolStripMenuItem";
            this.dartCollectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dartCollectorToolStripMenuItem.Text = "Dart Collector";
            this.dartCollectorToolStripMenuItem.Click += new System.EventHandler(this.DartCollectorToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보입력ToolStripMenuItem,
            this.과거로그보기ToolStripMenuItem});
            this.설정ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.설정ToolStripMenuItem.Text = "도구";
            // 
            // 정보입력ToolStripMenuItem
            // 
            this.정보입력ToolStripMenuItem.Name = "정보입력ToolStripMenuItem";
            this.정보입력ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보입력ToolStripMenuItem.Text = "정보입력";
            this.정보입력ToolStripMenuItem.Click += new System.EventHandler(this.SettingsClick);
            // 
            // 과거로그보기ToolStripMenuItem
            // 
            this.과거로그보기ToolStripMenuItem.Name = "과거로그보기ToolStripMenuItem";
            this.과거로그보기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.과거로그보기ToolStripMenuItem.Text = "과거 로그보기";
            this.과거로그보기ToolStripMenuItem.Click += new System.EventHandler(this.HistoricalLogClick);
            // 
            // TabMenu
            // 
            this.TabMenu.AutoSize = false;
            this.TabMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TabMenu.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainToolStripLabel,
            this.toolStripSeparator1,
            this.AnalyzeToolStripLabel,
            this.toolStripSeparator4,
            this.SimulationToolStripLabel,
            this.toolStripSeparator3,
            this.TradeToolStripLabel,
            this.toolStripSeparator2});
            this.TabMenu.Location = new System.Drawing.Point(0, 25);
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.Size = new System.Drawing.Size(800, 25);
            this.TabMenu.TabIndex = 1;
            this.TabMenu.Text = "toolStrip1";
            // 
            // MainToolStripLabel
            // 
            this.MainToolStripLabel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainToolStripLabel.Name = "MainToolStripLabel";
            this.MainToolStripLabel.Size = new System.Drawing.Size(31, 22);
            this.MainToolStripLabel.Text = "메인";
            this.MainToolStripLabel.Click += new System.EventHandler(this.ClickHome);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AnalyzeToolStripLabel
            // 
            this.AnalyzeToolStripLabel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AnalyzeToolStripLabel.Name = "AnalyzeToolStripLabel";
            this.AnalyzeToolStripLabel.Size = new System.Drawing.Size(31, 22);
            this.AnalyzeToolStripLabel.Text = "분석";
            this.AnalyzeToolStripLabel.Click += new System.EventHandler(this.ClickAnalyze);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // SimulationToolStripLabel
            // 
            this.SimulationToolStripLabel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SimulationToolStripLabel.Name = "SimulationToolStripLabel";
            this.SimulationToolStripLabel.Size = new System.Drawing.Size(67, 22);
            this.SimulationToolStripLabel.Text = "시뮬레이션";
            this.SimulationToolStripLabel.Click += new System.EventHandler(this.ClickSimulate);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // TradeToolStripLabel
            // 
            this.TradeToolStripLabel.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TradeToolStripLabel.Name = "TradeToolStripLabel";
            this.TradeToolStripLabel.Size = new System.Drawing.Size(31, 22);
            this.TradeToolStripLabel.Text = "거래";
            this.TradeToolStripLabel.Click += new System.EventHandler(this.ClickTrade);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoSize = true;
            this.MainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainPanel.Location = new System.Drawing.Point(0, 50);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 400);
            this.MainPanel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.CheckSystem);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.TabMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "AutoTrader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabMenu.ResumeLayout(false);
            this.TabMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 작업ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPICollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip TabMenu;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem dartCollectorToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 정보입력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 과거로그보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel TradeToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel AnalyzeToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel SimulationToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel MainToolStripLabel;
    }
}

