using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.Framework;
using System;

namespace BookMan.ConsoleApp
{
    internal partial class Program
    {
        /// <summary>
        /// Chuẩn bị dữ liệu options cho các lệnh
        /// </summary>
        public static void PrepareOptions()
        {
            Options.AddListOptions("help");
            Options.AddListOptions("create", new string[]
            {
                "--book", "--shelf", "-b", "-sh", "-d", "--default"
            });
            Options.AddListOptions("view", new string[]
            {
                "--single", "--list"
            });
            Options.AddListOptions("update");
            Options.AddListOptions(new string[]
            {
                "exit", "q", "quit"
            });
            Options.AddListOptions(new string[]
            {
                "cls", "clear"
            });
        }

        /// <summary>
        /// Chuẩn bị dữ liệu cho router
        /// </summary>
        /// <param name="controllers"></param>
        public static void PrepareRouter(BookControllers controllers)
        {
            Router r = Router.Instance;
            r.Register(new string[]
            {
                "help", "/?"
            }, (o, p) => controllers.Help());

            r.Register("create", (o, p) => controllers.Create());
            r.Register("do-create", (o, p) => controllers.Create());

            r.Register("view", (o, p) =>
            {
                if (o.Contains("--single"))
                    controllers.Single(int.Parse(p?["id"]));
                else if (o.Contains("--list"))
                    controllers.List();
            });

            r.Register("update", (o, p) => controllers.Update(int.Parse(p?["id"])));

            r.Register(new string[]
            {
                "exit", "quit", "q"
            }, (o, p) =>
            {
                Environment.Exit(0);
            });

            r.Register(new string[]
            {
                "about", "abt"
            }, (o, p) =>
            {
                About();
            });

            r.Register(new string[]
            {
                "clear", "cls"
            }, (o, p) =>
            {
                Console.Clear();
            });
        }
    }
}