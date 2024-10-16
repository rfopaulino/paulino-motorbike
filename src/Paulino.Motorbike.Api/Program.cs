using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Consumers;
using Paulino.Motorbike.Infra.CrossCutting.EventBus;
using Paulino.Motorbike.Infra.Data.Dapper.Base;
using Paulino.Motorbike.Infra.Data.EF;
using RabbitMQ.Client;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<BaseResponse>());

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Paulino Motorbike",
        Description = "Aplicação para gerenciar aluguel de motos e entregadores"
    });

    options.EnableAnnotations();
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(connectionString));
builder.Services.AddScoped<IDapperRepository>(x => new DapperRepository(connectionString));

builder.Services.AddSingleton<IEventBusPersistentConnection>(sp =>
{
    var factory = new ConnectionFactory
    {
        Uri = new Uri(builder.Configuration["RabbitMQ:Uri"])
    };

    return new EventBusPersistentConnection(factory);
});

builder.Services.AddSingleton<IEventBus, EventBus>();
builder.Services.AddSingleton<IConsumer, NewMotorbike2024Consumer>(sp =>
{
    var persistentConnection = sp.GetService<IEventBusPersistentConnection>();
    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

    return new NewMotorbike2024Consumer(Queue.NEW_MOTORBIKE_2024, persistentConnection, scopeFactory);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

_ = app.Services.GetRequiredService<IEventBus>();
var consumers = app.Services.GetServices<IConsumer>();
foreach (var consumer in consumers)
    consumer.Subscribe();

app.Run();
