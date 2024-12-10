namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Views;
    internal class BookControllers
    {
        public void Single()
        {
            Book book = new()
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
            BookSingleView view = new(book);
            view.Render();
        }

        public void Create()
        {
            BookCreateView view = new();
            view.Render();
        }

        public void Update()
        {
            Book book = new()
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

            BookUpdateView view = new(book);
            view.Render();
        }
    }
}
