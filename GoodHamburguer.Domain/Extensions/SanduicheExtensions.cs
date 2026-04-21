using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Domain.Extensions;

public static class SanduicheExtensions
{
    public static decimal ObterPreco(this Sanduiche sanduiche) => sanduiche switch
    {
        Sanduiche.XBurger => 5.00m,
        Sanduiche.XEgg => 4.50m,
        Sanduiche.XBacon => 7.00m,
        _ => throw new ArgumentOutOfRangeException(nameof(sanduiche))
    };
}