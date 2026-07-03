using TaskManagement.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceServices(builder.Configuration);

var app = builder.Build();

//app.MapDefaultControllerRoute();

app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.Run();
