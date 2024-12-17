using System.Collections.Generic;

namespace BookMan.ConsoleApp.Framework
{
    public class Router
    {
        /// <summary>
        /// Class yêu cầu từ người dùng
        /// </summary>
        internal class Request
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
            public string[] Options { get; set; }

            public Request(string req)
            {
                Analyze(req);
            }

            /// <summary>
            /// Phân tích yêu cầu của người dùng thành các phần nhỏ: lệnh, tham số, tùy chọn
            /// </summary>
            /// <param name="request"></param>
            public void Analyze(string request)
            {
                var splRequest = request.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
                Route = splRequest[0];
                if (splRequest.Length > 1)
                {
                    List<string> opt = new List<string>();
                    List<string> @params = new List<string>();
                    for (int i = 1; i < splRequest.Length; i++)
                    {
                        var data = splRequest[i];

                        if (data.StartsWith("-") || data.StartsWith("--"))
                        {
                            opt.Add(data);
                        }
                        else if (data.Contains("="))
                        {
                            @params.Add(data);
                        }
                    }

                    Options = opt.ToArray();
                    Parameters = new(@params.ToArray());
                }
            }
        }


    }
}
