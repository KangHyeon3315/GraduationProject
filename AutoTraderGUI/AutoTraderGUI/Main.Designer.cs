
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.작업ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPICollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dartCollectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.설정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보입력ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.과거로그보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.작업ToolStripMenuItem,
            this.설정ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 작업ToolStripMenuItem
            // 
            this.작업ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPICollectorToolStripMenuItem,
            this.dartCollectorToolStripMenuItem});
            this.작업ToolStripMenuItem.Name = "작업ToolStripMenuItem";
            this.작업ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.작업ToolStripMenuItem.Text = "작업";
            // 
            // aPICollectorToolStripMenuItem
            // 
            this.aPICollectorToolStripMenuItem.Name = "aPICollectorToolStripMenuItem";
            this.aPICollectorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aPICollectorToolStripMenuItem.Text = "API Collector";
            this.aPICollectorToolStripMenuItem.Click += new System.EventHandler(this.APICollectorToolStripMenuItem_Click);
            // 
            // dartCollectorToolStripMenuItem
            // 
            this.dartCollectorToolStripMenuItem.Name = "dartCollectorToolStripMenuItem";
            this.dartCollectorToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.dartCollectorToolStripMenuItem.Text = "Dart Collector";
            this.dartCollectorToolStripMenuItem.Click += new System.EventHandler(this.DartCollectorToolStripMenuItem_Click);
            // 
            // 설정ToolStripMenuItem
            // 
            this.설정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보입력ToolStripMenuItem,
            this.과거로그보기ToolStripMenuItem});
            this.설정ToolStripMenuItem.Name = "설정ToolStripMenuItem";
            this.설정ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.ClickHome);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.MainPanel.Location = new System.Drawing.Point(0, 50);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(800, 401);
            this.MainPanel.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.CheckSystem);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "home-512.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "AutoTrader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 작업ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPICollectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 설정ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem dartCollectorToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.ToolStripMenuItem 정보입력ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 과거로그보기ToolStripMenuItem;
    }
}

