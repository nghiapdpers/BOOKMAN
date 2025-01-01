using System;

namespace BookMan.ConsoleApp
{
    using BookMan.ConsoleApp.Framework;

    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            PrepareOptions();
            PrepareRouter();

            var promp = Config.Instance.PrompText;

            while (true)
            {
                ViewHelp.Write($"# {promp} >>> ", ConsoleColor.Yellow);
                string input = Console.ReadLine();

                try
                {
                    Router.Instance.Forward(input);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message, ex.StackTrace);
                    var view = new MessageView(new Message
                    {
                        Description = ex.Message,
                        Type = MessageType.ERROR
                    });

                    view.Render();
                }
                finally
                {
                    ViewHelp.WriteLine("");
                }
            }
        }
    }
}
