namespace ShopBlazor.Api.Entities
{
    public class ItemCart
    {
        public long  Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }

        // Propriedades de navegação
        public Cart? Cart { get; set; }
        public Product? Product { get; set; }
    }
}
