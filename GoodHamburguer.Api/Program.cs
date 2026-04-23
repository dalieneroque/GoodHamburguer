// src/GoodHamburguer.API/Program.cs
using GoodHamburguer.Application.Services;
using GoodHamburguer.Domain.Interfaces;
using GoodHamburguer.Infrastructure.Data;
using GoodHamburguer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// ── Banco de dados ────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(opcoes =>
    opcoes.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── Injeção de dependência ────────────────────────────────────────────────────
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

// ── API ───────────────────────────────────────────────────────────────────────
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── Configuração para serializar enums como strings ─────────────────────────
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();