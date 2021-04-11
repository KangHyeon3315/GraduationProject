
namespace AutoTraderGUI.Forms
{
    partial class LogViewerControl
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
            this.LogViewer = new System.Windows.Forms.ListView();
            this.InfoHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompanyHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogTextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
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
            this.LogViewer.Size = new System.Drawing.Size(872, 273);
            this.LogViewer.TabIndex = 6;
            this.LogViewer.UseCompatibleStateImageBehavior = false;
            this.LogViewer.View = System.Windows.Forms.View.Details;
            this.LogViewer.Resize += new System.EventHandler(this.ResizeEvent);
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
            // LogViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogViewer);
            this.Name = "LogViewerControl";
            this.Size = new System.Drawing.Size(872, 273);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LogViewer;
        private System.Windows.Forms.ColumnHeader InfoHeader;
        private System.Windows.Forms.ColumnHeader TimeHeader;
        private System.Windows.Forms.ColumnHeader TaskHeader;
        private System.Windows.Forms.ColumnHeader CompanyHeader;
        private System.Windows.Forms.ColumnHeader LogTextHeader;
    }
}
