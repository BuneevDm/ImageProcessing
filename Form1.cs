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
            for (int y = 25; y < myImage.Height - 25; y++)
            {
                for (int x = 25; x < myImage.Width - 25; x++)
                {
                        //myImage.SetPixel(x, y)
                        int temp = ((myImage.GetPixel(x, y).B + myImage.GetPixel(x, y).R + myImage.GetPixel(x, y).G) / 3) % 255;
                        Color tc = Color.FromArgb(temp, temp, temp);
                        myImage.SetPixel(x, y, tc);
                }
            }

            pictureBox1.Image = (Image)myImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = openFileDialog1.FileName;

            myImage = new Bitmap(textBox1.Text);
            pictureBox1.Image = (Image)myImage;
        }
    }
}
