
namespace AutoTraderGUI.Forms
{
    partial class AlgorithmManager
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
            this.BasicLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ToolLayout = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.BasicLayout.SuspendLayout();
            this.ToolLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 1;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.Controls.Add(this.ToolLayout, 0, 0);
            this.BasicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicLayout.Name = "BasicLayout";
            this.BasicLayout.RowCount = 2;
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.Size = new System.Drawing.Size(1354, 849);
            this.BasicLayout.TabIndex = 0;
            // 
            // ToolLayout
            // 
            this.ToolLayout.ColumnCount = 5;
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ToolLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ToolLayout.Controls.Add(this.button1, 3, 0);
            this.ToolLayout.Controls.Add(this.button2, 4, 0);
            this.ToolLayout.Controls.Add(this.SearchTextBox, 0, 0);
            this.ToolLayout.Controls.Add(this.button3, 1, 0);
            this.ToolLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolLayout.Location = new System.Drawing.Point(0, 0);
            this.ToolLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ToolLayout.Name = "ToolLayout";
            this.ToolLayout.RowCount = 1;
            this.ToolLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ToolLayout.Size = new System.Drawing.Size(1354, 40);
            this.ToolLayout.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(957, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(194, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "알고리즘 추가하기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AlgorithmOptionManagerClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(1157, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(194, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "선택하기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.AlgorithmSelect);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Font = new System.Drawing.Font("굴림", 12F);
            this.SearchTextBox.Location = new System.Drawing.Point(3, 8);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(394, 26);
            this.SearchTextBox.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(403, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(44, 34);
            this.button3.TabIndex = 3;
            this.button3.Text = "검색";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SearchClick);
            // 
            // AlgorithmManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 849);
            this.Controls.Add(this.BasicLayout);
            this.Name = "AlgorithmManager";
            this.Text = "AlgorithmManager";
            this.BasicLayout.ResumeLayout(false);
            this.ToolLayout.ResumeLayout(false);
            this.ToolLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.TableLayoutPanel ToolLayout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button button3;
    }
}