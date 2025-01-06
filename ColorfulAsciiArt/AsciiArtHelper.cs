using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ColorfulAsciiArt
{
    public class AsciiArtHelper
    {
        public static Bitmap ConvertTo4Bit(Bitmap original)
        {
            // Create a new bitmap with 4-bit color depth
            Bitmap newImage = new Bitmap(original.Width, original.Height, PixelFormat.Format4bppIndexed);

            // Set the palette to grayscale
            ColorPalette palette = newImage.Palette;
            for (int i = 0; i < 16; i++)
            {
                int c = (int)(i * 255 / 15.0);
                palette.Entries[i] = Color.FromArgb(c, c, c);
            }
            newImage.Palette = palette;

            // Lock the bits of the original image
            BitmapData originalData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, original.PixelFormat);

            // Lock the bits of the new image
            BitmapData newData = newImage.LockBits(new Rectangle(0, 0, newImage.Width, newImage.Height), ImageLockMode.WriteOnly, newImage.PixelFormat);

            // Copy the pixel data
            int bytesPerPixel = Image.GetPixelFormatSize(original.PixelFormat) / 8;
            int height = original.Height;
            int width = original.Width * bytesPerPixel;
            byte[] pixelBuffer = new byte[width * height];
            System.Runtime.InteropServices.Marshal.Copy(originalData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            // Reduce color depth
            byte[] newPixelBuffer = new byte[newData.Stride * newData.Height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x += bytesPerPixel)
                {
                    int index = y * width + x;
                    byte gray = (byte)(0.299 * pixelBuffer[index + 2] + 0.587 * pixelBuffer[index + 1] + 0.114 * pixelBuffer[index]);
                    byte colorIndex = (byte)(gray / 16);
                    newPixelBuffer[y * newData.Stride + x / bytesPerPixel] = colorIndex;
                }
            }

            // Copy the new pixel data back to the new image
            System.Runtime.InteropServices.Marshal.Copy(newPixelBuffer, 0, newData.Scan0, newPixelBuffer.Length);

            // Unlock the bits
            original.UnlockBits(originalData);
            newImage.UnlockBits(newData);

            return newImage;
        }

        public static Bitmap ResizeAndConvertTo4Bit(Bitmap originalImage, int newWidth, int newHeight)
        {
            // Tạo một bitmap mới với kích thước và định dạng mong muốn
            Bitmap resizedImage = new Bitmap(newWidth, newHeight, PixelFormat.Format4bppIndexed);

            // Tạo một đối tượng Graphics để vẽ lên bitmap mới
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                // Sử dụng interpolation mode để cải thiện chất lượng hình ảnh khi resize
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            // Áp dụng bảng màu 4-bit cho bitmap
            ColorPalette palette = resizedImage.Palette;
            for (int i = 0; i < palette.Entries.Length; i++)
            {
                // Tính toán màu mới dựa trên chỉ số màu hiện tại
                // Bạn có thể tùy chỉnh cách tính toán này để tạo ra các hiệu ứng màu khác nhau
                Color newColor = Color.FromArgb((i * 16) & 0xF0, (i * 16) & 0xF0, (i * 16) & 0xF0);
                palette.Entries[i] = newColor;
            }
            resizedImage.Palette = palette;

            return resizedImage;
        }
    }
}
