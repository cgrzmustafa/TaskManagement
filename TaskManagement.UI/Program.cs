using TaskManagement.Persistance;
using TaskManagement.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();


app.UseStaticFiles();

// || AREA ALAN => Member, Admin =>

app.MapControllerRoute(name: "area", pattern: "{Area}/{Controller=Home}/{Action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{Controller=Account}/{Action=Login}/{id?}");

app.Run();
