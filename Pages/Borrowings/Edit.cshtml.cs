using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Areas.Identity.Data;
using Stefanuta_Cristina_lab2.Models;

namespace Stefanuta_Cristina_lab2.Pages.Borrowings
{
    public class EditModel : PageModel
    {
        private readonly LibraryIdentityContext _context;

        public EditModel(LibraryIdentityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var bookList = _context.Book
                .Include(b => b.Author)
                .Select(x => new {
                    x.ID,
                    BookDetails = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName
                });

            ViewData["BookID"] = new SelectList(bookList, "ID", "BookDetails");


            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
            var bookList = _context.Book
            .Include(b => b.Author)
            .Select(x => new {x.ID, BookDetails = x.Title + " - " + x.Author.LastName + " " + x.Author.FirstName});
            
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookDetails");
           
            ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
           
            return Page();
            }
            
            _context.Attach(Borrowing).State = EntityState.Modified;
            
            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
            return _context.Borrowing.Any(e => e.ID == id);
        }
    }
}
