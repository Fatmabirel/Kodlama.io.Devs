using Application;
using Persistence;
using Core.CrossCuttingConcerns.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(); // add application services
builder.Services.AddPersistenceServices(builder.Configuration); //add persistence services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//if (app.Environment.IsProduction())
  // app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
