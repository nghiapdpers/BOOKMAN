using ColorfulAsciiArt;
using System.Drawing;
using AsciiArtInstance = ColorfulAsciiArt.ColorfulAsciiArt;

namespace BookMan.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Image image = Image.FromFile("C:\\Users\\Nghia\\Pictures\\qrcode.png");

            Bitmap bitmap = (Bitmap)Bitmap.FromFile("C:\\Users\\Nghia\\Pictures\\qrcode.png");

            GdiImageSource source = new GdiImageSource(bitmap);
            //GdiImageSource source2 = new GdiImageSource(bitmap2);

            AsciiArt art = AsciiArtInstance.GenereateArtFromImage(source, 20);
            //AsciiArt art2 = AsciiArtInstance.GenereateArtFromImage(source2);
            Console.BackgroundColor = ConsoleColor.White;
            AsciiArtInstance.Render(art);
            //AsciiArtInstance.Render(art2);
        }
    }
}
