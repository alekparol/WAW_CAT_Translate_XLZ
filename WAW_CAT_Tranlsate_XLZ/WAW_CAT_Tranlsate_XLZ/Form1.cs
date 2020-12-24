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

namespace WAW_CAT_Tranlsate_XLZ
{
    public partial class TranslateXLZ : Form
    {
        public TranslateXLZ()
        {
            InitializeComponent();

            listSourceFiles.AllowDrop = true;
            listSourceFiles.DragDrop += listSourceFiles_DragDrop;
            listSourceFiles.DragEnter += listFiles_DragEnter;

            listTargetFiles.AllowDrop = true;
            listTargetFiles.DragDrop += listTargetFiles_DragDrop;
            listTargetFiles.DragEnter += listFiles_DragEnter;

            listXLZFiles.AllowDrop = true;
            listXLZFiles.DragDrop += listXLZFiles_DragDrop;
            listXLZFiles.DragEnter += listFiles_DragEnter;

        }

        private void listFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listSourceFiles_DragDrop(object sender, DragEventArgs e)
        {

            List<string> files = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    files.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    files.Add(s);
                }
            }

            foreach (string file in files)
                listSourceFiles.Items.Add(file);
        }

        private void listTargetFiles_DragDrop(object sender, DragEventArgs e)
        {
            List<string> files = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    files.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    files.Add(s);
                }
            }

            foreach (string file in files)
                listTargetFiles.Items.Add(file);
        }

        private void listXLZFiles_DragDrop(object sender, DragEventArgs e)
        {
            List<string> files = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    files.AddRange(Directory.GetFiles(s));
                }
                else
                {
                    files.Add(s);
                }
            }

            foreach (string file in files)
                listXLZFiles.Items.Add(file);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listTargetFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listXLZFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void readSourceFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                listSourceFiles.Items.Clear();

                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.html", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    listSourceFiles.Items.Add(file);
                }
            }
        }

        private void readTargetFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                listTargetFiles.Items.Clear();

                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.html", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    listTargetFiles.Items.Add(file);
                }
            }
        }

        private void readXLZFiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                listXLZFiles.Items.Clear();

                string[] files = Directory.GetFiles(FBD.SelectedPath, "*.xlz", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    listXLZFiles.Items.Add(file);
                }
            }
        }

        private void clearSourceFiles_Click(object sender, EventArgs e)
        {
            listSourceFiles.Items.Clear();
            MessageBox.Show("The list of source files was cleared.");
        }

        private void clearTargetFiles_Click(object sender, EventArgs e)
        {
            listTargetFiles.Items.Clear();
            MessageBox.Show("The list of source files was cleared.");
        }

        private void clearXLZFiles_Click(object sender, EventArgs e)
        {
            listXLZFiles.Items.Clear();
            MessageBox.Show("The list of source files was cleared.");
        }

        private void translateFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
