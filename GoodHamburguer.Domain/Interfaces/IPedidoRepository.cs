using GoodHamburguer.Domain.Entidades;

namespace GoodHamburguer.Domain.Interfaces;

public interface IPedidoRepository
{
    Task AdicionarAsync(Pedido pedido);
    Task<List<Pedido>> ObterTodosAsync();
    Task<Pedido?> ObterPorIdAsync(Guid id);
    Task AtualizarAsync(Pedido pedido);
    Task RemoverAsync(Pedido pedido);
}