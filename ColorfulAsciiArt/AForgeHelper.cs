using AForge.Imaging.ColorReduction;
using AForge.Imaging.Filters;
using System.Drawing;

namespace ColorfulAsciiArt
{
    /// <summary>
    /// Class triển khai chức năng của thư viện AForge
    /// </summary>
    public static class AForgeHelper
    {
        /// <summary>
        /// Resize hình ảnh
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ResizeIamge(Bitmap image, int width, int height)
        {
            ResizeBilinear filter = new(width, height);

            return filter.Apply(image);
        }

        /// <summary>
        /// Giảm số lượng màu sắc của hình ảnh.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="colorNum"></param>
        /// <returns></returns>
        public static Bitmap ReduceColor(Bitmap image, int colorNum)
        {
            ColorImageQuantizer ciq = new ColorImageQuantizer(new MedianCutQuantizer());

            return ciq.ReduceColors(image, colorNum);
        }
    }
}
