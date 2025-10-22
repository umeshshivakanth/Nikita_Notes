using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Application.Mappings;
using Web.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<NotesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Configure Dependency Injection
builder.Services.AddScoped<INoteRepository, NoteRepository>(); // Infrastructure repo implements Application interface
builder.Services.AddScoped<INoteService, NoteService>();       // Application service

var app = builder.Build();

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Note}/{action=Index}/{id?}");

app.Run();
