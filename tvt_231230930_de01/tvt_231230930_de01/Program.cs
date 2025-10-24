using Microsoft.EntityFrameworkCore;
using Tvt_231230930_de01.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var tvtConnection = builder.Configuration.GetConnectionString("Tvt_231230930_de01Context");
builder.Services.AddDbContext<Tvt_231230930_de01Context>(options =>
    options.UseSqlServer(tvtConnection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/TvtHome/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TvtHome}/{action=TvtIndex}/{id?}");

app.Run();
