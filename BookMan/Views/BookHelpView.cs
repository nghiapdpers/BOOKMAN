using BookMan.ConsoleApp.Framework;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// class hiển thị thông tin trợ giúp
    /// </summary>
    internal class BookHelpView
    {
        private Dictionary<string, string> _help = new()
        {
            {"single", "xem thông tin một cuốn sách" },
            {"create", "tạo ra một cuốn sách và lưu trữ" },
            {"update", "cập nhật thông tin một cuốn sách" },
            {"list", "hiển thị danh sách các cuốn sách" },
            {"q/quit/exit", "thoát chương trình" },
            {"clear/cls", "xóa màn hình" },
        };

        /// <summary>
        /// Hiển thị thông tin trợ giúp.
        /// </summary>
        public void Render()
        {
            foreach (var item in _help)
            {
                ViewHelp.WriteLine($"{item.Key,-20}{item.Value}");
            }
        }
    }
}
