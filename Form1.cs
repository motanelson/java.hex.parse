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
            String[] s = textBox1.Text.Split('\n');
            String ss = "";
            int a = 0;
            String args = "";

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = s[i].Trim();
                s[i] = s[i].Replace("\n", "");
                textBox2.Text = textBox2.Text + s[i] + "\r\n";
                args = s[i];
                try
                {
                    if (s[i] != "") Process.Start(s[i]);




                }
                catch (Exception ex)
                {



                    // Configure the process start info
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",              // Run CMD
                        Arguments = "/c " + args,       // /c = run command and exit
                        RedirectStandardOutput = true,     // Capture output
                        RedirectStandardError = true,      // Capture errors
                        UseShellExecute = false,           // Required for redirection
                        CreateNoWindow = true              // Hide CMD window
                    };
                    using (Process process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();

                        // Read the output and errors
                        string output = process.StandardOutput.ReadToEnd();
                        string errors = process.StandardError.ReadToEnd();

                        process.WaitForExit();

                        // Display results

                        textBox2.Text = textBox2.Text + output + "\n";
                        textBox2.Text = textBox2.Text + errors + "\n";

                    }

                }
            }
                
                


            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
