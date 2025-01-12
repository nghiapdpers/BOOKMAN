using System.Drawing;
namespace ColorfulAsciiArt
{
    using Colorful;
    /// <summary>
    /// Lớp Console Art tạo Art và hiển thị
    /// </summary>
    public class ConsoleArt
    {
        public Art Art { get; set; }

        /// <summary>
        /// Tạo ConsoleArt với hỉnh ảnh
        /// <br>
        /// Lưu ý: width càng lớn, thời gian render càng lâu!
        /// </br>
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        public ConsoleArt(Bitmap image, int width)
        {
            var imageResized = AForgeHelper.ReduceColor(GetReSizedImage(image, width), 12);
            var source = new GdiImageSource(imageResized);
            Art = GenereateArtFromImage(source);
        }

        /// <summary>
        /// Hiển thị ảnh 
        /// </summary>
        public void Render()
        {
            ConsoleHelper.SetCurrentFont("Consolas", 5);
            ConsoleHelper.Maximize();
            Console.WriteLineFormatted(Art.builder, Color.Black, Art.art);
            Console.Read();
        }

        /// <summary>
        /// Tạo ảnh
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Art GenereateArtFromImage(IImageSource image)
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

        /// <summary>
        /// Tính width và height của ảnh, sau đó resize.
        /// </summary>
        /// <param name="inputBitmap"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        private Bitmap GetReSizedImage(Bitmap inputBitmap, int width)
        {
            int height = (int)Math.Ceiling((double)inputBitmap.Height * width / inputBitmap.Width);

            return AForgeHelper.ResizeIamge(inputBitmap, width, height);
        }
    }
}
