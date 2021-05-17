using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTraderGUI.Layout
{
    public partial class Home : UserControl
    {
        public LogInterface logInterface
        {
            get
            {
                return logViewer.logInterface;
            }
        }

        public ProgressInterface progressInterface
        {
            get
            {
                return progInterface;
            }
        }

        ProgressInterface progInterface = null;
        Forms.CollectorProgressControl collectorProgress;
        Forms.AlgorithmInfoControl algorithmInfo;
        public Forms.LogViewerControl logViewer;
        Forms.EmptyControl empty;

        public Home(SettingsInterface settings)
        {
            InitializeComponent();

            collectorProgress = new Forms.CollectorProgressControl();
            algorithmInfo = new Forms.AlgorithmInfoControl();
            logViewer = new Forms.LogViewerControl(settings);
            empty = new Forms.EmptyControl("포트폴리오 표현");


            tableLayoutPanel2.ColumnStyles[0].Width = 417;            

            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.Controls.Add(collectorProgress);
            //tableLayoutPanel2.Controls.Add(new Forms.EmptyControl());
            

            progInterface = collectorProgress.progressInterface;

            splitContainer1.Panel1.Controls.Add(empty);
            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(algorithmInfo);

            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(logViewer);

            this.Dock = DockStyle.Fill;
        }
    }
}
