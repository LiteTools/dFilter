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


       public static string directory;
        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {

                 directory = fbd.SelectedPath;



                if (fbd.ShowDialog() == DialogResult.OK)
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
