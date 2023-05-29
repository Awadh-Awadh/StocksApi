using Infrastructure;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
});
builder.Services.AddInfrastructureServices(configuration);

// configure serilog
builder.Host.UseSerilog((context, provider, config) =>
{
    config
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(provider);
});

// var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(configuration)
//     .Enrich.FromLogContext()
//     .CreateLogger();
//
// builder.Logging.ClearProviders();
// builder.Logging.AddSerilog(logger);
//
// logger.Information("logging works");
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
