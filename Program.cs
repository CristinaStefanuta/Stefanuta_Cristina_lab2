using Microsoft.EntityFrameworkCore;
using Stefanuta_Cristina_lab2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("LibraryDbConnection") ?? throw new InvalidOperationException("Connection string 'LibraryDbConnection' not found.");

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
        options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. AM ADĂUGAT UseAuthentication(). Este OBLIGATORIU.
// Trebuie să fie MEREU înainte de UseAuthorization().
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();