﻿using System;
namespace BookMan.ConsoleApp.Views
{
    using Framework;

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
            ViewHelp.WriteLine("________Nhập đầu sách_________", ConsoleColor.DarkGreen);
            var name = ViewHelp.InputString("Tên sách: ", ConsoleColor.DarkRed);
            var authors = ViewHelp.InputString("Tác giả: ", ConsoleColor.DarkRed);
            var publisher = ViewHelp.InputString("Nhà xuất bản: ", ConsoleColor.DarkRed);
            var year = ViewHelp.InputInt("Năm xuất bản: ", ConsoleColor.DarkRed);
            var edition = ViewHelp.InputInt("Tái bản lần thứ: ", ConsoleColor.DarkRed);
            var isbn = ViewHelp.InputInt("Mã ISBN: ", ConsoleColor.DarkRed);
            var shortDescription = ViewHelp.InputInt("Mô tả sách: ", ConsoleColor.DarkRed);
            var rate = ViewHelp.InputInt("Đánh giá cá nhân: ", ConsoleColor.DarkRed);
            var filePath = ViewHelp.InputInt("Đường dẫn file sách: ", ConsoleColor.DarkRed);
        }
    }
}
