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
    public partial class Simulate : UserControl
    {
        Forms.AlgorithmManager algorithmManager;
        public Simulate()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            
        }

        private void AlgorithmManageClick(object sender, EventArgs e)
        {
            algorithmManager = new Forms.AlgorithmManager();
            algorithmManager.Show();
        }
    }
}
