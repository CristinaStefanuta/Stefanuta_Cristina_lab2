namespace Stefanuta_Cristina_lab2.Models;

public class BookData
{
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Category> BookCategories { get; set; }
}