using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Image_Processing
{
    public static class ImageProcess
    {
        public static Bitmap Convolution(double[,] convolutionCore, Bitmap image)
        {
            Bitmap tempImage = new Bitmap(image);
            BitmapData tempImageData = tempImage.LockBits(new Rectangle(0, 0, tempImage.Width, tempImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* tempImagePtr = (byte*) tempImageData.Scan0.ToPointer();
                byte* imagePtr = (byte*)imageData.Scan0.ToPointer();
                int stride = tempImageData.Stride;
                int height = image.Height - 1;
                double sum = 0;
                for(int i = 1; i< height; i++)
                {
                    byte* tempPos = tempImagePtr + (stride * i);
                    byte* imgPos = imagePtr + (stride * i);
                    for (int j= 0; j< stride; j++)
                    {
                        if (j > 2 && j < stride-3)
                        {
                            sum += (convolutionCore[0, 0] * (*(tempPos - stride - 3)));
                            sum += (convolutionCore[0, 1] * (*(tempPos - stride)));
                            sum += (convolutionCore[0, 2] * (*(tempPos - stride + 3)));
                            sum += (convolutionCore[1, 0] * (*(tempPos - 3)));
                            sum += (convolutionCore[1, 1] * (*(tempPos)));
                            sum += (convolutionCore[1, 2] * (*(tempPos + 3)));
                            sum += (convolutionCore[2, 0] * (*(tempPos + stride - 3)));
                            sum += (convolutionCore[2, 1] * (*(tempPos + stride)));
                            sum += (convolutionCore[2, 2] * (*(tempPos + stride + 3)));
                            if (sum > 255) sum = 255;
                            if (sum < 0) sum = 0;
                            *imgPos = (byte)sum;
                        }
                        sum = 0;
                        tempPos++;
                        imgPos++;
                    }                   
                }
                image.UnlockBits(imageData);
                tempImage.UnlockBits(tempImageData);
                return image;
            }
        }

        public static Bitmap DeleteRed(Bitmap image)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)(imageData.Scan0.ToPointer());
                int stride = imageData.Stride;
                int height = imageData.Height;               
                for(int i= 0; i< height; i++)
                {
                    byte* position = ptr + stride * i;
                    int step = 0;
                    for (int j = 0; j < stride; j++)
                    {
                        if(j == step)
                        {
                            *position = (byte)(0);
                            step += 3;
                        }
                        position++;
                    }
                }
            }
            image.UnlockBits(imageData);
            return image;
        }

        public static Bitmap DeleteGreen(Bitmap image)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)(imageData.Scan0.ToPointer());
                int stride = imageData.Stride;
                int height = imageData.Height;
                for (int i = 0; i < height; i++)
                {
                    byte* position = ptr + stride * i;
                    int step = 2;
                    for (int j = 0; j < stride; j++)
                    {
                        if (j == step)
                        {
                            *position = (byte)(0);
                            step += 3;
                        }
                        position++;
                    }
                }
            }
            image.UnlockBits(imageData);
            return image;
        }

        public static Bitmap DeleteBlue(Bitmap image)
        {
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* ptr = (byte*)(imageData.Scan0.ToPointer());
                int stride = imageData.Stride;
                int height = imageData.Height;
                for (int i = 0; i < height; i++)
                {
                    byte* position = ptr + stride * i;
                    int step = 0;
                    for (int j = 0; j < stride; j++)
                    {
                        if (j == step)
                        {
                            *position = (byte)(0);
                            step += 3;
                        }
                        position++;
                    }
                }
            }
            image.UnlockBits(imageData);
            return image;
        }


    }
}
