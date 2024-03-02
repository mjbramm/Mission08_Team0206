using Mission08_Team0206.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sqliteConnection"]); // Defines our connection to the sqlite database
});

builder.Services.AddScoped<ITaskRepository, EFTaskRepository>();

var app = builder.Build();

app.UseHttpsRedirection(); // Redirects Http requests to be Https

app.UseStaticFiles(); // Enables use of wwwroot files

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Maps default route to the index and allows for passing ids through the URL

app.Run();
