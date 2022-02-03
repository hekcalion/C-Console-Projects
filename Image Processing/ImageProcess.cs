using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Image_Processing
{
    public static class ImageProcess
    {
        public static Bitmap Convolution(double[,] convolutionCore, Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            Color pixelColor;
            int row = convolutionCore.GetLength(0);
            int col = convolutionCore.GetLength(1);
            double Red = 0, Green = 0, Blue = 0;
            for (int i = 1; i < image.Width-1; i++)
            {
                for (int j = 1; j < image.Height-1; j++)
                {
                    for (int i1 = 0, c = (j - 1); i1 < col; i1++, c++)
                    {
                        for (int j1 = 0, r = (i - 1); j1 < row; j1++, r++)
                        {                                                     
                                pixelColor = image.GetPixel(r, c);
                                Red += convolutionCore[i1, j1] * pixelColor.R;
                                Green += convolutionCore[i1, j1] * pixelColor.G;
                                Blue += convolutionCore[i1, j1] * pixelColor.B;                           
                        }
                    }
                    Red = Red > 255 ? Red = 255 : Red;
                    Green = Green > 255 ? Green = 255 : Green;
                    Blue = Blue > 255 ? Blue = 255 : Blue;
                    Red = Red < 0 ? Red = 0 : Red;
                    Green = Green < 0 ? Green = 0 : Green;
                    Blue = Blue < 0 ? Blue = 0 : Blue;
                    pixelColor = Color.FromArgb((int)Red, (int)Green, (int)Blue);
                    result.SetPixel(i, j, pixelColor);
                    Red = Green = Blue = 0;
                }
            }
            return result;
        }

        public static Bitmap DeleteRed (Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            Color pixelColor;
            for (int i = 0; i < image.Width; i++)
            {
                for(int j = 0; j< image.Height; j++)
                {
                    pixelColor = image.GetPixel(i, j);
                    result.SetPixel(i, j, Color.FromArgb(0,pixelColor.G,pixelColor.B));
                }
            }
            return result;
        }

        public static Bitmap DeleteGreen (Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            Color pixelColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    pixelColor = image.GetPixel(i, j);
                    result.SetPixel(i, j, Color.FromArgb(pixelColor.R, 0, pixelColor.B));
                }
            }
            return result;
        }

        public static Bitmap DeleteBlue (Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            Color pixelColor;
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    pixelColor = image.GetPixel(i, j);
                    result.SetPixel(i, j, Color.FromArgb(pixelColor.R, pixelColor.G, 0));
                }
            }
            return result;
        }
    }
}
