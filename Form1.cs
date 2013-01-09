using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap myImage;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.Title = "Выберите изображение для обработки";
            openFileDialog1.Filter = "Image Files (*.JPG)|*.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            progressBar1.Maximum = myImage.Width * myImage.Height;
            for (int y = 1; y < myImage.Height-1; y++)
            {
                for (int x = 1; x < myImage.Width-1; x++)
                {
                    i++;
                    progressBar1.Value = i;
                    int temp = myImage.GetPixel(x + 1, y + 1).R + myImage.GetPixel(x, y + 1).R + myImage.GetPixel(x - 1, y + 1).R +
                        myImage.GetPixel(x + 1, y).R + myImage.GetPixel(x, y).R + myImage.GetPixel(x - 1, y).R +
                        myImage.GetPixel(x + 1, y - 1).R + myImage.GetPixel(x, y - 1).R + myImage.GetPixel(x - 1, y - 1).R;
                    temp = temp / 9;
                    Color tc = Color.FromArgb(temp, temp, temp);
                    myImage.SetPixel(x, y, tc);
                }
            }

            pictureBox1.Image = (Image)myImage;
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = openFileDialog1.FileName;

            myImage = Filters.GreyColors(new Bitmap(textBox1.Text));
            pictureBox1.Image = (Image)myImage;
        }
    }
}
