using BookMan.ConsoleApp.Framework;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Views
{
    /// <summary>
    /// class hiển thị thông tin trợ giúp
    /// </summary>
    internal class BookHelpView : ViewBase
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
        public override void Render()
        {
            ViewHelp.WriteLine($"Các lệnh cơ bản (command)");
            foreach (var item in _help)
            {
                ViewHelp.WriteLine($"\t{item.Key,-20}{item.Value}\n");
            }
            ViewHelp.WriteLine($"Sử dụng lệnh theo cấu trúc:\n\tcommand [--options] [parametere=\"value\"]\nhoặc\n\tcommand [parameter=\"value\"] [--options]");
            ViewHelp.WriteLine($"\nĐể biết chi  tiết về các [--options] và [parameter] của các lệnh, vui lòng sử dụng\n\tcommand --help\nhoặc\n\tcommand -h\nhoặc\n\tcommand /?");
        }
    }
}
