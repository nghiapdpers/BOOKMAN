using BookMan.ConsoleApp.Framework;
using BookMan.ConsoleApp.Models;
using static BookMan.ConsoleApp.Framework.Router;

/// <summary>
/// Extension cho các internal class, vì extension internal class không thể viết ở public static class Extension
/// </summary>
internal static class ExtensionHelpers
{

    /// <summary>
    /// Kiểm tra book có null hay không?
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    public static bool IsNull(this Book book)
    {
        if (book == null)
        {
            return true;
        }
        return false;
    }

    public static Book ToBook(this Parameter parameter)
    {
        Book book = new Book();

        if (parameter.ContainsKey("id")) book.Id = parameter["id"].ToInt();
        if (parameter.ContainsKey("name")) book.Name = parameter["name"];
        if (parameter.ContainsKey("authors")) book.Authors = parameter["authors"];
        if (parameter.ContainsKey("publisher")) book.Publisher = parameter["publisher"];
        if (parameter.ContainsKey("year")) book.Year = (parameter["year"]).ToInt();
        if (parameter.ContainsKey("edition")) book.Edition = (parameter["edition"]).ToInt();
        if (parameter.ContainsKey("isbn")) book.Isbn = parameter["isbn"];
        if (parameter.ContainsKey("file")) book.File = parameter["file"];
        if (parameter.ContainsKey("tags")) book.Tags = parameter["tags"];
        if (parameter.ContainsKey("description")) book.ShortDescription = parameter["description"];
        if (parameter.ContainsKey("rate")) book.Rate = (parameter["rate"]).ToSbyte();

        return book;
    }

    public static Book ToBook(this Request request)
    {
        Book book = new Book();

        var parameter = request.Parameters;

        if (parameter.ContainsKey("id")) book.Id = parameter["id"].ToInt();
        if (parameter.ContainsKey("name")) book.Name = parameter["name"];
        if (parameter.ContainsKey("authors")) book.Authors = parameter["authors"];
        if (parameter.ContainsKey("publisher")) book.Publisher = parameter["publisher"];
        if (parameter.ContainsKey("year")) book.Year = (parameter["year"]).ToInt();
        if (parameter.ContainsKey("edition")) book.Edition = (parameter["edition"]).ToInt();
        if (parameter.ContainsKey("isbn")) book.Isbn = parameter["isbn"];
        if (parameter.ContainsKey("file")) book.File = parameter["file"];
        if (parameter.ContainsKey("tags")) book.Tags = parameter["tags"];
        if (parameter.ContainsKey("description")) book.ShortDescription = parameter["description"];
        if (parameter.ContainsKey("rate")) book.Rate = (parameter["rate"]).ToSbyte();

        return book;
    }

    public static bool IsValid(this Parameter parameter)
    {
        if (parameter == null) return false;
        return !parameter.IsEmpty();
    }

    public static bool IsValid(this Request request)
    {
        return request.ListOptions.Count > 0 || request.Parameters.IsValid();
    }
}