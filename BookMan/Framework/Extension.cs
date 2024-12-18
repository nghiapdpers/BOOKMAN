﻿using System.Collections.Generic;

namespace BookMan.ConsoleApp.Framework
{
    /// sử dụng alias cho kiểu dữ liệu phức tạp.
    using DBoolFormatString = Dictionary<BooleanFormat, Dictionary<bool, string>>;
    using DStringBoolean = Dictionary<string, bool>;
    public enum BooleanFormat
    {
        reading,
        yesno,
    }


    /// <summary>
    /// Extension method cho các kiểu dữ liệu
    /// </summary>
    public static class Extension
    {
        private static readonly DBoolFormatString dBooleanToString = new()
        {
            {
                BooleanFormat.reading, new() { {true, "Đang đọc" }, {false, "Chưa đánh dấu" } }
            },
            {
                BooleanFormat.yesno, new() { {true, "Có" }, {false, "Không" } }
            },
        };

        private static readonly DStringBoolean dStringToTrue = new()
        {
            {"y", true },
            {"true", true },
            {"yes", true },
            {"có", true },
            {"co", true },
        };

        /// <summary>
        /// Biến đổi bool thành chuỗi theo dạng format
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToString(this bool value, BooleanFormat format = BooleanFormat.yesno)
        {
            return dBooleanToString[format][value];
        }

        /// <summary>
        /// Biến đổi chuỗi nhập vào thành boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            if (dStringToTrue[value] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
