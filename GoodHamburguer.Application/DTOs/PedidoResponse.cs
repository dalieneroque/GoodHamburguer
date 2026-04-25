using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Api.DTOs;

public record PedidoResponse(
    Guid Id,
    Sanduiche? Sanduiche,
    Acompanhamento? Acompanhamento,
    Bebida? Bebida,
    decimal Subtotal,
    decimal Desconto,
    decimal Total
);