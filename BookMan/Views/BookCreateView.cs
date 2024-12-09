using System;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// class tạo thông tin cuốn sách
    /// </summary>
    internal class BookCreateView
    {
        /// <summary>
        /// Nhập thông tin cho cuốn sách
        /// </summary>
        public void Render()
        {
            WriteLine("________Nhập đầu sách_________", ConsoleColor.DarkGreen);
            var name = InputString("Tên sách: ", ConsoleColor.DarkRed);
            var authors = InputString("Tác giả: ", ConsoleColor.DarkRed);
            var publisher = InputString("Nhà xuất bản: ", ConsoleColor.DarkRed);
            var year = InputInt("Năm xuất bản: ", ConsoleColor.DarkRed);
            var edition = InputInt("Tái bản lần thứ: ", ConsoleColor.DarkRed);
            var isbn = InputInt("Mã ISBN: ", ConsoleColor.DarkRed);
            var shortDescription = InputInt("Mô tả sách: ", ConsoleColor.DarkRed);
            var rate = InputInt("Đánh giá cá nhân: ", ConsoleColor.DarkRed);
            var filePath = InputInt("Đường dẫn file sách: ", ConsoleColor.DarkRed);
        }

        /// <summary>
        /// In ra một dòng với màu sắc
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// In ra và xuống dòng có màu sắc
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Nhập thông tin chuỗi
        /// </summary>
        /// <param name="title">Tiêu đề</param>
        /// <param name="titleColor">Màu tiêu đề</param>
        /// <param name="inputColor">Màu chữ khi nhập</param>
        /// <returns></returns>
        public string InputString(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title, titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadLine();
            Console.ResetColor();
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            return input;
        }

        /// <summary>
        /// Nhập thông tin số
        /// </summary>
        /// <param name="title">Tiêu đề</param>
        /// <param name="titleColor">Màu tiêu đề</param>
        /// <param name="inputColor">Màu chữ khi nhập</param>
        /// <returns></returns>
        public int InputInt(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            while (true)
            {
                var input = InputString(title, titleColor, inputColor);
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
            }
        }

        /// <summary>
        /// Nhập thông tin true/false
        /// </summary>
        /// <param name="title">Tiêu đề</param>
        /// <param name="titleColor">Màu tiêu đề</param>
        /// <param name="inputColor">Màu chữ khi nhập</param>
        /// <returns></returns>
        public bool InputBool(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title + "[y/n]: ", titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadKey();
            Console.WriteLine();
            bool @bool = input.Key == ConsoleKey.Y ? true : false;
            Console.ResetColor();
            return @bool;
        }
    }
}
