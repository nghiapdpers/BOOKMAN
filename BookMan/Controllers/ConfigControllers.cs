using BookMan.ConsoleApp.Framework;

namespace BookMan.ConsoleApp.Controllers
{
    internal class ConfigControllers : ControllerBase
    {
        private Config _c = Config.Instance;

        public void ConfigPrompText(string text)
        {
            _c.PrompText = text;
            Success($"Thay đổi thành công, sẽ có tác dụng sau khi khởi động lại.");
        }

        public void CurrentDataAccess()
        {
            var da = _c.DataAcess;
            var df = _c.DataFile;
            Information($"Kiểu lưu trữ hiện tại: {da}\nDữ liệu được lưu vào file: {df}");
        }

        public void ConfigDataAccess(string text)
        {
            switch (text)
            {
                case "json":
                    _c.DataFile = "data.json";
                    _c.DataAcess = text;
                    break;

                case "xml":
                    _c.DataFile = "data.xml";
                    _c.DataAcess = text;
                    break;


                case "bin":
                case "binary":
                    _c.DataFile = "data.dat";
                    _c.DataAcess = text;
                    break;

                default:
                    _c.DataFile = "data.json";
                    _c.DataAcess = text;
                    break;
            }
            Success($"Thay đổi thành công, sẽ có tác dụng sau khi khởi động lại.");
        }
    }
}
