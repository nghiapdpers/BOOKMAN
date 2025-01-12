using System.Drawing;

namespace ColorfulAsciiArt
{
    /// <summary>
    /// Class nguồn ảnh
    /// </summary>
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

        /// <summary>
        /// Dispose ảnh để giải phóng dung lượng.
        /// </summary>
        public void Dispose()
        {
            _image.Dispose();
        }

        /// <summary>
        /// Lấy color ARGB của một pixel theo tọa độ x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Argb GetPixelArgb(int x, int y)
        {
            var pixel = _image.GetPixel(x, y);

            return new(pixel.A, pixel.R, pixel.G, pixel.B);
        }

        /// <summary>
        ///  Lấy color RGB của một pixel theo tọa độ x,y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Rgb GetPixelRgb(int x, int y)
        {
            var pixel = _image.GetPixel(x, y);

            return new(pixel.R, pixel.G, pixel.B);
        }
    }
}
