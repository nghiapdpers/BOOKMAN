namespace ColorfulAsciiArt
{
    public struct Argb
    {
        public byte Alpha;
        public byte Red;
        public byte Green;
        public byte Blue;

        public Argb(byte alpha, byte red, byte green, byte blue)
        {
            Alpha = alpha;
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}