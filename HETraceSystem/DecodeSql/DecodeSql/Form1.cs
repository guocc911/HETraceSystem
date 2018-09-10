using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecodeSql
{
    public partial class 配置 : Form
    {
        public 配置()
        {
            InitializeComponent();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
          
            openFileDialog.Filter = "SQL文件|*.sql";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {


                    this.textBox1.Text = openFileDialog.FileName.Trim();


                    FileInfo info = new FileInfo(this.textBox1.Text);

                    using (StreamWriter sw = new StreamWriter(info.DirectoryName + "\\new.sql"))
                    {
                        using (StreamReader sr = new StreamReader(info.FullName))
                        {
                            while (sr.Peek() >= 0)
                            {
                                char code = (char)sr.Read();

                                if (code.Equals(']'))
                                {
                                    sw.Write(code);
                                    sw.WriteLine(this.textBox2.Text.Trim());
                                }
                                else
                                    sw.Write(code);
                            }
                        }
                    }
                    MessageBox.Show("转换完成");
                  }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
