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
    }
}
