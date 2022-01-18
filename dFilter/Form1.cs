using Microsoft.VisualBasic;
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
            string directory = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                directory = fbd.SelectedPath;
                textBox1.Text = directory;
                var filesEx = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".exe"));

                foreach (FileInfo FilesE in filesEx)
                {
                    string PathDir = FilesE.FullName;
                    listView1.Items.Add(PathDir + Environment.NewLine);
                }
            }
        }
    }
}
