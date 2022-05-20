using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

                string[] keywordnew = { "Setup", "setup", "Installer", "Downloader", "downloader", "install", "set-up" };
  
                directory = fbd.SelectedPath;
                textBox1.Text = directory;
                var filesEx = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".exe"));

                foreach (string FilesE in filesEx)
                {
                    foreach(string keyword in keywordnew)
                    {
                        if (FilesE.Contains(keyword))
                        {
                            listView1.Items.Add(FilesE + Environment.NewLine);
                            button2.Visible = true;
                        }
                    }
                }
            }
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            CreateFileMover();
            // Need to get the variables from Button1.
        }
        
        public static string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dFilter\\";
        public static void CreateFileMover()
        {
            if (Directory.Exists(desktopDir))
            {
             //   MessageBox.Show("Unable to create the output folder since it already exists.", "dFilter");
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(desktopDir);
                }
                 catch
                {
                 //   MessageBox.Show("Error while creating output directory.", "dFilter");
                }
            }

        }

        public static void DeleteFiles()
        {
            try
            {
                Directory.Delete(desktopDir);
                MessageBox.Show("The files inside of the output folder have been deleted.", "dFilter");
            }
            catch
            {
                MessageBox.Show("An error occurred.", "dFilter");
            }

        }
    }
}
