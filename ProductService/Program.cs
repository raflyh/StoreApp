using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Environment
//if (builder.Environment.IsProduction())
//{
//    //SQL Server Di Sini
//}
//else
//{
//    Console.WriteLine("--> Dev Env: Using InMem Db");
//    builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
//}
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Inject Repo
builder.Services.AddScoped<IProductRepo, ProductRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
PrepDb.PrepPopulation(app, builder.Environment.IsProduction());

app.Run();
