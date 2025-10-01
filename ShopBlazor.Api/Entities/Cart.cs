using System.Collections.ObjectModel;

namespace ShopBlazor.Api.Entities
{
    public class Cart
    {
        public long Id { get; set; }
        public long UserId { get; set; }

        public ICollection<ItemCart> Itens { get; set; } = new List<ItemCart>();
    }
}
