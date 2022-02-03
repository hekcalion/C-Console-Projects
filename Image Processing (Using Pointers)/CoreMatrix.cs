using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Processing
{
    public sealed class CoreMatrix
    {
        public static double[,] EdgeDetection
        {
            get
            {
                return new double[,]
                {
                    { -1, -1, -1 },
                    { -1, 8, -1 },
                    { -1, -1, -1 }
                };
            }
        }
        public static double[,] Contrast
        {
            get
            {
                return new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 8, -1 },
                    { 0, -1, 0 }
                };
            }
        }
        public static double[,] Vertical
        {
            get
            {
                return new double[,]
                {
                    { -1, 2, -1 },
                    { -1, 2, -1 },
                    { -1, 2, -1 }
                };
            }
        }
        public static double[,] Horizontal
        {
            get
            {
                return new double[,]
                {
                    { -1, -1, -1 },
                    { 2, 2, 2 },
                    { -1, -1, -1 }
                };
            }
        }
    }
}

