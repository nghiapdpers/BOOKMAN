namespace BookMan.ConsoleApp.Views
{
    using Framework;
    using Models;
    /// <summary>
    /// Class hiển thị danh sách các cuốn sách
    /// </summary>
    internal class BookListView : ViewBase<Book[]>
    {
        public BookListView(Book[] books) : base(books) { }

        /// <summary>
        /// Hiển thị ra danh sách các cuốn sách
        /// </summary>
        public override void Render()
        {
            if (Model.Length == 0)
            {
                ViewHelp.WriteLine("Không có sách", System.ConsoleColor.Red);
                return;
            }

            for (int i = 0; i < Model.Length; i++)
            {
                var book = Model[i];

                ViewHelp.Write($"[{book.Id}] ", System.ConsoleColor.Magenta);
                ViewHelp.WriteLine(book.Name, book.Reading ? System.ConsoleColor.DarkYellow : System.ConsoleColor.White);
            }
        }
    }
}
