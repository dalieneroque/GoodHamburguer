using GoodHamburguer.Domain.Entidades;
using GoodHamburguer.Domain.Interfaces;
using GoodHamburguer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Pedido>> ObterTodosAsync()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido?> ObterPorIdAsync(Guid id)
    {
        return await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AtualizarAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Pedido pedido)
    {
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
    }
}