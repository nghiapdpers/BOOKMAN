using AForge.Imaging.ColorReduction;
using AForge.Imaging.Filters;
using System.Drawing;

namespace ColorfulAsciiArt
{
    public static class AForgeHelper
    {

        public static Bitmap ResizeIamge(Bitmap image, int width, int height)
        {
            ResizeBilinear filter = new(width, height);

            return filter.Apply(image);
        }

        public static Bitmap ReduceColor(Bitmap image, int colorNum)
        {
            ColorImageQuantizer ciq = new ColorImageQuantizer(new MedianCutQuantizer());

            return ciq.ReduceColors(image, colorNum);
        }
    }
}
