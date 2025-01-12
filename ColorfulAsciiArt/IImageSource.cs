using System.Drawing;

namespace ColorfulAsciiArt
{
    public interface IImageSource : IDisposable
    {
        public int Width { get; }
        public int Height { get; }
        public float AspectRatio { get; }
        Argb GetPixelArgb(int x, int y);
        Rgb GetPixelRgb(int x, int y);
    }
}
