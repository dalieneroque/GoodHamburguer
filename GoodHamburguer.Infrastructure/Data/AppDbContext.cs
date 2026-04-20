using GoodHamburguer.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}