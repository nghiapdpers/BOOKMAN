using ColorfulAsciiArt;
using System.Drawing;

namespace BookMan.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Image image = Image.FromFile("C:\\Users\\nghia\\OneDrive\\Pictures\\cappie.jpg");
            Bitmap imageBitmap = new Bitmap(image);

            var art = new ConsoleArt(imageBitmap, 200);

            art.Render();

            imageBitmap.Dispose();
            image.Dispose();
        }
    }
}
