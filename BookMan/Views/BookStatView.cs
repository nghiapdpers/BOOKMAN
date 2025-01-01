using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// Class hiển thị danh sách sách theo thống kê
    /// </summary>
    internal class BookStatView : ViewBase<IEnumerable<IGrouping<string, Book>>>
    {
        public BookStatView(IEnumerable<IGrouping<string, Book>> books) : base(books) { }

        public override void Render()
        {
            foreach (var g in Model)
            {
                ViewHelp.WriteLine($"{g.Key}", System.ConsoleColor.DarkGreen);

                foreach (var b in g)
                {
                    ViewHelp.Write($"[{b.Id}]", System.ConsoleColor.Magenta);
                    ViewHelp.WriteLine($"{b.Name,-20}", b.Reading ? System.ConsoleColor.DarkYellow : System.ConsoleColor.White);
                }

                ViewHelp.WriteLine("");
            }
        }
    }
}
