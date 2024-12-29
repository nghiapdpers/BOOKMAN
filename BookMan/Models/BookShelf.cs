using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Models
{
    /// <summary>
    /// Class dữ liệu kệ sách
    /// </summary>
    public class BookShelf
    {
        private int _id;
        /// <summary>
        /// ID kệ sách
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { if (value > 0) _id = value; }
        }
        /// <summary>
        /// Tên kệ sách
        /// </summary>
        public string Name { set; get; } = "Unknow BookShelf";
        /// <summary>
        /// Danh sách cuốn sách trên kệ
        /// </summary>
        public List<Book> Books { set; get; } = new List<Book>();
        /// <summary>
        /// Thời gian tạo kệ sách
        /// </summary>
        public long CreatedUnixTime { protected set; get; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        /// <summary>
        /// Lần cập nhật kệ sách gần nhất
        /// </summary>
        public long LatestUpdateUnixTime { protected set; get; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}
