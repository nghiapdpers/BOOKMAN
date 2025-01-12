using Colorful;

namespace ColorfulAsciiArt
{
    /// <summary>
    /// Kiểu dữ liệu AsciiArt
    /// </summary>
    public struct Art
    {
        public string builder;
        public Formatter[] art;
        public int Width { get; set; }
        public int Height { get; set; }

        public Art(string builder, Formatter[] art, int width, int height)
        {
            this.builder = builder;
            this.art = art;
            Width = width;
            Height = height;
        }
    }
}