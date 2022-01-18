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

namespace dFilter {
  public partial class Form1: Form {
    public Form1() {
      InitializeComponent();
    }

    public static string directory;
    private void button1_Click(object sender, EventArgs e) {
      string directory = "";
      FolderBrowserDialog fbd = new FolderBrowserDialog();

      if (fbd.ShowDialog() == DialogResult.OK) {
        directory = fbd.SelectedPath;
        textBox1.Text = directory;
        var filesEx = Directory.GetFiles(directory, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".exe"));

        foreach(FileInfo FilesE in filesEx) {
          string PathDir = FilesE.FullName;
          listView1.Items.Add(PathDir + Environment.NewLine);
        }
      }
    }

    public static void CreateFileMover() {
      string desktopDir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\dFilter\\";
      // This creates a folder on the desktop to move all of the detected files into.

      if (Directory.Exists(desktopDir)) {
        MessageBox.Show("Unable to create a folder on the desktop since it already exists.");
      } else {
        Directory.CreateDirectory(desktopDir);
      }

    }

    public static void DeleteFiles() {
      try {
        Directory.Delete(desktopDir); // this code errors, will fix later.
        MessageBox.Show("The files inside of the dFilter output folder have been deleted.");
      } catch {
        MessageBox.Show("An error occurred.");
      }

    }

  }
}
