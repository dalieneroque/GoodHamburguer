using GoodHamburguer.Web.Models;

namespace GoodHamburguer.Web.Services
{
    public interface IPedidoService
    {
        Task<PedidoRespostaModel?> CriarPedidoAsync(CriarPedidoModel model);

        Task<List<PedidoRespostaModel>> ObterTodosAsync();

        Task<PedidoRespostaModel?> ObterPorIdAsync(Guid id);

        Task AtualizarPedidoAsync(Guid id, CriarPedidoModel pedido);

        Task DeletarPedidoAsync(Guid id);
    }
}
