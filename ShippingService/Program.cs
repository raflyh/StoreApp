using Microsoft.EntityFrameworkCore;
using ShippingService.AsyncDataServices;
using ShippingService.Data;
using ShippingService.EventProcessing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Menambahkan auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Menambahkan DbContext
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
//Menambahkan Shipping Repository
builder.Services.AddScoped<IShipping,ShippingRepo>();
//Menambahkan proses masuk order
builder.Services.AddSingleton<IEventProcessor,EventProcessor>();

builder.Services.AddHostedService<MessageBusSubscriber>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
