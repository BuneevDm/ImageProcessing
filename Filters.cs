using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageProcessing
{
    class Filters
    {
        public static Bitmap GreyColors(Bitmap myImage)
        {
            Bitmap result = new Bitmap(myImage.Width, myImage.Height);
            for (int y = 0; y < myImage.Height; y++)
            {
                for (int x = 0; x < myImage.Width; x++)
                {
                    int temp = ((myImage.GetPixel(x, y).B + myImage.GetPixel(x, y).R + myImage.GetPixel(x, y).G) / 3) % 255;
                    Color tc = Color.FromArgb(temp, temp, temp);
                    result.SetPixel(x, y, tc);
                }
            }

            return result;
        }
    }
}
