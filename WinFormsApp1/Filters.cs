﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace WinFormsApp1
{
    abstract class Filters
    {
        
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max) 
                return max;
            return value;
        }
    }

    class MatrixFilter : Filters
    {
        protected float[,] kernel = null;
        protected MatrixFilter() { }
        public MatrixFilter(float[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            }
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255), 
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }

    class BlurFilter : MatrixFilter
    {
        public BlurFilter()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            for (int i = 0; i < sizeX; ++i)
            {
                for (int j = 0; j < sizeY; ++j)
                {
                    kernel[i, j] = 1.0f / (float)(sizeX * sizeY);
                }
            }
        }
    }

    class MotionblurFilter: MatrixFilter
    {
        public MotionblurFilter()
        {
            int sizeX = 9;
            int sizeY = 9;
            kernel = new float[sizeX, sizeY];
            for (int i = 0;i < sizeX; ++i)
            {
                for (int j = 0;j < sizeY; ++j)
                {
                    if (i == j)
                        kernel[i, j] = 1.0f / (float)(sizeX);
                    else
                        kernel[i, j] = 0f;
                }
            }
            
        }
    }
    class EmbossingFilter : MatrixFilter
    {
        public EmbossingFilter()
        {
            kernel = new float[,]
            {
            { 0,  1,  0 },
            { 1,  0,  -1 },
            { 0,  -1,  0 }
            };
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = base.calculateNewPixelColor(sourceImage, x, y);
            int gray = (int)(0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B);
            gray = Clamp(gray + 100, 0, 255);
            return Color.FromArgb(gray, gray, gray);
        }
    }

    class SobelFilter : Filters
    {
        private readonly int[,] Gx = {
        { -1,  0,  1 },
        { -2,  0,  2 },
        { -1,  0,  1 }
        };
        private readonly int[,] Gy = {
        { -1, -2, -1 },
        {  0,  0,  0 },
        {  1,  2,  1 }
        };
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int GxR = 0;
            int GxG = 0;
            int GxB = 0;

			int GyR = 0;
			int GyG = 0;
			int GyB = 0;

			for (int l = -1; l <= 1; ++l)
            {
                for (int k = -1; k <= 1; ++k)
                {
                    int idX = Clamp(x+l, 0, sourceImage.Width - 1);
                    int idY = Clamp(y+k, 0, sourceImage.Height - 1);

                    Color pixel = sourceImage.GetPixel(idX, idY);

					GxR += pixel.R * Gx[l + 1, k + 1];
					GxG += pixel.G * Gx[l + 1, k + 1];
					GxB += pixel.B * Gx[l + 1, k + 1];

					GyR += pixel.R * Gy[l + 1, k + 1];
					GyG += pixel.G * Gy[l + 1, k + 1];
					GyB += pixel.B * Gy[l + 1, k + 1];

				}
            }
            int gradientR = Clamp((int)Math.Sqrt(GxR * GxR + GyR * GyR), 0, 255);
			int gradientG = Clamp((int)Math.Sqrt(GxG * GxG + GyG * GyG), 0, 255);
			int gradientB = Clamp((int)Math.Sqrt(GxB * GxB + GyB * GyB), 0, 255);

			return Color.FromArgb(gradientR, gradientG, gradientB);
        }
    }

	class SharraFilter : Filters
	{
		private readonly int[,] Gx = {
		{ -3,  0,  3 },
		{ -10,  0,  10 },
		{ -3,  0,  3 }
		};
		private readonly int[,] Gy = {
		{ -3, -10, -3 },
		{  0,  0,  0 },
		{  3,  10,  3 }
		};
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			int GxR = 0;
			int GxG = 0;
			int GxB = 0;

			int GyR = 0;
			int GyG = 0;
			int GyB = 0;

			for (int l = -1; l <= 1; ++l)
			{
				for (int k = -1; k <= 1; ++k)
				{
					int idX = Clamp(x + l, 0, sourceImage.Width - 1);
					int idY = Clamp(y + k, 0, sourceImage.Height - 1);

					Color pixel = sourceImage.GetPixel(idX, idY);

					GxR += pixel.R * Gx[l + 1, k + 1];
					GxG += pixel.G * Gx[l + 1, k + 1];
					GxB += pixel.B * Gx[l + 1, k + 1];

					GyR += pixel.R * Gy[l + 1, k + 1];
					GyG += pixel.G * Gy[l + 1, k + 1];
					GyB += pixel.B * Gy[l + 1, k + 1];

				}
			}
			int gradientR = Clamp((int)Math.Sqrt(GxR * GxR + GyR * GyR), 0, 255);
			int gradientG = Clamp((int)Math.Sqrt(GxG * GxG + GyG * GyG), 0, 255);
			int gradientB = Clamp((int)Math.Sqrt(GxB * GxB + GyB * GyB), 0, 255);

			return Color.FromArgb(gradientR, gradientG, gradientB);
		}
	}
	class InvertFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
            return resultColor;
        }
    }
    class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114*sourceColor.B;
            int grayValue = (int)Intensity;
            Color resultColor = Color.FromArgb(grayValue, grayValue, grayValue);
            return resultColor;
        }
    }
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            double Intensity = 0.299 * sourceColor.R + 0.587 * sourceColor.G + 0.114 * sourceColor.B;
            int k = 20;
            int R = Clamp((int)Intensity + 2 * k, 0, 255);
            int G = Clamp((int)Intensity + k / 2, 0, 255);
            int B = Clamp((int)Intensity - k, 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }
    class OriginalFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }
    }
    class BrightnessIncreaseFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int k = 20;
            int R = Clamp(sourceColor.R + k, 0, 255);
            int G = Clamp(sourceColor.G + k, 0, 255);
            int B = Clamp(sourceColor.B + k, 0, 255);
            Color resultColor = Color.FromArgb(R, G, B);
            return resultColor;
        }
    }

    class GlassFilter : Filters
    {
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			Random rand = new Random();
            int newX = Clamp(x + (int)((rand.NextDouble() - 0.5) * 10), 0, sourceImage.Width - 1);
            int newY = Clamp(y + (int)((rand.NextDouble() - 0.5) * 10), 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(newX, newY);
		}
	}
    class ShiftFilter : Filters
    {
        
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            if (x < 50)
                return Color.FromArgb(0, 0, 0);
            return sourceImage.GetPixel(x - 50, y);
        }
    }
    class GrayWorldFilter: Filters
    {
        public A sum;
        public struct A
        {
            public int resultR;
            public int resultG;
            public int resultB;
            public A()
            {
                resultR = 0;
                resultG = 0;
                resultB = 0;
            }
        }
        static public A Sum(Bitmap sourceImage)
        {
            A result = new A();
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    result.resultR += sourceImage.GetPixel(i, j).R;
                    result.resultG += sourceImage.GetPixel(i, j).G;
                    result.resultB += sourceImage.GetPixel(i, j).B;
                }
            }
            return result;
        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int N = sourceImage.Width * sourceImage.Height;
            float avgR = (float)sum.resultR / (float)N;
            float avgG = (float)sum.resultG / (float)N;
            float avgB = (float)sum.resultB / (float)N;
            float avg = (avgR + avgG + avgB) / 3f;
            int newR = Clamp((int)(sourceColor.R * avg / avgR), 0, 255);
            int newG = Clamp((int)(sourceColor.G * avg / avgG), 0, 255);
            int newB = Clamp((int)(sourceColor.B * avg / avgB), 0, 255);
            Color resultColor = Color.FromArgb(newR, newG, newB);
            return resultColor;
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            sum = Sum(sourceImage);
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }
    }
    class AutoLevelsFilter : Filters
    {
        public int minR = 256;
        public int minG = 256;
        public int minB = 256;

        public int maxR = -1;
        public int maxG = -1;
        public int maxB = -1;

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    Color pixel = sourceImage.GetPixel(i, j);
                    minR = Math.Min(minR, pixel.R);
                    minG = Math.Min(minG, pixel.G);
                    minB = Math.Min(minB, pixel.B);

                    maxR = Math.Max(maxR, pixel.R);
                    maxG = Math.Max(maxG, pixel.G);
                    maxB = Math.Max(maxB, pixel.B);
                }
            }
            for (int i = 0; i < sourceImage.Width; ++i)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; ++j)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int newR = Clamp((int)((float)(sourceColor.R - minR) * (float)255 / (float)(maxR - minR)), 0, 255);
            int newG = Clamp((int)((float)(sourceColor.G - minG) * (float)255 / (float)(maxG - minG)), 0, 255);
            int newB = Clamp((int)((float)(sourceColor.B - minB) * (float)255 / (float)(maxB - minB)), 0, 255);
            Color resultColor = Color.FromArgb(newR, newG, newB);
            return resultColor;
        }
    }

	class IdealReflectorFilter : Filters
	{

		public int maxR = -1;
		public int maxG = -1;
		public int maxB = -1;

		public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
		{
			Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
			for (int i = 0; i < sourceImage.Width; ++i)
			{
				for (int j = 0; j < sourceImage.Height; ++j)
				{
					Color pixel = sourceImage.GetPixel(i, j);

					maxR = Math.Max(maxR, pixel.R);
					maxG = Math.Max(maxG, pixel.G);
					maxB = Math.Max(maxB, pixel.B);
				}
			}
			for (int i = 0; i < sourceImage.Width; ++i)
			{
				worker.ReportProgress((int)((float)i / resultImage.Width * 100));
				if (worker.CancellationPending)
					return null;
				for (int j = 0; j < sourceImage.Height; ++j)
				{
					resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
				}
			}
			return resultImage;
		}

		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			Color sourceColor = sourceImage.GetPixel(x, y);
			int newR = Clamp((int)((float)sourceColor.R * (float)255 / (float)maxR), 0, 255);
			int newG = Clamp((int)((float)sourceColor.G * (float)255 / (float)maxG), 0, 255);
			int newB = Clamp((int)((float)sourceColor.B * (float)255 / (float)maxB), 0, 255);
			Color resultColor = Color.FromArgb(newR, newG, newB);
			return resultColor;
		}
	}

    class ExtensionFilter : Filters
    {

        bool[,] kernel = new bool[3, 3] {
            {false, true, false },
            {true, true, true },
            {false, true, false }
        };

		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
            int maxR = -1;
            int maxG = -1;
            int maxB = -1;

            for (int l = -1; l <= 1; ++l)
            {
                for (int k = -1; k <= 1; ++k)
                {
                    if (kernel[l+1, k+1] && (x+l) >= 0 && (x+l)<sourceImage.Width && (y+k)>=0 && (y+k)<sourceImage.Height)
                    {
                        maxR = Math.Max(maxR, sourceImage.GetPixel(x + l, y + k).R);
						maxG = Math.Max(maxG, sourceImage.GetPixel(x + l, y + k).G);
						maxB = Math.Max(maxB, sourceImage.GetPixel(x + l, y + k).B);

					}
                }
            }

            Color resultColor = Color.FromArgb(maxR, maxG, maxB);
            return resultColor;
		}
	}

	class ConstrictionFilter : Filters
	{

		bool[,] kernel = new bool[3, 3] {
			{false, true, false },
			{true, true, true },
			{false, true, false }
		};

		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			int minR = 256;
			int minG = 256;
			int minB = 256;

			for (int l = -1; l <= 1; ++l)
			{
				for (int k = -1; k <= 1; ++k)
				{
					if (kernel[l + 1, k + 1] && (x + l) >= 0 && (x + l) < sourceImage.Width && (y + k) >= 0 && (y + k) < sourceImage.Height)
					{
						minR = Math.Min(minR, sourceImage.GetPixel(x + l, y + k).R);
						minG = Math.Min(minG, sourceImage.GetPixel(x + l, y + k).G);
						minB = Math.Min(minB, sourceImage.GetPixel(x + l, y + k).B);

					}
				}
			}

			Color resultColor = Color.FromArgb(minR, minG, minB);
			return resultColor;
		}
	}

    class MedianFilter : Filters
    {
		protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
		{
			List<int> R = new List<int>();
            List<int> G = new List<int>();
            List<int> B = new List<int>();

            for (int l = -1; l <= 1; ++l)
            {
                for (int k = -1; k <= 1; ++k)
                {
                    int X = Clamp(x + l, 0, sourceImage.Width - 1);
                    int Y = Clamp(y + k, 0, sourceImage.Height - 1);

                    Color neighborColor = sourceImage.GetPixel(X, Y);

                    R.Add(neighborColor.R);
                    G.Add(neighborColor.G);
                    B.Add(neighborColor.B);
                }
            }

            R.Sort();
            G.Sort();
            B.Sort();

            Color resultColor = Color.FromArgb(R[R.Count/2], G[G.Count/2], B[B.Count/2]);

            return resultColor;
		}
	}
}
