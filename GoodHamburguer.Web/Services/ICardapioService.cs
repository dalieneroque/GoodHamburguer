namespace GoodHamburguer.Web.Services;

using GoodHamburguer.Web.Models;

public interface ICardapioService
{
    Task<CardapioModel> ObterCardapioAsync();
}