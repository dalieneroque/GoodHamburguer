using GoodHamburguer.Domain.Entidades;
using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Application.Services;

public class PedidoService
{
    public void Calcular(Pedido pedido)
    {
        decimal subtotal = 0;

        if (pedido.Sanduiche.HasValue)
            subtotal += ObterPrecoSanduiche(pedido.Sanduiche.Value);

        if (pedido.Acompanhamento.HasValue)
            subtotal += 2.00m;

        if (pedido.Bebida.HasValue)
            subtotal += 2.50m;

        var desconto = CalcularDesconto(pedido, subtotal);

        pedido.Subtotal = subtotal;
        pedido.Desconto = desconto;
        pedido.Total = subtotal - desconto;
    }

    private decimal CalcularDesconto(Pedido pedido, decimal subtotal)
    {
        bool temSanduiche = pedido.Sanduiche.HasValue;
        bool temBatata = pedido.Acompanhamento.HasValue;
        bool temBebida = pedido.Bebida.HasValue;

        if (temSanduiche && temBatata && temBebida)
            return subtotal * 0.20m;

        if (temSanduiche && temBebida)
            return subtotal * 0.15m;

        if (temSanduiche && temBatata)
            return subtotal * 0.10m;

        return 0;
    }

    private decimal ObterPrecoSanduiche(Sanduiche sanduiche) => sanduiche switch
    {
        Sanduiche.XBurger => 5.00m,
        Sanduiche.XEgg => 4.50m,
        Sanduiche.XBacon => 7.00m,
        _ => 0
    };
}