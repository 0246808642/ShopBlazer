using System.Collections.ObjectModel;

namespace ShopBlazor.Api.Entities
{
    public class Cart
    {
        public long Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public ICollection<ItemCart> Itens { get; set; } = new List<ItemCart>();
    }
}
