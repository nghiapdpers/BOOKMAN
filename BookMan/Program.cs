using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.DataServices;
using BookMan.ConsoleApp.Framework;
using System;

namespace BookMan.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            BookControllers controllers = new(new SimpleDataAcess());
            PrepareOptions();
            PrepareRouter(controllers);
            while (true)
            {
                try
                {

                    ViewHelp.Write("#BookManCLI>", ConsoleColor.DarkGreen);
                    string input = Console.ReadLine();

                    Router.Instance.Forward(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

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
            }, (o, p) => controllers.Help("help"));

            r.Register("create", (o, p) => controllers.Create());

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
                "clear", "cls"
            }, (o, p) =>
            {
                Console.Clear();
            });
        }
    }
}
