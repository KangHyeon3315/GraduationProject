﻿
namespace AutoTraderGUI.Forms
{
    partial class Simulate
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
            this.button1 = new System.Windows.Forms.Button();
            this.BasicLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasicLayout
            // 
            this.BasicLayout.ColumnCount = 2;
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.BasicLayout.Controls.Add(this.button1, 1, 0);
            this.BasicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BasicLayout.Location = new System.Drawing.Point(0, 0);
            this.BasicLayout.Name = "BasicLayout";
            this.BasicLayout.RowCount = 2;
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.BasicLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BasicLayout.Size = new System.Drawing.Size(1020, 591);
            this.BasicLayout.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(723, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "알고리즘 추가 및 선택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.AlgorithmManageClick);
            // 
            // Simulate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasicLayout);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Simulate";
            this.Size = new System.Drawing.Size(1020, 591);
            this.BasicLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BasicLayout;
        private System.Windows.Forms.Button button1;
    }
}
