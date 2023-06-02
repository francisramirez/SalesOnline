using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.ApiServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddTransient<IProductApiService, ProductApiService>();

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
