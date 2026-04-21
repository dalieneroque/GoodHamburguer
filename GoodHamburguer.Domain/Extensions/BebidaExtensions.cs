using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Domain.Extensions
{
    public static class BebidaExtensions
    {
        public static decimal ObterPreco(this Bebida bebida) => bebida switch
        {
            Bebida.Refrigerante => 2.50m,
            _ => throw new ArgumentOutOfRangeException(nameof(bebida))
        };
    }
}