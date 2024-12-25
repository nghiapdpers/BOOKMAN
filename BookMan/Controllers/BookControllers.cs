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
    internal class BookControllers : ControllerBase
    {
        protected override Dictionary<string, string> _help
        {
            get => new(){
                {"single", "xem thông tin một cuốn sách" },
                {"create", "tạo ra một cuốn sách và lưu trữ" },
                {"update", "cập nhật thông tin một cuốn sách" },
                {"list", "hiển thị danh sách các cuốn sách" },
                {"q/quit/exit", "thoát chương trình" },
                {"clear/cls", "xóa màn hình" },
            };
        }

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
            Render(new BookSingleView(book));
        }

        /// <summary>
        /// Tạo một cuốn sách
        /// </summary>
        public void Create(Book model = null)
        {
            if (model.IsNull())
            {
                Render(new BookCreateView());
            }
            else
            {
                Repository.Insert(model);
                Success("Tạo sách thành công");
            }
        }

        /// <summary>
        /// Cập nhật thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id, Book model = null)
        {
            if (model.IsNull())
            {
                Book book = Repository.Get(id);
                Render(new BookUpdateView(book));
            }
            else
            {
                Repository.Update(model);
                Success("Cập nhật sách thành công");
            }
        }

        /// <summary>
        /// Hiển thị danh sách cuốn sách
        /// </summary>
        /// <param name="keyword"></param>
        public void List(string keyword = "")
        {
            Render(new BookListView(Repository.GetAll()));
        }
    }
}
