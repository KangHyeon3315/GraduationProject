
namespace AutoTraderGUI.Forms
{
    partial class AlgorithmInfoControl
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
            this.AlgorithmInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.세부정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수정하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.삭제하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.AlgorithmInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.AlgorithmInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AlgorithmInfo.GridLines = true;
            this.AlgorithmInfo.HideSelection = false;
            this.AlgorithmInfo.Location = new System.Drawing.Point(0, 0);
            this.AlgorithmInfo.MultiSelect = false;
            this.AlgorithmInfo.Name = "AlgorithmInfo";
            this.AlgorithmInfo.Size = new System.Drawing.Size(999, 484);
            this.AlgorithmInfo.TabIndex = 10;
            this.AlgorithmInfo.UseCompatibleStateImageBehavior = false;
            this.AlgorithmInfo.View = System.Windows.Forms.View.Details;
            this.AlgorithmInfo.Resize += new System.EventHandler(this.ResizeEvent);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "알고리즘 이름";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.세부정보ToolStripMenuItem,
            this.수정하기ToolStripMenuItem,
            this.삭제하기ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // 세부정보ToolStripMenuItem
            // 
            this.세부정보ToolStripMenuItem.Name = "세부정보ToolStripMenuItem";
            this.세부정보ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.세부정보ToolStripMenuItem.Text = "세부정보";
            // 
            // 수정하기ToolStripMenuItem
            // 
            this.수정하기ToolStripMenuItem.Name = "수정하기ToolStripMenuItem";
            this.수정하기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.수정하기ToolStripMenuItem.Text = "수정하기";
            this.수정하기ToolStripMenuItem.Click += new System.EventHandler(this.EidtClick);
            // 
            // 삭제하기ToolStripMenuItem
            // 
            this.삭제하기ToolStripMenuItem.Name = "삭제하기ToolStripMenuItem";
            this.삭제하기ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.삭제하기ToolStripMenuItem.Text = "삭제하기";
            this.삭제하기ToolStripMenuItem.Click += new System.EventHandler(this.DeleteClick);
            // 
            // AlgorithmInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AlgorithmInfo);
            this.Name = "AlgorithmInfoControl";
            this.Size = new System.Drawing.Size(999, 484);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.ListView AlgorithmInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 세부정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 수정하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 삭제하기ToolStripMenuItem;
    }
}
