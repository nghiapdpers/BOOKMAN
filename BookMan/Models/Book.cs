using System;

namespace BookMan.ConsoleApp.Models
{
    /// <summary>
    /// Lớp sách điện tử
    /// </summary>
    internal class Book
    {
        private int _id = 1;
        /// <summary>
        /// ID duy nhất của sách, lớn hơn 0
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { if (value > 0) _id = value; }
        }
        private string _authors = "Unknow Authors";
        /// <summary>
        /// Danh sách tác giả của cuốn sách, khác rỗng
        /// </summary>
        public string Authors
        {
            get { return _authors; }
            set { if (!string.IsNullOrEmpty(value)) _authors = value; }
        }
        private string _name;
        /// <summary>
        /// Tên sách, khác rỗng
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) _name = value; }
        }
        /// <summary>
        /// Nhà xuất bản cuốn sách, mặc định Unknow Publisher
        /// </summary>
        public string Publisher { set; get; } = "Unknow Publisher";
        /// <summary>
        /// Năm xuất bản, mặc định 1970
        /// </summary>
        public int Year { set; get; } = 1970;
        /// <summary>
        /// Lần tái bản, mặc định 1
        /// </summary>
        public int Edition { set; get; } = 1;
        /// <summary>
        /// ISBN của sách, mặc định Unknow ISBN
        /// </summary>
        public string Isbn { set; get; } = "Unknow ISBN";
        /// <summary>
        /// Thể loại sách, người dùng tự định nghĩa, mặc định rỗng
        /// </summary>
        public string Tags { set; get; } = "";
        /// <summary>
        /// Mô tả ngắn về nội dung cuốn sách.
        /// </summary>
        public string ShortDescription { set; get; } = "";
        private sbyte _rate;
        /// <summary>
        /// Đánh giá cá nhân, giới hạn từ 1 tới 5
        /// </summary>
        public sbyte Rate
        {
            get { return _rate; }
            set { if (value >= 1 || value <= 5) _rate = value; }
        }
        /// <summary>
        /// Đánh dấu đang đọc cuốn sách này, mặc định là false (đang không đọc)
        /// </summary>
        public bool Reading { set; get; } = false;
        /// <summary>
        /// Đánh dấu trang đang đọc, mặc định là 0.
        /// </summary>
        public int PageReading { set; get; } = 0;
        private string _file = "";
        /// <summary>
        /// Đường dẫn tới file sách, mặc định là rỗng.
        /// </summary>
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }
        }
        /// <summary>
        /// Tên file sách, lấy ra từ file sách.
        /// </summary>
        public string FileName { get { return System.IO.Path.GetFileName(_file); } }
        /// <summary>
        /// Thời gian mở sách gần đây nhất, lưu trữ ở dạng Unix Timestamp, mặc định là 0.
        /// </summary>
        public long LatestOpenUnixTime { set; get; } = 0;
        /// <summary>
        /// Tổng số phút đã đọc cuốn sách, mặc định là 0.
        /// </summary>
        public int TotalMinutesRead { set; get; } = 0;
    }
}
