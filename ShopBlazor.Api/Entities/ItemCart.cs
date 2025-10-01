namespace ShopBlazor.Api.Entities
{
    public class ItemCart
    {
        public long  Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
