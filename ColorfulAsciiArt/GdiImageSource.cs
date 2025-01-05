﻿using System.Drawing;

namespace ColorfulAsciiArt
{
    public class GdiImageSource : IImageSource
    {
        private readonly Bitmap _image;

        public GdiImageSource(Bitmap image)
        {
            _image = image;
        }

        public int Width => _image.Width;

        public int Height => _image.Height;

        public float AspectRatio => _image.Width / (float)_image.Height;

        public void Dispose()
        {
            _image.Dispose();
        }

        public Rgb GetPixel(int x, int y)
        {
            var pixel = _image.GetPixel(x, y);

            return new(pixel.R, pixel.G, pixel.B);
        }
    }
}
