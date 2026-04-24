using GoodHamburguer.Web.Models;

namespace GoodHamburguer.Web.Services
{
    public interface IPedidoService
    {
        Task<PedidoRespostaModel?> CriarPedidoAsync(CriarPedidoModel model);
    }
}
