namespace GoodHamburguer.Web.Models
{
    public class ItemCardapioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}
