using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.Api.DTOs;

public record CriarPedidoRequest(
    Sanduiche? Sanduiche,
    Acompanhamento? Acompanhamento,
    Bebida? Bebida
);