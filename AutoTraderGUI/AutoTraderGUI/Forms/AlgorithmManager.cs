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
    public partial class AlgorithmManager : Form
    {
        Forms.AlgorithmInfoControl algorithmInfo;
        Forms.AlgorithmCreate algorithmCreate;
        public AlgorithmManager()
        {
            InitializeComponent();

            this.CenterToParent();

            algorithmInfo = new Forms.AlgorithmInfoControl();

            BasicLayout.Controls.Clear();
            BasicLayout.Controls.Add(ToolLayout);
            BasicLayout.Controls.Add(algorithmInfo);
        }

        private void AlgorithmOptionManagerClick(object sender, EventArgs e)
        {
            algorithmCreate = new Forms.AlgorithmCreate();
            algorithmCreate.Show();
        }
    }
}
