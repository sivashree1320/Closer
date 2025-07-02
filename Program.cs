using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Closer.Data; //  Add this to register ApplicationDbContext
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//  Add services to the container
builder.Services.AddControllersWithViews();

//  Register EF Core with connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//  Add session with configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register HttpContextAccessor (for session or user access)
builder.Services.AddHttpContextAccessor();

//  REMOVE THIS LINE — You deleted CartService
// builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Configure middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); //  Enable session BEFORE authorization

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

