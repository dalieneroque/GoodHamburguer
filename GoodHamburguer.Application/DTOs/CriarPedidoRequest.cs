using GoodHamburguer.Domain.Enums;

namespace GoodHamburguer.API.DTOs;

public record CriarPedidoRequest(
    Sanduiche? Sanduiche,
    Acompanhamento? Acompanhamento,
    Bebida? Bebida
);