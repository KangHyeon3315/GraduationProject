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
    public partial class AlgorithmInfoControl : UserControl
    {
        public AlgorithmInfoControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void ResizeEvent(object sender, EventArgs e)
        {
            int totalWidth = AlgorithmInfo.Size.Width;
            int restWidth = totalWidth;
            AlgorithmInfo.Columns[0].Width = 90;            // Algorithm Number
            restWidth -= AlgorithmInfo.Columns[0].Width;

            int temp = restWidth / 5;

            AlgorithmInfo.Columns[1].Width = temp;
            restWidth -= AlgorithmInfo.Columns[1].Width;

            AlgorithmInfo.Columns[2].Width = temp;
            restWidth -= AlgorithmInfo.Columns[2].Width;

            AlgorithmInfo.Columns[3].Width = temp;
            restWidth -= AlgorithmInfo.Columns[3].Width;

            AlgorithmInfo.Columns[4].Width = temp;
            restWidth -= AlgorithmInfo.Columns[4].Width;

            AlgorithmInfo.Columns[5].Width = restWidth;
        }
    }
}
