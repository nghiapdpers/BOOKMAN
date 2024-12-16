namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// Class hiển thị danh sách các cuốn sách
    /// </summary>
    internal class BookListView
    {
        public Book[] Books;

        public BookListView(Book[] books)
        {
            Books = books;
        }

        /// <summary>
        /// Hiển thị ra danh sách các cuốn sách
        /// </summary>
        public void Render()
        {
            if (Books.Length == 0)
            {
                ViewHelp.WriteLine("Không có sách", System.ConsoleColor.Red);
                return;
            }

            for (int i = 0; i < Books.Length; i++)
            {
                var book = Books[i];

                ViewHelp.Write($"[{book.Id}] ");
                ViewHelp.WriteLine(book.Name, book.Reading ? System.ConsoleColor.DarkYellow : System.ConsoleColor.White);
            }
        }
    }
}
