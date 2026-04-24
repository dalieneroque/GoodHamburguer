using GoodHamburguer.Web.Models;
using System.Net.Http.Json;

namespace GoodHamburguer.Web.Services
{
    public class CardapioService : ICardapioService
    {
        private readonly HttpClient _http;

        public CardapioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ItemCardapioModel>> ObterCardapioAsync()
        {
            return await _http.GetFromJsonAsync<List<ItemCardapioModel>>("api/menu")
                   ?? new List<ItemCardapioModel>();
        }
    }
}
