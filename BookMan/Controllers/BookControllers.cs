namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Views;
    internal class BookControllers
    {
        public void Single()
        {
            Book book = new Book
            {
                Id = 1,
                Authors = "Ngô Tất Tố",
                Name = "Tắt đèn",
                Publisher = "Nhà xuất bản Văn học",
                Year = 2010,
                Edition = 4,
                Isbn = "9999",
                Tags = "Văn học đương đại",
                Rate = 5
            };
            BookSingleView view = new BookSingleView(book);
            view.Render();
        }

        public void Create()
        {
            BookCreateView view = new BookCreateView();
            view.Render();
        }
    }
}
