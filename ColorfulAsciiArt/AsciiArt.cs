using Colorful;

namespace ColorfulAsciiArt
{
    public struct AsciiArt
    {
        public string builder;
        public Formatter[] art;
        public int Width { get; set; }
        public int Height { get; set; }

        public AsciiArt(string builder, Formatter[] art, int width, int height)
        {
            this.builder = builder;
            this.art = art;
            Width = width;
            Height = height;
        }
    }
}