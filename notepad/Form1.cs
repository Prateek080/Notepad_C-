using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // text.Text = "";
            text.ResetText();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgopen = new OpenFileDialog();
            dlgopen.ShowDialog();
            using (StreamReader sr = new StreamReader(dlgopen.FileName))
            {
                while (sr.EndOfStream != true)
                {
                    text.Text = text.Text+Environment.NewLine + sr.ReadLine();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] textlines=text.Lines;
            SaveFileDialog dlgsave = new SaveFileDialog();
            dlgsave.ShowDialog();
            using (StreamWriter sw = new StreamWriter(dlgsave.FileName))
            {
                for (int i = 0; i < textlines.GetUpperBound(0) + 1; i++)
                {
                    sw.WriteLine(textlines[i]);
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text.Copy();
            text.Cut();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            text.Copy();
            text.Paste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(" "+e.KeyChar);
        }
    }
}
