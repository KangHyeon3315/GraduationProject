
namespace AutoTraderGUI.Forms
{
    partial class AlgorithmInfoViewer
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
            this.SellSQL = new System.Windows.Forms.Label();
            this.BuySQL = new System.Windows.Forms.Label();
            this.AlgorithmName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.LossCut = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Distribute = new System.Windows.Forms.Label();
            this.MaxOwnDate = new System.Windows.Forms.Label();
            this.Frequency = new System.Windows.Forms.Label();
            this.BuyTiming = new System.Windows.Forms.Label();
            this.BuyTrends = new System.Windows.Forms.Label();
            this.SellTiming = new System.Windows.Forms.Label();
            this.ProfitCut = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1086, 620);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.SellSQL, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.BuySQL, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.AlgorithmName, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(543, 620);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // SellSQL
            // 
            this.SellSQL.AutoSize = true;
            this.SellSQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SellSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellSQL.Location = new System.Drawing.Point(10, 500);
            this.SellSQL.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.SellSQL.Name = "SellSQL";
            this.SellSQL.Padding = new System.Windows.Forms.Padding(10);
            this.SellSQL.Size = new System.Drawing.Size(523, 110);
            this.SellSQL.TabIndex = 7;
            this.SellSQL.Text = "SQL";
            // 
            // BuySQL
            // 
            this.BuySQL.AutoSize = true;
            this.BuySQL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BuySQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuySQL.Location = new System.Drawing.Point(10, 350);
            this.BuySQL.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.BuySQL.Name = "BuySQL";
            this.BuySQL.Padding = new System.Windows.Forms.Padding(10);
            this.BuySQL.Size = new System.Drawing.Size(523, 110);
            this.BuySQL.TabIndex = 6;
            this.BuySQL.Text = "SQL";
            // 
            // AlgorithmName
            // 
            this.AlgorithmName.AutoSize = true;
            this.AlgorithmName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlgorithmName.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AlgorithmName.Location = new System.Drawing.Point(3, 0);
            this.AlgorithmName.Name = "AlgorithmName";
            this.AlgorithmName.Size = new System.Drawing.Size(537, 40);
            this.AlgorithmName.TabIndex = 2;
            this.AlgorithmName.Text = "Name";
            this.AlgorithmName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(10, 320);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "매수 SQL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(10, 470);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "매도 SQL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label18, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.LossCut, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.Distribute, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.MaxOwnDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Frequency, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.BuyTiming, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.BuyTrends, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.SellTiming, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.ProfitCut, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(537, 274);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.Location = new System.Drawing.Point(10, 238);
            this.label18.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label18.Size = new System.Drawing.Size(180, 36);
            this.label18.TabIndex = 22;
            this.label18.Text = "손절 기준 : ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LossCut
            // 
            this.LossCut.AutoSize = true;
            this.LossCut.BackColor = System.Drawing.SystemColors.Control;
            this.LossCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LossCut.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LossCut.Location = new System.Drawing.Point(210, 238);
            this.LossCut.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.LossCut.Name = "LossCut";
            this.LossCut.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.LossCut.Size = new System.Drawing.Size(317, 36);
            this.LossCut.TabIndex = 21;
            this.LossCut.Text = "None";
            this.LossCut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(10, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label3.Size = new System.Drawing.Size(180, 34);
            this.label3.TabIndex = 7;
            this.label3.Text = "분산투자 수 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(10, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label4.Size = new System.Drawing.Size(180, 34);
            this.label4.TabIndex = 8;
            this.label4.Text = "최대 보유 일 :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(10, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label5.Size = new System.Drawing.Size(180, 34);
            this.label5.TabIndex = 9;
            this.label5.Text = "익절 기준 : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(10, 136);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label6.Size = new System.Drawing.Size(180, 34);
            this.label6.TabIndex = 10;
            this.label6.Text = "매수 시장추세 :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(10, 170);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label7.Size = new System.Drawing.Size(180, 34);
            this.label7.TabIndex = 11;
            this.label7.Text = "매도 시기 : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(10, 68);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label8.Size = new System.Drawing.Size(180, 34);
            this.label8.TabIndex = 12;
            this.label8.Text = "거래 빈도 : ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(10, 102);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label9.Size = new System.Drawing.Size(180, 34);
            this.label9.TabIndex = 13;
            this.label9.Text = "매수 시기 :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Distribute
            // 
            this.Distribute.AutoSize = true;
            this.Distribute.BackColor = System.Drawing.SystemColors.Control;
            this.Distribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Distribute.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Distribute.Location = new System.Drawing.Point(210, 0);
            this.Distribute.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Distribute.Name = "Distribute";
            this.Distribute.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Distribute.Size = new System.Drawing.Size(317, 34);
            this.Distribute.TabIndex = 14;
            this.Distribute.Text = "None";
            this.Distribute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MaxOwnDate
            // 
            this.MaxOwnDate.AutoSize = true;
            this.MaxOwnDate.BackColor = System.Drawing.SystemColors.Control;
            this.MaxOwnDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaxOwnDate.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaxOwnDate.Location = new System.Drawing.Point(210, 34);
            this.MaxOwnDate.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MaxOwnDate.Name = "MaxOwnDate";
            this.MaxOwnDate.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MaxOwnDate.Size = new System.Drawing.Size(317, 34);
            this.MaxOwnDate.TabIndex = 15;
            this.MaxOwnDate.Text = "None";
            this.MaxOwnDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frequency
            // 
            this.Frequency.AutoSize = true;
            this.Frequency.BackColor = System.Drawing.SystemColors.Control;
            this.Frequency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Frequency.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Frequency.Location = new System.Drawing.Point(210, 68);
            this.Frequency.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Frequency.Name = "Frequency";
            this.Frequency.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Frequency.Size = new System.Drawing.Size(317, 34);
            this.Frequency.TabIndex = 16;
            this.Frequency.Text = "None";
            this.Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BuyTiming
            // 
            this.BuyTiming.AutoSize = true;
            this.BuyTiming.BackColor = System.Drawing.SystemColors.Control;
            this.BuyTiming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyTiming.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BuyTiming.Location = new System.Drawing.Point(210, 102);
            this.BuyTiming.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BuyTiming.Name = "BuyTiming";
            this.BuyTiming.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BuyTiming.Size = new System.Drawing.Size(317, 34);
            this.BuyTiming.TabIndex = 17;
            this.BuyTiming.Text = "None";
            this.BuyTiming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BuyTrends
            // 
            this.BuyTrends.AutoSize = true;
            this.BuyTrends.BackColor = System.Drawing.SystemColors.Control;
            this.BuyTrends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BuyTrends.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BuyTrends.Location = new System.Drawing.Point(210, 136);
            this.BuyTrends.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BuyTrends.Name = "BuyTrends";
            this.BuyTrends.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.BuyTrends.Size = new System.Drawing.Size(317, 34);
            this.BuyTrends.TabIndex = 18;
            this.BuyTrends.Text = "None";
            this.BuyTrends.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SellTiming
            // 
            this.SellTiming.AutoSize = true;
            this.SellTiming.BackColor = System.Drawing.SystemColors.Control;
            this.SellTiming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SellTiming.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SellTiming.Location = new System.Drawing.Point(210, 170);
            this.SellTiming.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.SellTiming.Name = "SellTiming";
            this.SellTiming.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.SellTiming.Size = new System.Drawing.Size(317, 34);
            this.SellTiming.TabIndex = 19;
            this.SellTiming.Text = "None";
            this.SellTiming.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProfitCut
            // 
            this.ProfitCut.AutoSize = true;
            this.ProfitCut.BackColor = System.Drawing.SystemColors.Control;
            this.ProfitCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfitCut.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ProfitCut.Location = new System.Drawing.Point(210, 204);
            this.ProfitCut.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ProfitCut.Name = "ProfitCut";
            this.ProfitCut.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ProfitCut.Size = new System.Drawing.Size(317, 34);
            this.ProfitCut.TabIndex = 20;
            this.ProfitCut.Text = "None";
            this.ProfitCut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AlgorithmInfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 620);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlgorithmInfoViewer";
            this.Text = "AlgorithmInfoViewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label SellSQL;
        private System.Windows.Forms.Label BuySQL;
        private System.Windows.Forms.Label AlgorithmName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LossCut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Distribute;
        private System.Windows.Forms.Label MaxOwnDate;
        private System.Windows.Forms.Label Frequency;
        private System.Windows.Forms.Label BuyTiming;
        private System.Windows.Forms.Label BuyTrends;
        private System.Windows.Forms.Label SellTiming;
        private System.Windows.Forms.Label ProfitCut;
    }
}