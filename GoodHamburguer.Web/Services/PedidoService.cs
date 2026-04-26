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
            var response = await _http.PostAsJsonAsync("api/pedidos", model);

            if (!response.IsSuccessStatusCode)
            {
                var erroApi = await response.Content.ReadAsStringAsync();
                throw new Exception(erroApi);
            }

            return await response.Content.ReadFromJsonAsync<PedidoRespostaModel>();
        }

        public async Task<List<PedidoRespostaModel>> ObterTodosAsync()
        {
            return await _http.GetFromJsonAsync<List<PedidoRespostaModel>>("api/pedidos")
                   ?? new List<PedidoRespostaModel>();
        }

        public async Task<PedidoRespostaModel?> ObterPorIdAsync(Guid id)
        {
            var response = await _http.GetAsync($"api/pedidos/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<PedidoRespostaModel>();
        }

        public async Task AtualizarPedidoAsync(Guid id, CriarPedidoModel pedido)
        {
            var response = await _http.PutAsJsonAsync($"api/pedidos/{id}", pedido);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao atualizar pedido");
        }

        public async Task DeletarPedidoAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"api/pedidos/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao deletar pedido");
        }
    }
}