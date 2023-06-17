using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.ApiServices.Services;
using SalesOnline.Web.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
///

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();


#region "Apis Dependency"

builder.Services.AddApiAlmancenDependency();
builder.Services.AddAuthDependencyApi();

#endregion


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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
