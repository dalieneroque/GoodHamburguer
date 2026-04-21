using GoodHamburguer.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pedido>(entidade =>
        {
            entidade.HasKey(p => p.Id);

            entidade.Property(p => p.Subtotal)
                   .HasColumnType("decimal(18,2)"); 

            entidade.Property(p => p.Desconto)
                    .HasColumnType("decimal(18,2)");

            entidade.Property(p => p.Total)
                    .HasColumnType("decimal(18,2)");

            entidade.Property(p => p.Sanduiche)
                    .HasConversion<string>();

            entidade.Property(p => p.Acompanhamento)
                    .HasConversion<string>();

            entidade.Property(p => p.Bebida)
                    .HasConversion<string>(); 


        });
    }

}