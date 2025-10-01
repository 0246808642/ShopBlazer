using System.Collections.ObjectModel;

namespace ShopBlazor.Api.Entities;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Chave estrangeira para a categoria
    public long CategoryId { get; set; }

    // Propriedade de navegação
    public Category? Category { get; set; }

    // Relacionamento com itens do carrinho
    public Collection<ItemCart> Itens { get; set; } = new Collection<ItemCart>();
}
