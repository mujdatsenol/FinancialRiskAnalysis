using FinancialRiskAnalysis.Api;
using FinancialRiskAnalysis.Infrastructure.Extensions;
using FinancialRiskAnalysis.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.RegisterApplicationServices();
builder.Services.RegisterMapper();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<MainDbContext>();
    db.Database.Migrate();
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

// INFO: WebApplcation için extension metod yazarak her bir servis için kullanılan endpointler api'ye tanıtılır.
// Buradaki amaç minimal API'nin sağladığı esneklik ile
// Controller yapısından bağımsız daha az kaynak tüketen API geliştirmek.
app.RegisterEndpoints();

app.Run();
