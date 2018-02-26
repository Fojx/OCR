using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Ocr37
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filetoconvert = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = filetoconvert;
                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                    var action = ocr.Process(filetoconvert);
                    textBox1.Text = action.GetText();
                    status.Text = "OCR Complete !";
                    status.ForeColor = System.Drawing.Color.Green;
                }
                catch
                {
                    status.Text = "Error can't load image please try again !";
                    status.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/fojx");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }
    }
}
