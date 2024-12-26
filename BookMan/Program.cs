using System;

namespace BookMan.ConsoleApp
{
    using BookMan.ConsoleApp.Controllers;
    using BookMan.ConsoleApp.DataServices;
    using BookMan.ConsoleApp.Framework;

    internal partial class Program
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

                    ViewHelp.Write("# BookManCLI >>> ", ConsoleColor.DarkGreen);
                    string input = Console.ReadLine();

                    Router.Instance.Forward(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message, ex.StackTrace);
                }
            }
        }
    }
}
