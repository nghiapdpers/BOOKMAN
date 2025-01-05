namespace ColorfulAsciiArt
{
    internal interface IImageSource : IDisposable
    {
        public int Width { get; }
        public int Height { get; }
        public float AspectRatio { get; }
        Rgb GetPixel(int x, int y);
    }
}
