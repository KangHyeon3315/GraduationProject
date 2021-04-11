using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTraderGUI.Forms
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
        CollectorProgressControl collectorProgress;
        AlgorithmInfoControl algorithmInfo;
        LogViewerControl logViewer;
        public Home()
        {
            InitializeComponent();

            collectorProgress = new CollectorProgressControl();
            algorithmInfo = new AlgorithmInfoControl();
            logViewer = new LogViewerControl();

            tableLayoutPanel2.ColumnStyles[1].Width = 417;

            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.Controls.Add(new EmptyControl());
            tableLayoutPanel2.Controls.Add(collectorProgress);

            progInterface = collectorProgress.progressInterface;

            splitContainer2.Panel1.Controls.Clear();
            splitContainer2.Panel1.Controls.Add(algorithmInfo);

            splitContainer2.Panel2.Controls.Clear();
            splitContainer2.Panel2.Controls.Add(logViewer);

            this.Dock = DockStyle.Fill;
        }
    }
}
