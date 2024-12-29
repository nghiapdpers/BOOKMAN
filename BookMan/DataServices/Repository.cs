using BookMan.ConsoleApp.Models;
using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
    /// <summary>
    /// Lớp quản trị dữ liệu, thêm, xóa, cập nhật...
    /// </summary>
    internal class Repository
    {
        /// <summary>
        /// Liên kết với lớp lưu trữ dữ liệu
        /// </summary>
        private readonly JsonDataAccess _context;

        public Repository(JsonDataAccess context)
        {
            _context = context;
            _context.Load();
        }
        /// <summary>
        /// Lấy tất cả sách
        /// </summary>
        /// <returns></returns>
        public Book[] GetAll() => _context.Books.ToArray();
        /// <summary>
        /// Lưu tất cả sách vào dữ liệu
        /// </summary>
        public void SaveChanges() => _context.SaveChanges();
        /// <summary>
        /// Lấy sách theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book Get(int id)
        {
            foreach (var b in _context.Books)
            {
                if (b.Id == id)
                {
                    return b;
                }
            }

            return null;
        }
        /// <summary>
        /// Lấy sách theo keyword (tên, tác giả, nhà xuất bản, mô tả, thể loại).
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public Book[] Get(string keyword)
        {
            List<Book> temp = new();

            foreach (Book book in _context.Books)
            {
                bool logic = book.Name.ToLower().Contains(keyword.ToLower())
                    || book.Publisher.ToLower().Contains(keyword.ToLower())
                    || book.ShortDescription.ToLower().Contains(keyword.ToLower())
                    || book.Tags.ToLower().Contains(keyword.ToLower())
                    || book.Authors.ToLower().Contains(keyword.ToLower());
                if (logic)
                {
                    temp.Add(book);
                }
            }

            return temp.ToArray();
        }
        /// <summary>
        /// Thêm sách vào dữ liệu
        /// </summary>
        /// <param name="book"></param>
        public void Insert(Book book)
        {
            int LatestIndex = _context.Books.Count - 1;
            int id = LatestIndex < 0 ? 1 : _context.Books[LatestIndex].Id + 1;
            book.Id = id;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        /// <summary>
        /// Xóa sách khỏi dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(int id)
        {
            Book b = Get(id);

            if (b.IsNull())
            {
                return false;
            }

            _context.Books.Remove(Get(id));
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Cập nhật thông tin sách
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Update(Book book)
        {
            Book b = Get(book.Id);
            if (b.IsNull())
            {
                return false;
            }

            b.Id = book.Id;
            b.Name = book.Name;
            b.Authors = book.Authors;
            b.Publisher = book.Publisher;
            b.Isbn = book.Isbn;
            b.Edition = book.Edition;
            b.Reading = book.Reading;
            b.PageReading = book.PageReading;
            b.Tags = book.Tags;
            b.Year = book.Year;
            b.File = book.File;
            b.ShortDescription = book.ShortDescription;
            b.TotalMinutesRead = book.TotalMinutesRead;
            b.Rate = book.Rate;
            return true;
        }

        /// <summary>
        /// Lấy danh sách các cuốn sách theo điều kiện
        /// </summary>
        /// <param name="predicate">Hàm điều kiện trả về bool</param>
        /// <returns></returns>
        public Book[] Get(Predicate<Book> predicate)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in GetAll())
            {
                if (predicate(book))
                {
                    books.Add(book);
                }
            }

            return books.ToArray();
        }

        /// <summary>
        /// Xóa dữ liệu sách
        /// </summary>
        public void ClearBook()
        {
            _context.Books.Clear();
        }
    }
}
