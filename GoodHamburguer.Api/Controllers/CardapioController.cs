using GoodHamburguer.Domain.Enums;
using GoodHamburguer.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GoodHamburguer.API.Controllers;

[ApiController]
[Route("api/cardapio")]
public class CardapioController : ControllerBase
{
    [HttpGet]
    public IActionResult ObterCardapio()
    {
        var cardapio = new
        {
            Sanduiches = Enum.GetValues<Sanduiche>()
                .Select(s => new
                {
                    Nome = s.ToString(),
                    Preco = s.ObterPreco()
                }),

            Acompanhamentos = Enum.GetValues<Acompanhamento>()
                .Select(a => new
                {
                    Nome = a.ToString(),
                    Preco = a.ObterPreco()
                }),

            Bebidas = Enum.GetValues<Bebida>()
                .Select(b => new
                {
                    Nome = b.ToString(),
                    Preco = b.ObterPreco()
                }),

            Descontos = new[]
            {
                new { Descricao = "Combo completo (Sanduíche + Batata + Refrigerante)", Percentual = 20 },
                new { Descricao = "Sanduíche + Refrigerante", Percentual = 15 },
                new { Descricao = "Sanduíche + Batata", Percentual = 10 }
            }
        };

        return Ok(cardapio);
    }
}