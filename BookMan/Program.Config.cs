using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Views;
using System;
using System.Collections.Generic;

namespace BookMan.ConsoleApp
{
    internal partial class Program
    {
        private static Dictionary<string, string> _help
        {
            get => new(){
                {"view", "xem thông tin một/danh sách cuốn sách" },
                {"create", "tạo ra một cuốn sách và lưu trữ" },
                {"update", "cập nhật thông tin một cuốn sách" },
                {"delete", "xóa một cuốn sách" },
                {"q/quit/exit", "thoát chương trình" },
                {"clear/cls", "xóa màn hình" },
            };
        }

        private static Exception notValidAction = new("Hành động không xác định, vui lòng sử dụng \n\t\t[command --help]\n để biết thêm chi tiết hướng dẫn");

        /// <summary>
        /// Chuẩn bị dữ liệu options cho các lệnh
        /// </summary>
        public static void PrepareOptions()
        {
            Options.AddListOptions("help");

            Options.AddListOptions("create", new string[]
            {
                "--book", "--shelf", "-b", "-sh", "-d", "--default", "--help", "-h"
            });

            Options.AddListOptions("do-create", new string[]
            {
                "--book", "--shelf", "-b", "-sh", "-d", "--default"
            });

            Options.AddListOptions("view", new string[]
            {
                "--single", "--list"
            });

            Options.AddListOptions("delete", new string[]
            {
                "--skip", "-s"
            });

            Options.AddListOptions("update");

            Options.AddListOptions("do-update", value: new string[]
            {
                "--book", "--shelf", "-b", "-sh", "-d", "--default"
            });

            Options.AddListOptions("filter", new string[]
            {
                "--book", "--shelf", "-b", "-sh"
            });

            Options.AddListOptions("shell");

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
        /// <param name="bookControllers"></param>
        /// <param name="shellControllers"></param>
        public static void PrepareRouter(BookControllers bookControllers, ShellControllers shellControllers)
        {
            Router Router = Router.Instance;
            Router.Register(new string[]
            {
                "help", "/?"
            },
            (r) => Help());

            Router.Register(
                "create",
                (r) =>
                {
                    //if (r.InValid()) throw notValidAction;
                    bookControllers.Create();
                },
                () => BookCreateView.Help()
                );

            Router.Register(
                "do-create",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    bookControllers.Create(r.ToBook());
                });

            Router.Register(
                "view",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    if (r.ListOptions.Contains("--single"))
                        bookControllers.Single(r.Parameters["id"].ToInt());
                    else if (r.ListOptions.Contains("--list"))
                        bookControllers.List();
                });

            Router.Register(
                "update",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    bookControllers.Update(r.Parameters["id"].ToInt());
                });

            Router.Register(
               "do-update",
               (r) =>
               {
                   if (!r.IsValid()) throw notValidAction;
                   bookControllers.Update(r.Parameters["id"].ToInt());
               });

            Router.Register(
                "delete",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    if (r.ContainOptions(new string[] { "--skip", "-s" }))
                    {
                        Router.Forward($"do-delete id=\"{r.Parameters["id"]}\"");
                    }
                    bookControllers.Delete(r.Parameters["id"].ToInt());
                });

            Router.Register(
                "do-delete",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    bookControllers.Delete(r.Parameters["id"].ToInt(), false);
                });

            Router.Register(
                "filter",
                (r) =>
                {
                    if (!r.IsValid()) throw notValidAction;
                    bookControllers.Filter(r.Parameters["keyword"]);
                });

            Router.Register(
             "shell",
             (r) =>
             {
                 if (!r.IsValid()) throw notValidAction;
                 shellControllers.Shell(r.Parameters?["folder"], r.Parameters?["ext"]);
             });

            Router.Register(new string[]
            {
                "exit", "quit", "q"
            },
            (r) =>
            {
                Environment.Exit(0);
            });

            Router.Register(new string[]
            {
                "about", "abt"
            },
            (r) =>
            {
                About();
            });

            Router.Register(new string[]
            {
                "clear", "cls"
            },
            (r) =>
            {
                Console.Clear();
            });
        }

        /// <summary>
        /// Hỗ trợ về các lệnh của controller đã đăng ký với router
        /// </summary>
        public static void Help()
        {
            ViewHelp.WriteLine($"Sử dụng lệnh theo cấu trúc:\n\tcommand [--options] [parametere=\"value\"]\nhoặc\n\tcommand [parameter=\"value\"] [--options]");
            ViewHelp.WriteLine($"\nCác lệnh cơ bản (command)");
            foreach (var item in _help)
            {
                ViewHelp.WriteLine($"\t{item.Key,-20}{item.Value}\n");
            }
            ViewHelp.WriteLine($"\nĐể biết chi  tiết về các [--options] và [parameter] của các lệnh, vui lòng sử dụng\n\tcommand --help\nhoặc\n\tcommand -h\nhoặc\n\tcommand /?");
        }

        public static void About()
        {
            ViewHelp.WriteLine("Small BookShelf App\nProgrammed by Pham Duy Nghia 2024", ConsoleColor.Green);
        }
    }
}