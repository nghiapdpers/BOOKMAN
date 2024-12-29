using BookMan.ConsoleApp.Models;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.DataServices
{
    /// <summary>
    /// Interface các method và properties của class DataAccess
    /// </summary>
    internal interface IDataAccess
    {
        List<Book> Books { get; set; }
        /// <summary>
        /// Load dữ liệu
        /// </summary>
        public void Load();
        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        public void SaveChanges();
    }
}
