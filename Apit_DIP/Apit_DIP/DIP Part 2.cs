using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Apit_DIP
{
    public partial class DIP_Part_2 : Form
    {
        Bitmap imageA, imageB, subtracted;
        public DIP_Part_2()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = imageB;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = imageA;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subtracted =  new Bitmap(imageB.Width, imageB.Height);

            Color solidGreen = Color.FromArgb(0, 255, 0);
            int greyGreen = (solidGreen.R + solidGreen.B + solidGreen.G) / 3;
            int threshold = 5;

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);

                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractionValue = Math.Abs(grey - greyGreen);

                    if (subtractionValue < threshold)
                        subtracted.SetPixel(x, y, backpixel);
                    else
                        subtracted.SetPixel(x, y, pixel);
                }
            }

            pictureBox3.Image = subtracted;
        }

        private void dIP1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
