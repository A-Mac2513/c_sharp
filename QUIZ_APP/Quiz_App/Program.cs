using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Quiz_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*// Add connection to MySQL database
builder.Services.AddDbContext<Quiz_App_DB>(options =>
{
    var connectionString = "server=localhost;user=root;password=root;database=quiz_app";
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
