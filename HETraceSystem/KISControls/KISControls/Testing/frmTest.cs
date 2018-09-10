using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestControls
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Resize(object sender, EventArgs e)
        {
            listView1.Width = this.ClientRectangle.Width - (headerPanel1.Width + 4);
            listView1.Height = (headerPanel2.Top - (listView1.Top + 4)); 
        }
    }
}