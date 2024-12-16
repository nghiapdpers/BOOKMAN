using System;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// Class cập nhật thông tin sách
    /// </summary>
    internal class BookUpdateView
    {
        private Book model;

        public BookUpdateView(Book model)
        {
            this.model = model;
        }

        /// <summary>
        /// Hiển thị thông tin và nhập thông tin mới cho sách
        /// </summary>
        public void Render()
        {
            ViewHelp.WriteLine("____Cập nhật thông tin sách____", ConsoleColor.DarkYellow);

            var name = ViewHelp.InputString("Tên sách: ", model.Name, ConsoleColor.DarkRed);
            var authors = ViewHelp.InputString("Tác giả: ", model.Authors, ConsoleColor.DarkRed);
            var publisher = ViewHelp.InputString("Nhà xuất bản: ", model.Publisher, ConsoleColor.DarkRed);
            var year = ViewHelp.InputInt("Năm xuất bản: ", model.Year, ConsoleColor.DarkRed);
            var edition = ViewHelp.InputInt("Tái bản lần thứ: ", model.Edition, ConsoleColor.DarkRed);
            var isbn = ViewHelp.InputString("Mã ISBN: ", model.Isbn, ConsoleColor.DarkRed);
            var shortDescription = ViewHelp.InputString("Mô tả sách: ", model.ShortDescription, ConsoleColor.DarkRed);
            var rate = ViewHelp.InputInt("Đánh giá cá nhân: ", model.Rate, ConsoleColor.DarkRed);
            var filePath = ViewHelp.InputString("Đường dẫn file sách: ", model.File, ConsoleColor.DarkRed);
        }
    }
}
