
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
            this.BasicLayout = new System.Windows.Forms.TableLayoutPanel();
            this.CenterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OptionSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ChartLayout = new System.Windows.Forms.TableLayoutPanel();
            this.listView4 = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.financialStatementLayout = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.BasicLayout.SuspendLayout();
            this.CenterLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.ChartLayout.SuspendLayout();
            this.financialStatementLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 3;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 226F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.BasicLayout.Controls.Add(this.CenterLayout, 1, 0);
            this.BasicLayout.Controls.Add(this.financialStatementLayout, 0, 0);
            this.BasicLayout.Controls.Add(this.listView3, 2, 0);
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
            this.CenterLayout.ColumnCount = 1;
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterLayout.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.CenterLayout.Controls.Add(this.ChartLayout, 0, 1);
            this.CenterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterLayout.Location = new System.Drawing.Point(226, 0);
            this.CenterLayout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.CenterLayout.Name = "CenterLayout";
            this.CenterLayout.RowCount = 2;
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.CenterLayout.Size = new System.Drawing.Size(963, 675);
            this.CenterLayout.TabIndex = 0;
            this.CenterLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.CenterLayout_Paint);
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 41);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.Location = new System.Drawing.Point(212, 6);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(107, 29);
            this.SearchButton.TabIndex = 1;
            this.SearchButton.Text = "검색";
            this.SearchButton.UseVisualStyleBackColor = true;
            // 
            // OptionSearch
            // 
            this.OptionSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionSearch.Location = new System.Drawing.Point(779, 6);
            this.OptionSearch.Name = "OptionSearch";
            this.OptionSearch.Size = new System.Drawing.Size(178, 29);
            this.OptionSearch.TabIndex = 2;
            this.OptionSearch.Text = "조건검색";
            this.OptionSearch.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.MenuText;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 25);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("나눔고딕", 19F);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 30);
            this.textBox1.TabIndex = 0;
            // 
            // ChartLayout
            // 
            this.ChartLayout.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ChartLayout.ColumnCount = 2;
            this.ChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ChartLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.ChartLayout.Controls.Add(this.listView4, 0, 0);
            this.ChartLayout.Controls.Add(this.toolStrip1, 1, 0);
            this.ChartLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartLayout.Location = new System.Drawing.Point(0, 41);
            this.ChartLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ChartLayout.Name = "ChartLayout";
            this.ChartLayout.RowCount = 1;
            this.ChartLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ChartLayout.Size = new System.Drawing.Size(963, 634);
            this.ChartLayout.TabIndex = 2;
            // 
            // listView4
            // 
            this.listView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(0, 0);
            this.listView4.Margin = new System.Windows.Forms.Padding(0);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(922, 634);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(922, 1);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(41, 632);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // financialStatementLayout
            // 
            this.financialStatementLayout.ColumnCount = 1;
            this.financialStatementLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.financialStatementLayout.Controls.Add(this.listView1, 0, 1);
            this.financialStatementLayout.Controls.Add(this.listView2, 0, 0);
            this.financialStatementLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.financialStatementLayout.Location = new System.Drawing.Point(0, 0);
            this.financialStatementLayout.Margin = new System.Windows.Forms.Padding(0);
            this.financialStatementLayout.Name = "financialStatementLayout";
            this.financialStatementLayout.RowCount = 2;
            this.financialStatementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.financialStatementLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.financialStatementLayout.Size = new System.Drawing.Size(226, 678);
            this.financialStatementLayout.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 339);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(224, 337);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(2, 0);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(224, 339);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(1189, 0);
            this.listView3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(184, 675);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ChartLayout.ResumeLayout(false);
            this.ChartLayout.PerformLayout();
            this.financialStatementLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.TableLayoutPanel CenterLayout;
        private System.Windows.Forms.TableLayoutPanel financialStatementLayout;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button OptionSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel ChartLayout;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ToolStrip toolStrip1;
    }
}
