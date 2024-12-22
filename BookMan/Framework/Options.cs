using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Class static lưu toàn bộ options của các lệnh
    /// </summary>
    public static class Options
    {
        /// <summary>
        /// Lưu danh sách option cho từng lệnh, key là lệnh, value là danh sách option
        /// </summary>
        public static Dictionary<string, string[]> ListOptions = new Dictionary<string, string[]>();

        /// <summary>
        /// Thêm danh sách options
        /// </summary>
        /// <param name="key">Lệnh</param>
        /// <param name="value">Danh sách option</param>
        public static void AddListOptions(string key, string[] value = null)
        {
            if (value == null)
                ListOptions.Add(key, Array.Empty<string>());
            else
                ListOptions.Add(key, value);
        }


        /// <summary>
        /// Thêm danh sách options
        /// </summary>
        /// <param name="key">Danh sách lệnh</param>
        /// <param name="value">Danh sách option</param>
        public static void AddListOptions(string[] key, string[] value = null)
        {
            for (int i = 0; i < key.Length; i++)
            {
                AddListOptions(key[i], value);
            }
        }

        /// <summary>
        /// Lấy danh sách options của lệnh
        /// </summary>
        /// <param name="key">Lệnh</param>
        /// <returns></returns>
        public static List<string> GetOptions(string key)
        {
            if (ListOptions.TryGetValue(key, out var value))
                return new List<string>(value);
            else
                return null;
        }

        /// <summary>
        /// Kiểm tra option có thuộc lệnh hay không?
        /// </summary>
        /// <param name="key">Lệnh</param>
        /// <param name="option">option</param>
        /// <returns></returns>
        public static bool CheckOptions(string key, string option)
        {
            var list = GetOptions(key);
            if (list != null)
                return list.Contains(option);
            else
                return false;
        }
    }
}
