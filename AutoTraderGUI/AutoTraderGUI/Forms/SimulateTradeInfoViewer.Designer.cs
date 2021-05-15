
namespace AutoTraderGUI.Forms
{
    partial class SimulateTradeInfoViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.TradeInfoCombo = new System.Windows.Forms.ComboBox();
            this.InfoPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ActionText = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.MAEText = new System.Windows.Forms.Label();
            this.MFEText = new System.Windows.Forms.Label();
            this.MDDText = new System.Windows.Forms.Label();
            this.YieldText = new System.Windows.Forms.Label();
            this.SellPriceText = new System.Windows.Forms.Label();
            this.SellDateText = new System.Windows.Forms.Label();
            this.BuyPriceText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.BuyDateText = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NextButton);
            this.panel1.Controls.Add(this.prevButton);
            this.panel1.Controls.Add(this.TradeInfoCombo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 58);
            this.panel1.TabIndex = 1;
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold);
            this.NextButton.Location = new System.Drawing.Point(784, 12);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(30, 29);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.prevButton.Location = new System.Drawing.Point(748, 12);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(30, 29);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "<";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // TradeInfoCombo
            // 
            this.TradeInfoCombo.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.TradeInfoCombo.FormattingEnabled = true;
            this.TradeInfoCombo.Location = new System.Drawing.Point(12, 12);
            this.TradeInfoCombo.Name = "TradeInfoCombo";
            this.TradeInfoCombo.Size = new System.Drawing.Size(730, 29);
            this.TradeInfoCombo.TabIndex = 0;
            this.TradeInfoCombo.SelectedIndexChanged += new System.EventHandler(this.TradeInfoCombo_SelectedIndexChanged);
            // 
            // InfoPanel
            // 
            this.InfoPanel.ColumnCount = 2;
            this.InfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.InfoPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InfoPanel.Controls.Add(this.ActionText, 1, 0);
            this.InfoPanel.Controls.Add(this.label9, 0, 0);
            this.InfoPanel.Controls.Add(this.MAEText, 1, 8);
            this.InfoPanel.Controls.Add(this.MFEText, 1, 7);
            this.InfoPanel.Controls.Add(this.MDDText, 1, 6);
            this.InfoPanel.Controls.Add(this.YieldText, 1, 5);
            this.InfoPanel.Controls.Add(this.SellPriceText, 1, 4);
            this.InfoPanel.Controls.Add(this.SellDateText, 1, 3);
            this.InfoPanel.Controls.Add(this.BuyPriceText, 1, 2);
            this.InfoPanel.Controls.Add(this.label1, 0, 1);
            this.InfoPanel.Controls.Add(this.label2, 0, 2);
            this.InfoPanel.Controls.Add(this.label3, 0, 3);
            this.InfoPanel.Controls.Add(this.label4, 0, 4);
            this.InfoPanel.Controls.Add(this.label5, 0, 5);
            this.InfoPanel.Controls.Add(this.label6, 0, 6);
            this.InfoPanel.Controls.Add(this.label7, 0, 7);
            this.InfoPanel.Controls.Add(this.label8, 0, 8);
            this.InfoPanel.Controls.Add(this.BuyDateText, 1, 1);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoPanel.Location = new System.Drawing.Point(985, 58);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.RowCount = 10;
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.InfoPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.InfoPanel.Size = new System.Drawing.Size(267, 649);
            this.InfoPanel.TabIndex = 2;
            // 
            // ActionText
            // 
            this.ActionText.AutoSize = true;
            this.ActionText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActionText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.ActionText.Location = new System.Drawing.Point(111, 0);
            this.ActionText.Name = "ActionText";
            this.ActionText.Size = new System.Drawing.Size(153, 50);
            this.ActionText.TabIndex = 17;
            this.ActionText.Text = "None";
            this.ActionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 50);
            this.label9.TabIndex = 16;
            this.label9.Text = "행동 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MAEText
            // 
            this.MAEText.AutoSize = true;
            this.MAEText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAEText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MAEText.Location = new System.Drawing.Point(111, 400);
            this.MAEText.Name = "MAEText";
            this.MAEText.Size = new System.Drawing.Size(153, 50);
            this.MAEText.TabIndex = 15;
            this.MAEText.Text = "0%";
            this.MAEText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MFEText
            // 
            this.MFEText.AutoSize = true;
            this.MFEText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MFEText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MFEText.Location = new System.Drawing.Point(111, 350);
            this.MFEText.Name = "MFEText";
            this.MFEText.Size = new System.Drawing.Size(153, 50);
            this.MFEText.TabIndex = 14;
            this.MFEText.Text = "0%";
            this.MFEText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MDDText
            // 
            this.MDDText.AutoSize = true;
            this.MDDText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MDDText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.MDDText.Location = new System.Drawing.Point(111, 300);
            this.MDDText.Name = "MDDText";
            this.MDDText.Size = new System.Drawing.Size(153, 50);
            this.MDDText.TabIndex = 13;
            this.MDDText.Text = "0%";
            this.MDDText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YieldText
            // 
            this.YieldText.AutoSize = true;
            this.YieldText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YieldText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.YieldText.Location = new System.Drawing.Point(111, 250);
            this.YieldText.Name = "YieldText";
            this.YieldText.Size = new System.Drawing.Size(153, 50);
            this.YieldText.TabIndex = 12;
            this.YieldText.Text = "0%";
            this.YieldText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SellPriceText
            // 
            this.SellPriceText.AutoSize = true;
            this.SellPriceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellPriceText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.SellPriceText.Location = new System.Drawing.Point(111, 200);
            this.SellPriceText.Name = "SellPriceText";
            this.SellPriceText.Size = new System.Drawing.Size(153, 50);
            this.SellPriceText.TabIndex = 11;
            this.SellPriceText.Text = "0000";
            this.SellPriceText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SellDateText
            // 
            this.SellDateText.AutoSize = true;
            this.SellDateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellDateText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.SellDateText.Location = new System.Drawing.Point(111, 150);
            this.SellDateText.Name = "SellDateText";
            this.SellDateText.Size = new System.Drawing.Size(153, 50);
            this.SellDateText.TabIndex = 10;
            this.SellDateText.Text = "0000-00-00";
            this.SellDateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuyPriceText
            // 
            this.BuyPriceText.AutoSize = true;
            this.BuyPriceText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyPriceText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.BuyPriceText.Location = new System.Drawing.Point(111, 100);
            this.BuyPriceText.Name = "BuyPriceText";
            this.BuyPriceText.Size = new System.Drawing.Size(153, 50);
            this.BuyPriceText.TabIndex = 9;
            this.BuyPriceText.Text = "0000";
            this.BuyPriceText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(3, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "구매일 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "구매금액 :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "판매일 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.Location = new System.Drawing.Point(3, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 50);
            this.label4.TabIndex = 3;
            this.label4.Text = "판매금액 :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.Location = new System.Drawing.Point(3, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "수익률 :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label6.Location = new System.Drawing.Point(3, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 50);
            this.label6.TabIndex = 5;
            this.label6.Text = "MDD :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label7.Location = new System.Drawing.Point(3, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 50);
            this.label7.TabIndex = 6;
            this.label7.Text = "MFE :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label8.Location = new System.Drawing.Point(3, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 50);
            this.label8.TabIndex = 7;
            this.label8.Text = "MAE : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuyDateText
            // 
            this.BuyDateText.AutoSize = true;
            this.BuyDateText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyDateText.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.BuyDateText.Location = new System.Drawing.Point(111, 50);
            this.BuyDateText.Name = "BuyDateText";
            this.BuyDateText.Size = new System.Drawing.Size(153, 50);
            this.BuyDateText.TabIndex = 8;
            this.BuyDateText.Text = "0000-00-00";
            this.BuyDateText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 58);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.MarkerBorderWidth = 0;
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.Red;
            series2.MarkerBorderColor = System.Drawing.Color.Black;
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.MarkerSize = 10;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "BuySell";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(985, 649);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // SimulateTradeInfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 707);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.InfoPanel);
            this.Controls.Add(this.panel1);
            this.Name = "SimulateTradeInfoViewer";
            this.Text = "SimulateTradeInfoViewer";
            this.panel1.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.ComboBox TradeInfoCombo;
        private System.Windows.Forms.TableLayoutPanel InfoPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label MAEText;
        private System.Windows.Forms.Label MFEText;
        private System.Windows.Forms.Label MDDText;
        private System.Windows.Forms.Label YieldText;
        private System.Windows.Forms.Label SellPriceText;
        private System.Windows.Forms.Label SellDateText;
        private System.Windows.Forms.Label BuyPriceText;
        private System.Windows.Forms.Label BuyDateText;
        private System.Windows.Forms.Label ActionText;
        private System.Windows.Forms.Label label9;
    }
}