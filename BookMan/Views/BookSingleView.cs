using System;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    internal class BookSingleView
    {
        public Book Model;
        public BookSingleView(Book model)
        {
            this.Model = model;
        }

        public void Render()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            if (Model == null)
            {
                WriteLine("Không tìm thấy cuốn sách.", ConsoleColor.Red);
                return;
            }
            WriteLine("Thông tin sách", ConsoleColor.Green);

            WriteLine($"Tên sách:               {Model.Name}");
            WriteLine($"Tác giả:                {Model.Authors}");
            WriteLine($"Nhà xuất bản:           {Model.Publisher}");
            WriteLine($"Năm xuất bản:           {Model.Year}");
            WriteLine($"Tái bản lần thứ:        {Model.Edition}");
            WriteLine($"Thể loại:               {Model.Tags}", ConsoleColor.Cyan);
            WriteLine($"ISBN:                   {Model.Isbn}");
            WriteLine($"Đánh giá cá nhân:       {Model.Rate}/5", ConsoleColor.DarkYellow);
            WriteLine($"Tên File sách:          {Model.FileName}");
            WriteLine($"Địa chỉ File sách:      {Model.File}");
            WriteLine($"Đánh dấu sách:          {(Model.Reading ? "Đang đọc" : "Chưa đánh dấu")}", Model.Reading ? ConsoleColor.Magenta : ConsoleColor.DarkRed);
            if (Model.Reading)
                WriteLine($"Đọc tới trang:          {Model.PageReading}", ConsoleColor.DarkMagenta);
            WriteLine($"Số phút đã đọc:         {Model.TotalMinutesRead}", ConsoleColor.Yellow);
            WriteLine($"Lần đọc gần đây nhất:   {Model.LatestOpenUnixTime}", ConsoleColor.DarkGreen);
            WriteLine($"Mô tả ngắn:             {Model.ShortDescription}");
        }

        public void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
