using Microsoft.EntityFrameworkCore;
using TvtDay10LabCf.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<TvtDay10LabCfContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("TvtDay10LabCfConnection")));

var tvtConnection = builder.Configuration.GetConnectionString("TvtDay10LabCfConnection");
builder.Services.AddDbContext<TvtDay10LabCfContext>(options =>
    options.UseSqlServer(tvtConnection));
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
    pattern: "{controller=Home}/{action=Index}/{tvtId?}");

app.Run();
