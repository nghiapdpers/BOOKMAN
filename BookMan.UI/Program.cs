using AForge.Imaging.ColorReduction;
using ColorfulAsciiArt;
using System.Drawing;
using AsciiArtInstance = ColorfulAsciiArt.ColorfulAsciiArt;

namespace BookMan.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Image image = Image.FromFile("C:\\Users\\nghia\\OneDrive\\Pictures\\cappie.jpg");
            Image image = Image.FromFile("C:\\Users\\nghia\\OneDrive\\Pictures\\cappie.jpg");
            Bitmap imageBitmap = new Bitmap(image);

            ColorImageQuantizer ciq = new ColorImageQuantizer(new MedianCutQuantizer());

            Color[] colorTable = ciq.CalculatePalette(imageBitmap, 16);

            Bitmap newImage = ciq.ReduceColors(imageBitmap, 16);

            newImage.Save("demo2.png");

            GdiImageSource source = new GdiImageSource(newImage);

            AsciiArt art = AsciiArtInstance.GenereateArtFromImage(source, 15);
            AsciiArtInstance.Render(art);
            image.Dispose();
            source.Dispose();
            newImage.Dispose();
        }
    }
}
