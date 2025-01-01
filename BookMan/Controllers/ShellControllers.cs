using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;
using System.IO;

namespace BookMan.ConsoleApp.Controllers
{
    internal class ShellControllers : ControllerBase
    {
        public ShellControllers(IDataAccess context) : base(context) { }

        public void Shell(string folder, string ext = "txt")
        {
            if (!Directory.Exists(folder))
            {
                Information("Không tìm thấy folder phù hợp, vui lòng thử lại.");
                return;
            }
            var lFile = Directory.GetFiles(folder, $"*.{ext ?? "txt"}", SearchOption.AllDirectories);
            if (lFile.Length == 0)
            {
                Information("Không tìm thấy sách phù hợp trong folder, vui lòng thử lại!");
                return;
            }

            Information($"Tìm thấy {lFile.Length} cuốn sách....");
            foreach (var l in lFile)
            {
                Repository.Insert(new()
                {
                    Name = Path.GetFileNameWithoutExtension(l),
                    File = l,
                });
            }
            Success($"Đã thêm sách vào thư viện!");
        }

        public void Save()
        {
            Repository.SaveChanges();
            Success("Lưu trữ dữ liệu thành công!");
        }
    }
}
