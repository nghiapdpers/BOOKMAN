using Newtonsoft.Json;
using System.IO;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Class cha cho các view
    /// </summary>
    public abstract class ViewBase
    {
        /// <summary>
        /// Router sử dụng để thực hiện hành động
        /// </summary>
        protected Router Router = Router.Instance;
        public ViewBase() { }

        /// <summary>
        /// Helper hỗ trợ người dùng các lệnh
        /// </summary>
        public static void Help() { }

        /// <summary>
        /// Render ra thông tin của view
        /// </summary>
        public abstract void Render();
    }

    /// <summary>
    /// Class cha cho các view, bổ sung thêm phương thức lưu file
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ViewBase<T> : ViewBase
    {
        protected T Model;
        public ViewBase(T model)
        {
            Model = model;
        }
        /// <summary>
        /// Lưu file vào thư mục với tên
        /// </summary>
        /// <param name="fileName">tên file</param>
        /// <param name="folder">thư mục lưu file</param>
        public virtual void SaveToPath(string fileName, string folder = null)
        {
            string filePath = fileName + ".json";
            if (folder != null)
            {
                filePath = folder + filePath;
            }

            var json = JsonConvert.SerializeObject(Model);
            File.WriteAllText(filePath, json);
            ViewHelp.WriteLine($"File được lưu tại: {filePath}");
        }
    }
}
