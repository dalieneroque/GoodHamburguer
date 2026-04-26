using GoodHamburguer.Web.Models;

namespace GoodHamburguer.Web.Services
{
    public class CarrinhoService
    {
        public CriarPedidoModel Pedido { get; set; } = new();
        public Guid? PedidoId { get; set; } 

        public void Limpar()
        {
            Pedido = new CriarPedidoModel();
            PedidoId = null;
        }
    }
}