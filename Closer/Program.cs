
using Closer.Data;
using Closer.Data.Repositories;
using Closer.dataaccess;
using Closer.Domain.Interface;
using Closer.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------------------------
//  Add services to the container
// -------------------------------------------------------------

builder.Services.AddControllersWithViews();

//  Register EF Core DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories & Services for Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Register other services (example: CartService)
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IContactMessageService, ContactMessageService>();
builder.Services.AddScoped<IContactMessageRepository, ContactMessagesRepository>();

//  Register HttpContextAccessor for accessing session/user info
builder.Services.AddHttpContextAccessor();

//  Configure Session (must come before middleware use)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// -------------------------------------------------------------
//  Configure the HTTP request pipeline
// -------------------------------------------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Optional: Use HTTPS Redirection in production
// app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//  Enable Session (before authorization)
app.UseSession();

app.UseAuthorization();

// Configure default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//using Closer.Data;
//using Closer.Data.Repositories;
//using Closer.Domain.Interface;
//using Closer.Services;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

////  Add services to the container
//builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

////  Register EF Core with connection string
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

////  Add session with configuration
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

//// Register HttpContextAccessor (for session or user access)
//builder.Services.AddHttpContextAccessor();

////  REMOVE THIS LINE — You deleted CartService
//// builder.Services.AddScoped<CartService>();

//var app = builder.Build();

//// Configure middleware pipeline
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

////app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseSession(); //  Enable session BEFORE authorization

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
