namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;
    using Models;
    using System.Collections.Generic;
    using Views;
    /// <summary>
    /// Controllers sách
    /// </summary>
    internal class BookControllers
    {
        /// <summary>
        /// Liên kết công cụ lưu trữ dữ liệu
        /// </summary>
        protected Repository Repository;

        public BookControllers(SimpleDataAcess context)
        {
            Repository = new(context);
        }

        /// <summary>
        /// Hiển thị thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id"></param>
        public void Single(int id)
        {
            Book book = Repository.Get(id);
            BookSingleView view = new(book);
            view.Render();
        }

        /// <summary>
        /// Tạo một cuốn sách
        /// </summary>
        public void Create()
        {
            BookCreateView view = new();
            view.Render();
        }

        /// <summary>
        /// Cập nhật thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            Book book = Repository.Get(id);
            BookUpdateView view = new(book);
            view.Render();
        }

        /// <summary>
        /// Hiển thị danh sách cuốn sách
        /// </summary>
        /// <param name="keyword"></param>
        public void List(string keyword = "")
        {
            BookListView view = new(Repository.GetAll());
            view.Render();
        }

        /// <summary>
        /// Hiển thị thông tin hỗ trợ.
        /// </summary>
        public void Help(List<string> options, Parameter parameter)
        {
            BookHelpView view = new();
            view.Render();
        }
    }
}
