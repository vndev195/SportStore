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

//Set up the services used by Razor Pages
builder.Services.AddRazorPages();

//session state, which is data associated with a series of requests made by a user.
//the session data is lost when the application is stopped or restarted. 
//The AddDistributedMemoryCache method call sets up the in-memory data store.
//The AddSession method registers the services used to access session data
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// enables support for serving static content from the wwwroot folder
app.UseStaticFiles();

//Adding session state to middleware
//the UseSession method allows the session system to automatically associate requests with sessions when they arrive from the client.
app.UseSession();

//http://localhost:5000/Soccer
app.MapControllerRoute("category", "{category}",
    new { controller = "Home", action = "Index" });
//registers the MVC Framework as a source of endpoints using a default convention for mapping requests to classes and methods.
//Also tell ASP.Net Core how to match URLs to controller classes
app.MapDefaultControllerRoute();

//registers Razor Pages as endpoints that the URL routing system can use to handle requrests
app.MapRazorPages();
SeedData.EnsurePopulated(app);
app.Run();
