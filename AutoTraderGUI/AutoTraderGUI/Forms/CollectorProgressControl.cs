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
    public partial class CollectorProgressControl : UserControl, ProgressInterface
    {
        public ProgressInterface progressInterface
        {
            get
            {
                return (this as ProgressInterface);
            }
        }

        public string Task
        {
            get
            {
                return TaskInfoText.Text;
            }
            set
            {
                TaskInfoText.Text = value;
            }
        }
        public string Company
        {
            get
            {
                return CompanyText.Text;
            }
            set
            {
                CompanyText.Text = value;
            }
        }
        public int RqCount
        {
            get
            {
                return int.Parse(RqCountText.Text);
            }
            set
            {
                RqCountText.Text = value.ToString();
            }
        }
        public int CompleteCount
        {
            get
            {
                return int.Parse(CompleteCountText.Text);
            }
            set
            {
                CompleteCountText.Text = value.ToString();
            }
        }
        public int CompanyCount
        {
            get
            {
                return int.Parse(CompanyCountText.Text);
            }
            set
            {
                CompanyCountText.Text = value.ToString();
            }
        }
        public int Progress
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                progressBar1.Value = value;
            }
        }

        public Size ControlSize
        {
            get
            {
                return groupBox1.Size;
            }
        }
        public CollectorProgressControl()
        {
            InitializeComponent();
        }
    }
}
