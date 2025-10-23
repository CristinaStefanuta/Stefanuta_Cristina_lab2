using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Data;
using Stefanuta_Cristina_lab2.Models;

namespace Stefanuta_Cristina_lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Stefanuta_Cristina_lab2.Data.Stefanuta_Cristina_lab2Context _context;

        public IndexModel(Stefanuta_Cristina_lab2.Data.Stefanuta_Cristina_lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
