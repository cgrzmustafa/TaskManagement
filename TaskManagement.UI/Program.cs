using TaskManagement.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddPersistanceServices(builder.Configuration);

var app = builder.Build();



app.Run();
