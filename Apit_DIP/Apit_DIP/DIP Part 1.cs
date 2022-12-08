using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apit_DIP
{
    public partial class Form1 : Form
    {
        Bitmap input, result;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            input = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = input;
        }

        private void greyscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = new Bitmap(input.Width, input.Height);

            //Grayscale Convertion
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixel = input.GetPixel(x, y);

                    int toGray = (pixel.R + pixel.G + pixel.B) / 3;

                    Color greyscale = Color.FromArgb(toGray, toGray, toGray);

                    result.SetPixel(x, y, greyscale);
                }
            }

            pictureBox2.Image = result;
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = new Bitmap(input.Width, input.Height);

            //Inversion Conversion
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color data = input.GetPixel(x, y);
                    Color invert = Color.FromArgb(255 - data.R, 255 - data.G, 255 - data.B);

                    result.SetPixel(x, y, invert);
                }
            }

            pictureBox2.Image = result;
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color sample;
            Color greyscale;
            int graydata;

            //Grayscale Convertion
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    sample = input.GetPixel(x, y);
                    graydata = (sample.R + sample.G + sample.B) / 3;
                    greyscale = Color.FromArgb(graydata, graydata, graydata);
                    input.SetPixel(x, y, greyscale);
                }
            }

            //histogram 1d pixel;
            int[] histogramData = new int[256]; // array from 0 to 255
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    sample = input.GetPixel(x, y);
                    histogramData[sample.R]++;
                }
            }

            // Bitmap Graph Generation
            // Setting empty Bitmap with imageA color
            result = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    result.SetPixel(x, y, Color.White);
                }
            }

            // plotting points based from histogramData
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histogramData[x] / 5, result.Height - 1); y++)
                {
                    result.SetPixel(x, (result.Height - 1) - y, Color.Black);
                }
            }

            pictureBox2.Image = result;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = new Bitmap(input.Width, input.Height);

            //sepia
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    //get pixel value
                    Color pixel = input.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = pixel.A;
                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    //calculate temp value
                    int tempRed = (int)(0.393 * red + 0.769 * green + 0.189 * blue);
                    int tempGreen = (int)(0.349 * red + 0.686 * green + 0.168 * blue);
                    int tempBlue = (int)(0.272 * red + 0.534 * green + 0.131 * blue);

                    //set new RGB value
                    if (tempRed > 255)
                        red = 255;
                    else
                        red = tempRed;

                    if (tempGreen > 255)
                        green = 255;
                    else
                        green = tempGreen;

                    if (tempBlue > 255)
                        blue = 255;
                    else
                        blue = tempBlue;

                    //set the new RGB value in image pixel
                    result.SetPixel(x, y, Color.FromArgb(a, red, green, blue));

                    pictureBox2.Image = result;
                }
            }
        }

        private void dIP2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            DIP_Part_2 form2 = new DIP_Part_2();
            form2.ShowDialog();
            
        }

        private void basicCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            result = new Bitmap(input.Width, input.Height);

            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color data = input.GetPixel(x, y);

                    result.SetPixel(x, y, data);
                }
            }

            pictureBox2.Image = result;
        }
    }
}
