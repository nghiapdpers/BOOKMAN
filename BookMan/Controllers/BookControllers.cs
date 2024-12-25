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
            Render(new BookSingleView(book), true, "single");
        }

        /// <summary>
        /// Tạo một cuốn sách
        /// </summary>
        public void Create()
        {
            Render(new BookCreateView());
        }

        /// <summary>
        /// Cập nhật thông tin 1 cuốn sách
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            Book book = Repository.Get(id);
            Render(new BookUpdateView(book));
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
        /// Hiển thị thông tin hỗ trợ.
        /// </summary>
        public override void Help()
        {
            Render(new BookHelpView());
        }
    }
}
