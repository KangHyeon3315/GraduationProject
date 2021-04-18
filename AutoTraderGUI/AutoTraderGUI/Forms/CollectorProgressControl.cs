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
        delegate void SetTextCallback(string text);
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
                if(this.TaskInfoText.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetTask);
                    this.Invoke(d, new object[] { value });
                }
                else
                {
                    SetTask(value);
                }
            }
        }
        void SetTask(string text)
        {
            TaskInfoText.Text = text;
        }
        public string Company
        {
            get
            {
                return CompanyText.Text;
            }
            set
            {
                if (this.CompanyText.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetCompany);
                    this.Invoke(d, new object[] { value });
                }
                else
                {
                    SetCompany(value);
                }
            }
        }
        void SetCompany(string text)
        {
            CompanyText.Text = text;
        }
        public int RqCount
        {
            get
            {
                return int.Parse(RqCountText.Text);
            }
            set
            {
                if (this.RqCountText.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetRqCount);
                    this.Invoke(d, new object[] { value.ToString() });
                }
                else
                {
                    SetRqCount(value.ToString());
                }    
            }
        }
        void SetRqCount(string text)
        {
            RqCountText.Text = text;
        }
        public int CompleteCount
        {
            get
            {
                return int.Parse(CompleteCountText.Text);
            }
            set
            {
                if (this.CompleteCountText.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetCompleteCount);
                    this.Invoke(d, new object[] { value.ToString() });
                }
                else
                {
                    SetCompleteCount(value.ToString());
                }
            }
        }
        void SetCompleteCount(string text)
        {
            CompleteCountText.Text = text;
        }
        public int CompanyCount
        {
            get
            {
                return int.Parse(CompanyCountText.Text);
            }
            set
            {
                if (this.CompanyCountText.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetCompanyCount);
                    this.Invoke(d, new object[] { value.ToString() });
                }
                else
                {
                    SetCompanyCount(value.ToString());
                }

            }
        }
        void SetCompanyCount(string text)
        {
            CompanyCountText.Text = text;
        }
        public int Progress
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                if (this.progressBar1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetProgress);
                    this.Invoke(d, new object[] { value.ToString() });
                }
                else
                {
                    SetProgress(value.ToString());
                }
            }
        }
        void SetProgress(string value)
        {
            try
            {
                progressBar1.Value = int.Parse(value);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                progressBar1.Value = 0;
            }
        }

        public Size ControlSize
        {
            get
            {
                return groupBox1.Size;
            }
        }
        public string Title
        {
            get
            {
                return groupBox1.Text;
            }
            set
            {
                groupBox1.Text = value;
            }
        }
        public CollectorProgressControl()
        {
            InitializeComponent();
        }
    }
}
