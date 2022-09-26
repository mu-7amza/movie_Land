using Microsoft.Extensions.Options;
using MovieWorld.Data;
using MovieWorld.Data.Services;
using MovieWorld.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<itiDBContext>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Initializer.Seed(app);

app.Run();
