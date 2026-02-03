using Application;
using Http;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddPresentation();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();