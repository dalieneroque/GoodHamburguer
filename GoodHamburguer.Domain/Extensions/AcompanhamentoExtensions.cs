using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Domain.Extensions
{
    public static class AcompanhamentoExtensions
    {
        public static decimal ObterPreco(this Acompanhamento acompanhamento) => acompanhamento switch
        {
            Acompanhamento.BatataFrita => 2.00m, 
            _ => throw new ArgumentOutOfRangeException(nameof(acompanhamento))
        };
    }
}