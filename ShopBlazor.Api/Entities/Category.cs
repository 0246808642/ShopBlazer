using System.Collections.ObjectModel;

namespace ShopBlazor.Api.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public string IconCSS { get; set; }= string.Empty;

        // Relacionamento com produtos
        public ICollection<Product>  Products { get; set; } = new List<Product>();
    }
}
