using BookMan.ConsoleApp.Models;

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
}