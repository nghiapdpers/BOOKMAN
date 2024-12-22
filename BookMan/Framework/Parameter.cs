using System.Collections.Generic;

namespace BookMan.ConsoleApp.Framework
{
    /// <summary>
    /// Class tham số của lệnh truyền vào
    /// </summary>
    public class Parameter
    {
        private readonly Dictionary<string, string> _parameters = new Dictionary<string, string>();

        /// <summary>
        /// Truy cập vào giá trị của tham số bằng key indexing
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                if (_parameters.ContainsKey(key))
                    return _parameters[key];
                return null;
            }
            set
            { _parameters[key] = value; }
        }

        /// <summary>
        /// Check tham số có chứa key không
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            return _parameters.ContainsKey(key);
        }

        public Parameter(string[] param)
        {
            foreach (string p in param)
            {
                var pSplit = p.Split('=');
                if (pSplit.Length == 2)
                {
                    _parameters[pSplit[0]] = pSplit[1];
                }
            }
        }
    }
}
