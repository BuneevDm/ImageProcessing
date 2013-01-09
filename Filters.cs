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

        public static Bitmap NewFilter(Bitmap myImage)
        {
            Bitmap result = new Bitmap(myImage.Width, myImage.Height);
            for (int y = 1; y < myImage.Height-1; y++)
            {
                for (int x = 1; x < myImage.Width-1; x++)
                {
                    int temp = myImage.GetPixel(x + 1, y + 1).R + 7*myImage.GetPixel(x, y + 1).R + myImage.GetPixel(x - 1, y + 1).R +
                        2*myImage.GetPixel(x + 1, y).R + (int) 0.25*myImage.GetPixel(x, y).R + 2*myImage.GetPixel(x - 1, y).R +
                        myImage.GetPixel(x + 1, y - 1).R + 7*myImage.GetPixel(x, y - 1).R + myImage.GetPixel(x - 1, y - 1).R;
                    temp = (temp / 9) % 255;
                    Color tc = Color.FromArgb(temp, temp, temp);
                    
                    result.SetPixel(x, y, tc);
                }
            }

            return result;
        }
    }
}
