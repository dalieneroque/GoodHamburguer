using GoodHamburguer.Domain.Entidades;
using GoodHamburguer.Domain.Enums;
using GoodHamburguer.Domain.Extensions;
using GoodHamburguer.Domain.Interfaces;

namespace GoodHamburguer.Application.Services;

public class PedidoService
{
    private readonly IPedidoRepository _repositorio;

    public PedidoService(IPedidoRepository repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Pedido> CriarAsync(Sanduiche? sanduiche, Acompanhamento? acompanhamento, Bebida? bebida)
    {
        var pedido = new Pedido(sanduiche, acompanhamento, bebida);
        Calcular(pedido);
        await _repositorio.AdicionarAsync(pedido);
        return pedido;
    }

    public async Task<List<Pedido>> ObterTodosAsync()
        => await _repositorio.ObterTodosAsync();

    public async Task<Pedido?> ObterPorIdAsync(Guid id)
        => await _repositorio.ObterPorIdAsync(id);

    public async Task AtualizarAsync(Guid id, Sanduiche? sanduiche, Acompanhamento? acompanhamento, Bebida? bebida)
    {
        var pedido = await _repositorio.ObterPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Pedido {id} não encontrado.");

        pedido.AtualizarItens(sanduiche, acompanhamento, bebida);
        Calcular(pedido);
        await _repositorio.AtualizarAsync(pedido);
    }

    public async Task RemoverAsync(Guid id)
    {
        var pedido = await _repositorio.ObterPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Pedido {id} não encontrado.");

        await _repositorio.RemoverAsync(pedido);
    }

    private static void Calcular(Pedido pedido)
    {
        decimal subtotal = 0;

        if (pedido.Sanduiche.HasValue)
            subtotal += pedido.Sanduiche.Value.ObterPreco();

        if (pedido.Acompanhamento.HasValue)
            subtotal += 2.00m;

        if (pedido.Bebida.HasValue)
            subtotal += 2.50m;

        var desconto = CalcularDesconto(pedido, subtotal);
        var total = subtotal - desconto;

        pedido.AplicarCalculo(subtotal, desconto, total); 
    }

    private static decimal CalcularDesconto(Pedido pedido, decimal subtotal)
    {
        bool temSanduiche = pedido.Sanduiche.HasValue;
        bool temBatata = pedido.Acompanhamento.HasValue;
        bool temBebida = pedido.Bebida.HasValue;

        if (temSanduiche && temBatata && temBebida) return subtotal * 0.20m;
        if (temSanduiche && temBebida) return subtotal * 0.15m;
        if (temSanduiche && temBatata) return subtotal * 0.10m;

        return 0;
    }
}