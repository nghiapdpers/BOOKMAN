using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Models
{
    internal class BookShelf
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { if (value > 0) _id = value; }
        }
        public string Name { set; get; } = "Unknow BookShelf";
        public List<Book> Books { set; get; } = new List<Book>();
        public long CreatedUnixTime { protected set; get; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        public long LatestUpdateUnixTime { protected set; get; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}
