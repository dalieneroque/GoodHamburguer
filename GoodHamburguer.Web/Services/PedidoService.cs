using GoodHamburguer.Web.Models;
using System.Net.Http.Json;

namespace GoodHamburguer.Web.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly HttpClient _http;
        public PedidoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<PedidoRespostaModel?> CriarPedidoAsync(CriarPedidoModel model)
        {
            var resposta = await _http.PostAsJsonAsync("api/pedidos", model);
            resposta.EnsureSuccessStatusCode();
            return await resposta.Content.ReadFromJsonAsync<PedidoRespostaModel>();

        }


    }

}
