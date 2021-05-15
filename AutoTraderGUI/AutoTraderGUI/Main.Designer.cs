
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.FSCollectButton = new System.Windows.Forms.Button();
            this.PriceCollectButton = new System.Windows.Forms.Button();
            this.CollectButton = new System.Windows.Forms.Button();
            this.ButtonMarginPanel = new System.Windows.Forms.Panel();
            this.TradeButton = new System.Windows.Forms.Button();
            this.SimulationButton = new System.Windows.Forms.Button();
            this.AnalyzeButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoSize = true;
            this.MainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.MainPanel.Location = new System.Drawing.Point(198, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(917, 581);
            this.MainPanel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.CheckSystem);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.AutoScroll = true;
            this.ButtonPanel.Controls.Add(this.SettingsButton);
            this.ButtonPanel.Controls.Add(this.FSCollectButton);
            this.ButtonPanel.Controls.Add(this.PriceCollectButton);
            this.ButtonPanel.Controls.Add(this.CollectButton);
            this.ButtonPanel.Controls.Add(this.ButtonMarginPanel);
            this.ButtonPanel.Controls.Add(this.TradeButton);
            this.ButtonPanel.Controls.Add(this.SimulationButton);
            this.ButtonPanel.Controls.Add(this.AnalyzeButton);
            this.ButtonPanel.Controls.Add(this.HomeButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(200, 581);
            this.ButtonPanel.TabIndex = 3;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SettingsButton.Location = new System.Drawing.Point(0, 480);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(5);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SettingsButton.Size = new System.Drawing.Size(200, 60);
            this.SettingsButton.TabIndex = 9;
            this.SettingsButton.Text = "설정";
            this.SettingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingClick);
            // 
            // FSCollectButton
            // 
            this.FSCollectButton.BackColor = System.Drawing.SystemColors.Control;
            this.FSCollectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FSCollectButton.FlatAppearance.BorderSize = 0;
            this.FSCollectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FSCollectButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FSCollectButton.Location = new System.Drawing.Point(0, 420);
            this.FSCollectButton.Margin = new System.Windows.Forms.Padding(5);
            this.FSCollectButton.Name = "FSCollectButton";
            this.FSCollectButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.FSCollectButton.Size = new System.Drawing.Size(200, 60);
            this.FSCollectButton.TabIndex = 8;
            this.FSCollectButton.Text = "재무제표 수집";
            this.FSCollectButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FSCollectButton.UseVisualStyleBackColor = false;
            this.FSCollectButton.Visible = false;
            this.FSCollectButton.Click += new System.EventHandler(this.FSClick);
            // 
            // PriceCollectButton
            // 
            this.PriceCollectButton.BackColor = System.Drawing.SystemColors.Control;
            this.PriceCollectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PriceCollectButton.FlatAppearance.BorderSize = 0;
            this.PriceCollectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PriceCollectButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PriceCollectButton.Location = new System.Drawing.Point(0, 360);
            this.PriceCollectButton.Margin = new System.Windows.Forms.Padding(5);
            this.PriceCollectButton.Name = "PriceCollectButton";
            this.PriceCollectButton.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.PriceCollectButton.Size = new System.Drawing.Size(200, 60);
            this.PriceCollectButton.TabIndex = 7;
            this.PriceCollectButton.Text = "가격 지표 수집";
            this.PriceCollectButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PriceCollectButton.UseVisualStyleBackColor = false;
            this.PriceCollectButton.Visible = false;
            this.PriceCollectButton.Click += new System.EventHandler(this.PriceCollectClick);
            // 
            // CollectButton
            // 
            this.CollectButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CollectButton.FlatAppearance.BorderSize = 0;
            this.CollectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollectButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CollectButton.Location = new System.Drawing.Point(0, 300);
            this.CollectButton.Margin = new System.Windows.Forms.Padding(5);
            this.CollectButton.Name = "CollectButton";
            this.CollectButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.CollectButton.Size = new System.Drawing.Size(200, 60);
            this.CollectButton.TabIndex = 6;
            this.CollectButton.Text = "데이터 수집";
            this.CollectButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CollectButton.UseVisualStyleBackColor = true;
            this.CollectButton.Click += new System.EventHandler(this.CollectClick);
            // 
            // ButtonMarginPanel
            // 
            this.ButtonMarginPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonMarginPanel.Location = new System.Drawing.Point(0, 240);
            this.ButtonMarginPanel.Name = "ButtonMarginPanel";
            this.ButtonMarginPanel.Size = new System.Drawing.Size(200, 60);
            this.ButtonMarginPanel.TabIndex = 5;
            // 
            // TradeButton
            // 
            this.TradeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TradeButton.FlatAppearance.BorderSize = 0;
            this.TradeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TradeButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TradeButton.Location = new System.Drawing.Point(0, 180);
            this.TradeButton.Margin = new System.Windows.Forms.Padding(5);
            this.TradeButton.Name = "TradeButton";
            this.TradeButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.TradeButton.Size = new System.Drawing.Size(200, 60);
            this.TradeButton.TabIndex = 4;
            this.TradeButton.Text = "실전거래";
            this.TradeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TradeButton.UseVisualStyleBackColor = true;
            this.TradeButton.Click += new System.EventHandler(this.TradeClick);
            // 
            // SimulationButton
            // 
            this.SimulationButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SimulationButton.FlatAppearance.BorderSize = 0;
            this.SimulationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SimulationButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SimulationButton.Location = new System.Drawing.Point(0, 120);
            this.SimulationButton.Margin = new System.Windows.Forms.Padding(5);
            this.SimulationButton.Name = "SimulationButton";
            this.SimulationButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SimulationButton.Size = new System.Drawing.Size(200, 60);
            this.SimulationButton.TabIndex = 3;
            this.SimulationButton.Text = "시뮬레이션";
            this.SimulationButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SimulationButton.UseVisualStyleBackColor = true;
            this.SimulationButton.Click += new System.EventHandler(this.SimulateClick);
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnalyzeButton.FlatAppearance.BorderSize = 0;
            this.AnalyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnalyzeButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AnalyzeButton.Location = new System.Drawing.Point(0, 60);
            this.AnalyzeButton.Margin = new System.Windows.Forms.Padding(5);
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.AnalyzeButton.Size = new System.Drawing.Size(200, 60);
            this.AnalyzeButton.TabIndex = 2;
            this.AnalyzeButton.Text = "분석화면";
            this.AnalyzeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AnalyzeButton.UseVisualStyleBackColor = true;
            this.AnalyzeButton.Click += new System.EventHandler(this.AnalyzeClick);
            // 
            // HomeButton
            // 
            this.HomeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HomeButton.Location = new System.Drawing.Point(0, 0);
            this.HomeButton.Margin = new System.Windows.Forms.Padding(5);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.HomeButton.Size = new System.Drawing.Size(200, 60);
            this.HomeButton.TabIndex = 1;
            this.HomeButton.Text = "홈화면";
            this.HomeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1115, 581);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.MainPanel);
            this.Name = "Main";
            this.Text = "AutoTrader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button TradeButton;
        private System.Windows.Forms.Button SimulationButton;
        private System.Windows.Forms.Button AnalyzeButton;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button FSCollectButton;
        private System.Windows.Forms.Button PriceCollectButton;
        private System.Windows.Forms.Button CollectButton;
        private System.Windows.Forms.Panel ButtonMarginPanel;
        private System.Windows.Forms.Button SettingsButton;
    }
}

