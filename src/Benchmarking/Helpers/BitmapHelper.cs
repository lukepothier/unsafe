using System.Drawing;
using System.Drawing.Imaging;

namespace Benchmarking.Helpers
{
    public static class BitmapHelper
    {
        public static void ProcessSafe(Bitmap image)
        {
            var width = image.Width;
            var height = image.Height;
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Color oldPixel = image.GetPixel(x, y);
                    Color newPixel = oldPixel;
                    image.SetPixel(x, y, newPixel);
                }
            }
        }

        public unsafe static void ProcessUnsafe(Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            var bytesPerPixel = Image.GetPixelFormatSize(image.PixelFormat) / 8;
            var heightInPixels = bitmapData.Height;
            var widthInBytes = bitmapData.Width * bytesPerPixel;
            var ptrFirstPixel = (byte*)bitmapData.Scan0;

            for (var y = 0; y < heightInPixels; y++)
            {
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);
                for (var x = 0; x < widthInBytes; x = x + bytesPerPixel)
                {
                    int oldBlue = currentLine[x];
                    int oldGreen = currentLine[x + 1];
                    int oldRed = currentLine[x + 2];

                    currentLine[x] = (byte)oldBlue;
                    currentLine[x + 1] = (byte)oldGreen;
                    currentLine[x + 2] = (byte)oldRed;
                }
            }

            image.UnlockBits(bitmapData);
        }
    }
}
