using Microsoft.EntityFrameworkCore;
using shop.Infraestructure.Context;
using shop.IOC.Dependencies;
using shop.Web.Services;
using shop.Web.Services.Caller;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<shopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("shopContext")));

builder.Services.AddOrderDependency();
builder.Services.AddShipperDependency();

builder.Services.AddTransient<IOrderApiService, OrderApiService>();
builder.Services.AddTransient<IShipperApiService, ShipperApiService>();

builder.Services.AddTransient<IApiServiceCaller, ApiServiceCaller>();

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
