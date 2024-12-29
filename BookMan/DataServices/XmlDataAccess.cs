using BookMan.ConsoleApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BookMan.ConsoleApp.DataServices
{
    /// <summary>
    /// Class đọc/lưu trữ dữ liệu xml
    /// </summary>
    internal class XmlDataAccess
    {
        public List<Book> Books = new List<Book>();
        private readonly string _file = "data.xml";

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
            var xmlSerialize = new XmlSerializer(typeof(List<Book>));
            using (var reader = XmlReader.Create(_file))
            {
                Books = (List<Book>)xmlSerialize.Deserialize(reader);
            }
        }

        /// <summary>
        /// Lưu dữ liệu vào file
        /// </summary>
        public void SaveChanges()
        {
            var xmlSerialize = new XmlSerializer(typeof(List<Book>));
            using (var writer = XmlWriter.Create(_file))
            {
                xmlSerialize.Serialize(writer, Books);
            }
        }
    }
}
