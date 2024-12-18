﻿using BookMan.ConsoleApp.Controllers;
using BookMan.ConsoleApp.DataServices;
using System;

namespace BookMan.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            BookControllers controllers = new BookControllers(new SimpleDataAcess());

            while (true)
            {

                Console.Write("BookManCLI> ");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    //function command
                    case "single":
                        controllers.Single(1);
                        break;
                    case "create":
                        controllers.Create();
                        break;
                    case "update":
                        controllers.Update(1);
                        break;
                    case "list":
                        controllers.List();
                        break;

                    //system command
                    case "q":
                    case "quit":
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "clear":
                    case "cls":
                        Console.Clear();
                        break;
                    case "/?":
                    case "-h":
                    case "--help":
                        controllers.Help();
                        break;

                    default:
                        Console.Error.WriteLine("Không tìm thấy lệnh này. Sử dụng /? hoặc -h hoặc --help để xem hướng dẫn.");
                        break;
                }
            }
        }
    }
}
