using AirlineBookingSystem.Bookings.Application.Consumers;
using AirlineBookingSystem.Bookings.Application.Handlers;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.Bookings.Infrastructure.Repositories;
using AirlineBookingSystem.BuildingBlocks.Common;
using MassTransit;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register MediatR
var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(GetBookingHandler).Assembly,
    typeof(CreateBookingHandler).Assembly
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

// Application Services
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// MassTransit
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<NotificationEventConsumer>();
    config.UsingRabbitMq((ct, cfg) => 
    {
        cfg.Host(builder.Configuration["EventBusSetting:HostAddress"]);
        cfg.ReceiveEndpoint(EventBusConstant.NotificationSentQueue, c =>
        {
            c.ConfigureConsumer<NotificationEventConsumer>(ct);
        });
    });
});

// Add Sql Connection
builder.Services.AddScoped<IDbConnection>(sp =>
new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


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
