using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dFilter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All|*.*" })
            {
                string selDirectory = ofd.FileName;
                string directory = ofd.FileName;



                if (ofd.ShowDialog() == DialogResult.OK)
                {
                  //  foreach()
                  //  {
                        try
                        {
                        textBox1.Text = directory;
                         }
                        catch
                        {

                        }
                    }
                
                }
            }
        }
    }
//}
