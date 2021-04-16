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

        public ProgressInterface DartprogressInterface
        {
            get
            {
                return DartprogInterface;
            }
        }

        ProgressInterface progInterface = null;
        ProgressInterface DartprogInterface = null;
        Forms.CollectorProgressControl collectorProgress;
        Forms.CollectorProgressControl dartcollectorProgress;
        Forms.AlgorithmInfoControl algorithmInfo;
        public Forms.LogViewerControl logViewer;

        public Home()
        {
            InitializeComponent();

            collectorProgress = new Forms.CollectorProgressControl("API Collector");
            dartcollectorProgress = new Forms.CollectorProgressControl("Dairt Collector");
            algorithmInfo = new Forms.AlgorithmInfoControl();
            logViewer = new Forms.LogViewerControl();

            tableLayoutPanel2.ColumnStyles[1].Width = 417;
            tableLayoutPanel2.ColumnStyles[2].Width = 417;

            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.Controls.Add(new Forms.EmptyControl());
            tableLayoutPanel2.Controls.Add(collectorProgress);
            tableLayoutPanel2.Controls.Add(dartcollectorProgress);

            progInterface = collectorProgress.progressInterface;
            DartprogInterface = dartcollectorProgress.progressInterface;

            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(algorithmInfo);

            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(logViewer);

            this.Dock = DockStyle.Fill;
        }
    }
}
