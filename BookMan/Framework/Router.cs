using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookMan.ConsoleApp.Framework
{
    /// Khai báo các kiểu dữ liệu sử dụng
    using HelperMap = Dictionary<string, HelpAction>;
    using RouterMap = Dictionary<string, ControllerAction>;
    public delegate void ControllerAction(Router.Request request);
    public delegate void HelpAction();
    /// <summary>
    /// Class Router ánh xạ các lệnh của chương trình
    /// </summary>
    public class Router
    {
        /// <summary>
        /// Singleton cho class
        /// </summary>
        private static Router _instance;
        public static Router Instance
        {
            private set { }
            get
            {
                _instance ??= new Router();

                return _instance;
            }
        }
        /// <summary>
        /// Map các lệnh được ánh xạ
        /// </summary>
        private RouterMap _routerMap;
        /// <summary>
        /// Map các hướng dẫn được ánh xạ
        /// </summary>
        private HelperMap _helperMap;
        private Router()
        {
            _routerMap = new RouterMap();
            _helperMap = new HelperMap();
        }

        /// <summary>
        /// Đăng ký một lệnh vào router
        /// </summary>
        /// <param name="key">lệnh đăng ký</param>
        /// <param name="action">hàm khi gọi tới lệnh đó</param>
        /// <param name="help">hàm hướng dẫn cho lệnh đó</param>
        public void Register(string[] key, ControllerAction action, HelpAction help = null)
        {
            for (int i = 0; i < key.Length; i++)
            {
                Register(key[i], action, help);
            }
        }

        /// <summary>
        /// Đăng ký một lệnh vào router
        /// </summary>
        /// <param name="key">lệnh đăng ký</param>
        /// <param name="action">hàm khi gọi tới lệnh đó</param>
        /// <param name="help">hàm hướng dẫn cho lệnh đó</param>
        public void Register(string key, ControllerAction action, HelpAction help = null)
        {
            if (!_routerMap.ContainsKey(key))
            {
                _routerMap[key] = action;
                if (help != null)
                    _helperMap[key] = help;
            }
        }

        /// <summary>
        /// Thực thi lệnh
        /// </summary>
        /// <param name="command">chuỗi lệnh nhận vào</param>
        /// <exception cref="Exception">Ngoại lệ khi lệnh không hợp lệ</exception>
        public void Forward(string command)
        {
            var req = new Request(command);
            if (!_routerMap.ContainsKey(req.Route))
            {
                throw new Exception("Không có lệnh này, vui lòng thử lại.\nSử dụng help hoặc /? để biết thêm chi tiết.");
            }

            var validHelp = req.ListOptions.Contains("--help")
                || req.ListOptions.Contains("-h");

            if (validHelp)
            {
                if (_helperMap.ContainsKey(req.Route))
                    _helperMap[req.Route]?.Invoke();
                else
                    throw new Exception("Không có hướng dẫn cho lệnh này, vui lòng thử lại.\nSử dụng help hoặc /? để biết thêm chi tiết.");
                return;
            }

            _routerMap[req.Route]?.Invoke(req);
        }

        /// <summary>
        /// Class yêu cầu từ người dùng
        /// <code>
        /// example: create     --book      name="The new book"
        /// anatony: Route      Option      Parameter
        /// </code>
        /// </summary>
        public class Request
        {
            /// <summary>
            /// Lệnh cần xử lý
            /// </summary>
            public string Route;
            /// <summary>
            /// Tham số truyền vào
            /// </summary>
            public Parameter Parameters;
            /// <summary>
            /// Tùy chọn của lệnh
            /// </summary>
            public List<string> ListOptions;

            public Request(string req)
            {
                ListOptions = new List<string>();
                Analyze(req);
            }

            /// <summary>
            /// Phân tích yêu cầu của người dùng thành các phần nhỏ: lệnh, tham số, tùy chọn
            /// </summary>
            /// <param name="request"></param>
            public void Analyze(string request)
            {
                var regParameter = @"\w+\=\"".*?\""";
                var strParameter = request;
                var lRequest = request.Split(" ");
                bool invalidRoute = string.IsNullOrEmpty(request)
                    || lRequest[0].StartsWith("-")
                    || lRequest[0].StartsWith("--")
                    || lRequest[0].Contains("=");

                if (invalidRoute)
                {
                    throw new Exception("Lệnh không hợp lệ, vui lòng thử lại.\nSử dụng help hoặc /? để biết thêm chi tiết.");
                }
                // Route luôn là lệnh đầu tiên
                Route = lRequest[0];
                strParameter = strParameter.Replace(Route, "");

                if (lRequest.Length > 1)
                {
                    List<string> @params = new List<string>();

                    for (int i = 1; i < lRequest.Length; i++)
                    {
                        var data = lRequest[i];

                        // Options sẽ bắt đầu bằng - hoặc --
                        if (data.StartsWith("-") || data.StartsWith("--"))
                        {
                            if (Options.CheckOptions(Route, data))
                            {
                                ListOptions.Add(data);
                                strParameter = strParameter.Replace(data, "");
                            }
                            else
                            {
                                throw new Exception($"Tùy chọn {data} không tồn tại, vui lòng sử dụng [{Route} --help] để biết thêm hướng dẫn về lệnh này.");
                            }
                        }
                    }

                    // Parameter là các thành phần còn lại trong chuỗi
                    MatchCollection matches = Regex.Matches(strParameter, regParameter);
                    foreach (Match m in matches)
                    {
                        @params.Add(m.Value);
                    }

                    Parameters = new(@params.ToArray());

                }
            }
        }
    }
}
