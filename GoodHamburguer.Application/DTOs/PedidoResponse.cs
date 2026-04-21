using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.API.DTOs;

public record PedidoResponse(
    Guid Id,
    Sanduiche? Sanduiche,
    Acompanhamento? Acompanhamento,
    Bebida? Bebida,
    decimal Subtotal,
    decimal Desconto,
    decimal Total
);