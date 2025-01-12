using System.Drawing;

namespace ColorfulAsciiArt
{
    using Colorful;

    public class ColorfulAsciiArt
    {
        public AsciiArt Art { get; set; }

        public ColorfulAsciiArt(Bitmap image, int width)
        {
            var imageResized = AForgeHelper.ReduceColor(GetReSizedImage(image, width), 12);
            var source = new GdiImageSource(imageResized);
            Art = GenereateArtFromImage(source);
        }

        public void Render()
        {
            ConsoleHelper.SetCurrentFont("Consolas", 5);
            ConsoleHelper.Maximize();
            Console.WriteLineFormatted(Art.builder, Color.Black, Art.art);
            Console.Read();
        }

        private AsciiArt GenereateArtFromImage(IImageSource image)
        {
            var width = image.Width;
            var height = image.Height;

            string builder = "";
            Formatter[] formatter = new Formatter[width * height];
            var index = 0;

            for (var h = 0; h < height; h++)
            {
                for (var w = 0; w < width; w++)
                {
                    var pixelColor = image.GetPixelArgb(w, h);

                    Color color = Color.FromArgb(pixelColor.Alpha, pixelColor.Red, pixelColor.Green, pixelColor.Blue);

                    builder += $"{{{index}}}";
                    formatter[index] = new("██", color);
                    index++;
                }
                builder += "\n";
            }

            image.Dispose();

            return new(builder, formatter, width, height);
        }

        private Bitmap GetReSizedImage(Bitmap inputBitmap, int width)
        {
            int height = (int)Math.Ceiling((double)inputBitmap.Height * width / inputBitmap.Width);

            return AForgeHelper.ResizeIamge(inputBitmap, width, height);
        }
    }
}
