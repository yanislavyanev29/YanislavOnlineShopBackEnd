using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.DB;
using System.Text;
using YanislavOnlineShopBackEnd.Middleware;
using YanislavOnlineShopBackEnd.Seeder;
using YanislavOnlineShopBackEnd.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();





        


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
});
app.UseAuthorization();

app.MapControllers();





using var scope = app.Services.CreateScope();
var context  = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
var logger = scope.ServiceProvider.GetService<ILogger<Program>>();

try
{
     context.Database.Migrate();
    DbInitilizer.Initilize(context);
}
catch (Exception ex)
{

    logger.LogError(ex, "Problem of migrationg data");
}

app.Run();
