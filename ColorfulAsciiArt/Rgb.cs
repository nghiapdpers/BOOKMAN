namespace ColorfulAsciiArt
{
    /// <summary>
    /// Kiểu dữ liệu RGB
    /// </summary>
    public struct Rgb
    {
        public byte Red;
        public byte Green;
        public byte Blue;

        public Rgb(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}