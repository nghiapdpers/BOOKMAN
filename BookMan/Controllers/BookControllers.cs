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

        public void List()
        {
            Book[] books = new Book[]
            {
                new Book() { Id = 1, Name = "Hello" },
                new Book() { Id = 2, Name = "Hello 2" },
                new Book() { Id = 3, Name = "Hello 3" },
                new Book() { Id = 4, Name = "Hello 4" },
                new Book() { Id = 5, Name = "Hello 5" },
            };

            BookListView view = new(books);
            view.Render();
        }
    }
}
