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
            CreateFileMover();
            string directory = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string keywords = "setup";
                string[] keywordnew = { "setup", "installer", "install" };

                directory = fbd.SelectedPath;
                textBox1.Text = directory;
                var filesEx = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".exe"));

                foreach (string FilesE in filesEx)
                {
                    if (FilesE.Contains(keywords))
                    {
                        listView1.Items.Add(FilesE + Environment.NewLine);
                        try
                        {
                            File.Move(FilesE, desktopDir + Path.GetFileName(FilesE));
                        }
                        catch(Exception ex)
                        {
                            Debug.Print("Unable to move. " + ex.Message);
                        }
                       
                    }
                 
                }
       


            }
        }
        public static string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dFilter\\";
        public static void CreateFileMover()
        {
            if (Directory.Exists(desktopDir))
            {
                MessageBox.Show("Unable to create a folder on the desktop since it already exists.");
            }
            else
            {
                Directory.CreateDirectory(desktopDir);
            }

        }

        public static void DeleteFiles()
        {
            try
            {
                Directory.Delete(desktopDir);
                MessageBox.Show("The files inside of the dFilter output folder have been deleted.");
            }
            catch
            {
                MessageBox.Show("An error occurred.");
            }

        }

    }
}
