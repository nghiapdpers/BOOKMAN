using System;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// Class cập nhật thông tin sách
    /// </summary>
    internal class BookUpdateView : ViewBase<Book>
    {
        public BookUpdateView(Book model) : base(model) { }

        /// <summary>
        /// Hiển thị thông tin và nhập thông tin mới cho sách
        /// </summary>
        public override void Render()
        {
            ViewHelp.WriteLine("____Cập nhật thông tin sách____", ConsoleColor.DarkYellow);

            var name = ViewHelp.InputString("Tên sách: ", Model.Name, ConsoleColor.DarkRed);
            var authors = ViewHelp.InputString("Tác giả: ", Model.Authors, ConsoleColor.DarkRed);
            var publisher = ViewHelp.InputString("Nhà xuất bản: ", Model.Publisher, ConsoleColor.DarkRed);
            var year = ViewHelp.InputInt("Năm xuất bản: ", Model.Year, ConsoleColor.DarkRed);
            var edition = ViewHelp.InputInt("Tái bản lần thứ: ", Model.Edition, ConsoleColor.DarkRed);
            var isbn = ViewHelp.InputString("Mã ISBN: ", Model.Isbn, ConsoleColor.DarkRed);
            var shortDescription = ViewHelp.InputString("Mô tả sách: ", Model.ShortDescription, ConsoleColor.DarkRed);
            var rate = ViewHelp.InputInt("Đánh giá cá nhân: ", Model.Rate, ConsoleColor.DarkRed);
            var filePath = ViewHelp.InputString("Đường dẫn file sách: ", Model.File, ConsoleColor.DarkRed);
        }
    }
}
