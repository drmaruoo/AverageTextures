using System;
using System.Drawing;

namespace AverageTextures
{
    public class ImageProcessor
    {
        public static Bitmap setToAverageColor(Bitmap initialBitmap)
        {
            int width = initialBitmap.Width;
            int height = initialBitmap.Height;
            try
            {
                Bitmap AveragedBitmap = new Bitmap(width, height);
                Graphics AveragedBitmapGDI = Graphics.FromImage(AveragedBitmap);
                Color initialBitmapAverageColor = AverageColor(initialBitmap);
                AveragedBitmapGDI.Clear(initialBitmapAverageColor);

                return AveragedBitmap;
            }
            catch
            {
                throw;
            }
        }
        private static Color AverageColor(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            int totalPixels = width * height;
            int totalRed = 0;
            int totalGreen = 0;
            int totalBlue = 0;
            int totalOpacity = 0;
            int averageRed;
            int averageGreen;
            int averageBlue;
            int averageOpacity;
            Color color;
            Color resultColor;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    color = bitmap.GetPixel(x, y);
                    totalOpacity += color.A;
                    totalRed += color.R;
                    totalGreen += color.G;
                    totalBlue += color.B;
                }
            }

            averageOpacity = totalOpacity / totalPixels;
            averageRed = totalRed / totalPixels;
            averageGreen = totalGreen / totalPixels;
            averageBlue = totalBlue / totalPixels;

            resultColor = Color.FromArgb(averageOpacity, averageRed, averageGreen, averageBlue);

            return resultColor;
        }
        public static void averageAndSaveBitmapToPath(string path)
        {
            Image image = Image.FromFile(path);
            Bitmap bitmap = new Bitmap(image);
            image.Dispose();
            bitmap = setToAverageColor(bitmap);
            bitmap.Save(path);
            bitmap.Dispose();
        }
    }
}
