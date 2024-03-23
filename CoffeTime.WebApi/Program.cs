using Mediator.Handler;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Service.Conversor;
using Service.Service;
using Service.Service.Interface;
using WebApi.Converter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetAllCoffeesHandler).Assembly));
builder.Services.TryAddScoped<ICoffeeService, CoffeeService>();
builder.Services.TryAddScoped<ICalculateService, CalculateService>();
builder.Services.AddTransient<CooffeesConverter>();
builder.Services.AddTransient<CoffeeConsumptionConverter>();
builder.Services.AddTransient<CalculateConverter>();
builder.Services.AddTransient<CoffeeService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
