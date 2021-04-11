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
    public partial class EmptyControl : UserControl
    {
        public EmptyControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }
    }
}
