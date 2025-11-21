using Bài_TH_01.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register SchoolContext (InMemory for dev/demo). Replace with UseSqlServer/UseSqlite in real app.
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseInMemoryDatabase("School"));

var app = builder.Build();

// Initialize sample data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitalizer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// If you use attribute routing in controllers, ensure MapControllers exists (optional)
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
