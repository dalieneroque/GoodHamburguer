using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Domain.Entidades;

public class Pedido
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Sanduiche? Sanduiche { get; set; }
    public Acompanhamento? Acompanhamento { get; set; }
    public Bebida? Bebida { get; set; }

    public decimal Subtotal { get; set; }
    public decimal Desconto { get; set; }
    public decimal Total { get; set; }

    protected Pedido() { }

    public Pedido(Sanduiche? sanduiche, Acompanhamento? acompanhamento, Bebida? bebida)
    {
        Sanduiche = sanduiche;
        Acompanhamento = acompanhamento;
        Bebida = bebida;
    }

    public void AtualizarItens(Sanduiche? sanduiche, Acompanhamento? acompanhamento, Bebida? bebida)
    {
        Sanduiche = sanduiche;
        Acompanhamento = acompanhamento;
        Bebida = bebida;
    }

    public void AplicarCalculo(decimal subtotal, decimal desconto, decimal total)
    {
        Subtotal = subtotal;
        Desconto = desconto;
        Total = total;
    }
}


