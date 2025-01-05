using System.Drawing;

namespace ColorfulAsciiArt
{
    using Colorful;
    public class ColorfulAcsiiArt
    {
        public static void Render(AcsiiArt art)
        {
            Console.WriteLineFormatted($"", Color.Gray, art.art);

        }
    }
}
