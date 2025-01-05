using Colorful;

namespace ColorfulAsciiArt
{
    public struct AcsiiArt
    {
        public Formatter[] art;
        public int Width { get; set; }
        public int Height { get; set; }

        public AcsiiArt(Formatter[] art, int width, int height)
        {
            this.art = art;
            Width = width;
            Height = height;

            
        }
    }
}