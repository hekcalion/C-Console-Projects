using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Image_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap Image;
            Bitmap result;
            string filterName;
            Stopwatch timer = new Stopwatch();
            Console.WriteLine("Print full path to image");
            string pathToImage = Console.ReadLine();
            Console.WriteLine();
            bool fileExist = File.Exists(pathToImage);
            if (!fileExist)
            {
                int fakePath = 0;
                int maxFaxePass = 3;
                do
                {
                    if (fakePath == maxFaxePass)
                    {
                        Console.WriteLine("Do you want exit? (Yes/No)");
                        string exitChoice = Console.ReadLine();
                        Console.WriteLine();
                        if (exitChoice.Equals("Yes") || exitChoice.Equals("yes"))
                        {
                            return;
                        }
                        else
                        {
                            maxFaxePass *= 2;
                            continue;
                        }
                    }
                    Console.WriteLine("File does not exist!");
                    Console.WriteLine("Print new path to image");
                    pathToImage = Console.ReadLine();
                    Console.WriteLine();
                    fakePath++;
                } while (!File.Exists(pathToImage));
            }
            using (FileStream imageStream = new FileStream(pathToImage, FileMode.Open, FileAccess.Read))
            {
                Image = new Bitmap(imageStream);
            }
            bool correctNumber = true;
            int filterChoice;
            do
            {
                Console.WriteLine("Choose filter:");
                Console.WriteLine("1- Edge detection");
                Console.WriteLine("2- Contrast");
                Console.WriteLine("3- Vertical");
                Console.WriteLine("4- Horizontal");
                Console.WriteLine("5- Delete Red Color");
                Console.WriteLine("6- Delete Green Color");
                Console.WriteLine("7- Delete Blue Color");
                bool isNumber = int.TryParse(Console.ReadLine(), out filterChoice);
                if (!isNumber)
                {
                    Console.WriteLine("Incorrect input! \n");
                    continue;
                }
                else if (filterChoice < 0 || filterChoice > 7)
                {
                    Console.WriteLine("Incorrect number! \n");
                    continue;
                }
                correctNumber = false;
            } while (correctNumber);
            switch (filterChoice)
            {
                case 1:
                    filterName = nameof(CoreMatrix.EdgeDetection);
                    timer.Start();
                    result = ImageProcess.Convolution(CoreMatrix.EdgeDetection, Image);
                    timer.Stop();
                    break;
                case 2:
                    filterName = nameof(CoreMatrix.Contrast);
                    timer.Start();
                    result = ImageProcess.Convolution(CoreMatrix.Contrast, Image);
                    timer.Stop();
                    break;
                case 3:
                    filterName = nameof(CoreMatrix.Vertical);
                    timer.Start();
                    result = ImageProcess.Convolution(CoreMatrix.Vertical, Image);
                    timer.Stop();
                    break;
                case 4:
                    filterName = nameof(CoreMatrix.Horizontal);
                    timer.Start();
                    result = ImageProcess.Convolution(CoreMatrix.Horizontal, Image);
                    timer.Stop();
                    break;
                case 5:
                    filterName = nameof(ImageProcess.DeleteRed);
                    timer.Start();
                    result = ImageProcess.DeleteRed(Image);
                    timer.Stop();
                    break;
                case 6:
                    filterName = nameof(ImageProcess.DeleteGreen);
                    timer.Start();
                    result = ImageProcess.DeleteGreen(Image);
                    timer.Stop();
                    break;
                case 7:
                    filterName = nameof(ImageProcess.DeleteBlue);
                    timer.Start();
                    result = ImageProcess.DeleteBlue(Image);
                    timer.Stop();
                    break;
                default:
                    filterName = nameof(CoreMatrix.EdgeDetection);
                    timer.Start();
                    result = ImageProcess.Convolution(CoreMatrix.EdgeDetection, Image);
                    timer.Stop();
                    break;
            }
            Console.WriteLine("Image successfully filtered!");
            Console.WriteLine($"Time of image filtering {(double)timer.ElapsedMilliseconds / 1000} seconds");
            result.Save($"{Path.GetDirectoryName(pathToImage)}\\{Path.GetFileNameWithoutExtension(pathToImage)}({filterName}).jpeg", ImageFormat.Jpeg);
            Console.ReadKey();
            return;
        }
    }

}
