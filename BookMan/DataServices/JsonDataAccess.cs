using BookMan.ConsoleApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BookMan.ConsoleApp.DataServices
{
    /// <summary>
    /// Class lưu/đọc dữ liệu từ json
    /// </summary>
    internal class JsonDataAccess : IDataAccess
    {
        public List<Book> Books { get; set; } = new List<Book>();
        private readonly string _file = Config.Instance.DataFile;

        /// <summary>
        /// Load dữ liệu từ local
        /// </summary>
        public void Load()
        {
            if (!File.Exists(_file))
            {
                SaveChanges();
                return;
            }
            var jsonSerialize = new JsonSerializer();
            using (var sReader = new StreamReader(_file))
            using (var jsReader = new JsonTextReader(sReader))
            {
                Books = jsonSerialize.Deserialize<List<Book>>(jsReader);
            }
        }

        /// <summary>
        /// Lưu dữ liệu vào file
        /// </summary>
        public void SaveChanges()
        {
            var jsonSerialize = new JsonSerializer();
            using (var sReader = new StreamWriter(_file))
            using (var jsWriter = new JsonTextWriter(sReader))
            {
                jsonSerialize.Serialize(jsWriter, Books);
            }
        }
    }
}
