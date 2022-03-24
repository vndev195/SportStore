using Microsoft.EntityFrameworkCore;
using SportStore.Models;
var builder = WebApplication.CreateBuilder(args);

//AddControllersWithViews - sets up the shared objects required by applications using MVC framework and the razor view engine
builder.Services.AddControllersWithViews();

//Entity Framework Core must be configured so that it knows the type of database to which it will connect
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportStoreConnection"]);
});

//Adding dependency injection
builder.Services.AddScoped<IStoreRepository, StoreRepository>();

var app = builder.Build();

// enables support for serving static content from the wwwroot folder
app.UseStaticFiles();

//http://localhost:5000/Soccer
app.MapControllerRoute("category", "{category}",
    new { controller = "Home", action = "Index" });
//registers the MVC Framework as a source of endpoints using a default convention for mapping requests to classes and methods.
//Also tell ASP.Net Core how to match URLs to controller classes
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);
app.Run();
