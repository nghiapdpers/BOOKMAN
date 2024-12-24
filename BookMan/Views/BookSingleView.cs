using System;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// class hiển thị một cuốn sách
    /// </summary>
    internal class BookSingleView : ViewBase<Book>
    {
        public BookSingleView(Book model) : base(model) { }

        /// <summary>
        /// Hiển thị thông tin cuốn sách
        /// </summary>
        public override void Render()
        {
            if (Model == null)
            {
                ViewHelp.WriteLine("Không tìm thấy cuốn sách.", ConsoleColor.Red);
                return;
            }
            ViewHelp.WriteLine("____Thông tin sách____", ConsoleColor.Green);

            ViewHelp.WriteLine($"Tên sách:               {Model.Name}");
            ViewHelp.WriteLine($"Tác giả:                {Model.Authors}");
            ViewHelp.WriteLine($"Nhà xuất bản:           {Model.Publisher}");
            ViewHelp.WriteLine($"Năm xuất bản:           {Model.Year}");
            ViewHelp.WriteLine($"Tái bản lần thứ:        {Model.Edition}");
            ViewHelp.WriteLine($"Thể loại:               {Model.Tags}", ConsoleColor.Cyan);
            ViewHelp.WriteLine($"ISBN:                   {Model.Isbn}");
            ViewHelp.WriteLine($"Đánh giá cá nhân:       {Model.Rate}/5", ConsoleColor.DarkYellow);
            ViewHelp.WriteLine($"Tên File sách:          {Model.FileName}");
            ViewHelp.WriteLine($"Địa chỉ File sách:      {Model.File}");
            ViewHelp.WriteLine($"Đánh dấu sách:          {Model.Reading.ToString(BooleanFormat.reading)}", Model.Reading ? ConsoleColor.Magenta : ConsoleColor.DarkRed);
            if (Model.Reading)
                ViewHelp.WriteLine($"Đọc tới trang:          {Model.PageReading}", ConsoleColor.DarkMagenta);
            ViewHelp.WriteLine($"Số phút đã đọc:         {Model.TotalMinutesRead}", ConsoleColor.Yellow);
            ViewHelp.WriteLine($"Lần đọc gần đây nhất:   {Model.LatestOpenUnixTime}", ConsoleColor.DarkGreen);
            ViewHelp.WriteLine($"Mô tả ngắn:             {Model.ShortDescription}");
        }
    }
}
