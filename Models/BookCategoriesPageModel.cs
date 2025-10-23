using Microsoft.AspNetCore.Mvc.RazorPages;
using Stefanuta_Cristina_lab2.Data;
namespace Stefanuta_Cristina_lab2.Models;

public class BookCategoriesPageModel:PageModel
{
    public List<AssignedCategoryData> AssignedCategoriesDataList;

    public void PopulateAssignedCategoriesData(Stefanuta_Cristina_lab2Context context, Book book)
    {
        var allCategories = context.Category;
        var bookCategories = new HashSet<int>(
                book.BookCategories.Select(c => c.CategoryID));
        AssignedCategoriesDataList = new List<AssignedCategoryData>();
        foreach (var category in allCategories)
        {
            AssignedCategoriesDataList.Add(new AssignedCategoryData
            {
                CategoryID = category.ID,
                Name = category.CategoryName,
                Assigned = bookCategories.Contains(category.ID)
            });
        }
    }

    public void UpdateBookCategories(Stefanuta_Cristina_lab2Context context, string[] selectedCategories,
        Book bookToUpdate)
    {
        if (selectedCategories == null)
        {
            bookToUpdate.BookCategories = new List<BookCategory>();
            return;
        }
        var selectedCategoriesHS = new HashSet<string>(selectedCategories);
        var bookCategories = new HashSet<int>(
                bookToUpdate.BookCategories.Select(c => c.CategoryID));
        foreach (var category in context.Category)
        {
            if (selectedCategoriesHS.Contains(category.ID.ToString()))
            {
                if (!bookCategories.Contains(category.ID))
                {
                    bookToUpdate.BookCategories.Add(
                        new BookCategory
                        {
                            BookID = bookToUpdate.ID,
                            CategoryID = category.ID
                        });
                }
            }
            else
            {
                if (bookCategories.Contains(category.ID))
                {
                    BookCategory bookToRemove =
                        bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == category.ID);
                    context.Remove(bookToRemove);
                }
            }
        }
    }
}