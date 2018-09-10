using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HETraceSystem.Control
{
    public partial class ProgressBarEx : UserControl
    {

        private string _strInfo;

        public int _nvalue;

        private int _BMaxValue;

        private delegate void DelegateSetVlaue();

        public int ProgressValue
        {

            set
            {
                _nvalue = value;
                DoRefreshStatusBar();
            }
   
        }

        public string ProgressInfo
        {
            get { return _strInfo; }
            set { _strInfo = value;
               }
        }


        public ProgressBarEx()
        {
            InitializeComponent();
   

        }


        public void SetProgerssInfo(int nvalue,string info)
        {
            _nvalue = nvalue;
            _strInfo = info;
            DoRefreshStatusBar();
        }

        // 更改textBox的文字显示
        public void setProgressBarTextbox(String str)
        {
            this.textBox1.Text = str;
            //this.Invalidate();
        }


        private void DoRefreshStatusBar()
        {
            if (this.InvokeRequired)
                this.Invoke(new DelegateSetVlaue(RefreshValue));
            else
            {
                this.progressBar1.Value = _nvalue;
                this.textBox1.Text = _strInfo;
                this.Refresh();
            }
        }


        private void RefreshValue()
        {

            this.progressBar1.Value = _nvalue;
            this.textBox1.Text=_strInfo;
            this.Refresh();
        }
      
    }
}
