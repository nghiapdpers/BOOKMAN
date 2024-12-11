using System;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Helper hỗ trợ chức năng cho Views
    /// </summary>
    public class ViewHelp
    {
        /// <summary>
        /// In ra một dòng chữ với màu sắc (không xuống dòng).
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor) Console.ResetColor();
        }

        /// <summary>
        /// In ra và xuống dòng có màu sắc
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor) Console.ResetColor();
        }

        /// <summary>
        /// Nhập thông tin chuỗi
        /// </summary>
        /// <param name="title">Tiêu đề</param>
        /// <param name="titleColor">Màu tiêu đề</param>
        /// <param name="inputColor">Màu chữ khi nhập</param>
        /// <returns></returns>
        public static string InputString(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title, titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadLine();
            Console.ResetColor();
            if (string.IsNullOrEmpty(input.Trim()))
            {
                return "";
            }
            return input;
        }

        /// <summary>
        /// Hiển thị chuỗi cũ, nhập vào chuỗi mới
        /// </summary>
        /// <param name="title"></param>
        /// <param name="oldValue"></param>
        /// <param name="titleColor"></param>
        /// <param name="inputColor"></param>
        /// <returns>Chuỗi mang giá trị mới</returns>
        public static string InputString(string title, string oldValue, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title + "[old]: ", titleColor);
            WriteLine(oldValue, inputColor);
            Write(title + "[new]: ", titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadLine();
            Console.ResetColor();
            if (string.IsNullOrEmpty(input.Trim()))
            {
                return oldValue;
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
        public static int InputInt(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
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
        /// Hiển thị số cũ, nhập số mới
        /// </summary>
        /// <param name="title"></param>
        /// <param name="oldValue"></param>
        /// <param name="titleColor"></param>
        /// <param name="inputColor"></param>
        /// <returns>Số mới</returns>
        public static int InputInt(string title, int oldValue, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            while (true)
            {
                var input = InputString(title, oldValue.ToString(), titleColor, inputColor);
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
        public static bool InputBool(string title, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title + "[y/n]: ", titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadKey();
            Console.WriteLine();
            bool @bool = input.Key == ConsoleKey.Y ? true : false;
            Console.ResetColor();
            return @bool;
        }

        /// <summary>
        /// Hiển thị tùy chọn cũ, nhập tùy chọn mới
        /// </summary>
        /// <param name="title"></param>
        /// <param name="titleColor"></param>
        /// <param name="inputColor"></param>
        /// <returns></returns>
        public static bool InputBool(string title, bool oldValue, ConsoleColor titleColor = ConsoleColor.White, ConsoleColor inputColor = ConsoleColor.White)
        {
            Write(title + "[old]: ", titleColor);
            WriteLine(oldValue ? "Có[y]" : "Không[n]", inputColor);
            Write(title + "[new - y/n]: ", titleColor);
            Console.ForegroundColor = inputColor;
            var input = Console.ReadKey();
            Console.WriteLine();
            bool @bool = input.Key == ConsoleKey.Y ? true : false;
            if (input.Key == ConsoleKey.Enter)
            {
                @bool = oldValue;
            }
            Console.ResetColor();
            return @bool;
        }
    }
}
