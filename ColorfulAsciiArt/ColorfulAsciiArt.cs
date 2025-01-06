using System.Drawing;

namespace ColorfulAsciiArt
{
    using Colorful;
    public class ColorfulAsciiArt
    {
        public static string[] AsciiChars = new string[] { "@", "%", "#", "*", "+", "=", "-", ":", ",", ".", " " };

        public static void Render(AsciiArt art)
        {
            Console.WriteLineFormatted(art.builder, Color.Gray, art.art);
        }

        public static AsciiArt GenereateArtFromImage(IImageSource image, float scale)
        {
            var scaleRatio = Math.Floor(image.AspectRatio * scale);
            var outputWidth = (int)Math.Floor(image.Width / scaleRatio);
            var outputHeight = (int)Math.Floor(outputWidth / image.AspectRatio);
            var widthStep = image.Width / outputWidth;
            var heightStep = image.Height / outputHeight;

            string builder = "";
            Formatter[] formatter = new Formatter[outputWidth * outputHeight];
            var index = 0;

            for (var h = 0; h < outputHeight; h++)
            {
                for (var w = 0; w < outputWidth; w++)
                {
                    var pixelColor = image.GetPixelArgb(w * widthStep, h * heightStep);
                    var grayValue = (int)(pixelColor.Red * 0.3 + pixelColor.Green * 0.59 + pixelColor.Blue * 0.11);
                    var asciiChar = AsciiChars[grayValue * (AsciiChars.Length - 1) / 255];
                    var color = Color.FromArgb(pixelColor.Red, pixelColor.Green, pixelColor.Blue);

                    builder += $"{{{index}}}";
                    formatter[index] = new(asciiChar, color);
                    index++;
                }
                builder += "\n";
            }

            return new(builder, formatter, outputWidth, outputHeight);
        }
    }
}
