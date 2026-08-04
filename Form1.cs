using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace shells
{
    public partial class Form1 : Form
    {
        private string files = "new.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s =Application.ExecutablePath;
            openFileDialog1.InitialDirectory = s;
            s = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "open shell script";
            openFileDialog1.CheckFileExists = true;

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                files = openFileDialog1.FileName;
                s =File.ReadAllText(openFileDialog1.FileName);
                textBox1.Text = s;
            }
           

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = Application.ExecutablePath;
            openFileDialog1.InitialDirectory = s;
            s = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "save shell script";
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                File.WriteAllText(openFileDialog1.FileName,textBox1.Text);
                
            }


        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = Application.ExecutablePath;
            openFileDialog1.InitialDirectory = s;
            s = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "save shell script";
            openFileDialog1.CheckFileExists = false;

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                File.WriteAllText(openFileDialog1.FileName, textBox1.Text);

            }
            textBox1.Text = "";


        }

        private void clearMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void saveMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = Application.ExecutablePath;
            openFileDialog1.InitialDirectory = s;
            s = "";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "save shell script";
            openFileDialog1.CheckFileExists = false;

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                File.WriteAllText(openFileDialog1.FileName, textBox2.Text);

            }
           

        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] s =textBox1.Text.Split('\n');
            try

            {
                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = s[i].Trim();
                    s[i] = s[i].Replace("\n","");
                    textBox2.Text=textBox2.Text + s[i]+"\r\n";
                    if (s[i]!="")Process.Start(s[i]);
                }
                

            }
            catch (Exception ex)
            {
                textBox2.Text=textBox2.Text + ex.Message+"\r\n";
            }
                

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
