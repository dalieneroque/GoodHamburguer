namespace GoodHamburguer.Web.Models
{
    public class PedidoRespostaModel
    {
        public Guid Id { get; set; }
        public string? Sanduiche { get; set; }
        public string? Acompanhamento { get; set; }
        public string? Bebida { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total { get; set; }
    }
}
