namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;
    using Models;
    using Views;
    /// <summary>
    /// Controllers sách
    /// </summary>
    internal class BookControllers : ControllerBase
    {
        public BookControllers(SimpleDataAcess context) : base(context)
        {
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

        /// <summary>
        /// Xóa một cuốn sách
        /// </summary>
        /// <param name="id">Id cuốn sách</param>
        /// <param name="processs">Hỏi xác nhận người dùng</param>
        public void Delete(int id, bool processs = true)
        {
            if (processs)
            {
                var b = Repository.Get(id);

                Confirmation(
                    text: $"Bạn muốn xóa cuốn sách {b.Name} chứ?",
                    confirmCommand: $"do-delete id=\"{b.Id}\"");
            }
            else
            {
                Repository.Remove(id);
                Success("Đã xóa sách!");
            }
        }

        /// <summary>
        /// Lọc sách theo từ khóa
        /// </summary>
        /// <param name="keyword">từ khóa</param>
        public void Filter(string keyword)
        {
            var model = Repository.Get(keyword);
            if (model.Length == 0)
            {
                Information($"Không tìm thấy thông tin cuốn sách với từ khóa \"{keyword}\"");
            }
            else
            {
                Render(new BookListView(model));
            }
        }
    }
}
