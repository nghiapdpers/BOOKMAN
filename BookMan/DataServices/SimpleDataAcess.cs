using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
    using BookMan.ConsoleApp.Models;
    /// <summary>
    /// Lớp lưu trữ dữ liệu cơ bản
    /// </summary>
    internal class SimpleDataAcess : IDataAccess
    {
        public List<Book> Books { set; get; }

        /// <summary>
        /// Load dữ liệu
        /// </summary>
        public void Load()
        {
            this.Books = new()
            {
                new Book() { Id = 1, Name = "Hello" },
                new Book() { Id = 2, Name = "Hello 2" },
                new Book() { Id = 3, Name = "Hello 3" },
                new Book() { Id = 4, Name = "Hello 4" },
                new Book() { Id = 5, Name = "Hello 5" },
            };
        }

        /// <summary>
        /// Lưu thay đổi
        /// </summary>
        public void SaveChanges() { }
    }
}
