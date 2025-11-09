using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Models;

namespace Stefanuta_Cristina_lab2.Areas.Identity.Data;
public class LibraryIdentityContext : IdentityDbContext<IdentityUser>
{
    public LibraryIdentityContext(DbContextOptions<LibraryIdentityContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Author { get; set; } = default!;
    public DbSet<Book> Book { get; set; } = default!;
    public DbSet<Borrowing> Borrowing { get; set; } = default!;
    public DbSet<Category> Category { get; set; } = default!;
    public DbSet<Member> Member { get; set; } = default!;
    public DbSet<Publisher> Publisher { get; set; } = default!;
    public DbSet<BookCategory> BookCategory { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
