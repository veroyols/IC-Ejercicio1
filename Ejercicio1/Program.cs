using Application.Interfaces;
using Application.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Query;
using Microsoft.EntityFrameworkCore;

//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//CORS
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => {
                          policy
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddControllersWithViews();


//db
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//dependencias 
builder.Services.AddTransient<IServiceClient, ServiceClient>();
builder.Services.AddTransient<ICommandClient, CommandClient>();
builder.Services.AddTransient<IQueryClient, QueryClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Client/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Clients}/{id?}");

app.MapControllerRoute(
    name: "GetNombreByCuit",
    pattern: "Client/GetNombreByCuit/{cuit?}",
    defaults: new { controller = "Client", action = "GetNombreByCuit" });

app.Run();
