using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Areas.Identity.Data;
using Stefanuta_Cristina_lab2.Models;

namespace Stefanuta_Cristina_lab2.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly LibraryIdentityContext _context;

        public IndexModel(LibraryIdentityContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Member.ToListAsync();
        }
    }
}
