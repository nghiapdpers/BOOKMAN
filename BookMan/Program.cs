using BookMan.ConsoleApp.Controllers;

namespace BookMan.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookControllers controllers = new BookControllers();

            controllers.Single();
        }
    }
}
