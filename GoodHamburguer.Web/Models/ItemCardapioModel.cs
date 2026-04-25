namespace GoodHamburguer.Web.Models;

public class CardapioModel
{
    public List<ProdutoModel> Sanduiches { get; set; } = new();
    public List<ProdutoModel> Acompanhamentos { get; set; } = new();
    public List<ProdutoModel> Bebidas { get; set; } = new();
    public List<DescontoModel> Descontos { get; set; } = new();
}

public class ProdutoModel
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}

public class DescontoModel
{
    public string Descricao { get; set; } = string.Empty;
    public int Percentual { get; set; }
}