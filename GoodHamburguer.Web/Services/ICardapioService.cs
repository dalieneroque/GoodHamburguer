using GoodHamburguer.Web.Models;

namespace GoodHamburguer.Web.Services
{
    public interface ICardapioService
    {
        Task<List<ItemCardapioModel>> ObterCardapioAsync();
    }
}
