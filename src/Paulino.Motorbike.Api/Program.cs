using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Infra.Data.EF;

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
        Description = "Aplica��o para gerenciar aluguel de motos e entregadores"
    });

    options.EnableAnnotations();
});

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

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

app.Run();
