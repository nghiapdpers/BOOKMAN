using BookMan.ConsoleApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BookMan.ConsoleApp.DataServices
{
    /// <summary>
    /// Class lưu trữ/đọc dữ liệu dạng binary
    /// </summary>
    internal class BinaryDataAccess
    {
        public List<Book> Books = new List<Book>();
        private readonly string _file = "data.dat";

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
            using (FileStream stream = File.OpenRead(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Books = formatter.Deserialize(stream) as List<Book>;
            }
        }

        /// <summary>
        /// Lưu dữ liệu vào file
        /// </summary>
        public void SaveChanges()
        {
            using (FileStream stream = File.OpenWrite(_file))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Books);
            }
        }
    }
}
