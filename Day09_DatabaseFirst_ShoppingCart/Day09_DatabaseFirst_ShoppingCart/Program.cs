using Microsoft.EntityFrameworkCore;
using Day09_DatabaseFirst_ShoppingCart.Models;

var builder = WebApplication.CreateBuilder(args);


// ✅ cấu hình DbContext dùng connection string trong appsettings.json
builder.Services.AddDbContext<ShoppingCartTaoTuCodeFirstContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
