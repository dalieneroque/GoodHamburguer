using GoodHamburguer.Api.DTOs;
using GoodHamburguer.Application.Services;
using GoodHamburguer.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidosController : ControllerBase
{
    private readonly PedidoService _service;

    public PedidosController(PedidoService service)
    {
        _service = service;
    }

    // GET /api/pedidos
    [HttpGet]
    public async Task<IActionResult> ObterTodos()
    {
        var pedidos = await _service.ObterTodosAsync();
        var response = pedidos.Select(ParaResponse);
        return Ok(response);
    }

    // GET /api/pedidos/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var pedido = await _service.ObterPorIdAsync(id);

        if (pedido is null)
            return NotFound(new { mensagem = $"Pedido {id} não encontrado." });

        return Ok(ParaResponse(pedido));
    }

    // POST /api/pedidos
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarPedidoRequest request)
    {
        try
        {
            var pedido = await _service.CriarAsync(
                request.Sanduiche,
                request.Acompanhamento,
                request.Bebida
            );

            return CreatedAtAction(
                nameof(ObterPorId),
                new { id = pedido.Id },
                ParaResponse(pedido)
            );
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }


    // PUT /api/pedidos/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] CriarPedidoRequest request)
    {
        try
        {
            await _service.AtualizarAsync(
                id,
                request.Sanduiche,
                request.Acompanhamento,
                request.Bebida
            );

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    // DELETE /api/pedidos/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remover(Guid id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }

    private static PedidoResponse ParaResponse(Domain.Entidades.Pedido pedido) => new(
        pedido.Id,
        pedido.Sanduiche,
        pedido.Acompanhamento,
        pedido.Bebida,
        pedido.Subtotal,
        pedido.Desconto,
        pedido.Total
    );
}