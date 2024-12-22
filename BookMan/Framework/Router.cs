using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BookMan.ConsoleApp.Framework
{
    public class Router
    {
        /// <summary>
        /// Class yêu cầu từ người dùng
        /// <code>
        /// example: create     --book      name="The new book"
        /// anatony: Route      Option      Parameter
        /// </code>
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

                // Route luôn là lệnh đầu tiên
                Route = lRequest[0];
                Console.WriteLine(Route);
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
                                Console.WriteLine(data);
                                strParameter = strParameter.Replace(data, "");
                            }
                        }
                    }

                    // Parameter là các thành phần còn lại trong chuỗi
                    MatchCollection matches = Regex.Matches(strParameter, regParameter);
                    foreach (Match m in matches)
                    {
                        @params.Add(m.Value);
                        Console.WriteLine(m.Value);
                    }

                    Parameters = new(@params.ToArray());

                }
            }
        }


    }
}
