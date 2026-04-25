namespace GoodHamburguer.Web.Services;

using System.Net.Http.Json;
using GoodHamburguer.Web.Models;

public class CardapioService : ICardapioService
{
    private readonly HttpClient _http;

    public CardapioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<CardapioModel> ObterCardapioAsync()
    {
        return await _http.GetFromJsonAsync<CardapioModel>("api/cardapio")
               ?? new CardapioModel();
    }
}