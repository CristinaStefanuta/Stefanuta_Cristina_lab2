using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Models;

namespace Stefanuta_Cristina_lab2.Data
{
    public class Stefanuta_Cristina_lab2Context : DbContext
    {
        public Stefanuta_Cristina_lab2Context (DbContextOptions<Stefanuta_Cristina_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Stefanuta_Cristina_lab2.Models.Book> Book { get; set; } = default!;
    }
}
