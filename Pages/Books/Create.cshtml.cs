using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stefanuta_Cristina_lab2.Areas.Identity.Data;
using Stefanuta_Cristina_lab2.Models;
using Microsoft.AspNetCore.Authorization;

namespace Stefanuta_Cristina_lab2.Pages.Books
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly LibraryIdentityContext _context;

        public CreateModel(LibraryIdentityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(
                _context.Author
            .OrderBy(a => a.FirstName) 
            .Select(a => new {
                 ID = a.ID,
                FullName = a.FirstName + " " + a.LastName}),
            "ID",
            "FullName" 
            );
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID","PublisherName");
            
            var book = new Book();
            book.BookCategories = new List<BookCategory>();
            
            PopulateAssignedCategoriesData(_context, book);
            
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var category in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(category)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }
            
            Book.BookCategories = newBook.BookCategories;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
