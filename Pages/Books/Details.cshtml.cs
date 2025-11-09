using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Areas.Identity.Data;
using Stefanuta_Cristina_lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanuta_Cristina_lab2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryIdentityContext _context;

        public DetailsModel(LibraryIdentityContext context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories) 
                .ThenInclude(bc => bc.Category) 
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }

            return Page();
        }
    }
}
