
namespace AutoTraderGUI.Forms
{
    partial class HistoricalLogViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.DateList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LogViewer = new System.Windows.Forms.ListView();
            this.IndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InfoColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CompanyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LogColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DebugCheck = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LogViewer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DateList, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.DebugCheck, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(451, 34);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "날짜";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateList
            // 
            this.DateList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateList.FormattingEnabled = true;
            this.DateList.Location = new System.Drawing.Point(93, 7);
            this.DateList.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.DateList.Name = "DateList";
            this.DateList.Size = new System.Drawing.Size(183, 20);
            this.DateList.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(282, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Search);
            // 
            // LogViewer
            // 
            this.LogViewer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexColumn,
            this.InfoColumn,
            this.TimeColumn,
            this.TaskColumn,
            this.CompanyColumn,
            this.LogColumn});
            this.LogViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogViewer.FullRowSelect = true;
            this.LogViewer.HideSelection = false;
            this.LogViewer.Location = new System.Drawing.Point(3, 43);
            this.LogViewer.Name = "LogViewer";
            this.LogViewer.Size = new System.Drawing.Size(794, 404);
            this.LogViewer.TabIndex = 1;
            this.LogViewer.UseCompatibleStateImageBehavior = false;
            this.LogViewer.View = System.Windows.Forms.View.Details;
            // 
            // IndexColumn
            // 
            this.IndexColumn.Text = "Index";
            // 
            // InfoColumn
            // 
            this.InfoColumn.Text = "Info";
            // 
            // TimeColumn
            // 
            this.TimeColumn.Text = "Time";
            this.TimeColumn.Width = 120;
            // 
            // TaskColumn
            // 
            this.TaskColumn.Text = "Task";
            this.TaskColumn.Width = 120;
            // 
            // CompanyColumn
            // 
            this.CompanyColumn.Text = "Company";
            this.CompanyColumn.Width = 120;
            // 
            // LogColumn
            // 
            this.LogColumn.Text = "Log";
            this.LogColumn.Width = 360;
            // 
            // DebugCheck
            // 
            this.DebugCheck.AutoSize = true;
            this.DebugCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugCheck.Location = new System.Drawing.Point(373, 3);
            this.DebugCheck.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.DebugCheck.Name = "DebugCheck";
            this.DebugCheck.Size = new System.Drawing.Size(75, 28);
            this.DebugCheck.TabIndex = 3;
            this.DebugCheck.Text = "Debug";
            this.DebugCheck.UseVisualStyleBackColor = true;
            // 
            // HistoricalLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HistoricalLogViewer";
            this.Text = "과거 로그보기";
            this.Load += new System.EventHandler(this.ResizeEvent);
            this.Resize += new System.EventHandler(this.ResizeEvent);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DateList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView LogViewer;
        private System.Windows.Forms.ColumnHeader InfoColumn;
        private System.Windows.Forms.ColumnHeader TimeColumn;
        private System.Windows.Forms.ColumnHeader TaskColumn;
        private System.Windows.Forms.ColumnHeader CompanyColumn;
        private System.Windows.Forms.ColumnHeader LogColumn;
        private System.Windows.Forms.ColumnHeader IndexColumn;
        private System.Windows.Forms.CheckBox DebugCheck;
    }
}