using GoodHamburguer.Domain.Entidades;
using GoodHamburguer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Repositories;

public class PedidoRepository
{
    private readonly AppDbContext _context;

    public PedidoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Pedido>> ObterTodos()
    {
        return await _context.Pedidos.ToListAsync();
    }

    public async Task<Pedido?> ObterPorId(Guid id)
    {
        return await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Remover(Pedido pedido)
    {
        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();
    }

    public async Task Atualizar(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);
        await _context.SaveChangesAsync();
    }
}