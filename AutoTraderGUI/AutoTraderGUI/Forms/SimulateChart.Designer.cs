
namespace AutoTraderGUI.Forms
{
    partial class SimulateChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EvaluationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MDDChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.YieldChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ProfitLossChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DistChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MFEMAEChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MDDChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YieldChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitLossChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFEMAEChart)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.MFEMAEChart, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.DistChart, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProfitLossChart, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.YieldChart, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MDDChart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.EvaluationChart, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 615);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // EvaluationChart
            // 
            chartArea6.Name = "ChartArea1";
            this.EvaluationChart.ChartAreas.Add(chartArea6);
            this.EvaluationChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EvaluationChart.Location = new System.Drawing.Point(3, 3);
            this.EvaluationChart.Name = "EvaluationChart";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Name = "Series1";
            this.EvaluationChart.Series.Add(series8);
            this.EvaluationChart.Size = new System.Drawing.Size(457, 198);
            this.EvaluationChart.TabIndex = 0;
            this.EvaluationChart.Text = "chart1";
            // 
            // MDDChart
            // 
            chartArea5.Name = "ChartArea1";
            this.MDDChart.ChartAreas.Add(chartArea5);
            this.MDDChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MDDChart.Location = new System.Drawing.Point(466, 3);
            this.MDDChart.Name = "MDDChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Name = "Series1";
            this.MDDChart.Series.Add(series7);
            this.MDDChart.Size = new System.Drawing.Size(458, 198);
            this.MDDChart.TabIndex = 1;
            this.MDDChart.Text = "chart1";
            // 
            // YieldChart
            // 
            chartArea4.Name = "ChartArea1";
            this.YieldChart.ChartAreas.Add(chartArea4);
            this.YieldChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YieldChart.Location = new System.Drawing.Point(3, 207);
            this.YieldChart.Name = "YieldChart";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "Series1";
            this.YieldChart.Series.Add(series6);
            this.YieldChart.Size = new System.Drawing.Size(457, 198);
            this.YieldChart.TabIndex = 2;
            this.YieldChart.Text = "chart1";
            // 
            // ProfitLossChart
            // 
            chartArea3.Name = "ChartArea1";
            this.ProfitLossChart.ChartAreas.Add(chartArea3);
            this.ProfitLossChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfitLossChart.Location = new System.Drawing.Point(466, 207);
            this.ProfitLossChart.Name = "ProfitLossChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.OrangeRed;
            series4.Name = "Profit";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.CornflowerBlue;
            series5.Name = "Loss";
            this.ProfitLossChart.Series.Add(series4);
            this.ProfitLossChart.Series.Add(series5);
            this.ProfitLossChart.Size = new System.Drawing.Size(458, 198);
            this.ProfitLossChart.TabIndex = 3;
            this.ProfitLossChart.Text = "chart1";
            // 
            // DistChart
            // 
            chartArea2.Name = "ChartArea1";
            this.DistChart.ChartAreas.Add(chartArea2);
            this.DistChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistChart.Location = new System.Drawing.Point(3, 411);
            this.DistChart.Name = "DistChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "Series1";
            this.DistChart.Series.Add(series3);
            this.DistChart.Size = new System.Drawing.Size(457, 201);
            this.DistChart.TabIndex = 4;
            this.DistChart.Text = "chart1";
            // 
            // MFEMAEChart
            // 
            chartArea1.Name = "ChartArea1";
            this.MFEMAEChart.ChartAreas.Add(chartArea1);
            this.MFEMAEChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MFEMAEChart.Location = new System.Drawing.Point(466, 411);
            this.MFEMAEChart.Name = "MFEMAEChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.OrangeRed;
            series1.Name = "MFE";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.CornflowerBlue;
            series2.Name = "MAE";
            this.MFEMAEChart.Series.Add(series1);
            this.MFEMAEChart.Series.Add(series2);
            this.MFEMAEChart.Size = new System.Drawing.Size(458, 201);
            this.MFEMAEChart.TabIndex = 5;
            this.MFEMAEChart.Text = "chart1";
            // 
            // SimulateChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SimulateChart";
            this.Size = new System.Drawing.Size(927, 615);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EvaluationChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MDDChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YieldChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProfitLossChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MFEMAEChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart EvaluationChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart MFEMAEChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart DistChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ProfitLossChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart YieldChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart MDDChart;
    }
}
